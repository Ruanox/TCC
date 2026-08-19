import React, { useState } from "react";
import {
  View,
  Text,
  TextInput,
  TouchableOpacity,
  StyleSheet,
  Alert,
} from "react-native";

import { registerAluno } from "../../services/alunoService";
import { calcularIdade } from "../../services/idadeService";

export default function RegisterAluno({ navigation }) {
  const [nome, setNome] = useState("");
  const [cpf, setCpf] = useState("");
  const [dataNasc, setDataNasc] = useState(""); // use format YYYY-MM-DD

  async function handleRegister() {
    if (!nome || !cpf || !dataNasc) {
      Alert.alert("Erro", "Preencha todos os campos");
      return;
    }

    const data = new Date(dataNasc);
    if (Number.isNaN(data.getTime())) {
      Alert.alert("Erro", "Data inválida. Use AAAA-MM-DD");
      return;
    }

    const idade = calcularIdade(data);
    const menorDeIdade = idade !== null && idade < 18;

    try {
      const payload = {
        nome,
        cpf,
        data_nasc: dataNasc,
        menor_de_idade: menorDeIdade ? 1 : 0,
      };

      const res = await registerAluno(payload);

      if (res.success || res.status === "success") {
        Alert.alert("Sucesso", "Cadastro realizado com sucesso.", [
          {
            text: "OK",
            onPress: () => navigation.navigate("Login"),
          },
        ]);
      } else {
        Alert.alert("Erro", res.message || "Não foi possível cadastrar o aluno.");
      }
    } catch (err) {
      console.log("Erro ao registrar:", err.response?.data || err.message);
      Alert.alert("Erro", err.response?.data?.message || "Não foi possível cadastrar o aluno. Verifique a conexão com o servidor.");
    }
  }

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Cadastro de Aluno</Text>

      <TextInput
        placeholder="Nome"
        style={styles.input}
        value={nome}
        onChangeText={setNome}
      />

      <TextInput
        placeholder="CPF"
        style={styles.input}
        value={cpf}
        onChangeText={setCpf}
      />

      <TextInput
        placeholder="Data de nascimento (AAAA-MM-DD)"
        style={styles.input}
        value={dataNasc}
        onChangeText={setDataNasc}
      />

      <TouchableOpacity style={styles.button} onPress={handleRegister}>
        <Text style={styles.buttonText}>Cadastrar</Text>
      </TouchableOpacity>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 24,
    backgroundColor: "#F5F5F5",
    justifyContent: "center",
  },
  title: {
    fontSize: 22,
    fontWeight: "bold",
    marginBottom: 18,
    textAlign: "center",
  },
  input: {
    backgroundColor: "#fff",
    padding: 12,
    borderRadius: 8,
    marginBottom: 12,
  },
  button: {
    backgroundColor: "#FA2A55",
    padding: 14,
    borderRadius: 10,
    alignItems: "center",
    marginTop: 8,
  },
  buttonText: {
    color: "#fff",
    fontWeight: "bold",
  },
});
