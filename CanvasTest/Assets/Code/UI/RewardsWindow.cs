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
            rewardItem.Show(items[i]);
			rewardItem.ShowTooltip += ShowTooltip;
        }

		// устанавливаем мин ширину для контейнера с наградами,
		// чтобы на любых разрешениях экранов награды отображались согласно тз
		float parentWidth = _rewardsContainer.transform.parent.GetComponent<RectTransform>().rect.width;
		_rewardsContainer.GetComponent<LayoutElement>().minWidth = parentWidth;
    }

    protected override void OnHide()
    {
		foreach (Transform child in _rewardsContainer)
		{
			Destroy(child.gameObject);
		}
	}

	private void ShowTooltip(InventoryItem item)
	{
		Get<Tooltip>().Show("", new List<InventoryItem>() {
			item,
		});
	}

	void Update()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			switch (touch.phase)
			{
				case TouchPhase.Ended:
				case TouchPhase.Canceled:
					Get<Tooltip>().Hide();
					break;
			}
		}
	}

}