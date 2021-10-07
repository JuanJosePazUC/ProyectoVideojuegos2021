using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuVictoria : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI puntajeFinal;
    [SerializeField] private TextMeshProUGUI puntajeMaximo;

    private void Start()
    {
        int puntajeFinalNum = GameManager.Instance.GetCantidadPuntos();
        puntajeFinal.text = "Puntaje Final: " + puntajeFinalNum;
        if (puntajeFinalNum > PlayerPrefs.GetInt("PuntajeMaximo"))
        {
            PlayerPrefs.SetInt("PuntajeMaximo", puntajeFinalNum);
        }
        puntajeMaximo.text = "Puntaje Maximo: " + PlayerPrefs.GetInt("PuntajeMaximo");

        AudioManager.Instance.StopAll();
        AudioManager.Instance.Play("Victory");
    }

    public void VolverMenuInicial(){
        SceneManager.LoadScene(0);
    }
}
