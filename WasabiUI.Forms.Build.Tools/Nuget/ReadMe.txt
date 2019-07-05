WasabiUI.Forms.Build.Tools
============================
Welcome to WasabiUI.Forms.Build.Tools (WCC for short), a preprocessor adding conditional compilation support to XAML files.

Much of this library is based on Xcc https://github.com/firstfloorsoftware/xcc from First Floor Software.

A sample app is also available at https://github.com/pcbender/wasabi-ui.

Overview
============================
A Xamarin Forms app will commonly share common code with platform specific projects.  

<Project DefaultTargets="Build" ToolsVersion="4.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003" InitialTargets="SetWccDefinitions">
  <Target Name="SetWccDefinitions">
    <VariableConstants TaskAction="Set" Value="__ANDROID__;__USE_CC__" />
  </Target>
  <PropertyGroup>
    <XccRemoveIgnorableContent>True</XccRemoveIgnorableContent>
    ...

See https://github.com/firstfloorsoftware/xcc/wiki for instructions
