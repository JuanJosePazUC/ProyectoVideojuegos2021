using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoBala : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private int daño;

    private void Update()
    {
        transform.Translate(Vector2.right * velocidadMovimiento * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CombateJugador>().TomarDaño(daño);
            Destroy(gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Suelo"))
        {
            Destroy(gameObject);
        }
    }

}
