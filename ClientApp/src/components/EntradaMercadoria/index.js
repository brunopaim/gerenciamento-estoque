// React
import React, { useEffect, useState } from "react";

/// Material UI
import {
  Button,
  Dialog,
  DialogTitle,
  DialogContent,
  Stepper,
  Step,
  StepLabel,
  DialogActions,
} from "@mui/material";
import ArchiveOutlinedIcon from "@mui/icons-material/ArchiveOutlined";

// Components
import Passo1 from "./wizard/passo1";
import Passo2 from "./wizard/passo2";
import Passo3 from "./wizard/passo3";
import { BotaoAnterior, BotaoCancelar, BotaoProximo } from "./wizard/styles";

// Zustand
import useGlobalStore from "../../store";

const EntradaMercadoria = () => {
  const {
    produtos,
    setProdutos,
    adicionarProduto,
    novaEntrada,
    setNovaEntrada,
    entradas,
    setEntradas,
    produtosEntrada,
    setProdutosEntrada,
    nomeUsuario,
    setNomeUsuario,
    mapaEstoque,
    setMapaEstoque,
  } = useGlobalStore();
  const [openWizard, setOpenWizard] = useState(false);
  const [passo, setPasso] = useState(0);

  const fetchEntradas = () => {
    fetch("/api/EntradaMercadoria")
      .then((response) => response.json())
      .then((data) => setEntradas(data))
      .catch((error) => console.error("Erro ao obter entradas:", error));
  };

  useEffect(() => {
    fetchEntradas();
  }, [setEntradas]);

  const getMapaEstoqueId = (vol, qtd) => {
    let volT = vol * qtd;
    let id = 0;
    const newMapa = mapaEstoque.map((cell) => {
      if (
        cell.volumeLivre &&
        cell.volumeLivre > 0 &&
        cell.volumeLivre >= volT
      ) {
        id = cell.mapaEstoqueId;
        const volumeUtilizado = cell.volumeutilizado + volT;
        const volumeLivre = cell.capacidadeMaxima - volumeUtilizado;
        const newCell = { ...cell, volumeLivre, volumeUtilizado };
        return newCell;
      }
      return cell;
    });
    setMapaEstoque(newMapa);

    return id;
  };

  const handleOpenWizard = () => {
    setNovaEntrada({
      numeroEntrada: entradas.length + 1,
      pesoTotal: 0,
      volumeTotal: 0,
      valorTotal: 0,
      produtos: [],
    });
    setOpenWizard(true);
  };

  const handleCloseWizard = () => {
    setPasso(0);
    setProdutosEntrada([]);
    setNomeUsuario("");
    setOpenWizard(false);
  };

  const handleNextStep = () => {
    const novoPasso = passo + 1;
    setPasso(novoPasso);
  };

  const handlePrevStep = () => {
    const novoPasso = passo - 1;
    setPasso(novoPasso);
  };

  const handleSend = () => {
    const newDataProdutos = produtosEntrada.map((data) => {
      return {
        produtoEntradaId: 0,
        numeroEntrada: String(novaEntrada.numeroEntrada),
        produtoId: data.produtoId,
        entradaMercadoriaId: 0,
        mapaEstoqueId: getMapaEstoqueId(data.volumeCubico, data.quantidade),
        quantidade: data.quantidade,
        volumeCubico: data.volumeCubico * data.quantidade,
        peso: data.peso,
        valorUnitario: data.valorUnitario,
      };
    });
    const newData = {
      entradaMercadoriaId: 0,
      numeroEntrada: String(novaEntrada.numeroEntrada),
      nomeUsuario: nomeUsuario,
      totalVolumeCubico: novaEntrada.totalVolume,
      pesoTotal: novaEntrada.totalPeso,
      valorTotal: novaEntrada.totalValor,
      produtosEntrada: newDataProdutos,
    };

    fetch("/api/EntradaMercadoria", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newData),
    })
      .then((response) => response.json())
      .then((data) => {
        fetchEntradas();
        handleCloseWizard();
      })
      .catch((error) =>
        console.error("Erro ao adicionar entrada de mercadoria:", error)
      );
  };

  const getStepContent = (step) => {
    switch (step) {
      case 0:
        return (
          <Passo1 onCancel={handleCloseWizard} onNextStep={handleNextStep} />
        );
      case 1:
        return (
          <Passo2
            onCancel={handleCloseWizard}
            onPrevStep={handlePrevStep}
            onNextStep={handleNextStep}
          />
        );
      case 2:
        return (
          <Passo3
            onPrevStep={handlePrevStep}
            onCancel={handleCloseWizard}
            onFinish={handleSend}
          />
        );
      default:
        return null;
    }
  };

  const StepComponent = ({ activeStep, steps }) => {
    return (
      <Stepper activeStep={activeStep} alternativeLabel>
        {steps.map((label) => (
          <Step key={label}>
            <StepLabel>{label}</StepLabel>
          </Step>
        ))}
      </Stepper>
    );
  };

  return (
    <div>
      <h2>
        Entrada de Mercadoria
        <Button
          style={{ marginLeft: "20px" }}
          variant="contained"
          startIcon={<ArchiveOutlinedIcon />}
          onClick={handleOpenWizard}
        >
          Nova Entrada
        </Button>
      </h2>
      <br />
      <p>Lista de Entradas de Mercadorias já cadastradas:</p>

      {entradas.length > 0 ? (
        <ul>
          {entradas?.map((entrada) => (
            <li key={entrada.entradaMercadoriaId}>
              <strong>Número da Entrada:</strong> #{entrada.numeroEntrada}
              <br />
              <strong>Usuário:</strong> {entrada.nomeUsuario}
              <br />
              <strong>Volume Total:</strong> {entrada.totalVolumeCubico}
              <br />
              <strong>Quantidade de Produtos:</strong>{" "}
              {entrada.produtosEntrada?.length}
              <br />
              <hr />
            </li>
          ))}
        </ul>
      ) : (
        <p>Sem Entradas cadastradas!</p>
      )}

      <Dialog open={openWizard} onClose={handleCloseWizard}>
        <DialogTitle align="center">
          <>
            {`Nova Entrada - Número #${novaEntrada.numeroEntrada}`}
            <StepComponent
              activeStep={passo}
              steps={["Passo 1", "Passo 2", "Passo 3"]} //ToDo: alterar título dos passos
            />
          </>
        </DialogTitle>
        <DialogContent style={{ width: "600px" }}>
          <div>{getStepContent(passo)}</div>
        </DialogContent>
        <DialogActions>
          <BotaoCancelar onClick={handleCloseWizard} />
          {passo === 0 ? (
            <>
              <BotaoProximo
                disabled={produtosEntrada.length < 1} // Valida se tem produto adicionado
                onClick={handleNextStep}
              />
            </>
          ) : passo == 1 ? (
            <>
              <BotaoAnterior onClick={handlePrevStep} />
              <BotaoProximo disabled={false} onClick={handleNextStep} />
            </>
          ) : passo === 2 ? (
            <>
              <BotaoAnterior onClick={handlePrevStep} />
              <BotaoProximo
                disabled={nomeUsuario === ""}
                onClick={handleSend}
                text={"Confirmar"}
              />
            </>
          ) : (
            <></>
          )}
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default EntradaMercadoria;
