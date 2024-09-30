using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;  // Array de prefabs de power-ups
    public Transform[] spawnPoints;      // Array de puntos en el mapa donde se pueden generar los power-ups

    void Start()
    {
        SpawnRandomPowerUp();
    }

    void SpawnRandomPowerUp()
    {
        // Selecciona un prefab de power-up aleatorio
        int randomIndex = Random.Range(0, powerUpPrefabs.Length);
        GameObject randomPowerUp = powerUpPrefabs[randomIndex];

        // Selecciona un punto de spawn aleatorio
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnIndex];

        // Genera el power-up en el punto de spawn
        Instantiate(randomPowerUp, spawnPoint.position, spawnPoint.rotation);
    }
}
