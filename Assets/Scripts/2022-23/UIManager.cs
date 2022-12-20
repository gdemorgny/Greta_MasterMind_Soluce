using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button _checkButton;
    [SerializeField] private GameObject _winMessagen;
    [SerializeField] private GameObject _lostMessagen;

    private void Start()
    {
        _checkButton.interactable = false;
    }

    public void AllowCheckRow()
    {
        _checkButton.interactable = true;
    }
    public void DisableCheckRow()
    {
        _checkButton.interactable = false;
    }

    public void Win()
    {
        _winMessagen.SetActive(true);
    }

    public void Lost()
    {
        _lostMessagen.SetActive(true);

    }
}
