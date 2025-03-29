using UnityEngine;

[CreateAssetMenu(fileName = "EntityFinder", menuName = "SO/Entity/Finder")]
public class EntityFinderSO : ScriptableObject
{
    [SerializeField] private string targetTag;
    public Entity target;

    public void SetPlayer(Entity entity)
    {
        target = entity;
    }
}
