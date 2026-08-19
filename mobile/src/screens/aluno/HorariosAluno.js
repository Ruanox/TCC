import {
  ScrollView,
  View,
  Text,
  StyleSheet
}
  from "react-native";

import {
  useEffect,
  useState
}
  from "react";

import {
  getAulas
}
  from "../../services/aulaService";

export default function HorariosAluno() {

  const [aulas, setAulas] = useState([]);

  useEffect(() => {
    load();
  }, []);

  async function load() {

    try {

      const data = await getAulas();

      if (Array.isArray(data)) {
        setAulas(data);
      }

    } catch (err) {
      console.log(err);
    }
  }

  return (

    <ScrollView style={styles.container}>

      <Text style={styles.title}>
        Meus Horários
      </Text>

      {aulas.map((a, i) => (

        <View key={i} style={styles.card}>

          <Text style={styles.modalidade}>
            {a.modalidade}
          </Text>

          <Text style={styles.info}>
            📅 {a.dia_semana}
          </Text>

          <Text style={styles.info}>
            ⏰ {a.hora_inicio} - {a.hora_fim}
          </Text>

          <Text style={styles.info}>
            👨‍🏫 {a.professor}
          </Text>

        </View>
      ))}

    </ScrollView>
  );
}

const styles = StyleSheet.create({

  container: {
    flex: 1,
    backgroundColor: "#f5f5f5",
    padding: 15,
  },

  title: {
    fontSize: 28,
    fontWeight: "bold",
    marginBottom: 20,
    color: "#222",
  },

  card: {
    backgroundColor: "#fff",
    borderRadius: 15,
    padding: 20,
    marginBottom: 15,
    elevation: 4,
  },

  modalidade: {
    fontSize: 22,
    fontWeight: "bold",
    color: "#FA2A55",
    marginBottom: 10,
  },

  info: {
    fontSize: 16,
    marginBottom: 5,
    color: "#444",
  },

});