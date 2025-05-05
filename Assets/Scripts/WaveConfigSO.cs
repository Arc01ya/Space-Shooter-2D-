using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
   [SerializeField] List<GameObject> enemyPrefabs;
   [SerializeField] Transform pathPrefab;
   [SerializeField] float moveSpeed = 5f;
   [SerializeField] float timeBetweenEnSpawns = 1f;
   [SerializeField] float spawnTimeVariance = 0f;
   [SerializeField] float minSpawnTime = 0.2f;

   public Transform GetStartingWaypoint()
   {
      return pathPrefab.GetChild(0);
   }

   public List<Transform> GetWaypointsList()
   {
      List<Transform> waypoints = new();
      foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
   }

   public float GetEnMoveSpeed {get => moveSpeed;}

   public int GetEnemyCount()
   {
      return enemyPrefabs.Count;
   }

   public GameObject GetEnemyPrefabs(int index)
   {
      return enemyPrefabs[index];
   }

   public float GetRandomSpawnTime()
   {
      float spawnTime = Random.Range(timeBetweenEnSpawns - spawnTimeVariance,
                                     timeBetweenEnSpawns + spawnTimeVariance);
      return Mathf.Clamp (spawnTime, minSpawnTime, float.MaxValue);
   }
}
