using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TestSkillTree : MonoBehaviour
{
    [SerializeField] private GameEventChannelSO eventChannelSO;
    private List<SkillTreeNode> _fruitsList;
    
    private SkillTreeEvent _skillTreeEvent = SkillTreeEventChannel.SkillTreeEvent;

    private void Awake()
    {
        _fruitsList = transform.GetComponentsInChildren<SkillTreeNode>(true).ToList();
        _fruitsList.ForEach(f => f.Initialize());
        _fruitsList.ForEach(f => f.NodeButton.onClick.AddListener(() => SelectFruits(f.GetNodeSO())));
        eventChannelSO.AddListener<SkillTreePurchaseEvent>(HandleFruitsPurchase);
    }

    private void HandleFruitsPurchase(SkillTreePurchaseEvent skillTreeEvent)
    {
        StartCoroutine(TestConnect(skillTreeEvent.SkillTreeNode));
    }

    public void SelectFruits(NodeSO selectedNode)
    {
        Debug.Log("SelectFruits");
        _skillTreeEvent.NodeSo = selectedNode;
        eventChannelSO.RaiseEvent(_skillTreeEvent);
    }

    private IEnumerator TestConnect(SkillTreeNode f)
    {
        f.transform.SetSiblingIndex(f.ParentNode.transform.GetSiblingIndex() - 1);
        
        for (int i = 0; i < 3; i++)
        {
            DOTween.To(() => 0, amount => f.FillBranch[i].fillAmount = amount, 1f, 0.2f)
                .SetEase(Ease.OutQuad);
            yield return new WaitUntil(() => f.FillBranch[i].fillAmount == 1);
        }
        
        Outline outline = f.GetComponentInChildren<Outline>();
        Color lineColor = outline.effectColor;
        DOTween.To(() => lineColor, color => outline.effectColor = color, f.branchColor, 1.5f)
            .SetEase(Ease.InBounce);
    }
}
