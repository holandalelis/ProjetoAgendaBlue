<template>
  <div>
    <div class="jumbotron p-3 p-md-5 text-white rounded bg-dark">
      <div class="col-md-6 px-0">
          <h1 class="display-4 font italic">{{ msg }}</h1>
      </div>
    </div>
    <form>
      <div class="form-groupr">
        <label for="nome">Nome</label>
        <input type="hidden" id="id" name="id">
        <input type="text" class="form-control" id="nome" name="nome" placeholder="Digite o Nome">
      </div>
      <div class="form-group">
        <label for="telefone">Telefone</label>
        <input type="tel" class="form-control" id="telefone" name="telefone" placeholder="Digite o Telefone">
      </div>
      <div class="form-group">
        <label for="email">Email</label>
        <input type="text" class="form-control" id="email" name="email" placeholder="Digite o Email">
      </div>
      <button v-on:click="salvar()" type="button" class="btn btn-primary">Enviar</button>
      <div style="color: red">
        {{mensagem}}
      </div>
    </form>
    <hr>
    <table class="table">
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
          <th colspan="2">

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
          <td>
            <button class="btn btn-primary" v-on:click="editar(contato)">Editar</button>
          </td>
          <td>
            <button class="btn btn-danger" v-on:click="excluir(contato.id)">Excluir</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios';
let scopoContatos = null;
export default {
  name: 'HelloWorld',
  props: {
    msg: String
  },
  data: () => {
    return {
      contatos: [],
      mensagem: ""
    }
  },
  methods: {
    lista(){
      axios.get('https://localhost:44387/contatos').then((res)=>{
        scopoContatos.contatos = res.data
      })
    },
    salvar: () =>{
      axios.post('https://localhost:44387/contatos', 
      {
        nome: document.getElementById("nome").value,
        telefone: document.getElementById("telefone").value,
        email: document.getElementById("email").value
      }).then(()=>{
        scopoContatos.lista()
      })
    }
  },
  created(){
    scopoContatos = this;
    this.lista()
  }
}
</script>