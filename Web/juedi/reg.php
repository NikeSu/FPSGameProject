<?php
header("Content-type:text/html;charset=utf-8");

  require_once("global.php");



$username="";
if(isset($_GET["username"])){
  $username=$_GET["username"];
}
$password="";
if(isset($_GET["password"])){
  $password=$_GET["password"];
}
$u=new User();
if($username=="" || $password==""){
  $u->success=false;
  $u->username=$username;
  $u->message="账户或密码不能为空!";
  exit(JsonEncode($u));
}


//检测此用户是不存在
$sql="select * from account where acc_user='".$username."'";
$row=$db->Query2Arr($sql);


if(count($row)==0){
  if($db->insert("account","acc_user,acc_pwd","'".$username."','".$password."'")){
    $u->success=true;
    $u->username=$username;
    $u->id=mysql_insert_id();
    $u->message="用户添加成功";
    exit(JsonEncode($u));
  }
}else{
  $u->success=false;
  $u->username=$username;
  $u->message="此用户已经存在!";
  exit(JsonEncode($u));
}

class User{
  public $success=false;
  public $id=-1;
  public $username="";
  public $message="";
}

 ?>
