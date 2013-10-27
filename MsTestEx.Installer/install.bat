REM     Install Script for MsTest Extensions

REM     Copy Assemblies to the Public Assemblies directory in vs 2012
xcopy /s/k/y .\bin\debug\MsTextEx.dll C:\"Program Files (x86)"\"Microsoft Visual Studio 11.0"\Common7\IDE\PublicAssemblies

REM     Registry Key to register new test type "TestClassEx"
reg add "HKLM\Software\Wow6432Node\Microsoft\VisualStudio\11.0\EnterpriseTools\QualityTools\TestTypes\{13cdc9d9-ddb5-4fa4-a97d-d965ccfc6d4b}\TestTypeExtensions\TestClassExAttribute"
reg add "HKLM\Software\Wow6432Node\Microsoft\VisualStudio\11.0\EnterpriseTools\QualityTools\TestTypes\{13cdc9d9-ddb5-4fa4-a97d-d965ccfc6d4b}\TestTypeExtensions\TestClassExAttribute" /v "AttributeProvider" /t REG_SZ /d "MsTestEx.TestClassExAttribute,MsTestEx" /if


