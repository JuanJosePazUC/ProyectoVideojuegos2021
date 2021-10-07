using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarraDeVida : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void CambiarVidaMaxima(int vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
        slider.value = vidaMaxima;
    }

    public void CambiarVida(int vida)
    {
        slider.value = vida;
    }
}
