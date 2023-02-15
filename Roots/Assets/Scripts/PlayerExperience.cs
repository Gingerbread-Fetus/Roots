using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public int expToNextLevel = 100;
    public int level = 1;
    [HideInInspector]
    public int currentExp;

    [SerializeField]
    LevelUpUI levelUpUI;
    [SerializeField]
    List<ItemData> upgrades;
    

    public void AddExp(int newExp)
    {
        currentExp += newExp;
        if(currentExp >= expToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level += 1;
        expToNextLevel = level * 1000;
    }

    public List<ItemData> GetUpgrades(int count)
    {
        List<ItemData> upgradeList = new List<ItemData>();

        if(count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]); 
        }

        return upgradeList;
    }
}
