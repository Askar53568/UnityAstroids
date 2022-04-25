using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]


    public class AsteroidData{

    public float[] position;
    public float size;
    public int sprite;

    public AsteroidData(Asteroid asteroid){

        size = asteroid.size;
        sprite = asteroid.sprite;
        position = new float[3];
        position[0] = asteroid.transform.position.x;
        position[1] = asteroid.transform.position.y;
        position[2] = asteroid.transform.position.z;

        }
    }  