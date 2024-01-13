// React
import React, { useEffect, useState } from "react";

// Material UI
import {
  Button,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
} from "@mui/material";
import AddCircleOutlineIcon from "@mui/icons-material/AddCircleOutline";

// Zustand
import useGlobalStore from "../../store";

const CadastroProdutos = () => {
  const { produtos, setProdutos, adicionarProduto } = useGlobalStore();

  const [openDialog, setOpenDialog] = useState(false);
  const [novoProduto, setNovoProduto] = useState({
    nome: "",
    peso: 0,
    volumeCubico: 0,
    valorUnitario: 0,
  });

  useEffect(() => {
    fetch("/api/Produto")
      .then((response) => response.json())
      .then((data) => setProdutos(data))
      .catch((error) => console.error("Erro ao obter produtos:", error));
  }, [setProdutos]);

  const handleOpenDialog = () => {
    setOpenDialog(true);
  };

  const handleCloseDialog = () => {
    setOpenDialog(false);
    setNovoProduto({
      nome: "",
      peso: 0,
      volumeCubico: 0,
      valorUnitario: 0,
    });
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setNovoProduto({
      ...novoProduto,
      [name]: value,
    });
  };

  const handleAdicionarProduto = () => {
    fetch("/api/Produto", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(novoProduto),
    })
      .then((response) => response.json())
      .then((data) => {
        // Atualizar a lista de produtos após adicionar um novo
        adicionarProduto(data);
        // Fechar o popup
        handleCloseDialog();
      })
      .catch((error) => console.error("Erro ao adicionar produto:", error));
  };

  return (
    <div>
      <h2>
        Cadastro de Produtos
        <Button
          style={{ marginLeft: "20px" }}
          variant="contained"
          startIcon={<AddCircleOutlineIcon />}
          onClick={handleOpenDialog}
        >
          Novo Produto
        </Button>
      </h2>
      <br />
      <p>Lista de Produtos já cadastrados:</p>
      {produtos.length > 0 ? (
        <ul>
          {produtos?.map((produto) => (
            <li key={produto.produtoId}>
              <strong>Nome:</strong> {produto.nome}
              <br />
              <strong>Peso (UN/Kg):</strong> {produto.peso}
              <br />
              <strong>Volume Cúbico (UN):</strong> {produto.volumeCubico}
              <br />
              <strong>Valor Unitário:</strong> {"R$" + produto.valorUnitario}
              <br />
              <hr />
            </li>
          ))}
        </ul>
      ) : (
        <p>Sem Produtos cadastrados!</p>
      )}
      <Dialog open={openDialog} onClose={handleCloseDialog}>
        <DialogTitle>Novo Produto</DialogTitle>
        <DialogContent>
          <TextField
            label="Nome"
            name="nome"
            value={novoProduto.nome}
            onChange={handleInputChange}
            fullWidth
            margin="normal"
          />
          <TextField
            label="Peso"
            name="peso"
            type="number"
            value={novoProduto.peso}
            onChange={handleInputChange}
            fullWidth
            margin="normal"
          />
          <TextField
            label="Volume Cúbico"
            name="volumeCubico"
            type="number"
            value={novoProduto.volumeCubico}
            onChange={handleInputChange}
            fullWidth
            margin="normal"
          />
          <TextField
            label="Valor Unitário"
            name="valorUnitario"
            type="number"
            value={novoProduto.valorUnitario}
            onChange={handleInputChange}
            fullWidth
            margin="normal"
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseDialog}>Cancelar</Button>
          <Button
            onClick={handleAdicionarProduto}
            variant="contained"
            color="primary"
          >
            Adicionar
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default CadastroProdutos;
