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

import api from "../../services/api";

export default function PresencaAluno({ route }) {

  const idAluno = Number(
    route?.params?.id_aluno || 0
  );

  const [presencas, setPresencas] =
    useState([]);

  const [carregando, setCarregando] =
    useState(true);

  const carregar = useCallback(async () => {

    console.log(
      "ID DO ALUNO EM PRESENÇA:",
      idAluno
    );

    if (idAluno <= 0) {
      setPresencas([]);
      setCarregando(false);
      return;
    }

    try {

      setCarregando(true);

      const response =
        await api.get(
          `/presenca.php?id_aluno=${idAluno}`
        );

      console.log(
        "PRESENÇAS RECEBIDAS:",
        response.data
      );

      const lista =
        Array.isArray(response.data)
          ? response.data
          : [];

      setPresencas(lista);

    } catch (error) {

      console.log(
        "ERRO PRESENÇA:",
        error.response?.data ||
        error.message
      );

      setPresencas([]);

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
        Minha Presença
      </Text>

      <Text style={styles.subtitulo}>
        Aluno: {idAluno}
      </Text>

      {carregando ? (

        <ActivityIndicator
          size="large"
          style={styles.loading}
        />

      ) : presencas.length === 0 ? (

        <View style={styles.vazio}>

          <Text style={styles.vazioTitulo}>
            Nenhum registro de presença
          </Text>

          <Text style={styles.vazioTexto}>
            A presença aparecerá aqui depois
            que o professor realizar a chamada.
          </Text>

        </View>

      ) : (

        presencas.map((p) => (

          <View
            key={String(p.id_presenca)}
            style={styles.card}
          >

            <Text style={styles.aula}>
              🏐 {p.modalidade || "Vôlei"}
            </Text>

            <Text style={styles.info}>
              📅 Data: {p.data_presenca}
            </Text>

            <Text style={styles.info}>
              📅 Dia: {p.dia_semana}
            </Text>

            <Text style={styles.info}>
              ⏰{" "}
              {String(
                p.hora_inicio || ""
              ).substring(0, 5)}
              {" - "}
              {String(
                p.hora_fim || ""
              ).substring(0, 5)}
            </Text>

            <Text style={styles.info}>
              👨‍🏫 Professor: {p.professor}
            </Text>

            <Text
              style={[
                styles.status,
                p.status === "Presente"
                  ? styles.presente
                  : p.status === "Faltou"
                  ? styles.falta
                  : styles.justificado
              ]}
            >
              {p.status}
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
    padding: 20,
    borderRadius: 22,
    marginBottom: 15,
    elevation: 4,
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 3
    },
    shadowOpacity: 0.08,
    shadowRadius: 7,
    borderWidth: 1,
    borderColor: "#F0F1F4"
  },

  aula: {
    fontSize: 21,
    fontWeight: "800",
    color: "#FA2A55",
    marginBottom: 15
  },

  info: {
    fontSize: 14,
    color: "#555B66",
    marginBottom: 8,
    fontWeight: "500"
  },

  status: {
    marginTop: 8,
    alignSelf: "flex-start",
    paddingHorizontal: 14,
    paddingVertical: 7,
    borderRadius: 20,
    fontSize: 14,
    fontWeight: "800"
  },

  presente: {
    color: "#16803C",
    backgroundColor: "#E6F7EC"
  },

  falta: {
    color: "#C62828",
    backgroundColor: "#FDEAEA"
  },

  justificado: {
    color: "#A06A00",
    backgroundColor: "#FFF5D6"
  }
});