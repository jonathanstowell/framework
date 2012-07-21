@echo Setting environment for using Windows SDK Tools.

@ECHO OFF

IF "%WindowsSdkVersion%"=="" (
  CALL :SetWindowsSdkVersionHelper HKCU > nul 2>&1
  IF ERRORLEVEL 1 CALL :SetWindowsSdkVersionHelper HKLM > nul 2>&1
  IF ERRORLEVEL 1 GOTO ERROR_NOWSDK
)

CALL :SetWindowsSdkPathHelper > nul 2>&1
IF ERRORLEVEL 1 GOTO ERROR_NOWSDK
GOTO END

:SetWindowsSdkPathHelper
SET WindowsSdkPath=
FOR /F "tokens=1,2*" %%i in ('REG QUERY "HKLM\SOFTWARE\Microsoft\Microsoft SDKs\Windows\%WindowsSdkVersion%" /V InstallationFolder') DO (
    IF "%%i"=="InstallationFolder" (
        SET "WindowsSdkPath=%%k"
    )
)
IF "%WindowsSdkPath%"=="" EXIT /B 1
EXIT /B 0

:SetWindowsSdkVersion
CALL :GetWindowsSdkVersionHelper HKCU > nul 2>&1
IF ERRORLEVEL 1 CALL :GetWindowsSdkVersionHelper HKLM > nul 2>&1
IF ERRORLEVEL 1 EXIT /B 1
EXIT /B 0

:SetWindowsSdkVersionHelper
SET WindowsSdkVersion=
FOR /F "tokens=1,2*" %%i in ('REG QUERY "%1\SOFTWARE\Microsoft\Microsoft SDKs\Windows" /V "CurrentVersion"') DO (
    IF "%%i"=="CurrentVersion" (
        SET "WindowsSdkVersion=%%k"
    )
)
IF "%WindowsSdkVersion%"=="" EXIT /B 1
EXIT /B 0

:ERROR_NOWSDK
ECHO The Windows SDK %WindowsSdkVersion% could not be found.
EXIT /B 1

:END

call "%WindowsSdkPath%\bin\Setenv.cmd" /Release /x86 /xp

set Drive=C
set ProjectHollywoodWeb=%Drive%:\inetpub\wwwroot\ProjectHollywood
set ProjectHollywoodBus=%Drive%:\Program Files (x86)\ThreeBytes\ThreeBytes.ProjectHollywood.ServiceHost
set UserBus=%Drive%:\Program Files (x86)\ThreeBytes\ThreeBytes.User.ServiceHost
set EmailBus=%Drive%:\Program Files (x86)\ThreeBytes\ThreeBytes.Email.ServiceHost
set LoggingBus=%Drive%:\Program Files (x86)\ThreeBytes\ThreeBytes.Logging.ServiceHost
set ProjectHollywoodJobHost=%Drive%:\Program Files (x86)\ThreeBytes\ThreeBytes.ProjectHollywood.JobHost
set UserJobHost=%Drive%:\Program Files (x86)\ThreeBytes\ThreeBytes.User.JobHost
set EmailJobHost=%Drive%:\Program Files (x86)\ThreeBytes\ThreeBytes.Email.JobHost
set LoggingJobHost=%Drive%:\Program Files (x86)\ThreeBytes\ThreeBytes.Logging.JobHost

@echo off
echo.
echo Please Check Deployment Locations:
echo.
echo Drive: %Drive%
echo ProjectHollywoodWeb: %ProjectHollywoodWeb%
echo ProjectHollywoodBus: %ProjectHollywoodBus%
echo UserBus: %UserBus%
echo EmailBus: %EmailBus%
echo LoggingBus: %LoggingBus%
echo ProjectHollywoodJobHost: %ProjectHollywoodJobHost%
echo UserJobHost: %UserJobHost%
echo EmailJobHost: %EmailJobHost%
echo LoggingJobHost: %LoggingJobHost%
echo.
pause

echo Stopping IIS instance...
%windir%\system32\inetsrv\appcmd.exe stop sites "ProjectHollywood"
%windir%\system32\inetsrv\appcmd.exe stop apppool "ProjectHollywood"

echo Uninstalling ThreeBytes.ProjectHollywood.ServiceHost...
"%ProjectHollywoodBus%\NServiceBus.Host.exe" /uninstall /serviceName:"ThreeBytes.ProjectHollywood.ServiceHost"

echo Uninstalling ThreeBytes.User.ServiceHost...
"%UserBus%\NServiceBus.Host.exe" /uninstall /serviceName:"ThreeBytes.User.ServiceHost"

echo Uninstalling ThreeBytes.Email.ServiceHost...
"%EmailBus%\NServiceBus.Host.exe" /uninstall /serviceName:"ThreeBytes.Email.ServiceHost"

echo Uninstalling ThreeBytes.ProjectHollywood.JobHost...
"%ProjectHollywoodJobHost%\ThreeBytes.ProjectHollywood.JobHost.exe" uninstall

echo Uninstalling ThreeBytes.User.JobHost...
"%UserJobHost%\ThreeBytes.User.JobHost.exe" uninstall

echo Uninstalling ThreeBytes.Email.JobHost...
"%EmailJobHost%\ThreeBytes.Email.JobHost.exe" uninstall

rmdir /s /q "%ProjectHollywoodWeb%"
mkdir "%ProjectHollywoodWeb%"

rmdir /s /q "%ProjectHollywoodBus%"
mkdir "%ProjectHollywoodBus%"

rmdir /s /q "%UserBus%"
mkdir "%UserBus%"

rmdir /s /q "%EmailBus%"
mkdir "%EmailBus%"

rmdir /s /q "%LoggingBus%"
mkdir "%LoggingBus%"

msbuild ".\packages\ThreeBytes.Deploy.msbuild" /p:Drive="%Drive%" /p:ProjectHollywoodWeb="%ProjectHollywoodWeb%" /p:ProjectHollywoodBus="%ProjectHollywoodBus%" /p:UserBus="%UserBus%" /p:EmailBus="%EmailBus%" /p:LoggingBus="%LoggingBus%"

echo Starting IIS instance...
%windir%\system32\inetsrv\appcmd.exe start sites "ProjectHollywood"
%windir%\system32\inetsrv\appcmd.exe start apppool "ProjectHollywood"

echo Installing ThreeBytes.ProjectHollywood.ServiceHost...
"%ProjectHollywoodBus%\NServiceBus.Host.exe" /install /serviceName:"ThreeBytes.ProjectHollywood.ServiceHost" /displayName:"ThreeBytes.ProjectHollywood.ServiceHost"

echo Installing ThreeBytes.User.ServiceHost...
"%UserBus%\NServiceBus.Host.exe" /install /serviceName:"ThreeBytes.User.ServiceHost" /displayName:"ThreeBytes.User.ServiceHost"

echo Installing ThreeBytes.Email.ServiceHost...
"%EmailBus%\NServiceBus.Host.exe" /install /serviceName:"ThreeBytes.Email.ServiceHost" /displayName:"ThreeBytes.Email.ServiceHost"

echo Installing ThreeBytes.ProjectHollywood.JobHost...
"%ProjectHollywoodJobHost%\ThreeBytes.ProjectHollywood.JobHost.exe" install

echo Installing ThreeBytes.User.JobHost...
"%UserJobHost%\ThreeBytes.User.JobHost.exe" install

echo Installing ThreeBytes.Email.JobHost...
"%EmailJobHost%\ThreeBytes.Email.JobHost.exe" install

echo Starting ThreeBytes.ProjectHollywood.ServiceHost...
%windir%\system32\net.exe start ThreeBytes.ProjectHollywood.ServiceHost

echo Starting ThreeBytes.User.ServiceHost...
%windir%\system32\net.exe start ThreeBytes.User.ServiceHost

echo Starting ThreeBytes.Email.ServiceHost...
%windir%\system32\net.exe start ThreeBytes.Email.ServiceHost

echo Granting IIS folder Permissions...
%windir%\system32\icacls.exe "%ProjectHollywoodWeb%\css" /grant IIS_IUSRS:(OI)(CI)F
%windir%\system32\icacls.exe "%ProjectHollywoodWeb%\js" /grant IIS_IUSRS:(OI)(CI)F
%windir%\system32\icacls.exe "%ProjectHollywoodWeb%\img\uploads" /grant IIS_IUSRS:(OI)(CI)F
%windir%\system32\icacls.exe "%ProjectHollywoodWeb%\img\uploads\temp" /grant IIS_IUSRS:(OI)(CI)F

pause