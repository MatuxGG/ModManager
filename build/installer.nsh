!macro customInstall
  WriteRegStr HKCR "modmanager7" "" "URL:ModManager7 Protocol"
  WriteRegStr HKCR "modmanager7" "URL Protocol" ""
  WriteRegStr HKCR "modmanager7\\DefaultIcon" "" "$INSTDIR\\Mod Manager.exe,1"
  WriteRegStr HKCR "modmanager7\\shell" "" ""
  WriteRegStr HKCR "modmanager7\\shell\\open" "" ""
  WriteRegStr HKCR "modmanager7\\shell\\open\\command" "" '"$INSTDIR\\Mod Manager.exe" "%1"'
!macroend

!macro customUnInstall
  DeleteRegKey HKCR "modmanager7"
!macroend