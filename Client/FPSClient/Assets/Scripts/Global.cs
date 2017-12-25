using Sfs2X.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Global : MonoBehaviour {

    #region 服务器信息配置
    public static string ServerIP = "127.0.0.1";
    public static int ServerPort = 9933;
    public static string m_defaultZone = "FPSServer1";
    public static string m_defaultRoom = "lobby";

    public static User me;
    #endregion

    #region 公共管理类属性

    public static NetManager NetMgr = null;
    public static EventManager EvtMgr = null;
    public static ResManager ResMgr = null;

    #endregion

    #region 单例实现
    private static Global _instance;
    public static Global Instance
    {

        get { return _instance; }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    #endregion


    void Start()
    {
        //初始化各管理器
        NetMgr = this.gameObject.AddComponent<NetManager>();
        EvtMgr = this.gameObject.AddComponent<EventManager>();
        ResMgr = this.gameObject.AddComponent<ResManager>();

        ResMgr.Init();
        EvtMgr.Init();
        NetMgr.Init(m_defaultZone);
        NetMgr.Connect(ServerIP, ServerPort);
    }


   public static void Log(params object[] infos)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in infos)
        {
            sb.Append(item.ToString()+"   ");
        }
        Debug.Log(sb);
    } 
}
