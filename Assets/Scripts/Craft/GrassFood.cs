using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassFood : MonoBehaviour
{
    [SerializeField] private float bushHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject foodPrefab;
     [SerializeField] private int totalFoodDrop;
      //manter falso após cortar para for infinite drop
     [SerializeField] private bool isLooted;



    public void OnHit()
    {
        bushHealth--;

        anim.SetTrigger("isLooting");
        if(bushHealth <= 0)
        {
            for(int i = 0; i < totalFoodDrop; i++) {
                Instantiate(foodPrefab, transform.position + new Vector3(Random.Range(-0.5f, 0.5f),Random.Range(-1f, 1f),0f), transform.rotation);
              
            }
             anim.SetTrigger("looted");
             isLooted = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Loot") && !isLooted)
        {
            OnHit();
        }
    }
}
