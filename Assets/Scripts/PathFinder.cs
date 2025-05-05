using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake() 
    {
      enemySpawner = FindAnyObjectByType<EnemySpawner>();  
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();   
        waypoints = waveConfig.GetWaypointsList();
        transform.position = waypoints[waypointIndex].position;     
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
       if (waypointIndex < waypoints.Count)
         {
           Vector3 targetPosition = waypoints[waypointIndex].position;
           float delta = waveConfig.GetEnMoveSpeed * Time.deltaTime;
           transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);
           if (transform.position == targetPosition)
           {
              waypointIndex++;
           } 
         }
       else
         {
            Destroy(gameObject);
         }
    }
}
