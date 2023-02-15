using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    WeaponUpgrade,
    ItemUpgrade,
    WeaponUnlock,
    ItemUnlock
}

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    public UpgradeType upgradeType;
    public Sprite itemSprite;
    public string itemName;
    public int[] damageByLevel;
    public GameObject gameObject;
    public int requiredLevel;
}


