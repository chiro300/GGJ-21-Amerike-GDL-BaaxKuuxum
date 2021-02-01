using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jugador;
    public float lLimit; // left border
    public float rLimit;//  right border    
    public float tLimit; // top border
    public float bLimit; //  bot border

    private void Start()
    {
        buscaLimites();
    }

    void Update()
    { 
        transform.position = new Vector3(Mathf.Clamp(jugador.position.x, lLimit, rLimit), Mathf.Clamp(jugador.position.y, bLimit, tLimit), transform.position.z);
       
    }

   public void buscaLimites()
    {
        tLimit = GameObject.Find("LimiteSup").GetComponent<Transform>().position.y;
        bLimit = GameObject.Find("LimiteInf").GetComponent<Transform>().position.y;
        rLimit = GameObject.Find("LimiteDer").GetComponent<Transform>().position.x;
        lLimit = GameObject.Find("LimiteIzq").GetComponent<Transform>().position.x;
        Debug.Log("busque limites");
    }
}
