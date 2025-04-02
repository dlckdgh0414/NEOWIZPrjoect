using System;
using UnityEngine;

public class EntityAnimatorTrigger : MonoBehaviour, IEntityComponet
{

    public Action OnAnimationEndTrigger;

    public  Action OnAttackTriggerEnd, OnStrongAtk;

    public event Action OnAttackVFXTrigger;

    public event Action<bool> OnRollingStatusChange;

    private Entity _entity;

    public void Initialize(Entity entity)
    {
        _entity = entity;
    }

    private void AnimationEnd()
    {
        OnAnimationEndTrigger?.Invoke();
    }
    private void RollingStart() => OnRollingStatusChange?.Invoke(true);
    private void RollingEnd() => OnRollingStatusChange?.Invoke(true);

    private void PlayAttackVFX() => OnAttackVFXTrigger?.Invoke();


    private void AttackEnd() => OnAttackTriggerEnd?.Invoke();

    private void StrongSkill() => OnStrongAtk?.Invoke();
}
