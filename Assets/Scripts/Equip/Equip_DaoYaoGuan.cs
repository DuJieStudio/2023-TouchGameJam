using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameForm;

/// <summary>
/// 捣药罐
/// </summary>
public class Equip_DaoYaoGuan : EquipBase
{
    public Button 研杵;
    public Button 研钵;
    public GameObject 药颗粒_大;
    public GameObject 药颗粒_中;
    public GameObject 药颗粒_小;
    public Animator animator;

    public int 捣药次数;

    public int 捣药_中颗粒次数 = 3;
    public int 捣药_小颗粒次数 = 5;
    public int 捣药_最大次数 = 7;

    public 颗粒大小类型 颗粒大小;

    protected readonly int 空闲Hash = Animator.StringToHash("空闲");
    protected readonly int 捣药1Hash = Animator.StringToHash("研杵_捣药1");
    protected readonly int 捣药2Hash = Animator.StringToHash("研杵_捣药2");

    void Awake()
    {
        研杵.onClick.AddListener(点击_研杵);
        研钵.onClick.AddListener(点击_研钵);

        Reset();
    }

    void 点击_研钵()
    {
        switch (currentState)
        {
            case State.空闲:
                UIManager.Instance.ShowBubbleTip("这是研钵");
                break;
            case State.准备捣药:
                break;
            case State.正在捣药:
                UIManager.Instance.ShowBubbleTip("结束捣药");
                SetState(State.捣药完成);
                break;
            case State.捣药完成:
                if(GameManager.Instance.currentStep == GameManager.Step.炼丹)
                {
                    GameManager.Instance.Set加入草药();
                    UIManager.Instance.ShowBubbleTip("草药已加入炼丹炉，可以开始炼制丹药了");
                }
                else
                {
                    UIManager.Instance.ShowBubbleTip("已完成捣药");
                }
                break;
        }
    }

    void 点击_研杵()
    {
        switch (currentState)
        {
            case State.空闲:
                UIManager.Instance.ShowBubbleTip("这是研杵");
                break;
            case State.准备捣药:
                break;
            case State.正在捣药:
                执行_捣药();
                break;
            case State.捣药完成:
                UIManager.Instance.ShowBubbleTip("已完成捣药");
                break;
        }
    }

    void 执行_捣药()
    {
        if (!Utility.IsAnimatorFinished(animator))
        {
            UIManager.Instance.ShowBubbleTip("正在捣药中...次数：" + 捣药次数 + "\n（点击研钵，结束捣药）");
            return;
        }

        animator.Play(Utility.RandomBool() ? 捣药1Hash : 捣药2Hash);
        捣药次数++;
        药颗粒_大.SetActive(false);
        药颗粒_中.SetActive(false);
        药颗粒_小.SetActive(false);
        if (捣药次数 >= 捣药_最大次数)
        {
            UIManager.Instance.ShowBubbleTip("以达最大次数，结束捣药");
            SetState(State.捣药完成);
        }
        else if (捣药次数 >= 捣药_小颗粒次数)
        {
            药颗粒_小.SetActive(true);
            颗粒大小 = 颗粒大小类型.细;
        }
        else if (捣药次数 >= 捣药_中颗粒次数)
        {
            药颗粒_中.SetActive(true);
            颗粒大小 = 颗粒大小类型.中;
        }
        else
        {
            药颗粒_大.SetActive(true);
            颗粒大小 = 颗粒大小类型.粗;
        }
    }

    public override void Reset()
    {
        捣药次数 = 0;
        颗粒大小 = 颗粒大小类型.粗;

        SetState(State.空闲);
        // SetState(State.正在捣药);
    }

    public enum State
    {
        空闲,
        准备捣药,
        正在捣药,
        捣药完成,
    }

    public State currentState = State.空闲;

    public void SetState(State state)
    {
        currentState = state;
        switch (currentState)
        {
            case State.空闲:
                animator.Play(空闲Hash);
                药颗粒_大.SetActive(false);
                药颗粒_中.SetActive(false);
                药颗粒_小.SetActive(false);
                捣药次数 = 0;
                break;
            case State.准备捣药:
                药颗粒_大.SetActive(true);
                SetState(State.正在捣药);
                break;
            case State.正在捣药:
                break;
            case State.捣药完成:
                GameManager.Instance.Set颗粒大小(颗粒大小);
                break;
        }
        print("捣药罐状态：" + Enum.GetName(typeof(State), currentState));
        // UIManager.Instance.ShowBubbleTip("捣药罐状态：" + Enum.GetName(typeof(State), currentState));
    }
}
