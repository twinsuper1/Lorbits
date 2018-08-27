﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;

public class BaseStat : MonoBehaviour
{
    public enum BaseStatType { Power, Toughness, AttackSpeed }

    public List<StatBonus> BaseAdditives { get; set; }
    public BaseStatType StatType { get; set; }
    public int BaseValue { get; set; }
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public int FinalValue { get; set;  }


    /*public BaseStat(int baseValue, string statName, string statDescription)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.BaseValue = baseValue;
        this.StatName = statName;
        this.StatDescription = statDescription;

    }*/

   // [Newtonsoft.Json.JsonConstructor]
    public BaseStat(BaseStatType statType, int baseValue, string statName)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.StatType = statType;
        this.BaseValue = baseValue;
        this.StatName = statName;
    }


    public void AddStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Add(statBonus);
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Remove(statBonus);
    }

    public int GetCalculatedStatValue()
    {
        this.FinalValue = 0;
        this.BaseAdditives.ForEach(i => FinalValue += i.BonusValue);
        FinalValue += BaseValue;
        return FinalValue;
    }

}


