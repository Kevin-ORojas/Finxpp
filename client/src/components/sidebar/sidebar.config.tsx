import type { ReactNode } from "react";
import PersonIcon from "@mui/icons-material/Person";
import HomeIcon from "@mui/icons-material/Home";

export type SidebarItem = {
  id: string;
  label: string;
  icon: ReactNode;
  path: string;
};

export const sidebarItems: SidebarItem[] = [
  { id: "home", label: "Inicio", icon: <HomeIcon />, path: "/" },
  { id: "login", label: "login", icon: <PersonIcon />, path: "register" },
];
