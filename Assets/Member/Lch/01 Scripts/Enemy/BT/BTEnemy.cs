using Unity.Behavior;
using UnityEngine;

public abstract class BTEnemy : Enemy
{
    private StateChangeEvent _stateChannel;
    private EntityFeedbackData _feedbackData;
    private BlackboardVariable<BTEnemyState> _state;

    protected override void Start()
    {
        BlackboardVariable<StateChangeEvent> stateChannelVariable =
            GetBlackboardVariable<StateChangeEvent>("BossStateChangeEvent");
        _stateChannel = stateChannelVariable.Value;
        Debug.Assert(_stateChannel != null, $"StateChannel variable is null {gameObject.name}");

        _state = GetBlackboardVariable<BTEnemyState>("BossState");
    }

    protected override void HandleHit()
    {
        if (IsDead) return;

        if (_state.Value == BTEnemyState.STUN || _state.Value == BTEnemyState.HIT) return;

        if (_feedbackData.IsLastStopHit)
        {
            _stateChannel.SendEventMessage(BTEnemyState.HIT);
        }
        else if (_state.Value == BTEnemyState.IDLE)
        {
            _stateChannel.SendEventMessage(BTEnemyState.CHASE);
        }
    }

    protected override void HandleDead()
    {

    }
}
