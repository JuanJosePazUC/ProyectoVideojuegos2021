using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sierra : MonoBehaviour
{
    [SerializeField] private List<Transform> cadenas;
    [SerializeField] private float velocidadMovimiento;
    private bool derecho = true;
    private int numeroCadena = 0;

    private void Start()
    {
        transform.position = cadenas[0].position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, cadenas[numeroCadena].position, velocidadMovimiento * Time.deltaTime);

        if (transform.position == cadenas[numeroCadena].position)
        {
            if ((numeroCadena + 1 > cadenas.Count - 1 && derecho) || (numeroCadena - 1 < 0 && !derecho))
            {
                derecho = !derecho;
            }
            if (derecho)
            {
                numeroCadena += 1;
            }
            else
            {
                numeroCadena -= 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CombateJugador>().TomarDaño(3);
        }
    }
}
