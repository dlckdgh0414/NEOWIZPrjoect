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
        //�÷��̾� ���� ��
        //_energyCompo.StartFill();
        //_energyCompo.StartFillMag();
    }

    public override void Update()
    {
        base.Update();
        // ���� ���� (�ð��� ����)
        angle += speed * Time.deltaTime;

        // ���� ������ ��ȯ�ؼ� ��ǥ ���
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        // ������Ʈ ��ġ ����
        _player.transform.position = new Vector3(_player.player.position.x + x, _player.transform.position.y, _player.player.position.z + z);
    }

    public override void Exit()
    {
        base.Exit();
        //_energyCompo.StopHeal();
        //_energyCompo.StopMag();
    }
}
