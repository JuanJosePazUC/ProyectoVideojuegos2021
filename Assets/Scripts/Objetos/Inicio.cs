using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour
{
    [SerializeField] private float tiempoInicio;
    [SerializeField] private GameObject jugador;
    [SerializeField] private Transform puntoSpawn;

    private void Start()
    {
        StartCoroutine("CrearJugadorCR");
    }

    private IEnumerator CrearJugadorCR()
    {
        yield return new WaitForSeconds(tiempoInicio);
        Instantiate(jugador, puntoSpawn.position, Quaternion.identity);
    }
}
