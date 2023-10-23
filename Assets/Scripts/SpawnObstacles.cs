using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstacle;

    public GameObject oxygenCylinderPrefab;

    public float oxygenCylinderSpawnProbability = 0.2f;  // 20% de chance de gerar um cilindro de oxigênio em vez de um obstáculo.

    public float maxX;
    public float minX;

    public float maxY;

    public float minY;

    public float timeBetweenSpawn;

    private float spawnTime;
    
    // Update is called once per frame
    void Update()
    {
        if(Time.time>spawnTime){
        Spawn();
        spawnTime=Time.time + timeBetweenSpawn;
    }
    }
    void Spawn()
    {
        float randomX=Random.Range(minX,maxX);
        float randomY=Random.Range(minY,maxY);
        if (Random.value < oxygenCylinderSpawnProbability) {
            Instantiate(oxygenCylinderPrefab, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }       
        else {
            Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }

    }
    
    public void SetSpawnRate(float multiplier)
{
    timeBetweenSpawn /= multiplier; // Dividimos porque quanto menor o tempo entre spawns, mais rápido os obstáculos aparecerão
}

}
