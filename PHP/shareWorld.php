<?php

/**
 * @author Christian Nieves
 * @copyright 2012
 */
 $con = mysql_connect("localhost","MYSQLUSERNAME","MYSQLPASSWORD") or die(mysql_error());
 mysql_select_db("etwoepne_minesync") or die(mysql_error());
 
$id = urldecode($_GET["id"]);

$result = mysql_query("SELECT * FROM worlds WHERE id='$id'");
$num=mysql_num_rows($result);
while($row = mysql_fetch_assoc($result))
{
	if($row["downloadable"] == 1)
	{
		$file = "upload/" . $row["owner"] . "/" . $row["name"] . ".zip";
		//echo $file;
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
			echo "This world cannot be found on the server. ";
		}
	}
	else
	{
		echo "This world is not being shared by its owner";
	}
}

?>