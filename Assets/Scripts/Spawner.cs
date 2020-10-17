using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Player player;
    public GameObject[] hazards;
    public GameObject spawnPointsParent;
    List<Transform> spawnPoints;

    // time passed from one spawn to the other.
    float timeBtwSpawns;
    // total time taking to spawn new hazards.
    public float startTimeBtwSpawns;
    // the lowest the harder the faster hazards will be spawned.
    public float minTimeBtwSpawns;
    // ratio at which the startTimeBtwSpawns will decrease and so make the level
    // harder.
    public float decrease;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = spawnPointsParent.GetComponentsInChildren<Transform>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            if(timeBtwSpawns <= 0)
            {
                //spawn enemy
                int randomLocationIndex = Random.Range(0, spawnPoints.Count);
                int randomHazardIndex = Random.Range(0, hazards.Length);
                Transform randowmSpawnLocation = spawnPoints[randomLocationIndex];
                GameObject randomEnemy = hazards[randomHazardIndex];
                Instantiate(randomEnemy, randowmSpawnLocation.position, Quaternion.identity);

                if (startTimeBtwSpawns > minTimeBtwSpawns)
                    startTimeBtwSpawns -= decrease;

                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
