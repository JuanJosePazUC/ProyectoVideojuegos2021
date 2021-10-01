using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    [SerializeField] private int cantidadPuntos;
    [SerializeField] private GameObject efecto;
    private GameManager gameManager;

    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.RecogerFruta(cantidadPuntos);
            Instantiate(efecto, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
