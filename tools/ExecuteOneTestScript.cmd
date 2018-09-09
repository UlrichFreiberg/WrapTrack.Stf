@echo off
setlocal

:: ==================================================================
:: =
:: = Command file to execute one 
:: = or more Stf tests from command line
:: =
:: = Arguments are one or more test case number separated by space
:: =
:: = Used from a cmd prompt 
:: = or from the STF Excel TCM tool.
:: =
:: = Author: Ulrich Freiberg / 2018-09-09
:: =
:: ==================================================================

SET EOTS_ResultsDirectory=C:\temp\Stf\Results

CALL :FindMsTest
CALL :FindTheWrapTestContainer
CALL :ExtendTestNameList %*
CALL :SetResultFilename
CALL :SetTestSettingsFilename
CALL :ConstructCommandLineCommand

ECHO Executing this command: 
ECHO %EOTS_Command%
ECHO.

:: Ensure the result file can be created
IF NOT EXIST "%EOTS_ResultsDirectory%" mkdir "%EOTS_ResultsDirectory%"

CALL %EOTS_Command%
echo find results here: [%EOTS_ResultsDirectory%]

goto :EOF
:: ==================================================================
:: =
:: = Script Utilities 
:: =
:: ==================================================================

:: =====================
:ExtendTestNameList
:: =====================
   REM Compose the tests to run

   SET EOTS_TestNameList=
   
   for %%I in (%*) do (
     call :ExtendTestNameListOne  %%I
   )
   goto :EOF

  
:: =====================
:ExtendTestNameListOne 
:: =====================
   CALL :GetTestNameForTestCaseNumber %1
   SET EOTS_TestNameList=%EOTS_TestNameList% /test:%TESTNAME%
   goto :EOF

:: =====================
:GetTestNameForTestCaseNumber
:: =====================
   SET TESTNUMBER=00%1
   SET TESTNAME=Tc%TESTNUMBER:~-3%
   echo %TESTNAME%
   goto :EOF

   
:: =====================
:FindMsTest
:: =====================
   SET EOTS_MsTest="C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\MSTest.exe"
   goto :EOF



:: =====================
:SetResultFilename   
:: =====================
   FOR /f %%a in ('WMIC OS GET LocalDateTime ^| find "."') DO set DTS=%%a
   set CUR_DATE=%DTS:~0,4%-%DTS:~4,2%-%DTS:~6,2%
   set CUR_TIME=%DTS:~8,6%
   SET EOTS_ResultFile=%EOTS_ResultsDirectory%\TestResult_%CUR_DATE%_%CUR_TIME%.trx   
   goto :EOF

   
:: =====================
:ConstructCommandLineCommand
:: =====================
   REM Construct the command line
   REM Refer to this link for command line parameters:
   REM http://msdn.microsoft.com/en-us/library/ms182489.aspx
   SET EOTS_Command=
   SET EOTS_Command=%EOTS_Command% %EOTS_MsTest%
   SET EOTS_Command=%EOTS_Command% /testcontainer:"%EOTS_DllContainer%" 
   SET EOTS_Command=%EOTS_Command% %EOTS_TestNameList%
   SET EOTS_Command=%EOTS_Command% /resultsfile:"%EOTS_ResultFile%" 
   SET EOTS_Command=%EOTS_Command% /usestderr 
   ::SET EOTS_Command=%EOTS_Command% /testsettings:"%EOTS_TestSettings%"
   goto :EOF
   
   
:: =====================
:FindTheWrapTestContainer
:: =====================
   SET EOTS_DllContainer=D:\Projects\WrapTrack.Stf\UnitTests\WrapTrackWebTests\bin\Debug\WrapTrackWebTests.dll
   goto :EOF


:: =====================
:SetTestSettingsFilename
:: =====================
   REM the testsettings file
   SET EOTS_TestSettings=Some File
