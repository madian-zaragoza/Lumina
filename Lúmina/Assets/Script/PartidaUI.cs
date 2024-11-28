using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PartidaUI : MonoBehaviour
{
    public TextMeshProUGUI nombreText;
    public GameObject Opciones;
    private int idPartida;
    private PartidasManager partidasManager;

    public void ConfigurarPartida (string nombre, int id, PartidasManager manager)
    {
        nombreText.text = nombre;
        idPartida = id;
        partidasManager = manager;
    }

    public void CargarPartida ()
    {
        PlayerPrefs.SetInt("PartidaActual", idPartida);
        PlayerPrefs.Save();

        string progresoPartida = PlayerPrefs.GetString($"Partida{idPartida}_Progreso", "Juego");
        SceneManager.LoadScene(progresoPartida);
        Time.timeScale=1;
    }

    public void BorrarPartida ()
    {
        PlayerPrefs.DeleteKey($"Partida{idPartida}_Nombre");
        PlayerPrefs.DeleteKey($"Partida{idPartida}_Progreso");

        partidasManager.ReorganizarPartidas(idPartida);
        Destroy(gameObject);
    }

    public void ReiniciarPartida ()
    {
        string escenaInicial = "Juego";
        PlayerPrefs.SetString($"Partida{idPartida}_Progreso", escenaInicial);
        PlayerPrefs.Save();
        SceneManager.LoadScene(escenaInicial);
        Time.timeScale=1;
    }

    public void ToggleP1 ()
    {
        Opciones.SetActive(!Opciones.activeSelf);
    }
}
