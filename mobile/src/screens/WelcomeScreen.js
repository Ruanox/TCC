import React from "react";
import { View, Text, TouchableOpacity, StyleSheet } from "react-native";

export default function WelcomeScreen({ navigation }) {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Bem-vindo ao SportCorp</Text>

      <TouchableOpacity
        style={styles.button}
        onPress={() => navigation.navigate("Login")}
      >
        <Text style={styles.buttonText}>Já tenho conta</Text>
      </TouchableOpacity>

      <TouchableOpacity
        style={[styles.button, styles.outline]}
        onPress={() => navigation.navigate("RoleSelect")}
      >
        <Text style={[styles.buttonText, styles.outlineText]}>Não tenho conta</Text>
      </TouchableOpacity>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    padding: 24,
    backgroundColor: "#F5F5F5",
  },
  title: {
    fontSize: 28,
    fontWeight: "bold",
    marginBottom: 24,
    color: "#FA2A55",
  },
  button: {
    width: "100%",
    backgroundColor: "#FA2A55",
    padding: 14,
    borderRadius: 10,
    alignItems: "center",
    marginTop: 12,
  },
  buttonText: {
    color: "#fff",
    fontWeight: "bold",
  },
  outline: {
    backgroundColor: "transparent",
    borderWidth: 1,
    borderColor: "#FA2A55",
  },
  outlineText: {
    color: "#FA2A55",
  },
});
