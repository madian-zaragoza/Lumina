using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuP : MonoBehaviour
{
    public GameObject Controles;
    public GameObject Creditos;
    public GameObject Salir;
    public void Iniciar ()
    {
        SceneManager.LoadScene("Partidas", LoadSceneMode.Single);
    }
    public void Control ()
    {
        Controles.SetActive(true);
    }
    public void credito ()
    {
        Creditos.SetActive(true);
    }
    public void salir ()
    {
        Salir.SetActive(true);
    }
    public void CerrarPanel ()

    {
        Time.timeScale=1;
        Controles.SetActive(false);
        Creditos.SetActive(false);
        Salir.SetActive(false);
    }
    public void CerrarJuego ()
    {
        Application.Quit();
    }
}
