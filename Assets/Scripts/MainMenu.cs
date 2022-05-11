using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public InputHandler handler;

   public void PlayGame ()
    {
        SceneManager.LoadScene("ProfilesMenu");
    }

<<<<<<< HEAD
=======
    public void PlayButton ()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadButton ()
    {
        SceneManager.LoadScene("Game");
    }
    public void AchButton ()
    {
        SceneManager.LoadScene("Achievements");
    }

>>>>>>> f8002301dd91344294887fe90016bdd363b0c789
    public void BackButton ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}