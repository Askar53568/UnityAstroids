using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData{
    public int lives;
    public int score;

    public float[] position;

    public PlayerData(GameManager manager){

        score = manager.score;
        lives = manager.lives;

        position = new float[3];
        position[0] = manager.GetComponent<Player>().transform.position.x;
        position[1] = manager.GetComponent<Player>().transform.position.y;
        position[2] = manager.GetComponent<Player>().transform.position.z;

    }
}