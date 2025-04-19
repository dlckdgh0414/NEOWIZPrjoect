using UnityEngine;

public class EntityFeedbackData : MonoBehaviour,IEntityComponet
{
    #region Hit data

    [field: SerializeField] public bool IsLastHitCritical { get; set; } = false;
    [field: SerializeField] public bool IsLastStopHit { get; set; } = false;
    [field: SerializeField] public int LastStunLevel { get; set; } = 0;
    [field: SerializeField] public Entity LastEntityWhoHit { get; set; }

    #endregion

    private Entity _entity;
    public void Initialize(Entity entity)
    {
        _entity = entity;
    }
}
