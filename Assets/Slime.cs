using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private LayerMask queEsPared;
    [SerializeField] private float distancia;
    [SerializeField] private int daño;
    private bool mirandoIzquierda = true;
    private bool tocoPared;
    private Animator animator;
    private Rigidbody2D rb2D;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (mirandoIzquierda)
        {
            tocoPared = Physics2D.Raycast(transform.position, Vector2.left, distancia, queEsPared);
        }
        else
        {
            tocoPared = Physics2D.Raycast(transform.position, Vector2.right, distancia, queEsPared);
        }

        if (tocoPared)
        {
            Girar();
        }
    }
    private void FixedUpdate()
    {
        if (mirandoIzquierda)
        {
            rb2D.MovePosition(rb2D.position + Vector2.left * velocidadMovimiento * Time.fixedDeltaTime);
        }
        else
        {
            rb2D.MovePosition(rb2D.position + Vector2.right * velocidadMovimiento * Time.fixedDeltaTime);
        }
    }
    private void Girar()
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
            }
            else
            {
                other.gameObject.GetComponent<CombateJugador>().TomarDaño(daño);
            }
        }
    }

}
