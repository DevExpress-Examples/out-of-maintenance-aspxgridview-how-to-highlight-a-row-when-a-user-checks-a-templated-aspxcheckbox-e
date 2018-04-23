using System;
using DevExpress.Xpo;

public class MyObject : XPObject {
    public MyObject()
        : base() { }

    public MyObject(Session session)
        : base(session) { }

    public override void AfterConstruction() {
        base.AfterConstruction();
    }

    protected String _Title;
    public String Title {
        get { return _Title; }
        set { SetPropertyValue<String>("Title", ref _Title, value); }
    }

    private Boolean active;
    public Boolean Active {
        get { return active; }
        set { SetPropertyValue("Active", ref active, value); }
    }
}

