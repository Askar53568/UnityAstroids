using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour {
    //Instance of the player
    public Player player;
    //Reference to the explosion effect
    public ParticleSystem explosion;
    //Time after which the player can respawn
    public float respawnTime = 2.0f;
    //Time for which a player cannot collide with any objects in the scene
    public float respawnInvisibility = 3.0f;

    public GameObject gameOverUI;

    //Lives of the player
    public int score { get; private set; }
    public Text scoreText;

    public int lives { get; private set; }
    public Text livesText;

    //position at the center of the screen
    public Vector3 initialPosition = new Vector3(404f,123f,0);


    private void Start() {
        NewGame();
    }

    //Account for the player death
    public void PlayerDied(){
        //Play the explosion effect at the position of the player's death
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();
        //Decrement the amount of lives
        SetLives(lives - 1);
        if (this.lives <= 0){
            GameOver();
        }else{
            Invoke(nameof(Respawn), this.respawnTime);
        }
    }

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        //Play the explosion effect at the position of the asteroid's death
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        //small - 100 points
        if(asteroid.size < asteroid.minSize+20.0f){
            SetScore(score+100);
        //medium size - 50 points
        }else if(asteroid.size < 125.0f){
             SetScore(score + 50);
        //large size - 25 points
        }else{
            SetScore(score + 25);
        }
    }
    

    //Respawn the player when they have lives left
    public void Respawn()
    {
        //Reset the player position to be the center of the board
        this.player.transform.position = initialPosition;
        //Re-activate the player game object
        this.player.gameObject.SetActive(true);
        //Change the layer of the player object to Respawn which will ignore all collisions
        this.player.gameObject.layer = LayerMask.NameToLayer("Respawn");
        //After 3 seconds turn on collisions
        Invoke(nameof(TurnOnCollisions), this.respawnInvisibility);
    }

    //Reset the player object layer back to having normal collisions (asteroids)
    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    //Enable the Game Over UI
    private void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    //Load the Main Menu Scene
    public void BackToMainMenu(){
        SceneManager.LoadScene(0);
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void NewGame()
    {
        Asteroid[] asteroids = FindObjectsOfType<Asteroid>();

        for (int i = 0; i < asteroids.Length; i++) {
            Destroy(asteroids[i].gameObject);
        }

        gameOverUI.SetActive(false);

        SetScore(0);
        SetLives(1);
        Respawn();
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = lives.ToString();
    }
}