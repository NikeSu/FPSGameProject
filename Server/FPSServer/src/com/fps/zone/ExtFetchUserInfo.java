package com.fps.zone;

import com.smartfoxserver.v2.entities.User;
import com.smartfoxserver.v2.entities.data.ISFSObject;
import com.smartfoxserver.v2.entities.data.SFSObject;
import com.smartfoxserver.v2.extensions.BaseClientRequestHandler;

public class ExtFetchUserInfo extends BaseClientRequestHandler {

	public void handleClientRequest(User arg0, ISFSObject arg1) {
		// TODO Auto-generated method stub
		
		//通过ISFSObject可以获取客户端发过来的参数
		
		//从客户端发过来的参数中获取id
		int uid=arg1.containsKey("id") ? arg1.getInt("id") : -1;
		
		trace("id="+uid);
		
		//构建返回数据
		SFSObject outObj=new SFSObject();
		
		//如果没有发送id则返回当前用户信息
		if(uid!=-1) {
			outObj.putUtfString("name", arg0.getName());
			outObj.putInt("id", arg0.getId());
			outObj.putUtfString("name", arg0.getName());
			if(arg0.getLastJoinedRoom()==null) {
				outObj.putNull("room");
			}else {
				outObj.putUtfString("room", arg0.getLastJoinedRoom().getName());
			}
			outObj.putUtfString("zone",arg0.getZone().getName());
		
		}else {
			User u=this.getApi().getUserById(uid);
			outObj.putInt("id", u.getId());
			outObj.putUtfString("name", u.getName());
			if(u.getLastJoinedRoom()==null) {
				outObj.putNull("room");
			}else {
				outObj.putUtfString("room", u.getLastJoinedRoom().getName());
			}
			outObj.putUtfString("zone",u.getZone().getName());
		}
		//此项为测试值
		outObj.putInt("coin", 1000);
 
		//向客户端发送数据
		this.send("FetchUserInfo", outObj, arg0);
		
		
	}

}
