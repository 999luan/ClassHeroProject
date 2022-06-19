using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    [Header("Enemy Stats")]


    [Header("Enemy Stats")]
    public float radius;
    public LayerMask layer;

    public float health;
    public float totalHealth;
    public Image healthBar;

    public bool isDead;



    public float stamina;



    // Start is called before the first frame update
    [Header("Components")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AnimationControl animControl;
    [SerializeField] private bool isWar;

    



    private Player player;
    private bool detectPlayer;

    void Start()
    {
        health = totalHealth;
        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
       

    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead && detectPlayer){

            agent.isStopped = false;

            agent.SetDestination(player.transform.position);  
            if(isWar && Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
            {
                animControl.PlayAnim(2);
            }
            else
            {
                animControl.PlayAnim(1);
            }

            float posX = player.transform.position.x - transform.position.x;
            if(posX > 0)
            {
                transform.eulerAngles = new Vector2(0,0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0,180);

            }

        }
    }
    void FixedUpdate()
    {
        DetectPlayer();
    }

    public void DetectPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, layer);

        if(hit != null)
        //enchergou player
        {   
            detectPlayer = true;
        }
        else
        //nao enchergou player

        {
            detectPlayer = false;
            animControl.PlayAnim(0);
            agent.isStopped = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
