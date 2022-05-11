using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeysMenu : MonoBehaviour
{
    public Text forwardPlaceholder;
    public Text backPlaceholder;
    public Text leftPlaceholder;
    public Text rightPlaceholder;
    public Text shootPlaceholder;

    public string forward = "w";
    public string back = "s";
    public string left = "a";
    public string right = "d";
    public string shoot = "space";

    
    public void GetForwardInput(string forward){
        this.forward = forward;
        ProfileSingleton.instance.up = forward;
        forwardPlaceholder.text = forward;
    }
    public void GetBackInput(string back){
        this.back = back;
        ProfileSingleton.instance.back = back;
        backPlaceholder.text = back;
    }
    public void GetLeftInput(string left){
        this.left = left;
        ProfileSingleton.instance.left = left;
        leftPlaceholder.text = left;
    }
    public void GetRightInput(string right){
        this.right = right;
        ProfileSingleton.instance.right = right;
        rightPlaceholder.text = right;
    }
    public void GetShootInput(string shoot){
        this.shoot = shoot;
        ProfileSingleton.instance.shoot = shoot;
        shootPlaceholder.text = shoot;
    }
    public void GoBackButton(){
        SceneManager.LoadScene("Game");
    }
    // Start is called before the first frame update
    void Start()
    {
        ProfileSingleton.instance.up = forward;
        ProfileSingleton.instance.back = back;
        ProfileSingleton.instance.left = left;
        ProfileSingleton.instance.right = right;
        ProfileSingleton.instance.shoot = shoot;

    }
}
