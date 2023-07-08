using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 捣药罐
/// </summary>
public class Equip_DaoYaoGuan : MonoBehaviour
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
        UIManager.Instance.ShowBubbleTip("这是研钵");
    }

    void 点击_研杵()
    {
        switch (currentState)
        {
            case State.空闲:
                UIManager.Instance.ShowBubbleTip("这是研杵");
                break;
            case State.正在捣药:
                执行_捣药();
                break;
            case State.捣药完成:
                Reset();
                break;
        }
    }

    void 执行_捣药()
    {
        if (!Utility.IsAnimatorFinished(animator))
        {
            UIManager.Instance.ShowBubbleTip("正在捣药中...次数：" + 捣药次数);
            return;
        }

        animator.Play(Utility.RandomBool() ? 捣药1Hash : 捣药2Hash);
        捣药次数++;
        药颗粒_大.SetActive(false);
        药颗粒_中.SetActive(false);
        药颗粒_小.SetActive(false);
        if(捣药次数 >= 捣药_最大次数)
        {
            UIManager.Instance.ShowBubbleTip("捣药完成");
            SetState(State.捣药完成);
        }
        else if (捣药次数 >= 捣药_小颗粒次数)
        {
            药颗粒_小.SetActive(true);
        }
        else if (捣药次数 >= 捣药_中颗粒次数)
        {
            药颗粒_中.SetActive(true);
        }
        else
        {
            药颗粒_大.SetActive(true);
        }
    }

    public void Reset()
    {
        捣药次数 = 0;
        
        // SetState(State.空闲);
        SetState(State.正在捣药);
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
                break;
        }
        print("捣药罐状态：" + Enum.GetName(typeof(State), currentState));
        // UIManager.Instance.ShowBubbleTip("捣药罐状态：" + Enum.GetName(typeof(State), currentState));
    }
}
