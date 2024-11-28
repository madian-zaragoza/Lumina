using UnityEngine;
using UnityEngine.SceneManagement;

public class CrearPartida : MonoBehaviour
{
    public TMPro.TMP_InputField inputFieldNombre; // Campo de texto donde se escribe el nombre

    public void CrearNuevaPartida ()
    {
        string nombrePartida = inputFieldNombre.text;

        if (!string.IsNullOrEmpty(nombrePartida))
        {
            // Obtén la cantidad actual de partidas y asigna un nuevo ID
            int cantidadPartidas = PlayerPrefs.GetInt("CantidadPartidas", 0);

            // Guarda el nombre y progreso de la nueva partida
            PlayerPrefs.SetString($"Partida{cantidadPartidas}_Nombre", nombrePartida);
            PlayerPrefs.SetString($"Partida{cantidadPartidas}_Progreso", "Juego"); // Escena inicial
            PlayerPrefs.SetInt("CantidadPartidas", cantidadPartidas + 1);

            PlayerPrefs.Save(); // Asegúrate de guardar los datos

            // Cargar la escena de juego
            SceneManager.LoadScene("Juego");
        }
        else
        {
            Debug.LogWarning("El nombre de la partida no puede estar vacío.");
        }
    }
}
