
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour{
    
    private bool movingForward;
    private bool movingBack;
    private bool turningLeft;
    private bool turningRight;
    private MoveBackCommand back;
    private MoveForwardCommand forward;
    private TurnLeftCommand turnLeft;
    private TurnRightCommand turnRight;

    private ShootCommand shoot;

    private void Start() {

        back = new MoveBackCommand(this.gameObject.GetComponent<Player>());
        forward = new MoveForwardCommand(this.gameObject.GetComponent<Player>());
        turnLeft = new TurnLeftCommand(this.gameObject.GetComponent<Player>());
        turnRight = new TurnRightCommand(this.gameObject.GetComponent<Player>());
        shoot = new ShootCommand(this.gameObject.GetComponent<Player>());
    }


    void Update()
    {
        movingForward = (Input.GetKey(ProfileSingleton.instance.up)); 
        movingBack = (Input.GetKey(ProfileSingleton.instance.back)); 
        turningLeft = (Input.GetKey(ProfileSingleton.instance.left)); 
        turningRight = (Input.GetKey(ProfileSingleton.instance.right)); 
        if (Input.GetKeyDown(ProfileSingleton.instance.shoot)) shoot.Execute();
        
    }
    public int GetProgress(int progress, string direction){
        if(direction.Equals("up")){
            if(movingForward) progress++;
        }
        return progress;
    }
    private void FixedUpdate() {
        Profile profile = ProfileManager.FindProfile(ProfileSingleton.instance.profileId);

        if (movingForward) forward.Execute();
        if (movingBack) back.Execute();
        if (turningLeft) turnLeft.Execute();
        if (turningRight) turnRight.Execute();
    }
}