using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBotones : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuBotones;
    private bool juegosPausado = false;
    public void Pausar()
    {
        Time.timeScale = 0f;
        AudioManager.Instance.Play("Pause");
        juegosPausado = true;
        menuPausa.SetActive(true);
        menuBotones.SetActive(false);
    }
    public void MenuInicial()
    {
        Reanudar();
        SceneManager.LoadScene("MainMenu");
    }
    public void Reiniciar()
    {
        Reanudar();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Reanudar()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.Play("MenuBack");
        juegosPausado = false;
        menuPausa.SetActive(false);
        menuBotones.SetActive(true);
    }
}
