export function calcularIdade(dataNascimento) {
  if (!dataNascimento) {
    return null;
  }

  const hoje = new Date();
  const nascimento = new Date(dataNascimento);

  if (isNaN(nascimento.getTime())) {
    return null;
  }

  let idade =
    hoje.getFullYear() -
    nascimento.getFullYear();

  const mes =
    hoje.getMonth() -
    nascimento.getMonth();

  if (
    mes < 0 ||
    (mes === 0 &&
      hoje.getDate() < nascimento.getDate())
  ) {
    idade--;
  }

  return idade;
}

export function classificarIdade(idade) {
  const valor = Number(idade);

  if (isNaN(valor)) {
    return "";
  }

  if (valor < 6) {
    return "Pré-escolar";
  }

  if (valor <= 10) {
    return "Infantil";
  }

  if (valor <= 13) {
    return "Juvenil";
  }

  if (valor <= 17) {
    return "Adolescente";
  }

  return "Adulto";
}

export function normalizarAluno(aluno) {
  if (!aluno || typeof aluno !== "object") {
    return null;
  }

  let idade = aluno.idade;

  if (
    idade === undefined ||
    idade === null ||
    idade === ""
  ) {
    idade = calcularIdade(aluno.data_nasc);
  }

  return {
    ...aluno,
    idade:
      idade !== null &&
      idade !== undefined &&
      idade !== ""
        ? Number(idade)
        : null,
    turmaIdade:
      aluno.turma_idade ||
      aluno.turmaIdade ||
      classificarIdade(idade),
  };
}

export function agruparAlunosPorFaixaEtaria(alunos) {
  if (!Array.isArray(alunos)) {
    return {};
  }

  return alunos.reduce((grupos, aluno) => {
    if (!aluno) {
      return grupos;
    }

    const idade = aluno.idade;

    const faixa =
      aluno.turmaIdade ||
      classificarIdade(idade);

    if (!faixa) {
      return grupos;
    }

    if (!grupos[faixa]) {
      grupos[faixa] = [];
    }

    grupos[faixa].push(aluno);

    return grupos;
  }, {});
}

export default {
  calcularIdade,
  classificarIdade,
  normalizarAluno,
  agruparAlunosPorFaixaEtaria,
};