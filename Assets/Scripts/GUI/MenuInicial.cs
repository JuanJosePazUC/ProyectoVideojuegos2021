using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] private GameObject menuSeleccionPersonaje;
    [SerializeField] private GameObject menuBase;
    public void IniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MenuSeleccionarPersonaje()
    {
        menuBase.SetActive(false);
        menuSeleccionPersonaje.SetActive(true);
    }
    public void MenuBase()
    {
        menuSeleccionPersonaje.SetActive(false);
        menuBase.SetActive(true);
    }

    public void Salir(){
        Debug.Log("Saliendo...");
        Application.Quit();
    }
}
