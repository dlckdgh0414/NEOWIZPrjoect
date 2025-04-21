using System;
using UnityEngine;

public enum UpgradeType
{
    Int, Float, String
}

public enum NodeType
{
    Normal, Choice, Reqire
}

[CreateAssetMenu(fileName = "NodeSO", menuName = "SO/NodeSO")]
public class NodeSO : ScriptableObject
{
    public string fruitsName;
    public int price;
    public Sprite icon;
    public string upgradeValue;
    public UpgradeType UpgradeType;
    [TextArea]
    public string description;

    public bool isActive;
    public SkillTreeNode SkillTreeNode { get; set; }

    private void OnValidate()
    {
        fruitsName = this.name;
    }
}