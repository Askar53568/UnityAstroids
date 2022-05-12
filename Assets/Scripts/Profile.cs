using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Profile {
    public string profileId;
    public string username;
    public List<string> achievements; 
    public bool newPlayer = true;
    public int score = 0;
    public KeyCode up;
    public KeyCode back;
    public KeyCode left;
    public KeyCode right;

    public KeyCode shoot;

    public Profile(string profileId, string username, KeyCode up, KeyCode back, KeyCode left, KeyCode right, KeyCode shoot){
        this.profileId = profileId;
        this.username = username;
        this.up = up;
        this.back = back;
        this.left = left;
        this.right = right;
        this.shoot = shoot;
        this.achievements = new List<string>();
    }
}