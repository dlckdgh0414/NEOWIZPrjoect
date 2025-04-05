using UnityEngine;

public class GhoulAttackCompo : Attack
{
    public override void EnemyAttack(Transform target)
    {
        Debug.Log("Attack");
    }
}
