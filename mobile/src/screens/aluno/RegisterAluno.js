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

export default function RegisterAluno({ navigation }) {
  const [nome, setNome] = useState("");
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
      return `${numeros.slice(0, 3)}.${numeros.slice(3)}`;
    }

    if (numeros.length <= 9) {
      return `${numeros.slice(0, 3)}.${numeros.slice(
        3,
        6
      )}.${numeros.slice(6)}`;
    }

    return `${numeros.slice(0, 3)}.${numeros.slice(
      3,
      6
    )}.${numeros.slice(6, 9)}-${numeros.slice(9)}`;
  }

  function formatarData(valor) {
    const numeros = valor
      .replace(/\D/g, "")
      .slice(0, 8);

    if (numeros.length <= 4) {
      return numeros;
    }

    if (numeros.length <= 6) {
      return `${numeros.slice(0, 4)}-${numeros.slice(4)}`;
    }

    return `${numeros.slice(0, 4)}-${numeros.slice(
      4,
      6
    )}-${numeros.slice(6, 8)}`;
  }

  async function handleRegister() {
    if (carregando) {
      return;
    }

    const nomeLimpo = nome.trim();
    const cpfLimpo = cpf.replace(/\D/g, "");
    const dataLimpa = dataNasc.trim();

    if (!nomeLimpo || !cpfLimpo || !dataLimpa) {
      Alert.alert(
        "Atenção",
        "Preencha todos os campos."
      );
      return;
    }

    if (!/^\d{4}-\d{2}-\d{2}$/.test(dataLimpa)) {
      Alert.alert(
        "Data inválida",
        "Digite a data no formato AAAA-MM-DD."
      );
      return;
    }

    const data = new Date(
      `${dataLimpa}T00:00:00`
    );

    if (Number.isNaN(data.getTime())) {
      Alert.alert(
        "Data inválida",
        "Digite uma data válida."
      );
      return;
    }

    if (data > new Date()) {
      Alert.alert(
        "Data inválida",
        "A data de nascimento não pode ser futura."
      );
      return;
    }

    try {
      setCarregando(true);

      const resposta = await registerAluno({
        nome: nomeLimpo,
        cpf: cpfLimpo,
        data_nasc: dataLimpa,
      });

      console.log(
        "Resposta do cadastro:",
        resposta
      );

      if (resposta?.success === true) {
        Alert.alert(
          "Sucesso",
          "Aluno cadastrado com sucesso!",
          [
            {
              text: "OK",
              onPress: () => {
                navigation.popToTop();
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
          "Não foi possível cadastrar o aluno."
      );
    } catch (error) {
      console.log(
        "Erro ao cadastrar aluno:",
        error.response?.data ||
          error.message
      );

      const dados = error.response?.data;

      if (error.response?.status === 409) {
        Alert.alert(
          "CPF já cadastrado",
          "Este CPF já está cadastrado no sistema."
        );
      } else {
        Alert.alert(
          "Erro",
          dados?.error ||
            dados?.message ||
            "Não foi possível cadastrar o aluno."
        );
      }
    } finally {
      setCarregando(false);
    }
  }

  return (
    <View style={styles.container}>
      <Text style={styles.title}>
        Cadastro de Aluno
      </Text>

      <TextInput
        style={styles.input}
        placeholder="Nome completo"
        value={nome}
        onChangeText={setNome}
        autoCapitalize="words"
        editable={!carregando}
      />

      <TextInput
        style={styles.input}
        placeholder="CPF"
        value={cpf}
        onChangeText={(valor) =>
          setCpf(formatarCPF(valor))
        }
        keyboardType="numeric"
        maxLength={14}
        editable={!carregando}
      />

      <TextInput
        style={styles.input}
        placeholder="Data de nascimento (AAAA-MM-DD)"
        value={dataNasc}
        onChangeText={(valor) =>
          setDataNasc(formatarData(valor))
        }
        keyboardType="numeric"
        maxLength={10}
        editable={!carregando}
      />

      <TouchableOpacity
        style={[
          styles.button,
          carregando && styles.buttonDisabled,
        ]}
        onPress={handleRegister}
        disabled={carregando}
      >
        <Text style={styles.buttonText}>
          {carregando
            ? "Cadastrando..."
            : "Cadastrar"}
        </Text>
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
    fontSize: 26,
    fontWeight: "bold",
    marginBottom: 25,
    textAlign: "center",
    color: "#222",
  },

  input: {
    backgroundColor: "#FFFFFF",
    paddingHorizontal: 15,
    paddingVertical: 13,
    borderRadius: 10,
    marginBottom: 14,
    borderWidth: 1,
    borderColor: "#DDD",
    fontSize: 16,
  },

  button: {
    backgroundColor: "#FA2A55",
    paddingVertical: 15,
    borderRadius: 10,
    alignItems: "center",
    marginTop: 5,
  },

  buttonDisabled: {
    opacity: 0.6,
  },

  buttonText: {
    color: "#FFFFFF",
    fontSize: 17,
    fontWeight: "bold",
  },
});