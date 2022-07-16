using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip holeSFX;
    [SerializeField] private AudioClip carrotSFX;

    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [Header("Settings")]

    [SerializeField] private int digAmount; // tempo de cavar buraco //
    [SerializeField] private bool detecting;
    [SerializeField] private float waterAmount; // total de agua
    


    private int initialDigAmount;
    private float currentWater;

    private bool dugHole;
    private bool PlantedCarrot;

    PlayerInventory playerInventory;

    // Start is called before the first frame update

    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        initialDigAmount = digAmount;
    }

    private void Update()
    {
        if(dugHole)
        {
      if(detecting)
      {
        currentWater += 0.01f;
      } 


        //cheio
      if(currentWater >= waterAmount && !PlantedCarrot)
      {
        audioSource.PlayOneShot(holeSFX);
        spriteRenderer.sprite = carrot;

        PlantedCarrot = true;
        
      } 
      if(Input.GetKeyDown(KeyCode.E) && PlantedCarrot)
        {
            audioSource.PlayOneShot(carrotSFX);
            spriteRenderer.sprite = hole;
            playerInventory.carrots++;
            currentWater = 0f;
            
        }
      
        }

     
    }

    public void OnHit()
    {
        digAmount--;
        
        if(digAmount <= initialDigAmount / 2)
        {
            spriteRenderer.sprite = hole;
            dugHole = true;
             

            
        }

        // if(digAmount <= 0)
        // {
        //     spriteRenderer.sprite = carrot;
            
        // }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dig"))
        {
            OnHit();
        }
        if(collision.CompareTag("Water"))
        {
            detecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         if(collision.CompareTag("Water"))
        {
            detecting = false;
        }
    }
}
