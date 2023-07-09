using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameForm
{
    public static readonly Dictionary<string, 丹药配置> 丹药配置表 = new()
    {
        {
            丹药名称.丹药1, new 丹药配置()
            {
                名称 = 丹药名称.丹药1,
                描述 = "丹药1的描述",
                图标 = "丹药1的图标",
                制药流程名称 = 制药流程名称.制药流程1,
            }
        },
        {
            丹药名称.丹药2, new 丹药配置()
            {
                名称 = 丹药名称.丹药2,
                描述 = "丹药2的描述",
                图标 = "丹药2的图标",
                制药流程名称 = 制药流程名称.制药流程2,
            }
        },
        {
            丹药名称.丹药3, new 丹药配置()
            {
                名称 = 丹药名称.丹药3,
                描述 = "丹药3的描述",
                图标 = "丹药3的图标",
                制药流程名称 = 制药流程名称.制药流程3,
            }
        },
    };

    public static readonly Dictionary<string, 木柴配置> 木柴配置表 = new()
    {
        {
            木柴名称.木柴1, new 木柴配置()
            {
                名称 = 木柴名称.木柴1,
                描述 = "木柴1的描述",
                图标 = "木柴1的图标",
            }
        },
        {
            木柴名称.木柴2, new 木柴配置()
            {
                名称 = 木柴名称.木柴2,
                描述 = "木柴2的描述",
                图标 = "木柴2的图标",
            }
        },
        {
            木柴名称.木柴3, new 木柴配置()
            {
                名称 = 木柴名称.木柴3,
                描述 = "木柴3的描述",
                图标 = "木柴3的图标",
            }
        },
    };

    public static readonly Dictionary<string, 砂体配置> 砂体配置表 = new()
    {
        {
            砂体名称.砂体1, new 砂体配置()
            {
                名称 = 砂体名称.砂体1,
                描述 = "砂体1的描述",
                图标 = "砂体1的图标",
            }
        },
        {
            砂体名称.砂体2, new 砂体配置()
            {
                名称 = 砂体名称.砂体2,
                描述 = "砂体2的描述",
                图标 = "砂体2的图标",
            }
        },
        {
            砂体名称.砂体3, new 砂体配置()
            {
                名称 = 砂体名称.砂体3,
                描述 = "砂体3的描述",
                图标 = "砂体3的图标",
            }
        },
    };

    public static readonly Dictionary<string, 制药流程配置> 制药流程配置表 = new()
    {
        {
            制药流程名称.制药流程1, new 制药流程配置()
            {
                名称 = 制药流程名称.制药流程1,
                颗粒大小 = 颗粒大小类型.粗,
                木柴名称 = 木柴名称.木柴1,
                砂体名称 = 砂体名称.砂体1,
                草药名称 = 草药名称.草药1,
                烧制时间 = 10,
            }
        },
        {
            制药流程名称.制药流程2, new 制药流程配置()
            {
                名称 = 制药流程名称.制药流程2,
                颗粒大小 = 颗粒大小类型.中,
                木柴名称 = 木柴名称.木柴2,
                砂体名称 = 砂体名称.砂体2,
                草药名称 = 草药名称.草药2,
                烧制时间 = 20,
            }
        },
        {
            制药流程名称.制药流程3, new 制药流程配置()
            {
                名称 = 制药流程名称.制药流程3,
                颗粒大小 = 颗粒大小类型.细,
                木柴名称 = 木柴名称.木柴3,
                砂体名称 = 砂体名称.砂体3,
                草药名称 = 草药名称.草药3,
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
        public const string 丹药1 = "丹药1";
        public const string 丹药2 = "丹药2";
        public const string 丹药3 = "丹药3";
    }

    public class 制药流程名称
    {
        public const string 制药流程1 = "制药流程1";
        public const string 制药流程2 = "制药流程2";
        public const string 制药流程3 = "制药流程3";
    }

    public class 砂体名称
    {
        public const string 砂体1 = "砂体1";
        public const string 砂体2 = "砂体2";
        public const string 砂体3 = "砂体3";
    }

    public class 木柴名称
    {
        public const string 木柴1 = "木柴1";
        public const string 木柴2 = "木柴2";
        public const string 木柴3 = "木柴3";
    }

    public class 草药名称
    {
        public const string 草药1 = "草药1";
        public const string 草药2 = "草药2";
        public const string 草药3 = "草药3";
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
        public 颗粒大小类型 颗粒大小;
        public string 木柴名称;
        public string 砂体名称;
        public string 草药名称;
        public int 烧制时间;
    }
}