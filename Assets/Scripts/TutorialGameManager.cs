using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialGameManager : MonoBehaviour{

    public Player player;
    public Asteroid asteroidPre;

    public AsteroidSpawner spawner;
    //Reference to the explosion effect
    public ParticleSystem explosion;
    //Time after which the player can respawn
    public float respawnTime = 2.0f;
    //Time for which a player cannot collide with any objects in the scene
    public GameObject gamePausedUI;


    public void NewGame(){
        gamePausedUI.SetActive(false);
        spawner.gameObject.SetActive(false);
    }
    public bool paused = false;


    private void Start() {
        NewGame();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Return)) Pause();
    }

        public void Pause(){
        paused = !paused;
        if (paused){
            Time.timeScale = 0;
            gamePausedUI.SetActive(true);
        } else{
            Time.timeScale = 1;
            gamePausedUI.SetActive(false);
        }
    }

}