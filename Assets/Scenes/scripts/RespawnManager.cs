using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance;

    private void Awake()
    {
        // Ensure there's only one instance of RespawnManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ScheduleRespawn(GameObject enemyToSpawn, Vector3 position, Quaternion rotation, float delay)
    {
        StartCoroutine(RespawnCoroutine(enemyToSpawn, position, rotation, delay));
    }

    private IEnumerator RespawnCoroutine(GameObject enemyToSpawn, Vector3 position, Quaternion rotation, float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(enemyToSpawn, position, rotation);
        Debug.Log("Enemy respawned at: " + position + " with rotation: " + rotation);
    }
}
