using UnityEngine;

public class Enemy : Entity
{
    protected override void HandleHit()
    {
        Debug.Log("�ڵ� ��");
    }

    protected override void HandleDead()
    {
        Debug.Log("�ڵ� ����");
    }

    protected override void AfterInitialize()
    {
        Debug.Log("���ʹ� �� �ʱ�ȭ");
        base.AfterInitialize();
    }
}
