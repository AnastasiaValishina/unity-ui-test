using Code.Inventory;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardsWindow : BaseWindow
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private Transform _rewardsContainer;
    [SerializeField] private RewardUiItem _rewardPrefab;
    [SerializeField] private Button _closeButton;
    
    protected override void Awake()
    {
        base.Awake();
        _closeButton.onClick.AddListener(Hide);
    }

    protected override void OnShow(object[] args)
    {
        _titleText.text = (string)args[0];

        var items = (List<InventoryItem>)args[1];

        for (int i = 0; i < items.Count; i++)
        {
            var rewardItem = Instantiate(_rewardPrefab, _rewardsContainer);
            rewardItem.SetIcon(items[i].Icon);
        }
    }

    protected override void OnHide()
    {
		foreach (Transform child in _rewardsContainer)
		{
			Destroy(child.gameObject);
		}
	}
}