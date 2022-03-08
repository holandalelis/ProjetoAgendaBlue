<template>
  <div class="container" id="app">
    <div class="nav-scroller py-1 mb-2">
      <nav class="nav d-flex justify-content-between">
        <a class="p-2 text-muted text black font italic" href="/">Agenda Blue Technology</a>
        <a class="p-2 text-muted text black font italic" href="https://www.linkedin.com/company/blue-technology-brasil/">Blue Technology</a>
      </nav>
    </div>
  </div>
    <img alt="Vue logo" src="./assets/logo.png">
    <Contatos msg="Bem Vindo(a) a Agenda da Blue Technology"/>
</template>

<script>
import Contatos from './components/Contatos.vue'

export default {
  name: 'App',
  components: {
    Contatos
  }
}
</script>
