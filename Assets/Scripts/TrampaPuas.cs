using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaPuas : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite conEspinas;
    public Sprite sinEspinas;
    bool danino;
    private int damage = 1;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SoundManager.PlaySound(SoundManager.Sound.alerta);
            Invoke("Puas", 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            spriteRenderer.sprite = sinEspinas;
            danino = false;
            CancelInvoke("Puas");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            if(danino)
            {               
               collision.SendMessageUpwards("AddDamage", damage);
            }
        }
    }

    void Puas()
    {
        spriteRenderer.sprite = conEspinas;
        danino = true;
        SoundManager.PlaySound(SoundManager.Sound.puas);
    }
}
