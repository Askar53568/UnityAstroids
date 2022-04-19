
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour{
    private Command spaceCommand;
    private Command commandW;
    private Command commandUpArrow;
    private Command commandDownArrow;
    private Command commandRightArrow;
    private Command commandLeftArrow;
    private Command commandS;
    private Command commandD;
    private Command commandA;

    private bool inputW;
    private bool inputA;
    private bool inputS;
    private bool inputD;
    private bool inputUp;
    private bool inputDown;
    private bool inputLeft;
    private bool inputRight;



    public void AssignCommand(KeyCode keyCode, Command cmd){
        if (keyCode == KeyCode.Space) spaceCommand = cmd;
        else if (keyCode == KeyCode.W) commandW = cmd;
        else if (keyCode == KeyCode.A) commandA = cmd;
        else if (keyCode == KeyCode.D) commandD = cmd;
        else if (keyCode == KeyCode.S) commandS = cmd;
        else if (keyCode == KeyCode.UpArrow) commandUpArrow = cmd;
        else if (keyCode == KeyCode.DownArrow) commandDownArrow = cmd;
        else if (keyCode == KeyCode.RightArrow) commandRightArrow = cmd;
        else if (keyCode == KeyCode.LeftArrow) commandLeftArrow = cmd;
    }


    void Update()
    {
        //Space bar mapping
        if(Input.GetKeyDown(KeyCode.Space)) spaceCommand.Execute();

        //WASD mappings
        inputW = (Input.GetKey(KeyCode.W)); 
        inputA = (Input.GetKey(KeyCode.A)); 
        inputS = (Input.GetKey(KeyCode.S)); 
        inputD = (Input.GetKey(KeyCode.D)); 

        //Arrow mapings
        inputUp = (Input.GetKey(KeyCode.UpArrow)); 
        inputDown = (Input.GetKey(KeyCode.DownArrow)); 
        inputLeft = (Input.GetKey(KeyCode.LeftArrow)); 
        inputRight = (Input.GetKey(KeyCode.RightArrow)); 

        

    }
    private void FixedUpdate() {
        if (inputW) commandW.Execute();
        if (inputA) commandA.Execute();
        if (inputS) commandS.Execute();
        if (inputD) commandD.Execute();

        if (inputUp) commandUpArrow.Execute();
        if (inputDown) commandDownArrow.Execute();
        if (inputLeft) commandLeftArrow.Execute();
        if (inputRight) commandRightArrow.Execute();
    }
}