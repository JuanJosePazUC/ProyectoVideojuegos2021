using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radish_RunBehaviour : StateMachineBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private bool tocopared;
    [SerializeField] private float distancia;
    [SerializeField] private LayerMask queEsPared;
    private Radish radish;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        radish = animator.GetComponent<Radish>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.Translate(Vector2.left * velocidadMovimiento * Time.deltaTime);

        if (radish.GetMirandoIzquierda())
        {
            tocopared = Physics2D.Raycast(animator.transform.position, Vector2.left, distancia, queEsPared);
        }
        else
        {
            tocopared = Physics2D.Raycast(animator.transform.position, Vector2.right, distancia, queEsPared);
        }

        if (tocopared)
        {
            radish.Girar();
        }
    }
}
