<?php
// Check for empty fields
if(empty($_POST['name']) || empty($_POST['email']) || empty($_POST['message']) || !filter_var($_POST['email'],FILTER_VALIDATE_EMAIL)){
	echo "No arguments Provided!";
	return false;
}

// $name = $_POST['name'];
// $email_address = $_POST['email'];
// $message = $_POST['message'];

// Create the email and send the message
// $to = 'me_bauza@hotmail.com'; // Add your email address inbetween the '' replacing yourname@yourdomain.com - This is where the form will send a message to.
// $email_subject = "Formulario de contacto:  $name";
// $email_body = "Recibiste un mensaje desde el formulario de contacto de emiral.com.ar.\n\n"."Detalles del mensaje:\n\nName: $name\n\nEmail: $email_address\n\nMessage:\n$message";
// $headers = "De: noreply@yourdomain.com\n"; // This is the email address the generated message will be from. We recommend using something like noreply@yourdomain.com.
// $headers .= "Responder a: $email_address";	
// mail($to,$email_subject,$email_body,$headers);

$name = $_POST['name'];
$email_address = $_POST['email'];
$message = $_POST['message'];

include("Mail.php"); # Archivo interno del servidor
$recipients = "contacto@cedeira.com.ar"; # $_POST["para"]; # "contacto@emiral.com.ar"; # Mail del receptor del correo
$headers["From"] = "contacto@cedeira.com.ar"; # Cuenta de correo valida del dominio
$headers["To"] = "contacto@cedeira.com.ar"; # $_POST["para"]; # "contacto@emiral.com.ar"; # Destinatario del correo
$headers["Subject"] = "Formulario de contacto:  $name"; # Asunto de mail
$mailbody = "Recibiste un mensaje desde el formulario de contacto de cedeira.com.\n\n"."Detalles del mensaje:\n\nName: $name\n\nEmail: $email_address\n\nMessage:\n$message"; # Cuerpo del mail
$smtpinfo["host"] = "mail.cedeira.com.ar"; # Servidor SMTP
$smtpinfo["port"] = "25";
$smtpinfo["auth"] = true;
$smtpinfo["username"] = "contacto@cedeira.com.ar"; # Cuenta de correo para autentificar
$smtpinfo["password"] = "123QWEasdZXC"; # Clave de la cuenta de correo
$mail_object =& Mail::factory("smtp", $smtpinfo);
$mail_object->send($recipients, $headers, $mailbody);
echo "el correo fue enviado..";

return true;			
?>