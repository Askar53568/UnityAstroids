using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement {
    //for every profile ill have a list of strings
    //initially it's emtpy
    //im gonna have a dictionary of name, desc of achievements 
    //on start initialize dictionary of achievements 
    //
    public string title;
    public string description;

    public Achievement(string title, string description)
    {
        this.title = title;
        this.description = description;
    }
}