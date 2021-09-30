using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rino_CorrerBehaviour : StateMachineBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private bool tocopared;
    [SerializeField] private float distancia;
    [SerializeField] private LayerMask queEsPared;
    private Transform jugador;
    private Rino rino;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rino = animator.GetComponent<Rino>();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GiroInicial(animator.transform);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.Translate(Vector2.left * velocidadMovimiento * Time.deltaTime);

        if (rino.GetMirandoIzquierda())
        {
            tocopared = Physics2D.Raycast(animator.transform.position, Vector2.left, distancia, queEsPared);
        }
        else
        {
            tocopared = Physics2D.Raycast(animator.transform.position, Vector2.right, distancia, queEsPared);
        }

        if (tocopared)
        {
            animator.SetTrigger("Choca");
        }
    }

    private void GiroInicial(Transform transform)
    {
        if (jugador.position.x > transform.position.x && rino.GetMirandoIzquierda())
        {
            rino.Girar();
        }
        else if (jugador.position.x < transform.position.x && !rino.GetMirandoIzquierda())
        {
            rino.Girar();
        }
    }
}
