using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public InputHandler handler;

   public void PlayGame ()
    {
        SceneManager.LoadScene("ProfilesMenu");
    }

    public void BackButton ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("KeysMenu");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}