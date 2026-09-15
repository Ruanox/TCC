import api from "./api";

export async function getHorarios(idProfessor = 0) {
  try {
    const id = Number(idProfessor);

    const url =
      id > 0
        ? `/horarios.php?id_professor=${id}`
        : "/horarios.php";

    const response = await api.get(url);

    if (Array.isArray(response.data)) {
      return response.data;
    }

    return [];
  } catch (error) {
    console.log(
      "Erro ao buscar horários:",
      error.response?.data || error.message
    );

    throw error;
  }
}

export async function getAulas(
  idAluno = 0,
  idProfessor = 0
) {
  try {
    const aluno = Number(idAluno);
    const professor = Number(idProfessor);

    let url = "/horarios.php";

    if (aluno > 0) {
      url += `?id_aluno=${aluno}`;
    } else if (professor > 0) {
      url += `?id_professor=${professor}`;
    }

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

export async function atualizarHorario({
  id_horario,
  id_professor,
  id_dia,
  hora_inicio,
  hora_fim,
  acao = "",
}) {
  try {
    const payload = {
      id_horario: Number(id_horario),
      id_professor: Number(id_professor),
      id_dia: Number(id_dia),
      hora_inicio: String(hora_inicio),
      hora_fim: String(hora_fim),
      acao: String(acao),
    };

    if (payload.id_horario <= 0) {
      throw new Error("ID do horário inválido.");
    }

    if (payload.id_professor <= 0) {
      throw new Error("ID do professor inválido.");
    }

    if (payload.id_dia <= 0) {
      throw new Error("Dia inválido.");
    }

    if (!payload.hora_inicio || !payload.hora_fim) {
      throw new Error("Horário inválido.");
    }

    const response = await api.post(
      "/horarios.php",
      payload
    );

    return response.data;
  } catch (error) {
    console.log(
      "Erro ao atualizar horário:",
      error.response?.data || error.message
    );

    throw error;
  }
}

export default {
  getHorarios,
  getAulas,
  atualizarHorario,
};