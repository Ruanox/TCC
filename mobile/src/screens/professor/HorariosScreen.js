import React, {
  useCallback,
  useState
} from "react";

import {
  View,
  Text,
  StyleSheet,
  TouchableOpacity,
  ScrollView,
  TextInput,
  Alert,
  ActivityIndicator
} from "react-native";

import {
  useFocusEffect,
  useRoute
} from "@react-navigation/native";

import {
  getHorarios,
  atualizarHorario
} from "../../services/horarioService";

export default function HorariosScreen() {

  const route = useRoute();

  const idProfessor = Number(
    route?.params?.id_professor || 0
  );

  const [horarios, setHorarios] = useState([]);

  const [horarioSelecionado, setHorarioSelecionado] =
    useState(null);

  const [diaSelecionado, setDiaSelecionado] =
    useState(0);

  const [horaInicio, setHoraInicio] =
    useState("");

  const [horaFim, setHoraFim] =
    useState("");

  const [carregando, setCarregando] =
    useState(false);

  const dias = [
    {
      id: 1,
      nome: "Segunda-feira"
    },
    {
      id: 2,
      nome: "Terça-feira"
    },
    {
      id: 3,
      nome: "Quarta-feira"
    },
    {
      id: 4,
      nome: "Quinta-feira"
    },
    {
      id: 5,
      nome: "Sexta-feira"
    },
    {
      id: 6,
      nome: "Sábado"
    },
    {
      id: 7,
      nome: "Domingo"
    }
  ];

  const carregarHorarios = async () => {

    try {

      setCarregando(true);

      console.log(
        "BUSCANDO HORÁRIOS DO PROFESSOR:",
        idProfessor
      );

      const dados = await getHorarios(
        idProfessor
      );

      console.log(
        "HORÁRIOS RECEBIDOS:",
        dados
      );

      setHorarios(
        Array.isArray(dados)
          ? dados
          : []
      );

    } catch (error) {

      console.log(
        "Erro ao carregar horários:",
        error.response?.data ||
        error.message
      );

      Alert.alert(
        "Erro",
        "Não foi possível carregar os horários."
      );

    } finally {

      setCarregando(false);

    }
  };

  useFocusEffect(
    useCallback(() => {

      carregarHorarios();

    }, [idProfessor])
  );

  const selecionarHorario = (horario) => {

    console.log(
      "HORÁRIO SELECIONADO:",
      horario
    );

    setHorarioSelecionado(horario);

    setDiaSelecionado(
      Number(horario.id_dia)
    );

    setHoraInicio(
      horario.hora_inicio
        ? String(horario.hora_inicio).substring(0, 5)
        : ""
    );

    setHoraFim(
      horario.hora_fim
        ? String(horario.hora_fim).substring(0, 5)
        : ""
    );
  };

  const salvarHorario = async () => {

    try {

      if (!horarioSelecionado) {

        Alert.alert(
          "Atenção",
          "Selecione um horário."
        );

        return;
      }

      const idHorario = Number(
        horarioSelecionado.id_horario
      );

      const idProf = Number(
        idProfessor ||
        horarioSelecionado.id_professor ||
        0
      );

      const idDia = Number(
        diaSelecionado
      );

      if (idHorario <= 0) {

        Alert.alert(
          "Erro",
          "ID do horário inválido."
        );

        return;
      }

      if (idProf <= 0) {

        Alert.alert(
          "Erro",
          "ID do professor inválido."
        );

        return;
      }

      if (idDia <= 0) {

        Alert.alert(
          "Erro",
          "Selecione o dia da aula."
        );

        return;
      }

      if (
        !horaInicio ||
        !horaFim
      ) {

        Alert.alert(
          "Erro",
          "Informe o horário de início e fim."
        );

        return;
      }

      const resposta =
        await atualizarHorario({

          id_horario: idHorario,

          id_professor: idProf,

          id_dia: idDia,

          hora_inicio:
            horaInicio.length === 5
              ? `${horaInicio}:00`
              : horaInicio,

          hora_fim:
            horaFim.length === 5
              ? `${horaFim}:00`
              : horaFim,

          acao: ""
        });

      if (
        !resposta ||
        !resposta.success
      ) {

        Alert.alert(
          "Erro",
          resposta?.error ||
          "Não foi possível alterar o horário."
        );

        return;
      }

      Alert.alert(
        "Sucesso",
        "Horário alterado com sucesso."
      );

      setHorarioSelecionado(null);

      setDiaSelecionado(0);

      setHoraInicio("");

      setHoraFim("");

      await carregarHorarios();

    } catch (error) {

      console.log(
        "ERRO AO SALVAR:",
        error.response?.data ||
        error.message
      );

      const dados =
        error.response?.data;

      Alert.alert(
        "Erro",
        dados?.details ||
        dados?.error ||
        error.message ||
        "Erro ao alterar horário."
      );
    }
  };

  const cancelarAula = async () => {

    try {

      if (!horarioSelecionado) {

        Alert.alert(
          "Atenção",
          "Selecione uma aula."
        );

        return;
      }

      const idHorario = Number(
        horarioSelecionado.id_horario
      );

      const idProf = Number(
        idProfessor ||
        horarioSelecionado.id_professor ||
        0
      );

      if (
        idHorario <= 0 ||
        idProf <= 0
      ) {

        Alert.alert(
          "Erro",
          "Dados do horário inválidos."
        );

        return;
      }

      Alert.alert(
        "Cancelar aula",
        "Deseja avisar os alunos que esta aula foi cancelada?",
        [
          {
            text: "Não",
            style: "cancel"
          },
          {
            text: "Sim",
            onPress: async () => {

              try {

                const resposta =
                  await atualizarHorario({

                    id_horario:
                      idHorario,

                    id_professor:
                      idProf,

                    id_dia:
                      Number(
                        horarioSelecionado.id_dia
                      ),

                    hora_inicio:
                      horarioSelecionado.hora_inicio,

                    hora_fim:
                      horarioSelecionado.hora_fim,

                    acao: "cancelar"
                  });

                if (
                  !resposta ||
                  !resposta.success
                ) {

                  Alert.alert(
                    "Erro",
                    resposta?.error ||
                    "Não foi possível enviar o aviso."
                  );

                  return;
                }

                Alert.alert(
                  "Aviso enviado",
                  "Os alunos foram avisados sobre o cancelamento."
                );

              } catch (error) {

                console.log(
                  "ERRO AO CANCELAR:",
                  error.response?.data ||
                  error.message
                );

                Alert.alert(
                  "Erro",
                  error.response?.data?.details ||
                  error.response?.data?.error ||
                  error.message ||
                  "Erro ao avisar o cancelamento."
                );
              }
            }
          }
        ]
      );

    } catch (error) {

      console.log(
        "Erro:",
        error
      );

    }
  };

  return (

    <ScrollView
      style={styles.container}
      contentContainerStyle={styles.content}
    >

      <Text style={styles.titulo}>
        Horários das aulas
      </Text>

      <Text style={styles.subtitulo}>
        Professor ID: {idProfessor}
      </Text>

      {carregando ? (

        <ActivityIndicator
          size="large"
          style={styles.loading}
        />

      ) : horarios.length === 0 ? (

        <View style={styles.vazio}>

          <Text style={styles.vazioTexto}>
            Nenhum horário encontrado.
          </Text>

        </View>

      ) : (

        horarios.map((horario) => (

          <TouchableOpacity
            key={String(
              horario.id_horario
            )}
            style={[
              styles.card,
              horarioSelecionado?.id_horario ===
              horario.id_horario &&
              styles.cardSelecionado
            ]}
            onPress={() =>
              selecionarHorario(horario)
            }
          >

            <Text style={styles.modalidade}>
              {horario.modalidade ||
                "Modalidade"}
            </Text>

            <Text style={styles.info}>
              Professor:{" "}
              {horario.professor ||
                "Não informado"}
            </Text>

            <Text style={styles.info}>
              Dia:{" "}
              {horario.dia_semana ||
                "Não informado"}
            </Text>

            <Text style={styles.info}>
              Horário:{" "}
              {String(
                horario.hora_inicio || ""
              ).substring(0, 5)}
              {" - "}
              {String(
                horario.hora_fim || ""
              ).substring(0, 5)}
            </Text>

            <Text style={styles.info}>
              Turno:{" "}
              {horario.turno ||
                "Não informado"}
            </Text>

          </TouchableOpacity>

        ))

      )}

      {horarioSelecionado && (

        <View style={styles.edicao}>

          <Text style={styles.edicaoTitulo}>
            Alterar horário
          </Text>

          <Text style={styles.label}>
            Dia da semana
          </Text>

          <ScrollView
            horizontal
            showsHorizontalScrollIndicator={false}
            style={styles.diasContainer}
          >

            {dias.map((dia) => (

              <TouchableOpacity
                key={dia.id}
                style={[
                  styles.diaButton,
                  diaSelecionado === dia.id &&
                  styles.diaSelecionado
                ]}
                onPress={() =>
                  setDiaSelecionado(dia.id)
                }
              >

                <Text
                  style={[
                    styles.diaTexto,
                    diaSelecionado === dia.id &&
                    styles.diaTextoSelecionado
                  ]}
                >
                  {dia.nome}
                </Text>

              </TouchableOpacity>

            ))}

          </ScrollView>

          <Text style={styles.label}>
            Hora de início
          </Text>

          <TextInput
            style={styles.input}
            value={horaInicio}
            onChangeText={setHoraInicio}
            placeholder="07:00"
            keyboardType="numbers-and-punctuation"
            maxLength={5}
          />

          <Text style={styles.label}>
            Hora de término
          </Text>

          <TextInput
            style={styles.input}
            value={horaFim}
            onChangeText={setHoraFim}
            placeholder="22:00"
            keyboardType="numbers-and-punctuation"
            maxLength={5}
          />

          <TouchableOpacity
            style={styles.botaoSalvar}
            onPress={salvarHorario}
          >

            <Text style={styles.botaoTexto}>
              Salvar alteração
            </Text>

          </TouchableOpacity>

          <TouchableOpacity
            style={styles.botaoCancelar}
            onPress={cancelarAula}
          >

            <Text style={styles.botaoTexto}>
              Avisar cancelamento
            </Text>

          </TouchableOpacity>

        </View>

      )}

    </ScrollView>
  );
}

const styles = StyleSheet.create({

  container: {
    flex: 1,
    backgroundColor: "#f5f5f5"
  },

  content: {
    padding: 20,
    paddingBottom: 40
  },

  titulo: {
    fontSize: 25,
    fontWeight: "bold",
    marginBottom: 5
  },

  subtitulo: {
    fontSize: 14,
    color: "#666",
    marginBottom: 20
  },

  loading: {
    marginTop: 40
  },

  vazio: {
    padding: 30,
    alignItems: "center"
  },

  vazioTexto: {
    fontSize: 16,
    color: "#777"
  },

  card: {
    backgroundColor: "#fff",
    padding: 18,
    borderRadius: 12,
    marginBottom: 12,
    elevation: 2
  },

  cardSelecionado: {
    borderWidth: 2,
    borderColor: "#222"
  },

  modalidade: {
    fontSize: 19,
    fontWeight: "bold",
    marginBottom: 8
  },

  info: {
    fontSize: 15,
    marginTop: 4,
    color: "#444"
  },

  edicao: {
    backgroundColor: "#fff",
    padding: 18,
    borderRadius: 12,
    marginTop: 10
  },

  edicaoTitulo: {
    fontSize: 21,
    fontWeight: "bold",
    marginBottom: 18
  },

  label: {
    fontSize: 15,
    fontWeight: "bold",
    marginBottom: 8,
    marginTop: 10
  },

  diasContainer: {
    marginBottom: 5
  },

  diaButton: {
    paddingVertical: 10,
    paddingHorizontal: 14,
    borderWidth: 1,
    borderColor: "#ccc",
    borderRadius: 8,
    marginRight: 8,
    backgroundColor: "#fff"
  },

  diaSelecionado: {
    backgroundColor: "#222",
    borderColor: "#222"
  },

  diaTexto: {
    fontSize: 13,
    color: "#333"
  },

  diaTextoSelecionado: {
    color: "#fff",
    fontWeight: "bold"
  },

  input: {
    height: 48,
    borderWidth: 1,
    borderColor: "#ccc",
    borderRadius: 8,
    paddingHorizontal: 12,
    fontSize: 16,
    backgroundColor: "#fff"
  },

  botaoSalvar: {
    marginTop: 20,
    backgroundColor: "#222",
    padding: 15,
    borderRadius: 8,
    alignItems: "center"
  },

  botaoCancelar: {
    marginTop: 10,
    backgroundColor: "#777",
    padding: 15,
    borderRadius: 8,
    alignItems: "center"
  },

  botaoTexto: {
    color: "#fff",
    fontSize: 16,
    fontWeight: "bold"
  }

});