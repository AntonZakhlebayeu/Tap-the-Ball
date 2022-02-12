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
		if (Instance == null)
			Instance = this;
	}

	public void OnEnable()
	{
		Render(ShopItems);
	}

	public void Render(List<AssetShopItem> shopItems)
	{
		foreach (Transform child in _container)
		{
			Destroy(child.gameObject);
		}

		shopItems.ForEach(shopItem =>
		{
			var cell = Instantiate(_shopCellTemplate, _container);
			cell.Render(shopItem);

		});
	}
}
