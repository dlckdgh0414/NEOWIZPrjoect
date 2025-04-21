using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MousePlayerMoveAndAttackState : MousePlayerCanMove
{
    private Vector3 dir = Vector3.zero;
    private RaycastHit hit;
    private float maxDistatnce = 8f;

    public MousePlayerMoveAndAttackState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("MouseMove");

        bool isHit = Physics.SphereCast(_entity.transform.position, _entity.transform.lossyScale.x * 0.5f,
            _entity.transform.forward, out hit, maxDistatnce);

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
