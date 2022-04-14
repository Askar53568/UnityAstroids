using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    public float size = 1.0f;

    public float minSize = 0.5f;
    public float maxSize = 1.5f;

    public float speed = 3000.0f;

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

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        asteroid.mass = this.size;
        
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
