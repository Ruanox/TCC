import api from "./api";

export const getAulas = async () => {
  const response = await api.get("/horarios.php");

  return response.data;
};
