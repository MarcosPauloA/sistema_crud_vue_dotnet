import axios from 'axios'

export interface Regiao {
  id?: number
  uf: string
  nome: string
  situacao: 'Ativo' | 'Inativo'
}

const api = axios.create({
  baseURL: 'http://localhost:5211/api/regiao', // ajuste a porta se necessário
})

export default {
  async listar(): Promise<Regiao[]> {
    const { data } = await api.get('/')
    return data
  },

  async cadastrar(regiao: Regiao): Promise<Regiao> {
    console.log('Cadastrando região:', regiao)
    const { data } = await api.post('/', regiao)
    return data
  },

  async atualizar(id: number, regiao: Regiao) {
    await api.put(`/${id}`, regiao)
  },

  async excluir(id: number) {
    await api.delete(`/${id}`)
  },
}
