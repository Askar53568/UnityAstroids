using UnityEngine;


public class GameManager : MonoBehaviour {
    //Instance of the player
    public Player player;
    //Time after which the player can respawn
    public float respawnTime = 2.0f;

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
    }

    private void GameOver()
    {
        //TODO
    }
}