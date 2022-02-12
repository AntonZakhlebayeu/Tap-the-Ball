using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopItem
{
	public int Cost { get; }
	public bool IsBought { get; set; }
	public bool IsChosen { get; set; }
	public int IndexForColoredSkins { get; }

}
