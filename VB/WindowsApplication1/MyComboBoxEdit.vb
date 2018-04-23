Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Popup

Namespace WindowsApplication1
	'The attribute that points to the registration method
	<UserRepositoryItem("RegisterCustomEdit")> _
	Public Class RepositoryItemCustomComboBoxEdit
		Inherits RepositoryItemComboBox

		'The static constructor which calls the registration method
		Shared Sub New()
			RegisterCustomEdit()
		End Sub

		'Initialize new properties
		Public Sub New()
		End Sub

		'The unique name for the custom editor
		Public Const CustomEditName As String = "CustomComboBoxEdit"

		'Return the unique name
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return CustomEditName
			End Get
		End Property

		'Register the editor
        Public Shared Sub RegisterCustomEdit()
            Dim img As System.Drawing.Image = Nothing
            'Icon representing the editor within a container editor's Designer
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(CustomEditName, GetType(CustomComboBoxEdit), _
          GetType(RepositoryItemCustomComboBoxEdit), _
          GetType(ComboBoxViewInfo), New ButtonEditPainter, True, img))
        End Sub
	End Class

	Public Class CustomComboBoxEdit
		Inherits ComboBoxEdit
		Protected Overrides Function CreatePopupForm() As DevExpress.XtraEditors.Popup.PopupBaseForm
			Return New CustomPopupListBoxForm(Me)
		End Function
		'The static constructor which calls the registration method
		Shared Sub New()
			RepositoryItemCustomComboBoxEdit.RegisterCustomEdit()
		End Sub

		'Initialize the new instance
		Public Sub New()
			'...
		End Sub

		'Return the unique name
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemCustomComboBoxEdit.CustomEditName
			End Get
		End Property

		'Override the Properties property
		'Simply type-cast the object to the custom repository item type
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemCustomComboBoxEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemCustomComboBoxEdit)
			End Get
		End Property


	End Class

	Public Class CustomPopupListBoxForm
		Inherits PopupListBoxForm
		Public Sub New(ByVal be As ComboBoxEdit)
			MyBase.New(be)

		End Sub
		Protected Overrides Function CreateListBox() As PopupListBox
			Return New CustomPopupListBox(Me)
		End Function

	End Class

	Public Class CustomPopupListBox
		Inherits PopupListBox
		Public Sub New(ByVal owner As PopupListBoxForm)
			MyBase.New(owner)
		End Sub
		Protected Overrides Function CreateViewInfo() As BaseStyleControlViewInfo
			Return New CustomBaseStyleControlViewInfo(Me)
		End Function
	End Class

	Public Class CustomBaseStyleControlViewInfo
		Inherits PopupListBoxViewInfo
		Public Sub New(ByVal owner As PopupListBox)
			MyBase.New(owner)
		End Sub
		Protected Overrides Function CreateItemInfo(ByVal bounds As Rectangle, ByVal item As Object, ByVal text As String, ByVal index As Integer) As BaseListBoxViewInfo.ItemInfo
			If item.ToString() <> "1" Then
				text = "  " & text
			End If
			Return MyBase.CreateItemInfo(bounds, item, text, index)
		End Function
	End Class
End Namespace
