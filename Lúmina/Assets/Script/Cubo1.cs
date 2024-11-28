using UnityEngine;
using UnityEngine.SceneManagement;

public class CuboTeletransportador2 : MonoBehaviour
{
    public string nivelDestino = "Nivel2";

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GuardarProgreso(nivelDestino);
            SceneManager.LoadScene(nivelDestino);
        }
    }

    private void GuardarProgreso (string escenaDestino)
    {
        int idPartida = PlayerPrefs.GetInt("PartidaActual", -1);
        if (idPartida == -1)
        {
            Debug.LogError("Error: No se ha configurado un ID para la partida actual.");
            return;
        }

        PlayerPrefs.SetString($"Partida{idPartida}_Progreso", escenaDestino);
        PlayerPrefs.Save();

        Debug.Log($"Progreso guardado: {escenaDestino} para la partida con ID {idPartida}");
    }
}
