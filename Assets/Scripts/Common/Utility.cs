using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    // 获取或添加组件
    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();

        return component;
    }

    // 生成随机布尔值
    public static bool RandomBool()
    {
        return UnityEngine.Random.Range(0, 2) == 0;
    }

    // 随机颜色
    public static Color RandomColor()
    {
        return UnityEngine.Random.ColorHSV();
    }

    // 动画是否播放完毕
    public static bool IsAnimatorFinished(Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f;
    }

    // 中断Animator动画
    public static void InterruptAnimator(Animator animator)
    {
        animator.speed = 0;
        animator.Update(0);
    }
}