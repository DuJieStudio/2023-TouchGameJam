using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum Step
    {
        S1, //研磨
        S2, //选择柴火
        S3, //烧砂
        S4, //放入药草烧制并定时
        S5, //定时结束并封泥
        S6, //裁剪切口并放入木塞
    }

    private Step currentStep = Step.S1;

    // Start is called before the first frame update
    void Start()
    {
        currentStep = Step.S1;
        EventManager.Instance.AddListener<SelectItemEventArgs>(OnSelectWoodHandler);
    }

    private void OnSelectWoodHandler(object sender, SelectItemEventArgs e)
    {
        UIManager.Instance.ShowBubbleTip("选择木柴：" + e.选择的物品名称);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // UIManager.Instance.ShowBubbleTip("点击了鼠标左键");
        }
    }
}
