using UnityEngine;

public class MousePlayerMoveState : MousePlayerCanMove
{

    private Vector3 dir = Vector3.zero;
    public MousePlayerMoveState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("MouseMove");
        _player.rbCompo.linearVelocity = Vector3.zero;

        dir = _player.MoveToMousePosition(_player);
    }

    public override void Update()
    {
        base.Update();

        _player.transform.LookAt(dir);

        _player.transform.position = Vector3.MoveTowards(_player.transform.position,
            dir, 15f * Time.deltaTime);

        _player.transform.LookAt(dir);

        if (_player.transform.position == dir)
        {
            _player.ChangeState("IDLE");
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}
