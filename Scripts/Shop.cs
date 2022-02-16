using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	[SerializeField] public List<AssetShopItem> ShopItems;
	[SerializeField] public ShopCell _shopCellTemplate;
	[SerializeField] private Transform _container;

	public static Shop Instance;

	private void Awake()
	{
		Instance = this;

		if (DataManager.GetFirstEnter())
			DataManager.SaveShopCondition(ShopItems);
		else
			DataManager.GetShopCondition(ref ShopItems);

		ReturnChosenSkin();
	}


	public void OnEnable()
	{
		Render(ShopItems);
	}

	public void Render(List<AssetShopItem> shopItems)
	{
		int index = 0;

		foreach (Transform child in _container)
		{
			Destroy(child.gameObject);
		}

		shopItems.ForEach(shopItem =>
		{

			var cell = Instantiate(_shopCellTemplate, _container);
			cell.Render(shopItem, index);
			index++;
		});
	}

	public static void BuyShopItem(AssetShopItem Item, int index)
	{
		{
			if (Item.IsBought == false && DataManager.GetAmountOfGlobalCurrency() >= Item.Cost)
			{
				DataManager.DecreaseAmountOfCurrency(Item.Cost);
				UIManager.Instance.UpdateStoreCurrencyText();
				Item.IsBought = true;
				DataManager.SaveShopCondition(Instance.ShopItems);
				Instance.Render(Instance.ShopItems);
			}
			else if (Item.IsBought == true)
			{
				UpdatePlayerSkin(Item);
				UpdateChooseStatus(Item);
			}
		}
	}

	public static void UpdatePlayerSkin(AssetShopItem Item)
	{
		Variables._PlayerMaterial.color = Skins.ColoredSkins[Item.IndexForColoredSkins];
		Variables._PlayerTailMaterial.color = Skins.ColoredSkins[Item.IndexForColoredSkins];
		Variables._ChosenColor = Skins.ColoredSkins[Item.IndexForColoredSkins];
	}

	public static void UpdateChooseStatus(AssetShopItem ChosenItem)
	{
		ChosenItem.IsChosen = true;
		foreach (AssetShopItem Item in Instance.ShopItems)
		{
			if (Item != ChosenItem && Item.IsChosen == true)
			{
				Item.IsChosen = false;
			}
		}
		DataManager.SaveShopCondition(Instance.ShopItems);
		Instance.Render(Instance.ShopItems);
	}

	public static void ReturnChosenSkin()
	{
		foreach (AssetShopItem Item in Instance.ShopItems)
		{
			if (Item.IsChosen == true)
			{
				UpdatePlayerSkin(Item);
				break;
			}
		}
	}
}
