using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarubSpawner : MonoBehaviour
{
    public GameObject[] bug; // the prefab to be spawned
    public float spawnTime = 6f; // how long between each spawn
    public float scaleCap = 3;
    public float difTimer = 8;
    public float difTimerCap;
    public float randomizer;

    private void Start()
    {
        Invoke("SpawnRandom", Random.Range(1, 3));
    }
    private void Update()
    {
        //Subtracts Timer
        difTimer = difTimer - 1 * Time.deltaTime;

        //Clamps Timer
        if (difTimer < 0)
        {
            difTimer = 0;
        }

        //Checks if timer is finished
        if (difTimer == 0)
        {
            randomizer = Random.Range(1, scaleCap);
            SpawnRandom();
            CancelInvoke();

            scaleCap += 1;
            if (scaleCap < 3)
            {
                scaleCap = 3;
            }
            difTimer = 8;
        }
    }

    // Update is called once per frame
    void SpawnRandom()
    {
        for (int i = 0; i < randomizer; i++)
        {
            Instantiate(bug[Random.Range(0, bug.Length - 1)]);
        }

    }

    void StopSpawning()
    {
        CancelInvoke("SpawnRandom");
    }
}