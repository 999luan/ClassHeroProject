using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawner : MonoBehaviour
{

    public GameObject skellPrefab;
    public float spawnTime = 5f;

    private Camera mainCamera;
    private float xMax, yMax;

    

  


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        xMax = mainCamera.orthographicSize * mainCamera.aspect;
        yMax = mainCamera.orthographicSize;

        InvokeRepeating("SpawnSkel" , spawnTime, spawnTime);
        //o valor do meio define quantor tempo demora para aparecer na primeira vez
        // InvokeRepeating("SpawnSkel" , 50f, spawnTime);

    }

    private void SpawnSkel()
    {
        
        Debug.Log("Um inimigo apareceu depois de " + Time.timeSinceLevelLoad + " segundos");

        Vector3 cameraPosition = mainCamera.transform.position;

        Vector3 skellPosition = new Vector3(cameraPosition.x + Random.Range(-xMax, xMax), Random.Range(-yMax, yMax),0);

        //cria inimigo
        Instantiate(skellPrefab, skellPosition, Quaternion.identity);

        
    }
    void Update()
    {
        
    }
}
