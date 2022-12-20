using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public bool isActive;

    public Sphere[] spheres;
    public void ActivateLine()
    {
        isActive = true;
        for (int i = 0; i < spheres.Length; i++)
        {
            spheres[i].ActivateSphere();
        }
    }
    public void DesactivateLine()
    {
        for (int i = 0; i < spheres.Length; i++)
        {
            spheres[i].DesactivateSphere();
        }
    }
}
