using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigss;
    [SerializeField] float timeBetwenWaves = 0f;
    [SerializeField] bool isLooping ;
     WaveConfigSO currentWave;
    void Start()
    {
       StartCoroutine (SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
      return currentWave;
    }
    IEnumerator SpawnEnemyWaves()
    {
      do{
       foreach (WaveConfigSO wave in waveConfigss)
         {
          currentWave = wave;
          for(int i = 0; i < currentWave.GetEnemyCount() ; i++)
           {
             Instantiate(currentWave.GetEnemyPrefabs(i),
                         currentWave.GetStartingWaypoint().position,
                         Quaternion.identity,
                         transform);
             yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());             
           }
           yield return new WaitForSeconds(timeBetwenWaves);
         }
        }
        while (isLooping ==true);
    }
}
