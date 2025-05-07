using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ThrowtheShoul", story: "[Wolf] Throw the [Shoul] in [ShotPos] with [target] to [AttackTrigger] in [EnemyAttack]", category: "Action", id: "15bfceabd999cb3a56227ed94a909d7f")]
public partial class ThrowtheShoulAction : Action
{
    [SerializeReference] public BlackboardVariable<Enemy> Wolf;
    [SerializeReference] public BlackboardVariable<WolfParryingBullet> Shoul;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<Transform> ShotPos;
    [SerializeReference] public BlackboardVariable<EntityAnimatorTrigger> AttackTrigger;
    [SerializeReference] public BlackboardVariable<WolfParryingAttackCompo> EnemyAttack;
    private bool _isAttack;
    protected WolfParryingBullet _bullet;

    protected override Status OnStart()
    {
        _isAttack = false;
        AttackTrigger.Value.OnAttackTrigger += HandleWolfAttack;
        _bullet = GameObject.Instantiate(Shoul, ShotPos.Value.position, Quaternion.identity) as WolfParryingBullet;
        EnemyAttack.Value.SetBullet(_bullet);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return _isAttack ? Status.Success : Status.Running;
    }

    protected override void OnEnd()
    {
        AttackTrigger.Value.OnAttackTrigger -= HandleWolfAttack;
    }

    private void HandleWolfAttack()
    {
        _isAttack = true;
        EnemyAttack.Value.EnemyAttack(Target.Value, Wolf.Value);
    }
}

