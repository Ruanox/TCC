import api from "./api";

export async function getAulas(
  idAluno = 0,
  idProfessor = 0
) {
  try {
    const aluno = Number(idAluno);
    const professor = Number(idProfessor);

    const params = [];

    if (aluno > 0) {
      params.push(`id_aluno=${aluno}`);
    }

    if (professor > 0) {
      params.push(`id_professor=${professor}`);
    }

    const url =
      params.length > 0
        ? `/horarios.php?${params.join("&")}`
        : "/horarios.php";

    const response = await api.get(url);

    if (Array.isArray(response.data)) {
      return response.data;
    }

    return [];
  } catch (error) {
    console.log(
      "Erro ao buscar aulas:",
      error.response?.data || error.message
    );

    throw error;
  }
}

export default {
  getAulas,
};