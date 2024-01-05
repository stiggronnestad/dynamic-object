namespace Usignert.DynamicObject
{
    /// <summary>
    /// CustomProperty
    /// </summary>
    public class CustomProperty(string key, string name, object value, bool readOnly = false, bool visible = true, object? tag = null, object? payLoad = null)
    {
        public string Key { get; set; } = key;
        public string Name { get; set; } = name;
        public object Value { get; set; } = value;
        public bool ReadOnly { get; set; } = readOnly;
        public bool Visible { get; set; } = visible;
        public object? Tag { get; set; } = tag;
        public object? Payload { get; set; } = payLoad;
    }
}
