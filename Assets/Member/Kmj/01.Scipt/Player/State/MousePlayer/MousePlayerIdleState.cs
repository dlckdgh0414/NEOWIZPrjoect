using UnityEditorInternal;
using UnityEngine;

public class MousePlayerIdleState : MousePlayerCanAttack
{
    public float speed = 2f;  
    public float radius = 1f;
    private float angle = 0f;
    public MousePlayerIdleState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }

    public override void Enter()
    {
        _player.isUseDashSkill = false;
        base.Enter();
        //플레이어 한테 옴
        //_energyCompo.StartFill();
        //_energyCompo.StartFillMag();
    }

    public override void Update()
    {
        base.Update();
        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        _player.transform.position = new Vector3(_player.player.transform.position.x 
            + x, _player.player.transform.position.y, _player.player.transform.position.z + z);
    }

    public override void Exit()
    {
        base.Exit();
        //_energyCompo.StopHeal();
        //_energyCompo.StopMag();
    }
}
