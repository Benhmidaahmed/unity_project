using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    public GameObject obstacle1,obstacle2,obstacle3;
    private float obstacleSpawnInterval = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstacles");
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void SpawnObstacle()
    {
        int random = Random.Range(1, 4);
        if (random == 1)
        {
            Instantiate(obstacle1,new Vector3 (transform.position.x,0.5f,0),Quaternion.identity);
        }
        else if (random == 2)
        {
            Instantiate(obstacle2, new Vector3(transform.position.x, 0.5f, 0), Quaternion.identity);
        }
        else if (random == 3)
        {
            Instantiate(obstacle3, new Vector3(transform.position.x, 0.5f, 0), Quaternion.identity);
        }
    }
    IEnumerator SpawnObstacles ()
    {
        while (true) 
        {
            SpawnObstacle();
            yield return new WaitForSeconds (obstacleSpawnInterval);
        }
    }
}
