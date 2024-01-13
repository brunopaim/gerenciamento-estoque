import React from "react";
import Button from "@mui/material/Button";
import PropTypes from "prop-types";

// Botão Próximo
export const BotaoProximo = ({ onClick, disabled, text }) => (
  <Button
    disabled={disabled}
    onClick={onClick}
    style={{ marginLeft: "10px" }}
    variant="contained"
  >
    {text ? text : "Próximo"}
  </Button>
);

BotaoProximo.propTypes = {
  onClick: PropTypes.func.isRequired,
  disabled: PropTypes.bool,
};

// Botão Cancelar
export const BotaoCancelar = ({ onClick }) => (
  <Button
    style={{
      color: "red",
      backgroundColor: "white",
      borderColor: "red",
    }}
    variant="outlined"
    onClick={onClick}
  >
    Cancelar
  </Button>
);

BotaoCancelar.propTypes = {
  onClick: PropTypes.func.isRequired,
};

// Botão Anterior
export const BotaoAnterior = ({ onClick }) => (
  <Button
    style={{
      marginLeft: "10px",
    }}
    variant="outlined"
    onClick={onClick}
  >
    Anterior
  </Button>
);

BotaoAnterior.propTypes = {
  onClick: PropTypes.func.isRequired,
};
