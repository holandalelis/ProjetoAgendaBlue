<template>
  <div>
    <h1>{{ msg }}</h1>
    <table>
      <thead>
        <tr>
          <th>
            Id
          </th>
          <th>
            Nome
          </th>
          <th>
            Telefone
          </th>
          <th>
            Email
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="contato in contatos" v-bind:key="contato.id">
          <td>
            {{contato.id}}
          </td>
          <td>
            {{contato.nome}}
          </td>
          <td>
            {{contato.telefone}}
          </td>
          <td>
            {{contato.email}}
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  name: 'ContatosAgenda',
  props: {
    msg: String
  },
  data: () => {
    return {
      contatos: [],
    }
  },
  methods: {
    lista: (scope) => {
      axios.get('https://localhost:44387/contatos').then((res)=>{
      console.log(res)
      scope.contatos = res.data
      })
    }
  },
  created(){
    this.lista(this)
  }
}
</script>