using UnityEngine;


public class GameManager : MonoBehaviour {
    //Instance of the player
    public Player player;
    //Reference to the explosion effect
    public ParticleSystem explosion;
    //Time after which the player can respawn
    public float respawnTime = 2.0f;
    //Time for which a player cannot collide with any objects in the scene
    public float respawnInvisibility = 3.0f;
    //Lives of the player
    public int lives = 3;
    //Score
    public int score = 0;

    //Account for the player death
    public void PlayerDied(){
        //Play the explosion effect at the position of the player's death
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();
        //Decrement the amount of lives
        this.lives--;
        if (this.lives < 0){
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

        //If an asteroid is a little bigger than minimal size add 100 points
        if(asteroid.size < asteroid.minSize+20.0f){
            score += 100;
        //medium size - 50 points
        }else if(asteroid.size < 100.0f){
            score+= 50;
        //big size - 25 points
        }else{
            score +=25;
        }
    }
    

    //Respawn the player when they have lives left
    public void Respawn()
    {
        //Reset the player position to be the center of the board
        this.player.transform.position = Vector3.zero;
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

    private void GameOver()
    {
        //TODO
    }
}