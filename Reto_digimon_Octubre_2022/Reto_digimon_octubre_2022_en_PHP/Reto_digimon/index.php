<?php
	$digimon=$_GET['digimon'];
	require("url_imagen_digimon.php");
	//$digimon=parse_str($url_components['digimon'], $params);
	//require("descargar_imagen_digimon.php");
	//$digimon="Superstarmon";
	
	$url= url_imagen_digimon($digimon);
	echo $url;
	//print_r= $url;
	//descargar_imagen_digimon($digimon);
	//echo $_GET[$digimon]
	//require("url_imagen_digimon.php");
	//$url_digimon=url_imagen_digimon($digimon);
?>

