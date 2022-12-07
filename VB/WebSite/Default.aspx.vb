Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Xpo
Imports DevExpress.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private session As Session = XpoHelper.GetNewSession()

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		xds.Session = session
	End Sub

	Protected Sub chk_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim chk As ASPxCheckBox = TryCast(sender, ASPxCheckBox)
		Dim container As GridViewDataItemTemplateContainer = TryCast(chk.NamingContainer, GridViewDataItemTemplateContainer)

		chk.ClientSideEvents.CheckedChanged = String.Format("function (s, e) {{ OnCheckedChange(s, e, {0}, {1}); }}", container.KeyValue, container.VisibleIndex)
	End Sub
	Protected Sub cb_Callback(ByVal source As Object, ByVal e As DevExpress.Web.CallbackEventArgs)
		Dim p() As String = e.Parameter.Split("|"c)

		Dim obj As MyObject = session.GetObjectByKey(Of MyObject)(Convert.ToInt32(p(0))) ' get the record from the Session
		obj.Active = Convert.ToBoolean(p(1))

		obj.Save()
	End Sub
	Protected Sub grid_HtmlRowPrepared(ByVal sender As Object, ByVal e As ASPxGridViewTableRowEventArgs)
		e.Row.CssClass += String.Format(" dataRow{0}", e.VisibleIndex)
		Dim g As ASPxGridView = TryCast(sender, ASPxGridView)
		Dim cb As ASPxCheckBox = TryCast(g.FindRowCellTemplateControl(e.VisibleIndex, CType(g.Columns("Active"), GridViewDataColumn), "chk"), ASPxCheckBox)
		If cb.Checked Then
			e.Row.CssClass &= " rowChecked"
		End If
	End Sub
End Class
