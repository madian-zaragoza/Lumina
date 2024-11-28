using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : MonoBehaviour
{
    public Transform[] spawners; // Array de spawners
    public GameObject[] objectsA; // Array de objetos tipo A
    public GameObject[] objectsB; // Array de objetos tipo B
    public GameObject[] objectsC; // Array de objetos tipo C

    private GameObject[] spawnedObjects; // Array para guardar los objetos generados

    private bool collectedA = false;
    private bool collectedB = false;
    private bool collectedC = false;
    private float timer = 90f; // Tiempo límite de 90 segundos
    private bool gameLost = false;

    public GameObject gameOverObject; // Referencia al GameObject de Game Over
    public GameObject cuboNivel2; // GameObject del cubo para pasar al siguiente nivel

    void Start ()
    {
        spawnedObjects = new GameObject[spawners.Length];

        // Llenar los spawners con los objetos aleatoriamente
        SpawnObjects(objectsA);
        SpawnObjects(objectsB);
        SpawnObjects(objectsC);

        // Asegúrate de que el cubo esté desactivado al inicio
        cuboNivel2.SetActive(false);
    }

    void Update ()
    {
        if (!gameLost)
        {
            // Actualizar el temporizador solo si el jugador no ha ganado
            timer -= Time.deltaTime;

            // Verificar si el tiempo ha terminado
            if (timer <= 0f)
            {
                CheckGameOver();
            }
        }
    }

    void SpawnObjects (GameObject[] objects)
    {
        foreach (var obj in objects)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, spawners.Length);
            } while (spawnedObjects[randomIndex] != null);

            spawnedObjects[randomIndex] = Instantiate(obj, spawners[randomIndex].position, Quaternion.identity);
        }
    }

    public void ObjectCollected (string type)
    {
        // Marcar el tipo recogido y destruir los objetos del mismo tipo
        switch (type)
        {
            case "Cabello":
                collectedA = true;
                break;
            case "Altura":
                collectedB = true;
                break;
            case "Piel":
                collectedC = true;
                break;
        }

        foreach (var spawnedObject in spawnedObjects)
        {
            if (spawnedObject != null && spawnedObject.CompareTag(type))
            {
                Destroy(spawnedObject);
            }
        }

        // Verificar si ha recolectado todos los tipos
        CheckVictory();
    }

    private void CheckVictory ()
    {
        if (collectedA && collectedB && collectedC)
        {
            Debug.Log("¡Has ganado! Has recogido todos los tipos de objetos.");

            // Detener el temporizador
            timer = 0f;

            // Activar el cubo para pasar al siguiente nivel
            cuboNivel2.SetActive(true);

        
        }
    }

    private void CheckGameOver ()
    {
        if (!collectedA || !collectedB || !collectedC)
        {
            gameLost = true;
            Debug.Log("¡Has perdido! No recogiste todos los tipos en 90 segundos.");

            // Mostrar el GameObject de Game Over
            gameOverObject.SetActive(true);

            // Mostrar el cursor y desbloquearlo
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            // Detener el tiempo del juego
            Time.timeScale = 0;
        }
    }

}
