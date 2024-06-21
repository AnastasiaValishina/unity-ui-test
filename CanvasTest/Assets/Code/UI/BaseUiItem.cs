using UnityEngine;

public abstract class BaseUiItem : MonoBehaviour
{
	public static TWindow Get<TWindow>() where TWindow : BaseWindow
	{
		return FindObjectOfType<TWindow>(true);
	}

	public void Show(object args)
	{
		gameObject.SetActive(true);

		OnShow(args);
	}
	protected abstract void OnShow(object args);
}
