using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto1 : MonoBehaviour
{
    public string type; // A, B o C

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player")) // Comprobamos si el jugador colisionó con el objeto
        {
            // Buscar el script SpawnerManager y llamar a su función para manejar la recolección
            Spawn1 manager = FindObjectOfType<Spawn1>();
            manager.ObjectCollected(type);
            Destroy(gameObject); // Destruir el objeto recogido
        }
    }
}
