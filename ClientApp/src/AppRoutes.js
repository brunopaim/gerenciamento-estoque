import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import CadastroProduto from "./components/CadastroProduto";
import { EntradaMercadoria } from "./components/EntradaMercadoria";

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: "/counter",
    element: <Counter />,
  },
  {
    path: "/fetch-data",
    element: <FetchData />,
  },
  {
    path: "/cadastro-produto",
    element: <CadastroProduto />,
  },
  {
    path: "/entrada-mercadoria",
    element: <EntradaMercadoria />,
  },
];

export default AppRoutes;
