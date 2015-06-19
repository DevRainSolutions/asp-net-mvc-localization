using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Resources;
using System.Web.Mvc;

namespace asp_net_mvc_localization.Utils
{
    /*
     * http://stackoverflow.com/questions/4749657/client-side-validation-does-not-work-when-inherting-from-requiredattribute-in-as
     */

    /// <summary>
    /// Universal Adapter for each ValidationAttribute
    /// Does not support client validation :(
    /// </summary>
    public class ValidationAttributeAdapter : DataAnnotationsModelValidator<ValidationAttribute>
    {
        public ValidationAttributeAdapter(ModelMetadata metadata,
            ControllerContext context,
            ValidationAttribute attribute)
            : base(metadata, context, attribute)
        {
            AdapterHelper.ChangeAttribute(attribute);
        }
    }

    /// <summary>
    /// Adapters that provide localization for Validation Attributes
    /// Supports client validation
    /// </summary>
    #region ValidationAttribute Adapters
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
    #endregion
}

public class LocalizedDescriptionAttribute : DescriptionAttribute
{
    private readonly string _resourceKey;
    private readonly ResourceManager _resource;
    public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
    {
        _resource = new ResourceManager(resourceType);
        _resourceKey = resourceKey;
    }

    public override string Description
    {
        get
        {
            string displayName = _resource.GetString(_resourceKey);

            return string.IsNullOrEmpty(displayName)
                ? string.Format("[[{0}]]", _resourceKey)
                : displayName;
        }
    }
}