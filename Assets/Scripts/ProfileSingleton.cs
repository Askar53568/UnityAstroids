using UnityEngine;

public class ProfileSingleton : MonoBehaviour {
    public static ProfileSingleton instance {get; private set;}
    

    public string profileId {get; set;}
    public KeyCode up {get;set;}
    public KeyCode back {get;set;}
    public KeyCode left {get;set;}
    public KeyCode right {get;set;}
    public KeyCode shoot {get;set;}
    public bool newPlayer = true;

    private void Awake() {
        if(instance){
            Destroy(gameObject);
    
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start() {
            up = KeyCode.W;
            back = KeyCode.S;
            left = KeyCode.A;
            right = KeyCode.D;
            shoot = KeyCode.Space;
        
    }


}