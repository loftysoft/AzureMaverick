$path = Join-Path $demosPath 'Demos & Exercises\11_Monitoring\02_LoggingAndInsights'
Test-Path $path

$resourceGroupName = '{mylogging name made up by you}'
#$resourceGroupName = 'foologging'
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
$resourceGroup = New-AzResourceGroup @params -Force

# Deploy
$templateFile = Get-Item (Join-Path $path 'azuredeploy.json')
$templateParameterFile = Get-Item (Join-Path $path 'azuredeploy.parameters.json')
$params = @{
  ResourceGroupName     = $resourceGroup.ResourceGroupName
  TemplateFile          = $templateFile.FullName
  TemplateParameterFile = $templateParameterFile
}
#Test-AzResourceGroupDeployment @params -Verbose
New-AzResourceGroupDeployment @params -Verbose -Force -Mode Complete

return

Remove-ResourceGroup $resourceGroupName