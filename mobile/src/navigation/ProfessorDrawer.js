import React from "react";
import { createDrawerNavigator } from "@react-navigation/drawer";
import { Ionicons } from "@expo/vector-icons";

import ProfessorHome from "../screens/professor/ProfessorHome";
import HorariosScreen from "../screens/professor/HorariosScreen";
import AlunosScreen from "../screens/professor/AlunosScreen";
import ChamadaScreen from "../screens/professor/ChamadaScreen";
import NotificacoesProfessor from "../screens/professor/NotificacoesProfessor";

const Drawer = createDrawerNavigator();

export default function ProfessorDrawer({ route }) {
  const idProfessor = route?.params?.id_professor;

  return (
    <Drawer.Navigator
      initialRouteName="Aulas"
      screenOptions={{
        headerStyle: {
          backgroundColor: "#FA2A55",
          elevation: 0,
          shadowOpacity: 0,
        },

        headerTintColor: "#FFFFFF",
        headerTitleStyle: {
          fontWeight: "700",
          fontSize: 20,
        },

        drawerStyle: {
          backgroundColor: "#FFFFFF",
          width: 285,
        },

        drawerActiveBackgroundColor: "#FFF0F4",
        drawerActiveTintColor: "#FA2A55",
        drawerInactiveTintColor: "#555B66",

        drawerLabelStyle: {
          fontSize: 16,
          fontWeight: "600",
          marginLeft: -8,
        },

        drawerItemStyle: {
          borderRadius: 14,
          marginHorizontal: 12,
          marginVertical: 4,
          paddingHorizontal: 4,
        },

        drawerContentContainerStyle: {
          paddingTop: 12,
        },
      }}
    >
      <Drawer.Screen
        name="Aulas"
        component={ProfessorHome}
        initialParams={{
          id_professor: idProfessor,
        }}
        options={{
          title: "Aulas",
          drawerIcon: ({ focused, color, size }) => (
            <Ionicons
              name={focused ? "home" : "home-outline"}
              size={size}
              color={color}
            />
          ),
        }}
      />

      <Drawer.Screen
        name="Horários"
        component={HorariosScreen}
        initialParams={{
          id_professor: idProfessor,
        }}
        options={{
          title: "Horários",
          drawerIcon: ({ focused, color, size }) => (
            <Ionicons
              name={focused ? "calendar" : "calendar-outline"}
              size={size}
              color={color}
            />
          ),
        }}
      />

      <Drawer.Screen
        name="Alunos"
        component={AlunosScreen}
        initialParams={{
          id_professor: idProfessor,
        }}
        options={{
          title: "Alunos",
          drawerIcon: ({ focused, color, size }) => (
            <Ionicons
              name={focused ? "people" : "people-outline"}
              size={size}
              color={color}
            />
          ),
        }}
      />

      <Drawer.Screen
        name="Chamada"
        component={ChamadaScreen}
        initialParams={{
          id_professor: idProfessor,
        }}
        options={{
          title: "Chamada",
          drawerIcon: ({ focused, color, size }) => (
            <Ionicons
              name={focused ? "clipboard" : "clipboard-outline"}
              size={size}
              color={color}
            />
          ),
        }}
      />

      <Drawer.Screen
        name="Notificações"
        component={NotificacoesProfessor}
        initialParams={{
          id_professor: idProfessor,
        }}
        options={{
          title: "Notificações",
          drawerIcon: ({ focused, color, size }) => (
            <Ionicons
              name={focused ? "notifications" : "notifications-outline"}
              size={size}
              color={color}
            />
          ),
        }}
      />
    </Drawer.Navigator>
  );
}