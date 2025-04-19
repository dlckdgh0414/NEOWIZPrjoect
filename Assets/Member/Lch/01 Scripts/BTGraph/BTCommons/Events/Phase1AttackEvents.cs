using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/Phase1AttackEvents")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "Phase1AttackEvents", message: "Phase1 to [Attack] Changes", category: "Events", id: "98f6f8c369a6ab3f58d616beebd0341d")]
public partial class Phase1AttackEvents : EventChannelBase
{
    public delegate void Phase1AttackEventsEventHandler(WolfPhase1AttackEnum Attack);
    public event Phase1AttackEventsEventHandler Event; 

    public void SendEventMessage(WolfPhase1AttackEnum Attack)
    {
        Event?.Invoke(Attack);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<WolfPhase1AttackEnum> AttackBlackboardVariable = messageData[0] as BlackboardVariable<WolfPhase1AttackEnum>;
        var Attack = AttackBlackboardVariable != null ? AttackBlackboardVariable.Value : default(WolfPhase1AttackEnum);

        Event?.Invoke(Attack);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        Phase1AttackEventsEventHandler del = (Attack) =>
        {
            BlackboardVariable<WolfPhase1AttackEnum> var0 = vars[0] as BlackboardVariable<WolfPhase1AttackEnum>;
            if(var0 != null)
                var0.Value = Attack;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as Phase1AttackEventsEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as Phase1AttackEventsEventHandler;
    }
}

