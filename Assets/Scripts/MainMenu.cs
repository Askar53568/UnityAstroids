using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public InputHandler handler;
    public Animator transition;
    public string sceneName;
    

   public void PlayGame ()
    {
        StartCoroutine(LoadAnim("ProfilesMenu"));
        SceneManager.LoadScene("ProfilesMenu");
    }

    public void BackButton ()
    {
        StartCoroutine(LoadAnim("MainMenu"));
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("Options");
        
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    IEnumerator LoadAnim(string sceneName){
        transition.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }

}