import { Box, Button, TextField } from "@mui/material";
import ButtonForm from "./ui/ButtonForm";

import { useState } from "react";
import { Link } from "react-router-dom";

function LoginForm() {
  const [form, setForm] = useState({
    name: "",
    email: "",
    password: "",
  });
  const [isRegistered, setIsRegistered] = useState(false);

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log("Login con:", form);

    setIsRegistered(true);
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setForm((prev) => ({ ...prev, [name]: value }));
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
          padding: "3rem",
          borderRadius: 5,
          boxShadow: 3,
          display: "flex",
          width: "100%",
          maxWidth: 400,
          flexDirection: "column",
          gap: 2,
        }}
      >
        <TextField
          label="Email"
          variant="outlined"
          name="email"
          value={form.email}
          onChange={handleChange}
        />
        <TextField
          label="Password"
          name="password"
          variant="outlined"
          value={form.password}
          onChange={handleChange}
        />
        <ButtonForm />
        <Box
          sx={{
            display: "flex",
            alignItems: "center",
            justifyContent: "space-between",
          }}
        >
          {isRegistered && (
            <Button component={Link} to="/register">
              ¿Estás registrado?
            </Button>
          )}
        </Box>
      </Box>
    </Box>
  );
}

export default LoginForm;
