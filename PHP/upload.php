<?php

/**
 * @author Christian Nieves
 * @copyright 2012
 */
 
 $con = mysql_connect("localhost","MYSQLUSERNAME","MYSQLPASSWORD") or die(mysql_error());
 mysql_select_db("etwoepne_minesync") or die(mysql_error());
 
$user1 = $_GET['user'];
$fileHash = $_GET['hash'];
$fileName = mysql_real_escape_string(urldecode($_GET['fileName']));
$date = urldecode($_GET['date']);
$user = urldecode($user1);
$userUP = strtoupper($user);
$file = file_get_contents('php://input');
file_put_contents("upload/tmp_" . $userUP . "_" . $fileName . ".zip", $file);
$tmpZipHash = strtoupper(hash_file("md5", "upload/tmp_" . $userUP . "_" . $fileName . ".zip"));
$tmpFullHash = strtoupper(md5($tmpZipHash . $userUP . "RANDOMSTRING"));
echo $_FILES();
if($fileHash == $tmpFullHash)
{
    if(!is_dir('upload/' . $userUP))
    {
        mkdir('upload/' . $userUP);
    }
	file_put_contents("upload/" . $userUP . "/" . $fileName . ".zip", $file);
    $filesize = format_bytes(filesize("upload/" . $userUP . "/" . $fileName . ".zip"));

    $result = mysql_query("UPDATE worlds SET size='$filesize', date='$date', hash='$tmpFullHash' WHERE name='$fileName' AND owner='$userUP';");
    
    if(mysql_affected_rows()==0)
    {
        $result2 = mysql_query("REPLACE INTO worlds (name, owner, date, hash, size) VALUES ('$fileName','$userUP', '$date', '$tmpFullHash', '$filesize');");
    }
    echo "Done";
}
else
{
    echo "It appears as if the file attempting to be uploaded has been tampered with. ";
}

mysql_close($con);

function format_bytes($a_bytes)
{
    if ($a_bytes < 1024) {
        return $a_bytes .' B';
    } elseif ($a_bytes < 1048576) {
        return round($a_bytes / 1024, 2) .' KiB';
    } elseif ($a_bytes < 1073741824) {
        return round($a_bytes / 1048576, 2) . ' MiB';
    } elseif ($a_bytes < 1099511627776) {
        return round($a_bytes / 1073741824, 2) . ' GiB';
    } elseif ($a_bytes < 1125899906842624) {
        return round($a_bytes / 1099511627776, 2) .' TiB';
    } elseif ($a_bytes < 1152921504606846976) {
        return round($a_bytes / 1125899906842624, 2) .' PiB';
    } elseif ($a_bytes < 1180591620717411303424) {
        return round($a_bytes / 1152921504606846976, 2) .' EiB';
    } elseif ($a_bytes < 1208925819614629174706176) {
        return round($a_bytes / 1180591620717411303424, 2) .' ZiB';
    } else {
        return round($a_bytes / 1208925819614629174706176, 2) .' YiB';
    }
}
//file_put_contents("upload/" . $user . "/" . $fileName, $file);

/*/$file = '/' . $_POST['user'] . '/.zip';
// get the absolute path to $file
$path = pathinfo(realpath($file), PATHINFO_DIRNAME);

$zip = new ZipArchive;
$res = $zip->open($file);
if ($res === TRUE)
{
    // extract it to the path we determined above
    $zip->extractTo($path);
    $zip->close();
    echo "WOOT! $file extracted to $path";
}

else
{
    echo "Doh! I couldn't open $file";
}
*/
?>