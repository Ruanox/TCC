import React, {
  useCallback,
  useState
} from "react";

import {
  ScrollView,
  View,
  Text,
  StyleSheet,
  ActivityIndicator,
  RefreshControl
} from "react-native";

import {
  useFocusEffect
} from "@react-navigation/native";

import {
  getAulas
} from "../../services/aulaService";

export default function HorariosAluno({ route }) {

  const idAluno = Number(
    route?.params?.id_aluno || 0
  );

  const [aulas, setAulas] = useState([]);
  const [carregando, setCarregando] = useState(true);

  const carregar = useCallback(async () => {

    console.log(
      "ID DO ALUNO EM HORÁRIOS:",
      idAluno
    );

    if (idAluno <= 0) {
      setAulas([]);
      setCarregando(false);
      return;
    }

    try {

      setCarregando(true);

      const dados = await getAulas(
        idAluno,
        0
      );

      console.log(
        "HORÁRIOS DO ALUNO:",
        dados
      );

      setAulas(
        Array.isArray(dados)
          ? dados
          : []
      );

    } catch (error) {

      console.log(
        "ERRO HORÁRIOS ALUNO:",
        error.response?.data ||
        error.message
      );

      setAulas([]);

    } finally {

      setCarregando(false);

    }

  }, [idAluno]);

  useFocusEffect(
    useCallback(() => {
      carregar();
    }, [carregar])
  );

  return (

    <ScrollView
      style={styles.container}
      contentContainerStyle={styles.content}
      refreshControl={
        <RefreshControl
          refreshing={carregando}
          onRefresh={carregar}
        />
      }
    >

      <Text style={styles.title}>
        Meus Horários
      </Text>

      <Text style={styles.subtitulo}>
        Aluno: {idAluno}
      </Text>

      {carregando ? (

        <ActivityIndicator
          size="large"
          style={styles.loading}
        />

      ) : aulas.length === 0 ? (

        <View style={styles.vazio}>

          <Text style={styles.vazioTitulo}>
            Nenhum horário encontrado
          </Text>

          <Text style={styles.vazioTexto}>
            Este aluno precisa estar matriculado
            em uma modalidade para visualizar
            os horários.
          </Text>

        </View>

      ) : (

        aulas.map((aula) => (

          <View
            key={String(aula.id_horario)}
            style={styles.card}
          >

            <Text style={styles.modalidade}>
              {aula.modalidade || "Vôlei"}
            </Text>

            <Text style={styles.info}>
              📅 Dia: {aula.dia_semana || "Não informado"}
            </Text>

            <Text style={styles.info}>
              ⏰ Horário:{" "}
              {String(aula.hora_inicio || "")
                .substring(0, 5)}
              {" - "}
              {String(aula.hora_fim || "")
                .substring(0, 5)}
            </Text>

            <Text style={styles.info}>
              👨‍🏫 Professor:{" "}
              {aula.professor || "Não informado"}
            </Text>

            <Text style={styles.info}>
              🌙 Turno:{" "}
              {aula.turno || "Não informado"}
            </Text>

          </View>

        ))

      )}

    </ScrollView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#F4F6FA"
  },

  content: {
    padding: 20,
    paddingBottom: 40
  },

  title: {
    fontSize: 30,
    fontWeight: "800",
    color: "#171A21",
    letterSpacing: -0.5,
    marginBottom: 5
  },

  subtitulo: {
    fontSize: 14,
    color: "#7A7F8A",
    marginBottom: 22
  },

  loading: {
    marginTop: 50
  },

  vazio: {
    backgroundColor: "#FFFFFF",
    padding: 30,
    borderRadius: 22,
    alignItems: "center",
    elevation: 3,
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 3
    },
    shadowOpacity: 0.08,
    shadowRadius: 7
  },

  vazioTitulo: {
    fontSize: 20,
    fontWeight: "800",
    color: "#20232A",
    textAlign: "center",
    marginBottom: 10
  },

  vazioTexto: {
    textAlign: "center",
    color: "#777D89",
    fontSize: 14,
    lineHeight: 21
  },

  card: {
    backgroundColor: "#FFFFFF",
    padding: 22,
    borderRadius: 24,
    marginBottom: 18,
    elevation: 5,
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 4
    },
    shadowOpacity: 0.10,
    shadowRadius: 8,
    borderWidth: 1,
    borderColor: "#F0F1F4"
  },

  modalidade: {
    fontSize: 23,
    fontWeight: "800",
    color: "#FA2A55",
    marginBottom: 16
  },

  info: {
    fontSize: 15,
    color: "#4B505A",
    marginBottom: 9,
    fontWeight: "500"
  }
});