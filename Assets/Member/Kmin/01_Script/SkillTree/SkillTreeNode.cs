using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SkillTreeNode : MonoBehaviour, IFruits
{
    [FormerlySerializedAs("nodeSo")] [FormerlySerializedAs("fruitsSO")] [SerializeField] private NodeSO nodeSO;
    [SerializeField] private Sprite fillNodeImage;
    [FormerlySerializedAs("connectedFruits")] [SerializeField] private List<SkillTreeNode> connectedNodes;
    [FormerlySerializedAs("isRootFruits")] [SerializeField] private bool isRootNode;
    [SerializeField] private float width = 10;
    [FormerlySerializedAs("connectColor")] [SerializeField] private Color branchColor = Color.magenta;
    
    [HideInInspector]
    [field:SerializeField] public List<Image> ConnectedBranch { get; private set; }
    [field:SerializeField] public List<Image> FillBranch { get; private set; }
    public Button NodeButton { get; private set; } = null;
    public bool CanPurchase { get; private set; } = false;

    public void Initialize()
    {
        NodeButton = GetComponentInChildren<Button>();
        if(isRootNode) connectedNodes.ForEach(f => f.CanPurchase = true);
        nodeSO.SkillTreeNode = this;
    }

    public void PurchaseFruits()
    {
        if (nodeSO.price <= CurrencyManager.Instance.GetCurrency(CurrencyType.Eon) && !nodeSO.isActive && CanPurchase)
        { 
            CurrencyManager.Instance.ModifyCurrency
                (CurrencyType.Eon, ModifyType.Substract, nodeSO.price);
            connectedNodes.ForEach(f => f.CanPurchase = true);
            nodeSO.isActive = true;
        }
    }

    public NodeSO GetNodeSO() => nodeSO;

    #region ConnectLineOnEditor
    [ContextMenu("ConnectLine")]
    private void ConnectLine()
    {
        foreach (SkillTreeNode f in connectedNodes)
        {
            if (f.ConnectedBranch.Count > 0)
            {
                f.ConnectedBranch.ForEach(n => {if (n != null) DestroyImmediate(n.gameObject); });
                f.FillBranch.ForEach(n => { if (n != null) DestroyImmediate(n.gameObject); });
                f.ConnectedBranch.Clear();
                f.FillBranch.Clear();
            }

            Transform root = f.transform.Find("Nodes");
            GameObject[] obj = new GameObject[3];
            Image[] nodes = new Image[3];

            for (int i = 0; i < 3; i++)
            {
                obj[i] = new GameObject($"Node{i}");
                nodes[i] = obj[i].AddComponent<Image>();
                nodes[i].transform.SetParent(root, false);
                nodes[i].transform.SetSiblingIndex(0);
                f.ConnectedBranch.Add(nodes[i]);
            }

            var rect = transform as RectTransform;
            Vector2 node1Pos = Vector2.zero;
            Vector2 selfPos = rect.position;
            Vector2 fruitsPos = f.GetComponentInChildren<Image>().rectTransform.position;

            int origin = 0;

            if (node1Pos == Vector2.zero)
            {
                node1Pos = new Vector2(selfPos.x, (fruitsPos.y + selfPos.y) / 2);
                origin = selfPos.y < node1Pos.y ? 0 : 1;
                ConnectBranch(selfPos, node1Pos, nodes[0], true);
                ConnectFillBranch(f.ConnectedBranch[0], root, f, origin);
            }

            Vector3 node2Pos = new Vector2(fruitsPos.x, node1Pos.y);
            origin = node1Pos.x < node2Pos.x ? 0 : 1;
            ConnectBranch(node1Pos, node2Pos, nodes[1], false);
            ConnectFillBranch(f.ConnectedBranch[1], root, f, origin);

            origin = node2Pos.y < fruitsPos.y ? 0 : 1;
            ConnectBranch(node2Pos, fruitsPos, nodes[2], true);
            ConnectFillBranch(f.ConnectedBranch[2], root, f, origin);
        }
    }

    private void ConnectFillBranch(Image target, Transform root, SkillTreeNode parent, int origin)
    {
        Image fillImg = new GameObject($"FillNode{parent.FillBranch.Count}").AddComponent<Image>();
        fillImg.transform.SetParent(root, false);
        fillImg.rectTransform.anchoredPosition = target.rectTransform.anchoredPosition;
        fillImg.rectTransform.sizeDelta = target.rectTransform.sizeDelta;
        fillImg.type = Image.Type.Filled;
        fillImg.fillAmount = 0;
        fillImg.sprite = fillNodeImage;
        fillImg.transform.SetSiblingIndex(root.childCount);

        if (fillImg.rectTransform.sizeDelta.x > fillImg.rectTransform.sizeDelta.y)
            fillImg.fillMethod = Image.FillMethod.Horizontal;
        else
            fillImg.fillMethod = Image.FillMethod.Vertical;

        fillImg.fillOrigin = origin;
        parent.FillBranch.Add(fillImg);
    }

    [ContextMenu("ClearAllBranch")]
    private void ClearAllBranch()
    {
        foreach(var fruits in connectedNodes)
        {
            fruits.ConnectedBranch.ForEach(n => DestroyImmediate(n.gameObject));
            fruits.FillBranch.ForEach(n => DestroyImmediate(n.gameObject));
            fruits.ConnectedBranch.Clear();
            fruits.FillBranch.Clear();
        }
    }

    [ContextMenu("ClearBranch")]
    private void ClearBranch()
    {
        ConnectedBranch.ForEach(n => DestroyImmediate(n.gameObject));
        FillBranch.ForEach(n => DestroyImmediate(n.gameObject));
        ConnectedBranch.Clear();
        FillBranch.Clear();
    }
    
    private void ConnectBranch(Vector3 pos1, Vector3 pos2, Image node, bool isVert)
    {
        Vector3 centerPos = (pos1 + pos2) / 2f;
        float distance = Vector3.Distance(pos1, pos2);

        node.rectTransform.position = centerPos;

        if (isVert)
            node.rectTransform.sizeDelta = new Vector2(width, distance + width);
        else
            node.rectTransform.sizeDelta = new Vector2(distance + width, width);
    }
    #endregion

    private void OnValidate()
    {
        if (FillBranch != null)
        {
            foreach (var node in FillBranch)
            {
                node.color = branchColor;
            }
        }
    }
}
