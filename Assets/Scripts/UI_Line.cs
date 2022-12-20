using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Line : MonoBehaviour
{
    public Text Perfect;
    public Text Good;
    public Button CheckButton;
    private Manager _manager;
    private void Start()
    {
        _manager = FindObjectOfType<Manager>();
    }

    public void ShowResults(int perfect, int good)
    {
        CheckButton.interactable = false;
        Perfect.text = perfect.ToString();
        Good.text = good.ToString();
    }
    
}
