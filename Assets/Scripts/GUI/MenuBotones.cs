using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuBotones : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuBotones;
    private bool juegosPausado = false;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        CombateJugador combateJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<CombateJugador>();
        combateJugador.OnPlayerDeath += ReiniciarAutomatico;
    }

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

    private void ReiniciarAutomatico(object sender, EventArgs e)
    {
        StartCoroutine(ReiniciarCR());
    }

    private IEnumerator ReiniciarCR()
    {
        yield return new WaitForSeconds(2f);
        Reiniciar();
    }
}
