using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private float rockHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private int totalRockDrop;

        //manter falso após cortar para for infinite drop
     [SerializeField] private bool isMined;


    public void OnHit()
    {
        rockHealth--;

        anim.SetTrigger("isMining");
        if(rockHealth <= 0)
        {
             for(int i = 0; i < totalRockDrop; i++) {
                Instantiate(rockPrefab, transform.position + new Vector3(Random.Range(-0.5f, 0.5f),Random.Range(-1f, 1f),0f), transform.rotation);
               
            }
            anim.SetTrigger("mined");

            isMined = true;
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pick") && !isMined)
        {
            OnHit();
        }
    }
}
