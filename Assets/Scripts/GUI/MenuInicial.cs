using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.ReiniciarPuntaje();
    }
    public void IniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }
}
