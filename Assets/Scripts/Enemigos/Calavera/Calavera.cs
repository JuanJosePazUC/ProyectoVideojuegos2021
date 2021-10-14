using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calavera : MonoBehaviour
{
    private bool activado;
    [SerializeField] private int daño;
    [SerializeField] private int vidaMaxima;
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private GameObject balaCalavera;
    private int vidaActual;
    private bool mirandoDerecha = true;
    private Animator animator;
    [SerializeField] private Vector2 direccion;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private GameObject plataforma;
    [SerializeField] private GameObject efectoMuerte;

    private void Start()
    {
        animator = GetComponent<Animator>();
        vidaActual = vidaMaxima;
        AudioManager.Instance.StopAll();
        AudioManager.Instance.Play("FinalBattle");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (other.GetContact(0).normal.y == -1 && !activado)
            {
                MovimientoJugador movimientoJugador = other.gameObject.GetComponent<MovimientoJugador>();
                movimientoJugador.Rebota();
                TomarDaño();
            }
            else
            {
                other.gameObject.GetComponent<CombateJugador>().TomarDaño(daño);
            }
        }

        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Suelo"))
        {
            CambiarDireccion(other.GetContact(0).normal);
        }
    }

    public void CambiarDireccion(Vector2 valor)
    {
        if (valor.x < -0.1 || valor.x > 0.1)
        {
            direccion = new Vector2(direccion.x * -1, direccion.y);
            Girar();
        }

        if (valor.y < -0.1 || valor.y > 0.1)
        {
            direccion = new Vector2(direccion.x, direccion.y * -1);
        }
    }

    public void Disparar()
    {
        Instantiate(balaCalavera, puntoDisparo.position, puntoDisparo.rotation);
        AudioManager.Instance.Play("Shot");
    }

    public void CambiarRotacionDisparo(Transform objetivo)
    {
        Vector3 dir = objetivo.position - puntoDisparo.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        puntoDisparo.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    public void Activar()
    {
        activado = true;
    }

    public void Desactivar()
    {
        activado = false;
    }

    private void TomarDaño()
    {
        vidaActual -= 1;
        animator.SetTrigger("Golpe");
        activado = true;
        if (vidaActual <= 0)
        {
            Muerte();
        }
        velocidadMovimiento += 3;
    }

    private void Muerte()
    {
        plataforma.SetActive(false);
        GameObject efecto = Instantiate(efectoMuerte, transform.position + new Vector3(0, 0, -1), transform.rotation);
        efecto.transform.eulerAngles = new Vector3(efecto.transform.eulerAngles.x - 90, 0, 0);
        Destroy(gameObject);
    }

    public Vector2 GetDireccion()
    {
        return direccion;
    }

    public float GetVelocidadMovimiento()
    {
        return velocidadMovimiento;
    }
}
