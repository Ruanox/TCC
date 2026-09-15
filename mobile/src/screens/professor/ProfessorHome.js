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

export default function ProfessorHome({ navigation, route }) {
  const idProfessor = Number(route?.params?.id_professor || 0);

  const [aulas, setAulas] = useState([]);
  const [carregando, setCarregando] = useState(true);

  const carregar = useCallback(async () => {
    try {
      setCarregando(true);

      const data = await getAulas(0, idProfessor);

      const lista = Array.isArray(data) ? data : [];

      const hoje = new Date().getDay();
      const idDiaHoje = hoje === 0 ? 7 : hoje;

      const aulasHoje = lista.filter(
        (aula) => Number(aula.id_dia) === idDiaHoje
      );

      setAulas(aulasHoje);
    } catch (error) {
      console.log(
        "Erro ao carregar aulas:",
        error.response?.data || error.message
      );

      setAulas([]);
    } finally {
      setCarregando(false);
    }
  }, [idProfessor]);

  useEffect(() => {
    carregar();
  }, [carregar]);

  useFocusEffect(
    useCallback(() => {
      carregar();
    }, [carregar])
  );

  function abrirChamada() {
    navigation.navigate("Chamada", {
      id_professor: idProfessor,
    });
  }

  function abrirAlunos() {
    navigation.navigate("Alunos", {
      id_professor: idProfessor,
    });
  }

  function abrirHorarios() {
    navigation.navigate("Horários", {
      id_professor: idProfessor,
    });
  }

  function abrirNotificacoes() {
    navigation.navigate("Notificações", {
      id_professor: idProfessor,
    });
  }

  return (
    <ScrollView
      style={styles.container}
      contentContainerStyle={styles.content}
      showsVerticalScrollIndicator={false}
    >
      <View style={styles.topo}>
        <View>
          <Text style={styles.pequeno}>
            ÁREA DO PROFESSOR
          </Text>

          <Text style={styles.logo}>
            SportCorp
          </Text>

          <Text style={styles.descricao}>
            Gerencie suas aulas e alunos.
          </Text>
        </View>

        <TouchableOpacity
          style={styles.iconeTopo}
          onPress={abrirNotificacoes}
          activeOpacity={0.8}
        >
          <Ionicons
            name="notifications-outline"
            size={25}
            color="#FA2A55"
          />
        </TouchableOpacity>
      </View>

      <View style={styles.banner}>
        <View style={styles.bannerTexto}>
          <Text style={styles.bannerPequeno}>
            PAINEL DO PROFESSOR
          </Text>

          <Text style={styles.bannerTitulo}>
            Olá, Professor! 👋
          </Text>

          <Text style={styles.bannerDescricao}>
            Acompanhe suas aulas, alunos e chamadas.
          </Text>
        </View>

        <View style={styles.bannerIcone}>
          <Ionicons
            name="school-outline"
            size={48}
            color="#FFFFFF"
          />
        </View>
      </View>

      <View style={styles.resumo}>
        <View style={styles.resumoCard}>
          <View style={styles.resumoIcone}>
            <Ionicons
              name="calendar-outline"
              size={23}
              color="#FA2A55"
            />
          </View>

          <Text style={styles.resumoNumero}>
            {aulas.length}
          </Text>

          <Text style={styles.resumoTexto}>
            Aula{aulas.length !== 1 ? "s" : ""} hoje
          </Text>
        </View>

        <View style={styles.resumoCard}>
          <View style={styles.resumoIcone}>
            <Ionicons
              name="person-outline"
              size={23}
              color="#FA2A55"
            />
          </View>

          <Text style={styles.resumoNumero}>
            —
          </Text>

          <Text style={styles.resumoTexto}>
            Alunos
          </Text>
        </View>
      </View>

      <View style={styles.tituloSecao}>
        <View>
          <Text style={styles.tituloSecaoPrincipal}>
            Aulas de hoje
          </Text>

          <Text style={styles.tituloSecaoSub}>
            Sua programação para hoje
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
            Não existem aulas programadas para você hoje.
            Acesse horários para consultar toda a programação.
          </Text>

          <TouchableOpacity
            style={styles.botaoVazio}
            onPress={abrirHorarios}
            activeOpacity={0.8}
          >
            <Text style={styles.botaoVazioTexto}>
              Ver horários
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
                  name="people-outline"
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

              <View style={styles.infoItem}>
                <Ionicons
                  name="calendar-outline"
                  size={21}
                  color="#FA2A55"
                />

                <View>
                  <Text style={styles.infoLabel}>
                    DIA
                  </Text>

                  <Text style={styles.infoTexto}>
                    {aula.dia_semana || "Não informado"}
                  </Text>
                </View>
              </View>
            </View>

            <TouchableOpacity
              style={styles.botaoChamada}
              onPress={abrirChamada}
              activeOpacity={0.8}
            >
              <Ionicons
                name="clipboard-outline"
                size={19}
                color="#FFFFFF"
              />

              <Text style={styles.botaoChamadaTexto}>
                Fazer chamada
              </Text>
            </TouchableOpacity>
          </View>
        ))
      )}

      <Text style={styles.atalhosTitulo}>
        Acesso rápido
      </Text>

      <View style={styles.atalhos}>
        <TouchableOpacity
          style={styles.atalho}
          onPress={abrirChamada}
          activeOpacity={0.8}
        >
          <View style={styles.atalhoIcone}>
            <Ionicons
              name="clipboard-outline"
              size={25}
              color="#FA2A55"
            />
          </View>

          <View style={styles.atalhoTexto}>
            <Text style={styles.atalhoTitulo}>
              Chamada
            </Text>

            <Text style={styles.atalhoDescricao}>
              Registre a presença dos alunos
            </Text>
          </View>

          <Ionicons
            name="chevron-forward"
            size={20}
            color="#BBBBBB"
          />
        </TouchableOpacity>

        <TouchableOpacity
          style={styles.atalho}
          onPress={abrirAlunos}
          activeOpacity={0.8}
        >
          <View style={styles.atalhoIcone}>
            <Ionicons
              name="people-outline"
              size={25}
              color="#FA2A55"
            />
          </View>

          <View style={styles.atalhoTexto}>
            <Text style={styles.atalhoTitulo}>
              Alunos
            </Text>

            <Text style={styles.atalhoDescricao}>
              Consulte seus alunos
            </Text>
          </View>

          <Ionicons
            name="chevron-forward"
            size={20}
            color="#BBBBBB"
          />
        </TouchableOpacity>

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

          <View style={styles.atalhoTexto}>
            <Text style={styles.atalhoTitulo}>
              Horários
            </Text>

            <Text style={styles.atalhoDescricao}>
              Consulte e altere seus horários
            </Text>
          </View>

          <Ionicons
            name="chevron-forward"
            size={20}
            color="#BBBBBB"
          />
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

          <View style={styles.atalhoTexto}>
            <Text style={styles.atalhoTitulo}>
              Notificações
            </Text>

            <Text style={styles.atalhoDescricao}>
              Veja seus avisos
            </Text>
          </View>

          <Ionicons
            name="chevron-forward"
            size={20}
            color="#BBBBBB"
          />
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

  pequeno: {
    fontSize: 10,
    fontWeight: "800",
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

  iconeTopo: {
    width: 50,
    height: 50,
    borderRadius: 16,
    backgroundColor: "#FFFFFF",
    justifyContent: "center",
    alignItems: "center",
    elevation: 4,
    shadowOpacity: 0.08,
    shadowRadius: 8,
    shadowOffset: {
      width: 0,
      height: 3,
    },
  },

  banner: {
    minHeight: 145,
    backgroundColor: "#FA2A55",
    borderRadius: 24,
    padding: 22,
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
    marginBottom: 20,
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
    fontSize: 28,
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
    justifyContent: "center",
    alignItems: "center",
  },

  resumo: {
    flexDirection: "row",
    gap: 12,
    marginBottom: 25,
  },

  resumoCard: {
    flex: 1,
    backgroundColor: "#FFFFFF",
    borderRadius: 18,
    padding: 15,
    elevation: 3,
    shadowOpacity: 0.06,
    shadowRadius: 8,
    shadowOffset: {
      width: 0,
      height: 3,
    },
  },

  resumoIcone: {
    width: 43,
    height: 43,
    borderRadius: 14,
    backgroundColor: "#FFF0F4",
    alignItems: "center",
    justifyContent: "center",
    marginBottom: 8,
  },

  resumoNumero: {
    fontSize: 23,
    fontWeight: "900",
    color: "#222222",
  },

  resumoTexto: {
    fontSize: 11,
    color: "#888888",
    marginTop: 1,
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
    borderLeftWidth: 5,
    borderLeftColor: "#FA2A55",
    elevation: 4,
    shadowOpacity: 0.08,
    shadowRadius: 9,
    shadowOffset: {
      width: 0,
      height: 4,
    },
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
    justifyContent: "center",
    alignItems: "center",
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

  botaoChamada: {
    backgroundColor: "#FA2A55",
    borderRadius: 13,
    paddingVertical: 12,
    justifyContent: "center",
    alignItems: "center",
    flexDirection: "row",
    gap: 8,
    marginTop: 18,
  },

  botaoChamadaTexto: {
    color: "#FFFFFF",
    fontSize: 13,
    fontWeight: "800",
  },

  atalhosTitulo: {
    fontSize: 21,
    fontWeight: "800",
    color: "#202020",
    marginTop: 8,
    marginBottom: 13,
  },

  atalhos: {
    gap: 12,
  },

  atalho: {
    backgroundColor: "#FFFFFF",
    borderRadius: 18,
    padding: 16,
    minHeight: 80,
    flexDirection: "row",
    alignItems: "center",
    elevation: 3,
    shadowOpacity: 0.06,
    shadowRadius: 8,
    shadowOffset: {
      width: 0,
      height: 3,
    },
  },

  atalhoIcone: {
    width: 49,
    height: 49,
    borderRadius: 15,
    backgroundColor: "#FFF0F4",
    justifyContent: "center",
    alignItems: "center",
    marginRight: 13,
  },

  atalhoTexto: {
    flex: 1,
  },

  atalhoTitulo: {
    fontSize: 15,
    fontWeight: "800",
    color: "#222222",
  },

  atalhoDescricao: {
    fontSize: 12,
    color: "#888888",
    marginTop: 3,
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