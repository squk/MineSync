<?php

//Set database to counter
$con = mysql_connect("localhost","MYSQLUSERNAME","MYSQLPASSWORD") or die(mysql_error());
 mysql_select_db("etwoepne_minesync") or die(mysql_error());

//Increment counter
mysql_query("UPDATE stats SET downloads=downloads+1");
sleep(0.5);
header("Location: "."MineSync.zip");
?>