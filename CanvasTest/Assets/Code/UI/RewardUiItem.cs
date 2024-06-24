using Code.Inventory;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RewardUiItem : BaseUiItem, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField] private Image _icon;

	private InventoryItem _inventoryItem;

	private const float TAP_TIME = 0.3f;
	private bool _isItemPressed = false;
	private float _pressTime;

	public event Action<InventoryItem> ShowTooltip;

	protected override void OnShow(object args)
	{
		_inventoryItem = (InventoryItem)args;
		_icon.sprite = _inventoryItem.Icon;
	}

	private void Update()
	{
		if (!_isItemPressed) return;

		if (Time.time - _pressTime >= TAP_TIME)
		{
			ShowTooltip(_inventoryItem);
			_isItemPressed = false;
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		_pressTime = Time.time;
		_isItemPressed = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{

	}
}