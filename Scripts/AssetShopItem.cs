using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ShopItem")]
public class AssetShopItem : ScriptableObject, IShopItem
{
	public int Cost => _cost;
	public bool IsBought
	{
		get
		{
			return _isBought;
		}
		set
		{
			_isBought = value;
		}
	}
	public bool IsChosen
	{
		get
		{
			return _isChosen;
		}
		set
		{
			_isChosen = value;
		}
	}
	public int IndexForColoredSkins => _indexForColoredSkins;

	[SerializeField] private int _cost;
	[SerializeField] private bool _isBought;
	[SerializeField] private bool _isChosen;
	[SerializeField] private int _indexForColoredSkins;

}