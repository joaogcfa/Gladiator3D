using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    public Animator animator;
    public RectTransform healthbar;
    public int EnemyHealth;
    public AudioSource audioGrunt;
    public AudioSource audioClash;

    void Start()
    {
        // EnemyHealth = GameObject.Find("brute").GetComponent<EnemyController>().EnemyHealth;
        animator = transform.root.GetComponent<Animator>();
        // print(transform.root);
        // audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Axe")
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Impact"))
            {
                if (!animator.GetBool("Idle") && !animator.GetBool("Attack"))
                {
                    animator.SetBool("Attack", true);
                    animator.SetBool("Impact", false);
                }
            }
        }

    }
    private bool hasCollide = false;
    void OnTriggerEnter(Collider col)
    {

        // print(col.tag);
        if (gameObject.tag == "Sword")
        {
            if (col.tag == "Enemy")
            {
                if (hasCollide == false)
                {
                    print(col.transform.parent.gameObject.transform.Find("HealthCanvas/Background/Foreground"));
                    // healthbar.sizeDelta = new Vector2()
                    
                    col.transform.parent.gameObject.GetComponent<EnemyController>().EnemyHealth -= 25;
                    col.transform.parent.gameObject.transform.Find("HealthCanvas/Background/Foreground").GetComponent<RectTransform>().sizeDelta = new Vector2(col.transform.parent.gameObject.GetComponent<EnemyController>().EnemyHealth, healthbar.sizeDelta.y);
                    // healthbar.sizeDelta = new Vector2(col.gameObject.GetComponent<EnemyController>().EnemyHealth)
                    hasCollide = true;
                    audioGrunt.Play(0);
                    StartCoroutine(TakeHealth());
                }
            }
        }
        if (gameObject.tag == "Axe")
        {
            if (col.tag == "Player")
            {
                if (hasCollide == false && !GameObject.Find("LongSword").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Defense"))
                {
                    print(col.transform.parent.gameObject.transform.Find("HealthCanvas/Background/Foreground"));
                    // healthbar.sizeDelta = new Vector2()

                    col.transform.parent.gameObject.GetComponent<PlayerController>().playerHealth -= 25;
                    col.transform.parent.gameObject.transform.Find("HealthCanvas/Background/Foreground").GetComponent<RectTransform>().sizeDelta = new Vector2(col.transform.parent.gameObject.GetComponent<PlayerController>().playerHealth, healthbar.sizeDelta.y);
                    // healthbar.sizeDelta = new Vector2(col.gameObject.GetComponent<EnemyController>().EnemyHealth)
                    hasCollide = true;
                    audioGrunt.Play(0);
                    StartCoroutine(TakeHealth());
                }
            }
            if (col.tag == "Sword")
            {
                print("BATEU NA ESPADA");
                HandleAnimation();
            }
        }

    }

    private void HandleAnimation()
    {
        if (GameObject.Find("LongSword").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Defense"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                if (!animator.GetBool("Idle") && !animator.GetBool("Impact"))
                {
                    audioClash.Play();
                    animator.SetBool("Attack", false);
                    animator.SetBool("Impact", true);
                }
            }


        }

    }
    IEnumerator TakeHealth()
    {

        yield return new WaitForSeconds(1);
        hasCollide = false;

    }
}
