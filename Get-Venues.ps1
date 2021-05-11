
$result = Invoke-WebRequest -Uri "https://api.openbrewerydb.org/breweries"

$breweries = $result.Content | ConvertFrom-Json


# This will duplicate data if run several times, could be solved by checking for a natual key shared across services. (i.e. name?)
$breweries | foreach { invoke-sqlcmd -ConnectionString "Server=.;Database=ChaoticConventions;Integrated Security=true" -Query "Insert into dbo.Venue ([Name], [Address]) VALUES ('$($_.name)', '$($_.country) $($_.postal_code) $($_.city) $($_.state) $($_.street)')"}