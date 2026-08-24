import api from "./api";

export async function getHorarios() {
  const response = await api.get(
    "/horarios.php"
  );

  return Array.isArray(response.data)
    ? response.data
    : [];
}

export async function atualizarHorario(dados) {
  const response = await api.post(
    "/horarios.php",
    dados
  );

  return response.data;
}

export default {
  getHorarios,
  atualizarHorario,
};