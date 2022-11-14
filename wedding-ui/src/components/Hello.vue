<template>
  <div class="Hello">
    <h1>{{ msg }}</h1>
    <h2>{{ keyName }}</h2>
    <form class="pure-form pure-form-aligned">
      <fieldset>
        <div class="pure-control-group">
          <input v-model="name" type="name" placeholder="請輸入您的名字" />
        </div>
      </fieldset>
    </form>
    <button
      v-on:click="CheckGuest" @keyup.enter="CheckGuest"
      class="pure-button pure-button-primary formButtonfront"
    >
      送出
    </button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Hello",
  props: {
    msg: String,
    keyName: String,
    name: String,
  },
  mounted: function () {
    this.msg = "歡迎!";
    this.keyName = "請問您的名字?";
  },
  methods: {
    CheckGuest: function () {
      axios
        .get("https://wedding-api-egtt6zjfzq-uw.a.run.app/api/Wedding/Guest/" + this.name)
        .then((res) => {
          var guest = res.data.guest;
          var table = res.data.table;
          console.log(guest.name);
          console.log(guest.id);
          this.$router.push({
            path: "/about",
            query: {
              name: guest.name,
              id: guest.id,
              owner: guest.owner,
              relation: guest.relation,
              tableId: table?.name,
              weddingCake: guest.weddingCake,
              partner: guest.partner
            },
          });
        })
        .catch((err) => {
          console.log(err.response.status === 404)
          if (err.response.status === 404) {
            this.$router.push({
              path: "/newGuest",
              query: {
                name: this.name
              },
            });
          }
        });

      //
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.Hello {
  margin: 0;
  padding: 0;
  -webkit-animation: fadein 4s; /* Safari, Chrome and Opera > 12.1 */
  -moz-animation: fadein 4s; /* Firefox < 16 */
  -ms-animation: fadein 4s; /* Internet Explorer */
  -o-animation: fadein 4s; /* Opera < 12.1 */
  animation: fadein 4s;
}

input[type="name"],
select,
textarea {
  width: 60%;
  padding: 12px;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
  resize: vertical;
  max-width: 25rem;
}

.formButtonfront {
  border: 1px solid gray;
  border-radius: 7%;
  font-size: 0.875;
  word-wrap: break-word;
  width: 80px;
  max-width: 100%;
}

@keyframes fadein {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}

/* Firefox < 16 */
@-moz-keyframes fadein {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}

/* Safari, Chrome and Opera > 12.1 */
@-webkit-keyframes fadein {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}

/* Internet Explorer */
@-ms-keyframes fadein {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}

/* Opera < 12.1 */
@-o-keyframes fadein {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}
</style>
