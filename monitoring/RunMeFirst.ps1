<#
  This training material was created by Loftysoft, Sweden.
  For inquiries/feedback please contact @nopman.

  INSTRUCTIONS:
#>

#$path = 'C:\code\AzureWizardPublic'
$path = (Get-Item .).FullName
$path = 'c:\yourpath\' # Where are you working?

$contextFile = Join-Path $path 'context.json'
if (Get-Item $contextFile -ea 0) {
  Import-AzContext -Path $contextFile
}
else {
  Connect-AzAccount
  Save-AzContext -Path $contextFile
}

# List your Azure Subscriptions.
Get-AzSubscription | Format-Table Name, Id
$subscriptionName = '{your subscription name}' # Set your own subscription name here!
Select-AzSubscription -Subscription $subscriptionName
Save-AzContext -Path $contextFile -Force

Write-Host "Welcome to Azure $((Get-AzContext).Account.Id)! You are signed in using the subscription '$((Get-AzContext).Subscription.Name)'." -ForegroundColor Yellow