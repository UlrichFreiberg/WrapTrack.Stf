@echo off
setlocal

set SMG_ROOT=%~dp0

pushd "%SMG_ROOT%"
echo Cleaning up at %CD%

echo.
echo Killing Selenium ChromeDrivers
taskkill /F /IM chromedriver.exe 2> nul:

echo Killing Selenium IEDriverServer
taskkill /F /IM IEDriverServer 2> nul:

echo.
echo Cleaning up the repository
call "%SMG_ROOT%build\clean.cmd"

popd
