using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health = 100;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        // if (collision.gameObject.tag == "hitBox")
        // {
        //     audioSource.Play();
        //     lives[contadorLives].SetActive(false);
        //     contadorLives++;
        //     health -= 25;
        //     if (health <= 0)
        //     {
        //         StartCoroutine(TriggerDeath());
        //     }
        //     print("health: " + health);
        //     playerAnimator.SetTrigger("Hit");
        //     playerRenderer.color = new Color(1, 0, 0, 1);
        // } 
    }
}
