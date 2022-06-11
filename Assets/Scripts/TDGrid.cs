using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Grid))]
public class TDGrid : MonoBehaviour
{
    private static TDGrid instance;

    public static TDGrid Singleton
    {
        get
        {
            if (!instance) instance = FindObjectOfType<TDGrid>();
            if (!instance) Debug.LogError("Your trying to acces Grid singleton, but there is no grid in the scene");
            return instance;
        }
    }

    private Grid grid;

    private void OnValidate()
    {
        if (!grid) TryGetComponent(out grid);
    }

    public float cellSize => grid.cellSize.x;

}