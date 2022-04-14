using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPre;

    public float spawnDistance= 15.0f;

    public float spawnRate = 2.0f;
    public float trajectoryVarience = 15.0f;
    public int spawnAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        for (int i = 0; i< this.spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float varience = Random.Range(-this.trajectoryVarience, this.trajectoryVarience);
            Quaternion rotation = Quaternion.AngleAxis(varience, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPre, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);

            asteroid.SetTrajectory(rotation * spawnDirection);

        }
    }
}
