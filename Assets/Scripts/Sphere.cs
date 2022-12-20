using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public MeshRenderer renderer = new MeshRenderer();
    public Color color;
    private bool isActive;

    public Manager manager;
    private int ActualColor;

    private void Start()
    {
        manager = FindObjectOfType<Manager>();
    }

    public void ActivateSphere()
    {
        isActive = true;
        SetColor();
    }
    public void DesactivateSphere()
    {
        isActive = false;
        renderer.material.SetColor("_Color",Color.black);
    }

    public void ChangeColor()
    {
        if (isActive)
        {
            if (ActualColor < manager.Colors.Length - 1)
            {
                ActualColor++;
            }
            else
            {
                ActualColor = 0;
            }
            SetColor();

        }
    }

    public Color GetActualColor()
    {
        return manager.Colors[ActualColor];
    }
    
    private void SetColor()
    {
        renderer.material.SetColor("_Color",manager.Colors[ActualColor]);
    }
}
