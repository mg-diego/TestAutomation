:: Move to vstest.exe folder
@echo off
cd C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\Extensions\TestPlatform


:: Execute Test by category
echo. 
echo ---Executing Testcases---
vstest.console.exe "C:\GIT\QA\TestAutomation\US.AcceptanceTests\bin\Debug\US.AcceptanceTests.dll" /Logger:trx /TestCaseFilter:"TestCategory=Story:Login"


:: Get last TRX results file
@echo off
cd C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\Extensions\TestPlatform\TestResults
FOR /F "delims=|" %%I IN ('DIR "*.*" /B /O:D') DO SET NewestFile=%%I
echo Results TRX file: %NewestFile%


:: Get last folder created
cd C:\GIT\QA\TestAutomation\US.AcceptanceTests\bin\Debug\TestResults
FOR /F "delims=" %%i IN ('dir /b /ad-h /t:c /od') DO SET NewestFolder=%%i
echo Results folder: %NewestFolder%


:: Move to TestResults folder
cd C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\Extensions\TestPlatform\TestResults


:: Copy file to TrxerConsoler
echo. 
echo ---Copying TRX file to RESULTS folder---
echo Copy to TestResults:
xcopy /s %NewestFile% "C:\GIT\QA\TestAutomation\US.AcceptanceTests\bin\Debug\TestResults\%NewestFolder%" /Y
echo Copy to TestReports:
xcopy /s %NewestFile% C:\GIT\QA\TestAutomation\TestReports /Y



:: Generate new HTML file
@echo off
cd C:\GIT\QA\TestAutomation\TestReports
echo. 
echo ---Generating HTML report---
TrxerConsole.exe %NewestFile%



:: Copy HTML report to Test Results
@echo off
setlocal
set "yourDir=C:\GIT\QA\TestAutomation\TestReports"
set "yourExt=*.html"
pushd %yourDir%
for %%a in (*.%yourExt%) DO SET htmlFile=%%a
echo. 
echo ---Copying HTML file to RESULTS folder---
echo Copy to TestResults:
xcopy /s %htmlFile% "C:\GIT\QA\TestAutomation\US.AcceptanceTests\bin\Debug\TestResults\%NewestFolder%" /Y
%SystemRoot%\explorer.exe "C:\GIT\QA\TestAutomation\US.AcceptanceTests\bin\Debug\TestResults\%NewestFolder%\"
@echo off
popd
endlocal
pause


