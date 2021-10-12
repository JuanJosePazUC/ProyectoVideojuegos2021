using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calavera_Idle1Behaviour : StateMachineBehaviour
{
    private Calavera calavera;
    [SerializeField] float tiempoEntreDisparos;
    private float tiempoSiguienteDisparo;
    [SerializeField] float tiempoEstado;
    private float tiempoSiguienteEstado;
    private Transform posJugador;
    private Rigidbody2D rb2D;
    private float velocidad;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        calavera = animator.GetComponent<Calavera>();
        rb2D = animator.GetComponent<Rigidbody2D>();
        calavera.Activar();
        velocidad = calavera.GetVelocidadMovimiento();
        tiempoSiguienteDisparo = tiempoEntreDisparos;
        tiempoSiguienteEstado = tiempoEstado;

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            posJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        tiempoSiguienteDisparo -= Time.deltaTime;
        tiempoSiguienteEstado -= Time.deltaTime;

        rb2D.velocity = new Vector2(velocidad, velocidad) * calavera.GetDireccion();



        if (tiempoSiguienteDisparo <= 0)
        {
            if (posJugador)
            {
                calavera.CambiarRotacionDisparo(posJugador);
            }
            calavera.Disparar();
            tiempoSiguienteDisparo = tiempoEntreDisparos;
        }
        if (tiempoSiguienteEstado <= 0)
        {
            animator.SetTrigger("Cambio");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2D.velocity = new Vector2(0, 0);
        calavera.Desactivar();
    }
}
