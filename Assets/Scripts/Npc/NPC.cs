using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPC : MonoBehaviour
{
   public float speed;
    private float initialSpeed;

   private int index;
   private Animator anim;
 [SerializeField] private NavMeshAgent agent;
   public List<Transform> paths = new List<Transform>();

private void Start()
{
    initialSpeed = speed;
    anim = GetComponent<Animator>();
}


  
    // Update is called once per frame
    void Update()
    {
        if(DialogControl.instance.isShowing)
        {
            speed = 0f;
            anim.SetBool("IsWalking", false);
        }
        else{
            speed = initialSpeed;
            anim.SetBool("IsWalking", true);
        }
        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);        

        if(Vector2.Distance(transform.position, paths[index].position) < 0.1f)
        {
            if(index < paths.Count -1)
            {
                index = Random.Range(0, paths.Count);
            }
            else
            {
                index = 0;
            }
        }

        Vector2 direction = paths[index].position - transform.position;
        if(direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0,0);
        }
        if(direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0,180);
        }
    }
}