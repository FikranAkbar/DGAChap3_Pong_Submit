using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public float defaultDelay;
    private float delayBtwnSpawn;
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        delayBtwnSpawn = defaultDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Item.canSpawnItem)
        {
            delayBtwnSpawn -= Time.deltaTime;
            if (delayBtwnSpawn < 0)
            {
                Item.canSpawnItem = false;
                delayBtwnSpawn = defaultDelay;
                Instantiate(item,
                    new Vector3(
                        Random.Range(-5, 5),
                        Random.Range(-5, 5)),
                    Quaternion.identity);
            }
        }
    }
}
