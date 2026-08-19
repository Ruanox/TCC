import React, { useEffect, useState } from "react";
import {
ScrollView,
View,
Text,
StyleSheet,
TextInput,
TouchableOpacity,
Alert
} from "react-native";

import api from "../../services/api";

export default function HorariosScreen() {

const [aulas, setAulas] = useState([]);

useEffect(() => {
carregarHorarios();
}, []);

async function carregarHorarios() {


try {

  const response = await api.get("/horarios.php");

  if (Array.isArray(response.data)) {
    setAulas(response.data);
  }

} catch (error) {
  console.log(error);
}


}

async function salvarHorario(aula) {


try {

  await api.post("/horarios.php", aula);

  Alert.alert(
    "Sucesso",
    "Horário atualizado com sucesso!"
  );

} catch (error) {

  console.log(error);

  Alert.alert(
    "Erro",
    "Não foi possível atualizar."
  );
}


}

function atualizarCampo(index, campo, valor) {


const lista = [...aulas];

lista[index][campo] = valor;

setAulas(lista);


}

return (


<ScrollView style={styles.container}>

  <Text style={styles.title}>
    Gerenciar Horários
  </Text>

  {aulas.map((aula, index) => (

    <View
      key={aula.id_horario}
      style={styles.card}
    >

      <TextInput
        style={styles.input}
        value={aula.modalidade}
        onChangeText={(text) =>
          atualizarCampo(index, "modalidade", text)
        }
      />

      <TextInput
        style={styles.input}
        value={aula.dia_semana}
        onChangeText={(text) =>
          atualizarCampo(index, "dia_semana", text)
        }
      />

      <TextInput
        style={styles.input}
        value={aula.horario}
        onChangeText={(text) =>
          atualizarCampo(index, "horario", text)
        }
      />

      <TextInput
        style={styles.input}
        value={aula.turno}
        onChangeText={(text) =>
          atualizarCampo(index, "turno", text)
        }
      />

      <TextInput
        style={styles.input}
        value={aula.professor}
        onChangeText={(text) =>
          atualizarCampo(index, "professor", text)
        }
      />

      <TouchableOpacity
        style={styles.botao}
        onPress={() => salvarHorario(aula)}
      >
        <Text style={styles.botaoTexto}>
          Salvar Alterações
        </Text>
      </TouchableOpacity>

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
borderRadius: 15,
padding: 20,
marginBottom: 15,
elevation: 4,
},

input: {
borderWidth: 1,
borderColor: "#ddd",
borderRadius: 8,
padding: 10,
marginBottom: 10,
backgroundColor: "#fff",
},

botao: {
backgroundColor: "#6C2BD9",
padding: 12,
borderRadius: 8,
alignItems: "center",
},

botaoTexto: {
color: "#fff",
fontWeight: "bold",
},

});
