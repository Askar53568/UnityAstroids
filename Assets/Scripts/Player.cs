using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    public Bullet bulletPrefab;

    private InputHandler handler;

    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;

    private  void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        handler = GetComponent<InputHandler>();

    }
    // Start is called before the first frame update
    void Start()
    {
        handler.AssignCommand(KeyCode.Space, new ShootCommand(this));
        handler.AssignCommand(KeyCode.W, new MoveForwardCommand(this,rigidBody));
        handler.AssignCommand(KeyCode.UpArrow, new MoveForwardCommand(this, rigidBody));
        handler.AssignCommand(KeyCode.S, new MoveBackCommand(this, rigidBody));
        handler.AssignCommand(KeyCode.D, new TurnRightCommand(this, rigidBody));
        handler.AssignCommand(KeyCode.A, new TurnLeftCommand(this,rigidBody));
    }

    //Account for the player's collision with the asteroid
    private  void OnCollisionEnter2D(Collision2D collision)
    {
        //When the player collides with an asteroid
        if (collision.gameObject.tag == "Asteroid"){
            //Stop all the player movement
            rigidBody.velocity = Vector3.zero;
            //Stop all rotation
            rigidBody.angularVelocity= 0.0f;
            //Turn off the game object entirely until the player respawns
            this.gameObject.SetActive(false);
        }
    }



}
