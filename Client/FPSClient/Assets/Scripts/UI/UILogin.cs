using Sfs2X.Core;
using Sfs2X.Entities;
using Sfs2X.Entities.Data;
using Sfs2X.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILogin : MonoBehaviour {

    public InputField user;
    public InputField pwd;
    public Button btnLogin;
	// Use this for initialization
	void Start () {
        btnLogin.onClick.AddListener(Start2Login);
        Global.EvtMgr.AddEventListener(SFSEvent.LOGIN, OnLoginHandler);
        Global.EvtMgr.AddEventListener(SFSEvent.LOGIN_ERROR, OnLoginErrorHandler);
	}

    private void OnLoginErrorHandler(Event evt)
    {
        print("登录失败"+evt.evt.Params["errorMessage"]);
    }

    private void OnLoginHandler(Event evt)
    {
        print("登录成功");

        //存储自己
        Global.me = evt.evt.Params["user"] as User;

        SceneManager.LoadSceneAsync("Lobby");
        
    }

    private void Start2Login()
    {
        Global.NetMgr.SendSFSMessage(new LoginRequest(user.text, pwd.text, Global.m_defaultZone));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
