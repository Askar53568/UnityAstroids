using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    public float size = 200.0f;

    public float minSize = 500.5f;
    public float maxSize = 2000.5f;

    public float speed = 30.0f;

    public float maxLifetime = 30.0f;

    private Rigidbody2D asteroid;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        asteroid = GetComponent<Rigidbody2D>();
    
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0,sprites.Length)];

        //Rotate the sprite a random angle to make all asteroids look different
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        //Change the scale of the spawned asteroid instead of the size
        //If the size is changed, then the mass is changed which will affect other physical properties
        this.transform.localScale = Vector3.one * this.size;
        //the larger the size the larger the mass
        asteroid.mass = this.size * 2.0f;
        
    }

    public void SetTrajectory(Vector2 direction)
    {
        asteroid.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
