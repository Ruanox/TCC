import React, { useState } from "react";
import {
  View,
  Text,
  TextInput,
  TouchableOpacity,
  StyleSheet,
  Alert,
  KeyboardAvoidingView,
  Platform,
  ScrollView,
  StatusBar,
  ActivityIndicator,
} from "react-native";
import { Ionicons } from "@expo/vector-icons";

import { registerAluno } from "../../services/alunoService";

export default function RegisterAluno({
  navigation,
}) {
  const [usuario, setUsuario] = useState("");
  const [cpf, setCpf] = useState("");
  const [dataNasc, setDataNasc] = useState("");
  const [carregando, setCarregando] = useState(false);

  function formatarCPF(valor) {
    const numeros = valor
      .replace(/\D/g, "")
      .slice(0, 11);

    if (numeros.length <= 3) {
      return numeros;
    }

    if (numeros.length <= 6) {
      return `${numeros.slice(
        0,
        3
      )}.${numeros.slice(3)}`;
    }

    if (numeros.length <= 9) {
      return `${numeros.slice(
        0,
        3
      )}.${numeros.slice(
        3,
        6
      )}.${numeros.slice(6)}`;
    }

    return `${numeros.slice(
      0,
      3
    )}.${numeros.slice(
      3,
      6
    )}.${numeros.slice(
      6,
      9
    )}-${numeros.slice(9)}`;
  }

  function formatarData(valor) {
    const numeros = valor
      .replace(/\D/g, "")
      .slice(0, 8);

    if (numeros.length <= 4) {
      return numeros;
    }

    if (numeros.length <= 6) {
      return `${numeros.slice(
        0,
        4
      )}-${numeros.slice(4)}`;
    }

    return `${numeros.slice(
      0,
      4
    )}-${numeros.slice(
      4,
      6
    )}-${numeros.slice(6)}`;
  }

  async function handleRegister() {
    if (carregando) {
      return;
    }

    const usuarioLimpo = usuario.trim();
    const cpfLimpo = cpf.replace(/\D/g, "");
    const dataLimpa = dataNasc.trim();

    if (
      !usuarioLimpo ||
      !cpfLimpo ||
      !dataLimpa
    ) {
      Alert.alert(
        "Atenção",
        "Preencha todos os campos."
      );
      return;
    }

    if (cpfLimpo.length !== 11) {
      Alert.alert(
        "CPF inválido",
        "Digite um CPF com 11 números."
      );
      return;
    }

    if (
      !/^\d{4}-\d{2}-\d{2}$/.test(
        dataLimpa
      )
    ) {
      Alert.alert(
        "Data inválida",
        "Digite a data no formato AAAA-MM-DD."
      );
      return;
    }

    try {
      setCarregando(true);

      const resposta =
        await registerAluno({
          usuario: usuarioLimpo,
          cpf: cpfLimpo,
          data_nasc: dataLimpa,
        });

      console.log(
        "RESPOSTA DO CADASTRO:",
        resposta
      );

      if (resposta?.success === true) {
        Alert.alert(
          "Cadastro realizado!",
          "Aluno cadastrado com sucesso.",
          [
            {
              text: "Continuar",
              onPress: () => {
                navigation.navigate("Login");
              },
            },
          ]
        );

        return;
      }

      Alert.alert(
        "Erro",
        resposta?.error ||
          resposta?.message ||
          resposta?.erro ||
          "Não foi possível cadastrar o aluno."
      );
    } catch (error) {
      console.log(
        "ERRO NO CADASTRO:",
        error.response?.data ||
          error.message
      );

      Alert.alert(
        "Erro",
        error.response?.data?.error ||
          error.response?.data?.message ||
          error.response?.data?.erro ||
          "Não foi possível conectar ao servidor."
      );
    } finally {
      setCarregando(false);
    }
  }

  return (
    <KeyboardAvoidingView
      style={styles.container}
      behavior={
        Platform.OS === "ios"
          ? "padding"
          : undefined
      }
    >
      <StatusBar
        barStyle="light-content"
        backgroundColor="#FA2A55"
      />

      <ScrollView
        contentContainerStyle={styles.scroll}
        keyboardShouldPersistTaps="handled"
        showsVerticalScrollIndicator={false}
      >
        <View style={styles.header}>
          <TouchableOpacity
            style={styles.backButton}
            onPress={() => navigation.goBack()}
            disabled={carregando}
          >
            <Ionicons
              name="arrow-back"
              size={23}
              color="#FFFFFF"
            />
          </TouchableOpacity>

          <View style={styles.logoCircle}>
            <Ionicons
              name="person-add-outline"
              size={34}
              color="#FFFFFF"
            />
          </View>

          <Text style={styles.logo}>
            SportCorp
          </Text>

          <Text style={styles.subtitle}>
            Cadastro de aluno
          </Text>
        </View>

        <View style={styles.card}>
          <Text style={styles.title}>
            Cadastro de Aluno
          </Text>

          <Text style={styles.description}>
            Preencha seus dados para criar sua
            conta no SportCorp.
          </Text>

          <View style={styles.field}>
            <Text style={styles.label}>
              Usuário
            </Text>

            <View style={styles.inputContainer}>
              <Ionicons
                name="person-outline"
                size={20}
                color="#FA2A55"
              />

              <TextInput
                style={styles.input}
                placeholder="Digite seu usuário"
                placeholderTextColor="#AAAAAA"
                value={usuario}
                onChangeText={setUsuario}
                autoCapitalize="none"
                editable={!carregando}
              />
            </View>
          </View>

          <View style={styles.field}>
            <Text style={styles.label}>
              CPF
            </Text>

            <View style={styles.inputContainer}>
              <Ionicons
                name="card-outline"
                size={20}
                color="#FA2A55"
              />

              <TextInput
                style={styles.input}
                placeholder="000.000.000-00"
                placeholderTextColor="#AAAAAA"
                value={cpf}
                onChangeText={(valor) =>
                  setCpf(formatarCPF(valor))
                }
                keyboardType="numeric"
                maxLength={14}
                editable={!carregando}
              />
            </View>
          </View>

          <View style={styles.field}>
            <Text style={styles.label}>
              Data de nascimento
            </Text>

            <View style={styles.inputContainer}>
              <Ionicons
                name="calendar-outline"
                size={20}
                color="#FA2A55"
              />

              <TextInput
                style={styles.input}
                placeholder="AAAA-MM-DD"
                placeholderTextColor="#AAAAAA"
                value={dataNasc}
                onChangeText={(valor) =>
                  setDataNasc(
                    formatarData(valor)
                  )
                }
                keyboardType="numeric"
                maxLength={10}
                editable={!carregando}
              />
            </View>
          </View>

          <View style={styles.info}>
            <Ionicons
              name="information-circle-outline"
              size={18}
              color="#FA2A55"
            />

            <Text style={styles.infoText}>
              Informe a data no formato
              AAAA-MM-DD.
            </Text>
          </View>

          <TouchableOpacity
            style={[
              styles.button,
              carregando &&
                styles.buttonDisabled,
            ]}
            onPress={handleRegister}
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
                <Text style={styles.buttonText}>
                  Cadastrar
                </Text>

                <Ionicons
                  name="checkmark-circle-outline"
                  size={21}
                  color="#FFFFFF"
                />
              </>
            )}
          </TouchableOpacity>
        </View>

        <Text style={styles.footer}>
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
    paddingTop: 45,
    paddingBottom: 25,
    justifyContent: "center",
  },

  header: {
    alignItems: "center",
    marginBottom: 20,
  },

  backButton: {
    position: "absolute",
    left: 0,
    top: 0,
    width: 43,
    height: 43,
    borderRadius: 14,
    backgroundColor: "rgba(255,255,255,0.14)",
    alignItems: "center",
    justifyContent: "center",
  },

  logoCircle: {
    width: 68,
    height: 68,
    borderRadius: 34,
    backgroundColor: "rgba(255,255,255,0.15)",
    borderWidth: 1,
    borderColor: "rgba(255,255,255,0.25)",
    alignItems: "center",
    justifyContent: "center",
    marginTop: 20,
    marginBottom: 8,
  },

  logo: {
    color: "#FFFFFF",
    fontSize: 29,
    fontWeight: "900",
  },

  subtitle: {
    color: "#FFE5EB",
    fontSize: 12,
    marginTop: 3,
  },

  card: {
    backgroundColor: "#FFFFFF",
    borderRadius: 28,
    padding: 23,
    elevation: 8,
    shadowColor: "#000000",
    shadowOpacity: 0.16,
    shadowRadius: 14,
    shadowOffset: {
      width: 0,
      height: 7,
    },
  },

  title: {
    color: "#202020",
    fontSize: 25,
    fontWeight: "900",
    textAlign: "center",
  },

  description: {
    color: "#777777",
    fontSize: 12,
    lineHeight: 18,
    textAlign: "center",
    marginTop: 7,
    marginBottom: 22,
  },

  field: {
    marginBottom: 15,
  },

  label: {
    color: "#333333",
    fontSize: 12,
    fontWeight: "800",
    marginBottom: 7,
  },

  inputContainer: {
    height: 53,
    backgroundColor: "#FAFAFA",
    borderWidth: 1.2,
    borderColor: "#E5E5E5",
    borderRadius: 14,
    paddingHorizontal: 14,
    flexDirection: "row",
    alignItems: "center",
  },

  input: {
    flex: 1,
    marginLeft: 10,
    fontSize: 14,
    color: "#222222",
    height: "100%",
  },

  info: {
    backgroundColor: "#FFF0F4",
    borderRadius: 12,
    paddingHorizontal: 11,
    paddingVertical: 9,
    flexDirection: "row",
    alignItems: "center",
    marginBottom: 17,
  },

  infoText: {
    flex: 1,
    color: "#777777",
    fontSize: 10,
    lineHeight: 15,
    marginLeft: 7,
  },

  button: {
    height: 55,
    borderRadius: 15,
    backgroundColor: "#FA2A55",
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "center",
    gap: 9,
    elevation: 4,
    shadowColor: "#FA2A55",
    shadowOpacity: 0.25,
    shadowRadius: 8,
    shadowOffset: {
      width: 0,
      height: 4,
    },
  },

  buttonDisabled: {
    opacity: 0.65,
  },

  buttonText: {
    color: "#FFFFFF",
    fontSize: 15,
    fontWeight: "800",
  },

  footer: {
    color: "#FFE5EB",
    textAlign: "center",
    fontSize: 10,
    marginTop: 20,
  },
});