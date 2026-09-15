import React, { useState } from "react";
import {
  View,
  Text,
  TextInput,
  TouchableOpacity,
  StyleSheet,
  KeyboardAvoidingView,
  Platform,
  ScrollView,
  ActivityIndicator,
} from "react-native";
import { Ionicons } from "@expo/vector-icons";
import { login } from "../services/authService";

export default function LoginScreen({ navigation }) {
  const [cpf, setCpf] = useState("");
  const [senha, setSenha] = useState("");
  const [mostrarSenha, setMostrarSenha] = useState(false);
  const [carregando, setCarregando] = useState(false);
  const [erro, setErro] = useState("");

  function formatarCPF(valor) {
    const numeros = valor.replace(/\D/g, "").slice(0, 11);

    if (numeros.length <= 3) {
      return numeros;
    }

    if (numeros.length <= 6) {
      return `${numeros.slice(0, 3)}.${numeros.slice(3)}`;
    }

    if (numeros.length <= 9) {
      return `${numeros.slice(0, 3)}.${numeros.slice(3, 6)}.${numeros.slice(
        6
      )}`;
    }

    return `${numeros.slice(0, 3)}.${numeros.slice(3, 6)}.${numeros.slice(
      6,
      9
    )}-${numeros.slice(9)}`;
  }

  async function realizarLogin() {
    setErro("");

    const cpfLimpo = cpf.replace(/\D/g, "");

    if (!cpfLimpo) {
      setErro("Digite seu CPF.");
      return;
    }

    if (cpfLimpo.length !== 11) {
      setErro("Digite um CPF válido.");
      return;
    }

    if (!senha.trim()) {
      setErro("Digite sua senha.");
      return;
    }

    try {
      setCarregando(true);

      const resposta = await login(cpfLimpo, senha);

      console.log("RESPOSTA DO LOGIN:", resposta);

      if (!resposta) {
        setErro("Não foi possível realizar o login.");
        return;
      }

      if (
        resposta.success === false ||
        resposta.erro ||
        resposta.error
      ) {
        setErro(
          resposta.erro ||
            resposta.error ||
            "CPF ou senha incorretos."
        );
        return;
      }

      const tipo = String(
        resposta.tipo ||
          resposta.tipo_usuario ||
          resposta.usuario ||
          resposta.perfil ||
          ""
      ).toLowerCase();

      if (
        tipo.includes("professor") ||
        tipo.includes("prof") ||
        resposta.id_professor
      ) {
        navigation.replace("Professor", {
          id_professor:
            resposta.id_professor || resposta.id,
        });

        return;
      }

      if (
        tipo.includes("aluno") ||
        resposta.id_aluno
      ) {
        navigation.replace("Aluno", {
          id_aluno:
            resposta.id_aluno || resposta.id,
        });

        return;
      }

      setErro("Tipo de usuário não identificado.");
    } catch (error) {
      console.log(
        "ERRO NO LOGIN:",
        error.response?.data || error.message
      );

      const mensagem =
        error.response?.data?.erro ||
        error.response?.data?.error ||
        error.response?.data?.message;

      setErro(
        mensagem || "Não foi possível conectar ao servidor."
      );
    } finally {
      setCarregando(false);
    }
  }

  return (
    <KeyboardAvoidingView
      style={styles.container}
      behavior={Platform.OS === "ios" ? "padding" : undefined}
    >
      <ScrollView
        contentContainerStyle={styles.scroll}
        keyboardShouldPersistTaps="handled"
        showsVerticalScrollIndicator={false}
      >
        <View style={styles.topo}>
          <View style={styles.logoCirculo}>
            <Ionicons
              name="football-outline"
              size={42}
              color="#FFFFFF"
            />
          </View>

          <Text style={styles.logo}>
            SportCorp
          </Text>

          <Text style={styles.slogan}>
            Gestão de escolas de vôlei
          </Text>
        </View>

        <View style={styles.card}>
          <Text style={styles.titulo}>
            Bem-vindo!
          </Text>

          <Text style={styles.subtitulo}>
            Entre com seus dados para acessar sua conta.
          </Text>

          <View style={styles.campoContainer}>
            <Text style={styles.label}>
              CPF
            </Text>

            <View
              style={[
                styles.inputContainer,
                erro && !cpf ? styles.inputErro : null,
              ]}
            >
              <Ionicons
                name="person-outline"
                size={21}
                color="#FA2A55"
              />

              <TextInput
                style={styles.input}
                value={cpf}
                onChangeText={(valor) => {
                  setCpf(formatarCPF(valor));
                  setErro("");
                }}
                placeholder="000.000.000-00"
                placeholderTextColor="#AAAAAA"
                keyboardType="numeric"
                maxLength={14}
                autoCapitalize="none"
              />
            </View>
          </View>

          <View style={styles.campoContainer}>
            <Text style={styles.label}>
              Senha
            </Text>

            <View style={styles.inputContainer}>
              <Ionicons
                name="lock-closed-outline"
                size={21}
                color="#FA2A55"
              />

              <TextInput
                style={styles.input}
                value={senha}
                onChangeText={(valor) => {
                  setSenha(valor);
                  setErro("");
                }}
                placeholder="Digite sua senha"
                placeholderTextColor="#AAAAAA"
                secureTextEntry={!mostrarSenha}
                autoCapitalize="none"
              />

              <TouchableOpacity
                onPress={() =>
                  setMostrarSenha(!mostrarSenha)
                }
                style={styles.olho}
              >
                <Ionicons
                  name={
                    mostrarSenha
                      ? "eye-outline"
                      : "eye-off-outline"
                  }
                  size={21}
                  color="#888888"
                />
              </TouchableOpacity>
            </View>
          </View>

          {erro ? (
            <View style={styles.erroContainer}>
              <Ionicons
                name="alert-circle-outline"
                size={19}
                color="#FA2A55"
              />

              <Text style={styles.erroTexto}>
                {erro}
              </Text>
            </View>
          ) : null}

          <TouchableOpacity
            style={[
              styles.botao,
              carregando ? styles.botaoDesabilitado : null,
            ]}
            onPress={realizarLogin}
            disabled={carregando}
            activeOpacity={0.85}
          >
            {carregando ? (
              <ActivityIndicator
                size="small"
                color="#FFFFFF"
              />
            ) : (
              <>
                <Text style={styles.botaoTexto}>
                  Entrar
                </Text>

                <Ionicons
                  name="arrow-forward"
                  size={20}
                  color="#FFFFFF"
                />
              </>
            )}
          </TouchableOpacity>
        </View>

        <View style={styles.informacao}>
          <Ionicons
            name="shield-checkmark-outline"
            size={18}
            color="#FA2A55"
          />

          <Text style={styles.informacaoTexto}>
            Acesso seguro ao sistema SportCorp
          </Text>
        </View>

        <Text style={styles.rodape}>
          SportCorp • Gestão de Escolas de Vôlei
        </Text>
      </ScrollView>
    </KeyboardAvoidingView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#FA2A55",
  },

  scroll: {
    flexGrow: 1,
    paddingHorizontal: 22,
    paddingVertical: 35,
    justifyContent: "center",
  },

  topo: {
    alignItems: "center",
    marginBottom: 25,
  },

  logoCirculo: {
    width: 82,
    height: 82,
    borderRadius: 41,
    backgroundColor: "rgba(255,255,255,0.15)",
    alignItems: "center",
    justifyContent: "center",
    marginBottom: 10,
    borderWidth: 1,
    borderColor: "rgba(255,255,255,0.25)",
  },

  logo: {
    fontSize: 35,
    fontWeight: "900",
    color: "#FFFFFF",
    letterSpacing: 0.5,
  },

  slogan: {
    color: "#FFE8EE",
    fontSize: 13,
    marginTop: 3,
  },

  card: {
    backgroundColor: "#FFFFFF",
    borderRadius: 26,
    padding: 24,
    elevation: 8,
    shadowColor: "#000000",
    shadowOpacity: 0.15,
    shadowRadius: 14,
    shadowOffset: {
      width: 0,
      height: 7,
    },
  },

  titulo: {
    fontSize: 27,
    fontWeight: "900",
    color: "#202020",
  },

  subtitulo: {
    fontSize: 13,
    color: "#858585",
    lineHeight: 19,
    marginTop: 5,
    marginBottom: 25,
  },

  campoContainer: {
    marginBottom: 17,
  },

  label: {
    fontSize: 13,
    fontWeight: "800",
    color: "#333333",
    marginBottom: 7,
  },

  inputContainer: {
    height: 55,
    borderWidth: 1.3,
    borderColor: "#E5E5E5",
    borderRadius: 15,
    backgroundColor: "#FAFAFA",
    paddingHorizontal: 15,
    flexDirection: "row",
    alignItems: "center",
  },

  inputErro: {
    borderColor: "#FA2A55",
  },

  input: {
    flex: 1,
    height: "100%",
    marginLeft: 10,
    fontSize: 15,
    color: "#222222",
  },

  olho: {
    padding: 5,
  },

  erroContainer: {
    flexDirection: "row",
    alignItems: "center",
    backgroundColor: "#FFF0F4",
    borderRadius: 12,
    paddingHorizontal: 12,
    paddingVertical: 10,
    marginBottom: 15,
  },

  erroTexto: {
    flex: 1,
    color: "#FA2A55",
    fontSize: 12,
    fontWeight: "600",
    marginLeft: 7,
  },

  botao: {
    height: 56,
    borderRadius: 15,
    backgroundColor: "#FA2A55",
    alignItems: "center",
    justifyContent: "center",
    flexDirection: "row",
    gap: 10,
    marginTop: 5,
    elevation: 4,
    shadowColor: "#FA2A55",
    shadowOpacity: 0.25,
    shadowRadius: 8,
    shadowOffset: {
      width: 0,
      height: 4,
    },
  },

  botaoDesabilitado: {
    opacity: 0.7,
  },

  botaoTexto: {
    color: "#FFFFFF",
    fontSize: 16,
    fontWeight: "800",
  },

  informacao: {
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "center",
    marginTop: 22,
    gap: 7,
  },

  informacaoTexto: {
    color: "#FFFFFF",
    fontSize: 11,
    fontWeight: "600",
  },

  rodape: {
    textAlign: "center",
    color: "#FFE5EB",
    fontSize: 10,
    marginTop: 25,
  },
});