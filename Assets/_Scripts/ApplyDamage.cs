using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    public Animator animator;
    public RectTransform healthbar;
    public int EnemyHealth;
    
    void Start()
    {
        // EnemyHealth = GameObject.Find("brute").GetComponent<EnemyController>().EnemyHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private bool hasCollide = false;
    void OnTriggerEnter(Collider col)
    {

        // print(col.tag);
        if(gameObject.tag == "Sword"){
            if (col.tag == "Enemy")
            {
                if (hasCollide == false)
                {
                    print(col.transform.parent.gameObject.transform.Find("HealthCanvas/Background/Foreground"));
                    // healthbar.sizeDelta = new Vector2()

                    col.transform.parent.gameObject.GetComponent<EnemyController>().EnemyHealth -= 25;
                    col.transform.parent.gameObject.transform.Find("HealthCanvas/Background/Foreground").GetComponent<RectTransform>().sizeDelta = new Vector2 (col.transform.parent.gameObject.GetComponent<EnemyController>().EnemyHealth , healthbar.sizeDelta.y);
                    // healthbar.sizeDelta = new Vector2(col.gameObject.GetComponent<EnemyController>().EnemyHealth)
                    hasCollide = true;
                    StartCoroutine(TakeHealth());
                }
            }
        }
        if(gameObject.tag == "Axe"){
            if (col.tag == "Player")
            {
                if (hasCollide == false)
                {
                    print(col.transform.parent.gameObject.transform.Find("HealthCanvas/Background/Foreground"));
                    // healthbar.sizeDelta = new Vector2()

                    col.transform.parent.gameObject.GetComponent<PlayerController>().playerHealth -= 25;
                    col.transform.parent.gameObject.transform.Find("HealthCanvas/Background/Foreground").GetComponent<RectTransform>().sizeDelta = new Vector2 (col.transform.parent.gameObject.GetComponent<PlayerController>().playerHealth , healthbar.sizeDelta.y);
                    // healthbar.sizeDelta = new Vector2(col.gameObject.GetComponent<EnemyController>().EnemyHealth)
                    hasCollide = true;
                    StartCoroutine(TakeHealth());
                }
            }
            if (col.tag == "Sword")
            {
                print("BATEU NA ESPADA");
             
            }
        }

    }

    IEnumerator TakeHealth()
    {

        yield return new WaitForSeconds(1);
        hasCollide = false;


    }
}
