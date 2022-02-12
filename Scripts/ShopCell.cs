using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCell : MonoBehaviour
{
	[SerializeField] public Text _costField;

	public void Render(IShopItem shopItem)
	{
		if (!shopItem.IsBought) _costField.text = shopItem.Cost.ToString();
		else if (shopItem.IsBought && !shopItem.IsChosen) _costField.text = "Bought";
		else _costField.text = "Chosen";
	}

	public void OnClickShopCell()
	{
		Debug.Log("Works");
	}

}
