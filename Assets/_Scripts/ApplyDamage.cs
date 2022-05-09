using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{

    public int EnemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        // EnemyHealth = GameObject.Find("brute").GetComponent<EnemyController>().EnemyHealth;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private bool hasCollide = false;
    void OnTriggerEnter(Collider col)
    {

        // print(col.tag);
        if (col.tag == "Enemy")
        {
            if (hasCollide == false)
            {
                print("Dano");
                GameObject.Find("brute").GetComponent<EnemyController>().EnemyHealth -= 25;
                hasCollide = true;
                StartCoroutine(TakeHealth());
            }
        }
    }

    IEnumerator TakeHealth()
    {

        yield return new WaitForSeconds(1);
        hasCollide = false;


    }
}
