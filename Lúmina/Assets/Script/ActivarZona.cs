using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarZona : MonoBehaviour
{
    //Objetos
    public GameObject sala;
    public GameObject cocina;
    public GameObject rec1;
    public GameObject rec2;
    public GameObject rec3;
    public GameObject baño1;
    public GameObject baño2;
   
    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "sala")
        {
            Sala();
        }
        if (other.gameObject.tag == "Cocina")
        {
            Cocina();
        }
        if (other.gameObject.tag == "Recamara 1")
        {
            Recamara1();
        }
        if (other.gameObject.tag == "Recamara 2")
        {
            Recamara2();
        }
        if (other.gameObject.tag == "Recamara 3")
        {
            Recamara3();
        }
        if (other.gameObject.tag == "Baño 1")
        {
            Baño1();
        }
        if (other.gameObject.tag == "Baño 2")
        {
            Baño2();
        }
       

    }

    public void Sala ()
    {
        sala.SetActive(true);
        cocina.SetActive(false);
        rec1.SetActive(false);
        rec2.SetActive(false);
        rec3.SetActive(false);
        baño1.SetActive(false);
        baño2.SetActive(false);
    }
    public void Cocina ()
    {
        sala.SetActive(false);
        cocina.SetActive(true);
        rec1.SetActive(false);
        rec2.SetActive(false);
        rec3.SetActive(false);
        baño1.SetActive(false);
        baño2.SetActive(false);
    }
    public void Recamara1 ()
    {
        sala.SetActive(false);
        cocina.SetActive(false);
        rec1.SetActive(true);
        rec2.SetActive(false);
        rec3.SetActive(false);
        baño1.SetActive(false);
        baño2.SetActive(false);
    }
    public void Recamara2 ()
    {
        sala.SetActive(false);
        cocina.SetActive(false);
        rec1.SetActive(false);
        rec2.SetActive(true);
        rec3.SetActive(false);
        baño1.SetActive(false);
        baño2.SetActive(false);
    }
    public void Recamara3 ()
    {
        sala.SetActive(false);
        cocina.SetActive(false);
        rec1.SetActive(false);
        rec2.SetActive(false);
        rec3.SetActive(true);
        baño1.SetActive(false);
        baño2.SetActive(false);
    }
    public void Baño1 ()
    {
        sala.SetActive(false);
        cocina.SetActive(false);
        rec1.SetActive(false);
        rec2.SetActive(false);
        rec3.SetActive(false);
        baño1.SetActive(true);
        baño2.SetActive(false);
    }
    public void Baño2 ()
    {
        sala.SetActive(false);
        cocina.SetActive(false);
        rec1.SetActive(false);
        rec2.SetActive(false);
        rec3.SetActive(false);
        baño1.SetActive(false);
        baño2.SetActive(true);
    }
   
}
