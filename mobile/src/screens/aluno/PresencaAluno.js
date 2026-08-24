import React, {
  useEffect,
  useState,
} from "react";

import {
  ScrollView,
  View,
  Text,
  StyleSheet,
} from "react-native";

import api from "../../services/api";

export default function PresencaAluno() {
  const [presencas, setPresencas] =
    useState([]);

  useEffect(() => {
    carregar();
  }, []);

  async function carregar() {
    try {
      const response =
        await api.get(
          "/presenca.php"
        );

      setPresencas(
        Array.isArray(response.data)
          ? response.data
          : []
      );
    } catch (error) {
      console.log(
        "Erro:",
        error.response?.data ||
          error.message
      );

      setPresencas([]);
    }
  }

  return (
    <ScrollView
      style={styles.container}
    >
      <Text style={styles.title}>
        Minha Presença
      </Text>

      {presencas.length === 0 ? (
        <Text>
          Nenhum registro de presença.
        </Text>
      ) : (
        presencas.map((p) => (
          <View
            key={p.id_presenca}
            style={styles.card}
          >
            <Text style={styles.aula}>
              🏐 {p.aluno}
            </Text>

            <Text style={styles.info}>
              📅 {p.data_presenca}
            </Text>

            <Text
              style={[
                styles.status,
                p.status === "Presente"
                  ? styles.presente
                  : p.status === "Faltou"
                  ? styles.falta
                  : styles.justificado,
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
    backgroundColor: "#f5f5f5",
    padding: 15,
  },

  title: {
    fontSize: 28,
    fontWeight: "bold",
    marginBottom: 20,
    color: "#222",
  },

  card: {
    backgroundColor: "#fff",
    padding: 20,
    borderRadius: 15,
    marginBottom: 15,
    elevation: 4,
  },

  aula: {
    fontSize: 22,
    fontWeight: "bold",
    color: "#FA2A55",
    marginBottom: 10,
  },

  info: {
    fontSize: 16,
    marginBottom: 10,
    color: "#444",
  },

  status: {
    fontSize: 16,
    fontWeight: "bold",
  },

  presente: {
    color: "green",
  },

  falta: {
    color: "red",
  },

  justificado: {
    color: "#d69e00",
  },
});