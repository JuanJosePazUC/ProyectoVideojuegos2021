using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radish_FlyBehaviour : StateMachineBehaviour
{

    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float distancia;
    [SerializeField] private LayerMask queEsSuelo;
    private bool tocoPared;
    private Radish radish;
    private Rigidbody2D rb2D;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        radish = animator.GetComponent<Radish>();
        rb2D = animator.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (radish.GetMirandoIzquierda())
        {
            rb2D.velocity = new Vector2(velocidadMovimiento, 0) * Vector2.left;
            tocoPared = Physics2D.Raycast(animator.transform.position, Vector2.left, distancia, queEsSuelo);
        }
        else
        {
            rb2D.velocity = new Vector2(velocidadMovimiento, 0) * Vector2.right;
            tocoPared = Physics2D.Raycast(animator.transform.position, Vector2.right, distancia, queEsSuelo);
        }

        if (tocoPared)
        {
            radish.Girar();
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2D.velocity = new Vector2(0, 0);
        rb2D.gravityScale = 2;
    }

}
