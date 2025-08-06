import { Route, Routes } from "react-router-dom";
import Dashboard from "../../pages/Dashboard";
import RegisterForm from "../form/ui/RegisterForm";
import LoginForm from "../form/LoginForm";
import Transaccion from "../transaccion/Transaccion";

function RoutesApp() {
  return (
    <Routes>
      <Route path="/" element={<Dashboard />} />
      <Route path="register" element={<RegisterForm />} />
      <Route path="login" element={<LoginForm />} />
      <Route path="transaccion" element={<Transaccion />} />
    </Routes>
  );
}

export default RoutesApp;
