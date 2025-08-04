import type { ReactNode } from "react";
import PersonIcon from "@mui/icons-material/Person";

export type SidebarItem = {
  id: string;
  label: string;
  icon: ReactNode;
};

export const sidebarItems: SidebarItem[] = [
  { id: "home", label: "Inicio", icon: <PersonIcon /> },
  { id: "home", label: "Inicio", icon: <PersonIcon /> },
];
