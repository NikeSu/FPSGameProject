using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sfs2X.Core;

public class EventManager : MonoBehaviour {

    /// <summary>
    /// 基本事件委托
    /// </summary>
    /// <param name="evt">事件对象</param>
    public delegate void OnNotification(Event evt);
    private Dictionary<string, OnNotification> eventListeners;


    public void Init()
    {
        eventListeners = new Dictionary<string, OnNotification>();
        Global.Log("【EventManager】初始化成功！");
    }
    /// <summary>
    /// 添加监听事件
    /// </summary>
    /// <param name="type">类型</param>
    /// <param name="listener">监听回调委托</param>
    public void AddEventListener(string type, OnNotification listener)
    {
        if (!eventListeners.ContainsKey(type))
        {
            OnNotification onNote = null;
            eventListeners[type] = onNote;
        }
        eventListeners[type] += listener;
    }
    /// <summary>
    /// 添加系统事件监听
    /// </summary>
    /// <param name="type">事件类型</param>
    /// <param name="listener">委托函数</param>
    public void AddEventListener(SFSEvent type, OnNotification listener)
    {
        if (!eventListeners.ContainsKey(type.Type))
        {
            OnNotification onNote = null;
            eventListeners[type.Type] = onNote;
        }
        eventListeners[type.Type] += listener;

    }


    /// <summary>
    /// 移除监听事件
    /// </summary>
    /// <param name="type"></param>
    /// <param name="listener"></param>
    public void RemoveListener(string type, OnNotification listener)
    {
        if (eventListeners.ContainsKey(type))
        {
            return;
        }
        eventListeners[type] -= listener;
    }

    /// <summary>
    /// 移除系统事件监听
    /// </summary>
    /// <param name="type"></param>
    /// <param name="listener"></param>
    public void RemoveListener(SFSEvent type, OnNotification listener)
    {
        if (eventListeners.ContainsKey(type.Type))
        {
            return;
        }
        eventListeners[type.Type] -= listener;
    }

    /// <summary>
    ///移除事件
    /// </summary>
    /// <param name="type">事件类型</param>
    public void RemoveListener(string type)
    {
        if (eventListeners.ContainsKey(type))
        {
            eventListeners.Remove(type);
        }
    }

    /// <summary>
    /// 移除系统事件
    /// </summary>
    /// <param name="type"></param>
    public void RemoveListener(SFSEvent type)
    {
        if (eventListeners.ContainsKey(type.Type))
        {
            eventListeners.Remove(type.Type);
        }
    }

    public void DispatchEvent(Event note)
    {
        if (eventListeners.ContainsKey(note.type))
        {
            eventListeners[note.type](note);
        }
    }

    /// <summary>
    /// 检测是否存在监听
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public bool HasEventListener(string type)
    {
        return eventListeners.ContainsKey(type);
    }
}


