using UnityEngine;

public class SkillTreeEventChannel : MonoBehaviour
{
    public static SkillTreeEvent SkillTreeEvent = new SkillTreeEvent();
    public static SkillTreePurchaseEvent SkillTreePurchaseEvent = new SkillTreePurchaseEvent();
}

public class SkillTreeEvent : GameEvent
{
    public NodeSO NodeSO;
}

public class SkillTreePurchaseEvent : GameEvent
{
    public SkillTreeNode SkillTreeNode;
}
