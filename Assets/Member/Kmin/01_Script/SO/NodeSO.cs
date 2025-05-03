using System;
using System.Collections.Generic;
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
    public NodeType NodeType;
    public UpgradeType UpgradeType;
    [TextArea]
    public string description;

    public bool isPurchase { get; set; } = false;
    public bool isActive {get; set;}
    public SkillTreeNode SkillTreeNode { get; set; }

    private void OnValidate()
    {
        fruitsName = this.name;
    }
}