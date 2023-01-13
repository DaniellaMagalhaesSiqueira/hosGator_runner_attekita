using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] obstacles;
    public List<Obstacle> obstaclesToSpawn;
    public GameConfiguration config;
    void Start()
    {
        InitObstacles();
    }

    public void GeneratedObstacles()
    {
        StartCoroutine(SpawnRandomObstacles());
    }

    public void StopGenerator()
    {
        StopAllCoroutines();
    }

    public void ResetGenerator()
    {
        foreach(Obstacle obs in obstaclesToSpawn)
        {
            obs.gameObject.SetActive(false);
        }
    }
    void InitObstacles()
    {
        int index = 0;
        for(int i = 0; i < obstacles.Length * 3; i++)
        {
            GameObject obj = Instantiate(obstacles[index], transform.position, Quaternion.identity);
            obj.SetActive(false);
            obstaclesToSpawn.Add(obj.GetComponent<Obstacle>());
            index++;
            if(index == obstacles.Length)
            {
                index = 0;
            }
        }
    }

    IEnumerator SpawnRandomObstacles()
    {
        yield return new WaitForSeconds(Random.Range(config.minRangeObstaclesGenarator, config.maxRangeObstaclesGenarator));
        int index = Random.Range(0, obstaclesToSpawn.Count);

        while (true)
        {
            Obstacle obstacle = obstaclesToSpawn[index];

            if (!obstacle.gameObject.activeInHierarchy)
            {
                obstacle.gameObject.SetActive(true);
                obstacle.transform.position = transform.position;
                break;
            }
            else
            {
                index = Random.Range(0, obstaclesToSpawn.Count);
            }

        }


        StartCoroutine(SpawnRandomObstacles());
    }
}
