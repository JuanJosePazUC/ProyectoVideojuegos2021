using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiker : MonoBehaviour
{
    [SerializeField] private int daño;
    [SerializeField] private float tiempoCambioEstado;
    [SerializeField] private bool espinasFuera = true;
    private float tiempoRestanteCambio;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        tiempoRestanteCambio = tiempoCambioEstado;
    }

    private void Update()
    {
        tiempoRestanteCambio -= Time.deltaTime;
        if (tiempoRestanteCambio <= 0)
        {
            CambiarEstado();
        }
    }

    private void CambiarEstado()
    {
        tiempoRestanteCambio = tiempoCambioEstado;
        espinasFuera = !espinasFuera;
        if(espinasFuera){
            AudioManager.Instance.Play("Spikes");
        }
        animator.SetTrigger("CambiarEstado");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (espinasFuera)
            {
                other.gameObject.GetComponent<CombateJugador>().TomarDaño(daño);
            }
            else
            {
                if (other.GetContact(0).normal.y <= -0.9)
                {
                    MovimientoJugador movimientoJugador = other.gameObject.GetComponent<MovimientoJugador>();
                    movimientoJugador.Rebota();
                }
            }
        }
    }
}
