using Sfs2X;
using Sfs2X.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sfs2X.Requests;
using Sfs2X.Entities.Data;
using Sfs2X.Entities;
using Sfs2X.Entities.Variables;
using System.Text;

public class NetManager : MonoBehaviour {

    private SmartFox sfs = new SmartFox();

    private string defaultZoneName="";
    /// <summary>
    /// 初始化默认游戏区
    /// </summary>
    /// <param name="defaultZone"></param>
    public void Init(string Zone)
    {
        this.defaultZoneName = Zone;
        sfs.ThreadSafeMode = true;
        //是否开启调试模式
        //sfs.Debug = true;

        //监听客户端事件
        sfs.AddEventListener(SFSEvent.CONNECTION, OnSFSEventHandler);
        sfs.AddEventListener(SFSEvent.CONNECTION_LOST, OnSFSEventHandler);

        //监听客户端登录事件
        sfs.AddEventListener(SFSEvent.LOGIN, OnSFSEventHandler);
        sfs.AddEventListener(SFSEvent.LOGIN_ERROR, OnSFSEventHandler);

        sfs.AddEventListener(SFSEvent.EXTENSION_RESPONSE, OnExtensionHandler);
        sfs.AddEventListener(SFSEvent.ROOM_JOIN, OnSFSEventHandler);

        Global.Log("【NetManager】初始化成功！");
    }

  

    /// <summary>
    /// 链接到服务器
    /// </summary>
    /// <param name="serverIP">服务器IP</param>
    /// <param name="serverPort">端口</param>
    public void Connect(string serverIP = "127.0.0.1", int serverPort = 9933)
    {
        sfs.Connect(serverIP, serverPort);
    }

    /// <summary>
    /// 系统事件监听
    /// </summary>
    /// <param name="evt"></param>
    private void OnSFSEventHandler(BaseEvent evt)
    {
        Event e = new Event(this, evt.Type, evt);
        switch (evt.Type)
        {
            case "connection": //连接服务器
                #region 连接            
                if ((bool)evt.Params["success"])
                {
                    Global.Log(string.Format("[SYS]已连接到服务器{0}:{1}", sfs.Config.Host, sfs.Config.Port));
                    //sfs.Send(new LoginRequest("", "", defaultZoneName));
                }
                else
                {
                    Global.Log(string.Format("[SYS]无法接到服务器{0}:{1}", sfs.Config.Host, sfs.Config.Port));
                }
                #endregion
                break;
            case "connectLost":  //连接断开
                Global.Log("与服务器断开连接");
                break;
            case "login": //登录成功
                break;
			case "loginError": //登录失败
                Global.Log("用户登录失败！"+evt.Params["errorMessage"]);
                break;
            case "roomJoined":
                break;
        }
        ///派发系统事件
        Global.EvtMgr.DispatchEvent(e);
    }






    /// <summary>
    /// 向服务器发送扩展请求
    /// </summary>
    /// <param name="cmd">命令</param>
    /// <param name="obj">数据</param>
    public void SendExtMessage(string cmd,ISFSObject obj)
    {
        sfs.Send(new ExtensionRequest(cmd, obj));
    }

    /// <summary>
    /// 向服务器端发送事件请求
    /// </summary>
    /// <param name="request"></param>
    public void SendSFSMessage(IRequest request)
    {
        sfs.Send(request);
    }


    /// <summary>
    /// 扩展函数处理
    /// </summary>
    /// <param name="evt">事件类型</param>
    private void OnExtensionHandler(BaseEvent evt)
    {
        //通讯指令
        string cmd = (string)evt.Params["cmd"];
        Event e = new Event(this, cmd, evt);
        Global.EvtMgr.DispatchEvent(e); 
    }


    void Update()
    {
        ///不断刷新SmartFoxServer事件处理
        if (sfs != null)
            sfs.ProcessEvents();

    }


    void OnDestroy()
    {
        //关闭时，断开与服务器连接
        if (sfs != null && sfs.IsConnected)
        {
            sfs.Disconnect();
        }
    }
}
