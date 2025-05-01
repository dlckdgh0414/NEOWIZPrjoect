using UnityEngine;

public class ShoulAttack : Attack
{

    [SerializeField] private SoulBullet soulBullet;

    public override void EnemyAttack(Transform target, Entity entity)
    {
        SoulBullet bullet;
        bullet = Instantiate(soulBullet, transform.position, Quaternion.identity);
        bullet.SetDir(target,entity);
    }
}
