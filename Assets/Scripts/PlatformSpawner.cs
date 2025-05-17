using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public float spawnRate = 1.5f;
    public float xRange = 3f;
    public float zRange = 3f;
    public float yStep = 2f;
    public float minYRotation = 0f;
    public float maxYRotation = 360f;
    public float minDistanceBetweenPlatforms = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnRate)
        {
            SpawnTwoPlatforms();
            timer = 0;
        }
    }

    void SpawnTwoPlatforms()
    {
        Vector3 pos1 = GetRandomPosition();
        Vector3 pos2;

        // Keep generating second position until it's far enough from the first
        int safetyCounter = 0;
        do
        {
            pos2 = GetRandomPosition();
            safetyCounter++;
        } while (Vector3.Distance(pos1, pos2) < minDistanceBetweenPlatforms && safetyCounter < 20);

        // Apply Y step to spawner position
        transform.position += new Vector3(0, yStep, 0);

        // Instantiate both platforms with random Y rotation
        Instantiate(platformPrefab, pos1, GetRandomYRotation());
        Instantiate(platformPrefab, pos2, GetRandomYRotation());
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-xRange, xRange);
        float z = Random.Range(-zRange, zRange);
        float y = transform.position.y;
        return new Vector3(x, y, z);
    }

    Quaternion GetRandomYRotation()
    {
        float yRot = Random.Range(minYRotation, maxYRotation);
        return Quaternion.Euler(0, yRot, 0);
    }
}
