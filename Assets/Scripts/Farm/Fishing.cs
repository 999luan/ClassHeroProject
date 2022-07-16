using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{

    [SerializeField] private bool detectingPlayer;
  

    [SerializeField] private int percentage; // % de chance de pesca
    [SerializeField] private GameObject fishPrefab;



    private PlayerInventory player;
    private PlayerAnim playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerInventory>();
         playerAnim = player.GetComponent<PlayerAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
          playerAnim.OnCastingStarted();
        }

    }

    public void OnCasting()
    {
        int randomValue = Random.Range(1,100);

        if(randomValue < percentage)
        {
            //pescou
            Instantiate(fishPrefab, player.transform.position + new Vector3(Random.Range(-2.5f,-1f), 0f,0f), Quaternion.identity);
            
        }else{
            //falhou
           Debug.Log("Falhou");
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

