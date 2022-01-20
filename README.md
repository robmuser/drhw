# drhw

This project creates a web app in Azure using Pulumi, the response is a hello world.
Health check script using PS

REsponse: 
Displayr
HealthCheck

PS Script
$uri = "https://app-webapphelloworld.azurewebsites.net"

try{
$res = Invoke-WebRequest -Uri $uri -UseDefaultCredentials -UseBasicParsing -Method Head -TimeoutSec 5 -ErrorAction Stop
$status = [int]$res.StatusCode

}
catch {
$status = [int]$_.Exception.Response.StatusCode.value__
}

"$status - $uri"


if ($status -eq 200){
write-Output "Healthy site"
}
else
{
write-Output  "unhealthy site - send email alert"
#$EmailFrom = "sender’s email address"                
#$EmailTo = "recipient’s email address"
            
#$EmailSubject = "unhealthy site" 
#$EmailBody = "unhealthy site." 

#$SMTPserver= "SMTP server"
#$username="your_user_name" 
#$password = "your_password" | ConvertTo-SecureString -AsPlainText -Force
#$credential = New-Object System.Management.Automation.PSCredential($username, $password)

#Send-MailMessage -ErrorAction Stop -from "$EmailFrom" -to "$EmailTo" -subject "$EmailSubject" -body "$EmailBody" -SmtpServer "$SMTPserver"  -Priority  "Normal" -Credential $credential -Port 587 -UseSsl
}
