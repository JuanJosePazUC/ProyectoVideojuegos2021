using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rino_IdleBehaviour : StateMachineBehaviour
{
    [SerializeField] private bool tocoJugador;
    [SerializeField] private float distancia;
    [SerializeField] private LayerMask queEsJugador;
    private Rino rino;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rino = animator.GetComponent<Rino>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        tocoJugador = Physics2D.Raycast(animator.transform.position, Vector2.left, distancia, queEsJugador) || Physics2D.Raycast(animator.transform.position, Vector2.right, distancia, queEsJugador);

        if (tocoJugador)
        {
            animator.SetTrigger("Correr");
        }
    }
}
