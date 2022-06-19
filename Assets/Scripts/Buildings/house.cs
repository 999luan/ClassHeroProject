using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private int woodAmount;
 [SerializeField] private float timeAmount;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;

    [Header("Components")]
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private GameObject houseColider;
    [SerializeField] private Transform point;
   
    

    


    private bool detectingPlayer;
    private Player player;
    private PlayerAnim playerAnim;
    private PlayerInventory playerInventory;


    private float timeCount;
    private bool started;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        playerInventory = FindObjectOfType<PlayerInventory>();

        playerAnim = player.GetComponent<PlayerAnim>();
    }

    // Update is called once per frame
    void Update()
    {

    
        if(playerInventory.hamerClass > 0){
             if (detectingPlayer && Input.GetKeyDown(KeyCode.B) && playerInventory.totalWood >= woodAmount)
        {

            //constroi
           started = true;
           playerAnim.OnBuildingStart();
          houseSprite.color = startColor;
          player.transform.position = point.position;
          player.isPaused = true;
          houseColider.SetActive(true);
          playerInventory.totalWood -= woodAmount;

        }
        if(started){
            timeCount += Time.deltaTime;
            if(timeCount >= timeAmount)
            {
              playerAnim.OnBuildingEnd();
            houseSprite.color = endColor;
          player.isPaused = false;


            }
        }
        }
       

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
