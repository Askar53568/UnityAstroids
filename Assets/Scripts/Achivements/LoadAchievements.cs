using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//object within the canvas 
public class LoadAchievements : MonoBehaviour
{
    public Text username;
    public Text score;
    [SerializeField] GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        //Obtain the lost of profiles from the storage
        //create a gmae object from the profile prefab foreach profile in the obtained list
        ProfileManager.GetAllProfiles();
        Profile profile = ProfileManager.FindProfile(ProfileSingleton.instance.profileId);
        score.text = profile.score.ToString();
        username.text = profile.username;
        List<string> achievementNames = profile.achievements;
        foreach (string constant in achievementNames)
        {
            if (AchievementManager.achievements.ContainsKey(constant))
            {
                Achievement achievement = AchievementManager.achievements[constant];
                AddItem(achievement);
            }
        }
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene("ProfilesMenu");
    }

    public void OnPlayButton()
    {
        ProfileManager.GetAllProfiles();

        Profile profile = ProfileManager.FindProfile(ProfileSingleton.instance.profileId);

        if (profile.newPlayer)
        {
            SceneManager.LoadScene("Tutorial");
        }
        else
        {

            SceneManager.LoadScene("Game");
        }
    }


    public void AddItem(Achievement achievement)
    {
        //instantiate a profile game object from the profile refab
        GameObject newObject = Instantiate(prefab);
        //make the profile the child of the current game object 
        //whcih is the gridcontent bc the addprofiletolist is a component of the gridcontent
        newObject.transform.SetParent(gameObject.transform, false);
        //find a game object text that is attacjed to the profile object
        newObject.transform.Find("Title").GetComponent<Text>().text = achievement.title;
        newObject.transform.Find("Desc").GetComponent<Text>().text = achievement.description;
    }
}
