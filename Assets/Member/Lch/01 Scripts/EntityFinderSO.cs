using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityFinder", menuName = "SO/Entity/Finder")]
public class EntityFinderSO : ScriptableObject
{
    [SerializeField] private string targetTag;
    public List<GameObject> Targets;

    public void SetPlayer(GameObject entity)
    {
        Targets.Add(entity);
    }

    private void OnDestroy()
    {
        Targets.Clear();    
    }
}
