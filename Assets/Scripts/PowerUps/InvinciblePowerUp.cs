using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePowerUp : PowerUpEffect
{
    public InvinciblePowerUp()
    {
    }
    public override void Effect(GameObject player)
    {
        if (player.GetComponent<Player>().invincible != null)
        {
            player.GetComponent<Player>().StopCoroutine(player.GetComponent<Player>().invincible);
            player.GetComponent<Player>().invincible = player.GetComponent<Player>().StartCoroutine(LimitedEffect(player));
        }
        else
        {
            GameManager manager = FindObjectOfType<GameManager>();
            manager.CallAchievement("bystander");
            player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
            player.gameObject.layer = LayerMask.NameToLayer("Respawn");
            player.GetComponent<Player>().invincible = player.GetComponent<Player>().StartCoroutine(LimitedEffect(player));
        }
    }

    public void EndEffect(GameObject player)
    {
        player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    IEnumerator LimitedEffect(GameObject player)
    {
        yield return new WaitForSeconds(10f);
        EndEffect(player);
    }

}
