using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager:SingletonMono<UIManager>
{
    public Canvas UI画布;

    public TipUI 提示UI;
    public BubbleUI 气泡UI;
    public ItemSelectUI 物品选择UI;
    
    protected override void onInit()
    {
        base.onInit();
        DontDestroyOnLoad(gameObject);
    }

    public void ShowTip(string text, UnityAction onConfirm = null, UnityAction onCancel = null)
    {
        提示UI.Open();
        提示UI.SetText(text);
        提示UI.SetListener(onConfirm, onCancel);
    }

    public void ShowBubbleTip(string text)
    {
        气泡UI.Add(text);
    }

    public void ShowItemSelectUI(string title, List<string> itemNames, UnityAction<string> onSelect = null)
    {
        物品选择UI.Open();
        物品选择UI.SetTitle(title);
        物品选择UI.SetItems(itemNames, onSelect);
    }
}