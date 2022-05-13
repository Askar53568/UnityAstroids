using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float lifeTime = 10f;
    public Player player;
    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    private void Start() {
        player = FindObjectOfType<Player>();
        Destroy(this.gameObject,this.lifeTime);
    }

}
