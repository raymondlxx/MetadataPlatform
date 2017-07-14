using MetadataPlatform.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetadataPlatform.Web.Models
{
    public class BaseEntity
    {
        public string ID { get; set; }

    }

    public class UDObjectEntity: BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        [Description("状态")]
        public UDObjectStatusEnum Status { get; set; }

    }

    public class UDFieldEntity : BaseEntity
    {
        public string FieldName { get; set; }

        public string Description { get; set; }

        public FieldTypeEnum FieldType { get; set; }

        public FieldDisplayTypeEnum DisplayType { get; set; }


    }

}
