import React, { useCallback, useEffect, useState } from "react";
import {
  ScrollView,
  View,
  Text,
  StyleSheet,
  TouchableOpacity,
  ActivityIndicator,
} from "react-native";
import { useFocusEffect } from "@react-navigation/native";
import { Ionicons } from "@expo/vector-icons";
import { getAulas } from "../../services/aulaService";
import { getNotificacoes } from "../../services/notificacaoService";

export default function AlunoHome({ navigation, route }) {
  const idAluno = Number(route?.params?.id_aluno || 0);

  const [aulas, setAulas] = useState([]);
  const [naoLidas, setNaoLidas] = useState(0);
  const [carregando, setCarregando] = useState(true);

  const carregar = useCallback(async () => {
    if (idAluno <= 0) {
      setAulas([]);
      setCarregando(false);
      return;
    }

    try {
      setCarregando(true);

      const dados = await getAulas(idAluno, 0);
      const lista = Array.isArray(dados) ? dados : [];

      const hoje = new Date().getDay();
      const idDiaHoje = hoje === 0 ? 7 : hoje;

      const aulasHoje = lista.filter(
        (aula) => Number(aula.id_dia) === idDiaHoje
      );

      setAulas(aulasHoje);
    } catch (error) {
      console.log(
        "Erro ao carregar aula do dia:",
        error.response?.data || error.message
      );
      setAulas([]);
    } finally {
      setCarregando(false);
    }
  }, [idAluno]);

  const carregarNotificacoes = useCallback(async () => {
    if (idAluno <= 0) return;

    try {
      const dados = await getNotificacoes(idAluno);

      const lista = Array.isArray(dados) ? dados : [];

      setNaoLidas(
        lista.filter((item) => Number(item.lida) === 0).length
      );
    } catch (error) {
      console.log(
        "Erro nas notificações:",
        error.response?.data || error.message
      );
    }
  }, [idAluno]);

  useEffect(() => {
    carregar();
    carregarNotificacoes();
  }, [carregar, carregarNotificacoes]);

  useFocusEffect(
    useCallback(() => {
      carregar();
      carregarNotificacoes();
    }, [carregar, carregarNotificacoes])
  );

  function abrirNotificacoes() {
    navigation.navigate("Notificações", {
      id_aluno: idAluno,
    });
  }

  function abrirHorarios() {
    navigation.navigate("Horários", {
      id_aluno: idAluno,
    });
  }

  function abrirPresenca() {
    navigation.navigate("Presença", {
      id_aluno: idAluno,
    });
  }

  return (
    <ScrollView
      style={styles.container}
      contentContainerStyle={styles.content}
      showsVerticalScrollIndicator={false}
    >
      <View style={styles.topo}>
        <View style={styles.saude}>
          <Text style={styles.pequeno}>BEM-VINDO AO</Text>
          <Text style={styles.logo}>SportCorp</Text>
          <Text style={styles.descricao}>
            Sua rotina de vôlei em um só lugar.
          </Text>
        </View>

        <TouchableOpacity
          style={styles.botaoNotificacao}
          onPress={abrirNotificacoes}
          activeOpacity={0.8}
        >
          <Ionicons
            name="notifications-outline"
            size={25}
            color="#FA2A55"
          />

          {naoLidas > 0 && (
            <View style={styles.badge}>
              <Text style={styles.badgeTexto}>
                {naoLidas > 9 ? "9+" : naoLidas}
              </Text>
            </View>
          )}
        </TouchableOpacity>
      </View>

      <View style={styles.banner}>
        <View style={styles.bannerTexto}>
          <Text style={styles.bannerPequeno}>ÁREA DO ALUNO</Text>

          <Text style={styles.bannerTitulo}>
            Olá! 👋
          </Text>

          <Text style={styles.bannerDescricao}>
            Confira sua aula de hoje e acompanhe sua rotina.
          </Text>
        </View>

        <View style={styles.bannerIcone}>
          <Ionicons
            name="football-outline"
            size={48}
            color="#FFFFFF"
          />
        </View>
      </View>

      <View style={styles.tituloSecao}>
        <View>
          <Text style={styles.tituloSecaoPrincipal}>
            Aula do dia
          </Text>

          <Text style={styles.tituloSecaoSub}>
            Confira seus compromissos de hoje
          </Text>
        </View>

        <View style={styles.iconeSecao}>
          <Ionicons
            name="calendar-outline"
            size={22}
            color="#FA2A55"
          />
        </View>
      </View>

      {carregando ? (
        <View style={styles.loadingBox}>
          <ActivityIndicator
            size="large"
            color="#FA2A55"
          />

          <Text style={styles.loadingTexto}>
            Carregando suas aulas...
          </Text>
        </View>
      ) : aulas.length === 0 ? (
        <View style={styles.vazio}>
          <View style={styles.vazioIcone}>
            <Ionicons
              name="calendar-clear-outline"
              size={42}
              color="#FA2A55"
            />
          </View>

          <Text style={styles.vazioTitulo}>
            Nenhuma aula hoje
          </Text>

          <Text style={styles.vazioTexto}>
            Você não possui aulas programadas para hoje.
            Consulte seus horários para visualizar sua programação.
          </Text>

          <TouchableOpacity
            style={styles.botaoVazio}
            onPress={abrirHorarios}
            activeOpacity={0.8}
          >
            <Text style={styles.botaoVazioTexto}>
              Ver meus horários
            </Text>

            <Ionicons
              name="arrow-forward"
              size={18}
              color="#FFFFFF"
            />
          </TouchableOpacity>
        </View>
      ) : (
        aulas.map((aula) => (
          <View
            key={String(aula.id_horario)}
            style={styles.cardAula}
          >
            <View style={styles.cardTopo}>
              <View style={styles.modalidadeIcone}>
                <Ionicons
                  name="football-outline"
                  size={27}
                  color="#FA2A55"
                />
              </View>

              <View style={styles.modalidadeArea}>
                <Text style={styles.cardLabel}>
                  MODALIDADE
                </Text>

                <Text style={styles.cardTitle}>
                  {aula.modalidade || "Vôlei"}
                </Text>
              </View>
            </View>

            <View style={styles.linha} />

            <View style={styles.informacoes}>
              <View style={styles.infoItem}>
                <Ionicons
                  name="time-outline"
                  size={21}
                  color="#FA2A55"
                />

                <View>
                  <Text style={styles.infoLabel}>
                    HORÁRIO
                  </Text>

                  <Text style={styles.infoTexto}>
                    {String(aula.hora_inicio || "").substring(0, 5)}
                    {" - "}
                    {String(aula.hora_fim || "").substring(0, 5)}
                  </Text>
                </View>
              </View>

              <View style={styles.infoItem}>
                <Ionicons
                  name="person-outline"
                  size={21}
                  color="#FA2A55"
                />

                <View>
                  <Text style={styles.infoLabel}>
                    PROFESSOR
                  </Text>

                  <Text style={styles.infoTexto}>
                    {aula.professor || "Não informado"}
                  </Text>
                </View>
              </View>

              <View style={styles.infoItem}>
                <Ionicons
                  name="sunny-outline"
                  size={21}
                  color="#FA2A55"
                />

                <View>
                  <Text style={styles.infoLabel}>
                    TURNO
                  </Text>

                  <Text style={styles.infoTexto}>
                    {aula.turno || "Não informado"}
                  </Text>
                </View>
              </View>
            </View>
          </View>
        ))
      )}

      <Text style={styles.atalhosTitulo}>
        Acesso rápido
      </Text>

      <View style={styles.atalhos}>
        <TouchableOpacity
          style={styles.atalho}
          onPress={abrirHorarios}
          activeOpacity={0.8}
        >
          <View style={styles.atalhoIcone}>
            <Ionicons
              name="calendar-outline"
              size={25}
              color="#FA2A55"
            />
          </View>

          <Text style={styles.atalhoTitulo}>
            Horários
          </Text>

          <Text style={styles.atalhoDescricao}>
            Veja sua programação
          </Text>
        </TouchableOpacity>

        <TouchableOpacity
          style={styles.atalho}
          onPress={abrirPresenca}
          activeOpacity={0.8}
        >
          <View style={styles.atalhoIcone}>
            <Ionicons
              name="checkmark-circle-outline"
              size={25}
              color="#FA2A55"
            />
          </View>

          <Text style={styles.atalhoTitulo}>
            Presença
          </Text>

          <Text style={styles.atalhoDescricao}>
            Acompanhe sua frequência
          </Text>
        </TouchableOpacity>

        <TouchableOpacity
          style={styles.atalho}
          onPress={abrirNotificacoes}
          activeOpacity={0.8}
        >
          <View style={styles.atalhoIcone}>
            <Ionicons
              name="notifications-outline"
              size={25}
              color="#FA2A55"
            />
          </View>

          <Text style={styles.atalhoTitulo}>
            Avisos
          </Text>

          <Text style={styles.atalhoDescricao}>
            Confira suas notificações
          </Text>
        </TouchableOpacity>
      </View>

      <View style={styles.rodape}>
        <Text style={styles.rodapeTexto}>
          SportCorp • Gestão de Escolas de Vôlei
        </Text>
      </View>
    </ScrollView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#F7F7F7",
  },

  content: {
    padding: 18,
    paddingBottom: 35,
  },

  topo: {
    flexDirection: "row",
    justifyContent: "space-between",
    alignItems: "center",
    marginBottom: 20,
  },

  saude: {
    flex: 1,
  },

  pequeno: {
    fontSize: 11,
    fontWeight: "700",
    color: "#888888",
    letterSpacing: 1,
  },

  logo: {
    fontSize: 28,
    fontWeight: "900",
    color: "#FA2A55",
    marginTop: 2,
  },

  descricao: {
    fontSize: 13,
    color: "#777777",
    marginTop: 2,
  },

  botaoNotificacao: {
    width: 50,
    height: 50,
    borderRadius: 16,
    backgroundColor: "#FFFFFF",
    alignItems: "center",
    justifyContent: "center",
    elevation: 4,
    shadowOpacity: 0.08,
    shadowRadius: 8,
    shadowOffset: {
      width: 0,
      height: 3,
    },
  },

  badge: {
    position: "absolute",
    right: -3,
    top: -4,
    minWidth: 21,
    height: 21,
    borderRadius: 11,
    paddingHorizontal: 5,
    backgroundColor: "#FA2A55",
    justifyContent: "center",
    alignItems: "center",
    borderWidth: 2,
    borderColor: "#FFFFFF",
  },

  badgeTexto: {
    color: "#FFFFFF",
    fontSize: 10,
    fontWeight: "800",
  },

  banner: {
    minHeight: 145,
    backgroundColor: "#FA2A55",
    borderRadius: 24,
    padding: 22,
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
    marginBottom: 26,
    elevation: 5,
    shadowOpacity: 0.18,
    shadowRadius: 10,
    shadowOffset: {
      width: 0,
      height: 5,
    },
  },

  bannerTexto: {
    flex: 1,
    paddingRight: 10,
  },

  bannerPequeno: {
    color: "#FFE6EC",
    fontSize: 10,
    fontWeight: "800",
    letterSpacing: 1,
  },

  bannerTitulo: {
    color: "#FFFFFF",
    fontSize: 30,
    fontWeight: "900",
    marginTop: 5,
  },

  bannerDescricao: {
    color: "#FFFFFF",
    fontSize: 13,
    lineHeight: 19,
    marginTop: 5,
    opacity: 0.92,
  },

  bannerIcone: {
    width: 75,
    height: 75,
    borderRadius: 38,
    backgroundColor: "rgba(255,255,255,0.15)",
    alignItems: "center",
    justifyContent: "center",
  },

  tituloSecao: {
    flexDirection: "row",
    justifyContent: "space-between",
    alignItems: "center",
    marginBottom: 13,
  },

  tituloSecaoPrincipal: {
    fontSize: 22,
    fontWeight: "800",
    color: "#202020",
  },

  tituloSecaoSub: {
    fontSize: 12,
    color: "#888888",
    marginTop: 3,
  },

  iconeSecao: {
    width: 43,
    height: 43,
    borderRadius: 14,
    backgroundColor: "#FFF0F4",
    justifyContent: "center",
    alignItems: "center",
  },

  loadingBox: {
    backgroundColor: "#FFFFFF",
    borderRadius: 20,
    padding: 35,
    alignItems: "center",
    justifyContent: "center",
    elevation: 3,
  },

  loadingTexto: {
    color: "#777777",
    marginTop: 12,
    fontSize: 13,
  },

  vazio: {
    backgroundColor: "#FFFFFF",
    borderRadius: 22,
    padding: 25,
    alignItems: "center",
    elevation: 3,
  },

  vazioIcone: {
    width: 78,
    height: 78,
    borderRadius: 39,
    backgroundColor: "#FFF0F4",
    justifyContent: "center",
    alignItems: "center",
    marginBottom: 14,
  },

  vazioTitulo: {
    fontSize: 19,
    fontWeight: "800",
    color: "#222222",
  },

  vazioTexto: {
    color: "#777777",
    textAlign: "center",
    lineHeight: 19,
    fontSize: 13,
    marginTop: 7,
  },

  botaoVazio: {
    marginTop: 18,
    backgroundColor: "#FA2A55",
    borderRadius: 13,
    paddingVertical: 12,
    paddingHorizontal: 18,
    flexDirection: "row",
    alignItems: "center",
    gap: 8,
  },

  botaoVazioTexto: {
    color: "#FFFFFF",
    fontWeight: "700",
    fontSize: 13,
  },

  cardAula: {
    backgroundColor: "#FFFFFF",
    borderRadius: 22,
    padding: 20,
    marginBottom: 18,
    elevation: 4,
    shadowOpacity: 0.08,
    shadowRadius: 9,
    shadowOffset: {
      width: 0,
      height: 4,
    },
    borderLeftWidth: 5,
    borderLeftColor: "#FA2A55",
  },

  cardTopo: {
    flexDirection: "row",
    alignItems: "center",
  },

  modalidadeIcone: {
    width: 55,
    height: 55,
    borderRadius: 17,
    backgroundColor: "#FFF0F4",
    alignItems: "center",
    justifyContent: "center",
  },

  modalidadeArea: {
    marginLeft: 13,
  },

  cardLabel: {
    color: "#999999",
    fontSize: 9,
    fontWeight: "800",
    letterSpacing: 1,
  },

  cardTitle: {
    color: "#FA2A55",
    fontSize: 22,
    fontWeight: "900",
    marginTop: 2,
  },

  linha: {
    height: 1,
    backgroundColor: "#EEEEEE",
    marginVertical: 17,
  },

  informacoes: {
    gap: 15,
  },

  infoItem: {
    flexDirection: "row",
    alignItems: "center",
  },

  infoLabel: {
    fontSize: 9,
    color: "#999999",
    fontWeight: "800",
    letterSpacing: 0.7,
  },

  infoTexto: {
    fontSize: 14,
    color: "#333333",
    fontWeight: "600",
    marginTop: 1,
  },

  atalhoTitulo: {
    fontSize: 21,
    fontWeight: "800",
    color: "#202020",
    marginTop: 10,
    marginBottom: 13,
  },

  atalhos: {
    gap: 12,
  },

  atalho: {
    backgroundColor: "#FFFFFF",
    borderRadius: 18,
    padding: 17,
    minHeight: 82,
    elevation: 3,
    flexDirection: "row",
    alignItems: "center",
  },

  atalhoIcone: {
    width: 49,
    height: 49,
    borderRadius: 15,
    backgroundColor: "#FFF0F4",
    alignItems: "center",
    justifyContent: "center",
    marginRight: 14,
  },

  atalhoTitulo: {
    fontSize: 15,
    fontWeight: "800",
    color: "#222222",
    marginBottom: 2,
  },

  atalhoDescricao: {
    fontSize: 12,
    color: "#888888",
  },

  rodape: {
    alignItems: "center",
    marginTop: 30,
  },

  rodapeTexto: {
    color: "#AAAAAA",
    fontSize: 11,
  },
});