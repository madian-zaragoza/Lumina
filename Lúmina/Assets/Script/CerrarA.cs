using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarA : MonoBehaviour
{
    public ControladorOpciones PanelAjustes;
    // Start is called before the first frame update
    void Start ()
    {
        PanelAjustes = GameObject.FindGameObjectWithTag("Ajustes").GetComponent<ControladorOpciones>();
    }

    // Update is called once per frame
    void Update ()
    {

    }
   
    public void CerrarAjustes ()
    {
        PanelAjustes.Ajus.SetActive(false);
    }
}
