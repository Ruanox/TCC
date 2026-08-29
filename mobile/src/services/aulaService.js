import api from "./api";

export async function getAulas() {
  const response = await api.get(
    "/horarios.php"
  );

  if (Array.isArray(response.data)) {
    return response.data;
  }

  return [];
}

export default {
  getAulas,
};