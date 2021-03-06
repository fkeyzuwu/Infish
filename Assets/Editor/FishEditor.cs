using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(Fish), true)]
public class FishEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Fish fish = (Fish)target;

        for (int i = 0; i < fish.Food.Length; i++)
        {
            fish.Food[i] = fish.Food[i] != null ? CheckIfObjectValid(fish.Food[i], fish.Food[i].GetComponent<IEdible>()) : fish.Food[i];
        }

        for (int i = 0; i < fish.GoldDrop.Length; i++)
        {
            fish.GoldDrop[i] = fish.GoldDrop[i] != null ? CheckIfObjectValid(fish.GoldDrop[i], fish.GoldDrop[i].GetComponent<IGold>()) : fish.GoldDrop[i];  
        }

    }

    private GameObject CheckIfObjectValid(GameObject obj, IGameComponent componentType)
    {
        if (componentType == null)
        {
            Debug.LogError($"The {obj} on {obj.gameObject} isn't the correct IGameComponent.");
            return null;
        }

        return obj;
    }
}
