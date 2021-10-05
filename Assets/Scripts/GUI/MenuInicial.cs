using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] private float tiempoIniciar;
    private void Start()
    {
        GameManager.Instance.ReiniciarPuntaje();
        AudioManager.Instance.StopAll();
        AudioManager.Instance.Play("MainTheme");
    }
    public void IniciarJuego()
    {
        StartCoroutine(IniciarJuegoCR());
    }
    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }

    public IEnumerator IniciarJuegoCR()
    {
        AudioManager.Instance.Play("MenuConfirmar");
        AudioManager.Instance.Stop("MainTheme");
        yield return new WaitForSeconds(tiempoIniciar);
        AudioManager.Instance.Play("LevelTheme");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
