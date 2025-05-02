using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    public SkillTreeSO skillTreeSO;
    [SerializeField] private GameEventChannelSO eventChannelSO;
    private List<SkillTreeNode> _fruitsList;
    
    private SkillTreeEvent _skillTreeEvent = SkillTreeEventChannel.SkillTreeEvent;

    private void Awake()
    {
        _fruitsList = transform.GetComponentsInChildren<SkillTreeNode>(true).ToList();
        _fruitsList.ForEach(f =>
        {
            f.Initialize();

            if (f.IsRootNode)
                SetColor(f);
        });
        _fruitsList.ForEach(f => f.NodeButton.onClick.AddListener(() => SelectFruits(f.GetNodeSO())));
        eventChannelSO.AddListener<SkillTreePurchaseEvent>(HandleFruitsPurchase);
    }


    private void HandleFruitsPurchase(SkillTreePurchaseEvent skillTreeEvent)
    {
        ConnectColor(skillTreeEvent.SkillTreeNode);
    }

    private void SelectFruits(NodeSO selectedNode)
    {
        _skillTreeEvent.NodeSO = selectedNode;
        eventChannelSO.RaiseEvent(_skillTreeEvent);
    }

    private void ConnectColor(SkillTreeNode f)
    {
        f.transform.SetSiblingIndex(f.ParentNode.transform.GetSiblingIndex() - 1);
    
        Sequence seq = DOTween.Sequence();
    
        for (int i = 0; i < 3; i++) {
            int idx = i;
            seq.Append(DOTween.To(() => 0f, amount 
                    => f.FillBranch[idx].fillAmount = amount, 1f,
                0.2f).SetEase(Ease.OutQuad));
        }
    
        seq.OnComplete(() => SetColor(f));
    }

    private void SetColor(SkillTreeNode f)
    {
        Sequence seq = DOTween.Sequence();
        Outline outline = f.GetComponentInChildren<Outline>();
        Color lineColor = outline.effectColor;
        
        DOTween.To(() => lineColor, color => outline.effectColor = color, f.branchColor, 1.5f)
            .SetEase(Ease.InCubic);

        seq.Join(f.NodeIcon.DOColor(f.branchColor, 1f))
            .Join(f.NodeIcon.DOFade(1f, 1f))
            .OnComplete(() =>
            {
                f.ConnectedNodes.ForEach(n =>
                {
                    n.NodeIcon.DOColor(Color.white, 1f);
                    n.NodeIcon.DOFade(1f, 1f);
                    n.NodeButton.interactable = true;
                });
            });
    }

    private void ActiveNodeColor(SkillTreeNode node)
    {
        node.NodeIcon.DOColor(Color.white, 1f);
        node.NodeIcon.DOFade(1f, 1f);
        node.NodeButton.interactable = true;
    }
    
    private void InActiveNodeColor(SkillTreeNode node)
    {
        node.NodeIcon.DOColor(Color.black, 1f);
        node.NodeIcon.DOFade(0f, 1f);
        node.NodeButton.interactable = false;
    }
}
