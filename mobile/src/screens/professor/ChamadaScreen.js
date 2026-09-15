import React, {
  useCallback,
  useState
} from "react";

import {
  View,
  Text,
  FlatList,
  TouchableOpacity,
  StyleSheet,
  Alert,
  ActivityIndicator
} from "react-native";

import {
  useFocusEffect,
  useRoute
} from "@react-navigation/native";

import api from "../../services/api";

export default function ChamadaScreen() {

  const route = useRoute();

  const idProfessor = Number(
    route?.params?.id_professor || 0
  );

  const [alunos, setAlunos] =
    useState([]);

  const [horarios, setHorarios] =
    useState([]);

  const [horarioSelecionado, setHorarioSelecionado] =
    useState(null);

  const [carregando, setCarregando] =
    useState(true);

  const carregarDados = useCallback(
    async () => {

      if (idProfessor <= 0) {

        console.log(
          "ID DO PROFESSOR NÃO RECEBIDO:",
          route?.params
        );

        setAlunos([]);
        setHorarios([]);
        setCarregando(false);

        return;
      }

      try {

        setCarregando(true);

        console.log(
          "CARREGANDO CHAMADA PROFESSOR:",
          idProfessor
        );

        const alunosResponse =
          await api.get(
            `/alunos.php?id_professor=${idProfessor}`
          );

        console.log(
          "ALUNOS DO PROFESSOR:",
          alunosResponse.data
        );

        setAlunos(
          Array.isArray(
            alunosResponse.data
          )
            ? alunosResponse.data
            : []
        );

        const horariosResponse =
          await api.get(
            `/horarios.php?id_professor=${idProfessor}`
          );

        console.log(
          "HORÁRIOS DO PROFESSOR:",
          horariosResponse.data
        );

        const listaHorarios =
          Array.isArray(
            horariosResponse.data
          )
            ? horariosResponse.data
            : [];

        setHorarios(
          listaHorarios
        );

        if (
          listaHorarios.length > 0
        ) {

          setHorarioSelecionado(
            listaHorarios[0]
          );

        } else {

          setHorarioSelecionado(
            null
          );

        }

      } catch (error) {

        console.log(
          "ERRO AO CARREGAR CHAMADA:",
          error.response?.data ||
          error.message
        );

        Alert.alert(
          "Erro",
          error.response?.data?.error ||
          "Não foi possível carregar os dados."
        );

        setAlunos([]);
        setHorarios([]);

      } finally {

        setCarregando(false);

      }

    },
    [idProfessor]
  );

  useFocusEffect(
    useCallback(() => {

      carregarDados();

    }, [carregarDados])
  );

  async function marcarPresenca(
    idAluno,
    status
  ) {

    if (
      !horarioSelecionado?.id_horario
    ) {

      Alert.alert(
        "Erro",
        "Selecione um horário."
      );

      return;
    }

    try {

      const hoje =
        new Date()
          .toISOString()
          .split("T")[0];

      const resposta =
        await api.post(
          "/presenca.php",
          {
            id_aluno:
              Number(idAluno),

            id_horario:
              Number(
                horarioSelecionado.id_horario
              ),

            data_presenca:
              hoje,

            status:
              status
          }
        );

      console.log(
        "RESPOSTA PRESENÇA:",
        resposta.data
      );

      if (
        resposta.data?.success
      ) {

        Alert.alert(
          "Sucesso",
          status === "Presente"
            ? "Presença registrada."
            : "Falta registrada."
        );

      } else {

        Alert.alert(
          "Erro",
          resposta.data?.error ||
          "Não foi possível registrar."
        );

      }

    } catch (error) {

      console.log(
        "ERRO AO REGISTRAR PRESENÇA:",
        error.response?.data ||
        error.message
      );

      Alert.alert(
        "Erro",
        error.response?.data?.error ||
        "Não foi possível registrar a presença."
      );

    }
  }

  function renderAluno({
    item
  }) {

    return (

      <View style={styles.card}>

        <View style={styles.informacoes}>

          <Text style={styles.nome}>
            {item.usuario}
          </Text>

          <Text style={styles.info}>
            Idade: {item.idade ?? "-"}
          </Text>

          <Text style={styles.info}>
            Turma: {item.turma_idade || "-"}
          </Text>

        </View>

        <View style={styles.botoes}>

          <TouchableOpacity
            style={[
              styles.botao,
              styles.presente
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
              styles.falta
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

  if (carregando) {

    return (

      <View style={styles.carregando}>

        <ActivityIndicator
          size="large"
        />

        <Text style={styles.textoCarregando}>
          Carregando chamada...
        </Text>

      </View>
    );
  }

  return (

    <View style={styles.container}>

      <Text style={styles.titulo}>
        Chamada
      </Text>

      <Text style={styles.professor}>
        Professor ID: {idProfessor}
      </Text>

      {horarios.length > 0 ? (

        <View>

          <Text style={styles.label}>
            Selecione a aula:
          </Text>

          <FlatList
            horizontal
            data={horarios}
            keyExtractor={(item) =>
              String(item.id_horario)
            }
            showsHorizontalScrollIndicator={
              false
            }
            renderItem={({
              item
            }) => (

              <TouchableOpacity
                style={[
                  styles.horarioBotao,
                  horarioSelecionado?.id_horario ===
                    item.id_horario &&
                    styles.horarioSelecionado
                ]}
                onPress={() =>
                  setHorarioSelecionado(
                    item
                  )
                }
              >

                <Text
                  style={
                    styles.horarioBotaoTexto
                  }
                >
                  {item.modalidade}
                </Text>

                <Text>
                  {item.dia_semana}
                </Text>

                <Text>
                  {String(
                    item.hora_inicio
                  ).substring(0, 5)}
                  {" - "}
                  {String(
                    item.hora_fim
                  ).substring(0, 5)}
                </Text>

              </TouchableOpacity>

            )}
          />

          {horarioSelecionado && (

            <View style={styles.horario}>

              <Text
                style={styles.horarioTitulo}
              >
                {horarioSelecionado.modalidade}
              </Text>

              <Text>
                Dia:{" "}
                {horarioSelecionado.dia_semana}
              </Text>

              <Text>
                Horário:{" "}
                {String(
                  horarioSelecionado.hora_inicio
                ).substring(0, 5)}
                {" - "}
                {String(
                  horarioSelecionado.hora_fim
                ).substring(0, 5)}
              </Text>

              <Text>
                Professor:{" "}
                {horarioSelecionado.professor}
              </Text>

            </View>

          )}

        </View>

      ) : (

        <View style={styles.semHorario}>

          <Text>
            Nenhum horário cadastrado.
          </Text>

        </View>

      )}

      <Text style={styles.subtitulo}>
        Alunos ({alunos.length})
      </Text>

      <FlatList
        data={alunos}
        keyExtractor={(item) =>
          String(item.id_aluno)
        }
        renderItem={renderAluno}
        showsVerticalScrollIndicator={false}
        refreshing={carregando}
        onRefresh={carregarDados}
        ListEmptyComponent={

          <Text style={styles.vazio}>
            Nenhum aluno matriculado.
          </Text>

        }
      />

    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
    backgroundColor: "#F4F6FA"
  },

  carregando: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    backgroundColor: "#F4F6FA"
  },

  textoCarregando: {
    marginTop: 12,
    fontSize: 15,
    color: "#777D89"
  },

  titulo: {
    fontSize: 30,
    fontWeight: "800",
    color: "#171A21",
    marginBottom: 5
  },

  professor: {
    fontSize: 14,
    color: "#7A7F8A",
    marginBottom: 20
  },

  label: {
    fontSize: 17,
    fontWeight: "800",
    color: "#252932",
    marginBottom: 10
  },

  horarioBotao: {
    backgroundColor: "#FFFFFF",
    padding: 15,
    borderRadius: 17,
    marginRight: 10,
    minWidth: 155,
    elevation: 3,
    borderWidth: 1,
    borderColor: "#ECEEF2"
  },

  horarioSelecionado: {
    borderWidth: 2,
    borderColor: "#FA2A55",
    backgroundColor: "#FFF3F6"
  },

  horarioBotaoTexto: {
    fontWeight: "800",
    color: "#FA2A55",
    fontSize: 16,
    marginBottom: 6
  },

  horario: {
    backgroundColor: "#FFFFFF",
    padding: 18,
    borderRadius: 20,
    marginTop: 12,
    marginBottom: 20,
    elevation: 3,
    borderLeftWidth: 5,
    borderLeftColor: "#FA2A55"
  },

  horarioTitulo: {
    fontSize: 20,
    fontWeight: "800",
    color: "#20232A",
    marginBottom: 8
  },

  semHorario: {
    backgroundColor: "#FFFFFF",
    padding: 18,
    borderRadius: 18,
    marginBottom: 20
  },

  subtitulo: {
    fontSize: 21,
    fontWeight: "800",
    color: "#20232A",
    marginBottom: 12
  },

  card: {
    backgroundColor: "#FFFFFF",
    padding: 18,
    borderRadius: 20,
    marginBottom: 12,
    elevation: 3,
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 3
    },
    shadowOpacity: 0.08,
    shadowRadius: 6
  },

  informacoes: {
    marginBottom: 14
  },

  nome: {
    fontSize: 19,
    fontWeight: "800",
    color: "#20232A",
    marginBottom: 6
  },

  info: {
    fontSize: 14,
    color: "#666C77",
    marginBottom: 4
  },

  botoes: {
    flexDirection: "row",
    gap: 8
  },

  botao: {
    flex: 1,
    paddingVertical: 13,
    borderRadius: 13,
    alignItems: "center",
    justifyContent: "center"
  },

  presente: {
    backgroundColor: "#20A45A"
  },

  falta: {
    backgroundColor: "#E04444"
  },

  textoBotao: {
    color: "#FFFFFF",
    fontWeight: "800",
    fontSize: 14
  },

  vazio: {
    textAlign: "center",
    marginTop: 25,
    color: "#777D89",
    fontSize: 15
  }
});