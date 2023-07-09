using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperationSceneUI : MonoBehaviour
{
    public Button 说明书;
    public Button 草药柜;

    void Awake()
    {
        说明书.onClick.AddListener(点击_说明书);
        草药柜.onClick.AddListener(点击_草药柜);
    }

    private void 点击_草药柜()
    {
        UIManager.Instance.ShowHerbUI();
    }

    private void 点击_说明书()
    {
        UIManager.Instance.ShowBookUI();
    }
}
