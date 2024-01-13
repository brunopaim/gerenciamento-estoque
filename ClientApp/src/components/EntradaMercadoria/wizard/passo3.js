// React
import React, { useEffect, useState } from "react";

// Material UI
import { TextField } from "@mui/material";

// Component
import { BotaoCancelar, BotaoProximo, BotaoAnterior } from "./styles";

// Zustand
import useGlobalStore from "../../../store";

const Passo3 = ({ onPrevStep, onCancel, onFinish }) => {
  const { nomeUsuario, setNomeUsuario } = useGlobalStore();

  return (
    <div>
      <br />
      <h2>Passo 3: Tela de Assinatura</h2>
      <p>Digite o seu nome e confime a entrada de mercadoria.</p>
      <TextField
        label="Nome"
        name="nome"
        value={nomeUsuario}
        onChange={(e) => {
          setNomeUsuario(e.target.value);
        }}
        fullWidth
        margin="normal"
      />
      <br />
      <br />
    </div>
  );
};

export default Passo3;
