import { Box, TextField, Typography } from "@mui/material";
import ButtonForm from "./ui/ButtonForm";

import { useState } from "react";
import { Link } from "react-router-dom";
import { registerUser } from "../api/Auth";
import { RegisterData } from "../interfaces/auth";

function RegisterForm() {
  const [isRegistered, setIsRegistered] = useState(false);
  const [loading, setLoading] = useState(false);
  const [message, setMessage] = useState("");

  const [form, setForm] = useState<RegisterData>({
    nombre: "",
    email: "",
    contrasena: "",
  });

  // manejamos de cambios de los inputs
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setForm((prev) => ({ ...prev, [name]: value }));
  };

  // enviar datos de la API
  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setLoading(true);

    try {
      const result = await registerUser(form);
      console.log("Usuario registrado", result);
      setMessage("✅ Registro exitoso, ahora puedes iniciar sesión.");
      setIsRegistered(true);
    } catch (error) {
      console.error(error);
      setMessage("❌ Hubo un problema con el registro.");
      setLoading(false);
    }
  };

  return (
    <Box
      component="form"
      onSubmit={handleSubmit}
      sx={{
        display: "flex",
        alignItems: "center",
        minHeight: "100vh",
        justifyContent: "center",
      }}
    >
      <Box
        sx={{
          border: "2px solid",
          background: "#fff",
          borderColor: "#031926",
          padding: "3rem",
          borderRadius: 3,
          boxShadow: 3,
          display: "flex",
          width: "100%",
          maxWidth: 400,
          flexDirection: "column",
          gap: 2,
        }}
      >
        <h1>Registrate</h1>
        <TextField
          label="Nombre"
          variant="outlined"
          name="nombre"
          value={form.nombre}
          onChange={handleChange}
        />
        <TextField
          label="Email"
          name="email"
          variant="outlined"
          value={form.email}
          onChange={handleChange}
        />
        <TextField
          label="contrasena"
          name="contrasena"
          type="password"
          variant="outlined"
          value={form.contrasena}
          onChange={handleChange}
        />

        <ButtonForm disabled={loading}>
          {loading ? "Registrando..." : "Registrarse"}
        </ButtonForm>

        {message && (
          <Typography color={isRegistered ? "green" : "red"}>
            {message}
          </Typography>
        )}

        {isRegistered && <Link to="/login">Ir a Login</Link>}
      </Box>
    </Box>
  );
}

export default RegisterForm;
