import React, { useEffect, useState } from "react";
import {
  View,
  Text,
  FlatList,
  TouchableOpacity,
  StyleSheet,
  Alert
} from "react-native";

import api from "../../services/api";

export default function ChamadaScreen() {

  const [alunos, setAlunos] = useState([]);

  useEffect(() => {
    carregarAlunos();
  }, []);

  const carregarAlunos = async () => {
    try {
      const response = await api.get("/presenca.php");
      setAlunos(response.data);
    } catch (error) {
      console.log(error);
      Alert.alert("Erro", "Não foi possível carregar os alunos");
    }
  };

  const marcarPresenca = async (id_aluno, presente) => {
    try {

      await api.post("/presenca.php", {
        id_aluno,
        presente
      });

      Alert.alert(
        "Sucesso",
        presente ? "Presença registrada" : "Falta registrada"
      );

    } catch (error) {
      console.log(error);
      Alert.alert("Erro", "Não foi possível salvar");
    }
  };

  const renderItem = ({ item }) => (
    <View style={styles.card}>
      <Text style={styles.nome}>{item.nome}</Text>

      <View style={styles.botoes}>

        <TouchableOpacity
          style={[styles.botao, styles.presente]}
          onPress={() => marcarPresenca(item.id_aluno, 1)}
        >
          <Text style={styles.textoBotao}>Presente</Text>
        </TouchableOpacity>

        <TouchableOpacity
          style={[styles.botao, styles.falta]}
          onPress={() => marcarPresenca(item.id_aluno, 0)}
        >
          <Text style={styles.textoBotao}>Falta</Text>
        </TouchableOpacity>

      </View>
    </View>
  );

  return (
    <View style={styles.container}>

      <Text style={styles.titulo}>
        Chamada - {new Date().toLocaleString()}
      </Text>

      <FlatList
        data={alunos}
        keyExtractor={(item) => String(item.id_aluno)}
        renderItem={renderItem}
      />

    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 15,
    backgroundColor: "#fff"
  },

  titulo: {
    fontSize: 20,
    fontWeight: "bold",
    marginBottom: 15
  },

  card: {
    backgroundColor: "#f5f5f5",
    padding: 15,
    borderRadius: 10,
    marginBottom: 10
  },

  nome: {
    fontSize: 18,
    marginBottom: 10
  },

  botoes: {
    flexDirection: "row",
    justifyContent: "space-between"
  },

  botao: {
    flex: 1,
    padding: 10,
    borderRadius: 8,
    marginHorizontal: 5,
    alignItems: "center"
  },

  presente: {
    backgroundColor: "#28a745"
  },

  falta: {
    backgroundColor: "#dc3545"
  },

  textoBotao: {
    color: "#fff",
    fontWeight: "bold"
  }
});