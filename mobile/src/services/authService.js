import api from "./api";

export async function login(cpf, senha) {
  const response = await api.post(
    "/login.php",
    {
      cpf,
      senha,
    }
  );

  return response.data;
}

export default {
  login,
};