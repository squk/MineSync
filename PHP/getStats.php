<?php

//Set database to counter
$con = mysql_connect("localhost","etwoepne","Antman1432+") or die(mysql_error());
 mysql_select_db("etwoepne_minesync") or die(mysql_error());
//Increment counter
$result = mysql_query("SELECT * FROM stats");
while($row = mysql_fetch_assoc($result))
{
    echo "Downloads : " . $row["downloads"];
}

$result2 = mysql_query("SELECT * FROM users");
$online = 0;
while($row2 = mysql_fetch_assoc($result2))
{
    $online += intval($row2["online"]);
}
echo "<br>Users Online : " . $online . "</br>";
?>