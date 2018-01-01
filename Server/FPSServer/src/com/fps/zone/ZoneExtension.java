package com.fps.zone;

import com.fps.Global;
import com.smartfoxserver.v2.core.SFSEventType;
import com.smartfoxserver.v2.extensions.SFSExtension;

public class ZoneExtension extends SFSExtension {

	public void init() {
		trace("==================绝地求生服务器初始化==========================");
		Global.Init(this, getParentZone().getDBManager());
		//监听系统登录事件
		this.addEventHandler(SFSEventType.USER_LOGIN,SFSLoginHandler.class);
		
		//监听扩展
		this.addRequestHandler("FetchUserInfo", ExtFetchUserInfo.class);
		
		
		
		
	
		
		
		
		
		try {
			//初始化扩展及数据库连接
			
			
		
			// TODO Auto-generated method stub
			trace("=======================================================");
		}catch(Exception e) {
			trace("服务器初始化失败"+e.getMessage());
		}
	}


}
