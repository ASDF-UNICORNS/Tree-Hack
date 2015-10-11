<?php
	if(isset($_POST['submit']))
	{
		$get_fname = $_POST['first-name'];
		$get_lname = $_POST['last-name'];
		$get_username = $_POST['username'];
		$get_password = $_POST['password'];
		$get_password_repeated = $_POST['password-repeated'];
		
		$mysqli = new mysqli("localhost", "root", "", "treehack");
		
		$duplicate = $mysqli->query("SELECT * FROM `data` WHERE username = '$get_username'");
		
		//Check if there is registered anothe profile with the same username
		if ($duplicate->num_rows > 0) {
			echo "<script>alert('The username is taken')</script>";
			echo "<script>window.location = 'http://localhost/Danchev/TreeHack/register.html'</script>";
		}
		else if($get_username == '')
		{
			echo "<script>alert('Write username')</script>";
			echo "<script>window.location = 'http://localhost/Danchev/TreeHack/register.html'</script>";
		}
		else
		{
			//Check of the password is correct
			if($get_password == '')
			{
				echo "<script>alert('Write password')</script>";
				echo "<script>window.location = 'http://localhost/Danchev/TreeHack/register.html'</script>";
			}
			else if($get_password_repeated == '')
			{
				echo "<script>alert('Repeat the password')</script>";
				echo "<script>window.location = 'http://localhost/Danchev/TreeHack/register.html'</script>";
			}
			else if($get_password != $get_password_repeated || $get_password == '')
			{
				echo "<script>alert('The pass is incorrect')</script>";
				echo "<script>window.location = 'http://localhost/Danchev/TreeHack/register.html'</script>";
			}
			else
			{
				if($get_fname == '')
				{
					echo "<script>alert('Write your first name')</script>";
					echo "<script>window.location = 'http://localhost/Danchev/TreeHack/register.html'</script>";
				}
				else if($get_lname == '')
				{
					echo "<script>alert('Write your last name')</script>";
					echo "<script>window.location = 'http://localhost/Danchev/TreeHack/register.html'</script>";
				}
				else
				{
					$get_password = md5($get_password);
					$insert_query = "INSERT INTO `data` VALUES ('$get_fname', '$get_lname', '$get_username', '$get_password', DEFAULT, DEFAULT, DEFAULT, DEFAULT, DEFAULT, DEFAULT)";
					$mysqli->query($insert_query);
					echo "<script>alert('Your registration is done successfull')</script>";
					echo "<script>window.location = 'http://localhost/Danchev/TreeHack/register.html'</script>";
				}
			}					
		}
	}
?>