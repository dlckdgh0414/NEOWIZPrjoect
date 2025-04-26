using System;
using UnityEngine;

public class EntityAnimatorTrigger : MonoBehaviour, IEntityComponet
{

    public Action OnAnimationEndTrigger;
    public Action OnAttackTrigger;

    public Action OnAttackTriggerEnd;

    public event Action OnAttackVFXTrigger;

    public event Action OnStrongAttackTrigger;

    public event Action OnBarrierPressed;
    public event Action OnAttackDash;

    public event Action<bool> OnRollingStatusChange;

    public event Action<bool> OnManualRotationTrigger;

    private Entity _entity;

    public void Initialize(Entity entity)
    {
        _entity = entity;
    }

    private void AnimationEnd()
    {
        OnAnimationEndTrigger?.Invoke();
    }

    private void AttackDash() => OnAttackDash?.Invoke();
    private void RollingStart() => OnRollingStatusChange?.Invoke(true);
    private void RollingEnd() => OnRollingStatusChange?.Invoke(true);

    private void PlayAttackVFX() => OnAttackVFXTrigger?.Invoke();

    private void PlayerStrongAttack() => OnStrongAttackTrigger?.Invoke();
    private void AttackEnd() => OnAttackTriggerEnd?.Invoke();


    private void BarrierPressed() => OnBarrierPressed?.Invoke();


    private void Attack()
    {
        OnAttackTrigger?.Invoke();
    }

    private void StartManualRotation() => OnManualRotationTrigger?.Invoke(true);
    private void StopManualRotation() => OnManualRotationTrigger?.Invoke(false);
}
