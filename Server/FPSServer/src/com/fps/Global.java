package com.fps;

import com.smartfoxserver.v2.db.IDBManager;
import com.smartfoxserver.v2.extensions.ExtensionLogLevel;
import com.smartfoxserver.v2.extensions.SFSExtension;

public class Global {
	 public static DBManager db=null;
	 private static SFSExtension  ext=null;
  

	 /**
	  * 初始化全局对象，此对象存储全局对象或管理器
	  * @param startExt  服务器扩展
	  * @param dbmgr     SFS数据库管理器
	  */
	   public static void Init(SFSExtension startExt,IDBManager dbmgr) {
		   ext=startExt;
		   db=new DBManager(dbmgr);
	   }
	   
	   /** 
	    * 全局控制台输出函数
	    * @param args
	    */
	   public static void print(Object args) {
		   if(ext!=null) {
			   ext.trace(args);
		   }
	   }
	   
	   /** 
	    * 全局控制台输出函数
	    * @param level
	    * @param args
	    */
	   public static void print(ExtensionLogLevel level,Object args)
	   {
		   if(ext!=null) {
			   ext.trace(level, args);
		   }
	   }
}
