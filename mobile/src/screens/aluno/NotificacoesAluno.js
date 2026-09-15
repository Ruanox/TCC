import React, {
  useCallback,
  useState,
} from "react";

import {
  View,
  Text,
  FlatList,
  StyleSheet,
  ActivityIndicator,
  TouchableOpacity,
  RefreshControl,
} from "react-native";

import {
  useFocusEffect,
} from "@react-navigation/native";

import {
  getNotificacoes,
  marcarNotificacaoComoLida,
} from "../../services/notificacaoService";

export default function NotificacoesAluno({ route }) {
  const idAluno = Number(
    route?.params?.id_aluno || 0
  );

  const [
    notificacoes,
    setNotificacoes,
  ] = useState([]);

  const [
    carregando,
    setCarregando,
  ] = useState(true);

  const [
    atualizando,
    setAtualizando,
  ] = useState(false);

  const carregarNotificacoes =
    useCallback(
      async (refresh = false) => {
        if (!idAluno) {
          setCarregando(false);
          return;
        }

        try {
          if (refresh) {
            setAtualizando(true);
          } else {
            setCarregando(true);
          }

          const dados =
            await getNotificacoes(idAluno);

          setNotificacoes(
            Array.isArray(dados)
              ? dados
              : []
          );
        } catch (error) {
          console.log(
            "Erro ao carregar notificações:",
            error.response?.data ||
              error.message
          );

          setNotificacoes([]);
        } finally {
          setCarregando(false);
          setAtualizando(false);
        }
      },
      [idAluno]
    );

  useFocusEffect(
    useCallback(() => {
      carregarNotificacoes();
    }, [carregarNotificacoes])
  );

  async function abrirNotificacao(
    notificacao
  ) {
    if (
      Number(notificacao.lida) === 1
    ) {
      return;
    }

    try {
      await marcarNotificacaoComoLida(
        notificacao.id_notificacao,
        idAluno
      );

      setNotificacoes((lista) =>
        lista.map((item) =>
          item.id_notificacao ===
          notificacao.id_notificacao
            ? {
                ...item,
                lida: 1,
              }
            : item
        )
      );
    } catch (error) {
      console.log(
        "Erro ao marcar notificação:",
        error.response?.data ||
          error.message
      );
    }
  }

  function iconeTipo(tipo) {
    switch (tipo) {
      case "Aula":
        return "🏐";

      case "Cancelamento":
        return "❌";

      case "Alteração":
        return "🔄";

      case "Campeonato":
        return "🏆";

      default:
        return "📢";
    }
  }

  function renderItem({ item }) {
    const naoLida =
      Number(item.lida) === 0;

    return (
      <TouchableOpacity
        style={[
          styles.card,
          naoLida &&
            styles.cardNaoLido,
        ]}
        onPress={() =>
          abrirNotificacao(item)
        }
      >
        <View style={styles.topo}>
          <Text style={styles.icone}>
            {iconeTipo(item.tipo)}
          </Text>

          <View
            style={
              styles.tituloContainer
            }
          >
            <Text
              style={[
                styles.titulo,
                naoLida &&
                  styles.tituloNaoLido,
              ]}
            >
              {item.titulo}
            </Text>

            <Text style={styles.tipo}>
              {item.tipo}
            </Text>
          </View>

          {naoLida && (
            <View style={styles.ponto} />
          )}
        </View>

        <Text style={styles.mensagem}>
          {item.mensagem}
        </Text>

        {item.professor && (
          <Text style={styles.professor}>
            Enviado por:{" "}
            {item.professor}
          </Text>
        )}

        <Text style={styles.data}>
          {item.data_envio}
        </Text>
      </TouchableOpacity>
    );
  }

  if (carregando) {
    return (
      <View style={styles.carregando}>
        <ActivityIndicator
          size="large"
          color="#FA2A55"
        />

        <Text
          style={
            styles.textoCarregando
          }
        >
          Carregando notificações...
        </Text>
      </View>
    );
  }

  return (
    <View style={styles.container}>
      <Text style={styles.header}>
        🔔 Notificações
      </Text>

      <FlatList
        data={notificacoes}
        keyExtractor={(item) =>
          String(
            item.id_notificacao
          )
        }
        renderItem={renderItem}
        refreshControl={
          <RefreshControl
            refreshing={atualizando}
            onRefresh={() =>
              carregarNotificacoes(true)
            }
          />
        }
        ListEmptyComponent={
          <View
            style={
              styles.vazioContainer
            }
          >
            <Text
              style={
                styles.vazioIcone
              }
            >
              🔕
            </Text>

            <Text style={styles.vazio}>
              Nenhuma notificação.
            </Text>

            <Text
              style={
                styles.vazioDescricao
              }
            >
              Quando houver avisos sobre
              aulas, campeonatos ou outros
              comunicados, eles aparecerão
              aqui.
            </Text>
          </View>
        }
        showsVerticalScrollIndicator={
          false
        }
      />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#F5F5F5",
    padding: 15,
  },

  carregando: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    backgroundColor: "#F5F5F5",
  },

  textoCarregando: {
    marginTop: 10,
    fontSize: 16,
  },

  header: {
    fontSize: 28,
    fontWeight: "bold",
    marginBottom: 20,
    color: "#222",
  },

  card: {
    backgroundColor: "#fff",
    borderRadius: 15,
    padding: 18,
    marginBottom: 12,
    elevation: 3,
  },

  cardNaoLido: {
    borderLeftWidth: 5,
    borderLeftColor: "#FA2A55",
  },

  topo: {
    flexDirection: "row",
    alignItems: "center",
    marginBottom: 12,
  },

  icone: {
    fontSize: 28,
    marginRight: 12,
  },

  tituloContainer: {
    flex: 1,
  },

  titulo: {
    fontSize: 18,
    fontWeight: "600",
    color: "#222",
  },

  tituloNaoLido: {
    fontWeight: "bold",
  },

  tipo: {
    marginTop: 3,
    color: "#FA2A55",
    fontSize: 13,
  },

  ponto: {
    width: 10,
    height: 10,
    borderRadius: 5,
    backgroundColor: "#FA2A55",
  },

  mensagem: {
    fontSize: 16,
    lineHeight: 23,
    color: "#444",
    marginBottom: 12,
  },

  professor: {
    fontSize: 13,
    color: "#666",
    marginBottom: 5,
  },

  data: {
    fontSize: 12,
    color: "#999",
  },

  vazioContainer: {
    alignItems: "center",
    padding: 30,
  },

  vazioIcone: {
    fontSize: 45,
    marginBottom: 15,
  },

  vazio: {
    fontSize: 18,
    fontWeight: "bold",
    color: "#555",
  },

  vazioDescricao: {
    textAlign: "center",
    marginTop: 10,
    color: "#888",
    lineHeight: 20,
  },
});