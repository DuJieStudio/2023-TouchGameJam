using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItemEventArgs : EventArgs
{
    public string 选择的物品名称;
    public SelectItemEventArgs(string itemName)
    {
        选择的物品名称 = itemName;
    }
}
