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

    public static float speed = 200.0f;

    public float maxLifetime = 30.0f;

    private Rigidbody2D asteroid;
    

    private void Awake()
    {
        speed = 300.0f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        asteroid = GetComponent<Rigidbody2D>();
    
    }
    void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0,sprites.Length)];
        //Rotate the sprite a random angle to make all asteroids look different
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        //Change the scale of the spawned asteroid instead of the size
        //If the size is changed, then the mass is changed which will affect other physical properties
        this.transform.localScale = Vector3.one * this.size;
        //the larger the size the larger the mass
        asteroid.mass = this.size;
        
    }

    public void SetTrajectory(Vector2 direction)
    {
        asteroid.AddForce(direction * speed);

        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //verify if the asteroid collided with a bullet
        if(collision.gameObject.tag== "Bullet"){
            //check if the size of the asteroid is big enough to be split
            if((this.size * 0.5f)>= this.minSize){
                CreateSplit();
                CreateSplit();
            }
            //regardless of the condition destroy the old asteroid
            Destroy(this.gameObject);
        }

    }
    //Split big asteroids into small ones on collission
    private void CreateSplit()
    {
        //get the position of the old asteroid
        Vector2 position = this.transform.position;
        //offset the position of the new half asteroids by a little
        position += Random.insideUnitCircle * 200.0f;
        Asteroid half = Instantiate(this, position, this.transform.rotation);
        
        //Cut the size in half
        half.size = this.size * 0.5f;
        //Give the new asteroids a random new trajectory
        half.SetTrajectory(Random.insideUnitCircle.normalized*500.0f); 
        Debug.Log("half asteroid position", half);   
        }
}
