﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLog : MonoBehaviour
{
    
    private Collider col;
    private float overallDamage;
    private float damagePerSecond;
    private float overallTime;
    private int timesReceivedDamage;
    private static DamageLog _instance;
    public static DamageLog Instance { get { return _instance; } }
    


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    private void Start()
    {
        overallTime = 0;
        col = GetComponent<Collider>();
    }

    public void CaptureLog()
    {
        damagePerSecond = overallDamage / overallTime;
        Debug.Log("Damage Per Second: " + overallDamage/ overallTime);
        Debug.Log("Overall Damage: " + overallDamage);
        Debug.Log("Overall Time: " + overallTime);
        Debug.Log("Times Received Damage: " + timesReceivedDamage);
        Debug.Log("Damage per Attack: " + overallDamage / timesReceivedDamage);
    }

    private void Update()
    {
        overallTime += Time.deltaTime;
    }

    public void ReceiveDamage(float amount)
    {
        Debug.Log("Received damage");
        overallDamage += amount;
        timesReceivedDamage += 1;
    }
}
