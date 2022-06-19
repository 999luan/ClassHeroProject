using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    // Start is called before the first frame update

[SerializeField] private Transform attackPoint;
[SerializeField] private float radius;
[SerializeField] private LayerMask playerLayer;

private PlayerAnim player;
private Animator anim;
private Skeleton skeleton;

private void Start()
{
   anim = GetComponent<Animator>(); 
   player = FindObjectOfType<PlayerAnim>();
   skeleton = GetComponentInParent<Skeleton>();
}

public void PlayAnim(int value)
{
   anim.SetInteger("Transition", value); 
}

public void Attack()
{
    if(!skeleton.isDead)
    {

    Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);
    if(hit != null)
    {
        //hit player
        player.OnHit();
       
        
    }
    }
   
}

public void OnHit (){
    
   
    if(skeleton.health <= 0)
    {
        skeleton.isDead = true;
        anim.SetTrigger("Death");

        Destroy(skeleton.gameObject, 1f);
    }else{
        anim.SetTrigger("Hit");
        skeleton.health -= 1;
        skeleton.healthBar.fillAmount = skeleton.health / skeleton.totalHealth;
    
    }
}
 private void OnDrawGizmosSelected()
     {
        Gizmos.DrawWireSphere(attackPoint.position, radius);  
    }
}
