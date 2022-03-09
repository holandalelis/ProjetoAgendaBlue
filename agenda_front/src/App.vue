<template>
  <div class="container" id="app">
    <div class="nav-scroller py-1 mb-2">
      <nav class="nav d-flex justify-content-between">
        <a class="p-2 text-muted text black font italic" href="/">Agenda/Home</a>
        <a class="p-2 text-muted text black font italic" href="https://www.linkedin.com/company/blue-technology-brasil/" target="_blank">Blue Technology</a>
      </nav>
    </div>
    <img alt="Vue logo" src="./assets/logo.png">
    <hello-world msg="Bem Vindo(a) a Agenda da Blue Technology"/>
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue'

export default {
  name: 'App',
  components: {
    HelloWorld
  }
}
</script>
