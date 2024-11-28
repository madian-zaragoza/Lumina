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
    public GameObject ba�o1;
    public GameObject ba�o2;
   
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
        if (other.gameObject.tag == "Ba�o 1")
        {
            Ba�o1();
        }
        if (other.gameObject.tag == "Ba�o 2")
        {
            Ba�o2();
        }
       

    }

    public void Sala ()
    {
        sala.SetActive(true);
        cocina.SetActive(false);
        rec1.SetActive(false);
        rec2.SetActive(false);
        rec3.SetActive(false);
        ba�o1.SetActive(false);
        ba�o2.SetActive(false);
    }
    public void Cocina ()
    {
        sala.SetActive(false);
        cocina.SetActive(true);
        rec1.SetActive(false);
        rec2.SetActive(false);
        rec3.SetActive(false);
        ba�o1.SetActive(false);
        ba�o2.SetActive(false);
    }
    public void Recamara1 ()
    {
        sala.SetActive(false);
        cocina.SetActive(false);
        rec1.SetActive(true);
        rec2.SetActive(false);
        rec3.SetActive(false);
        ba�o1.SetActive(false);
        ba�o2.SetActive(false);
    }
    public void Recamara2 ()
    {
        sala.SetActive(false);
        cocina.SetActive(false);
        rec1.SetActive(false);
        rec2.SetActive(true);
        rec3.SetActive(false);
        ba�o1.SetActive(false);
        ba�o2.SetActive(false);
    }
    public void Recamara3 ()
    {
        sala.SetActive(false);
        cocina.SetActive(false);
        rec1.SetActive(false);
        rec2.SetActive(false);
        rec3.SetActive(true);
        ba�o1.SetActive(false);
        ba�o2.SetActive(false);
    }
    public void Ba�o1 ()
    {
        sala.SetActive(false);
        cocina.SetActive(false);
        rec1.SetActive(false);
        rec2.SetActive(false);
        rec3.SetActive(false);
        ba�o1.SetActive(true);
        ba�o2.SetActive(false);
    }
    public void Ba�o2 ()
    {
        sala.SetActive(false);
        cocina.SetActive(false);
        rec1.SetActive(false);
        rec2.SetActive(false);
        rec3.SetActive(false);
        ba�o1.SetActive(false);
        ba�o2.SetActive(true);
    }
   
}
