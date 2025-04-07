using UnityEngine;

public class GhoulAttackCompo : Attack
{
    public override void EnemyAttack(Transform target, Entity entity)
    {
        Debug.Log("Attack");
    }
}
