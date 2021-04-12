﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMouthOnTriggerEnter : MonoBehaviour
{
    Hunger fishHunger;

    private void Start()
    {
        fishHunger = gameObject.GetComponentInParent<Hunger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (fishHunger.IsHungry)
        {
            Food food = collision.gameObject.GetComponent<Food>();

            if (food != null)
            {
                fishHunger.HungerAmount += food.restoreAmount;
                Destroy(food.gameObject);
            }
        }
    }
}