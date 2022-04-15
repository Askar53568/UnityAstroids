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

    private float turnDirection= 0.0f;

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

    // Gets called every frame the game is running
    private void Update()
    {


    }

    private void FixedUpdate()
    {

    }



}
