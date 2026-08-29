import api from "./api";

export async function registerAluno(payload) {
  const response = await api.post(
    "/alunos_create.php",
    payload
  );

  return response.data;
}

export async function getAlunos() {
  const response = await api.get(
    "/alunos.php"
  );

  return Array.isArray(response.data)
    ? response.data
    : [];
}

export default {
  registerAluno,
  getAlunos,
};