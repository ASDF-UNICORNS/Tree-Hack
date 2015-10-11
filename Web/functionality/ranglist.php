<!DOCTYPE HTML>
<html>
	<head>
		<meta charset="UTF-8"/>
		<title>Tree Hack</title> 
		<link rel="icon" type="image/x-icon" href="../resources/favicon.png" />
		<link rel="stylesheet" type="text/css" href="../styles/index.css"/>
		<link rel="stylesheet" type="text/css" href="../styles/ranglist.css"/>
	</head>
	
	<body>
		<header>
			<img src="../resources/logo.gif" id="logo"/> 
			<nav>
				<ul>
					<li>
						<a href="../index.html">Home</a>	
					</li>
					<li>
						<a href="my-profile.php">My Profile</a>
					</li>
					<li>
						<a href="ranglist.php">Ranglist</a>
					</li>
					<li>
						<a href="donate.php">Donate</a>
					</li>
					<li>
						<a href="../register.html">Registration</a>
					</li>
				</ul>
			</nav>
			</br>
			<h1>Tree Hack</h1>
		</header>
		
		<main>

<?php
	$mysqli = new mysqli("localhost", "root", "", "treehack");
	$rows = $mysqli->query("SELECT * FROM `data` ORDER BY `score` DESC");

	if ($rows->num_rows > 0) {
		echo "<h2 style='text-align: center; font-size: 35px; color: green;'>Ranglist</h2>";
		echo "<table>";
		echo "<tr style='background-color: rgb(100, 100, 100;'>";
		echo "<th>№</th>";
		echo "<th>Username</th>";
		echo "<th>First Name</th>";
		echo "<th>Last Name</th>";
		echo "<th>Score</th>";
		echo "<th style='background-color: orange;'>Trees</th>";
		
		$i = 1;
		while($row = $rows->fetch_assoc()) {
			if($i % 2 == 0)
			{
				echo "<tr style='background-color: lightblue;'>";
			}
			else
			{
				echo "<tr style='background-color: rgb(152, 206, 264);'>";
			}
			
				echo "<td>" . $i . "</td>";
				echo "<td>" . $row["username"] . "</td>";
				echo "<td>" . $row["first-name"] . "</td>";
				echo "<td>" . $row["last-name"] . "</td>";
				echo "<td>" . $row["score"] . "</td>";
				echo "<td style='background-color: yellow; font-weight: bold; font-size: 25px; color: red;'>" . $row["trees"] . "</td>";
			echo "</tr>";
			$i++;
		}
	}
?>

		</main>

	</body>
</html>