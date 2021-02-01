using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    private float temporizador;
    bool danando;

    private void Awake()
    {
        temporizador = 3.0f;
        Invoke("autodestruccion", 5.0f);
    }

    private void Update()
    {
        
        if (danando)
        {
            if (temporizador > 0)
            {
                temporizador -= Time.deltaTime;
                Debug.Log(temporizador);

            }
            else
            {
                Debug.Log("Le hice dano al jugador");
                temporizador = 3.0f;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
            danando = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
            danando = false;
    }

    void autodestruccion()
    {
        this.gameObject.SetActive(false);
    }
}
