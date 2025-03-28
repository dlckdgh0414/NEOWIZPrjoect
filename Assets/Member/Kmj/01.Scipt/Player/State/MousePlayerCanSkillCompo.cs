using System;

public class MousePlayerCanSkillState : MousePlayerCanMove
{
    public MousePlayerCanSkillState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }

    public override void Enter()
    {
        _player.PlayerInput.OnSheldPressd += HandleSheldPressed;
        base.Enter();
    }

    private void HandleSheldPressed()
    {
        if (_player._skillCompo.CanUseSkill("Sheld"))
            _player.ChangeState("SHELD");
    }

    public override void Exit()
    {
        base.Exit();
        _player.PlayerInput.OnSheldPressd -= HandleSheldPressed;
    }

}
