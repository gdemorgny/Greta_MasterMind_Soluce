using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Board : MonoBehaviour
{
    [SerializeField] private AnswerRow[] _rows;
    [SerializeField] private BoardManager _manager;
    [SerializeField] private int[] _answer = new int[4];
    [SerializeField] private UIManager _uiManager;

    private int _actualLine = 0;
    private void Start()
    {
        CreateAnswer();
        ActivateNewRow(_actualLine);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray rayFromCam = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayFromCam, out hit))
            {
                Debug.Log("Je teste quelquechose : "+ hit.collider.gameObject.name);

                if (hit.collider.gameObject.GetComponent<AnswerPawn>() != null)
                {
                    hit.collider.gameObject.GetComponent<AnswerPawn>().ChangeColor();
                }
            }
        }
        
    }

    private void ActivateNewRow(int rowNumber)
    {
        if (rowNumber >= _rows.Length)
        {
            _uiManager.Lost();
            for (int i = 0; i < _rows.Length; i++)
            {
                    _rows[i].DesactivateLine();
            }
            return;
        }
        for (int i = 0; i < _rows.Length; i++)
        {
            if (i == rowNumber)
            {
                _rows[i].ActivateLine();
            }
            else
            {
                _rows[i].DesactivateLine();

            }
        }
    }    
    
    void CreateAnswer()
    {
        for (int i = 0; i < _answer.Length; i++)
        {
            _answer[i] = Random.Range(0, _manager.AnswerColors.Length);
        }
    }

    public void CheckRow()
    {
        int[] colorsToCheck = _rows[_actualLine].GetAllColors();
        int[] result = new int[colorsToCheck.Length];
        bool[] ResultAllowed = new bool[colorsToCheck.Length];
        int resultValue =0;
        for (int i = 0; i < colorsToCheck.Length; i++)
        {
            if (colorsToCheck[i] == _answer[i])
            {
                result[i] = 0;
                ResultAllowed[i] = true;
            }
            else
            {
                result[i] = 2;
            }

            resultValue += result[i];
        }

        if (resultValue == 0)
        {
            _uiManager.Win();
            DesactivateAllRows();
            return;
        }
        for (int i = 0; i < colorsToCheck.Length; i++)
        {
            if (!ResultAllowed[i])
            {
                for (int j = 0; j < colorsToCheck.Length; j++)
                {
                    if (!ResultAllowed[j])
                    {
                        if (colorsToCheck[i] == _answer[j])
                        {
                            result[i] = 1;
                            ResultAllowed[j] = true;
                        }
                    }
                }
            }
        }
        
        _rows[_actualLine].ApplyResult(result);
        _actualLine++;
        ActivateNewRow(_actualLine);
    }

    private void DesactivateAllRows()
    {
        for (int i = 0; i < _rows.Length; i++)
        {
            _rows[i].DesactivateLine();
        }
    }
}
