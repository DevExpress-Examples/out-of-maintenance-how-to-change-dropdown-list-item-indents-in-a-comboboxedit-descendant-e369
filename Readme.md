<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E369)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MyComboBoxEdit.cs](./CS/WindowsApplication1/MyComboBoxEdit.cs) (VB: [MyComboBoxEdit.vb](./VB/WindowsApplication1/MyComboBoxEdit.vb))
<!-- default file list end -->
# How to change dropdown list item indents in a ComboBoxEdit descendant


<p>This task can be accomplished without a descendant by handling the DrawItem event. However, in this case it's not possible to higlight a combo item as we do when the ComboBoxEdit.Properties.HighlightedItemStyle is set DevExpress.XtraEditors.HighlightStyle.Skinned. </p><p>The main idea is change the item info before displaying it, to move an item text. You need to create some descendant from our class, and override the CreateItemInfo method in which you add necessary spaces to text.</p>

<br/>


