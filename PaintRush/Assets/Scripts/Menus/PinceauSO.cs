using UnityEngine;
using System;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable objects/New pinceau Item", order = 1)]
public class PinceauSO : ShopItemSO
{
    // Characteristics
    public float inertia;
    public float thetaMax;
    public GameObject mesh;
}
