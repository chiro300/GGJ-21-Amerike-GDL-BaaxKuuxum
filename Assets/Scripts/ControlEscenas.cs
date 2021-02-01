using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlEscenas : MonoBehaviour
{
    public string zonaDestino;
    Vector2 posicionDestino;
    public float tiempoTransicion;
    public Animator transicion;
    public GameObject jugador;
    public CameraFollow camara;
    public ThemeControler fondo;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        fondo.setTheme(ThemeControler.Tema.woods);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("transicion"))
        {
            CambiaEscenas temporal = collision.GetComponent<CambiaEscenas>();
            zonaDestino = temporal.zonaDestino;
            posicionDestino = temporal.posicionDestino;
            //Llamar al Fade para cambiar de 
            CargaEscena();
        }
    }

    public void CargaEscena()
    {
        StartCoroutine(cargarNivel(zonaDestino));
    }

    IEnumerator cargarNivel(string nombreDestino)
    {
        //transicion.SetTrigger("cambio");
        //yield return new WaitForSeconds(tiempoTransicion);
        SceneManager.LoadScene(nombreDestino);
        yield return new WaitForSeconds(tiempoTransicion);
        jugador.transform.position = posicionDestino;
        camara.buscaLimites();
    }
}
