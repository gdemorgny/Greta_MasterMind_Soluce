using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPawn : MonoBehaviour
{
    [SerializeField] private BoardManager _manager;

    public void ApplyResultColor(int colorNumber)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color",_manager.ResultColors[colorNumber]);
    }
    
}
