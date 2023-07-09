using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameForm
{
    public static readonly Dictionary<string, 丹药配置> 丹药配置表 = new()
    {
        {
            丹药名称.雪岭丹, new 丹药配置()
            {
                名称 = 丹药名称.雪岭丹,
                描述 = "丹药1的描述",
                图标 = "丹药1的图标",
                制药流程名称 = 制药流程名称.雪岭丹制药流程,
            }
        },
        {
            丹药名称.热寂丹, new 丹药配置()
            {
                名称 = 丹药名称.热寂丹,
                描述 = "丹药2的描述",
                图标 = "丹药2的图标",
                制药流程名称 = 制药流程名称.热寂丹制药流程,
            }
        },
        {
            丹药名称.无情丹, new 丹药配置()
            {
                名称 = 丹药名称.无情丹,
                描述 = "丹药3的描述",
                图标 = "丹药3的图标",
                制药流程名称 = 制药流程名称.无情丹制药流程,
            }
        },
    };

    public static readonly Dictionary<string, 木柴配置> 木柴配置表 = new()
    {
        {
            木柴名称.松木, new 木柴配置()
            {
                名称 = 木柴名称.松木,
                描述 = "木柴1的描述",
                图标 = "icon_chai_1",
            }
        },
        {
            木柴名称.藤木, new 木柴配置()
            {
                名称 = 木柴名称.藤木,
                描述 = "木柴2的描述",
                图标 = "icon_chai_2",
            }
        },
        {
            木柴名称.雪木, new 木柴配置()
            {
                名称 = 木柴名称.雪木,
                描述 = "木柴3的描述",
                图标 = "icon_chai_3",
            }
        },
    };

    public static readonly Dictionary<string, 砂体配置> 砂体配置表 = new()
    {
        {
            砂体名称.原砂, new 砂体配置()
            {
                名称 = 砂体名称.原砂,
                描述 = "砂体1的描述",
                图标 = "icon__sha_3",
            }
        },
        {
            砂体名称.金砂, new 砂体配置()
            {
                名称 = 砂体名称.金砂,
                描述 = "砂体2的描述",
                图标 = "icon__sha_5",
            }
        },
        {
            砂体名称.紫砂, new 砂体配置()
            {
                名称 = 砂体名称.紫砂,
                描述 = "砂体3的描述",
                图标 = "icon__sha_1",
            }
        },
    };

    public static readonly Dictionary<string, 制药流程配置> 制药流程配置表 = new()
    {
        {
            制药流程名称.雪岭丹制药流程, new 制药流程配置()
            {
                名称 = 制药流程名称.雪岭丹制药流程,
                丹药名称 = 丹药名称.雪岭丹,
                颗粒大小 = 颗粒大小类型.粗,
                木柴名称 = 木柴名称.松木,
                砂体名称 = 砂体名称.原砂,
                草药名称 = 草药名称.雪岭草,
                烧制时间 = 10,
            }
        },
        {
            制药流程名称.热寂丹制药流程, new 制药流程配置()
            {
                名称 = 制药流程名称.热寂丹制药流程,
                丹药名称 = 丹药名称.热寂丹,
                颗粒大小 = 颗粒大小类型.中,
                木柴名称 = 木柴名称.藤木,
                砂体名称 = 砂体名称.金砂,
                草药名称 = 草药名称.热风枝,
                烧制时间 = 20,
            }
        },
        {
            制药流程名称.无情丹制药流程, new 制药流程配置()
            {
                名称 = 制药流程名称.无情丹制药流程,
                丹药名称 = 丹药名称.无情丹,
                颗粒大小 = 颗粒大小类型.细,
                木柴名称 = 木柴名称.雪木,
                砂体名称 = 砂体名称.紫砂,
                草药名称 = 草药名称.幽邃叶,
                烧制时间 = 30,
            }
        },
    };

    public class 丹药配置
    {
        public string 名称;
        public string 描述;
        public string 图标;
        public string 制药流程名称;
    }

    public class 木柴配置
    {
        public string 名称;
        public string 描述;
        public string 图标;
    }

    public class 砂体配置
    {
        public string 名称;
        public string 描述;
        public string 图标;
    }

    public class 草药配置
    {
        public string 名称;
        public string 描述;
        public string 图标;
    }

    public class 丹药名称
    {
        public const string 雪岭丹 = "雪岭丹";
        public const string 热寂丹 = "热寂丹";
        public const string 无情丹 = "无情丹";
    }

    public class 制药流程名称
    {
        public const string 雪岭丹制药流程 = "雪岭丹制药流程";
        public const string 热寂丹制药流程 = "热寂丹制药流程";
        public const string 无情丹制药流程 = "无情丹制药流程";
    }

    public class 砂体名称
    {
        public const string 原砂 = "原砂";
        public const string 金砂 = "金砂";
        public const string 紫砂 = "紫砂";
    }

    public class 木柴名称
    {
        public const string 松木 = "松木";
        public const string 藤木 = "藤木";
        public const string 雪木 = "雪木";
    }

    public class 草药名称
    {
        public const string 雪岭草 = "雪岭草";
        public const string 热风枝 = "热风枝";
        public const string 幽邃叶 = "幽邃叶";
    }

    public enum 颗粒大小类型
    {
        粗,
        中,
        细,
    }

    public class 制药流程配置
    {
        public string 名称;
        public string 丹药名称;
        public 颗粒大小类型 颗粒大小;
        public string 木柴名称;
        public string 砂体名称;
        public string 草药名称;
        public int 烧制时间;
    }
}