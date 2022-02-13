using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCell : MonoBehaviour
{
	[SerializeField] public Text _costField;
	[SerializeField] public int cellIndex;
	public static ShopCell Instance;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
	}

	public void Render(IShopItem shopItem, int index)
	{
		if (!shopItem.IsBought && !shopItem.IsChosen) _costField.text = shopItem.Cost.ToString();
		else if (shopItem.IsBought && !shopItem.IsChosen) _costField.text = "Bought";
		else if (shopItem.IsBought && shopItem.IsChosen) _costField.text = "Chosen";
		cellIndex = index;
	}

	public void OnClickShopCell()
	{
		var shopItem = ShopItemWrapper(cellIndex);
		Shop.BuyShopItem(shopItem, cellIndex);
	}

	public static AssetShopItem ShopItemWrapper(int index)
	{
		return Shop.Instance.ShopItems[index];
	}

}
