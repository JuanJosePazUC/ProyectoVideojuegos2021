using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tronco : MonoBehaviour
{
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private bool mirandoIzquierda;
    [SerializeField] private GameObject bala;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        if (!mirandoIzquierda)
        {
            Girar();
        }
    }

    public void Disparar()
    {
        Instantiate(bala, puntoDisparo.position, puntoDisparo.rotation);
    }

    public void Girar()
    {
        mirandoIzquierda = !mirandoIzquierda;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetContact(0).normal.y <= -0.9)
            {
                MovimientoJugador movimientoJugador = other.gameObject.GetComponent<MovimientoJugador>();
                movimientoJugador.Rebota();
                animator.SetTrigger("Golpe");
            }
        }
    }

}
