import React, { useEffect, useState } from "react";
import {
  View,
  Text,
  FlatList,
  StyleSheet,
  ActivityIndicator,
} from "react-native";
import { agruparAlunosPorFaixaEtaria, normalizarAluno } from "../../services/idadeService";

export default function AlunosScreen() {
  const [alunos, setAlunos] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    carregarAlunos();
  }, []);

  const carregarAlunos = async () => {
    try {
      const response = await fetch(
        "http://localhost/tcc_mobile/alunos.php"
      );

      const dados = await response.json();
      const alunosNormalizados = (Array.isArray(dados) ? dados : []).map(normalizarAluno);

      console.log("Dados recebidos:", dados);
      console.log("Alunos normalizados:", alunosNormalizados);

      setAlunos(alunosNormalizados);
    } catch (error) {
      console.log("Erro ao carregar alunos:", error);
    } finally {
      setLoading(false);
    }
  };

  if (loading) {
    return (
      <View style={styles.center}>
        <ActivityIndicator size="large" color="#6C2BD9" />
      </View>
    );
  }

  const grupos = agruparAlunosPorFaixaEtaria(alunos);
  const chaves = Object.keys(grupos);

  return (
    <View style={styles.container}>
      {chaves.length === 0 ? (
        <Text style={styles.vazio}>
          Nenhum aluno encontrado.
        </Text>
      ) : (
        chaves.map((chave) => (
          <View key={chave} style={styles.grupoContainer}>
            <Text style={styles.grupoTitulo}>{chave}</Text>
            <FlatList
              data={grupos[chave]}
              keyExtractor={(item, index) => `${chave}-${index}`}
              scrollEnabled={false}
              renderItem={({ item }) => (
                <View style={styles.card}>
                  <Text style={styles.nome}>
                    {item.nome || item.Nome || "Aluno sem nome"}
                  </Text>
                  <Text style={styles.info}>
                    Idade: {item.idade ?? "Não informada"}
                  </Text>
                  <Text style={styles.info}>
                    Turma: {item.turmaIdade}
                  </Text>
                </View>
              )}
            />
          </View>
        ))
      )}
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 15,
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