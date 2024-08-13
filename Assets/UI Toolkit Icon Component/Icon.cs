using Unity.Properties;
using UnityEngine.UIElements;

namespace UIToolkitIconComponent {
    [UxmlElement]
    public partial class Icon : Label {

        private readonly string[] iconStyleClasses = new[] {
            "material-icon__outlined",
            "material-icon__rounded",
            "material-icon__sharp",
        };


        public enum IconStyleEnum {
            Outlined = 0,
            Rounded = 1,
            Sharp = 2,
        }


        private IconStyleEnum _iconStyle;

        [UxmlAttribute, CreateProperty]
        public IconStyleEnum IconStyle {
            get => _iconStyle;
            set {
                RemoveFromClassList(
                    iconStyleClasses[(int) _iconStyle]
                );

                AddToClassList(
                    iconStyleClasses[(int) value]
                );

                _iconStyle = value;
            }
        }

        private string _iconCode;

        [UxmlAttribute, CreateProperty]
        public string IconCode {
            get => _iconCode;
            set {
                _iconCode = value;

                text = $"\\u{_iconCode}";
            }
        }


        public Icon() {
            IconStyle = IconStyleEnum.Rounded;

            AddToClassList(
                "icon"
            );
        }
    }
}
