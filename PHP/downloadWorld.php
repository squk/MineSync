<?php

/**
 * @author Christian Nieves
 * @copyright 2012
 */
 $con = mysql_connect("localhost","MYSQLUSERNAME","MYSQLPASSWORD") or die(mysql_error());
 mysql_select_db("etwoepne_minesync") or die(mysql_error());
 
$username = urldecode($_GET["username"]);
$worldName = urldecode($_GET["worldName"]);
$writeTime = strtotime(urldecode($_GET["dateTime"]));
$hash = $_GET['hash'];
$user2 = strtoupper($username);
$result = mysql_query("SELECT * FROM worlds WHERE name='$worldName' AND owner='$user2'");
$num=mysql_num_rows($result);
$file = "upload/$user2/$worldName.zip";
while($row = mysql_fetch_assoc($result))
{
    $dbTime = strtotime($row['date']);
    $dbHash = $row['hash'];
}
if($num == 0)
{
	exit("Upload");
}
else if($writeTime < $dbTime && $dbHash != $hash && $num != 0)
{
	if($_GET['dl'] != 1)
	{
    //$result = mysql_query("UPDATE worlds SET date='$writeTime' hash='$hash' WHERE name='$worldName' AND owner='$username'");
		exit("!UPD");
	}
}
else
{
    exit("Up to date");
}

if($_GET['dl'] == 1)
{
		if (file_exists($file))
		{
			header('Content-Description: File Transfer');
			header('Content-Type: application/octet-stream');
			header('Content-Disposition: attachment; filename='.basename($file));
			header('Content-Transfer-Encoding: binary');
			header('Expires: 0');
			header('Cache-Control: must-revalidate');
			header('Pragma: public');
			header('Content-Length: ' . filesize($file));
			ob_clean();
			flush();
			readfile($file);
		}
		else
		{
			echo "An unknown error has occured on the server";
		}
}

 mysql_close($con);
 ///
 ?>