using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Amounts")]
    
    public int totalWood;
    public int totalFood;
    public int carrots;
    public int totalRock;
    public float currentWater;
    public int hamerClass;
    public int fish;
    public int fisherClass;
    
    
    
    private float waterLimit = 50;
    private float foodLimit = 99;
    private float carrotsLimit = 99;
    private float woodLimit = 99;
    private float rockLimit = 99;
    private float hamerClassLimit = 1;
    private float fishLimit = 9f;
    
    public float WaterLimit1 {get => waterLimit; set => waterLimit = value;}
    public float FoodLimit {get => foodLimit; set => foodLimit = value;}
    public float CarrotsLimit {get => carrotsLimit; set => carrotsLimit = value;}
    public float WoodLimit {get => woodLimit; set => woodLimit = value;}
    public float RockLimit {get => rockLimit; set => rockLimit = value;}
    public float HamerClass {get => hamerClassLimit; set => hamerClassLimit = value;}
    public float Fish {get => fishLimit; set => fishLimit = value;}

    






    public void WaterLimit(float water)
    {
        if(currentWater < waterLimit)
        {
            currentWater += water;
        }
        
    }


}
