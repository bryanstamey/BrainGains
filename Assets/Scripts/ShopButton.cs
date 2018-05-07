using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour {

	public GameObject ItemManager;
	public char space;

	private Transform parent;

	void Start()
	{
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

	}

	void TaskOnClick()
	{
		ItemManager.GetComponent<ItemManager> ().displayShopItems (space);
	}

	public void refresh()
	{
		ItemManager.GetComponent<ItemManager> ().displayShopItems (space);
	}

}
