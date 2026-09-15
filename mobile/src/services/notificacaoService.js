import api from "./api";

export async function getNotificacoes(
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
        ? `/notificacoes.php?${params.join("&")}`
        : "/notificacoes.php";

    const response = await api.get(url);

    if (Array.isArray(response.data)) {
      return response.data;
    }

    return [];
  } catch (error) {
    console.log(
      "Erro ao buscar notificações:",
      error.response?.data || error.message
    );

    throw error;
  }
}

export async function marcarComoLida(
  idNotificacao
) {
  try {
    const id = Number(idNotificacao);

    if (id <= 0) {
      throw new Error(
        "ID da notificação inválido."
      );
    }

    const response = await api.post(
      "/notificacoes.php",
      {
        id_notificacao: id,
        lida: 1,
      }
    );

    return response.data;
  } catch (error) {
    console.log(
      "Erro ao marcar notificação:",
      error.response?.data || error.message
    );

    throw error;
  }
}

export default {
  getNotificacoes,
  marcarComoLida,
};