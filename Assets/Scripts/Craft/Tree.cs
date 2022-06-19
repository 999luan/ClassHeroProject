using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWoodDrop;

     //manter falso após cortar para for infinite drop
     [SerializeField] private bool isCut;

     
    [SerializeField] private ParticleSystem leafs;


    public void OnHit()
    {
        treeHealth--;

        anim.SetTrigger("isHit");
        leafs.Play();
        if(treeHealth <= 0)
        {
            //cria o toco e instancia drop (recurso)
            for(int i = 0; i < totalWoodDrop; i++) {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-0.5f, 0.5f),Random.Range(-1f, 1f),0f), transform.rotation);
                
            }
            anim.SetTrigger("cut"); 

            isCut = true;
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Axe") && !isCut)
        {
            OnHit();
        }
    }
}
