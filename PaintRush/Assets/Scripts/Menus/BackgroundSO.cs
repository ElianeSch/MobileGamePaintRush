using UnityEngine;
using System;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable objects/New background item", order = 1)]
[Serializable]
public class BackgroundSO : ShopItemSO
{

    public Sprite spriteBackground;

}
