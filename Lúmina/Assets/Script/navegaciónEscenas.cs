using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class navegaciónEscenas : MonoBehaviour
{
   public void regresar ()
    {
        SceneManager.LoadScene("Partidas");
    }
    public void Jugar ()
    {
        SceneManager.LoadScene("Juego");
    }
}
