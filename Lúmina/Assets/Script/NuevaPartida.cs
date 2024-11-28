using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NuevaPartida : MonoBehaviour
{
   public void CrearPartida ()
    {
        SceneManager.LoadScene("Crear");
    }
    public void Regresar ()
    {
        SceneManager.LoadScene("Menú principal");
    }
}
