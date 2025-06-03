using UnityEngine.UIElements;

namespace UIToolkitExamples
{
    [UxmlElement]
    public partial class ExampleField : BaseField<double>
    {
        [UxmlAttribute("value")]
        public double fieldValue
        {
            get => value;
            set => SetValueWithoutNotify(value);
        }

        Label m_Input;

        public ExampleField() : this(null) { }

        public ExampleField(string label) : base(label, new Label())
        {
            m_Input = (Label)this[0]; // The visualInput is always the first child
        }

        public override void SetValueWithoutNotify(double newValue)
        {
            base.SetValueWithoutNotify(newValue);
            if (m_Input != null)
                m_Input.text = newValue.ToString("N");
        }
    }
}