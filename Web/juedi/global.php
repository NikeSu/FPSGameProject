<?php


  include "lib/DBHelper.php";
  $db=new DBHelper();


  function JsonEncode($obj){
    $json=json_encode($obj);
    $json = @preg_replace("/\\\u([0-9a-f]{4})/ie", "iconv('UTF-16BE', 'UTF-8', pack('H4','\\1'))", $json);
    return $json;
  }
 ?>
