using System.Collections;
using System.ComponentModel;

namespace Usignert.DynamicObject
{
    /// <summary>
    /// CustomObject
    /// </summary>
    public class CustomObject : CollectionBase, ICustomTypeDescriptor
    {
        public string Name { get; set; } = "New Object";

        public void Add(CustomProperty value)
        {
            base.List.Add(value);
        }

        public void Remove(string key)
        {
            var p = GetByKey(key);

            if (p != null)
            {
                base.List.Remove(p);
            }
        }

        public CustomProperty? GetByKey(string key)
        {
            foreach (CustomProperty prop in base.List)
            {
                if (prop.Key.Equals(key, StringComparison.CurrentCultureIgnoreCase))
                {
                    return prop;
                }
            }

            return null;
        }

        public CustomProperty? this[int index]
        {
            get
            {
                return List[index] as CustomProperty;
            }
            set
            {
                List[index] = value;
            }
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[]? attributes)
        {
            if (attributes == null) return ((ICustomTypeDescriptor) this).GetProperties();

            PropertyDescriptor[] newProps = new PropertyDescriptor[Count];

            for (int i = 0; i < Count; i++)
            {
                var prop = this[i];
                if (prop == null) continue;

                newProps[i] = new CustomPropertyDescriptor(ref prop, attributes);
            }

            return new PropertyDescriptorCollection(newProps);
        }

        string? ICustomTypeDescriptor.GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        string? ICustomTypeDescriptor.GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        EventDescriptor? ICustomTypeDescriptor.GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        PropertyDescriptor? ICustomTypeDescriptor.GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        object? ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[]? attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return TypeDescriptor.GetProperties(this, true);
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor? pd)
        {
            return this;
        }
    }
}
