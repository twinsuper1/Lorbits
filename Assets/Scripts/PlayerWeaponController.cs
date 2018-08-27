using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    Item currentlyEquippedItem;
    IWeapon equippedWeapon;
    CharacterStats characterStats;

    private void Start()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if (EquippedWeapon != null)
        {
            UniquipWeapon();
        }
        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapon/" + itemToEquip.ObjectSlug));
    }

    private void UniquipWeapon()
    {
        //InventoryController.Instance.GiveItem(currentlyEquippedItem.ObjectSlug);
        characterStats.RemoveStatBonus(equippedWeapon.Stats);
        Destroy(EquippedWeapon.transform.gameObject);
        //UIEventHandler.StatsChanged();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            PerformWeaponAttack();
        if (Input.GetKeyDown(KeyCode.Z))
            PerformWeaponSpecialAttack();
    }
    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack(CalculateDamage());
    }
    public void PerformWeaponSpecialAttack()
    {
        equippedWeapon.PerformSpecialAttack();
    }

    private int CalculateDamage()
    {
        int damageToDeal = (characterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue() * 2)
            + UnityEngine.Random.Range(2, 8);
        damageToDeal += CalculateCrit(damageToDeal);
        Debug.Log("Damage dealt: " + damageToDeal);
        return damageToDeal;
    }

    private int CalculateCrit(int damage)
    {
        if (UnityEngine.Random.value <= .10f)
        {
            int critDamage = (int)(damage * UnityEngine.Random.Range(.5f, .75f));
            return critDamage;
        }
        return 0;
    }
}
