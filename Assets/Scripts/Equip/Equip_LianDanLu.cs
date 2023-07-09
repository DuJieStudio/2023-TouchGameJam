using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equip_LianDanLu : EquipBase
{
    public Button 木塞;
    public Button 泥料;
    public Button 炉体;
    public List<string> 砂体列表;

    public string 当前砂体;

    void Awake()
    {
        木塞.onClick.AddListener(点击_木塞);
        泥料.onClick.AddListener(点击_泥料);
        炉体.onClick.AddListener(点击_炉体);

        木塞.gameObject.SetActive(false);
        泥料.gameObject.SetActive(false);

        砂体列表 = new List<string>() {
            GameForm.砂体名称.原砂,
            GameForm.砂体名称.紫砂,
            GameForm.砂体名称.金砂,
         };

        Reset();
    }

    private void 点击_泥料()
    {
        UIManager.Instance.ShowBubbleTip("这是泥料");
    }

    private void 点击_木塞()
    {
        UIManager.Instance.ShowBubbleTip("这是木塞");
    }

    private void 点击_炉体()
    {
        switch (currentState)
        {
            case State.空闲:
                UIManager.Instance.ShowBubbleTip("这是炉体");
                break;
            case State.选择砂体:
                UIManager.Instance.ShowItemSelectUI("选择砂体", 砂体列表, (string item) =>
                {
                    if (!GameManager.Instance.Check砂体(item))
                    {
                        UIManager.Instance.ShowBubbleTip("砂体选择错误，请重新选择");
                        return;
                    }
                    else
                    {
                        当前砂体 = item;
                        UIManager.Instance.ShowBubbleTip("选择了砂体：" + item);
                        烧砂();
                    }
                });
                break;
            case State.烧砂中:
                UIManager.Instance.ShowBubbleTip("正在烧砂");
                break;
            case State.完成烧砂:
                UIManager.Instance.ShowBubbleTip("烧砂已完成");
                break;
            case State.准备烧制草药:
                UIManager.Instance.ShowTip("是否开始烧制草药？", () =>
                {
                    烧制草药();
                });
                break;
            case State.烧制草药中:
                UIManager.Instance.ShowBubbleTip("正在烧制草药");
                break;
            case State.烧制草药完成:
                // UIManager.Instance.ShowBubbleTip("烧制草药完成，等待冷却");
                break;
            case State.封泥冷却:
                // UIManager.Instance.ShowBubbleTip("");
                break;
            case State.裁剪切口:
                break;
            case State.塞木塞:
                break;
            case State.结束烧制草药:
                UIManager.Instance.ShowBubbleTip("烧药已结束");
                Reset();
                break;
        }
    }

    void 烧砂()
    {
        SetState(State.烧砂中);
        StartCoroutine(烧砂过程());
    }

    IEnumerator 烧砂过程()
    {
        UIManager.Instance.ShowBubbleTip("开始烧砂");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("烧砂中...1");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("烧砂中...2");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("烧砂中...3");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("烧砂已完成，请点击捣药罐加入草药颗粒");
        SetState(State.完成烧砂);
    }

    void 烧制草药()
    {
        SetState(State.烧制草药中);
        StartCoroutine(烧制草药过程());
    }

    IEnumerator 烧制草药过程()
    {
        UIManager.Instance.ShowBubbleTip("开始烧制草药");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("烧制草药中...1");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("烧制草药中...2");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("烧制草药中...3");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("烧制草药完成");
        SetState(State.烧制草药完成);
        // FIXME: 待移除
        SetState(State.结束烧制草药);
    }

    public override void Reset()
    {
        StopAllCoroutines();

        SetState(State.空闲);
        // SetState(State.选择砂体);

        当前砂体 = string.Empty;
    }

    public enum State
    {
        空闲,
        选择砂体,
        烧砂中,
        完成烧砂,
        准备烧制草药,
        烧制草药中,
        烧制草药完成,
        封泥冷却,
        裁剪切口,
        塞木塞,
        结束烧制草药,
    }

    public State currentState;

    public void SetState(State state)
    {
        currentState = state;
        switch (state)
        {
            case State.空闲:
                break;
            case State.选择砂体:
                break;
            case State.烧砂中:
                break;
            case State.完成烧砂:
                GameManager.Instance.Set砂体(当前砂体);
                break;
            case State.准备烧制草药:
                break;
            case State.烧制草药中:
                break;
            case State.烧制草药完成:
                break;
            case State.封泥冷却:
                break;
            case State.裁剪切口:
                break;
            case State.塞木塞:
                break;
            case State.结束烧制草药:
                GameManager.Instance.完成炼丹();
                break;
        }
        print("炼丹炉状态：" + Enum.GetName(typeof(State), state));
        // UIManager.Instance.ShowBubbleTip("炼丹炉状态：" + Enum.GetName(typeof(State), state));
    }
}
