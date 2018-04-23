<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Xpo.v13.1.Web, Version=13.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to update a Boolean field using the ASPxCheckBox in a DataItem template</title>
	<style type="text/css">
			.rowChecked
			{
				background-color:  aquamarine;
			}
		</style>
	<script src="Script/jquery-1.5.1.js"></script>
	<script language="javascript" type="text/javascript">
		function OnCheckedChange(s, e, rowKey, rowIndex) {
			var isChecked = s.GetChecked();
			cb.PerformCallback(rowKey + '|' + isChecked);
			var row = $('.dataRow' + rowIndex);
			if (isChecked)
				row.addClass("rowChecked");
			else
				row.removeClass("rowChecked");
			
		}	
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="xds"
            KeyFieldName="Oid" OnHtmlRowPrepared="grid_HtmlRowPrepared">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="Oid" ReadOnly="True" VisibleIndex="0" SortOrder="Ascending">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Title" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="Active" VisibleIndex="2">
                    <DataItemTemplate>
                        <dx:ASPxCheckBox ID="chk" runat="server" Value='<%# Eval("Active") %>' OnInit="chk_Init">
                        </dx:ASPxCheckBox>
                    </DataItemTemplate>
                </dx:GridViewDataCheckColumn>
            </Columns>
        </dx:ASPxGridView>
    </div>
    <dx:XpoDataSource ID="xds" runat="server" TypeName="MyObject">
    </dx:XpoDataSource>
    <dx:ASPxCallback ID="cb" runat="server" ClientInstanceName="cb" OnCallback="cb_Callback">
    </dx:ASPxCallback>
    </form>
</body>
</html>
