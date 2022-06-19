using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDcontroler : MonoBehaviour
{

    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image foodUIBar;

    [SerializeField] private Image hammerUIBar;
    [SerializeField] private Image swordUIBar;
    [SerializeField] private Image rocksUIBar;
    [SerializeField] private Image carrotsUIBar;
    [SerializeField] private Image fishUIbar;


    [Header("Tools")]
    // [SerializeField] private Image axeUI;
    // [SerializeField] private Image shovelUI;
    // [SerializeField] private Image pickUI;
    // [SerializeField] private Image bucketUI;

    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;



    private PlayerInventory playerInventory;
    private Player player;

    void Awake()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        player = playerInventory.GetComponent<Player>();
    }




    // Start is called before the first frame update
    void Start()
    {

        hammerUIBar.fillAmount = 0f;

         foodUIBar.fillAmount = 0f;


        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        fishUIbar.fillAmount = 0f;
       
        

        swordUIBar.fillAmount = 0f;

        rocksUIBar.fillAmount = 0f;

        carrotsUIBar.fillAmount = 0f;
        

    }

    // Update is called once per frame
    void Update()
    {
        waterUIBar.fillAmount = playerInventory.currentWater / playerInventory.WaterLimit1;
        foodUIBar.fillAmount = playerInventory.totalFood / playerInventory.FoodLimit;
        woodUIBar.fillAmount = playerInventory.totalWood / playerInventory.WoodLimit;
        swordUIBar.fillAmount = playerInventory.currentWater / playerInventory.WaterLimit1;
        rocksUIBar.fillAmount = playerInventory.totalRock / playerInventory.RockLimit;
        carrotsUIBar.fillAmount = playerInventory.carrots / playerInventory.CarrotsLimit;
        hammerUIBar.fillAmount = playerInventory.hamerClass / playerInventory.HamerClass;
        fishUIbar.fillAmount = playerInventory.fisherClass / playerInventory.Fish;

       // toolsUI[player.handlingObj].color = selectColor;

        for(int i = 0; i < toolsUI.Count; i++) 
        {
            if(i == player.handlingObj)
            {
                toolsUI[i].color = selectColor;
            } 
            else{
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
