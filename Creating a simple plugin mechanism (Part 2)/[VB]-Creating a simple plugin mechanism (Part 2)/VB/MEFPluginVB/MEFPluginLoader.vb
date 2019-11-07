'   Copyright 2013 Christoph Gattnar
'
'   Licensed under the Apache License, Version 2.0 (the "License");
'   you may not use this file except in compliance with the License.
'   You may obtain a copy of the License at
'
'	   http://www.apache.org/licenses/LICENSE-2.0
'
'   Unless required by applicable law or agreed to in writing, software
'   distributed under the License is distributed on an "AS IS" BASIS,
'   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'   See the License for the specific language governing permissions and
'   limitations under the License.

Imports System.ComponentModel.Composition.Hosting
Imports PluginContracts
Imports System.ComponentModel.Composition

Public Class MEFPluginLoader

    Private _Container As CompositionContainer

    Sub New(path As String)
        Dim directoryCatalog As DirectoryCatalog = New DirectoryCatalog(path)

        'An aggregate catalog that combines multiple catalogs
        Dim catalog = New AggregateCatalog(directoryCatalog)

        'Create the CompositionContainer with all parts in the catalog (links Exports and Imports)
        _Container = New CompositionContainer(catalog)

        'Fill the imports of this object
        _Container.ComposeParts(Me)
    End Sub

    <ImportMany>
    Public Property Plugins As IEnumerable(Of IPlugin)
End Class
