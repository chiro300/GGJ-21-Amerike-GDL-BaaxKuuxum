using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaGas : MonoBehaviour
{
    public GameObject gas;

    private BoxCollider2D dangerZone;
    private BoxCollider2D activateZone;

    void Start()
    {
        var colliders = GetComponents<BoxCollider2D>();
        activateZone = colliders[1];
        dangerZone = colliders[0];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.IsTouching(activateZone))
        {
            if (collision.transform.CompareTag("Player"))
            {
                Debug.Log("Se activa la trampa");
                SoundManager.PlaySound(SoundManager.Sound.gas);
                gas = Instantiate(gas, transform.position, transform.rotation);
                gameObject.SetActive(false);
            }
        }
        if (collision.IsTouching(dangerZone))
        {
            if (collision.transform.CompareTag("Player"))
            {
                Debug.Log("Se activa la trampa");
                SoundManager.PlaySound(SoundManager.Sound.alerta);
            }
        }
    }
}
