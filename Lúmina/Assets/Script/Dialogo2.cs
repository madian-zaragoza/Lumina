using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo2 : MonoBehaviour
{
    public GameObject[] Dialogos;
    public GameObject Dialogo1;
    private GameObject currentDialogo; // Para guardar el diálogo actual activo
    private bool isDialogActive = false; // Para verificar si ya hay un diálogo activo

    private void OnTriggerEnter (Collider other)
    {
        if (isDialogActive) return; // Si hay un diálogo activo, no activar más

        if (other.gameObject.tag == "Cabello")
        {
            Cabello();
        }
        if (other.gameObject.tag == "Altura")
        {
            Altura();
        }
        if (other.gameObject.tag == "Piel")
        {
            Piel();
        }
    }

    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Dialogo1.SetActive(false);
        }
        // Verifica si se presiona la tecla E y hay un diálogo activo
        if (Input.GetKeyDown(KeyCode.E) && currentDialogo != null)
        {
            currentDialogo.SetActive(false); // Cierra el diálogo actual
            currentDialogo = null; // Limpia la referencia al diálogo actual
            isDialogActive = false; // Permite que se active un nuevo diálogo
        }
    }

    public void Cabello ()
    {
        ActivateDialog(0);
    }

    public void Altura ()
    {
        ActivateDialog(1);
    }

    public void Piel ()
    {
        ActivateDialog(2);
    }

    private void ActivateDialog (int index)
    {
        // Cierra cualquier diálogo activo antes de abrir uno nuevo
        if (currentDialogo != null)
        {
            currentDialogo.SetActive(false);
        }

        // Activa el nuevo diálogo y guarda la referencia al diálogo actual
        Dialogos[index].SetActive(true);
        currentDialogo = Dialogos[index];
        isDialogActive = true; // Marca que un diálogo está activo
    }
}
