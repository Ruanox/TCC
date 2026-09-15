import React from "react";
import { createDrawerNavigator } from "@react-navigation/drawer";
import { Ionicons } from "@expo/vector-icons";

import AlunoHome from "../screens/aluno/AlunoHome";
import HorariosAluno from "../screens/aluno/HorariosAluno";
import PresencaAluno from "../screens/aluno/PresencaAluno";
import NotificacoesAluno from "../screens/aluno/NotificacoesAluno";

const Drawer = createDrawerNavigator();

export default function AlunoDrawer({ route }) {
  const idAluno = route?.params?.id_aluno;

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
        component={AlunoHome}
        initialParams={{
          id_aluno: idAluno,
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
        component={HorariosAluno}
        initialParams={{
          id_aluno: idAluno,
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
        name="Presença"
        component={PresencaAluno}
        initialParams={{
          id_aluno: idAluno,
        }}
        options={{
          title: "Presença",
          drawerIcon: ({ focused, color, size }) => (
            <Ionicons
              name={focused ? "checkmark-circle" : "checkmark-circle-outline"}
              size={size}
              color={color}
            />
          ),
        }}
      />

      <Drawer.Screen
        name="Notificações"
        component={NotificacoesAluno}
        initialParams={{
          id_aluno: idAluno,
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