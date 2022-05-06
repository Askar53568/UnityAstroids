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

    public InputHandler inputHandler;

    public GameObject upControl;
    public Image upImage;
    public Text mainText;
    private bool resistance = true;

    private float waitTime = 20.0f;

    public Vector3 initialPosition = new Vector3(404f,123f,0);



    public void NewGame(){
        gamePausedUI.SetActive(false);
        spawner.gameObject.SetActive(false);

        upControl.transform.Find("Text").GetComponent<Text>().text = ProfileSingleton.instance.up;


    }
    public bool paused = false;


    private void Start() {
        NewGame();
        upImage.fillAmount = 0.0f;
    }

    private void FixedUpdate() {
        if(Input.GetKeyDown(KeyCode.Return)) Pause();
        if(Input.GetKey(ProfileSingleton.instance.up)) AddProgress();
        if(resistance){
            upImage.fillAmount-= 1.0f / waitTime * Time.deltaTime;
        }
    }

        public void AddProgress(){
            upImage.fillAmount+=0.01f;
            if(upImage.fillAmount==1){
                resistance = false;
                upControl.gameObject.SetActive(false);
                mainText.gameObject.SetActive(true);
                this.player.transform.position = initialPosition;
                mainText.text = "Congrats! Let's try a few more things..";
                waitTime/10.0f
                Debug.LogError("Congrats!");
            }
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