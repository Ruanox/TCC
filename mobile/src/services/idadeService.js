function extrairIdade(dados) {
    if (!dados || typeof dados !== "object") {
        return null;
    }

    const candidatos = [
        dados.idade,
        dados.idadeAluno,
        dados.idade_aluno,
        dados.idade_alunos,
        dados.faixaEtaria,
        dados.faixa_etaria,
        dados.nascimento,
        dados.dataNascimento,
        dados.data_nascimento,
        dados.data_nasc,
        dados.dtNascimento,
        dados.dt_nascimento,
    ];

    for (const candidato of candidatos) {
        if (candidato === null || candidato === undefined || candidato === "") {
            continue;
        }

        if (typeof candidato === "number" && Number.isFinite(candidato)) {
            return candidato;
        }

        if (typeof candidato === "string") {
            const texto = candidato.trim();

            if (/^\d+$/.test(texto)) {
                return Number(texto);
            }

            const data = parseData(texto);
            if (data) {
                return calcularIdade(data);
            }
        }

        if (candidato instanceof Date) {
            return calcularIdade(candidato);
        }
    }

    return null;
}

function parseData(valor) {
    const texto = String(valor).trim();

    if (!texto) {
        return null;
    }

    const timestamp = Date.parse(texto);
    if (!Number.isNaN(timestamp)) {
        return new Date(timestamp);
    }

    const partes = texto.split(/[/-]/);
    if (partes.length !== 3) {
        return null;
    }

    if (/^\d{4}$/.test(partes[2])) {
        return null;
    }

    let dia;
    let mes;
    let ano;

    if (partes[2].length === 4) {
        dia = Number(partes[0]);
        mes = Number(partes[1]);
        ano = Number(partes[2]);
    } else {
        dia = Number(partes[2]);
        mes = Number(partes[1]);
        ano = Number(partes[0]);
    }

    if ([dia, mes, ano].some((valor) => Number.isNaN(valor))) {
        return null;
    }

    const data = new Date(ano, mes - 1, dia);
    if (
        data.getFullYear() !== ano ||
        data.getMonth() !== mes - 1 ||
        data.getDate() !== dia
    ) {
        return null;
    }

    return data;
}

function calcularIdade(dataNascimento) {
    if (!dataNascimento || Number.isNaN(dataNascimento.getTime())) {
        return null;
    }

    const hoje = new Date();
    let idade = hoje.getFullYear() - dataNascimento.getFullYear();
    const mesAtual = hoje.getMonth();
    const mesNascimento = dataNascimento.getMonth();

    if (
        mesAtual < mesNascimento ||
        (mesAtual === mesNascimento && hoje.getDate() < dataNascimento.getDate())
    ) {
        idade -= 1;
    }

    return idade;
}

function determinarFaixaEtaria(idade) {
    if (idade === null || idade === undefined || Number.isNaN(idade)) {
        return "Sem idade informada";
    }

    if (idade < 6) {
        return "Pré-escolar";
    }

    if (idade <= 10) {
        return "Infantil";
    }

    if (idade <= 13) {
        return "Juvenil";
    }

    if (idade <= 17) {
        return "Adolescente";
    }

    return "Adulto";
}

function normalizarAluno(aluno) {
    const idade = extrairIdade(aluno);
    const menorDeIdade = idade !== null && idade < 18;
    const faixaEtaria = menorDeIdade ? determinarFaixaEtaria(idade) : "Adulto";

    return {
        ...aluno,
        idade,
        menorDeIdade,
        faixaEtaria,
        turmaIdade: faixaEtaria,
    };
}

function normalizarRespostaLogin(resposta) {
    if (!resposta || typeof resposta !== "object") {
        return resposta;
    }

    const aluno =
        resposta.tipo === "aluno" ? normalizarAluno(resposta) : resposta;

    return {
        ...resposta,
        ...aluno,
    };
}

function agruparAlunosPorFaixaEtaria(alunos) {
    const mapa = {};

    (Array.isArray(alunos) ? alunos : []).forEach((aluno) => {
        const alunoNormalizado = normalizarAluno(aluno);
        const chave = alunoNormalizado.faixaEtaria || "Sem idade informada";

        if (!mapa[chave]) {
            mapa[chave] = [];
        }

        mapa[chave].push(alunoNormalizado);
    });

    return mapa;
}

module.exports = {
    calcularIdade,
    determinarFaixaEtaria,
    normalizarAluno,
    normalizarRespostaLogin,
    agruparAlunosPorFaixaEtaria,
};
