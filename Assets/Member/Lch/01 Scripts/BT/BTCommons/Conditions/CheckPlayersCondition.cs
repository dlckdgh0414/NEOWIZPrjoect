using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using static Unity.Behavior.Node;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "CheckPlayers", story: "distance between [Self] and [Targets] than [AttackRange] in [Target]", category: "Conditions", id: "7f2a206d95e3acda3c8c4c989e1e1939")]
public partial class CheckPlayersCondition : Condition
{
    [SerializeReference] public BlackboardVariable<BTEnemy> Self;
    [SerializeReference] public BlackboardVariable<List<GameObject>> Targets;
    [SerializeReference] public BlackboardVariable<float> AttackRange;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    public override bool IsTrue()
    {
        foreach (var target in Targets.Value)
        {
            if (Vector3.Distance(Self.Value.transform.position, target.transform.position) <= AttackRange)
            {
                Target.Value = target.transform;
                return true;
            }
        }

        return false;
    }

    public override void OnStart()
    {
        
    }

    public override void OnEnd()
    {
    }
}
