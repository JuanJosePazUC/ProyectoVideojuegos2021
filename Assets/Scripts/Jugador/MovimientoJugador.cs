using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    private float inputX;
    [SerializeField] private float velocidadDeMovimiento;
    [Range(0, 0.3f)] [SerializeField] private float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    private bool puedeMover = false;

    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCajaSuelo;
    [SerializeField] private bool enSuelo;
    [SerializeField] private float velocidadMaximaY;
    private bool salto = false;

    [Header("Animacion")]
    private Animator animator;

    [Header("SaltoPared")]
    [SerializeField] private Transform controladorPared;
    [SerializeField] private Vector3 dimensionesCajaPared;
    [SerializeField] private bool enPared;
    [SerializeField] private bool deslizando;
    [SerializeField] private float velocidadDeslizar;
    [SerializeField] private float fuerzaSaltoParedX;
    [SerializeField] private float fuerzaSaltoParedY;
    [SerializeField] private bool saltandoDePared;
    [SerializeField] private float tiempoSaltoPared;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        movimientoHorizontal = inputX * velocidadDeMovimiento;

        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));
        animator.SetFloat("VelocidadY", rb2D.velocity.y);
        animator.SetBool("Deslizando", deslizando);

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }

        if (!enSuelo && enPared && inputX != 0)
        {
            deslizando = true;
        }
        else
        {
            deslizando = false;
        }
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCajaSuelo, 0f, queEsSuelo);
        enPared = Physics2D.OverlapBox(controladorPared.position, dimensionesCajaPared, 0f, queEsSuelo);
        animator.SetBool("enSuelo", enSuelo);
        animator.SetBool("enPared", enPared);

        if (puedeMover)
        {
            Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);
        }

        if (rb2D.velocity.y >= velocidadMaximaY)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, velocidadMaximaY);
        }

        salto = false;

        if (deslizando)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, Mathf.Clamp(rb2D.velocity.y, -velocidadDeslizar, float.MaxValue));
        }
    }

    private void Mover(float mover, bool saltar)
    {
        if (!saltandoDePared)
        {
            Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
            rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);
        }

        if (mover > 0 && !mirandoDerecha)
        {
            //Girar
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            //Girar
            Girar();
        }

        if (enSuelo && saltar && !deslizando)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }

        if (enPared && saltar && deslizando)
        {
            enPared = false;
            rb2D.velocity = new Vector2(fuerzaSaltoParedX * -inputX, fuerzaSaltoParedY);
            StartCoroutine(CambioSaltoPared());
        }
    }

    public void Rebota()
    {
        rb2D.AddForce(new Vector2(0f, fuerzaDeSalto * 1.5f));
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    public void PuedeMoverFalse()
    {
        puedeMover = false;
    }

    public void PuedeMoverTrue()
    {
        puedeMover = true;
    }

    public bool GetMirandoDerecha()
    {
        return mirandoDerecha;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCajaSuelo);
        Gizmos.DrawWireCube(controladorPared.position, dimensionesCajaPared);
    }


    IEnumerator CambioSaltoPared()
    {
        saltandoDePared = true;
        yield return new WaitForSeconds(tiempoSaltoPared);
        saltandoDePared = false;
    }
}
