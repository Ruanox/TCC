import React, {
  useEffect,
  useState,
} from "react";

import {
  ScrollView,
  View,
  Text,
  StyleSheet,
  TextInput,
  TouchableOpacity,
  Alert,
  ActivityIndicator,
} from "react-native";

import {
  getHorarios,
  atualizarHorario,
} from "../../services/horarioService";

export default function HorariosScreen() {
  const [aulas, setAulas] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    carregarHorarios();
  }, []);

  async function carregarHorarios() {
    try {
      const dados = await getHorarios();

      setAulas(
        Array.isArray(dados)
          ? dados
          : []
      );
    } catch (error) {
      console.log(
        "Erro:",
        error.response?.data ||
          error.message
      );

      Alert.alert(
        "Erro",
        "Não foi possível carregar os horários."
      );
    } finally {
      setLoading(false);
    }
  }

  async function salvarHorario(aula) {
    try {
      const resposta =
        await atualizarHorario({
          id_horario:
            aula.id_horario,

          dia_semana:
            aula.dia_semana,

          hora_inicio:
            aula.hora_inicio,

          hora_fim:
            aula.hora_fim,
        });

      if (resposta?.success) {
        Alert.alert(
          "Sucesso",
          "Horário atualizado com sucesso!"
        );
      } else {
        Alert.alert(
          "Erro",
          resposta?.error ||
            "Não foi possível atualizar."
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
          "Não foi possível atualizar."
      );
    }
  }

  function atualizarCampo(
    index,
    campo,
    valor
  ) {
    setAulas((lista) => {
      const novaLista = [...lista];

      novaLista[index] = {
        ...novaLista[index],
        [campo]: valor,
      };

      return novaLista;
    });
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

  return (
    <ScrollView
      style={styles.container}
    >
      <Text style={styles.title}>
        Gerenciar Horários
      </Text>

      {aulas.length === 0 ? (
        <Text style={styles.vazio}>
          Nenhum horário encontrado.
        </Text>
      ) : (
        aulas.map((aula, index) => (
          <View
            key={aula.id_horario}
            style={styles.card}
          >
            <Text style={styles.label}>
              Modalidade
            </Text>

            <Text style={styles.info}>
              {aula.modalidade ||
                "Não informada"}
            </Text>

            <Text style={styles.label}>
              Professor
            </Text>

            <Text style={styles.info}>
              {aula.professor ||
                "Não informado"}
            </Text>

            <Text style={styles.label}>
              Turno
            </Text>

            <Text style={styles.info}>
              {aula.turno ||
                "Não informado"}
            </Text>

            <Text style={styles.label}>
              Dia da semana
            </Text>

            <TextInput
              style={styles.input}
              value={
                aula.dia_semana || ""
              }
              onChangeText={(text) =>
                atualizarCampo(
                  index,
                  "dia_semana",
                  text
                )
              }
            />

            <Text style={styles.label}>
              Hora inicial
            </Text>

            <TextInput
              style={styles.input}
              value={
                aula.hora_inicio || ""
              }
              onChangeText={(text) =>
                atualizarCampo(
                  index,
                  "hora_inicio",
                  text
                )
              }
              placeholder="08:00:00"
            />

            <Text style={styles.label}>
              Hora final
            </Text>

            <TextInput
              style={styles.input}
              value={
                aula.hora_fim || ""
              }
              onChangeText={(text) =>
                atualizarCampo(
                  index,
                  "hora_fim",
                  text
                )
              }
              placeholder="10:00:00"
            />

            <TouchableOpacity
              style={styles.botao}
              onPress={() =>
                salvarHorario(aula)
              }
            >
              <Text
                style={styles.botaoTexto}
              >
                Salvar Alterações
              </Text>
            </TouchableOpacity>
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

  center: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
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

  label: {
    fontWeight: "bold",
    marginTop: 8,
    marginBottom: 4,
  },

  info: {
    marginBottom: 8,
    color: "#555",
  },

  input: {
    borderWidth: 1,
    borderColor: "#ddd",
    borderRadius: 8,
    padding: 10,
    marginBottom: 10,
    backgroundColor: "#fff",
  },

  botao: {
    backgroundColor: "#6C2BD9",
    padding: 12,
    borderRadius: 8,
    alignItems: "center",
    marginTop: 5,
  },

  botaoTexto: {
    color: "#fff",
    fontWeight: "bold",
  },

  vazio: {
    textAlign: "center",
    marginTop: 20,
    fontSize: 16,
  },
});