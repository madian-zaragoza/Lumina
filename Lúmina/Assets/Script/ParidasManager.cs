using UnityEngine;

public class PartidasManager : MonoBehaviour
{
    public GameObject partidaPrefab;
    public Transform listaPartidas;

    void Start ()
    {
        CargarPartidas();

    }

    public void CargarPartidas ()
    {
        foreach (Transform child in listaPartidas)
        {
            Destroy(child.gameObject);
        }

        int cantidadPartidas = PlayerPrefs.GetInt("CantidadPartidas", 0);

        for (int i = 0; i < cantidadPartidas; i++)
        {
            string nombrePartida = PlayerPrefs.GetString($"Partida{i}_Nombre", "Sin Nombre");
            GameObject nuevaPartida = Instantiate(partidaPrefab, listaPartidas);

            PartidaUI partidaUI = nuevaPartida.GetComponent<PartidaUI>();
            if (partidaUI != null)
            {
                partidaUI.ConfigurarPartida(nombrePartida, i, this);
            }
        }
    }

    public void ReorganizarPartidas (int idEliminado)
    {
        int cantidadPartidas = PlayerPrefs.GetInt("CantidadPartidas", 0);

        for (int i = idEliminado; i < cantidadPartidas - 1; i++)
        {
            string nombreSiguiente = PlayerPrefs.GetString($"Partida{i + 1}_Nombre", "Sin Nombre");
            string progresoSiguiente = PlayerPrefs.GetString($"Partida{i + 1}_Progreso", "Juego");

            PlayerPrefs.SetString($"Partida{i}_Nombre", nombreSiguiente);
            PlayerPrefs.SetString($"Partida{i}_Progreso", progresoSiguiente);
        }

        PlayerPrefs.DeleteKey($"Partida{cantidadPartidas - 1}_Nombre");
        PlayerPrefs.DeleteKey($"Partida{cantidadPartidas - 1}_Progreso");

        PlayerPrefs.SetInt("CantidadPartidas", cantidadPartidas - 1);
        PlayerPrefs.Save();

        CargarPartidas();
    }
}
