using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonajesImagenes : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    private int index;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();

        foreach (Personajes sprite in GameManager.Instance.GetPersonajes())
        {
            sprites.Add(sprite.imagen);
        }

        index = PlayerPrefs.GetInt("JugadorIndex");
        if (index > sprites.Count - 1)
        {
            index = 0;
        }

        Debug.Log(sprites.Count);
        Debug.Log(GameManager.Instance.GetPersonajes().Count);
        

        CambiarImagen();
    }

    public void SiguientePersonaje()
    {
        AudioManager.Instance.Play("MenuMove");
        if (index == sprites.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }
        CambiarImagen();
    }

    public void AnteriorPersonaje()
    {
        AudioManager.Instance.Play("MenuMove");
        if (index == 0)
        {
            index = sprites.Count - 1;
        }
        else
        {
            index -= 1;
        }
        CambiarImagen();
    }

    private void CambiarImagen()
    {
        PlayerPrefs.SetInt("JugadorIndex", index);
        image.sprite = sprites[index];
    }

}
