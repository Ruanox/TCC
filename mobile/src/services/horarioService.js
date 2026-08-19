import api from "./api";

export const getHorarios = async () => {
  const res = await api.get("/horarios.php");
  return res.data;
};

export const atualizarHorario = async (dados) => {
  const res = await api.post(
    "/atualizar_horarios.php",
    dados
  );

  return res.data;
};