using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeChoiceButton : MonoBehaviour
{
    [SerializeField] Image icon;

    public void Set(ItemData itemData)
    {
        icon.sprite = itemData.itemSprite;
    }
}
