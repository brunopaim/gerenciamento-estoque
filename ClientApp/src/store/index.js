import create from "zustand";

const useProdutoStore = create((set) => ({
  produtos: [],
  setProdutos: (novosProdutos) => set({ produtos: novosProdutos }),
  adicionarProduto: (novoProduto) =>
    set((state) => ({ produtos: [...state.produtos, novoProduto] })),
}));

export default useProdutoStore;
