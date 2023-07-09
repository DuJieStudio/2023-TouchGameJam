using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TipUI : MonoBehaviour
{
    public Text 文字;
    public Button 确定按钮;
    public Button 取消按钮;

    private void Awake()
    {
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void SetText(string text)
    {
        文字.text = text;
    }

    public void SetListener(UnityAction onConfirm, UnityAction onCancel)
    {
        确定按钮.onClick.RemoveAllListeners();
        取消按钮.onClick.RemoveAllListeners();
        确定按钮.onClick.AddListener(() =>
        {
            Close();
            onConfirm?.Invoke();
        });
        取消按钮.onClick.AddListener(() =>
        {
            Close();
            onCancel?.Invoke();
        });
    }
}
