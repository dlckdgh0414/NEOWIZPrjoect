using UnityEngine;

public class TestEnemy : Entity
{
    public EntityHealth _heath { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        _heath = GetCompo<EntityHealth>();
    }


}
