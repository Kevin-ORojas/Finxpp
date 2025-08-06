import type { ReactNode } from "react";
import PersonIcon from "@mui/icons-material/Person";
import HomeIcon from "@mui/icons-material/Home";
import MoneyOffIcon from "@mui/icons-material/MoneyOff";

import AccountBalanceIcon from "@mui/icons-material/AccountBalance";

export type SidebarItem = {
  id: string;
  label: string;
  icon: ReactNode;
  path: string;
};

export const sidebarItems: SidebarItem[] = [
  { id: "home", label: "Inicio", icon: <HomeIcon />, path: "/" },
  { id: "login", label: "login", icon: <PersonIcon />, path: "login" },
  {
    id: "Transaccion",
    label: "Transaccion",
    icon: <PersonIcon />,
    path: "transaccion",
  },
  {
    id: "Prestamos",
    label: "Prestamos",
    icon: <MoneyOffIcon />,
    path: "prestamos",
  },
  {
    id: "Historial",
    label: "Historial",
    icon: <AccountBalanceIcon />,
    path: "historial",
  },
];
