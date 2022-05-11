using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public void HandleOnClick(){
        SceneManager.LoadScene("KeysMenu");
    }
}
