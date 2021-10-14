using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaPinchos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CombateJugador>().TomarDaño(1);
        }
    }
}
