using Unity.Behavior;
using UnityEngine;

public abstract class BTBoss : Enemy
{
    private BossStateChangeEvent _stateChannel;
    private EntityFeedbackData _feedbackData;
    private BlackboardVariable<BTBossState> _state;

    protected override void Start()
    {
        BlackboardVariable<BossStateChangeEvent> stateChannelVariable =
            GetBlackboardVariable<BossStateChangeEvent>("BossStateChangeEvent");
        _stateChannel = stateChannelVariable.Value;
        Debug.Assert(_stateChannel != null, $"StateChannel variable is null {gameObject.name}");

        _state = GetBlackboardVariable<BTBossState>("BossState");
    }
    protected override void HandleHit()
    {
        if (IsDead) return;

        if (_state.Value == BTBossState.STUN || _state.Value == BTBossState.HIT) return;

        if (_feedbackData.IsLastStopHit)
        {
            _stateChannel.SendEventMessage(BTBossState.HIT);
        }
        else if (_state.Value == BTBossState.PATROL)
        {
            _stateChannel.SendEventMessage(BTBossState.IDLE);
        }
    }

    protected override void HandleDead()
    {
        if (IsDead) return;
        gameObject.layer = DeadBodyLayer;
        IsDead = true;
        _stateChannel.SendEventMessage(BTBossState.DEAD);
    }

    protected override void HandleStun()
    {
        
    }
}
