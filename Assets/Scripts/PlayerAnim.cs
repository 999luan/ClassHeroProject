using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour



{

   
[Header("Atack Seetings")]
[SerializeField] private Transform attackPoint;
[SerializeField] private float radius;
[SerializeField] private LayerMask enemyLayer;

    private Player player;
  
    private Animator anim;

    private Fishing fishing;

    private bool isHitting;
    private float recoveryTime = 1f;
    private float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        fishing = FindObjectOfType<Fishing>();
       
    }

    // Update is called once per frame
    void Update()
    {
       OnMove();
       OnRun();

       if(isHitting)
       {
       timeCount += Time.deltaTime;
         if(timeCount >= recoveryTime)
       {
         isHitting = false;
         timeCount = 0f;
       }
       }

       
    }


    #region Movement



    void OnMove()
    {
     if(player.direction.sqrMagnitude > 0)
       {
          if(player.isRolling)
          {
               anim.SetTrigger("IsRoll");  
          }else
          {
               anim.SetInteger("Transition",1);
          }
            
       }
       else
       {
            anim.SetInteger("Transition",0);
       }
       if(player.direction.x > 0)
       {
            transform.eulerAngles = new Vector2(0,0);
       }
       if(player.direction.x < 0)
       {
            transform.eulerAngles = new Vector2(0,180);
       }
       if(player.isCutting)
       {
          anim.SetInteger("Transition", 3);
       }
       if(player.isMining)
       {
          anim.SetInteger("Transition", 4);
       }
       if (player.isLooting)
       {
          anim.SetInteger("Transition", 5);
       }
        if (player.isDigging)
       {
          anim.SetInteger("Transition", 6);
       }
          if (player.isWatering)
       {
          anim.SetInteger("Transition", 7);
       }
       
    }

     void OnRun()
     {
          if(player.isRunning)
          {
               anim.SetInteger("Transition", 2);
          }
     }

    #endregion


   #region Attack

   public void onAttack()
   {
      Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, enemyLayer);
      if(hit != null)
      {
         //atacou inimigo
         hit.GetComponentInChildren<AnimationControl>().OnHit();
      }

     
   }
    private void OnDrawGizmosSelected()
     {
        Gizmos.DrawWireSphere(attackPoint.position, radius);  
    }

   #endregion
      // chamado quando inicia a pesca
   public void OnCastingStarted()
   {
      anim.SetTrigger("IsCasting");
      player.isPaused = true;
   }
   //chamado quanod temrina
   public void OnCastingEnded()
   {
      fishing.OnCasting();
      player.isPaused = false;

   }

   public void OnBuildingStart()
   {
      anim.SetBool("Building", true);
   }
     public void OnBuildingEnd()
   {
      anim.SetBool("Building", false);
   }

   public void OnHit()
   {
      if(!isHitting)
      {
       anim.SetTrigger("Hit");
       isHitting = true;
      }

   }
}
