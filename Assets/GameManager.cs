using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int cantidadFrutasTotal;
    private int cantidadFrutasRecolectadas;
    private int cantidadMinimaFrutas;
    private int cantidadPuntos;
    private GameObject banderaFinal;

    private void Start()
    {
        cantidadFrutasTotal = GameObject.FindGameObjectsWithTag("Fruta").Length;
        banderaFinal = GameObject.FindGameObjectWithTag("BanderaFinal");
        cantidadMinimaFrutas = cantidadFrutasTotal - 1;
    }

    private void AumentarPuntos(int cantidadPuntosEntrada)
    {
        cantidadPuntos += cantidadPuntosEntrada;
    }

    public void RecogerFruta(int puntos)
    {
        cantidadFrutasRecolectadas += 1;
        AumentarPuntos(puntos);
        if (cantidadFrutasRecolectadas >= cantidadMinimaFrutas)
        {
            banderaFinal.GetComponent<BanderaFinal>().ActivarBandera();
        }
    }

}
