import { Route, Routes } from "react-router-dom";
import Dashboard from "../../pages/Dashboard";
import RegisterForm from "../form/ui/RegisterForm";
import LoginForm from "../form/LoginForm";

function RoutesApp() {
  return (
    <Routes>
      <Route path="/" element={<Dashboard />} />
      <Route path="register" element={<RegisterForm />} />
      <Route path="login" element={<LoginForm />} />
    </Routes>
  );
}

export default RoutesApp;
