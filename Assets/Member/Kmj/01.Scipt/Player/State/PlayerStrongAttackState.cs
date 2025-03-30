using UnityEngine;

public class PlayerStrongAttackState : PlayerState
{
    public PlayerStrongAttackState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("�� �����ε� �ȴ�");
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        _player._isSkilling = false;
        base.Exit();
    }
}
