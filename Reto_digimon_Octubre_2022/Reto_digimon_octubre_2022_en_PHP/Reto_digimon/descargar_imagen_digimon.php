<?php
	function descargar_imagen_digimon($digimon) 
    	{
		require("url_imagen_digimon.php");
		$url_digimon=url_imagen_digimon($digimon);
		echo ($url_digimon);
      	$ch=curl_init($url_digimon);
		//Definimos directorio local
		$dir_salvado="Digimon_imagenes/";
		// Definimos el nombre de archivo a descargar.
 		$nombre_archivo = basename($url_digimon);
 		// Definimos ruta del archivo local
 		$file_local= ($dir_salvado . $nombre_archivo);
		$fp= fopen($file_local, "wb");

		curl_setopt($ch, CURLOPT_FILE, $fp);
      	curl_setopt($ch, CURLOPT_HEADER, 0);
      	curl_exec($ch);
      	curl_close($ch);
      	fclose($fp);
   		}
?>
