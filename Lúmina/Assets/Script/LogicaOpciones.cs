using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LogicaOpciones : MonoBehaviour
{
    public ControladorOpciones PanelAjustes;
    // Start is called before the first frame update
    void Start()
    {
        PanelAjustes = GameObject.FindGameObjectWithTag("Ajustes").GetComponent<ControladorOpciones>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void MostrarAjustes ()
    {
        PanelAjustes.Ajus.SetActive(true);
    }
  
}
