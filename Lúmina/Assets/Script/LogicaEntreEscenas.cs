using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEntreEscenas : MonoBehaviour
{
    private void Awake ()
    {
        var noDestruirEntreEscenas = FindObjectsOfType<LogicaEntreEscenas>(); // Busca todas las instancias
        if (noDestruirEntreEscenas.Length > 1) // Verifica si hay m�s de una instancia
        {
            Destroy(gameObject); // Destruye esta instancia para evitar duplicados
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Aseg�rate de que esta instancia persista entre escenas
        }
    }
}
