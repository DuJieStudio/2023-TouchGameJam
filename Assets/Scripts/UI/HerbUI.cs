using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HerbUI : MonoBehaviour
{
    public Transform 内容;
    public List<Toggle> 抽屉列表 = new List<Toggle>();
    public Button 关闭;
    public List<string> 草药列表 = new List<string>();
    public string 当前草药;

    void Awake()
    {
        for (int i = 0; i < 内容.childCount; i++)
        {
            抽屉列表.Add(内容.GetChild(i).GetComponent<Toggle>());
        }
        关闭.onClick.AddListener(点击_关闭);

        草药列表.Add(GameForm.草药名称.雪岭草);
        草药列表.Add(GameForm.草药名称.热风枝);
        草药列表.Add(GameForm.草药名称.幽邃叶);
        for (int i = 0; i < 抽屉列表.Count; i++)
        {
            Toggle 抽屉 = 抽屉列表[i];
            抽屉.onValueChanged.AddListener(点击_抽屉);
            if (i >= 草药列表.Count)
            {
                草药列表.Add(string.Empty);
            }
            else
            {
                抽屉.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = 草药列表[i];
            }
        }
    }

    private void 点击_抽屉(bool isOn)
    {
        if (isOn)
        {
            当前草药 = 草药列表[抽屉列表.IndexOf(抽屉列表.Find(x => x.isOn))];
        }
    }

    private void 点击_关闭()
    {
        Close();
    }

    public void Reset()
    {
        for (int i = 0; i < 抽屉列表.Count; i++)
        {
            抽屉列表[i].isOn = false;
            抽屉列表[i].onValueChanged.Invoke(false);
        }
        当前草药 = string.Empty;
    }

    public void Open()
    {
        gameObject.SetActive(true);
        Reset();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        if (GameManager.Instance.currentStep != GameManager.Step.选药)
            return;

        if (当前草药 == string.Empty)
        {
            UIManager.Instance.ShowBubbleTip("请选择草药");
            return;
        }
        UIManager.Instance.ShowTip(
            string.Format("是否选择草药：【{0}】？", 当前草药),
            () =>
            {
                if (!GameManager.Instance.Check草药(当前草药))
                {
                    UIManager.Instance.ShowTip("选择错误，请重新选择草药!");
                    return;
                }
                GameManager.Instance.Set草药(当前草药);
                UIManager.Instance.ShowBubbleTip("草药已准备完毕!");
            },
            () =>
            {
                UIManager.Instance.ShowBubbleTip("请选择草药");
            }
        );
    }
}
