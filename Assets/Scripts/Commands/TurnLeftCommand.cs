
using UnityEngine;


public class TurnLeftCommand: Command{

    //Player
    private Player currentPlayer;
    //Rigid body of the player (physical object)
    private Rigidbody2D playerBody;
    //Set direction to left
    float turnDirection = 1.0f;

    //Pass the entity to the base class
    public TurnLeftCommand(Player entity, Rigidbody2D body) : base(entity){
        playerBody = body;
        currentPlayer = entity;
    }
    //Add torque to the passed rigid body of the player
    //the torque is calculated as direction (Vector3) * speed (specified in the player class)
    public override void Execute()
    {
        playerBody.AddTorque(turnDirection * currentPlayer.turnSpeed);
    }

}
