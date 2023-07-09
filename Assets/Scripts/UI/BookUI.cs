using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookUI : MonoBehaviour
{
    public List<GameObject> pages = new List<GameObject>();
    public Button 上一页;
    public Button 下一页;
    public Button 关闭;

    void Awake()
    {
        上一页.onClick.AddListener(点击_上一页);
        下一页.onClick.AddListener(点击_下一页);
        关闭.onClick.AddListener(点击_关闭);
    }

    private void 点击_关闭()
    {
        Close();
    }

    void 点击_上一页()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].SetActive(false);
        }
        pages[0].SetActive(true);
        pages[1].SetActive(true);
        pages[2].SetActive(false);
        pages[3].SetActive(false);
    }

    void 点击_下一页()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].SetActive(false);
        }
        pages[0].SetActive(false);
        pages[1].SetActive(false);
        pages[2].SetActive(true);
        pages[3].SetActive(true);
    }

    public void Reset()
    {
        点击_上一页();
    }

    public void Open()
    {
        gameObject.SetActive(true);
        Reset();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
