import { createDrawerNavigator } from "@react-navigation/drawer";

import AlunoHome from "../screens/aluno/AlunoHome";
import HorariosAluno from "../screens/aluno/HorariosAluno";
import PresencaAluno from "../screens/aluno/PresencaAluno";

const Drawer = createDrawerNavigator();

export default function AlunoDrawer() {
  return (
    <Drawer.Navigator
      screenOptions={{
        headerStyle: {
          backgroundColor: "#FA2A55",
        },

        headerTintColor: "#fff",

        drawerStyle: {
          backgroundColor: "#f5f5f5",
          width: 240,
        },

        drawerActiveTintColor: "#FA2A55",

        drawerLabelStyle: {
          fontSize: 16,
        },
      }}
    >
      <Drawer.Screen
        name="Aulas"
        component={AlunoHome}
      />

      <Drawer.Screen
        name="Horários"
        component={HorariosAluno}
      />

      <Drawer.Screen
        name="Presença"
        component={PresencaAluno}
      />
    </Drawer.Navigator>
  );
}