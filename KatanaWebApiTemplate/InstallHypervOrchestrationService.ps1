$fullpath = (Get-Item -Path ".\" -Verbose).FullName
$cred = Get-Credential -Message "This service requires domain privileges."
New-Service -Name "HypervOrchestrationService" -DisplayName "HypervOrchestrationService" -Credential $cred -StartupType Automatic -BinaryPathName $fullpath\HypervOrchestrationService.exe -Description "HypervOrchestrationService will provision VMs on a clustered HyperV host."

