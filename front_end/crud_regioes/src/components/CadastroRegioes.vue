<script setup lang="ts">
import { ref } from 'vue'

interface Regiao {
  uf: string
  regiao: string
  situacao: 'Ativo' | 'Inativo'
}

const ufs = ['São Paulo', 'Minas Gerais', 'Rio de Janeiro']

const ufSelecionada = ref('')
const regiao = ref('')
const regioes = ref<Regiao[]>([
  { uf: 'São Paulo', regiao: 'Grande ABC', situacao: 'Ativo' },
  { uf: 'São Paulo', regiao: 'Grande Campinas', situacao: 'Inativo' },
])

function inserir() {
  if (!ufSelecionada.value || !regiao.value) {
    alert('Preencha todos os campos!')
    return
  }
  regioes.value.push({
    uf: ufSelecionada.value,
    regiao: regiao.value,
    situacao: 'Ativo',
  })
  ufSelecionada.value = ''
  regiao.value = ''
}

function ativar(index: number) {
  regioes.value[index].situacao = 'Ativo'
}

function inativar(index: number) {
  regioes.value[index].situacao = 'Inativo'
}

function editar(index: number) {
  const r = regioes.value[index]
  ufSelecionada.value = r.uf
  regiao.value = r.regiao
  regioes.value.splice(index, 1)
}
</script>

<template>
  <div class="cadastro-container">
    <div class="formulario">
      <h3>Cadastro de Regiões</h3>

      <label> UF <span class="required">*</span> </label>
      <select v-model="ufSelecionada">
        <option value="">Selecione</option>
        <option v-for="uf in ufs" :key="uf" :value="uf">{{ uf }}</option>
      </select>

      <label> Região <span class="required">*</span> </label>
      <input type="text" v-model="regiao" />

      <button @click="inserir">Inserir</button>
    </div>

    <table>
      <thead>
        <tr>
          <th>UF</th>
          <th>Região</th>
          <th>Situação</th>
          <th>Ações</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(r, index) in regioes" :key="index">
          <td>{{ r.uf }}</td>
          <td>{{ r.regiao }}</td>
          <td :class="r.situacao === 'Ativo' ? 'ativo' : 'inativo'">
            {{ r.situacao }}
          </td>
          <td>
            <a href="#" @click.prevent="editar(index)">Editar</a> |
            <a href="#" @click.prevent="r.situacao === 'Ativo' ? inativar(index) : ativar(index)">
              {{ r.situacao === 'Ativo' ? 'Inativar' : 'Ativar' }}
            </a>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<style scoped>
.cadastro-container {
  border: 1px solid #999;
  width: 75vw;
  box-sizing: border-box;
  font-family: Arial, sans-serif;
  justify-content: center; /* centraliza na horizontal */
  align-items: center; /* centraliza na vertical */
  height: 100vh; /* ocupa a altura total da tela */
  background: #fff;
}

/* --- FORMULÁRIO --- */
.formulario {
  background: #ffebcd;
  padding: 10px;
  border-bottom: 1px solid #999;
}

.formulario h3 {
  margin: 0 0 10px 0;
  padding: 0;
  font-size: 16px;
  color: #000;
}

label {
  display: block;
  margin-top: 5px;
  font-size: 14px;
  color: #000;
}

.required {
  color: red;
}

select,
input {
  width: 98%;
  padding: 5px;
  margin-top: 3px;
  border: 1px solid #ccc;
  border-radius: 2px;
}

button {
  margin-top: 10px;
  padding: 5px 10px;
  background: #eee;
  border: 1px solid #999;
  border-radius: 3px;
  cursor: pointer;
}

button:hover {
  background: #ddd;
}

/* --- TABELA --- */
table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 0;
}

th {
  background: #ccc;
  padding: 5px;
  text-align: left;
  font-size: 14px;
}

td {
  border: 1px solid #ccc;
  padding: 5px;
  font-size: 14px;
  color: #000;
}

.ativo {
  color: black;
}

.inativo {
  color: red;
}

a {
  color: blue;
  text-decoration: underline;
  cursor: pointer;
}
</style>
