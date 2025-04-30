using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeTooltip : MonoBehaviour
{
    [SerializeField] private GameEventChannelSO eventChannel;
    [SerializeField] private SkillTree skillTree;
    [SerializeField] private StatSO selectNodeCount;
    
    private SkillTreeSO skillTreeSO;

    private Button _purchaseBtn;
    private Transform _background;
    private Transform _textArea;
    private TextMeshProUGUI _description;
    private TextMeshProUGUI _fruitsPrice;
    private TextMeshProUGUI _fruitsName;
    private TextMeshProUGUI _purchaseText;
    private Image _icon;
    private SkillTreePurchaseEvent _treePurchaseEvent = SkillTreeEventChannel.SkillTreePurchaseEvent;

    private void Awake()
    {
        eventChannel.AddListener<SkillTreeEvent>(HandleOnFruitsSelect);

        _background = transform.Find("Background");
        _icon = _background.Find("FruitsIcon/Icon").GetComponent<Image>();
        _textArea = _background.Find("TextArea");
        
        _purchaseBtn = _background.GetComponentInChildren<Button>();

        _description = _textArea.Find("Description").GetComponent<TextMeshProUGUI>();
        _fruitsPrice = _textArea.Find("FruitsPrice").GetComponent<TextMeshProUGUI>();
        _fruitsName = _textArea.Find("FruitsName").GetComponent<TextMeshProUGUI>();
        _purchaseText = _purchaseBtn.GetComponent<TextMeshProUGUI>();

        skillTreeSO = skillTree.skillTreeSO;
    }

    private void HandleOnFruitsSelect(SkillTreeEvent skillTreeEvent)
    {
        NodeSO node = skillTreeEvent.NodeSO;
        
        _description.text = node.description;
        _fruitsPrice.text = node.price.ToString();
        _fruitsName.text = node.fruitsName;
        _icon.sprite = node.icon;

        _purchaseBtn.onClick.RemoveAllListeners();

        if (skillTreeEvent.NodeSO.NodeType == NodeType.Choice && node.isActive)
            _purchaseBtn.onClick.AddListener(() => HandleFruitsSelect(node));
        else
            _purchaseBtn.onClick.AddListener(() => HandleFruitsPurchase(node));
    }

    private void HandleFruitsSelect(NodeSO node)
    {
        _purchaseText.text = "Select";
        skillTreeSO.selectNodeCount--;
    }

    private void HandleFruitsPurchase(NodeSO node)
    {
        _treePurchaseEvent.SkillTreeNode = node.SkillTreeNode;
        eventChannel.RaiseEvent(_treePurchaseEvent);
    }

}
