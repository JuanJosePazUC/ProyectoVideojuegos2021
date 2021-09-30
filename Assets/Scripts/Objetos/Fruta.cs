using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private GameObject efecto;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Puntos
            Instantiate(efecto, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
