using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] List<GameObject> spawnPoints = new List<GameObject>();

    WaitForSeconds waitForSeconds = new WaitForSeconds(5f);

    void Start()
    {
        obstacles.Capacity = 10;
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            yield return waitForSeconds;

            GameObject spawnObstacle = RandomObstacle(Random.Range(0, obstacles.Count));
            spawnObstacle.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position;
            spawnObstacle.SetActive(true);
        }
    }

    GameObject RandomObstacle(int i)
    {
        if (obstacles[i].activeSelf == false)
        {
            return obstacles[i];
        }
        else
        {
            return RandomObstacle((i + 1) % obstacles.Count);
        }
    }
}
