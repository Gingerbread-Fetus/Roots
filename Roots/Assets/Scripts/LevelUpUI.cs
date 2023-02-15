using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpUI : MonoBehaviour
{
    [SerializeField] List<UpgradeChoiceButton> upgradeButtons;

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    internal void OpenPanel(List<ItemData> itemDatas)
    {
        Time.timeScale = 0f;
        for(int i = 0; i < itemDatas.Count; i++)
        {
            upgradeButtons[i].Set(itemDatas[i]);
        }
    }
}
