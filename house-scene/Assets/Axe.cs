using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public GameObject Crawler;
    public float detectionRange = 2f;
    private Animator animator;
    public PlayerController handsManager;

    void Start()
    {
        Crawler = GameObject.Find("crawler");
        GameObject leftHandController = GameObject.Find("Object1538"); // găsește obiectul 'LeftHand Controller'
        if (leftHandController != null)
        {
            animator = leftHandController.GetComponent<Animator>(); // obține componenta Animator de pe 'LeftHand Controller'
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && handsManager.has_Axe && Crawler)
        {
            float distance = Vector3.Distance(transform.position, Crawler.transform.position);
            if (animator != null)
            {
                animator.SetTrigger("go_attack");
                StartCoroutine(DelayedAction(distance));
            }
        }

        IEnumerator DelayedAction(float distance)
        {
            yield return new WaitForSeconds(1f); // Așteaptă 1 secundă

            if (distance <= detectionRange && Crawler)
            {
                Debug.Log("Hit Crawler");
                Enemy enemyScript = Crawler.GetComponent<Enemy>();
                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(1);
                }
            }
            animator.SetTrigger("go_idle");
        }

    }
}
