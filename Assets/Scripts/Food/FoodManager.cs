﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodManager : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [SerializeField] private Food[] foodList;
    private Food currentFood;

    void Awake()
    {
        cam = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentFood = foodList[0];
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.currentSelectedGameObject == null) //checks if we pressed a button
            {
                Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
                position.z = 0;
                Instantiate(currentFood.gameObject, position, currentFood.transform.rotation, transform.Find("Food")); // change to object pooler
            }
        }
    }

}
