using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosDeVida : MonoBehaviour
{
    [SerializeField] private GameObject puntosVida;
    private float vidaMaxima;

    private void Start() {
        Instantiate(puntosVida, transform.position, transform.rotation, gameObject.transform);
    }

    private void CambiarVida(int daño){
        
    }
}
