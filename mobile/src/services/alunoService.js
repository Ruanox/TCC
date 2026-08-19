import api from "./api";

export const registerAluno = async (payload) => {
  const res = await api.post("/alunos_create.php", payload);
  return res.data;
};

export default { registerAluno };
