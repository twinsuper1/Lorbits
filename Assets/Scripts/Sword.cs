﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	public List<BaseStat> Stats { get; set; }

    public void PerformAttack()
    {
        Debug.Log("Sword Attack!");
    }
}
