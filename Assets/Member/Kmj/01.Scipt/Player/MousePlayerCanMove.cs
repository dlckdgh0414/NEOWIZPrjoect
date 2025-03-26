using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MousePlayerCanMove : EntityState
{
    protected MousePlayer _player;
    public MousePlayerCanMove(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _player = entity as MousePlayer;
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput.OnClickMovePressed += HandleMovePressed;
    }

    public override void Update()
    {
        base.Update();
    }
    public override void Exit()
    {
        _player.PlayerInput.OnClickMovePressed -= HandleMovePressed;
        base.Exit();
    }

    private void HandleMovePressed()
    {
        _player.ChangeState("MOVE");
    }
}
