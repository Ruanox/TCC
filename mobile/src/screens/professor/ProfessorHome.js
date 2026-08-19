import {
  ScrollView,
  View,
  Text,
  StyleSheet
} from "react-native";

import {
  useEffect,
  useState
} from "react";

import {
  getAulas
} from "../../services/aulaService";

export default function ProfessorHome() {

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

    } catch (error) {
      console.log(error);
    }
  }

  return (

    <ScrollView style={styles.container}>

      <Text style={styles.title}>
        Aulas do Dia
      </Text>

      {aulas.map((aula) => (

        <View
          key={aula.id_horario}
          style={styles.card}
        >

          <Text style={styles.cardTitle}>
            {aula.modalidade}
          </Text>

          <Text>
            📅 {aula.dia_semana}
          </Text>

          <Text>
            ⏰ {aula.hora_inicio} - {aula.hora_fim}
          </Text>

          <Text>
            👨‍🏫 {aula.professor}
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