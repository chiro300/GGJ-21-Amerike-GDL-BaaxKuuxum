using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeControler : MonoBehaviour
{
    public AudioSource temActual;
    public AudioClip[] temas;
    public enum Tema
    {
        main,
        boss, 
        woods,
        victory,
        proellum,
    }
    
    public void setTheme(Tema fondo)
    {
        if(temActual.clip != temas[(int)fondo] || temActual.clip == null)
        {
            temActual.clip = temas[(int)fondo];
            temActual.Play();
        }

    }

    public void stopTheme()
    {
        temActual.Stop();
    }
}
