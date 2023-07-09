using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 病人
{
    public string 姓名;
    public string 丹药名称;
}

public class GameManager : SingletonMono<GameManager>
{
    #region 场景==========================================================================================
    public GameObject 开始场景;
    public GameObject 问诊场景;
    public GameObject 操作场景;

    // 问诊场景
    public Button 进入炼丹房;

    // 操作场景
    public Equip_DaoYaoGuan 捣药罐;
    public Equip_ZaoTou 灶头;
    public Equip_LianDanLu 炼丹炉;
    public Equip_ZhuoZi 桌子;
    public Equip_Wan 碗;

    List<EquipBase> allEquips;
    #endregion


    #region 数据==========================================================================================
    // 病人列表
    public List<病人> patients = new()
    {
        new 病人(){
            姓名 = "病人1",
            丹药名称 = GameForm.丹药名称.雪岭丹,
        },
        new 病人(){
            姓名 = "病人2",
            丹药名称 = GameForm.丹药名称.热寂丹,
        },
        new 病人(){
            姓名 = "病人3",
            丹药名称 = GameForm.丹药名称.无情丹,
        },
    };
    // 病人序号
    public int 病人Index = 0;
    // 当前病人
    public 病人 current病人;
    public GameForm.制药流程配置 current制药流程配置;

    #endregion

    protected override void onInit()
    {
        allEquips = new() { 捣药罐, 灶头, 炼丹炉, 桌子, 碗 };

        SetStep(startStep);
        SetState(startState);

        Test();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // UIManager.Instance.ShowBubbleTip("点击了鼠标左键");
        }
    }

    void Test()
    {
        SetState(GameState.问诊);
        current制药流程配置 = GameForm.制药流程配置表[GameForm.制药流程名称.雪岭丹制药流程];
        进入炼丹房.onClick.AddListener(() =>
        {
            SetState(GameState.操作);
            SetStep(Step.选药);
        });
    }

    #region 状态========================================================================
    enum GameState
    {
        空闲,
        开始,
        问诊,
        操作,
    }

    GameState lastState = GameState.空闲;
    GameState currentState = GameState.空闲;

    [SerializeField]
    private GameState startState = GameState.空闲;

    void SetState(GameState state)
    {
        开始场景.SetActive(state == GameState.开始);
        问诊场景.SetActive(state == GameState.问诊);
        操作场景.SetActive(state == GameState.操作);

        lastState = currentState;
        currentState = state;
        switch (state)
        {
            case GameState.开始:
                break;
            case GameState.问诊:
                if (lastState == GameState.开始)
                {
                    current病人 = patients[病人Index];
                }
                break;
            case GameState.操作:
                if (lastState == GameState.问诊)
                {
                    string 制药流程名称 = GameForm.丹药配置表[current病人.丹药名称].制药流程名称;
                    current制药流程配置 = GameForm.制药流程配置表[制药流程名称];
                    allEquips.ForEach(e => e.Reset());


                }
                break;
            default:
                break;
        }
    }
    #endregion

    #region 制药流程======================================================================================================

    public enum Step
    {
        空闲,
        选药, //选择草药
        研磨, //研磨
        选柴, //选择柴火
        烧砂, //烧砂
        炼丹, //放入药草烧制并定时
        冷却, //定时结束并封泥
        密封, //裁剪切口并放入木塞
    }

    public Step lastStep = Step.空闲;
    public Step currentStep = Step.空闲;

    [SerializeField]
    private Step startStep = Step.空闲;

    void SetStep(Step step)
    {
        lastStep = currentStep;
        currentStep = step;
        switch (step)
        {
            case Step.选药:
                print("步骤：选择草药");
                UIManager.Instance.ShowBubbleTip("请点击草药柜选药！");
                break;
            case Step.研磨:
                UIManager.Instance.ShowBubbleTip("请操作捣药罐开始研磨！");
                print("步骤：研磨");

                捣药罐.SetState(Equip_DaoYaoGuan.State.准备捣药);
                break;
            case Step.选柴:
                UIManager.Instance.ShowBubbleTip("请操作灶台开始选柴！");
                print("步骤：选择柴火");

                灶头.SetState(Equip_ZaoTou.State.等待放柴);
                break;
            case Step.烧砂:
                UIManager.Instance.ShowBubbleTip("请操作炼丹炉开始烧砂！");
                print("步骤：烧砂");

                炼丹炉.SetState(Equip_LianDanLu.State.选择砂体);
                break;
            case Step.炼丹:
                print("步骤：放入药草烧制并定时");
                break;
            case Step.冷却:
                print("步骤：定时结束并封泥");
                break;
            case Step.密封:
                print("步骤：裁剪切口并放入木塞");
                break;
            default:
                break;
        }
    }

    // 操作状态
    public string current草药名称;
    public GameForm.颗粒大小类型 current颗粒大小;
    public int current柴火温度;
    public string current砂体名称;

    // 重新制药流程
    public void Restart制药()
    {
        allEquips.ForEach(e => e.Reset());
        SetStep(Step.选药);
        current草药名称 = string.Empty;
    }

    // 草药是否正确
    public bool Check草药(string 草药名称)
    {
        return 草药名称 == current制药流程配置.草药名称;
    }

    // 砂体是否正确
    public bool Check砂体(string 砂体名称)
    {
        return 砂体名称 == current制药流程配置.砂体名称;
    }

    // 设置草药
    public void Set草药(string 草药名称)
    {
        current草药名称 = 草药名称;
        SetStep(Step.研磨);

        // DelayCall(Restart制药);
    }

    public void Set颗粒大小(GameForm.颗粒大小类型 颗粒大小)
    {
        current颗粒大小 = 颗粒大小;
        SetStep(Step.选柴);
    }

    public void Set柴火温度(int 温度)
    {
        current柴火温度 = 温度;
        SetStep(Step.烧砂);
    }

    public void Set砂体(string 砂体名称)
    {
        current砂体名称 = 砂体名称;
        SetStep(Step.炼丹);
    }

    public void Set加入草药()
    {
        炼丹炉.SetState(Equip_LianDanLu.State.准备烧制草药);
    }

    public void 完成炼丹()
    {
        string 丹药名称 = current制药流程配置.丹药名称;
        int 丹药数量 = 0;
        switch (current颗粒大小)
        {
            case GameForm.颗粒大小类型.粗:
                丹药数量 = 1;
                break;
            case GameForm.颗粒大小类型.中:
                丹药数量 = 3;
                break;
            case GameForm.颗粒大小类型.细:
                丹药数量 = 5;
                break;
            default:
                break;
        }
        string 丹药品质 = "灵品";
        switch (current砂体名称)
        {
            case GameForm.砂体名称.原砂:
                丹药品质 = "灵品";
                break;
            case GameForm.砂体名称.金砂:
                丹药品质 = "仙品";
                break;
            case GameForm.砂体名称.紫砂:
                丹药品质 = "神品";
                break;
            default:
                break;
        }
        UIManager.Instance.ShowTip(string.Format("【{0}】炼制完成！\n数量：{1}\n品质：{2}", 丹药名称, 丹药数量, 丹药品质));
    }
    #endregion =========================================================================================================


    #region 其它=======================================================================
    void DelayCall(Action callback)
    {
        StartCoroutine(CoDelayCall(callback));
    }

    IEnumerator CoDelayCall(Action callback)
    {
        yield return new WaitForSeconds(1);
        callback?.Invoke();
        print("延迟调用");
    }
    #endregion
}
