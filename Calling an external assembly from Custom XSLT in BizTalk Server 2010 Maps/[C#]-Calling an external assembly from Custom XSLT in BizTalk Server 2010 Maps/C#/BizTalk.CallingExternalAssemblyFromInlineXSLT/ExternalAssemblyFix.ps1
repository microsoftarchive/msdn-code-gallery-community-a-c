$xml = New-Object XML
$xml.Load($args[0])

if (!$xml.mapsource.CustomXSLT)
{
	$newelement = $xml.CreateElement('CustomXSLT')
	$newelement.SetAttribute('XsltPath', '') 
	$newelement.SetAttribute('ExtObjXmlPath', $args[1])

	$xml.mapsource.InsertAfter($newelement, $xml.mapsource.ScriptTypePrecedence)
	$xml.Save($args[0])
}
