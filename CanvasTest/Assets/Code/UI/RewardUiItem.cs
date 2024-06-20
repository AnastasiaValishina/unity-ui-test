using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardUiItem : MonoBehaviour
{
	[SerializeField] private Image _icon;

	public void SetIcon(Sprite iconSprite)
	{
		_icon.sprite = iconSprite;
	}
}
