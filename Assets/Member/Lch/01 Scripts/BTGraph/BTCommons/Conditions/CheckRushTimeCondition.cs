using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "CheckRushTime", story: "Check Rush Time in [Timer]", category: "Conditions", id: "055905aa53c2fa14085c05b76fe2ce8f")]
public partial class CheckRushTimeCondition : Condition
{
    [SerializeReference] public BlackboardVariable<float> Timer;
    private bool IsRush = false;
    private float currentTime = 0f;
    public override bool IsTrue()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= Timer.Value)
        {
            Debug.Log("Rush Time!");
            currentTime = 0f;
           return true;
        }
        return false;
    }

}
