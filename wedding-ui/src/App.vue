<template>
  <div id="app">
    <div class="row header-img"/>
    <div class="row middle">
      <div class="pure-u-1" style="height:100%">
        <router-view/>
      </div>
    </div>
    <div class="row footer"/>
  </div>
</template>

<style>
html,body {
    padding:0;
    margin:0;
    height:100%;
    background-color: #fffdf7;
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  height:100%;
  padding:0;
  margin:0;
  margin-top: 2rem;
  background-image: url("./assets/backgroud_footer.png");
    background-repeat: no-repeat; 
    background-position: center;
    background-attachment: fixed;       
    -webkit-background-size: cover;
    -moz-background-size: cover;
    -o-background-size: cover;
    background-size: cover;
    height:100%;
    width:100%;
}

.row.header-img{
  width:100%;
  height:20%;
  background-image: url("./assets/Caesar_Aileen.png");
  background-size: 80%;
  background-repeat: no-repeat;
  background-position:center;
}
.row.middle{
  height:50%;
}
.row.footer{
  height:25%;
}

h1 {
  font-size:10vw;
}
h2 {
  font-size:6vw;
}
h3 {
  font-size:5vw;
}
</style>
