using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
  public bool isPaused;

  [SerializeField]public float speed;
  [SerializeField]public float runSpeed;

  private Rigidbody2D rig;

  private PlayerInventory playerInventory;

   private float initialSpeed;
   private bool _isRunning;
   private bool _isRolling;
   private bool _isCutting;
   private bool _isMining;
   private bool _isLooting;
   private bool _isDigging;
   private bool _isWatering;

  private Vector2 _direction;

  public int handlingObj;
  

  public Vector2 direction
  {
    get { return _direction;}
    set {_direction = value;}
  }
 

public bool isLooting {get => _isLooting; set => _isLooting = value;}
  public bool isMining {get => _isMining; set => _isMining = value;}

  public bool isRunning {get => _isRunning; set => _isRunning = value;}
  
  public bool isRolling {get => _isRolling; set => _isRolling = value;}
  public bool isCutting {get => _isCutting; set => _isCutting = value;}
  public bool isDigging {get => _isDigging; set => _isDigging = value;}
  public bool isWatering {get => _isWatering; set => _isWatering = value;}



private void Start()
{
    rig = GetComponent<Rigidbody2D>();
    playerInventory = GetComponent<PlayerInventory>();
    initialSpeed = speed;
}
  private void Update()
  {

    if(!isPaused){
          // hotbar
    if(Input.GetKeyDown(KeyCode.Alpha1))
    {
      handlingObj = 0;
    }
    if(Input.GetKeyDown(KeyCode.Alpha2))
    {
      handlingObj = 1;
    }
    if(Input.GetKeyDown(KeyCode.Alpha3))
    {
      handlingObj = 2;
    }
    if(Input.GetKeyDown(KeyCode.Alpha4))
    {
      handlingObj = 3;
    }


     OnInput();

      OnRun();

      OnRolling();
      OnCutting();
      OnMining();
      OnLooting();
      OnDig();
      OnWatering();
    }


  }

  
  private void FixedUpdate()
  {
    if(!isPaused){
       OnMove();
    }
     
  }


  #region  Movement

       
       

        void OnInput()
        {
         _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        void OnMove()
        {
          rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
        }
        void OnRun(){
          if(Input.GetKeyDown(KeyCode.LeftShift))
          {
            speed = runSpeed;
            _isRunning = true;
          }
          if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = initialSpeed;
            _isRunning = false;
          }
        }

          void OnDig()
         {
          if(handlingObj == 1)
          {
      if(Input.GetMouseButtonDown(0))
                    {
                      isDigging = true;
                      speed = 0.5f;
                    }
              if(Input.GetMouseButtonUp(0))
                    {
                      
                      isDigging = false;
                      speed = initialSpeed;
                    } 
          }
       
                  
          }

         void OnCutting()
         {
          if(handlingObj == 0)
          {
          if(Input.GetMouseButtonDown(0))
                          {
                            isCutting = true;
                            speed = 0.5f;
                          }
                    if(Input.GetMouseButtonUp(0))
                          {
                            
                            isCutting = false;
                            speed = initialSpeed;
                  }
          }
           
                  
          }
          void OnWatering()
         {
        
          if(handlingObj == 3)
          {
                    if(Input.GetMouseButtonDown(0) && playerInventory.currentWater > 0)
                          {
                            
                            isWatering = true;
                            speed = 0.5f;
                          }
                    if(Input.GetMouseButtonUp(0) || playerInventory.currentWater < 0)
                          {
                            
                            isWatering = false;
                            speed = initialSpeed;
                          }

                    if(isWatering)
                    {
                      playerInventory.currentWater -= 0.01f;
                    }
          }

          }
         
          
           
                  
          

          void OnMining(){
             if(handlingObj == 2)
             {
               if(Input.GetMouseButtonDown(0))
          {
            
            _isMining = true;
            speed = 0.5f;
          }
           if(Input.GetMouseButtonUp(0))
           {
            speed = initialSpeed;
            _isMining = false;
          }
             
         
        }
        }

        void OnLooting(){
          if(Input.GetKeyDown(KeyCode.E))
          {
            _isLooting = true;
            
          }
          if(Input.GetKeyUp(KeyCode.E))
          {
           
            _isLooting = false;
          }
        }


        void OnRolling()
        {
          if(Input.GetKeyDown(KeyCode.Space))
          {
            speed = runSpeed;
            _isRolling = true;
          }
          if(Input.GetKeyUp(KeyCode.Space))
          {
            speed = initialSpeed; 
            _isRolling = false;
          }
        }


  #endregion


}


