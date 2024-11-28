using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2 : MonoBehaviour
{
    public Transform[] spawners; // Array de spawners
    public GameObject[] objectsA; // Array de objetos tipo A (mantas)
    public GameObject[] objectsB; // Array de objetos tipo B (frutas)
    public GameObject[] objectsC; // Array de objetos tipo C (zapatos)

    private GameObject[] spawnedObjects; // Array para guardar los objetos generados

    private int collectedA = 0; // Cantidad de objetos tipo A recogidos
    private int collectedB = 0; // Cantidad de objetos tipo B recogidos
    private int collectedC = 0; // Cantidad de objetos tipo C recogidos
    private int maxCollectibles = 6; // Objetos necesarios para ganar

    private float timer = 180f; // Tiempo límite de 90 segundos
    private bool gameLost = false;
    private bool gameStarted = false; // Controla si el juego ha comenzado

    public GameObject gameOverObject; // Referencia al GameObject de Game Over
    public GameObject cuboNivel2; // GameObject del cubo para pasar al siguiente nivel

    public GameObject[] dialogObjects; // Array de los diálogos
    private int currentDialogIndex = 0; // Índice del diálogo actual
    public float dialogDelay = 1f; // Tiempo de espera entre diálogos

    void Start ()
    {
        spawnedObjects = new GameObject[spawners.Length];
        cuboNivel2.SetActive(false);
        gameOverObject.SetActive(false);

        // Asegurarse de que solo el primer diálogo esté activo al inicio
        for (int i = 0; i < dialogObjects.Length; i++)
        {
            dialogObjects[i].SetActive(i == 0);
        }

        Debug.Log("Esperando a que los diálogos terminen...");
    }

    void Update ()
    {
        if (!gameStarted)
        {
            HandleDialogInput();
        }
        else if (!gameLost)
        {
            // Actualizar el temporizador
            timer -= Time.deltaTime;

            // Verificar si el tiempo ha terminado
            if (timer <= 0f)
            {
                CheckGameOver();
            }

            // Asegurar que todos los spawners estén ocupados
            RespawnEmptySpawners();
        }
    }

    void HandleDialogInput ()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Si el jugador presiona 'E'
        {
            if (currentDialogIndex < dialogObjects.Length)
            {
                dialogObjects[currentDialogIndex].SetActive(false); // Ocultar diálogo actual

                currentDialogIndex++;
                if (currentDialogIndex < dialogObjects.Length)
                {
                    // Activar el siguiente diálogo después de un pequeño retraso
                    StartCoroutine(ShowNextDialog());
                }
                else
                {
                    // Si no hay más diálogos, iniciar el juego
                    StartGame();
                }
            }
        }
    }

    IEnumerator ShowNextDialog ()
    {
        yield return new WaitForSeconds(dialogDelay); // Esperar antes de mostrar el siguiente diálogo
        dialogObjects[currentDialogIndex].SetActive(true); // Mostrar el siguiente diálogo
    }

    public void StartGame ()
    {
        Debug.Log("¡Los diálogos han terminado! Iniciando recolección y temporizador...");
        gameStarted = true;
        SpawnObjects(); // Generar los objetos en los spawners
    }

    void SpawnObjects ()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            if (spawnedObjects[i] == null)
            {
                // Generar un objeto aleatorio entre los tres tipos
                int randomType = Random.Range(0, 3);
                GameObject objectToSpawn = null;

                switch (randomType)
                {
                    case 0:
                        objectToSpawn = objectsA[Random.Range(0, objectsA.Length)];
                        break;
                    case 1:
                        objectToSpawn = objectsB[Random.Range(0, objectsB.Length)];
                        break;
                    case 2:
                        objectToSpawn = objectsC[Random.Range(0, objectsC.Length)];
                        break;
                }

                spawnedObjects[i] = Instantiate(objectToSpawn, spawners[i].position, Quaternion.identity);
            }
        }
    }

    public void ObjectCollected (string type, Transform spawnPoint)
    {
        // Actualizar la cantidad de objetos recolectados según el tipo
        switch (type)
        {
            case "Manta":
                collectedA++;
                break;
            case "Fruta":
                collectedB++;
                break;
            case "Zapato":
                collectedC++;
                break;
        }

        // Destruir el objeto recolectado
        for (int i = 0; i < spawnedObjects.Length; i++)
        {
            if (spawnedObjects[i] != null && spawnedObjects[i].transform.position == spawnPoint.position)
            {
                Destroy(spawnedObjects[i]);
                spawnedObjects[i] = null;
                break;
            }
        }

        // Verificar si ha recolectado la cantidad necesaria de cada tipo
        CheckVictory();
    }

    private void RespawnEmptySpawners ()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            if (spawnedObjects[i] == null)
            {
                // Generar un nuevo objeto aleatorio
                int randomType = Random.Range(0, 3);
                GameObject objectToSpawn = null;

                switch (randomType)
                {
                    case 0:
                        objectToSpawn = objectsA[Random.Range(0, objectsA.Length)];
                        break;
                    case 1:
                        objectToSpawn = objectsB[Random.Range(0, objectsB.Length)];
                        break;
                    case 2:
                        objectToSpawn = objectsC[Random.Range(0, objectsC.Length)];
                        break;
                }

                spawnedObjects[i] = Instantiate(objectToSpawn, spawners[i].position, Quaternion.identity);
            }
        }
    }

    private void CheckVictory ()
    {
        if (collectedA >= maxCollectibles && collectedB >= maxCollectibles && collectedC >= maxCollectibles)
        {
            Debug.Log("¡Has ganado! Has recogido 6 de cada tipo de objetos.");

            // Detener el temporizador
            timer = 0f;

            // Activar el cubo para pasar al siguiente nivel
            cuboNivel2.SetActive(true);

            // Detener el tiempo del juego
            Time.timeScale = 0;
        }
    }

    private void CheckGameOver ()
    {
        if (collectedA < maxCollectibles || collectedB < maxCollectibles || collectedC < maxCollectibles)
        {
            gameLost = true;
            Debug.Log("¡Has perdido! No recogiste los objetos necesarios en 90 segundos.");
            gameOverObject.SetActive(true);

            // Mostrar el cursor y desbloquearlo
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            // Detener el tiempo del juego
            Time.timeScale = 0;
        }
    }

}
