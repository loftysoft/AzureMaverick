<#
$path = (Get-Item .).FullName
#>
$exercisePath = Join-Path $path 'monitoring\01_Resources'

$resourceGroupName = '{myapp name made up by you}'
#$resourceGroupName = 'fooservice'
$locationName = 'westeurope'

# Validation: Do not pass this with errors!
if ($resourceGroupName -eq '{myapp name made up by you}') {
  Write-Error 'You need to set a value for the $resourceGroupName! It can be anything at all!'
}
if (!$Location) {
  $Location = Get-AzLocation | Where-Object -Property Location -EQ $locationName
}
# End validation.

# Create Resoruce Group
$params = @{
  Name     = $resourceGroupName
  Location = $Location.Location
}
$resourceGroup = New-AzResourceGroup @params -Verbose -Force

# Deploy
$templateFile = Get-Item (Join-Path $exercisePath 'azuredeploy.json')
$templateParameterFile = Get-Item (Join-Path $exercisePath 'azuredeploy.parameters.json')
$adminPassword = Read-Host -Prompt 'Enter a VM admin password' -AsSecureString
$params = @{
  ResourceGroupName     = $resourceGroup.ResourceGroupName
  TemplateFile          = $templateFile.FullName
  TemplateParameterFile = $templateParameterFile
  adminPassword         = $adminPassword
}
#Test-AzResourceGroupDeployment @params -Verbose
New-AzResourceGroupDeployment @params -Verbose -Force -Mode Complete

# When the deployment succeeds to got the Azure Portal to your Resource Group to ensure everything was deployed:
explorer.exe "https://portal.azure.com/#resource/subscriptions/$((Get-AzContext).Subscription.Id)/resourceGroups/$($resourceGroup.ResourceGroupName)/overview"
