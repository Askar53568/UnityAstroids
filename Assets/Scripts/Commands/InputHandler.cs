
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour{
    
    private bool movingForward;
    private bool movingBack;
    private bool turningLeft;
    private bool turningRight;
    private bool shooting;

    private MoveBackCommand back;
    private MoveForwardCommand forward;
    private TurnLeftCommand turnLeft;
    private TurnRightCommand turnRight;

    private ShootCommand shoot;



    private string inputForward = "w";
    private string inputBack = "s";
    private string inputLeft = "a";
    private string inputRight = "d";
    private string inputShoot = "space";

    private void Start() {
        back = new MoveBackCommand(this.gameObject.GetComponent<Player>());
        forward = new MoveForwardCommand(this.gameObject.GetComponent<Player>());
        turnLeft = new TurnLeftCommand(this.gameObject.GetComponent<Player>());
        turnRight = new TurnRightCommand(this.gameObject.GetComponent<Player>());
        shoot = new ShootCommand(this.gameObject.GetComponent<Player>());
    }
    public void AssignCommand(string inputForward, string inputBack, string inputLeft, string inputRight, string inputShoot){
        this.inputForward = inputForward;
        this.inputBack = inputBack;
        this.inputLeft = inputLeft;
        this.inputRight = inputRight;
        this.inputShoot = inputShoot;
    }


    void Update()
    {
        movingForward = (Input.GetKey(inputForward)); 
        movingBack = (Input.GetKey(inputBack)); 
        turningLeft = (Input.GetKey(inputLeft)); 
        turningRight = (Input.GetKey(inputRight)); 
        if (Input.GetKeyDown(inputShoot)) shoot.Execute();
        
    }
    private void FixedUpdate() {
        if (movingForward) forward.Execute();
        if (movingBack) back.Execute();
        if (turningLeft) turnLeft.Execute();
        if (turningRight) turnRight.Execute();
    }
}