import React from "react";
import {
  View,
  Text,
  TouchableOpacity,
  StyleSheet,
  StatusBar,
} from "react-native";
import { Ionicons } from "@expo/vector-icons";

export default function RoleSelectScreen({
  navigation,
}) {
  return (
    <View style={styles.container}>
      <StatusBar
        barStyle="light-content"
        backgroundColor="#FA2A55"
      />

      <View style={styles.header}>
        <TouchableOpacity
          style={styles.backButton}
          onPress={() => navigation.goBack()}
          activeOpacity={0.8}
        >
          <Ionicons
            name="arrow-back"
            size={23}
            color="#FFFFFF"
          />
        </TouchableOpacity>

        <View style={styles.logoCircle}>
          <Ionicons
            name="person-add-outline"
            size={34}
            color="#FFFFFF"
          />
        </View>

        <Text style={styles.logo}>
          SportCorp
        </Text>

        <Text style={styles.subtitle}>
          Criar uma nova conta
        </Text>
      </View>

      <View style={styles.card}>
        <Text style={styles.title}>
          Que tipo de conta deseja criar?
        </Text>

        <Text style={styles.description}>
          Selecione uma opção para continuar
          com o cadastro.
        </Text>

        <TouchableOpacity
          style={styles.option}
          onPress={() =>
            navigation.navigate("RegisterAluno")
          }
          activeOpacity={0.85}
        >
          <View style={styles.optionIcon}>
            <Ionicons
              name="person-outline"
              size={28}
              color="#FA2A55"
            />
          </View>

          <View style={styles.optionContent}>
            <Text style={styles.optionTitle}>
              Sou aluno
            </Text>

            <Text style={styles.optionDescription}>
              Quero me cadastrar em uma escola
              de vôlei.
            </Text>
          </View>

          <Ionicons
            name="chevron-forward"
            size={23}
            color="#FA2A55"
          />
        </TouchableOpacity>
      </View>

      <View style={styles.footer}>
        <Ionicons
          name="information-circle-outline"
          size={17}
          color="#FFE5EB"
        />

        <Text style={styles.footerText}>
          Escolha uma opção para continuar
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
    paddingTop: 50,
    paddingBottom: 30,
    justifyContent: "space-between",
  },

  header: {
    alignItems: "center",
  },

  backButton: {
    position: "absolute",
    left: 0,
    top: 0,
    width: 43,
    height: 43,
    borderRadius: 14,
    backgroundColor: "rgba(255,255,255,0.14)",
    alignItems: "center",
    justifyContent: "center",
  },

  logoCircle: {
    width: 75,
    height: 75,
    borderRadius: 38,
    backgroundColor: "rgba(255,255,255,0.15)",
    borderWidth: 1,
    borderColor: "rgba(255,255,255,0.25)",
    alignItems: "center",
    justifyContent: "center",
    marginTop: 30,
    marginBottom: 11,
  },

  logo: {
    color: "#FFFFFF",
    fontSize: 30,
    fontWeight: "900",
  },

  subtitle: {
    color: "#FFE6EC",
    fontSize: 13,
    marginTop: 3,
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

  title: {
    color: "#202020",
    fontSize: 23,
    fontWeight: "900",
    textAlign: "center",
  },

  description: {
    color: "#777777",
    fontSize: 13,
    lineHeight: 19,
    textAlign: "center",
    marginTop: 8,
    marginBottom: 22,
  },

  option: {
    minHeight: 90,
    borderRadius: 18,
    backgroundColor: "#FFF0F4",
    borderWidth: 1,
    borderColor: "#FFD5DF",
    flexDirection: "row",
    alignItems: "center",
    paddingHorizontal: 14,
  },

  optionIcon: {
    width: 56,
    height: 56,
    borderRadius: 17,
    backgroundColor: "#FFFFFF",
    alignItems: "center",
    justifyContent: "center",
    marginRight: 13,
  },

  optionContent: {
    flex: 1,
  },

  optionTitle: {
    color: "#222222",
    fontSize: 16,
    fontWeight: "900",
    marginBottom: 4,
  },

  optionDescription: {
    color: "#777777",
    fontSize: 11,
    lineHeight: 16,
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