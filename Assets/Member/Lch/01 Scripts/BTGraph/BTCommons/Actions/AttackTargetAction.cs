using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "AttackTarget ", story: "[Attack] [Target] in [AttackTrigger] in [dealer]", category: "Action", id: "d3beaee3c852cbf70a2b94f716b8b617")]
public partial class AttackTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<Attack> Attack;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<EntityAnimatorTrigger> AttackTrigger;
    [SerializeReference] public BlackboardVariable<Entity> Dealer;
    private bool _isAttack;

    protected override Status OnStart()
    {
        _isAttack = false;
        AttackTrigger.Value.OnAttackTrigger += HandleAttackTrigger;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return _isAttack ? Status.Success : Status.Running;
    }

    protected override void OnEnd()
    {
        AttackTrigger.Value.OnAttackTrigger -= HandleAttackTrigger;
    }

    private void HandleAttackTrigger()
    {
        Attack.Value.EnemyAttack(Target.Value,Dealer.Value);
        _isAttack = true;
    }
}

