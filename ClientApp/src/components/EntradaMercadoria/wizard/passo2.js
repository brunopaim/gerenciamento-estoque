// Component
import { MapaComponent } from "../../MapaEstoque";

import { BotaoCancelar, BotaoProximo, BotaoAnterior } from "./styles";

const Passo2 = ({ onPrevStep, onCancel, onNextStep }) => {
  return (
    <div>
      <br />
      <h2>Passo 2: Mapa do Estoque</h2>
      {MapaComponent()}
      <p>
        Obs*: O armazenamento é passado de forma automática no estoque em
        espaços vazios!
      </p>
    </div>
  );
};

export default Passo2;
