using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equip_ZaoTou : EquipBase
{
    public Button 灶头;
    public Button 放柴口;
    public List<string> 柴火列表;

    void Awake()
    {
        灶头.onClick.AddListener(点击_灶头);
        放柴口.onClick.AddListener(点击_放柴口);

        柴火列表 = new List<string>() { "柴火1", "柴火2", "柴火3" };

        Reset();
    }

    private void 点击_灶头()
    {
        switch (currentState)
        {
            case State.空闲:
                UIManager.Instance.ShowBubbleTip("这是灶头");
                break;
            case State.等待放柴:
                UIManager.Instance.ShowBubbleTip("等待放柴");
                break;
            case State.等待烧柴:
                UIManager.Instance.ShowBubbleTip("等待烧柴");
                break;
            case State.正在烧柴:
                UIManager.Instance.ShowBubbleTip("正在烧柴");
                break;
            case State.结束烧柴:
                UIManager.Instance.ShowBubbleTip("结束烧柴");
                break;
        }
    }

    private void 点击_放柴口()
    {
        switch (currentState)
        {
            case State.空闲:
                UIManager.Instance.ShowBubbleTip("这是放柴口");
                break;
            case State.等待放柴:
                UIManager.Instance.ShowBubbleTip("显示柴火选择UI");
                UIManager.Instance.ShowItemSelectUI("选择柴火", 柴火列表,
                    (string item) =>
                    {
                        UIManager.Instance.ShowBubbleTip("选择了柴火：" + item);
                        SetState(State.等待烧柴);
                    }
                );
                break;
            case State.等待烧柴:
                UIManager.Instance.ShowTip("是否开始烧柴？", () =>
                {
                    烧柴();
                });
                break;
            case State.正在烧柴:
                UIManager.Instance.ShowBubbleTip("正在烧柴");
                break;
            case State.结束烧柴:
                UIManager.Instance.ShowBubbleTip("结束烧柴");
                Reset();
                break;
        }
    }

    void 烧柴()
    {
        SetState(State.正在烧柴);
        StartCoroutine(烧柴过程());
    }

    IEnumerator 烧柴过程()
    {
        UIManager.Instance.ShowBubbleTip("开始烧柴");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("烧柴中...1");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("烧柴中...2");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("烧柴中...3");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("结束烧柴");
        SetState(State.结束烧柴);
    }

    public override void Reset()
    {
        // SetState(State.空闲);
        SetState(State.等待放柴);
    }

    public enum State
    {
        空闲,
        等待放柴,
        等待烧柴,
        正在烧柴,
        结束烧柴,
    }

    public State currentState;

    public void SetState(State state)
    {
        currentState = state;
        switch (currentState)
        {
            case State.空闲:
                break;
            case State.等待放柴:
                break;
            case State.正在烧柴:
                break;
            case State.结束烧柴:
                break;
        }
        print("灶头状态：" + Enum.GetName(typeof(State), currentState));
        // UIManager.Instance.ShowBubbleTip("灶头状态：" + Enum.GetName(typeof(State), currentState));
    }
}
