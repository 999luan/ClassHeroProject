using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherClass : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float timeMove;

    private float timeCount;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerInventory>().fisherClass++;
            Destroy(gameObject);
        }
    }
}
