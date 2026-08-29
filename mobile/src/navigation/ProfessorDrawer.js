import { createDrawerNavigator } from "@react-navigation/drawer";

import ProfessorHome from "../screens/professor/ProfessorHome";
import HorariosScreen from "../screens/professor/HorariosScreen";
import AlunosScreen from "../screens/professor/AlunosScreen";
import ChamadaScreen from "../screens/professor/ChamadaScreen";

const Drawer = createDrawerNavigator();

export default function ProfessorDrawer() {
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
        component={ProfessorHome}
      />

      <Drawer.Screen
        name="Horários"
        component={HorariosScreen}
      />

      <Drawer.Screen
        name="Alunos"
        component={AlunosScreen}
      />

      <Drawer.Screen
        name="Chamada"
        component={ChamadaScreen}
      />
    </Drawer.Navigator>
  );
}