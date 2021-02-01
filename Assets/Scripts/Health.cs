using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int totalHealth;
    public int health;
    public float invincible;

    public string animatorTransition;
    private int animatortransitionId;

    private SpriteRenderer _renderer;
    private Animator _animator;

    bool isInvincible = false;

    public bool isPlayer = false;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        if (_animator != null)
        {
            animatortransitionId = Animator.StringToHash(animatorTransition);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        health = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDamage(int amount)
    {
        if(!isInvincible){

            health = health - amount;
            if(!string.IsNullOrEmpty(animatorTransition)){
                _animator.SetTrigger(animatortransitionId);
            }
            StartCoroutine(VisualFeedback());
            StartCoroutine(Invincible());
        }
        if (health <= 0)
        {
            health = 0;

            if (isPlayer)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        Debug.Log("Vida del Player es: " + health);
    }


    public void AddHealth(int amount)
    {
        if (health < 3)
        {
            health = health + amount;
        }
        // Max health
        if (health > totalHealth)
        {
            health = totalHealth;
        }

        Debug.Log("Vida del Player es: " + health);
    }

    private IEnumerator VisualFeedback()
    {
        _renderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        _renderer.color = Color.white;
    }

    private IEnumerator Invincible(){
        isInvincible = true;

        yield return new WaitForSeconds(invincible);

        isInvincible = false;
    }
}
