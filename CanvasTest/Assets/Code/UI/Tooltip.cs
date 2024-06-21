using Code.Inventory;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : BaseWindow
{
	[SerializeField] private TMP_Text _titleText;
	[SerializeField] private TMP_Text _description;
	[SerializeField] private Image _icon;
	
	protected override void OnHide()
	{
		_titleText.text = "";
		_description.text = "";
		_icon.sprite = null;
	}

	protected override void OnShow(object[] args)
	{
		var items = (List<InventoryItem>)args[1];

		var inventoryItem = items[0];
		_titleText.text = inventoryItem.Title;
		_description.text = inventoryItem.Description;
		_icon.sprite = inventoryItem.Icon;
	}
}
