--[[
m_nMaxCreateNum 	= n		-- 최대 생성 몬스터 갯수
--	 아이템ID,  자동소멸시간
AddItem( strItemId, dwKeepTime )	-- dwKeepTime -> SEC( n ) or MIN( n )
--{
--		    몬스터ID,	  생성확률
	AddMonster( strMonsterId, nProbability )
	...
--}

-- <example>
m_nMaxCreateNum 	= 1000

AddItem( "II_CHR_SYS_SCR_CM_LV5", MIN( 60 ) )
--{
	AddMonster( "MI_AIBATT1", 15 )
	AddMonster( "MI_AIBATT2", 15 )
	AddMonster( "MI_AIBATT3", 15 )
	AddMonster( "MI_AIBATT4", 5 )
	AddMonster( "MI_MUSHPANG1", 15 )
	AddMonster( "MI_MUSHPANG2", 15 )
	AddMonster( "MI_MUSHPANG3", 15 )
	AddMonster( "MI_MUSHPANG4", 5 )
--}
--]]

-------------------------------------------------------------
-- Begin Script ---------------------------------------------
-------------------------------------------------------------
dofile( ".\\LuaFunc\\CreateMonsterFunc.lua" )
-------------------------------------------------------------
m_nMaxCreateNum = 1000

AddItem( "II_CHR_SYS_SCR_CM_LV5", MIN( 60 ) )
--{
	AddMonster( "MI_AIBATT1",	15 )
	AddMonster( "MI_AIBATT2",	15 )
	AddMonster( "MI_AIBATT3",	15 )
	AddMonster( "MI_AIBATT4",	5 )
	AddMonster( "MI_MUSHPANG1",	15 )
	AddMonster( "MI_MUSHPANG2",	15 )
	AddMonster( "MI_MUSHPANG3",	15 )
	AddMonster( "MI_MUSHPANG4",	5 )
--}

AddItem( "II_CHR_SYS_SCR_CM_LV10", MIN( 60 ) )
--{
	AddMonster( "MI_BURUDENG1",	15 )
	AddMonster( "MI_BURUDENG2",	15 )
	AddMonster( "MI_BURUDENG3",	15 )
	AddMonster( "MI_BURUDENG4",	5 )
	AddMonster( "MI_PUKEPUKE1",	15 )
	AddMonster( "MI_PUKEPUKE2",	15 )
	AddMonster( "MI_PUKEPUKE3",	15 )
	AddMonster( "MI_PUKEPUKE4",	5 )
--}

AddItem( "II_CHR_SYS_SCR_CM_LV15", MIN( 60 ) )
--{
	AddMonster( "MI_PEAKYTURTLE1",	10 )
	AddMonster( "MI_PEAKYTURTLE2",	10 )
	AddMonster( "MI_PEAKYTURTLE3",	10 )
	AddMonster( "MI_PEAKYTURTLE4",	4 )
	AddMonster( "MI_DEMIAN1",	10 )
	AddMonster( "MI_DEMIAN2",	10 )
	AddMonster( "MI_DEMIAN3",	10 )
	AddMonster( "MI_DEMIAN4",	3 )
	AddMonster( "MI_DORIDOMA1",	10 )
	AddMonster( "MI_DORIDOMA2",	10 )
	AddMonster( "MI_DORIDOMA3",	10 )
	AddMonster( "MI_DORIDOMA4",	3 )
--}

AddItem( "II_CHR_SYS_SCR_CM_LV20", MIN( 60 ) )
--{
	AddMonster( "MI_LAWOLF1",	10 )
	AddMonster( "MI_LAWOLF2",	10 )
	AddMonster( "MI_LAWOLF3",	10 )
	AddMonster( "MI_LAWOLF4",	4 )
	AddMonster( "MI_FEFERN1",	10 )
	AddMonster( "MI_FEFERN2",	10 )
	AddMonster( "MI_FEFERN3",	10 )
	AddMonster( "MI_FEFERN4",	3 )
	AddMonster( "MI_NYANGNYANG1",	10 )
	AddMonster( "MI_NYANGNYANG2",	10 )
	AddMonster( "MI_NYANGNYANG3",	10 )
	AddMonster( "MI_NYANGNYANG4",	3 )
--}

AddItem( "II_CHR_SYS_SCR_CM_LV25", MIN( 60 ) )
--{
	AddMonster( "MI_BANG1",		15 )
	AddMonster( "MI_BANG2",		15 )
	AddMonster( "MI_BANG3",		15 )
	AddMonster( "MI_BANG4",		5 )
	AddMonster( "MI_WAGSAAC1",	15 )
	AddMonster( "MI_WAGSAAC2",	15 )
	AddMonster( "MI_WAGSAAC3",	15 )
	AddMonster( "MI_WAGSAAC4",	5 )
--}

AddItem( "II_CHR_SYS_SCR_CM_LV30", MIN( 60 ) )
--{
	AddMonster( "MI_MIA1",		15 )
	AddMonster( "MI_MIA2",		15 )
	AddMonster( "MI_MIA3",		15 )
	AddMonster( "MI_MIA4",		5 )
	AddMonster( "MI_MRPUMPKIN1",	15 )
	AddMonster( "MI_MRPUMPKIN2",	15 )
	AddMonster( "MI_MRPUMPKIN3",	15 )
	AddMonster( "MI_MRPUMPKIN4",	5 )
--}

AddItem( "II_CHR_SYS_SCR_CM_LV35", MIN( 60 ) )
--{
	AddMonster( "MI_GIGGLEBOX1",	15 )
	AddMonster( "MI_GIGGLEBOX2",	15 )
	AddMonster( "MI_GIGGLEBOX3",	15 )
	AddMonster( "MI_GIGGLEBOX4",	5 )
	AddMonster( "MI_ROCKMUSCLE1",	15 )
	AddMonster( "MI_ROCKMUSCLE2",	15 )
	AddMonster( "MI_ROCKMUSCLE3",	15 )
	AddMonster( "MI_ROCKMUSCLE4",	5 )
--}

AddItem( "II_CHR_SYS_SCR_CM_LV40", MIN( 60 ) )
--{
	AddMonster( "MI_HOBO1",		15 )
	AddMonster( "MI_HOBO2",		15 )
	AddMonster( "MI_HOBO3",		15 )
	AddMonster( "MI_HOBO4",		5 )
	AddMonster( "MI_DUMBBULL1",	15 )
	AddMonster( "MI_DUMBBULL2",	15 )
	AddMonster( "MI_DUMBBULL3",	15 )
	AddMonster( "MI_DUMBBULL4",	5 )
--}

AddItem( "II_CHR_SYS_SCR_CM_LV45", MIN( 60 ) )
--{
	AddMonster( "MI_TOTEMIA1",	15 )
	AddMonster( "MI_TOTEMIA2",	15 )
	AddMonster( "MI_TOTEMIA3",	15 )
	AddMonster( "MI_TOTEMIA4",	5 )
	AddMonster( "MI_CARDPUPPET1",	15 )
	AddMonster( "MI_CARDPUPPET2",	15 )
	AddMonster( "MI_CARDPUPPET3",	15 )
	AddMonster( "MI_CARDPUPPET4",	5 )
--}

AddItem( "II_CHR_SYS_SCR_CM_LV50", MIN( 60 ) )
--{
	AddMonster( "MI_TOMBSTONEBEARER1",	10 )
	AddMonster( "MI_TOMBSTONEBEARER2",	10 )
	AddMonster( "MI_TOMBSTONEBEARER3",	10 )
	AddMonster( "MI_TOMBSTONEBEARER4",	4 )
	AddMonster( "MI_BASQUE1",		10 )
	AddMonster( "MI_BASQUE2",		10 )
	AddMonster( "MI_BASQUE3",		10 )
	AddMonster( "MI_BASQUE4",		3 )
	AddMonster( "MI_PRANKSTER1",		10 )
	AddMonster( "MI_PRANKSTER2",		10 )
	AddMonster( "MI_PRANKSTER3",		10 )
	AddMonster( "MI_PRANKSTER4",		3 )
--}

AddItem( "II_CHR_SYS_SCR_CM_LV55", MIN( 60 ) )
--{
	AddMonster( "MI_WHEELEM1",	15 )
	AddMonster( "MI_WHEELEM2",	15 )
	AddMonster( "MI_WHEELEM3",	15 )
	AddMonster( "MI_WHEELEM4",	5 )
	AddMonster( "MI_LEYENA1",	15 )
	AddMonster( "MI_LEYENA2",	15 )
	AddMonster( "MI_LEYENA3",	15 )
	AddMonster( "MI_LEYENA4",	5 )
--}

AddItem( "II_CHR_SYS_SCR_CM_LV60", MIN( 60 ) )
--{
	AddMonster( "MI_STEAMWALKER1",	10 )
	AddMonster( "MI_STEAMWALKER2",	10 )
	AddMonster( "MI_STEAMWALKER3",	10 )
	AddMonster( "MI_STEAMWALKER4",	4 )
	AddMonster( "MI_STEELKNIGHT1",	10 )
	AddMonster( "MI_STEELKNIGHT2",	10 )
	AddMonster( "MI_STEELKNIGHT3",	10 )
	AddMonster( "MI_STEELKNIGHT4",	3 )
	AddMonster( "MI_NUTTYWHEEL1",	10 )
	AddMonster( "MI_NUTTYWHEEL2",	10 )
	AddMonster( "MI_NUTTYWHEEL3",	10 )
	AddMonster( "MI_NUTTYWHEEL4",	3 )
--}

AddItem( "II_CHR_SYS_SCR_CM_LV65", MIN( 60 ) )
--{
	AddMonster( "MI_DRILLER1",	15 )
	AddMonster( "MI_DRILLER2",	15 )
	AddMonster( "MI_DRILLER3",	15 )
	AddMonster( "MI_DRILLER4",	5 )
	AddMonster( "MI_VOLT1",		15 )
	AddMonster( "MI_VOLT2",		15 )
	AddMonster( "MI_VOLT3",		15 )
	AddMonster( "MI_VOLT4",		5 )
--}

AddItem( "II_CHR_SYS_SCR_CM_LV70", MIN( 60 ) )
--{
	AddMonster( "MI_ELDERGUARD1",		10 )
	AddMonster( "MI_ELDERGUARD2",		10 )
	AddMonster( "MI_ELDERGUARD3",		10 )
	AddMonster( "MI_ELDERGUARD4",		4 )
	AddMonster( "MI_GARBAGEPIDER1",		10 )
	AddMonster( "MI_GARBAGEPIDER2",		10 )
	AddMonster( "MI_GARBAGEPIDER3",		10 )
	AddMonster( "MI_GARBAGEPIDER4",		3 )
	AddMonster( "MI_CRANEMACHINERY1",	10 )
	AddMonster( "MI_CRANEMACHINERY2",	10 )
	AddMonster( "MI_CRANEMACHINERY3",	10 )
	AddMonster( "MI_CRANEMACHINERY4",	3 )
--}

AddItem( "II_CHR_SYS_SCR_CM_01", MIN( 60 ) )
--{
	AddMonster( "MI_NAUTREPY4",	25 )
	AddMonster( "MI_SYLIACA4",	25 )
	AddMonster( "MI_GREEMONG4",	25 )
	AddMonster( "MI_BOO4",		25 )
--}

AddItem( "II_CHR_SYS_SCR_CM_02", MIN( 60 ) )
--{
	AddMonster( "MI_CARRIERBOMB4",	20 )
	AddMonster( "MI_HOPPRE4",	20 )
	AddMonster( "MI_MUSHPOIE4",	20 )
	AddMonster( "MI_IREN4",		20 )
	AddMonster( "MI_WATANGKA4",	20 )
--}

AddItem( "II_CHR_SYS_SCR_CM_03", MIN( 60 ) )
--{
	AddMonster( "MI_ANTIQUERY4",	20 )
	AddMonster( "MI_LUIA4",		20 )
	AddMonster( "MI_GONGURY4",	20 )
	AddMonster( "MI_SHUHAMMA4",	20 )
	AddMonster( "MI_KERN4",		20 )
--}

AddItem( "II_CHR_SYS_SCR_CM_04", MIN( 60 ) )
--{
	AddMonster( "MI_GLAPHAN4",	20 )
	AddMonster( "MI_KIMERADON5",	20 )
	AddMonster( "MI_BEARNUCKY5",	20 )
	AddMonster( "MI_MUFFRIN6",	20 )
	AddMonster( "MI_POPCRANK5",	20 )
--}

AddItem( "II_CHR_SYS_SCR_CM_NAUTREPY", MIN( 60 ) )
--{
	AddMonster( "MI_NAUTREPY4",	100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_SYLIACA", MIN( 60 ) )
--{
	AddMonster( "MI_SYLIACA4",	100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_GREEMONG", MIN( 60 ) )
--{
	AddMonster( "MI_GREEMONG4",	100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_BOO", MIN( 60 ) )
--{
	AddMonster( "MI_BOO4",		100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_CARRIERBOMB", MIN( 60 ) )
--{
	AddMonster( "MI_CARRIERBOMB4",	100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_HOPPRE", MIN( 60 ) )
--{
	AddMonster( "MI_HOPPRE4",	100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_MUSHPOIE", MIN( 60 ) )
--{
	AddMonster( "MI_MUSHPOIE4",	100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_IREN", MIN( 60 ) )
--{
	AddMonster( "MI_IREN4",		100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_WATANGKA", MIN( 60 ) )
--{
	AddMonster( "MI_WATANGKA4",	100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_ANTIQUERY", MIN( 60 ) )
--{
	AddMonster( "MI_ANTIQUERY4",	100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_LUIA", MIN( 60 ) )
--{
	AddMonster( "MI_LUIA4",		100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_GONGURY", MIN( 60 ) )
--{
	AddMonster( "MI_GONGURY4",	100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_SHUHAMMA", MIN( 60 ) )
--{
	AddMonster( "MI_SHUHAMMA4",	100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_KERN", MIN( 60 ) )
--{
	AddMonster( "MI_KERN4",		100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_GLAPHAN", MIN( 60 ) )
--{
	AddMonster( "MI_GLAPHAN4",	100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_KIMERADON", MIN( 60 ) )
--{
	AddMonster( "MI_KIMERADON5",	100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_BEARNUCKY", MIN( 60 ) )
--{
	AddMonster( "MI_BEARNUCKY5",	100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_MUFFRIN", MIN( 60 ) )
--{
	AddMonster( "MI_MUFFRIN6",	100 )
--}

AddItem( "II_CHR_SYS_SCR_CM_POPCRANK", MIN( 60 ) )
--{
	AddMonster( "MI_POPCRANK5",	100 )
--}