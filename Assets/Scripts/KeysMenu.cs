using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeysMenu : MonoBehaviour
{
    public KeyCode up {get;set;}
    public KeyCode back {get;set;}
    public KeyCode left {get;set;}
    public KeyCode right {get;set;}
    public KeyCode shoot {get;set;}
    public InputField forwardPlaceholder;
    public InputField backPlaceholder;
    public InputField leftPlaceholder;
    public InputField rightPlaceholder;
    public InputField shootPlaceholder;

    private readonly System.Array keyCodes = System.Enum.GetValues(typeof(KeyCode));


    public void GoBackButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void SaveButton(){
        Profile profile = ProfileManager.FindProfile(ProfileSingleton.instance.profileId);
        profile.up = up;
        profile.back = back;
        profile.left = left;
        profile.right = right;
        profile.shoot = shoot;
        ProfileManager.SaveProfile(profile);
        ProfileManager.GetAllProfiles();
        Debug.LogError("save succesful");
    }

    private void Start()
    {
        ProfileManager.GetAllProfiles();
        Profile profile = ProfileManager.FindProfile(ProfileSingleton.instance.profileId);
        up = profile.up;
        back = profile.back;
        left = profile.left;
        right = profile.right;
        shoot = profile.shoot;
        ProfileSingleton.instance.up = up;
        ProfileSingleton.instance.back = back;
        ProfileSingleton.instance.right = right;
        ProfileSingleton.instance.left = left;
        ProfileSingleton.instance.shoot = shoot;

        leftPlaceholder.transform.Find("Placeholder").GetComponent<Text>().text = ProfileSingleton.instance.left.ToString();
        rightPlaceholder.transform.Find("Placeholder").GetComponent<Text>().text = ProfileSingleton.instance.right.ToString();
        forwardPlaceholder.transform.Find("Placeholder").GetComponent<Text>().text = ProfileSingleton.instance.up.ToString();
        backPlaceholder.transform.Find("Placeholder").GetComponent<Text>().text = ProfileSingleton.instance.back.ToString();
        shootPlaceholder.transform.Find("Placeholder").GetComponent<Text>().text = ProfileSingleton.instance.shoot.ToString();
    }

    private void Update()
    {
        if (forwardPlaceholder.isFocused)
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode keyCode in keyCodes)
                {
                    if (Input.GetKey(keyCode))
                    {
                        forwardPlaceholder.transform.Find("Placeholder").GetComponent<Text>().text = keyCode.ToString();
                        forwardPlaceholder.transform.Find("Text").GetComponent<Text>().text = keyCode.ToString();
                        up = keyCode;
                        ProfileSingleton.instance.up = keyCode;
                        break;
                    }
                }
            }

        }
        else if (backPlaceholder.isFocused)
        {
            foreach (KeyCode keyCode in keyCodes)
            {
                if (Input.GetKey(keyCode))
                {
                    backPlaceholder.transform.Find("Placeholder").GetComponent<Text>().text = keyCode.ToString();
                    backPlaceholder.transform.Find("Text").GetComponent<Text>().text = keyCode.ToString();
                    back = keyCode;
                    ProfileSingleton.instance.back = keyCode;
                    break;
                }
            }

        }
        else if (leftPlaceholder.isFocused)
        {
            foreach (KeyCode keyCode in keyCodes)
            {
                if (Input.GetKey(keyCode))
                {
                    leftPlaceholder.transform.Find("Placeholder").GetComponent<Text>().text = keyCode.ToString();
                    leftPlaceholder.transform.Find("Text").GetComponent<Text>().text = keyCode.ToString();
                    left = keyCode;
                    ProfileSingleton.instance.left = keyCode;
                    break;
                }
            }

        }
        else if (rightPlaceholder.isFocused)
        {
            foreach (KeyCode keyCode in keyCodes)
            {
                if (Input.GetKey(keyCode))
                {
                    rightPlaceholder.transform.Find("Placeholder").GetComponent<Text>().text = keyCode.ToString();
                    rightPlaceholder.transform.Find("Text").GetComponent<Text>().text = keyCode.ToString();
                    right = keyCode;
                    ProfileSingleton.instance.right = keyCode;
                    break;
                }
            }

        }
        else if (shootPlaceholder.isFocused)
        {
            foreach (KeyCode keyCode in keyCodes)
            {
                if (Input.GetKey(keyCode))
                {
                    shootPlaceholder.transform.Find("Placeholder").GetComponent<Text>().text = keyCode.ToString();
                    shootPlaceholder.transform.Find("Text").GetComponent<Text>().text = keyCode.ToString();
                    shoot = keyCode;
                    ProfileSingleton.instance.shoot = keyCode;
                    break;
                }
            }
        }
    }

}
