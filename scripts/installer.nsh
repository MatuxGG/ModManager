!macro customInstall
  WriteRegStr HKCR "modmanager" "" "Mod Manager"
  WriteRegStr HKCR "modmanager" "URL Protocol" ""
  WriteRegStr HKCR "modmanager\\DefaultIcon" "" "$INSTDIR\\Mod Manager.exe,1"
  WriteRegStr HKCR "modmanager\\shell" "" ""
  WriteRegStr HKCR "modmanager\\shell\\open" "" ""
  WriteRegStr HKCR "modmanager\\shell\\open\\command" "" '"$INSTDIR\\Mod Manager.exe" "%1"'
!macroend

!macro customUnInstall
  DeleteRegKey HKCR "modmanager7"
!macroend