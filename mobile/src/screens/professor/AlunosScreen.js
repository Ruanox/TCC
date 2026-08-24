import React, {
  useEffect,
  useState,
} from "react";

import {
  View,
  Text,
  FlatList,
  StyleSheet,
  ActivityIndicator,
} from "react-native";

import {
  getAlunos,
} from "../../services/alunoService";

import {
  agruparAlunosPorFaixaEtaria,
  normalizarAluno,
} from "../../services/idadeService";

export default function AlunosScreen() {
  const [alunos, setAlunos] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    carregarAlunos();
  }, []);

  async function carregarAlunos() {
    try {
      const dados = await getAlunos();

      const lista = Array.isArray(dados)
        ? dados.map(normalizarAluno)
        : [];

      setAlunos(lista);
    } catch (error) {
      console.log(
        "Erro ao carregar alunos:",
        error.response?.data ||
          error.message
      );

      setAlunos([]);
    } finally {
      setLoading(false);
    }
  }

  if (loading) {
    return (
      <View style={styles.center}>
        <ActivityIndicator
          size="large"
          color="#6C2BD9"
        />
      </View>
    );
  }

  const grupos =
    agruparAlunosPorFaixaEtaria(alunos);

  const chaves = Object.keys(grupos);

  return (
    <View style={styles.container}>
      {chaves.length === 0 ? (
        <Text style={styles.vazio}>
          Nenhum aluno encontrado.
        </Text>
      ) : (
        <FlatList
          data={chaves}
          keyExtractor={(item) => item}
          renderItem={({ item: chave }) => (
            <View style={styles.grupoContainer}>
              <Text style={styles.grupoTitulo}>
                {chave}
              </Text>

              {grupos[chave].map(
                (aluno, index) => (
                  <View
                    key={`${aluno.id_aluno}-${index}`}
                    style={styles.card}
                  >
                    <Text style={styles.nome}>
                      {aluno.nome ||
                        "Aluno sem nome"}
                    </Text>

                    <Text style={styles.info}>
                      Idade:{" "}
                      {aluno.idade ??
                        "Não informada"}
                    </Text>

                    <Text style={styles.info}>
                      CPF:{" "}
                      {aluno.cpf ||
                        "Não informado"}
                    </Text>

                    <Text style={styles.info}>
                      Turma:{" "}
                      {aluno.turmaIdade}
                    </Text>
                  </View>
                )
              )}
            </View>
          )}
        />
      )}
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 15,
    backgroundColor: "#F5F5F5",
  },

  center: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
  },

  card: {
    backgroundColor: "#fff",
    padding: 15,
    marginBottom: 10,
    borderRadius: 10,
    elevation: 3,
  },

  nome: {
    fontSize: 18,
    fontWeight: "bold",
  },

  vazio: {
    textAlign: "center",
    marginTop: 20,
    fontSize: 16,
  },

  grupoContainer: {
    marginBottom: 20,
  },

  grupoTitulo: {
    fontSize: 18,
    fontWeight: "bold",
    color: "#6C2BD9",
    marginBottom: 8,
  },

  info: {
    color: "#666",
    marginTop: 4,
  },
});