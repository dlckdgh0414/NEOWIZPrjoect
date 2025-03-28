using UnityEngine;

public class PlayerCanSkillCompo : PlayerCanAttackState
{
    private EntitySkillCompo _skillCompo;
    public PlayerCanSkillCompo(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _skillCompo = entity.GetCompo<EntitySkillCompo>();
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput.OnStrongAttackPressed += HandleStrongAttackPressed;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void HandleStrongAttackPressed()
    {
        if (_skillCompo.CanUseSkill("StrongAttack"))
            _player.ChangeState("STRONGATTACK");
        else
            return;
    }
}
