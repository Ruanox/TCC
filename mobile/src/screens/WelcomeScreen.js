import React from "react";
import {
  View,
  Text,
  TouchableOpacity,
  StyleSheet,
  StatusBar,
} from "react-native";
import { Ionicons } from "@expo/vector-icons";

export default function WelcomeScreen({ navigation }) {
  return (
    <View style={styles.container}>
      <StatusBar
        barStyle="light-content"
        backgroundColor="#FA2A55"
      />

      <View style={styles.topArea}>
        <View style={styles.logoCircle}>
          <Ionicons
            name="trophy-outline"
            size={45}
            color="#FFFFFF"
          />
        </View>

        <Text style={styles.logo}>
          SportCorp
        </Text>

        <Text style={styles.subtitle}>
          Gestão de Escolas de Vôlei
        </Text>
      </View>

      <View style={styles.card}>
        <View style={styles.iconCircle}>
          <Ionicons
            name="people-outline"
            size={30}
            color="#FA2A55"
          />
        </View>

        <Text style={styles.title}>
          Bem-vindo ao SportCorp
        </Text>

        <Text style={styles.description}>
          Organize seus treinos, acompanhe suas
          aulas e tenha tudo em um só lugar.
        </Text>

        <TouchableOpacity
          style={styles.button}
          onPress={() => navigation.navigate("Login")}
          activeOpacity={0.85}
        >
          <Ionicons
            name="log-in-outline"
            size={21}
            color="#FFFFFF"
          />

          <Text style={styles.buttonText}>
            Já tenho conta
          </Text>

          <Ionicons
            name="arrow-forward"
            size={20}
            color="#FFFFFF"
          />
        </TouchableOpacity>

        <TouchableOpacity
          style={styles.outlineButton}
          onPress={() =>
            navigation.navigate("RoleSelect")
          }
          activeOpacity={0.85}
        >
          <Ionicons
            name="person-add-outline"
            size={21}
            color="#FA2A55"
          />

          <Text style={styles.outlineText}>
            Não tenho conta
          </Text>

          <Ionicons
            name="arrow-forward"
            size={19}
            color="#FA2A55"
          />
        </TouchableOpacity>
      </View>

      <View style={styles.footer}>
        <Ionicons
          name="shield-checkmark-outline"
          size={17}
          color="#FFE5EB"
        />

        <Text style={styles.footerText}>
          Sistema seguro e organizado
        </Text>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#FA2A55",
    paddingHorizontal: 22,
    paddingTop: 65,
    paddingBottom: 30,
    justifyContent: "space-between",
  },

  topArea: {
    alignItems: "center",
  },

  logoCircle: {
    width: 88,
    height: 88,
    borderRadius: 44,
    backgroundColor: "rgba(255,255,255,0.15)",
    borderWidth: 1,
    borderColor: "rgba(255,255,255,0.25)",
    alignItems: "center",
    justifyContent: "center",
    marginBottom: 13,
  },

  logo: {
    color: "#FFFFFF",
    fontSize: 36,
    fontWeight: "900",
  },

  subtitle: {
    color: "#FFE6EC",
    fontSize: 13,
    marginTop: 4,
  },

  card: {
    backgroundColor: "#FFFFFF",
    borderRadius: 28,
    padding: 24,
    elevation: 8,
    shadowColor: "#000000",
    shadowOpacity: 0.16,
    shadowRadius: 14,
    shadowOffset: {
      width: 0,
      height: 7,
    },
  },

  iconCircle: {
    width: 58,
    height: 58,
    borderRadius: 29,
    backgroundColor: "#FFF0F4",
    alignItems: "center",
    justifyContent: "center",
    alignSelf: "center",
    marginBottom: 16,
  },

  title: {
    color: "#202020",
    fontSize: 24,
    fontWeight: "900",
    textAlign: "center",
  },

  description: {
    color: "#777777",
    fontSize: 13,
    lineHeight: 20,
    textAlign: "center",
    marginTop: 9,
    marginBottom: 25,
  },

  button: {
    height: 55,
    borderRadius: 15,
    backgroundColor: "#FA2A55",
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
    paddingHorizontal: 17,
    marginBottom: 12,
  },

  buttonText: {
    flex: 1,
    textAlign: "center",
    color: "#FFFFFF",
    fontSize: 14,
    fontWeight: "800",
  },

  outlineButton: {
    height: 55,
    borderRadius: 15,
    borderWidth: 1.4,
    borderColor: "#FA2A55",
    flexDirection: "row",
    alignItems: "center",
    paddingHorizontal: 17,
  },

  outlineText: {
    flex: 1,
    textAlign: "center",
    color: "#FA2A55",
    fontSize: 14,
    fontWeight: "800",
  },

  footer: {
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "center",
    gap: 7,
  },

  footerText: {
    color: "#FFE5EB",
    fontSize: 11,
    fontWeight: "600",
  },
});