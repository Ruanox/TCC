import React, { useState } from "react";
import {
  View,
  Text,
  TextInput,
  TouchableOpacity,
  StyleSheet,
  Alert,
} from "react-native";

import { login } from "../services/authService";

export default function LoginScreen({ navigation }) {
  const [cpf, setCpf] = useState("");
  const [senha, setSenha] = useState("");
  const [carregando, setCarregando] = useState(false);

  function formatarCPF(valor) {
    const numeros = valor
      .replace(/\D/g, "")
      .slice(0, 11);

    if (numeros.length <= 3) {
      return numeros;
    }

    if (numeros.length <= 6) {
      return `${numeros.slice(0, 3)}.${numeros.slice(3)}`;
    }

    if (numeros.length <= 9) {
      return `${numeros.slice(0, 3)}.${numeros.slice(3, 6)}.${numeros.slice(6)}`;
    }

    return `${numeros.slice(0, 3)}.${numeros.slice(3, 6)}.${numeros.slice(6, 9)}-${numeros.slice(9)}`;
  }

  async function handleLogin() {
    if (carregando) {
      return;
    }

    const cpfLimpo = cpf.replace(/\D/g, "");

    if (!cpfLimpo || !senha) {
      Alert.alert(
        "Atenção",
        "Preencha todos os campos."
      );
      return;
    }

    if (cpfLimpo.length !== 11) {
      Alert.alert(
        "CPF inválido",
        "Digite um CPF válido."
      );
      return;
    }

    try {
      setCarregando(true);

      const resposta = await login(
        cpfLimpo,
        senha
      );

      console.log(
        "Resposta do login:",
        resposta
      );

      if (
        resposta?.success === true &&
        resposta?.tipo === "professor"
      ) {
        navigation.replace("Professor");
        return;
      }

      if (
        resposta?.success === true &&
        resposta?.tipo === "aluno"
      ) {
        navigation.replace("Aluno");
        return;
      }

      Alert.alert(
        "Erro",
        resposta?.error ||
          resposta?.message ||
          "CPF ou senha incorretos."
      );
    } catch (error) {
      console.log(
        "Erro ao fazer login:",
        error.response?.data ||
          error.message
      );

      const dados = error.response?.data;

      Alert.alert(
        "Erro",
        dados?.error ||
          dados?.message ||
          "Não foi possível conectar ao servidor."
      );
    } finally {
      setCarregando(false);
    }
  }

  return (
    <View style={styles.container}>
      <Text style={styles.title}>
        SportCorp
      </Text>

      <TextInput
        placeholder="CPF"
        style={styles.input}
        value={cpf}
        onChangeText={(valor) =>
          setCpf(formatarCPF(valor))
        }
        keyboardType="numeric"
        maxLength={14}
      />

      <TextInput
        placeholder="Senha"
        secureTextEntry
        style={styles.input}
        value={senha}
        onChangeText={setSenha}
      />

      <TouchableOpacity
        style={[
          styles.button,
          carregando && styles.buttonDisabled,
        ]}
        onPress={handleLogin}
        disabled={carregando}
      >
        <Text style={styles.buttonText}>
          {carregando
            ? "Entrando..."
            : "Entrar"}
        </Text>
      </TouchableOpacity>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    padding: 25,
    backgroundColor: "#F5F5F5",
  },

  title: {
    fontSize: 30,
    fontWeight: "bold",
    textAlign: "center",
    marginBottom: 30,
    color: "#FA2A55",
  },

  input: {
    backgroundColor: "#fff",
    padding: 15,
    borderRadius: 12,
    marginBottom: 15,
  },

  button: {
    backgroundColor: "#FA2A55",
    padding: 15,
    borderRadius: 12,
    alignItems: "center",
  },

  buttonDisabled: {
    opacity: 0.6,
  },

  buttonText: {
    color: "#fff",
    fontSize: 18,
    fontWeight: "bold",
  },
});