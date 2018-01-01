<?php
class DBHelper {
    public $conn;
    public $dbname="fps";
    public $username="root";
    public $password="0540744hb";
    public $host="localhost";

    public function __construct(){

        $this->conn=mysql_connect($this->host,$this->username,$this->password);
        if(!$this->conn){
            die("连接失败".mysql_error());
        }
        mysql_query("set names 'utf8'");//写库
        mysql_select_db($this->dbname,$this->conn);
    }

    //执行dql语句
    public function query($sql){
        $res=mysql_query($sql,$this->conn) or die(mysql_error());
        return $res;
    }

   public function insert($table,$fields,$values){
     $sql="INSERT INTO $table ($fields) VALUES ($values)";
     if ($this->query($sql)) {

       return 1;
     }
     return 0;
   }
    // 根据insert,update,delete执行结果取得影响行数
    public function db_affected_rows() {
        return mysql_affected_rows();
    }

   //执行dql语句，但是返回的是一个数组
   public function Query2Arr($sql){
     $arr=array();
     $res=mysql_query($sql,$this->conn) or die(mysql_error());

     //把$res=>$arr 把结果集内容转移到一个数组中.
     while($row=mysql_fetch_assoc($res)){
         $arr[]=$row;
     }
     //这里就可以马上把$res关闭.
     mysql_free_result($res);
     return $arr;
   }

   /*创建添加新的数据库*/
   public function create_database($database_name) {
       $database = $database_name;
       $sqlDatabase = 'create database ' . $database;
       $this->Query($sqlDatabase);
   }

  /*返回数据库版本号*/
  public function version()
  {
   return mysql_get_server_info($this->conn);
  }


    //执行dml语句
    public  function execute_dml($sql){

        $b=mysql_query($sql,$this->conn) or die(mysql_error());
        if(!$b){
            return 0; //失败
        }else{
            if(mysql_affected_rows($this->conn)>0){
                return 1;//表示执行ok
            }else{
                return 2;//表示没有行受到影响
            }
        }

    }

    //关闭连接的方法
    public function close_connect(){

        if(!empty($this->conn)){
            mysql_close($this->conn);
        }
    }
}
