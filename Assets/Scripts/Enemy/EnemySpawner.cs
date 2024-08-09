using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int numberOfObjects = 10;
    public float spawnRadius = 100f;

    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            if (randomPosition != Vector3.zero)
            {
                Instantiate(objectToSpawn, randomPosition, Quaternion.identity, transform);
            }
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, spawnRadius, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return Vector3.zero; // NavMesh üzerinde geçerli bir pozisyon bulunamazsa Vector3.zero döner
    }
}