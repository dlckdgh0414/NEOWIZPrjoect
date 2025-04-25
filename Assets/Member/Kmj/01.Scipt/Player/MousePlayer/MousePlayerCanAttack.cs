using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MousePlayerCanAttack : EntityState
{
    protected MousePlayer _player;
    protected MousePlayerEnergy _energyCompo;
    public MousePlayerCanAttack(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _player = entity as MousePlayer;
        _energyCompo = entity.GetComponentInChildren<MousePlayerEnergy>(); 
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput.OnClickAttackPressed += HandleAttackPressed;
    }

    public override void Update()
    {
        base.Update();
    }
    public override void Exit()
    {
        _player.PlayerInput.OnClickAttackPressed -= HandleAttackPressed;
        base.Exit();
    }

    private void HandleAttackPressed()
    {
        _player.ChangeState("ATTACK");
    }
}
