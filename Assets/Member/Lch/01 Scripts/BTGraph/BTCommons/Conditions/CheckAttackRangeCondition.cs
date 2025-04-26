using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "CheckAttackRange", story: "distance between [Self] in [Target]", category: "Conditions", id: "53b2df49cc2e34a22e09da271a8c2e90")]
public partial class CheckAttackRangeCondition : Condition
{
    [SerializeReference] public BlackboardVariable<Enemy> Self;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    public override bool IsTrue()
    {
        float dir = Vector3.Distance(Self.Value.transform.position, Target.Value.position);
        return dir < Self.Value.attackRange;
    }
}
