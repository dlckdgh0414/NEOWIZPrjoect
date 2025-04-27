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
            GetBlackboardVariable<StateChangeEvent>("StateChangeEvent"); 
        _stateChannel = stateChannelVariable.Value;
        Debug.Assert(_stateChannel != null, $"StateChannel variable is null {gameObject.name}");

        _state = GetBlackboardVariable<BTEnemyState>("EnemyState");

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
        Debug.Log("È÷ÆR");
        if (IsDead) return;
        gameObject.layer = DeadBodyLayer;
        IsDead = true;
        _stateChannel.SendEventMessage(BTEnemyState.DEAD);
    }

    protected override void HandleStun()
    {
        
    }

    public void BackStepEnemy(Transform target, float power, Transform enemy)
    {
        enemy.LookAt(target);
        _rbCompo.AddForce(Vector3.up * 1.5f, ForceMode.Impulse);

        _rbCompo.AddForce(-enemy.forward * power, ForceMode.Impulse);
        Debug.Log("È÷ÆR");
    }
}
