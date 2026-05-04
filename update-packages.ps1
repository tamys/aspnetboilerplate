#!/usr/bin/env pwsh
# Script to update all NuGet packages to latest versions for .NET 10

Write-Host "Starting NuGet package updates for .NET 10..." -ForegroundColor Green

# Get all csproj files
$projects = Get-ChildItem -Path . -Recurse -Filter "*.csproj" | Where-Object { $_.FullName -notlike "*\obj\*" -and $_.FullName -notlike "*\bin\*" }

Write-Host "Found $($projects.Count) projects to update" -ForegroundColor Cyan

$failedProjects = @()
$successCount = 0

foreach ($project in $projects) {
    Write-Host "`nProcessing: $($project.Name)" -ForegroundColor Yellow
    
    try {
        # Update all packages to latest versions
        $output = dotnet list $project.FullName package --outdated 2>&1
        
        if ($output -match "Top-level Package") {
            Write-Host "  Updating packages..." -ForegroundColor Cyan
            
            # Get outdated packages
            $packagesOutput = dotnet list $project.FullName package --outdated --format json 2>&1 | ConvertFrom-Json
            
            if ($packagesOutput.projects) {
                foreach ($proj in $packagesOutput.projects) {
                    foreach ($framework in $proj.frameworks) {
                        foreach ($package in $framework.topLevelPackages) {
                            if ($package.latestVersion) {
                                Write-Host "    Updating $($package.id) to $($package.latestVersion)" -ForegroundColor Gray
                                dotnet add $project.FullName package $package.id --version $package.latestVersion 2>&1 | Out-Null
                            }
                        }
                    }
                }
            }
            
            $successCount++
        } else {
            Write-Host "  No updates needed" -ForegroundColor Green
            $successCount++
        }
    }
    catch {
        Write-Host "  ERROR: $($_.Exception.Message)" -ForegroundColor Red
        $failedProjects += $project.Name
    }
}

Write-Host "`n========================================" -ForegroundColor Green
Write-Host "Update Summary:" -ForegroundColor Green
Write-Host "  Successful: $successCount" -ForegroundColor Green
Write-Host "  Failed: $($failedProjects.Count)" -ForegroundColor $(if ($failedProjects.Count -gt 0) { "Red" } else { "Green" })

if ($failedProjects.Count -gt 0) {
    Write-Host "`nFailed projects:" -ForegroundColor Red
    $failedProjects | ForEach-Object { Write-Host "  - $_" -ForegroundColor Red }
}

Write-Host "`nPackage update complete!" -ForegroundColor Green
