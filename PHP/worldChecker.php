<?php

 $con = mysql_connect("localhost","MYSQLUSERNAME","MYSQLPASSWROD") or die(mysql_error());
 mysql_select_db("etwoepne_minesync") or die(mysql_error());
 
$username = urldecode($_GET["username"]);
$worldList = urldecode($_GET["worldList"]);
$worldNames = explode(",", $worldList);
$missingWorlds = array();
$userUP = strtoupper($username);
if($worldList == "000")
{
	$query = "SELECT * FROM worlds WHERE owner='$userUP'";
}
else
{
	$query = "SELECT * FROM worlds WHERE owner='$userUP' AND NOT FIND_IN_SET(name, '$worldList')";
}
$result = mysql_query($query) or die(mysql_error());
$num = mysql_numrows($result);
while($row = mysql_fetch_assoc($result))
{
    $missingWorlds[] = $row['name'];
}

$arraySize = count($missingWorlds);
if($arraySize > 1)
{
	echo implode(",", $missingWorlds);
}
else if($arraySize == 1)
{
	echo $missingWorlds[0];
}
else
{
	echo "localDB-UTD";
}
mysql_close($con);
?>