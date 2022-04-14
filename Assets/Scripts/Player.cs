using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    public Bullet bulletPrefab;

    private InputHandler handler;
    private ShootCommand shoot;

    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    private bool thrusting;
    private bool moveBack;

    private float turnDirection;

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
    }

    // Gets called every frame the game is running
    private void Update()
    {

        moveBack = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
    

        if (Input.GetKey(KeyCode.UpArrow))
        {
            print("up arrow key is held down");
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            print("down arrow key is held down");
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1.0f;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            turnDirection = -1.0f;
        }
        else
        {
            turnDirection = 0.0f;
        }


    }

    private void FixedUpdate()
    {

        if(moveBack)
        {
            rigidBody.AddForce(-(this.transform.up) * this.thrustSpeed);
        }


        if(turnDirection != 0.0f)
        {
            rigidBody.AddTorque(turnDirection * this.turnSpeed);
            print("turning");
        }
    }



}
