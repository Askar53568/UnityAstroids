using UnityEngine;

public class ProfileSingleton : MonoBehaviour {
    public static ProfileSingleton instance {get; private set;}
    

    public string profileId {get; set;}

    private void Awake() {
        if(instance){
            Destroy(gameObject);
    
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


}