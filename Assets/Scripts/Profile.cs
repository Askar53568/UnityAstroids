using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Profile {
    public string profileId;
    public string username;

    public Profile(string profileId, string username){
        this.profileId = profileId;
        this.username = username;
    }
}