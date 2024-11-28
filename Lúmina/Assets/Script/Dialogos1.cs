using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogos1 : MonoBehaviour
{
    [System.Serializable]
    public class Dialog
    {
        public GameObject dialogObject; // Referencia al GameObject del di�logo
        public float delayAfterDialog;  // Tiempo de espera antes de pasar al siguiente
    }

    public List<Dialog> dialogs; // Lista de di�logos
    private int currentDialogIndex = 0;
    private bool isWaiting = false;

    public GameObject activatableCube; // Referencia al cubo que se activar� al finalizar los di�logos

    void Start ()
    {
        // Desactivar todos los di�logos al inicio
        foreach (var dialog in dialogs)
        {
            dialog.dialogObject.SetActive(false);
        }

        // Desactivar el cubo al inicio
        if (activatableCube != null)
        {
            activatableCube.SetActive(false);
        }

        // Mostrar el primer di�logo
        if (dialogs.Count > 0)
        {
            ShowDialog(currentDialogIndex);
        }
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isWaiting && currentDialogIndex < dialogs.Count)
        {
            StartCoroutine(NextDialog());
        }
    }

    private void ShowDialog (int index)
    {
        if (index < dialogs.Count)
        {
            dialogs[index].dialogObject.SetActive(true);
        }
    }

    private IEnumerator NextDialog ()
    {
        isWaiting = true;

        // Desactiva el di�logo actual
        dialogs[currentDialogIndex].dialogObject.SetActive(false);

        // Espera el tiempo configurado
        yield return new WaitForSeconds(dialogs[currentDialogIndex].delayAfterDialog);

        // Avanza al siguiente di�logo
        currentDialogIndex++;

        if (currentDialogIndex < dialogs.Count)
        {
            ShowDialog(currentDialogIndex);
        }
        else
        {
            // Si se completaron todos los di�logos, activa el cubo
            if (activatableCube != null)
            {
                activatableCube.SetActive(true);
            }
        }

        isWaiting = false;
    }
}
