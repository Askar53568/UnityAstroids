using UnityEngine;


public class GameManager : MonoBehaviour {
    //Instance of the player
    public Player player;
    //Time after which the player can respawn
    public float respawnTime = 2.0f;
    //Time for which a player cannot collide with any objects in the scene
    public float respawnInvisibility = 3.0f;

    public int lives = 3;

    //Account for the player death
    public void PlayerDied(){
        this.lives--;
        if (this.lives < 0){
            GameOver();
        }else{
            Invoke(nameof(Respawn), this.respawnTime);
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