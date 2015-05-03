using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace asp_net_mvc_localization.Utils
{
    /*
     * http://stackoverflow.com/questions/4749657/client-side-validation-does-not-work-when-inherting-from-requiredattribute-in-as
     */
    public class MyRequiredAttributeAdapter : RequiredAttributeAdapter
    {
        public MyRequiredAttributeAdapter(
            ModelMetadata metadata,
            ControllerContext context,
            RequiredAttribute attribute)
            :base(metadata, context, attribute)
        {
            AdapterHelper.ChangeAttribute(attribute);
        }
    }

    public class MyMinLengthAttributeAdapter : MinLengthAttributeAdapter
    {
        public MyMinLengthAttributeAdapter(
            ModelMetadata metadata,
            ControllerContext context,
            MinLengthAttribute attribute)
            : base(metadata, context, attribute)
        {
            AdapterHelper.ChangeAttribute(attribute);
        }
    }

    public class MyMaxLengthAttributeAdapter : MaxLengthAttributeAdapter
    {
        public MyMaxLengthAttributeAdapter(
            ModelMetadata metadata,
            ControllerContext context,
            MaxLengthAttribute attribute)
            : base(metadata, context, attribute)
        {
            AdapterHelper.ChangeAttribute(attribute);
        }
    }

    public class MyRangeAttributeAdapter : RangeAttributeAdapter
    {
        public MyRangeAttributeAdapter(
            ModelMetadata metadata,
            ControllerContext context,
            RangeAttribute attribute)
            : base(metadata, context, attribute)
        {
            AdapterHelper.ChangeAttribute(attribute);
        }
    }

    public class MyRegularExpressionAttributeAdapter : RegularExpressionAttributeAdapter
    {
        public MyRegularExpressionAttributeAdapter(
            ModelMetadata metadata,
            ControllerContext context,
            RegularExpressionAttribute attribute)
            : base(metadata, context, attribute)
        {
            AdapterHelper.ChangeAttribute(attribute);
        }
    }
}