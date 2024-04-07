//==============================================================================
// Copyright (C) 皖仪科技研发中心
// 作者：软件一部 姚迪迪
//==============================================================================
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LucasNetLib.UI.Console
{
    /// <summary>
    /// 驱动插件特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [Serializable]
    public sealed class AddInAttribute : Attribute
    {
        /// <summary>
        /// 驱动对象
        /// </summary>
        public Type Object { get; set; }

        /// <summary>
        /// 驱动名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 名称描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 附加属性
        /// </summary>
        public object Tag { get; set; }

        public AddInAttribute()
        {
        }
    }


    [AddIn(Object = typeof(SWS500), Name = "SWS500", Description = "SWS500微型气象站", Tag = "ct_Device")]
    public class SWS500
    {
        private const string CTypeName = "SWS500";

        //[AddInProperty(Language = "config.device.sws500.gas", Descrption = "气体类型", Range = "", ProType = "pt_Label", DefaultValue = "WindSpeed,WindDirection,EnvTemp,EnvHumidity,Pressure")]
        public string GasCollect { get; set; }

        /// <summary>
        /// Modubus设备地址通过IDentify信息赋值
        /// </summary>
        //[AddInProperty(Language = "config.device.sws500.modbusaddr", Descrption = "地址", Range = "^[0-9]$|^[0-9][0-9]$|^1[0-9][0-9]$|^2[0-4][0-9]$|^25[0-5]$;config.warningInfo.inputRangeError.0to255;config.warningInfo.inputSuccess",
        //                ProType = "pt_String", DefaultValue = "01")]


        
    }
}
