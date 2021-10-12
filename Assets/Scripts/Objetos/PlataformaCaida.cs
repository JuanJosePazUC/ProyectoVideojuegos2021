using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaida : MonoBehaviour
{
    [SerializeField] private float tiempoEspera;
    [SerializeField] private GameObject explosion;
    private Rigidbody2D rb2D;
    private Animator animator;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DesactivarPlataforma());
        }

        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Suelo"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            AudioManager.Instance.Play("Explode");
            Destroy(gameObject);
        }
    }

    private IEnumerator DesactivarPlataforma()
    {
        animator.SetTrigger("Apagar");
        yield return new WaitForSeconds(tiempoEspera);
        rb2D.constraints = RigidbodyConstraints2D.None;
        AudioManager.Instance.Play("Fall");
        rb2D.AddForce(new Vector2(0, -1));
    }
}
