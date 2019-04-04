<#
  This training material was created by Loftysoft, Sweden.
  For inquiries/feedback please contact @nopman.

  INSTRUCTIONS: 
#>

$contextFile = 'context.json'
if (Get-Item $contextFile) {
  Import-AzContext -Path $contextFile
}
else {
  Connect-AzAccount
  Save-AzContext -Path $contextFile
}

# List your Azure Subscriptions.
<#
Get-AzSubscription | Format-Table Name,Id
#>
#$subscriptionName = '{your subscription name}'
Select-AzSubscription -Subscription $subscriptionName
Save-AzContext -Path $contextFile -Force

Write-Host "Welcome to Azure $((Get-AzContext).Account.Id)! You are signed in using the subscription '$((Get-AzContext).Subscription.Name)'." -ForegroundColor Yellow