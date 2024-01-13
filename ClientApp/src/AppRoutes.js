import { Home } from "./components/Home";
import CadastroProduto from "./components/CadastroProduto";
import EntradaMercadoria from "./components/EntradaMercadoria";
import MapaEstoque from "./components/MapaEstoque";

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: "/cadastro-produto",
    element: <CadastroProduto />,
  },
  {
    path: "/entrada-mercadoria",
    element: <EntradaMercadoria />,
  },
  {
    path: "/mapa-estoque",
    element: <MapaEstoque />,
  },
];

export default AppRoutes;
