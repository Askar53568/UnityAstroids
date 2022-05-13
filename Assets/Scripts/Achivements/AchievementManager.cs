using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class AchievementManager
{
    public static Dictionary<string, Achievement> achievements;

    static AchievementManager(){
        achievements = new Dictionary<string, Achievement>();
        achievements.Add("frozen", new Achievement("Ice Age", "Unlock the time freeze achievement"));
        achievements.Add("asteroid", new Achievement("Primal Desire", "Destroy an asteroid"));
        achievements.Add("soldier", new Achievement("Soldier", "Reach a score of 500"));
        achievements.Add("bystander", new Achievement("Bystander", "Unlock the Invincibility power up"));
        achievements.Add("freeze", new Achievement("Freeze! Don't move!", "Unlock a Time Freeze power up"));
        achievements.Add("war", new Achievement("Declaration of War", "Reach a score of 10000"));
        achievements.Add("armored", new Achievement("The Armored Titan", "Unlock the shield power up"));
        achievements.Add("descent", new Achievement("Descent", "End the game with a score of zero"));
        achievements.Add("speed", new Achievement("Jaws Titan", "Unlock a speed achievement"));
        achievements.Add("battle", new Achievement("First Battle", "Start your first game"));
   }
}