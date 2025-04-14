using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GetComponentFromEntity", story: "Get components from [btEnemy]", category: "Action", id: "7b26f18fcb48b2eacdd9324761fdf405")]
public partial class GetComponentFromEntityAction : Action
{
    [SerializeReference] public BlackboardVariable<BTEnemy> BtEnemy;

    protected override Status OnStart()
    {
        BTEnemy enemy = BtEnemy.Value;
        Debug.Assert(enemy != null,$"에너미없다 이자식아");
        SetVariableToBT(enemy, "Mover", enemy.GetComponentInChildren<EnemyMover>());
        SetVariableToBT(enemy, "Renderer",enemy.GetComponentInChildren<EnemyRenderer>());
        SetVariableToBT(enemy, "AnimTrigger",enemy.GetCompo<EntityAnimatorTrigger>());
        SetVariableToBT(enemy, "Attack",enemy.GetComponentInChildren<Attack>());
        SetVariableToBT(enemy, "MainAnim", enemy.GetComponentInChildren<Animator>());
        return Status.Success;
    }

    private void SetVariableToBT<T>(BTEnemy enemy, string variableName, T component)
    {
        Debug.Assert(component != null, $"Check {variableName} component exist on {enemy.gameObject.name}");
        BlackboardVariable<T> variable = enemy.GetBlackboardVariable<T>(variableName);
        variable.Value = component;
    }
}

