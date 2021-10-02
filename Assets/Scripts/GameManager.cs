using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int cantidadFrutasTotal;
    private int cantidadFrutasRecolectadas;
    private int cantidadMinimaFrutas;
    private int cantidadPuntos;
    private int cantidadPuntosTemporal;

    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        GameManager.Instance.Inicializar();
    }

    private void Inicializar()
    {
        cantidadFrutasTotal = GameObject.FindGameObjectsWithTag("Fruta").Length;
        cantidadMinimaFrutas = cantidadFrutasTotal - 1;
        cantidadFrutasRecolectadas = 0;
        cantidadPuntosTemporal = 0;
    }

    private void AumentarPuntosTemporal(int cantidadPuntosEntrada)
    {
        cantidadPuntosTemporal += cantidadPuntosEntrada;
    }

    public void AumetarPuntos()
    {
        cantidadPuntos += cantidadPuntosTemporal;
    }

    public void RecogerFruta(int puntos)
    {
        cantidadFrutasRecolectadas += 1;
        AumentarPuntosTemporal(puntos);
        if (cantidadFrutasRecolectadas >= cantidadMinimaFrutas)
        {
            GameObject.FindGameObjectWithTag("BanderaFinal").GetComponent<BanderaFinal>().ActivarBandera();
        }
    }

}
