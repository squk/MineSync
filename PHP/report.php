<?php

$username = urldecode($_GET["username"]);
$title = urldecode($_GET["title"]);
$body = urldecode($_GET["body"]);
$type = urldecode($_GET["type"]);

if(isset($_GET["username"]) && $_GET["title"] && $_GET["body"] && $_GET["type"])
{
	mail("EMAIL ADDRESS TO NOTIFY", "MineSync - " . $title . "--" . $type, $username . "\n" . $type . "\n" . $body);
	echo "Complete";
}
else
{
	echo "incomplete";
}

?>
