using Sfs2X.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event  {

    /// <summary>
    /// 事件发送者
    /// </summary>
    public Object sender = null;

    /// <summary>
    /// 事件类型
    /// </summary>
    public string  type = null;

    /// <summary>
    /// 事件信息包括(Ext和Sys)
    /// </summary>
    public BaseEvent evt = null;


    public Event(Object sender,string type,BaseEvent evt)
    {
        this.sender = sender;
        this.type = type;
        this.evt = evt;
    }

}
