

using System.Linq;
using UnityEngine;

public class MousePlayerAttackState : EntityState
{
    private MousePlayer _player;
    public MousePlayerAttackState(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _player = entity as MousePlayer;
    }

    public override void Enter()
    {
        base.Enter();
        _player.isUseDashSkill = true;
        _player._moveCompo.StopImmediately();

        Collider[] collider = Physics.OverlapBox(_player.transform.position, _player._attackCompo._boxSize,
             Quaternion.identity, _player._whatIsEnemy);

        foreach (var Obj in collider)
        {
            if (Obj.TryGetComponent(out IDamgable damage))
            {
                Debug.Log("공격됨");
                damage.ApplyDamage(10, true, 0, _player);
            }
            else if (Obj.TryGetComponent(out InteractionObj Interaction))
            {
                Debug.Log("상호작용됨");
                Interaction.InteractEvent.Invoke();    
            }
        }
        

    }

    public override void Update()
    {
        base.Update();

        //Vector3.MoveTowards(_entity.transform.position, _attackPosition,)


        if (_isTriggerCall)
            _player.ChangeState("BACK");
    }

    public override void Exit()
    {
        _player._moveCompo.StopImmediately();
        base.Exit();
    }
}
