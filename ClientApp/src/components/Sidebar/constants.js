// Material UI
import HomeIcon from "@mui/icons-material/Home";
import AddIcon from "@mui/icons-material/Add";
import ArquiveIcon from "@mui/icons-material/Archive";
import Inventory2Icon from "@mui/icons-material/Inventory2";

export const sidebarItems = [
  {
    id: "home",
    label: "Home",
    icon: <HomeIcon />,
    url: "/",
  },
  {
    id: "cadastro",
    label: "Cadastro de Produto",
    icon: <AddIcon />,
    url: "/cadastro-produto",
  },
  {
    id: "entrada-mercadoria",
    label: "Entrada de Mercadoria",
    icon: <ArquiveIcon />,
    url: "/entrada-mercadoria",
  },
  {
    id: "mapa-estoque",
    label: "Mapas Estoque",
    icon: <Inventory2Icon />,
    url: "/mapa-estoque",
  },
];
