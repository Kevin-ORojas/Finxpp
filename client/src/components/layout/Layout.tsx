import { Box, useMediaQuery } from "@mui/material";
import Sidebar from "../sidebar/Sidebar";
import { useEffect, useState, type ReactNode } from "react";

interface LayoutProps {
  children: ReactNode;
}

const drawerWidth = 230;
const drawerHeigth = 60;

function Layout({ children }: LayoutProps) {
  const isMobile = useMediaQuery("(max-width:930px)");
  const [open, setOpen] = useState<boolean>(true);

  useEffect(() => {
    setOpen(!isMobile);
  }),
    [isMobile];

  const sidebarWith = open ? drawerWidth : drawerHeigth;

  return (
    <Box sx={{ display: "flex" }}>
      <Sidebar open={open} />
      <Box
        component="main"
        sx={{
          flexGrow: 1,
          p: 3,
          ml: `${sidebarWith}`,
          transition: "margin-left 0.3s",
        }}
      >
        {children}
      </Box>
    </Box>
  );
}

export default Layout;
