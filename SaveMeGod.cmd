@echo off
setlocal

echo Killing Selenium ChromeDrivers
taskkill /F /IM chromedriver.exe

echo Killing Selenium ChromeDrivers
taskkill /F /IM IEDriverServer

echo Cleaning up the repository
call %~dp0build\clean.cmd
