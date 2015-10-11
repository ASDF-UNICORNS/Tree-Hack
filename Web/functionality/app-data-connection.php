<?php
	$i = 0;
	$pw = 0;
	$pf = 0;
	for(;;)
	{
		$file = fopen("D:\database.hack", "r") or die("Unable to open file!");
		$mysqli = new mysqli("localhost", "root", "", "treehack");
		
		$water = fgets($file);
		$fertilize = fgets($file);
		
		if($water != $pw || $fertilize != $pf)
		{
			$update = "UPDATE `data` SET water = $water WHERE username='nooro'";
			$update = "UPDATE `data` SET fertilizer = $fertilize WHERE username='nooro'";
			$mysqli->query($update);
		}
		
		fclose($file);
	
		sleep(1);
	}
?>