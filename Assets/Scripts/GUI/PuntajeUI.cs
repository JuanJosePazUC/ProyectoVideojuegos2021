using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntajeUI : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
    private int puntosTotal;

    private void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = GameManager.Instance.GetCantidadPuntos().ToString();
        GameManager.Instance.OnScoreChange += CambiarPuntaje_OnScoreChange;
    }

    private void CambiarPuntaje_OnScoreChange(object sender, GameManager.OnScoreChangeEventArgs e)
    {
        puntosTotal = e.cantidadPuntosTemporalCambio + e.cantidadPuntosCambio;
        textMeshProUGUI.text = puntosTotal.ToString();
    }
}
