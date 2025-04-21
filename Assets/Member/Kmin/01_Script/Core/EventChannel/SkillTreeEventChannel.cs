using UnityEngine;

public class SkillTreeEventChannel : MonoBehaviour
{
    public static SkillTreeEvent SkillTreeEvent = new SkillTreeEvent();
    public static SkillTreePurchaseEvent SkillTreePurchaseEvent = new SkillTreePurchaseEvent();
}

public class SkillTreeEvent : GameEvent
{
    public NodeSO NodeSo;
}

public class SkillTreePurchaseEvent : GameEvent
{
    public SkillTreeNode SkillTreeNode;
}

public class SkillTree : GameEvent
{
    public SkillTreeNode SkillTreeNode;
}
