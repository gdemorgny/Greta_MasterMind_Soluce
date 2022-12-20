using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnswerRow : MonoBehaviour
{
    [SerializeField] private AnswerPawn[] _answerPawns;
    [SerializeField] private ResultPawn[] _resultPawns;
    [SerializeField] private UIManager _uiManager;

    public int[] GetAllColors()
    {
        int[] colorNumbers = new int[_answerPawns.Length];
        for (int i = 0; i < _answerPawns.Length; i++)
        {
            colorNumbers[i] = _answerPawns[i].GetColorNumber();
        }

        return colorNumbers;
    }

    public void ApplyResult(int[] results)
    {
        for (int i = 0; i < _resultPawns.Length; i++)
        {
            _resultPawns[i].ApplyResultColor(results[i]);
        }
    }
    public void CheckAllPawnHaveAColor()
    {
        for (int i = 0; i < _answerPawns.Length; i++)
        {
            if (_answerPawns[i].GetColorNumber() == -1)
            {
                return;
            }
        }
        _uiManager.AllowCheckRow();
    }
    
    public void ActivateLine()
    {
        for (int i = 0; i < _answerPawns.Length; i++)
        {
            _answerPawns[i].GetComponent<Collider>().enabled = true;
        }
        _uiManager.DisableCheckRow();
    }

    public void DesactivateLine()
    {
        for (int i = 0; i < _answerPawns.Length; i++)
        {
            _answerPawns[i].GetComponent<Collider>().enabled = false;
        }
    }
}
