using UnityEngine;

public class WolfRushAttackCompo : Attack
{
    [SerializeField] private Wolf wolf;
    [SerializeField] private float Damge;
    [SerializeField] private Rigidbody rbCompo;
    private Vector3 _moveDir = Vector3.zero;

    private void Start()
    {
        wolf.RushDamge = Damge;
    }
    public override void EnemyAttack(Transform target, Entity entity)
    {
        _moveDir = target.position - entity.transform.position;
        
    }
    private void RushAttack(Transform target)
    {
        rbCompo.MovePosition(target.position);
    }
}
