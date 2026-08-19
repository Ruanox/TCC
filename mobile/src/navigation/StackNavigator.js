import { NavigationContainer }
from "@react-navigation/native";

import {
  createNativeStackNavigator
}
from "@react-navigation/native-stack";

import LoginScreen
from "../screens/LoginScreen";
import WelcomeScreen from "../screens/WelcomeScreen";
import RoleSelectScreen from "../screens/RoleSelectScreen";
import RegisterAluno from "../screens/aluno/RegisterAluno";

import ProfessorDrawer
from "./ProfessorDrawer";

import AlunoDrawer
from "./AlunoDrawer";

const Stack = createNativeStackNavigator();

export default function StackNavigator() {

  return (

    <NavigationContainer>

      <Stack.Navigator>

          <Stack.Screen
            name="Welcome"
            component={WelcomeScreen}
            options={{ headerShown: false }}
          />

          <Stack.Screen
            name="RoleSelect"
            component={RoleSelectScreen}
            options={{ headerShown: false }}
          />

          <Stack.Screen
            name="RegisterAluno"
            component={RegisterAluno}
            options={{ headerShown: false }}
          />

          <Stack.Screen
            name="Login"
            component={LoginScreen}
            options={{
              headerShown: false
            }}
          />

        <Stack.Screen
          name="Professor"
          component={ProfessorDrawer}
          options={{
            headerShown: false
          }}
        />

        <Stack.Screen
          name="Aluno"
          component={AlunoDrawer}
          options={{
            headerShown: false
          }}
        />

      </Stack.Navigator>

    </NavigationContainer>
  );
}