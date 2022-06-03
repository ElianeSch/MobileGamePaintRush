using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable objects/New shop Item", order = 1)]
public class ShopItemSO : ScriptableObject
{

    public string title;
    public string description;
    public Sprite sprite;
    public int cost;

}
