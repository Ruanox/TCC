import api from "./api";

export async function registerAluno(payload) {
  try {
    const response = await api.post(
      "/alunos_create.php",
      payload
    );

    return response.data;
  } catch (error) {
    console.log(
      "Erro ao cadastrar aluno:",
      error.response?.data ||
        error.message
    );

    throw error;
  }
}

export async function getAlunos(idProfessor = 0) {
  try {
    const id = Number(idProfessor);

    const url =
      id > 0
        ? `/alunos.php?id_professor=${id}`
        : "/alunos.php";

    const response = await api.get(url);

    return Array.isArray(response.data)
      ? response.data
      : [];
  } catch (error) {
    console.log(
      "Erro ao buscar alunos:",
      error.response?.data ||
        error.message
    );

    throw error;
  }
}

export default {
  registerAluno,
  getAlunos,
};