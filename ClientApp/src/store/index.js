import { create } from "zustand";

const useGlobalStore = create((set) => ({
  // Produtos
  produtos: [],
  setProdutos: (novosProdutos) => set({ produtos: novosProdutos }),
  adicionarProduto: (novoProduto) =>
    set((state) => ({ produtos: [...state.produtos, novoProduto] })),
  setProdutos: (novosProdutos) => set({ produtos: novosProdutos }),

  // Entrada de Mercadoria
  entradas: [],
  setEntradas: (novasEntradas) => set({ entradas: novasEntradas }),
  novaEntrada: {
    numeroEntrada: 0,
    passo: 1,
    produtos: [],
    totalVolume: 0,
    totalPeso: 0,
    totalValor: 0,
  },
  setNovaEntrada: (novaEntrada) => set({ novaEntrada: novaEntrada }),
  produtosEntrada: [],
  setProdutosEntrada: (novosProdutos) =>
    set({ produtosEntrada: novosProdutos }),

  // Mapa Estoque
  mapaEstoque: [],
  setMapaEstoque: (novoEstoque) => set({ mapaEstoque: novoEstoque }),

  // Usuário
  nomeUsuario: "",
  setNomeUsuario: (novoNome) => set({ nomeUsuario: novoNome }),
}));

export default useGlobalStore;
