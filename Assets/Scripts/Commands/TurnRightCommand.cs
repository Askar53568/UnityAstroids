
using UnityEngine;


public class TurnRightCommand: Command{

    //Player
    private Player currentPlayer;
    //Rigid body of the player (physical object)
    private Rigidbody2D playerBody;
    //Set direction to right
    float turnDirection = -1.0f;

    //Pass the entity to the base class
    public TurnRightCommand(Player entity, Rigidbody2D body) : base(entity){
        playerBody = body;
        currentPlayer = entity;
    }
    //Add torque to the passed rigid body of the player
    //the torque is calculated as direction (Vector3) * speed (specified in the player class)
    public override void Execute()
    {
        playerBody.AddTorque(turnDirection * currentPlayer.turnSpeed);
    }


    //  if(turnDirection != 0.0f)
    //     {
    //         rigidBody.AddTorque(turnDirection * this.turnSpeed);
    //         print("turning");
    //     }
    // else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
    //         turnDirection = -1.0f;
    //     }
}
