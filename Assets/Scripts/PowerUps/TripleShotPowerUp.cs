using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/SpeedInc")]
public class TripleShotPowerUp : PowerUpEffect
{
    public override void Effect(GameObject player)
    {
        if (player.GetComponent<Player>().tripleShot != null) {
            player.GetComponent<Player>().StopCoroutine(player.GetComponent<Player>().tripleShot);
            player.GetComponent<Player>().tripleShot = player.GetComponent<Player>().StartCoroutine(LimitedEffect(player));
        } else {
            player.GetComponent<Player>().tripleShot = player.GetComponent<Player>().StartCoroutine(LimitedEffect(player));
        }
    }

    public override void EndEffect(GameObject player)
    {
        
    }

    IEnumerator LimitedEffect(GameObject player) {
        yield return new WaitForSeconds(10f);
        EndEffect(player);
        player.GetComponent<Player>().tripleShot = null;
    }

}
