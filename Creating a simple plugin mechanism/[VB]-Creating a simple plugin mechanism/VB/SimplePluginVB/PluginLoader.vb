'   Copyright 2014 Christoph Gattnar
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

Imports PluginContracts
Imports System.IO
Imports System.Reflection

Public Module PluginLoader

    Public Function LoadPlugins(path As String) As ICollection(Of IPlugin)
        Dim dllFileNames As String()

        If Directory.Exists(path) Then
            dllFileNames = Directory.GetFiles(path, "*.dll")

            Dim assemblies As ICollection(Of Assembly) = New List(Of Assembly)(dllFileNames.Length)
            For Each dllFile As String In dllFileNames
                Dim an As AssemblyName = AssemblyName.GetAssemblyName(dllFile)
                Dim assembly As Assembly = assembly.Load(an)
                assemblies.Add(assembly)
            Next

            Dim pluginType As Type = GetType(IPlugin)
            Dim pluginTypes As ICollection(Of Type) = New List(Of Type)
            For Each assembly As Assembly In assemblies
                If assembly <> Nothing Then
                    Dim types As Type() = assembly.GetTypes()

                    For Each type As Type In types
                        If type.IsInterface Or type.IsAbstract Then
                            Continue For
                        Else
                            If type.GetInterface(pluginType.FullName) <> Nothing Then
                                pluginTypes.Add(type)
                            End If
                        End If
                    Next
                End If
            Next

            Dim plugins As ICollection(Of IPlugin) = New List(Of IPlugin)(pluginTypes.Count)
            For Each type As Type In pluginTypes
                Dim plugin As IPlugin = Activator.CreateInstance(type)
                plugins.Add(plugin)
            Next

            Return plugins
        End If

        Return Nothing
    End Function

End Module
