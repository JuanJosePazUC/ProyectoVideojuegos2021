using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour
{
    [SerializeField] private GameObject jugador;
    [SerializeField] private Transform puntoSpawn;

    public void CrearJugador()
    {
        Instantiate(jugador, puntoSpawn.position, Quaternion.identity);
    }
}
