using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BubbleUI : MonoBehaviour
{
    public GameObject itemObj;
    public int moveY = 100;
    public int duration = 1;
    public float interval = 0.2f;
    float coolDown = 0;
    List<string> textList = new List<string>();
    List<GameObject> itemList = new List<GameObject>();

    void Awake()
    {
        itemObj.SetActive(false);
    }

    void Update()
    {
        if (textList.Count > 0)
        {
            coolDown -= Time.deltaTime;
            if (coolDown <= 0)
            {
                coolDown = interval;
                Show();
            }
        }
    }

    public void Add(string text)
    {
        textList.Add(text);
    }

    void Show()
    {
        string text = textList[0];
        textList.RemoveAt(0);
        
        GameObject go = Instantiate(itemObj, transform);
        go.SetActive(true);
        go.GetComponentInChildren<Text>().text = text;
        go.transform.DOLocalMoveY(moveY, duration)
        .SetEase(Ease.OutQuad)
        .OnComplete(()=>{
            itemList.Remove(go);
            DestroyImmediate(go);
        });
        itemList.Add(go);
    }
}
