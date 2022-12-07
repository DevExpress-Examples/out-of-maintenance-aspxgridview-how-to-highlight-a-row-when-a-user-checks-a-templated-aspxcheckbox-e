using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Xpo;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page {
    Session session = XpoHelper.GetNewSession();

    protected void Page_Init(object sender, EventArgs e) {
        xds.Session = session;
    }

    protected void chk_Init(object sender, EventArgs e) {
        ASPxCheckBox chk = sender as ASPxCheckBox;
        GridViewDataItemTemplateContainer container = chk.NamingContainer as GridViewDataItemTemplateContainer;

		chk.ClientSideEvents.CheckedChanged = String.Format("function (s, e) {{ OnCheckedChange(s, e, {0}, {1}); }}", container.KeyValue, container.VisibleIndex);
    }
    protected void cb_Callback(object source, DevExpress.Web.CallbackEventArgs e) {
        String[] p = e.Parameter.Split('|');
		
        MyObject obj = session.GetObjectByKey<MyObject>(Convert.ToInt32(p[0])); // get the record from the Session
        obj.Active = Convert.ToBoolean(p[1]);

        obj.Save();
    }
	protected void grid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e) {
		e.Row.CssClass += String.Format(" dataRow{0}", e.VisibleIndex);
		ASPxGridView g = sender as ASPxGridView;
		ASPxCheckBox cb = g.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)g.Columns["Active"], "chk") as ASPxCheckBox;
		if (cb.Checked)
			e.Row.CssClass += " rowChecked";
	}
}
