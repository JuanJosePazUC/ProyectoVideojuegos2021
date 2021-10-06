using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour
{
    [SerializeField] private GameObject jugador;
    [SerializeField] private Transform puntoSpawn;

    public void CrearJugador()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        GameObject jugador = GameManager.Instance.GetJugadores()[indexJugador];
        Instantiate(jugador, puntoSpawn.position, Quaternion.identity);
        AudioManager.Instance.Play("Appear");
    }
}
