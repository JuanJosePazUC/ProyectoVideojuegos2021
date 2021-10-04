using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajesImagenes : MonoBehaviour
{
    [SerializeField] private List<GameObject> personajes;
    private int index;

    private void Start()
    {
        index = PlayerPrefs.GetInt("JugadorIndex");
        personajes[index].SetActive(true);
    }

    public void SiguientePersonaje()
    {
        personajes[index].SetActive(false);
        if (index == personajes.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }
        PlayerPrefs.SetInt("JugadorIndex", index);
        personajes[index].SetActive(true);
    }

    public void AnteriorPersonaje()
    {
        personajes[index].SetActive(false);
        if (index == 0)
        {
            index = personajes.Count - 1;
        }
        else
        {
            index -= 1;
        }
        PlayerPrefs.SetInt("JugadorIndex", index);
        personajes[index].SetActive(true);
    }
}
