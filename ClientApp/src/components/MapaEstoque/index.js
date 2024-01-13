// React
import React, { useEffect, useState } from "react";

// Material UI
import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";

// Zustand
import useGlobalStore from "../../store";

const MapaEstoque = () => {
  return (
    <div>
      <h2>Mapa do Estoque</h2>
      {MapaComponent()}
    </div>
  );
};

const CustomDialog = ({ open, onClose, selectedCell }) => {
  return (
    <Dialog open={open} onClose={onClose}>
      <DialogTitle>
        Produtos na Célula - {selectedCell.coluna} x {selectedCell.linha}
      </DialogTitle>
      <DialogContent>
        <DialogContentText>
          <ul>
            {selectedCell.produtoEntrada.map((produto) => (
              <li key={produto.produtoEntradaId}>
                Código: {produto.produtoId}
                <br /> Nome: {produto.produto?.nome}
                <br />
                Quantidade: {produto.quantidade}
                <br />
                Nº Entrada: #{produto.numeroEntrada}
              </li>
            ))}
          </ul>
          <div style={{ marginTop: "10px" }}>
            <strong>Volume utilizado: {selectedCell.volumeUtilizado}</strong>
            <br />
            <strong>Volume livre: {selectedCell.volumeLivre}</strong>
          </div>
        </DialogContentText>
      </DialogContent>
      <DialogActions>
        <Button onClick={onClose} variant="contained">
          Fechar
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export const MapaComponent = () => {
  const { mapaEstoque, setMapaEstoque } = useGlobalStore();

  const [volumeTotalUtilizado, setVolumeTotalUtilizado] = useState(null);
  const [volumeTotalLivre, setVolumeTotalLivre] = useState(null);
  const [selectedCell, setSelectedCell] = useState(null);

  useEffect(() => {
    fetch("/api/MapaEstoque")
      .then((response) => response.json())
      .then((data) => {
        const newMapa = data.map((cell) => {
          const volumeUtilizado = cell.produtoEntrada.reduce(
            (total, produto) => total + produto.volumeCubico,
            0
          );
          const volumeLivre = cell.capacidadeMaxima - volumeUtilizado;

          return { ...cell, volumeLivre, volumeUtilizado };
        });

        const volumeUtilizado = newMapa.reduce((total, cell) => {
          return (
            total +
            cell.produtoEntrada.reduce(
              (subtotal, produto) => subtotal + produto.volumeCubico,
              0
            )
          );
        }, 0);

        setVolumeTotalUtilizado(volumeUtilizado);

        const volumeLivre = newMapa.reduce((total, cell) => {
          return (
            total +
            (cell.capacidadeMaxima -
              cell.produtoEntrada.reduce(
                (subtotal, produto) => subtotal + produto.volumeCubico,
                0
              ))
          );
        }, 0);

        setVolumeTotalLivre(volumeLivre);

        setMapaEstoque(newMapa);
      })
      .catch((error) => console.error("Erro ao obter estoque:", error));
  }, []);

  const handleClick = (linha, coluna) => {
    const cell = mapaEstoque.find(
      (cell) => cell.linha === linha && cell.coluna === coluna
    );
    if (cell && cell.produtoEntrada.length > 0) {
      setSelectedCell(cell);
    }
  };

  const handleCloseDialog = () => {
    setSelectedCell(null);
  };

  const renderCell = (capacidadeMaxima, produtoEntrada, linha, coluna) => {
    let colorCell = "green";
    let cursor = "default";

    if (produtoEntrada.length > 0) {
      let totalOcupado = 0;
      produtoEntrada.map((data) => {
        totalOcupado += data.volumeCubico;
      });
      cursor = "pointer";
      colorCell = totalOcupado < capacidadeMaxima ? "yellow" : "red";
    }

    return (
      <div
        key={`${linha}-${coluna}`}
        style={{
          border: "1px solid #000",
          width: "50px",
          height: "50px",
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
          backgroundColor: colorCell,
          cursor,
        }}
        onClick={() => handleClick(linha, coluna)}
      >
        {produtoEntrada.length > 0 && "X"}
      </div>
    );
  };

  const renderRow = (row) => {
    return (
      <div key={row} style={{ display: "flex" }}>
        {mapaEstoque
          .filter((cell) => cell.linha === row)
          .map(({ coluna, capacidadeMaxima, produtoEntrada }) =>
            renderCell(capacidadeMaxima, produtoEntrada, row, coluna)
          )}
      </div>
    );
  };

  const renderMatrix = () => {
    const rows = Array.from({ length: 5 }, (_, index) => index + 1);
    return rows.map((row) => renderRow(row));
  };

  //const { volumeUtilizado, volumeLivre } = calculaVolumeTotal();

  return (
    <div>
      <p align="justify">
        O estoque padrão é composto por uma matriz 5x5 e cada célula armazena um
        volume máximo de até 100.
      </p>
      <p>Verde = Vazio | Amarelo = Ocupada | Vermelho = Cheio</p>
      <div>{renderMatrix()}</div>
      <div style={{ marginTop: "20px" }}>
        <strong>Soma Total de volume no Estoque</strong>
        <p>Volume utilizado: {volumeTotalUtilizado}</p>
        <p>Volume livre: {volumeTotalLivre}</p>
      </div>
      {selectedCell && (
        <CustomDialog
          open={!!selectedCell}
          onClose={handleCloseDialog}
          selectedCell={selectedCell}
        />
      )}
    </div>
  );
};

export default MapaEstoque;
