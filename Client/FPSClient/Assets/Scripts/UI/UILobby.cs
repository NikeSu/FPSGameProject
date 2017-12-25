using Sfs2X.Core;
using Sfs2X.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sfs2X.Entities.Data;

public class UILobby : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Global.EvtMgr.AddEventListener(SFSEvent.ROOM_JOIN, OnJoinRoomHandler);
        Global.EvtMgr.AddEventListener(SFSEvent.ROOM_JOIN_ERROR, OnJoinRoomErrorHandler);
       /// Global.NetMgr.SendSFSMessage(new JoinRoomRequest(Global.m_defaultRoom));
        Global.EvtMgr.AddEventListener("FetchUserInfo", OnFetchUserInfoHandler);
        ISFSObject obj = new SFSObject();
        obj.PutInt("id", Global.me.Id);
        Global.NetMgr.SendExtMessage("FetchUserInfo", obj);
    }

    private void OnFetchUserInfoHandler(Event evt)
    {
        SFSObject obj = evt.evt.Params["params"] as SFSObject;
        print(obj.GetUtfString("zone"));
        print(obj.GetInt("id"));
    }

    private void OnJoinRoomErrorHandler(Event evt)
    {
        print("进入房间失败");
    }

    private void OnJoinRoomHandler(Event evt)
    {
        print("进入 房间OK");

       
    }

    // Update is called once per frame
    void Update () {
		
	}
}
