using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPre;

    public float spawnDistance= 500.0f;

    public float spawnRate = 4.0f;
    public float trajectoryVarience = 30.0f;
    public int spawnAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }
    //Asteroids needs to spawn at random positions with random trajectory
    private void Spawn()
    {
        for (int i = 0; i< this.spawnAmount; i++)
        {
            //Get random radial direction 
            //The spawner will be placed at player's position and the asteroids will be
            //generated around the radius of the spawner $insideUnitCircle
            //The asteroids should always be spawned on the dge of the circle, so we normalize it
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            //Create an angle of a random variance so that asteroids spawning on the edge of the spawner circli 
            //have a random cone trajectory
            float varience = Random.Range(-this.trajectoryVarience, this.trajectoryVarience);
            //Create an angle of a random variance in the z-axis
            Quaternion rotation = Quaternion.AngleAxis(varience, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPre, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            //Set trajectory to always point at the center where the player is
            asteroid.SetTrajectory(rotation * -spawnDirection);

        }
    }
}
