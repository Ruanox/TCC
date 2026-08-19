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

export default function AlunoHome() {

  const [aulas, setAulas] = useState([]);

  useEffect(() => {
    load();
  }, []);

  async function load() {

    const data = await getAulas();

    if (Array.isArray(data)) {
      setAulas(data);
    }
  }

  return (

    <ScrollView style={styles.container}>

      <Text style={styles.title}>
        Aulas do Dia
      </Text>

      {aulas.map((a, i) => (

        <View key={i} style={styles.card}>

          <Text style={styles.cardTitle}>
            {a.modalidade}
          </Text>

          <Text>
            ⏰ {a.horario}
          </Text>

          <Text>
            👨‍🏫 {a.professor}
          </Text>

          <Text>
            🌙 {a.turno}
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
  },

  card: {
    backgroundColor: "#fff",
    padding: 20,
    borderRadius: 15,
    marginBottom: 15,
    elevation: 4,
  },

  cardTitle: {
    fontSize: 22,
    fontWeight: "bold",
    color: "#FA2A55",
    marginBottom: 10,
  },

});