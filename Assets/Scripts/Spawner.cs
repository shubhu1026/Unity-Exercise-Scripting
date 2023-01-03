using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    GameObject spawnPrefab;

    [SerializeField]
    Sprite spawnSprite1;
    [SerializeField]
    Sprite spawnSprite2;
    [SerializeField]
    Sprite spawnSprite3;

    //spawn control
    const float MinSpawnDelay = 1;
    const float MaxSpawnDelay = 2;
    Timer spawnTimer;

    //spawn location support
    const int SpawnBorderSize = 100;
    int minSpawnX;
    int minSpawnY;
    int maxSpawnX;
    int maxSpawnY;

    // Start is called before the first frame update
    void Start()
    {
        //spawn boundaries
        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;

        //create and start the timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished) {
            SpawnBear();

            spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            spawnTimer.Run();
        }
    }

    void SpawnBear()
    {
        Vector3 location = new Vector3(Random.Range(minSpawnX,maxSpawnX), 
            Random.Range(minSpawnY,maxSpawnY), 
            -Camera.main.transform.position.z);

        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

        GameObject spawnedObject = Instantiate(spawnPrefab) as GameObject;
        spawnedObject.transform.position = worldLocation;

        SpriteRenderer spriteRenderer = spawnedObject.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            spriteRenderer.sprite = spawnSprite1;
        }
        else if (spriteNumber == 1)
        {
            spriteRenderer.sprite = spawnSprite2;
        }
        else
        {
            spriteRenderer.sprite = spawnSprite3;
        }
    }
}
