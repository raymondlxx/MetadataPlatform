using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetadataPlatform.Common
{
    public enum FieldTypeEnum
    {
        /// <summary>
        /// 系统字段
        /// </summary>
        SystemField = 0,
        /// <summary>
        /// 用户字段
        /// </summary>
        UserDefinedField = 1,

    }
    /// <summary>
    /// 自定义字段的类型
    /// </summary>
    public enum FieldDisplayTypeEnum
    {
        Textbox = 1,

        Radio = 2,

        DropDownList = 3,

        Image = 4,

        DateTime = 5,

        Date = 6,
    }

    /// <summary>
    /// 自定义对象的状态
    /// </summary>
    public enum UDObjectStatusEnum
    {
        Disabled = 0,
        Enabled = 1,
    }
}
