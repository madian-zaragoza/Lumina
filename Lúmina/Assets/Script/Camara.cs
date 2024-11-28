using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public float sensibilidadMouse = 100f;
    public Transform jugadorCuerpo; // Asigna el objeto del jugador principal (el GameObject que se moverá y rotará).

    float rotacionX = 0f;

    void Start ()
    {
        // Oculta y bloquea el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update ()
    {
        // Obtener el movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;

        // Rotar hacia arriba/abajo la cámara
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f); // Limita la rotación para no voltear demasiado la cámara

        // Aplica la rotación al objeto de la cámara
        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);

        // Rotar hacia los lados el cuerpo del jugador
        jugadorCuerpo.Rotate(Vector3.up * mouseX);
    }
}
