using System;
using UnityEngine;

public class EntityAnimatorTrigger : MonoBehaviour, IEntityComponet
{

    public Action OnAnimationEndTrigger;
    public Action OnAttackTrigger;

    private Entity _entity;

    public void Initialize(Entity entity)
    {
        _entity = entity;
    }

    private void AnimationEnd()
    {
        OnAnimationEndTrigger?.Invoke();
    }

    private void Attack()
    {
        OnAttackTrigger?.Invoke();
    }
}
