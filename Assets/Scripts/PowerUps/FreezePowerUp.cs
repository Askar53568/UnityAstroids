using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Heart")]
public class FreezePowerUp : PowerUpEffect
{
    List<Asteroid> asteroids;
    List<Vector2> velocity;


    public FreezePowerUp()
    {
        asteroids = new List<Asteroid>();
        velocity = new List<Vector2>();
    }
    public override void Effect(GameObject player)
    {
        if (ProfileSingleton.instance.playing)
        {
            asteroids = new List<Asteroid>(FindObjectsOfType<Asteroid>());
            try
            {
                for (int i = 0; i < asteroids.Count; i++)
                {
                    asteroids[i].GetComponent<Rigidbody2D>().velocity = velocity[i];
                }
                player.GetComponent<Player>().StopCoroutine(player.GetComponent<Player>().freeze);
                player.GetComponent<Player>().freeze = player.GetComponent<Player>().StartCoroutine(LimitedEffect(player));
            }
            catch (System.ArgumentOutOfRangeException) { }
        }
        else
        {
            ProfileSingleton.instance.playing = true;
            asteroids.Clear();
            velocity.Clear();
            asteroids = new List<Asteroid>(FindObjectsOfType<Asteroid>());
            velocity = new List<Vector2>();
            foreach (Asteroid asteroid in asteroids)
            {
                velocity.Add(asteroid.GetComponent<Rigidbody2D>().velocity);
                asteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            player.GetComponent<Player>().freeze = player.GetComponent<Player>().StartCoroutine(LimitedEffect(player));
        }
    }

    public void EndEffect(GameObject player)
    {
        for (int i = 0; i < asteroids.Count; i++)
        {
            if (asteroids[i] != null)
            {
                asteroids[i].GetComponent<Rigidbody2D>().velocity = velocity[i];
            }
        }
        ProfileSingleton.instance.playing = false;
    }

    IEnumerator LimitedEffect(GameObject player)
    {
        yield return new WaitForSeconds(2f);
        EndEffect(player);
        player.GetComponent<Player>().freeze = null;

    }

}
