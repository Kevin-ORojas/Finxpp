import { Margin } from "@mui/icons-material";
import RegisterForm from "./components/form/ui/RegisterForm";
import Sidebar from "./components/sidebar/Sidebar";
import { Box } from "@mui/material";

function App() {
  return (
    <Box sx={{ marginLeft: "60px" }}>
      <Sidebar />
      <RegisterForm />
    </Box>
  );
}

export default App;
