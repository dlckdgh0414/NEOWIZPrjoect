using UnityEngine;

public class ShoulAttack : Attack
{

    [SerializeField] private SoulBullet soulBullet;

    public override void EnemyAttack(Transform target, Entity entity)
    {
        soulBullet = Instantiate(soulBullet,transform.position,Quaternion.identity);
        soulBullet.SetDir(target,entity);
    }
}
