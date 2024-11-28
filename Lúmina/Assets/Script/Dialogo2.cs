using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo2 : MonoBehaviour
{
    public GameObject[] Dialogos;
    public GameObject Dialogo1;
    private GameObject currentDialogo; // Para guardar el di�logo actual activo
    private bool isDialogActive = false; // Para verificar si ya hay un di�logo activo

    private void OnTriggerEnter (Collider other)
    {
        if (isDialogActive) return; // Si hay un di�logo activo, no activar m�s

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
        // Verifica si se presiona la tecla E y hay un di�logo activo
        if (Input.GetKeyDown(KeyCode.E) && currentDialogo != null)
        {
            currentDialogo.SetActive(false); // Cierra el di�logo actual
            currentDialogo = null; // Limpia la referencia al di�logo actual
            isDialogActive = false; // Permite que se active un nuevo di�logo
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
        // Cierra cualquier di�logo activo antes de abrir uno nuevo
        if (currentDialogo != null)
        {
            currentDialogo.SetActive(false);
        }

        // Activa el nuevo di�logo y guarda la referencia al di�logo actual
        Dialogos[index].SetActive(true);
        currentDialogo = Dialogos[index];
        isDialogActive = true; // Marca que un di�logo est� activo
    }
}
