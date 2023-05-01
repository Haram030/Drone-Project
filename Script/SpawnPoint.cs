using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public DroneController Drone;
    public Transform[] playerSpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        RandomSelectSpawnPoint();
    }

    void RandomSelectSpawnPoint()
    {
        int number = Random.Range(0, playerSpawnPoints.Length);
        Drone.transform.position = playerSpawnPoints[number].transform.position;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
