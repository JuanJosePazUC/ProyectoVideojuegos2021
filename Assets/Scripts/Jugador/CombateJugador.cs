using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] private int puntosDeVida;
    [SerializeField] private int puntosDeVidaMaximos;
    [SerializeField] private float tiempoIgnorarColisiones;
    [SerializeField] private Vector2 fuerzaGolpe;
    private MovimientoJugador movimientoJugador;
    private Animator animator;
    private Rigidbody2D rb2D;

    private void Start()
    {
        puntosDeVida = puntosDeVidaMaximos;
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        movimientoJugador = GetComponent<MovimientoJugador>();
        SetPuntosDeVida();
    }

    public void TomarDaño(int dañoEntrante)
    {
        puntosDeVida -= dañoEntrante;
        StartCoroutine(DesactivarColisiones());
        SetPuntosDeVida();
        animator.SetTrigger("Golpe");
        FuerzaGolpe();
    }

    public void Curar(int curacionEntrante)
    {
        if (puntosDeVida + curacionEntrante > puntosDeVidaMaximos)
        {
            puntosDeVida = puntosDeVidaMaximos;
        }
        else
        {
            puntosDeVida += curacionEntrante;
        }

        SetPuntosDeVida();
    }

    public void Muerte()
    {
        Destroy(this.gameObject);
    }

    private void SetPuntosDeVida()
    {
        animator.SetInteger("Vida", puntosDeVida);
    }

    IEnumerator DesactivarColisiones()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        yield return new WaitForSeconds(tiempoIgnorarColisiones);
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
    private void FuerzaGolpe()
    {
        int direccionMovimiento = 1;
        if (movimientoJugador.GetMirandoDerecha())
        {
            direccionMovimiento *= -1;
        }
        rb2D.AddForce(new Vector2(fuerzaGolpe.x * direccionMovimiento, fuerzaGolpe.y), ForceMode2D.Impulse);
    }

    private void OnDestroy()
    {
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
