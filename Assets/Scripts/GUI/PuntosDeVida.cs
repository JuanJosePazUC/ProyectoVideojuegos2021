using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosDeVida : MonoBehaviour
{
    [SerializeField] private GameObject puntoVida;
    [SerializeField] private PuntoDeVida[] puntosVida;

    public void InicializarPuntosVida(int cantidadPuntosVida)
    {
        for (int i = 0; i < cantidadPuntosVida; i++)
        {
            Instantiate(puntoVida, transform.position, transform.rotation, gameObject.transform);
        }

        foreach (Transform child in this.transform)
        {
            puntosVida = gameObject.GetComponentsInChildren<PuntoDeVida>();
        }

    }


    public void CambiarVidaDaño(int daño)
    {
        int indexUltimaVida = 0;
        for (int i = puntosVida.Length - 1; i >= 0; i--)
        {
            if (puntosVida[i].GetVidaLlena())
            {
                indexUltimaVida = i;
                break;
            }
        }

        for (int i = indexUltimaVida; i > indexUltimaVida - daño; i--)
        {
            puntosVida[i].CambiarVacio();
        }
    }

}
