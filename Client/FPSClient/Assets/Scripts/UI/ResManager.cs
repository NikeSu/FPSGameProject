using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 定义的资源类型
/// </summary>
public enum ResType
{
    UI,Role,Weapon
}
public class ResManager : MonoBehaviour {
	
    
    public void Init()
    {
        Global.Log("【ResManager】初始化成功!");
    }

    /// <summary>
    /// 通过资源类型和资源名称加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type">资源类型</param>
    /// <param name="resName">资源名称</param>
    /// <returns></returns>
    public T LoadRes<T>(ResType type,string resName)
    {
        return default(T);
    }
}
