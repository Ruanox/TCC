import api from "./api";

export const login = async (cpf, senha) => {
  const res = await api.post("/login.php", { cpf, senha });
  return res.data;
};