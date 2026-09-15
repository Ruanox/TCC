import React, {
  useEffect,
  useState,
} from "react";

import {
  View,
  Text,
  TextInput,
  TouchableOpacity,
  ScrollView,
  StyleSheet,
  Alert,
  ActivityIndicator,
} from "react-native";

import {
  getAlunos,
} from "../../services/alunoService";

import {
  enviarNotificacao,
} from "../../services/notificacaoService";

const TIPOS = [
  {
    nome: "Aula",
    icone: "🏐",
    titulo:
      "Lembrete de aula",
    mensagem:
      "Você possui aula de vôlei hoje.",
  },
  {
    nome: "Cancelamento",
    icone: "❌",
    titulo:
      "Aula cancelada",
    mensagem:
      "A aula foi cancelada.",
  },
  {
    nome: "Alteração",
    icone: "🔄",
    titulo:
      "Horário alterado",
    mensagem:
      "O horário da sua aula foi alterado.",
  },
  {
    nome: "Campeonato",
    icone: "🏆",
    titulo:
      "Você foi convocado para o campeonato!",
    mensagem:
      "Você foi convocado para participar do campeonato. Confira com o professor as informações sobre data, horário e local.",
  },
  {
    nome: "Aviso",
    icone: "📢",
    titulo:
      "Novo aviso",
    mensagem:
      "Você recebeu um novo aviso da escola.",
  },
];

export default function NotificacoesProfessor({
  route,
}) {
  const idProfessor = Number(
    route?.params?.id_professor || 0
  );

  const [alunos, setAlunos] =
    useState([]);

  const [alunoSelecionado, setAlunoSelecionado] =
    useState(null);

  const [tipo, setTipo] =
    useState("Aviso");

  const [titulo, setTitulo] =
    useState("");

  const [mensagem, setMensagem] =
    useState("");

  const [carregando, setCarregando] =
    useState(true);

  const [enviando, setEnviando] =
    useState(false);

  useEffect(() => {
    carregarAlunos();
  }, [idProfessor]);

  async function carregarAlunos() {
    try {
      setCarregando(true);

      const dados =
        await getAlunos(
          idProfessor
        );

      setAlunos(
        Array.isArray(dados)
          ? dados
          : []
      );
    } catch (error) {
      console.log(
        "Erro ao carregar alunos:",
        error.response?.data ||
          error.message
      );

      Alert.alert(
        "Erro",
        "Não foi possível carregar os alunos."
      );
    } finally {
      setCarregando(false);
    }
  }

  function selecionarTipo(tipoSelecionado) {
    setTipo(tipoSelecionado);

    const modelo =
      TIPOS.find(
        (item) =>
          item.nome ===
          tipoSelecionado
      );

    if (modelo) {
      setTitulo(modelo.titulo);
      setMensagem(modelo.mensagem);
    }
  }

  async function enviar() {
    if (enviando) {
      return;
    }

    if (!idProfessor) {
      Alert.alert(
        "Erro",
        "Professor não identificado."
      );
      return;
    }

    if (!alunoSelecionado) {
      Alert.alert(
        "Atenção",
        "Selecione um aluno."
      );
      return;
    }

    if (!titulo.trim()) {
      Alert.alert(
        "Atenção",
        "Informe o título."
      );
      return;
    }

    if (!mensagem.trim()) {
      Alert.alert(
        "Atenção",
        "Informe a mensagem."
      );
      return;
    }

    try {
      setEnviando(true);

      const resposta =
        await enviarNotificacao({
          id_professor:
            idProfessor,

          id_aluno:
            alunoSelecionado.id_aluno,

          titulo:
            titulo.trim(),

          mensagem:
            mensagem.trim(),

          tipo,
        });

      if (
        resposta?.success === true
      ) {
        Alert.alert(
          "Sucesso",
          "Notificação enviada com sucesso."
        );

        setTitulo("");
        setMensagem("");
        setAlunoSelecionado(null);
        setTipo("Aviso");
      } else {
        Alert.alert(
          "Erro",
          resposta?.error ||
            "Não foi possível enviar a notificação."
        );
      }
    } catch (error) {
      console.log(
        "Erro ao enviar:",
        error.response?.data ||
          error.message
      );

      Alert.alert(
        "Erro",
        error.response?.data?.error ||
          "Não foi possível enviar a notificação."
      );
    } finally {
      setEnviando(false);
    }
  }

  if (carregando) {
    return (
      <View style={styles.carregando}>
        <ActivityIndicator
          size="large"
          color="#FA2A55"
        />

        <Text>
          Carregando alunos...
        </Text>
      </View>
    );
  }

  return (
    <ScrollView
      style={styles.container}
      contentContainerStyle={
        styles.conteudo
      }
      showsVerticalScrollIndicator={
        false
      }
    >
      <Text style={styles.tituloPagina}>
        🔔 Enviar notificação
      </Text>

      <Text style={styles.label}>
        Selecione o aluno
      </Text>

      <View style={styles.listaAlunos}>
        {alunos.length === 0 ? (
          <Text style={styles.vazio}>
            Nenhum aluno encontrado.
          </Text>
        ) : (
          alunos.map((aluno) => {
            const selecionado =
              alunoSelecionado?.id_aluno ===
              aluno.id_aluno;

            return (
              <TouchableOpacity
                key={String(
                  aluno.id_aluno
                )}
                style={[
                  styles.aluno,
                  selecionado &&
                    styles.alunoSelecionado,
                ]}
                onPress={() =>
                  setAlunoSelecionado(
                    aluno
                  )
                }
              >
                <Text
                  style={[
                    styles.nomeAluno,
                    selecionado &&
                      styles.nomeAlunoSelecionado,
                  ]}
                >
                  {aluno.usuario}
                </Text>

                <Text
                  style={
                    styles.cpfAluno
                  }
                >
                  CPF: {aluno.cpf}
                </Text>
              </TouchableOpacity>
            );
          })
        )}
      </View>

      <Text style={styles.label}>
        Tipo da notificação
      </Text>

      <View style={styles.tipos}>
        {TIPOS.map((item) => {
          const selecionado =
            tipo === item.nome;

          return (
            <TouchableOpacity
              key={item.nome}
              style={[
                styles.tipoBotao,
                selecionado &&
                  styles.tipoSelecionado,
              ]}
              onPress={() =>
                selecionarTipo(
                  item.nome
                )
              }
            >
              <Text
                style={
                  styles.tipoIcone
                }
              >
                {item.icone}
              </Text>

              <Text
                style={[
                  styles.tipoTexto,
                  selecionado &&
                    styles.tipoTextoSelecionado,
                ]}
              >
                {item.nome}
              </Text>
            </TouchableOpacity>
          );
        })}
      </View>

      <Text style={styles.label}>
        Título
      </Text>

      <TextInput
        style={styles.input}
        placeholder="Título da notificação"
        value={titulo}
        onChangeText={setTitulo}
      />

      <Text style={styles.label}>
        Mensagem
      </Text>

      <TextInput
        style={[
          styles.input,
          styles.textarea,
        ]}
        placeholder="Digite a mensagem..."
        value={mensagem}
        onChangeText={setMensagem}
        multiline
        textAlignVertical="top"
      />

      <TouchableOpacity
        style={[
          styles.enviar,
          enviando &&
            styles.enviarDesativado,
        ]}
        onPress={enviar}
        disabled={enviando}
      >
        <Text
          style={styles.enviarTexto}
        >
          {enviando
            ? "Enviando..."
            : "Enviar notificação"}
        </Text>
      </TouchableOpacity>
    </ScrollView>
  );
}

const styles =
  StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor:
        "#F5F5F5",
    },

    conteudo: {
      padding: 15,
      paddingBottom: 40,
    },

    carregando: {
      flex: 1,
      justifyContent:
        "center",
      alignItems:
        "center",
      backgroundColor:
        "#F5F5F5",
    },

    tituloPagina: {
      fontSize: 26,
      fontWeight: "bold",
      color: "#222",
      marginBottom: 20,
    },

    label: {
      fontSize: 16,
      fontWeight: "bold",
      color: "#333",
      marginTop: 15,
      marginBottom: 8,
    },

    listaAlunos: {
      backgroundColor:
        "#fff",
      borderRadius: 12,
      padding: 8,
    },

    aluno: {
      padding: 14,
      borderRadius: 10,
      marginBottom: 5,
    },

    alunoSelecionado: {
      backgroundColor:
        "#FA2A55",
    },

    nomeAluno: {
      fontSize: 16,
      fontWeight: "bold",
      color: "#222",
    },

    nomeAlunoSelecionado: {
      color: "#fff",
    },

    cpfAluno: {
      fontSize: 13,
      color: "#777",
      marginTop: 3,
    },

    tipos: {
      flexDirection:
        "row",
      flexWrap:
        "wrap",
      gap: 8,
    },

    tipoBotao: {
      backgroundColor:
        "#fff",
      borderRadius: 12,
      paddingVertical: 12,
      paddingHorizontal: 14,
      alignItems:
        "center",
      minWidth: 100,
      borderWidth: 1,
      borderColor:
        "#ddd",
    },

    tipoSelecionado: {
      backgroundColor:
        "#FA2A55",
      borderColor:
        "#FA2A55",
    },

    tipoIcone: {
      fontSize: 23,
      marginBottom: 4,
    },

    tipoTexto: {
      fontSize: 13,
      color: "#444",
      fontWeight: "600",
    },

    tipoTextoSelecionado: {
      color: "#fff",
    },

    input: {
      backgroundColor:
        "#fff",
      borderRadius: 12,
      padding: 15,
      fontSize: 16,
      borderWidth: 1,
      borderColor:
        "#ddd",
    },

    textarea: {
      height: 130,
    },

    enviar: {
      backgroundColor:
        "#FA2A55",
      borderRadius: 12,
      padding: 16,
      alignItems:
        "center",
      marginTop: 25,
    },

    enviarDesativado: {
      opacity: 0.6,
    },

    enviarTexto: {
      color: "#fff",
      fontSize: 17,
      fontWeight: "bold",
    },

    vazio: {
      textAlign:
        "center",
      padding: 20,
      color: "#777",
    },
  });