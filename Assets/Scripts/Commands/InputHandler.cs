
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

        //WASD keys mappings
        if(Input.GetKey(KeyCode.W)) commandW.Execute();
        if(Input.GetKey(KeyCode.S)) commandS.Execute();
        if(Input.GetKey(KeyCode.A)) commandA.Execute();
        if(Input.GetKey(KeyCode.D)) commandD.Execute();


        //Arrow keys mappings
        if(Input.GetKey(KeyCode.UpArrow)) commandUpArrow.Execute();
        if(Input.GetKey(KeyCode.DownArrow)) commandDownArrow.Execute();
        if(Input.GetKey(KeyCode.RightArrow)) commandRightArrow.Execute();
        if(Input.GetKey(KeyCode.LeftArrow)) commandLeftArrow.Execute();


    }
}