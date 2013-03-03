<?php

/**
 * @author Christian Nieves
 * @copyright 2012
 */
 $con = mysql_connect("localhost","MYSQLUSERNAME","MYSQLPASSWORD") or die(mysql_error());
 mysql_select_db("etwoepne_minesync") or die(mysql_error());
 
$username = mysql_real_escape_string(urldecode($_GET["username"]));
$password = $_GET["password"];
$query = "SELECT username FROM users WHERE username='$username' && password='$password'";
$result = mysql_num_rows(mysql_query($query));
if(!$_GET["version"] || $_GET["version"] < 1010)
{
	exit("You must update MineSync. Visit http://www.URL.com/MineSync/download.php");
}
if ($result == 0)
{
	die('Incorrect username/password combination. Please try again.');
}
else if ($result == 1)
{
    echo md5($username . "RANDOMSTRING" . $password);
//log
/*
	$ip = $_SERVER['REMOTE_ADDR'];
    $result_id = @mysql_query($query) or die("DATABASE ERROR!");
    $total = mysql_num_rows($result_id);
    if($total)
    {
        $datas = @mysql_fetch_array($result_id);
        $realUser = $datas['username'];
        runQuery("INSERT into log (ip, username, logFrom) VALUES ('$ip', '$realUser', 'Site')");
//sign in correct
    }
    */
}
mysql_close($con);
 
 ?>