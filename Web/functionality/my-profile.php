<!DOCTYPE HTML>
<html>
	<head>
		<meta charset="UTF-8"/>
		<title>Tree Hack</title> 
		<link rel="icon" type="image/x-icon" href="../resources/favicon.png" />
		<link rel="stylesheet" type="text/css" href="../styles/index.css"/>
		<link rel="stylesheet" type="text/css" href="../styles/my-profile.css"/>
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
		
		<main id="main">
			<h2>Log in your profile</h2>
			<form action="my-profile.php" method="post">
				<input type="text" name="username" placeholder="Username"/> <br/>
				<input type="password" name="password" placeholder="Password"/> <br/>
				<input type="submit" name="submit" value="Log in" id="submit"/>
			</form>
		</main>
	</body>
</html>

<?php
	if(isset($_POST["submit"]))
	{
		$get_username = $_POST["username"];
		$get_password = $_POST["password"];
		
		$mysqli = new mysqli("localhost", "root", "", "treehack");
		$rows = $mysqli->query("SELECT * FROM `data`");
		
		while($row = $rows->fetch_assoc())
		{
			if($get_username == $row["username"])
			{
				if($row["password"] == md5($get_password))
				{
					echo "<script> document.getElementById('main').innerHTML = ''</script>";
					echo "<main id='new-main'>"; 
					echo "<h2>Hi, " . $row["username"] . " :) </h2> <br/>";
					echo "<h2 style='color: blue;'>Full Statistics</h2> <br/> <br/> <br/> <br/> <br/> <br/>";
					echo "<section id='stats' style='border-radius: 50px; background-color: lightblue; padding: 5px; color: green;'>";
					echo "Username: " . $row["username"] . " | ";
					echo "First name: " . $row["first-name"] .  " | ";
					echo "Last name: " . $row["last-name"] . "<br/><br/>";
					echo "Score: " . $row["score"] . " | ";
					echo "Trees: " . $row["trees"] . "<br/>";
					echo "Water level: " . $row["water"] . " | ";
					echo "Fertilizer level: " . $row["fertilizer"] . "<br/>";
					echo "Offline from: " . $row["last-online"];
					echo "</section>";
					
					echo "</main>";
					break;
				}
				else
				{
					//echo "<script>alert('The pass is incorrect')</script>";
					echo $get_username . "   " . $row["username"];
					break;
				}
			}
			else
			{
				echo "<script>alert('The username is incorrect')</script>";
				break;
			}
		}
	}
?>