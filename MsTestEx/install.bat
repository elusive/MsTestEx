REM     Install Script for MsTest Extensions
REM     John Gilliland - Lead Engineer
REM     john.gilliland@rndgroup.com

REM     Copy Assemblies to the Public Assemblies directory in vs 2012
xcopy /s /y "%~dp0bin\debug\*.*" "C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\PublicAssemblies\" /k

REM     Registry Key to register new test type "TestClassEx"
reg add "HKLM\Software\Wow6432Node\Microsoft\VisualStudio\11.0\EnterpriseTools\QualityTools\TestTypes\{13cdc9d9-ddb5-4fa4-a97d-d965ccfc6d4b}\TestTypeExtensions\TestClassExAttribute"
reg add "HKLM\Software\Wow6432Node\Microsoft\VisualStudio\11.0\EnterpriseTools\QualityTools\TestTypes\{13cdc9d9-ddb5-4fa4-a97d-d965ccfc6d4b}\TestTypeExtensions\TestClassExAttribute" /v "AttributeProvider" /t REG_SZ /d "MsTestEx.TestClassExAttribute,MsTestEx" /if


