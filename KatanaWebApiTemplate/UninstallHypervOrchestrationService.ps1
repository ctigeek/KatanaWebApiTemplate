Stop-Service "HypervOrchestrationService"
Start-Sleep -Seconds 3

$service = Get-WmiObject -Class Win32_Service -Filter "Name='HypervOrchestrationService'"
$service.delete()
