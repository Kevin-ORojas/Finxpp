import { Route, Routes } from "react-router-dom";
import Dashboard from "../../pages/Dashboard";
import RegisterForm from "../form/ui/RegisterForm";

function RoutesApp() {
  return (
    <Routes>
      <Route path="/" element={<Dashboard />} />
      <Route path="register" element={<RegisterForm />} />
    </Routes>
  );
}

export default RoutesApp;
