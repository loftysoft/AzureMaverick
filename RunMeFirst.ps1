<#
  This training material was created by Loftysoft, Sweden.
  For inquiries/feedback please contact @nopman.

  INSTRUCTIONS:
#>

#$path = 'C:\code\AzureWizardPublic'
$path = 'c:\yourpath\' # Where are you working?
$path = (Get-Item .).FullName

$contextFile = Join-Path $path 'context.json'
if (Get-Item $contextFile -ea 0) {
  Import-AzContext -Path $contextFile
}
else {
  Connect-AzAccount
  Save-AzContext -Path $contextFile
}

<# List your Azure Subscriptions:
Get-AzSubscription | Format-Table Name, Id
#>

$subscriptionName = '{your subscription name}' # Set your own subscription name here!
Select-AzSubscription -Subscription $subscriptionName
Save-AzContext -Path $contextFile -Force

Clear-Host
Write-Host "You are signed in and using the subscription '$((Get-AzContext).Subscription.Name)'." -ForegroundColor Yellow
Write-Host "Welcome to Azure $((Get-AzContext).Account.Id)!" -ForegroundColor Yellow