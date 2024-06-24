using Code.Inventory;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RewardUiItem : BaseUiItem, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
	[SerializeField] private Image _icon;

	private InventoryItem _inventoryItem;

	private const float TAP_TIME = 0.3f;
	private bool _isHolding;
	private bool _isShown = false;
	private float _pressTime;

	protected override void OnShow(object args)
	{
		_inventoryItem = (InventoryItem)args;
		_icon.sprite = _inventoryItem.Icon;
	}

	private void Update()
	{
		if (!_isHolding) return;
		if (_isShown) return;

		if (Time.time - _pressTime >= TAP_TIME)
		{
			ShowTooltip();			
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		_isHolding = true;
		_pressTime = Time.time;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		HideTooltip();
		_isHolding = false;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		HideTooltip();
		_isHolding = false;
	}

	private void HideTooltip()
	{
		Get<Tooltip>().Hide();
		_isShown = false;
	}
	private void ShowTooltip()
	{
		Get<Tooltip>().Show("", new List<InventoryItem>() {
			_inventoryItem,
		});
		_isShown = true;
	}
}