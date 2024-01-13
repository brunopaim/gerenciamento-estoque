// React
import React, { useEffect, useState } from "react";

// Material UI
import {
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  TextField,
  Button,
} from "@mui/material";

import { BotaoCancelar, BotaoProximo } from "./styles";

// Zustand
import useGlobalStore from "../../../store";

const Passo1 = ({}) => {
  const {
    produtos,
    setProdutos,
    produtosEntrada,
    setProdutosEntrada,
    novaEntrada,
    setNovaEntrada,
  } = useGlobalStore();

  const [produtoSelecionado, setProdutoSelecionado] = useState(null);
  const [quantidade, setQuantidade] = useState(0);

  //const [produtosEntrada, setProdutosEntrada] = useState(novaEntrada.produtos);

  const handleProductChange = (event) => {
    setProdutoSelecionado(event.target.value);
  };

  const handleQuantityChange = (event) => {
    setQuantidade(event.target.value);
  };

  const handleAddRow = () => {
    let produtoFilter = {};
    produtos.map((data) => {
      if (data.produtoId == produtoSelecionado) {
        produtoFilter = { ...data, quantidade: parseInt(quantidade, 10) };
      }
    });
    const newData = [...produtosEntrada, produtoFilter];
    setProdutosEntrada(newData);

    // Totais Produos Entrada
    const totalVolume = newData.reduce(
      (total, produto) => total + produto.volumeCubico * produto.quantidade,
      0
    );
    const totalPeso = newData.reduce(
      (total, produto) => total + produto.peso * produto.quantidade,
      0
    );
    const totalValor = newData.reduce(
      (total, produto) => total + produto.valorUnitario * produto.quantidade,
      0
    );

    const newDataEntrada = {
      ...novaEntrada,
      totalPeso,
      totalValor,
      totalVolume,
    };
    setNovaEntrada(newDataEntrada);

    // Limpar os campos após adicionar a linha
    setProdutoSelecionado(null);
    setQuantidade(0);
  };

  const handleDeleteRow = (id) => {
    const novaLista = produtosEntrada.filter((prod) => prod.produtoId !== id);
    setProdutosEntrada(novaLista);

    // Totais Produtos Entrada
    const totalVolume = novaLista.reduce(
      (total, produto) => total + produto.volumeCubico * produto.quantidade,
      0
    );
    const totalPeso = novaLista.reduce(
      (total, produto) => total + produto.peso * produto.quantidade,
      0
    );
    const totalValor = novaLista.reduce(
      (total, produto) => total + produto.valorUnitario * produto.quantidade,
      0
    );

    const newDataEntrada = {
      ...novaEntrada,
      totalPeso,
      totalValor,
      totalVolume,
    };
    setNovaEntrada(newDataEntrada);
  };

  //TODO: É necessário essa chamada do backend novamente?
  useEffect(() => {
    fetch("/api/Produto")
      .then((response) => response.json())
      .then((data) => setProdutos(data))
      .catch((error) => console.error("Erro ao obter produtos:", error));
  }, [setProdutos]);

  return (
    <div>
      <br />
      <h2>Passo 1: Iniciar nova entrada</h2>
      <br />
      <div style={{ display: "flex", marginBottom: "10px" }}>
        <FormControl style={{ width: "350px", marginRight: "10px" }}>
          <InputLabel id="product-label">Produto</InputLabel>
          <Select
            labelId="product-label"
            id="product-select"
            value={produtoSelecionado}
            onChange={handleProductChange}
          >
            {produtos.map((produto) => (
              <MenuItem key={produto.produtoId} value={produto.produtoId}>
                {produto.nome}
              </MenuItem>
            ))}
          </Select>
        </FormControl>
        <TextField
          label="Quantidade"
          type="number"
          value={quantidade}
          onChange={handleQuantityChange}
          style={{ marginRight: "10px", width: "150px" }}
        />
        <Button
          variant="contained"
          onClick={handleAddRow}
          disabled={!produtoSelecionado || quantidade < 1}
        >
          +
        </Button>
      </div>
      <br />

      {/* Lista/Grid de produtos */}
      <ul style={{ listStyle: "none", padding: 0 }}>
        {/* Cabeçalho da tabela */}
        <li
          style={{
            marginBottom: "10px",
            borderBottom: "1px solid #ccc",
            display: "flex",
            alignItems: "center",
            justifyContent: "space-between",
            fontWeight: "bold",
          }}
        >
          <div style={{ flex: 2.5 }}>
            <span>Produto</span>
          </div>
          <div style={{ flex: 1 }}>
            <span>Quantidade</span>
          </div>
          <div style={{ flex: 0.5 }}>
            <span>Ação</span>
          </div>
        </li>

        {/* Lista de produtos */}
        {produtosEntrada.length > 0 ? (
          produtosEntrada.map((row, index) => (
            <li
              key={index}
              style={{
                marginBottom: "10px",
                borderBottom: "1px solid #ccc",
                display: "flex",
                alignItems: "center",
                justifyContent: "space-between",
              }}
            >
              <div style={{ flex: 2.5 }}>
                <span>{row.nome}</span>
              </div>
              <div style={{ flex: 1, textAlign: "center" }}>
                <span>{row.quantidade}</span>
              </div>
              <div style={{ flex: 0.5 }}>
                <Button
                  style={{ color: "red" }}
                  onClick={() => handleDeleteRow(row.produtoId)}
                >
                  Excluir
                </Button>
              </div>
            </li>
          ))
        ) : (
          <p>Adicione produtos... </p>
        )}
      </ul>
      <br />

      {/* Soma total da quantidade */}
      <div>
        <strong>Soma Total Peso:</strong> {novaEntrada.totalPeso || 0 + " Kg"}
      </div>
      <div>
        <strong>Soma Total Volume:</strong> {novaEntrada.totalVolume || 0}
      </div>
      <div>
        <strong>Soma Total Valor:</strong>{" "}
        {novaEntrada.totalValor || 0 + " reais"}
      </div>
      <br />
    </div>
  );
};

export default Passo1;
