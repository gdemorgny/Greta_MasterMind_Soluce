using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPawn : MonoBehaviour
{
    [SerializeField] private BoardManager _manager;
    [SerializeField] private AnswerRow _row;
    private int _actualColor = -1;


    public int GetColorNumber()
    {
        return _actualColor;
    }
    
    public void ChangeColor()
    {
        if (_actualColor == -1 || _actualColor >= _manager.AnswerColors.Length - 1)
        {
            _actualColor = 0;
        } else
        {
            _actualColor++;
        }
        _row.CheckAllPawnHaveAColor();
        GetComponent<MeshRenderer>().material.SetColor("_Color",_manager.AnswerColors[_actualColor]);
    } 
    
    
    public void ChangeColor(Color newColor)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color",newColor);
    }
}
