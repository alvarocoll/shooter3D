using UnityEngine;

public class EnemieSpawner : MonoBehaviour
{
    public ENE_Zombie enemyPrefab; // Reference to the enemy prefab
    public Transform[] spawnPoints;
    private float _currentTime; // Tiempo actual
    void Start()
    {
        
    }

    
    void Update()
    {
        _currentTime -= Time.deltaTime; // Restar el tiempo transcurrido desde el último frame
        if (_currentTime < 0)
        {
            _currentTime = 1; // Reiniciar el tiempo para el próximo spawn
            ENE_Zombie newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = GetSpawnPoint();
        }

    }

    Vector3 GetSpawnPoint()
    {
        int random = Random.Range(0, spawnPoints.Length);
        return spawnPoints[random].position;
    }
}
