import {
  ScrollView,
  View,
  Text,
  StyleSheet
}
  from "react-native";

export default function PresencaAluno() {

  const presencas = [

    {
      aula: "Voleibol",
      data: "20/05/2026",
      status: "Presente"
    },

    {
      aula: "Voleibol",
      data: "22/05/2026",
      status: "Falta"
    },

    {
      aula: "Voleibol",
      data: "24/05/2026",
      status: "Presente"
    },

  ];

  return (

    <ScrollView style={styles.container}>

      <Text style={styles.title}>
        Minha Presença
      </Text>

      {presencas.map((p, i) => (

        <View key={i} style={styles.card}>

          <Text style={styles.aula}>
            🏐 {p.aula}
          </Text>

          <Text style={styles.info}>
            📅 {p.data}
          </Text>

          <Text
            style={[
              styles.status,

              p.status === "Presente"
                ? styles.presente
                : styles.falta
            ]}
          >
            {p.status}
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
    padding: 20,
    borderRadius: 15,
    marginBottom: 15,
    elevation: 4,
  },

  aula: {
    fontSize: 22,
    fontWeight: "bold",
    color: "#FA2A55",
    marginBottom: 10,
  },

  info: {
    fontSize: 16,
    marginBottom: 10,
    color: "#444",
  },

  status: {
    fontSize: 16,
    fontWeight: "bold",
  },

  presente: {
    color: "green",
  },

  falta: {
    color: "red",
  },

});