using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]


    public class AsteroidData{

    public float[] position;
    public float size;
    public int sprite;
    public float[] rotation;

    public AsteroidData(Asteroid asteroid){

        size = asteroid.size;
        sprite = asteroid.sprite;
        position = new float[3];
        position[0] = asteroid.transform.position.x;
        position[1] = asteroid.transform.position.y;
        position[2] = asteroid.transform.position.z;

        rotation = new float[4];
        rotation[0] = asteroid.transform.rotation.x;
        rotation[1] = asteroid.transform.rotation.y;
        rotation[2] = asteroid.transform.rotation.z;
        rotation[3] = asteroid.transform.rotation.w;


        }
    }  