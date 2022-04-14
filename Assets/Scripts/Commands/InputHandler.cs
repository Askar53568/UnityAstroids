
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour{
    private Command spaceCommand;
    private Command commandW;
    private Command commandUpArrow;


    public void AssignCommand(KeyCode keyCode, Command cmd){
        if (keyCode == KeyCode.Space) spaceCommand = cmd;
        else if (keyCode == KeyCode.W) commandW = cmd;
        else if (keyCode == KeyCode.UpArrow) commandUpArrow = cmd;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            spaceCommand.Execute();
        }
        if(Input.GetKey(KeyCode.W)) commandW.Execute();
        if(Input.GetKey(KeyCode.UpArrow)) commandUpArrow.Execute();
    }
}