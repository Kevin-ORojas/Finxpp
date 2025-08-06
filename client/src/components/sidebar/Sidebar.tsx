import {
  Drawer,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  Toolbar,

  // useTheme,
} from "@mui/material";
import { sidebarItems } from "./sidebar.config";
import { Link } from "react-router-dom";

interface SidebarProps {
  open: boolean;
}

function Sidebar({ open }: SidebarProps) {
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
          backgroundColor: "#031926",
        },
      }}
    >
      <Toolbar sx={{ justifyContent: open ? "flex-end" : "center" }} />

      <List sx={{ p: 0.5 }}>
        {sidebarItems.map((item) => (
          <ListItem
            key={item.id}
            component={Link}
            to={item.path}
            sx={{
              my: 2,
              display: "flex",
              alignItems: "center",
              justifyContent: "center",
              borderRadius: open ? 2 : 10,
              color: "#FFFFFF",
              "&:hover": {
                backgroundColor: "#36A5A9",
                transition: "background-color 0.3s ease",
              },
            }}
          >
            <ListItemIcon
              sx={{
                display: "flex",
                alignItems: "center",
                justifyContent: "center",
                color: "#ffffff",
              }}
            >
              {item.icon}
            </ListItemIcon>
            {open && <ListItemText primary={item.label} />}
          </ListItem>
        ))}
      </List>
    </Drawer>
  );
}

export default Sidebar;
