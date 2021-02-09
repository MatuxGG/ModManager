REM VERSION 0.1

REM CustomKeybinds v1.1
REM Extra Roles v1.2.2
REM Custom Roles 1.0.0
REM Tryhard v1.3.0
REM Sheriff v1.1
REM Love Couple v1.1_2020.12.9s
REM Mayor 1.0.1
REM Torch 1.0.2
REM Sweeper 1.0.0
REM Anonymous impostor v1.3
REM Chameleon v1.0
REM Smol v1.0.3

@echo off
call :MENU 9>out1.log 8>out2.log
exit /b

:MENU
CLS
ECHO.
ECHO ...............................................
ECHO MOD MANAGER
ECHO ...............................................
ECHO 
ECHO 1 - AMONG US CLASSIC (DISABLE MODS)
ECHO 2 - CUSTOM KEYBINDS
ECHO 3 - EXTRAROLES 1 (Officer/Joker/Medic/Engineer)
ECHO 4 - EXTRAROLES 2 (Torch/Mayor/Sweeper)
ECHO 5 - TRYHARD
ECHO 6 - SHERIFF
ECHO 7 - LOVERS
ECHO 8 - MAYOR
ECHO 9 - TORCH
ECHO 10 - SWEEPER
ECHO 11 - ANONYMOUS IMPOSTORS
ECHO 12 - CHAMELEON
ECHO 13 - SMOL (Everything bigger)
ECHO 0 - EXIT
ECHO 

SET /P M=Select a mod and press ENTER:
IF %M%==1 GOTO NORMAL
IF %M%==2 GOTO KEYBINDS
IF %M%==3 GOTO EXTRAROLES
IF %M%==4 GOTO CUSTOMROLES
IF %M%==5 GOTO TRYHARD
IF %M%==6 GOTO SHERIFF
IF %M%==7 GOTO LOVERS
IF %M%==8 GOTO MAYOR
IF %M%==9 GOTO TORCH
IF %M%==10 GOTO SWEEPER
IF %M%==11 GOTO ANON
IF %M%==12 GOTO CHAMELEON
IF %M%==13 GOTO SMOL
IF %M%==0 GOTO EOF

:NORMAL
rmdir /s /q .\..\BepInEx\
rmdir /s /q .\..\mono\
rmdir /s /q .\..\Assets\
del /q .\..\doorstop_config.ini
del /q .\..\winhttp.dll
GOTO MENU

:KEYBINDS
rmdir /s /q .\..\BepInEx\
rmdir /s /q .\..\mono\
rmdir /s /q .\..\Assets\
del /q .\..\doorstop_config.ini
del /q .\..\winhttp.dll
xcopy modlist\CustomKeyBinds\ .\..\ /E/H
GOTO MENU

:EXTRAROLES
rmdir /s /q .\..\BepInEx\
rmdir /s /q .\..\mono\
rmdir /s /q .\..\Assets\
del /q .\..\doorstop_config.ini
del /q .\..\winhttp.dll
xcopy modlist\ExtraRoles\ .\..\ /E/H
GOTO MENU

:CUSTOMROLES
rmdir /s /q .\..\BepInEx\
rmdir /s /q .\..\mono\
rmdir /s /q .\..\Assets\
del /q .\..\doorstop_config.ini
del /q .\..\winhttp.dll
xcopy modlist\CustomRoles\ .\..\ /E/H
GOTO MENU

:SHERIFF
rmdir /s /q .\..\BepInEx\
rmdir /s /q .\..\mono\
rmdir /s /q .\..\Assets\
del /q .\..\doorstop_config.ini
del /q .\..\winhttp.dll
xcopy modlist\Sheriff\ .\..\ /E/H
GOTO MENU

:LOVERS
rmdir /s /q .\..\BepInEx\
rmdir /s /q .\..\mono\
rmdir /s /q .\..\Assets\
del /q .\..\doorstop_config.ini
del /q .\..\winhttp.dll
xcopy modlist\Lovers\ .\..\ /E/H
GOTO MENU

:MAYOR
rmdir /s /q .\..\BepInEx\
rmdir /s /q .\..\mono\
rmdir /s /q .\..\Assets\
del /q .\..\doorstop_config.ini
del /q .\..\winhttp.dll
xcopy modlist\Mayor\ .\..\ /E/H
GOTO MENU

:TORCH
rmdir /s /q .\..\BepInEx\
rmdir /s /q .\..\mono\
rmdir /s /q .\..\Assets\
del /q .\..\doorstop_config.ini
del /q .\..\winhttp.dll
xcopy modlist\Torch\ .\..\ /E/H
GOTO MENU

:SWEEPER
rmdir /s /q .\..\BepInEx\
rmdir /s /q .\..\mono\
rmdir /s /q .\..\Assets\
del /q .\..\doorstop_config.ini
del /q .\..\winhttp.dll
xcopy modlist\Sweeper\ .\..\ /E/H
GOTO MENU

:ANON
rmdir /s /q .\..\BepInEx\
rmdir /s /q .\..\mono\
rmdir /s /q .\..\Assets\
del /q .\..\doorstop_config.ini
del /q .\..\winhttp.dll
xcopy modlist\AnonymousImpostors\ .\..\ /E/H
GOTO MENU

:CHAMELEON
rmdir /s /q .\..\BepInEx\
rmdir /s /q .\..\mono\
rmdir /s /q .\..\Assets\
del /q .\..\doorstop_config.ini
del /q .\..\winhttp.dll
xcopy modlist\Chameleon\ .\..\ /E/H
GOTO MENU

:SMOL
rmdir /s /q .\..\BepInEx\
rmdir /s /q .\..\mono\
rmdir /s /q .\..\Assets\
del /q .\..\doorstop_config.ini
del /q .\..\winhttp.dll
xcopy modlist\Smol\ .\..\ /E/H
GOTO MENU