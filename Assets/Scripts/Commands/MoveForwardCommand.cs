
using UnityEngine;


public class MoveForwardCommand: Command{

    //Player
    private Player currentPlayer;
    //Rigid body of the player (physical object)
    private Rigidbody2D playerBody;

    //Pass the entity to the base class
    public MoveForwardCommand(Player entity, Rigidbody2D body) : base(entity){
        playerBody = body;
        currentPlayer = entity;
    }
    //Add Force to the passed rigid body of the player
    //the force is calculated as direction (Vector3) * speed (specified in the player class)
    public override void Execute()
    {
        playerBody.AddForce(currentPlayer.transform.up * currentPlayer.thrustSpeed);
    }
}
