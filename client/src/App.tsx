
import RegisterForm from "./components/form/ui/RegisterForm";

import Dashboard from "./pages/Dashboard";
import Layout from "./components/layout/Layout";

function App() {
  return (
    <Layout >
      <Dashboard />
      <RegisterForm />
    </Layout>
  );
}

export default App;
