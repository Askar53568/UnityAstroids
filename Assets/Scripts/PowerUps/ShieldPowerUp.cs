using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : PowerUpEffect
{
    public Shield shield;
    float lifeTime;
    public ShieldPowerUp()
    {
        lifeTime = 5f;
        shield = new Shield();
    }

    public override void Effect(GameObject player)
    {
        GameManager manager = FindObjectOfType<GameManager>();
        manager.CallAchievement("armored");
        //manager.player.GetComponent<BoxCollider2D>().size; 
        if (FindObjectOfType<Shield>())
        {
            Shield oldShield = FindObjectOfType<Shield>();
            oldShield.lifeTime = oldShield.lifeTime+ 20f;
        }
        else
        {
            Shield shield = Instantiate(manager.shieldPre, player.transform.position, new Quaternion(0, 0, 0, 0));

        }
    }

}
