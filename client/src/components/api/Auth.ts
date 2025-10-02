import type { AuthResponse, LoginData, RegisterData } from "../interfaces/auth";

const API_URL = "http://localhost:5256/api/Auth/register";

export const registerUser = async (
  data: RegisterData
): Promise<AuthResponse> => {
  const res = await fetch(`${API_URL}/register`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });

  if (!res.ok) throw new Error("error en el registro");
  return res.json();
};

export const LoginUser = async (data: LoginData) => {
  const res = await fetch(`${API_URL}/login`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });

  if (!res.ok) throw new Error("Error en el login");
  return res.json();
};
