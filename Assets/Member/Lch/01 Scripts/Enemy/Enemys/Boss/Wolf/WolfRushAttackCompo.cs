using UnityEngine;

public class WolfRushAttackCompo : Attack
{
    [SerializeField] private Wolf wolf;
    [SerializeField] private float Damge;
    [SerializeField] private Rigidbody rbCompo;

    private void Start()
    {
        wolf.RushDamge = Damge;
    }
    public override void EnemyAttack(Transform target, Entity entity)
    {
        wolf.IsAttack = true;
        RushAttack(target);
    }
    private void RushAttack(Transform target)
    {
        rbCompo.MovePosition(target.position);
    }
}
