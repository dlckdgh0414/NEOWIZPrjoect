using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerIdleState : PlayerCanAttackState
{
    private CharacterMovement _movement;
    public PlayerIdleState(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _movement = entity.GetCompo<CharacterMovement>();
    }


    public override void Update()
    {
        base.Update();
        Debug.Log("Idle");
        Vector2 movementKey = _player.PlayerInput.MovementKey;
        _movement.SetMovementDirection(movementKey);
        if (movementKey.magnitude > _inputThereshold)
        {
            _player.ChangeState("MOVE");
        }
    }
}
