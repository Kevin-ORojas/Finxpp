export interface RegisterData {
  nombre: string;
  email: string;
  contrasena: string;
}

export interface LoginData {
  email: string;
  contrasena: string;
}

export interface AuthResponse {
  usuario: {
    id: number;
    nombre: string;
    email: string;
  };
}
