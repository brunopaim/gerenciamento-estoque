// Material UI
import HomeIcon from "@mui/icons-material/Home";
import AddIcon from "@mui/icons-material/Add";
import ShoppingCartIcon from "@mui/icons-material/Archive";

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
    icon: <ShoppingCartIcon />,
    url: "/entrada-mercadoria",
  },
];
