import {
  View,
  Text,
  TextInput,
  TouchableOpacity,
  StyleSheet,
  Alert,
} from "react-native";

import { useState } from "react";

import { login } from "../services/authService";

export default function LoginScreen({ navigation }) {
  const [cpf, setCpf] = useState("");
  const [senha, setSenha] = useState("");

  async function handleLogin() {
    if (!cpf || !senha) {
      Alert.alert("Erro", "Preencha todos os campos");
      return;
    }

    try {
      const res = await login(cpf, senha);

      if (res.tipo === "professor") {
        navigation.replace("Professor");
      } else if (res.tipo === "aluno") {
        if (res.menorDeIdade) {
          alert(`Aluno menor de idade. Turma de idade: ${res.faixaEtaria}`);
        }
        navigation.replace("Aluno");
      } else {
        Alert.alert("Erro", res.message || "Login inválido");
      }
    } catch (err) {
      console.log("Erro ao fazer login:", err.response?.data || err.message);
      Alert.alert("Erro", err.response?.data?.message || "Não foi possível conectar ao servidor. Verifique sua conexão e a URL da API.");
    }
  }

  return (
    <View style={styles.container}>
      <Text style={styles.title}>SportCorp</Text>

      <TextInput
        placeholder="CPF"
        style={styles.input}
        value={cpf}
        onChangeText={setCpf}
      />

      <TextInput
        placeholder="Senha"
        secureTextEntry
        style={styles.input}
        value={senha}
        onChangeText={setSenha}
      />

      <TouchableOpacity style={styles.button} onPress={handleLogin}>
        <Text style={styles.buttonText}>Entrar</Text>
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

  buttonText: {
    color: "#fff",
    fontSize: 18,
    fontWeight: "bold",
  },
});
