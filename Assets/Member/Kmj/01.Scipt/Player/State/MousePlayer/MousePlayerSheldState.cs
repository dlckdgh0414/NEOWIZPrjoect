using UnityEngine;

public class MousePlayerSheldState : EntityState
{
    private MousePlayer _player;
    private MousePlayerEnergy _energyCompo;
    private MousePlayerSkillCompo _skillCompo;
    public MousePlayerSheldState(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _player = entity as MousePlayer;
        _energyCompo = entity.GetComponentInChildren<MousePlayerEnergy>();
     //   _skillCompo = entity.GetComponentInChildren<MousePlayerSkillCompo>();
    }

    public override void Enter()
    {
        base.Enter();
        _player.LookAtMouse();
       // _energyCompo.StartSkill(5);
        Debug.Log("½¯µå");
    }

    public override void Update()
    {
        base.Update();

        if (!_energyCompo.isEnergyNotzero)
        {
            _skillCompo.HandleBarrierCanceled();
        }
    }

    public override void Exit()
    {
       // _energyCompo.CancelSkill();
        _player._isSkilling = false;
        base.Exit();
    }
}
