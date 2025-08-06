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
          // backgroundColor: "#1e1e2f",
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
              color: "#000",
            }}
          >
            <ListItemIcon
              sx={{
                display: "flex",
                alignItems: "center",
                justifyContent: "center",
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
