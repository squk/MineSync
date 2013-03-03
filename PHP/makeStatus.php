<?php

$con = mysql_connect("localhost","MYSQLUSERNAME","MYSQLPASSWORD") or die(mysql_error());
 mysql_select_db("etwoepne_minesync") or die(mysql_error());
$status = $_GET["status"];
$username = urldecode($_GET["user"]);
//Increment counter
if($status == "ON")
{
	$query = "UPDATE users SET online=1 WHERE username='$username'";
	echo "ON";
}
else
{
	$query = "UPDATE users SET online=0 WHERE username='$username'";
	echo "OFF";
}
echo "$query";
mysql_query($query);

?>