using System.ComponentModel;

namespace Usignert.DynamicObject
{
    /// <summary>
    /// CustomPropertyDescriptor
    /// </summary>
    public class CustomPropertyDescriptor : PropertyDescriptor
    {
        public CustomProperty Property { get; set; }

        public CustomPropertyDescriptor(ref CustomProperty myProperty, Attribute[] attrs) : base(myProperty.Name, attrs)
        {
            Property = myProperty;
        }

        public override AttributeCollection Attributes
        {
            get
            {
                return new AttributeCollection(null);
            }
        }

        public override bool CanResetValue(object? component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get
            {
                return Property.Value.GetType();
            }
        }

        public override string DisplayName
        {
            get
            {
                return Property.Name;
            }
        }

        public override string Description
        {
            get
            {
                return Property.Name;
            }
        }

        public override object GetValue(object? component)
        {
            return Property.Value;
        }

        public override bool IsReadOnly
        {
            get
            {
                return Property.ReadOnly;
            }
        }

        public override string Name
        {
            get
            {
                return Property.Name;
            }
        }

        public override Type PropertyType
        {
            get
            {
                if (Property == null || Property.Value == null) return typeof(object);
                return Property.Value.GetType();
            }
        }

        public override void ResetValue(object component)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        public override void SetValue(object? component, object? value)
        {
            if (value == null) return;
            Property.Value = value;
        }
    }
}
