using UnityEditorInternal;
using UnityEngine;

public class MousePlayerIdleState : MousePlayerCanAttack
{
    public float speed = 2f;  
    public float radius = 3f;
    private float angle = 0f;
    public MousePlayerIdleState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //플레이어 한테 옴
        //_energyCompo.StartFill();
        //_energyCompo.StartFillMag();
    }

    public override void Update()
    {
        base.Update();
        // 각도 증가 (시간에 따라)
        angle += speed * Time.deltaTime;

        // 라디안 단위로 변환해서 좌표 계산
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        // 오브젝트 위치 설정
        _player.transform.position = new Vector3(_player.player.position.x + x, _player.transform.position.y, _player.player.position.z + z);
    }

    public override void Exit()
    {
        base.Exit();
        //_energyCompo.StopHeal();
        //_energyCompo.StopMag();
    }
}
