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
    public List<string> 草药列表;

    void Awake()
    {
        木塞.onClick.AddListener(点击_木塞);
        泥料.onClick.AddListener(点击_泥料);
        炉体.onClick.AddListener(点击_炉体);

        木塞.gameObject.SetActive(false);
        泥料.gameObject.SetActive(false);

        砂体列表 = new List<string>() { "砂体1", "砂体2", "砂体3", "砂体4", "砂体5" };
        草药列表 = new List<string>() { "草药1", "草药2", "草药3", "草药4", "草药5", "草药6", "草药7" };

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
                    UIManager.Instance.ShowBubbleTip("选择了砂体：" + item);
                    SetState(State.选择草药);
                });
                break;
            case State.选择草药:
                UIManager.Instance.ShowItemSelectUI("选择草药", 草药列表, (string item) =>
                {
                    UIManager.Instance.ShowBubbleTip("选择了草药：" + item);
                    SetState(State.准备烧制);
                });
                break;
            case State.准备烧制:
                UIManager.Instance.ShowTip("是否开始烧制？", () =>
                {
                    烧制();
                });
                break;
            case State.烧制中:
                UIManager.Instance.ShowBubbleTip("正在烧制");
                break;
            case State.烧制完成:
                // UIManager.Instance.ShowBubbleTip("烧制完成，等待冷却");
                break;
            case State.封泥冷却:
                // UIManager.Instance.ShowBubbleTip("");
                break;
            case State.裁剪切口:
                break;
            case State.塞木塞:
                break;
            case State.结束烧制:
                UIManager.Instance.ShowBubbleTip("烧药已结束");
                Reset();
                break;
        }
    }

    void 烧制()
    {
        SetState(State.烧制中);
        StartCoroutine(烧制过程());
    }

    IEnumerator 烧制过程()
    {
        UIManager.Instance.ShowBubbleTip("开始烧制");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("烧制中...1");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("烧制中...2");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("烧制中...3");
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowBubbleTip("烧制完成");
        SetState(State.烧制完成);
        // FIXME: 待修改
        SetState(State.结束烧制);
    }

    public override void Reset()
    {
        // SetState(State.空闲);
        SetState(State.选择砂体);
    }

    public enum State
    {
        空闲,
        选择砂体,
        选择草药,
        准备烧制,
        烧制中,
        烧制完成,
        封泥冷却,
        裁剪切口,
        塞木塞,
        结束烧制,
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
            case State.选择草药:
                break;
            case State.准备烧制:
                break;
            case State.烧制中:
                break;
            case State.烧制完成:
                break;
            case State.封泥冷却:
                break;
            case State.裁剪切口:
                break;
            case State.塞木塞:
                break;
            case State.结束烧制:
                break;
        }
        print("炼丹炉状态：" + Enum.GetName(typeof(State), state));
        // UIManager.Instance.ShowBubbleTip("炼丹炉状态：" + Enum.GetName(typeof(State), state));
    }
}
