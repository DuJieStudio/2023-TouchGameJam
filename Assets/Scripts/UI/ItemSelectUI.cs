using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemSelectUI : MonoBehaviour
{
    public class Item
    {
        public string 名称;
        public GameObject obj;
        public Image 图标;
        public Text 文字;
        public Button 按钮;

        public Item(string name, GameObject go)
        {
            obj = go;
            按钮 = go.GetComponent<Button>();
            图标 = go.transform.Find("图标").GetComponent<Image>();
            文字 = go.transform.Find("文字").GetComponent<Text>();

            名称 = name;
            文字.text = name;
            
            string 路径 = string.Empty;
            if(GameForm.砂体配置表.ContainsKey(name))
            {
                路径 = GameForm.砂体配置表[name].图标;
                路径 = "Art/Icon/砂体/" + 路径;
            }
            else if(GameForm.木柴配置表.ContainsKey(name))
            {
                路径 = GameForm.木柴配置表[name].图标;
                路径 = "Art/Icon/木柴/" + 路径;
            }
            print(路径);
            
            if(路径 == string.Empty)         
            {
                图标.sprite = null;
                图标.color = Utility.RandomColor();
            }
            else
            {
                图标.sprite = Resources.Load<Sprite>(路径);
                图标.color = Color.white;
                图标.SetNativeSize();
            }

            obj.SetActive(true);
        }
    }

    public Text 标题文字;
    public Button 关闭按钮;
    public GameObject 物品;
    public GridLayoutGroup 网格;
    public List<Item> 物品列表;

    void Awake()
    {
        关闭按钮.onClick.AddListener(点击_关闭按钮);
        物品列表 = new();
    }

    void 点击_关闭按钮()
    {
        Close();
    }

    public void SetTitle(string title)
    {
        标题文字.text = title;
    }

    public void SetItems(List<string> itemNames, UnityAction<string> onSelect = null)
    {
        foreach (Item item in 物品列表)
        {
            DestroyImmediate(item.obj);
        }
        物品列表.Clear();
        foreach (string itemName in itemNames)
        {
            Item item = new Item(itemName, Instantiate(物品, 网格.transform));
            物品列表.Add(item);
            
            item.按钮.onClick.AddListener(() =>
            {
                // EventManager.Instance.DispatchEvent(new SelectItemEventArgs(item.名称));
                onSelect?.Invoke(item.名称);
                Close();
            });
        }
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
