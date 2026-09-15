import api from "./api";

export async function login(cpf, senha) {
  try {
    const cpfLimpo = String(cpf).replace(/\D/g, "");

    if (cpfLimpo.length !== 11) {
      throw new Error("CPF inválido.");
    }

    if (!String(senha).trim()) {
      throw new Error("Senha obrigatória.");
    }

    const response = await api.post("/login.php", {
      cpf: cpfLimpo,
      senha: String(senha),
    });

    return response.data;
  } catch (error) {
    console.log(
      "Erro no login:",
      error.response?.data || error.message
    );

    throw error;
  }
}

export default {
  login,
};