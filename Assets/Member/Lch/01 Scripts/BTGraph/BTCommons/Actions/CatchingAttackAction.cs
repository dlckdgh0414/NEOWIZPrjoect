using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CatchingAttack", story: "[WolfEnemy] Catching is [Attack] with [AttackTrigger] to [Mover] with [Target]", category: "Action", id: "cf746ce41ea676b860dd5ea7f8490fc8")]
public partial class CatchingAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<WolfCatchAttackCompo> Attack;
    [SerializeReference] public BlackboardVariable<Wolf> WolfEnemy;
    [SerializeReference] public BlackboardVariable<EntityAnimatorTrigger> AttackTrigger;
    [SerializeReference] public BlackboardVariable<EnemyMover> Mover;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    protected override Status OnStart()
    {
        AttackTrigger.Value.OnAttackTrigger += HandleAttackTrigger;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (WolfEnemy.Value.IsCatchingStop)
        {

             return Status.Success;
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
        AttackTrigger.Value.OnAttackTrigger -= HandleAttackTrigger;
    }

    private void HandleAttackTrigger()
    {
        Attack.Value.EnemyAttack(Target.Value,WolfEnemy.Value);
    }
}

