<template>
  <div class="GuestInfo">
    <h1>{{ $route.query.name }}，您好!</h1>
    <h3>請留在此頁，出示以下資訊給接待人員</h3>
    <form class="pure-form pure-form-aligned children">
    <fieldset>
        <div class="pure-control-group">
          <div class="pure-u-1-4"></div>
          <div class="pure-u-3-4"><h2 style="text-align: left;">編號: {{ $route.query.id }}</h2></div>
        </div>
        <div class="pure-control-group">
          <div class="pure-u-1-4"><p></p></div>
          <div class="pure-u-3-4"><h2 style="text-align: left;">關係: {{ $route.query.owner }} {{ $route.query.relation }}</h2></div>
        </div>
        <div class="pure-control-group">
          <div class="pure-u-1-4"><p></p></div>
          <div class="pure-u-3-4"><h2 style="text-align: left;">攜伴: {{ $route.query.partner }}</h2></div>
        </div>
        <div class="pure-control-group" >
          <div class="pure-u-1-4"><p></p></div>
          <div class="pure-u-3-4" v-if="$route.query.tableId"><h2  style="text-align: left;">桌號: {{ $route.query.tableId }}</h2></div>
          <div class="pure-u-3-4" v-else><h2  style="text-align: left;color:#e9322d;">桌號: </h2></div>
        </div>
        <div class="pure-control-group">
          <div class="pure-u-1-4"><p></p></div>
          <div class="pure-u-3-4"><h2 style="text-align: left;">喜餅: {{ $route.query.weddingCake }}</h2></div>
        </div>
    </fieldset>
    </form>
  </div>
</template>

<script>
export default {
  name: 'GuestInfo',
  props: {
    name: String,
    id: String,
    owner: String,
    relation: String,
    tableId: String,
    weddingCake: String,
    partner: String
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.GuestInfo{
  margin: 0;
  padding: 0;
  -webkit-animation: fadein 4s; /* Safari, Chrome and Opera > 12.1 */
    -moz-animation: fadein 4s; /* Firefox < 16 */
    -ms-animation: fadein 4s; /* Internet Explorer */
      -o-animation: fadein 4s; /* Opera < 12.1 */
        animation: fadein 4s;
}

@keyframes fadein {
    from { opacity: 0; }
    to   { opacity: 1; }
}

/* Firefox < 16 */
@-moz-keyframes fadein {
    from { opacity: 0; }
    to   { opacity: 1; }
}

/* Safari, Chrome and Opera > 12.1 */
@-webkit-keyframes fadein {
    from { opacity: 0; }
    to   { opacity: 1; }
}

/* Internet Explorer */
@-ms-keyframes fadein {
    from { opacity: 0; }
    to   { opacity: 1; }
}

/* Opera < 12.1 */
@-o-keyframes fadein {
    from { opacity: 0; }
    to   { opacity: 1; }
}
.children {
position: relative;
bottom: 0%;
transform: translateY(0%);
}
.pure-u-3-4 h2{
  margin: 1em 0 0 0;
}
</style>
