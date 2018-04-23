using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Popup;

namespace WindowsApplication1 {
    //The attribute that points to the registration method
    [UserRepositoryItem("RegisterCustomEdit")]
    public class RepositoryItemCustomComboBoxEdit : RepositoryItemComboBox {

        //The static constructor which calls the registration method
        static RepositoryItemCustomComboBoxEdit() { RegisterCustomEdit(); }

        //Initialize new properties
        public RepositoryItemCustomComboBoxEdit() {
        }

        //The unique name for the custom editor
        public const string CustomEditName = "CustomComboBoxEdit";

        //Return the unique name
        public override string EditorTypeName { get { return CustomEditName; } }

        //Register the editor
        public static void RegisterCustomEdit() {
            //Icon representing the editor within a container editor's Designer
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(CustomComboBoxEdit), typeof(RepositoryItemCustomComboBoxEdit), typeof(ComboBoxViewInfo), new ButtonEditPainter(), true, null, typeof(DevExpress.Accessibility.PopupEditAccessible)));
        }
    }

    public class CustomComboBoxEdit : ComboBoxEdit {
        protected override DevExpress.XtraEditors.Popup.PopupBaseForm CreatePopupForm() {
            return new CustomPopupListBoxForm(this);
        }
        //The static constructor which calls the registration method
        static CustomComboBoxEdit() { RepositoryItemCustomComboBoxEdit.RegisterCustomEdit(); }

        //Initialize the new instance
        public CustomComboBoxEdit() {
            //...
        }

        //Return the unique name
        public override string EditorTypeName { get { return RepositoryItemCustomComboBoxEdit.CustomEditName; } }

        //Override the Properties property
        //Simply type-cast the object to the custom repository item type
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomComboBoxEdit Properties {
            get { return base.Properties as RepositoryItemCustomComboBoxEdit; }
        }


    }

    public class CustomPopupListBoxForm : PopupListBoxForm {
        public CustomPopupListBoxForm(ComboBoxEdit be)
            : base(be) {

        }
        protected override PopupListBox CreateListBox() {
            return new CustomPopupListBox(this);
        }

    }

    public class CustomPopupListBox : PopupListBox {
        public CustomPopupListBox(PopupListBoxForm owner)
            : base(owner) {
        }
        protected override BaseStyleControlViewInfo CreateViewInfo() {
            return new CustomBaseStyleControlViewInfo(this);
        }
    }

    public class CustomBaseStyleControlViewInfo : PopupListBoxViewInfo {
        public CustomBaseStyleControlViewInfo(PopupListBox owner)
            : base(owner) {
        }
        protected override BaseListBoxViewInfo.ItemInfo CreateItemInfo(Rectangle bounds, object item, string text, int index) {
            if (item.ToString() != "1") { text = "  " + text; }
            return base.CreateItemInfo(bounds, item, text, index);
        }
    }
}
