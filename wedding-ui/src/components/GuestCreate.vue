<template>
  <div class="GuestCreate fadein">
    <h1>{{ $route.query.name }}，您好!</h1>
    <div class="fadein QuestionArea" v-show="showQuestion1">
      <div><h2>請問是男方親友還是女方親友?</h2></div>
      <div style="height: 80%">
        <ul>
          <li>
            <span
              ><button class="button-74" v-on:click="SetOwner(false)">
                男 方
              </button></span
            >
          </li>
          <li>
            <span
              ><button class="button-74" v-on:click="SetOwner(true)">
                女 方
              </button></span
            >
          </li>
        </ul>
      </div>
    </div>
    <div class="fadein QuestionArea" v-show="showQuestion2">
      <div><h2>與新人的關係?</h2></div>
      <div style="height: 80%">
        <ul>
          <li>
            <span
              ><button class="button-74" v-on:click="SetRelation('主婚人親友')">
                主婚人親友
              </button></span
            >
          </li>
          <li>
            <span
              ><button class="button-74" v-on:click="SetRelation('親戚')">
                親 戚
              </button></span
            >
          </li>
          <li>
            <span
              ><button class="button-74" v-on:click="SetRelation('同事')">
                同 事
              </button></span
            >
          </li>
          <li>
            <span
              ><button class="button-74" v-on:click="SetRelation('朋友')">
                朋 友
              </button></span
            >
          </li>
          <li>
            <span
              ><button class="button-74" v-on:click="SetRelation('同學')">
                同 學
              </button></span
            >
          </li>
        </ul>
      </div>
    </div>
    <div class="fadein QuestionArea" v-show="showQuestion3">
      <div><h2>請問有攜伴嗎?</h2></div>
      <div style="height: 80%">
        <ul>
          <li>
            <span
              ><button class="button-74" v-on:click="SetPartner('')">
                無
              </button></span
            >
          </li>
          <li>
            <span
              ><button class="button-74" v-on:click="SetPartner('1')">
                攜伴 1 人
              </button></span
            >
          </li>
          <li>
            <span
              ><button class="button-74" v-on:click="SetPartner('2')">
                攜伴 2 人
              </button></span
            >
          </li>
          <li>
            <span
              ><button class="button-74" v-on:click="SetPartner('3')">
                攜伴 3 人
              </button></span
            >
          </li>
          <li>
            <span
              ><button class="button-74" v-on:click="SetPartner('超過3人')">
                超過3人
              </button></span
            >
          </li>
        </ul>
      </div>
    </div>
    <div class="fadein QuestionArea" v-show="showQuestion4">
      <div><h2>請問需要喜餅嗎?</h2></div>
      <div style="height: 80%">
        <ul>
          <li>
            <span
              ><button class="button-74" v-on:click="SetWeddingCake(true)">
                好 呀
              </button></span
            >
          </li>
          <li>
            <span
              ><button class="button-74" v-on:click="SetWeddingCake(false)">
                不需要，謝謝
              </button></span
            >
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "GuestCreate",
  data() {
    return {
      name: this.$route.query.name,
      owner: "",
      relation: "",
      partner: "",
      weddingCake: "",
      showQuestion1: true,
      showQuestion2: false,
      showQuestion3: false,
      showQuestion4: false,
    };
  },
  methods: {
    SetOwner(aileen) {
      this.owner = aileen ? "林歆恬" : "賴俊豪";
      this.showQuestion1 = false;
      this.showQuestion2 = true;
    },
    SetRelation(relation) {
      this.relation = relation;
      this.showQuestion2 = false;
      this.showQuestion3 = true;
    },
    SetPartner(partner) {
      this.partner = partner;
      this.showQuestion3 = false;
      this.showQuestion4 = true;
    },
    SetWeddingCake(weddingCake) {
      this.weddingCake = weddingCake;
      axios
        .post("https://wedding-api-egtt6zjfzq-uw.a.run.app/api/Wedding/Guest", {
          Name: this.name,
          Owner: this.owner,
          Relation: this.relation,
          WeddingCake: this.weddingCake,
          Partner: this.partner
        })
        .then((res) => {
          var guest = res.data.guest;
          console.log(guest.name);
          console.log(guest.id);
          this.$router.push({
            path: "/about",
            query: {
              name: guest.name,
              id: guest.id,
              owner: guest.owner,
              relation: guest.relation,
              tableId: guest.tableId,
              weddingCake: guest.weddingCake,
              partner: guest.partner
            },
          });
        });
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.GuestCreate {
  height: 100%;
  margin: 0;
  padding: 0;
}

.fadein {
  -webkit-animation: fadein 4s; /* Safari, Chrome and Opera > 12.1 */
  -moz-animation: fadein 4s; /* Firefox < 16 */
  -ms-animation: fadein 4s; /* Internet Explorer */
  -o-animation: fadein 4s; /* Opera < 12.1 */
  animation: fadein 4s;
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

.pure-u-1-1 {
  margin-top: 15px;
}

/* CSS */
.button-74 {
  background-color: #fbeee0;
  border: 2px solid #422800;
  border-radius: 30px;
  box-shadow: #422800 4px 4px 0 0;
  color: #422800;
  cursor: pointer;
  display: inline-block;
  font-weight: 600;
  font-size: 6vw;
  padding: 0 18px;
  line-height: 40px;
  text-align: center;
  text-decoration: none;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
}

.button-74:hover {
  background-color: #fff;
}

.button-74:active {
  box-shadow: #422800 2px 2px 0 0;
  transform: translate(2px, 2px);
}

@media (min-width: 768px) {
  .button-74 {
    min-width: 120px;
    padding: 0 25px;
  }
}

ul {
  display: table;
  table-layout: fixed;
  width: 100%;
  height: 100%;
  -moz-box-sizing: border-box;
  box-sizing: border-box;
}

li {
  text-align: center;
  display: table-row;
}
span {
  display: table-cell;
  vertical-align: middle;
}

.QuestionArea {
  height: 100%;
}
</style>
