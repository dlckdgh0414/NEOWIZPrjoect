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
        _skillCompo = entity.GetComponentInChildren<MousePlayerSkillCompo>();
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("½¯µå");
    }

    public override void Update()
    {
        base.Update();
        _energyCompo.UseEnergyTimeAtTime(10);

        if (!_energyCompo.isEnergyNotzero)
            _skillCompo.HandleBarrierCanceled();
    }

    public override void Exit()
    {
        _player._isSkilling = false;
        base.Exit();
    }
}
