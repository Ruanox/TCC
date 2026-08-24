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

import {
  getAulas,
} from "../../services/aulaService";

export default function HorariosAluno() {
  const [aulas, setAulas] =
    useState([]);

  useEffect(() => {
    carregar();
  }, []);

  async function carregar() {
    try {
      const data =
        await getAulas();

      setAulas(
        Array.isArray(data)
          ? data
          : []
      );
    } catch (error) {
      console.log(
        "Erro:",
        error.message
      );
    }
  }

  return (
    <ScrollView
      style={styles.container}
    >
      <Text style={styles.title}>
        Meus Horários
      </Text>

      {aulas.length === 0 ? (
        <Text>
          Nenhum horário encontrado.
        </Text>
      ) : (
        aulas.map((aula) => (
          <View
            key={aula.id_horario}
            style={styles.card}
          >
            <Text
              style={styles.modalidade}
            >
              {aula.modalidade}
            </Text>

            <Text style={styles.info}>
              📅 {aula.dia_semana}
            </Text>

            <Text style={styles.info}>
              ⏰ {aula.hora_inicio} -{" "}
              {aula.hora_fim}
            </Text>

            <Text style={styles.info}>
              👨‍🏫 {aula.professor}
            </Text>

            <Text style={styles.info}>
              🌙 {aula.turno}
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
    borderRadius: 15,
    padding: 20,
    marginBottom: 15,
    elevation: 4,
  },

  modalidade: {
    fontSize: 22,
    fontWeight: "bold",
    color: "#FA2A55",
    marginBottom: 10,
  },

  info: {
    fontSize: 16,
    marginBottom: 5,
    color: "#444",
  },
});