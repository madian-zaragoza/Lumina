using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MostrarPaneles : MonoBehaviour
{
    public GameObject Pausa;

    public GameObject Salir;

    private void Start ()
    {
        //PantallaAjustes = GameObject.FindGameObjectsWithTag("EntreEscenas")
    }
    void Update ()
    {
        // Detecta si la tecla Q ha sido presionada
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Pausar();
        }
    }

    private void TogglePanel (GameObject Pausa)
    {
        bool isActive = Pausa.activeSelf; // Verifica si el panel está activo
        Pausa.SetActive(!isActive); // Cambia el estado del panel de pausa

        // Cambia entre pausa y reanudar el juego
        if (Pausa.activeSelf)
        {
            Time.timeScale = 0; // Pausa el juego
            Cursor.visible = true; // Muestra el cursor
            Cursor.lockState = CursorLockMode.None; // Libera el cursor para moverse
        }
        else
        {
            Time.timeScale = 1; // Reanuda el juego
            Cursor.visible = false; // Oculta el cursor
            Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla
        }
    }

    public void Pausar ()
    {
        TogglePanel(Pausa);
    }
    public void salir ()
    {
        Salir.SetActive(true);
    }
    public void volver ()
    {
        SceneManager.LoadScene("Partidas", LoadSceneMode.Single);
    }
    public void CerrarPanel ()
    {
        Salir.SetActive(false);
    }
    public void CerrarJuego ()
    {
        Application.Quit();
    }
    public void Reiniciar ()
    {
        Time.timeScale = 1; // Asegura que el tiempo esté en escala normal al reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Carga de nuevo la escena actual
    }
}
