<?
	function url_imagen_digimon($digimon) 
    	{
		//$cadena = str_replace("%20"," ",$digimon);
		//$variable = urlencode($cadena);
      	//base64_encode(string $digimon): string
    	$url = "https://www.digi-api.com/api/v1/digimon/" . $digimon;
   		$json = file_get_contents($url);
    	$obj = json_decode($json);
        //echo ($obj->images[0]->href);
		return ($obj->images[0]->href);
        }
?>


