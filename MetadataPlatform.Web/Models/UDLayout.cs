using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MetadataPlatform.Web.Models
{
    public interface IUILayout
    {

    }

    public interface IControl
    {

    }

    public interface IContainer: IControl
    {

    }

    public class UIControlBase: IUILayout
    {
        public string ID { get; set; }
    }

    public class UILayout: UIControlBase
    {
        [Description("布局名称")]
        public string Name { get; set; }

    }

    /// <summary>
    /// UI容器:可包含多个容器
    /// </summary>
    public class UIContainer: UIControlBase
    {
        [Description("容器标题")]
        public string Title { get; set; }
        public List<UIControl> Controls { get; set; }

    }

    public class UIControl
    {
        
    }
}