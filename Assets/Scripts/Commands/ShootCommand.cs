using UnityEngine;
public class ShootCommand: Command{

    private Bullet shootBullet;
    private Player player;

    //Pass the entity to the base class
    public ShootCommand(Player entity) : base(entity){
        player = entity;
    }
    //Project the bullet in the upwards direction of the passed entity
    public override void Execute()
    {
        Bullet bullet = Instantiate(player.bulletPrefab, player.transform.position, player.transform.rotation);
        bullet.Project(entity.transform.up);
    }
}
