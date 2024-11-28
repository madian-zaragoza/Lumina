using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovil : MonoBehaviour
{
    CharacterController controlador;

    // Variables p�blicas
    public float velocidad = 3.0f; // Velocidad de movimiento del jugador
    public float velocidadRotacion = 2.0f; // Sensibilidad de la c�mara
    public Transform camara; // Referencia a la c�mara del jugador
    public AudioClip sonidoCaminar; // Clip de sonido para caminar
    private AudioSource audioSource;

    float rotacionX = 0f;

    // Start is called before the first frame update
    void Start ()
    {

        controlador = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();

        if (controlador == null)
        {
            Debug.LogError("No se encontr� el componente CharacterController.");
        }
        if (audioSource == null)
        {
            Debug.LogError("No se encontr� el componente AudioSource.");
        }

        // Ocultar y bloquear el cursor para que no salga de la ventana del juego
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update ()
    {
        // Rotar la c�mara y el personaje seg�n el movimiento del rat�n
        float mouseX = Input.GetAxis("Mouse X") * velocidadRotacion;
        float mouseY = Input.GetAxis("Mouse Y") * velocidadRotacion;

        // Rotaci�n horizontal del personaje
        transform.Rotate(Vector3.up * mouseX);

        // Controlar la rotaci�n vertical de la c�mara (rotaci�n en X)
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f); // Limitar la rotaci�n vertical
        camara.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);

        // Obtener los valores del movimiento del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Direcci�n de movimiento relativa al personaje
        Vector3 direccion = transform.forward * vertical + transform.right * horizontal;

        // Normalizar el vector de movimiento y aplicar la velocidad
        direccion = direccion.normalized * velocidad;

        // Aplicar el movimiento al CharacterController
        controlador.Move(direccion * Time.deltaTime);

        // Reproducir el sonido de caminar si el personaje se est� moviendo
        if (direccion.magnitude > 0f)
        {
            if (!audioSource.isPlaying && sonidoCaminar != null)
            {
                audioSource.clip = sonidoCaminar;
                audioSource.Play();
            }
        }
        else
        {
            // Detener el sonido si el personaje no se est� moviendo
            audioSource.Stop();
        }
    }
}
