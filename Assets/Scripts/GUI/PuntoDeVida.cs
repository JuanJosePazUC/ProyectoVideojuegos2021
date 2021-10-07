using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntoDeVida : MonoBehaviour
{
    [SerializeField] private GameObject lleno;
    [SerializeField] private GameObject vacio;
    private bool vidallena = true;

    public void CambiarLleno()
    {
        lleno.SetActive(true);
        vacio.SetActive(false);
        vidallena = true;
    }

    public void CambiarVacio()
    {
        lleno.SetActive(false);
        vacio.SetActive(true);
        vidallena = false;
    }

    public bool GetVidaLlena()
    {
        return vidallena;
    }
}
