using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rino : MonoBehaviour
{
    private Animator animator;
    private bool mirandoIzquierda = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Girar()
    {
        mirandoIzquierda = !mirandoIzquierda;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    public bool GetMirandoIzquierda()
    {
        return mirandoIzquierda;
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
