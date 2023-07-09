using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public class 病人
{
    public string 姓名;
    public string 丹药名称;
}

public class GameManager : SingletonMono<GameManager>
{
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
                break;
            case Step.选柴:
                UIManager.Instance.ShowBubbleTip("请操作灶台开始选柴！");
                print("步骤：选择柴火");
                break;
            case Step.烧砂:
                print("步骤：烧砂");
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

    #region 场景==========================================================================================
    public GameObject 开始场景;
    public GameObject 问诊场景;
    public GameObject 操作场景;

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
            丹药名称 = GameForm.丹药名称.丹药1,
        },
        new 病人(){
            姓名 = "病人2",
            丹药名称 = GameForm.丹药名称.丹药2,
        },
        new 病人(){
            姓名 = "病人3",
            丹药名称 = GameForm.丹药名称.丹药3,
        },
    };
    // 病人序号
    public int 病人Index = 0;
    // 当前病人
    public 病人 current病人;
    public GameForm.制药流程配置 current制药流程配置;

    public string current草药名称;
    #endregion

    protected override void onInit()
    {
        allEquips = new() { 捣药罐, 灶头, 炼丹炉, 桌子, 碗 };

        SetStep(startStep);

        SetState(startState);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // UIManager.Instance.ShowBubbleTip("点击了鼠标左键");
        }
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

    #region 功能================================================================================
    // 重新制药流程
    public void Restart制药()
    {

    }
    
    // 草药是否正确
    public bool Check草药(string 草药名称)
    {
        return 草药名称 == current制药流程配置.草药名称;
    }

    // 设置草药
    public void Set草药(string 草药名称)
    {
        current草药名称 = 草药名称;
    }
    #endregion
}
