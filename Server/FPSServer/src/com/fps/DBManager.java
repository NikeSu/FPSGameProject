package com.fps;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.fps.zone.ZoneExtension;
import com.fps.Global;
import com.mysql.jdbc.ResultSetRow;
import com.smartfoxserver.v2.api.SFSApi;
import com.smartfoxserver.v2.db.IDBManager;
import com.smartfoxserver.v2.extensions.ExtensionLogLevel;


public class DBManager {
	// 数据库管理器
	private IDBManager dbManager;
	private Connection conn = null;// 数据库连接

	public DBManager(IDBManager mgr) {
		dbManager = mgr;
		try {
			conn = (Connection) dbManager.getConnection();
			Global.print("初始化数据库成功! " + dbManager.getConfig().connectionString);
			
		} catch (SQLException e) {
			Global.print(ExtensionLogLevel.WARN, "初始化数据库失败"+dbManager.getConfig().connectionString+": " + e.toString());
		}
	}

	public List<HashMap> doQuery(String sql) {
		try {
			Statement stmt = conn.createStatement();
			//执行SQL语句
			ResultSet rs = stmt.executeQuery(sql);
			//将查询结果转换为List
			List<HashMap> data=convertList(rs);
			rs.close();
			stmt.close();
			return data;
		} catch (Exception e) {
			Global.print("do Query【"+sql+"】 failed: " + e.getMessage());
		}
		return null;
	}
	
	public Boolean ExecuteSQL(String sql)
	{
		
		return false;
	}

	private List convertList(ResultSet rs) throws SQLException {
		List<HashMap>  list= new ArrayList();
		ResultSetMetaData md = rs.getMetaData();// 获取键名
		int columnCount = md.getColumnCount();// 获取行的数量
		while (rs.next()) {
			HashMap rowData = new HashMap();// 声明Map
			for (int i = 1; i <= columnCount; i++) {
				rowData.put(md.getColumnName(i), rs.getObject(i));// 获取键名及值
			}
			list.add(rowData);
		}
		return list;
	}
	
	
	public void CheckUserLogin(String user,String password) {
		
		//构建SQL语句
		String sql="select * from account where acc_user='"+user+"'";
		try {
			Statement stmt = conn.createStatement();
			//执行SQL语句
			ResultSet rs = stmt.executeQuery(sql);
			
		    Global.print(rs.getRow());
		}catch(SQLException e) {
			Global.print(e.getMessage());
		}
	}
}

