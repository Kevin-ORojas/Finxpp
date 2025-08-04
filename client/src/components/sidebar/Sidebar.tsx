import {
  Drawer,
  List,
  ListItem,
  ListItemText,
  Toolbar,
  useMediaQuery,
  // useTheme,
} from "@mui/material";
import { sidebarItems } from "./sidebar.config";
import { useState, useEffect } from "react";

function Sidebar() {
  // const theme = useTheme();
  const isMobile = useMediaQuery("(max-width:930px)");

  const [open, setOpen] = useState(true);

  // Detectar automáticamente si estamos en móvil y cerrar el sidebar
  useEffect(() => {
    setOpen(!isMobile);
  }, [isMobile]);

  const drawerWidth = 240;
  const miniWidth = 60;

  return (
    <Drawer
      variant="permanent"
      sx={{
        width: open ? drawerWidth : miniWidth,
        flexShrink: 0,
        "& .MuiDrawer-paper": {
          width: open ? drawerWidth : miniWidth,
          boxSizing: "border-box",
          transition: "width 0.3s",
          overflowX: "hidden",
        },
      }}
    >
      <Toolbar sx={{ justifyContent: open ? "flex-end" : "center" }} />

      <List>
        {sidebarItems.map((item) => (
          <ListItem key={item.id} component="button">
            {open && <ListItemText primary={item.label} />}
          </ListItem>
        ))}
      </List>
    </Drawer>
  );
}

export default Sidebar;
