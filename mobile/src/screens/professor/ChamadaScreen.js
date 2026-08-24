import React, {
  useEffect,
  useState,
} from "react";

import {
  View,
  Text,
  FlatList,
  TouchableOpacity,
  StyleSheet,
  Alert,
} from "react-native";

import api from "../../services/api";

export default function ChamadaScreen() {
  const [alunos, setAlunos] = useState([]);
  const [horario, setHorario] =
    useState(null);

  useEffect(() => {
    carregarDados();
  }, []);

  async function carregarDados() {
    try {
      const alunosResponse =
        await api.get("/alunos.php");

      const horariosResponse =
        await api.get("/horarios.php");

      const listaAlunos =
        Array.isArray(
          alunosResponse.data
        )
          ? alunosResponse.data
          : [];

      const listaHorarios =
        Array.isArray(
          horariosResponse.data
        )
          ? horariosResponse.data
          : [];

      setAlunos(listaAlunos);

      if (listaHorarios.length > 0) {
        setHorario(
          listaHorarios[0]
        );
      }
    } catch (error) {
      console.log(
        "Erro:",
        error.response?.data ||
          error.message
      );

      Alert.alert(
        "Erro",
        "Não foi possível carregar os dados."
      );
    }
  }

  async function marcarPresenca(
    id_aluno,
    status
  ) {
    if (!horario?.id_horario) {
      Alert.alert(
        "Erro",
        "Nenhum horário disponível para registrar a presença."
      );
      return;
    }

    try {
      const resposta =
        await api.post(
          "/presenca.php",
          {
            id_aluno,
            id_horario:
              horario.id_horario,
            data_presenca:
              new Date()
                .toISOString()
                .split("T")[0],
            status,
          }
        );

      if (resposta.data?.success) {
        Alert.alert(
          "Sucesso",
          status === "Presente"
            ? "Presença registrada."
            : status === "Faltou"
            ? "Falta registrada."
            : "Justificativa registrada."
        );
      } else {
        Alert.alert(
          "Erro",
          resposta.data?.error ||
            "Não foi possível salvar."
        );
      }
    } catch (error) {
      console.log(
        "Erro:",
        error.response?.data ||
          error.message
      );

      Alert.alert(
        "Erro",
        error.response?.data?.error ||
          "Não foi possível salvar a presença."
      );
    }
  }

  function renderItem({ item }) {
    return (
      <View style={styles.card}>
        <Text style={styles.nome}>
          {item.nome}
        </Text>

        <View style={styles.botoes}>
          <TouchableOpacity
            style={[
              styles.botao,
              styles.presente,
            ]}
            onPress={() =>
              marcarPresenca(
                item.id_aluno,
                "Presente"
              )
            }
          >
            <Text style={styles.textoBotao}>
              Presente
            </Text>
          </TouchableOpacity>

          <TouchableOpacity
            style={[
              styles.botao,
              styles.falta,
            ]}
            onPress={() =>
              marcarPresenca(
                item.id_aluno,
                "Faltou"
              )
            }
          >
            <Text style={styles.textoBotao}>
              Falta
            </Text>
          </TouchableOpacity>
        </View>
      </View>
    );
  }

  return (
    <View style={styles.container}>
      <Text style={styles.titulo}>
        Chamada
      </Text>

      {horario && (
        <View style={styles.horario}>
          <Text style={styles.horarioTitulo}>
            {horario.modalidade}
          </Text>

          <Text>
            {horario.dia_semana}
          </Text>

          <Text>
            {horario.hora_inicio} -{" "}
            {horario.hora_fim}
          </Text>

          <Text>
            Professor:{" "}
            {horario.professor}
          </Text>
        </View>
      )}

      <FlatList
        data={alunos}
        keyExtractor={(item) =>
          String(item.id_aluno)
        }
        renderItem={renderItem}
        ListEmptyComponent={
          <Text style={styles.vazio}>
            Nenhum aluno encontrado.
          </Text>
        }
      />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 15,
    backgroundColor: "#fff",
  },

  titulo: {
    fontSize: 26,
    fontWeight: "bold",
    marginBottom: 15,
  },

  horario: {
    backgroundColor: "#f5f5f5",
    padding: 15,
    borderRadius: 10,
    marginBottom: 15,
  },

  horarioTitulo: {
    fontSize: 18,
    fontWeight: "bold",
    marginBottom: 5,
  },

  card: {
    backgroundColor: "#f5f5f5",
    padding: 15,
    borderRadius: 10,
    marginBottom: 10,
  },

  nome: {
    fontSize: 18,
    marginBottom: 10,
  },

  botoes: {
    flexDirection: "row",
    justifyContent: "space-between",
  },

  botao: {
    flex: 1,
    padding: 10,
    borderRadius: 8,
    marginHorizontal: 5,
    alignItems: "center",
  },

  presente: {
    backgroundColor: "#28a745",
  },

  falta: {
    backgroundColor: "#dc3545",
  },

  textoBotao: {
    color: "#fff",
    fontWeight: "bold",
  },

  vazio: {
    textAlign: "center",
    marginTop: 20,
  },
});