using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto2 : MonoBehaviour
{
    public string type; // Tipo de objeto: "Manta", "Fruta" o "Zapato"

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player")) // Verificar si el jugador colision� con el objeto
        {
            // Buscar el script Spawn2 y llamar a su funci�n para manejar la recolecci�n
            Spawn2 manager = FindObjectOfType<Spawn2>();

            if (manager != null)
            {
                manager.ObjectCollected(type, transform); // Pasar el tipo del objeto y su posici�n
                Destroy(gameObject); // Destruir el objeto recogido
            }
            else
            {
                Debug.LogError("No se encontr� un script Spawn2 en la escena.");
            }
        }
    }
}
