<?php

/**
 * @author Christian Nieves
 * @copyright 2012
 */
 ///////////
 //this php file is used to set a status for a user saying where or not theyre online. Simply for statistics
 ////////////
 $con = mysql_connect("localhost","MYSQLUSERNAME","MYSQLPASSWORD") or die(mysql_error());
 mysql_select_db("etwoepne_minesync") or die(mysql_error());
 
$username = urldecode($_GET["username"]);
$hash = $_GET['hash'];
$id = $_GET["id"];
$downloadable = $_GET["downloadable"];
$user2 = strtoupper($username);
if($_GET["type"] == 0)
{
	if($hash == strtoupper(md5("manageWorlds" . $username . "RANDOMSTRING")))
	{	
		$result = mysql_query("SELECT * FROM worlds WHERE owner='$username'");
		$num=mysql_numrows($result);
		while($row = mysql_fetch_assoc($result))
		{
			echo $row["id"] . "," . $row["name"] . "," . $row["date"] . "," . $row["downloadable"] . "\n";
		}
	}
	else
	{
		echo "A fatal error occured";
	}
}
else if($_GET["type"] == 1)
{
	if($hash = strtoupper(md5("manageWorlds" . $username . "RANDOMSTRING" . $id . $downloadable)))
	{
		if($downloadable == "enabled")
		{
			$result = mysql_query("UPDATE worlds SET downloadable=1 WHERE id='$id'");
		}	
		else
		{
			$result = mysql_query("UPDATE worlds SET downloadable=0 WHERE id='$id'");
		}
	}
	else
	{
		echo "A fatal error occured";
	}
}
else
{
	if($hash = strtoupper(md5("manageWorlds" . $username . "4Cu1JOue" . $id . "delete")))
	{
		$result = mysql_query("DELETE FROM worlds WHERE id='$id'");
		unlink("upload/" . $user2 . "/" . $_GET["wName"] . ".zip");
		echo "okay";
	}
	else
	{
		echo "A fatal error occured";
	}
}
?>