--------------------------------------------------------------------
-- Dungeons --------------------------------------------------------
--------------------------------------------------------------------
dofile( ".\\LuaFunc\\InstanceDungeonBase.lua" )
--------------------------------------------------------------------
--[[
AddDungeon( "WI_DUNGEON_SECRET_L" )
--{	
	SetClass( dwClass )
	SetLevel( nMinLevel, nMaxLevel )
	SetCoolTime( dwCoolTime )
	SetMonster( nType, strMonsterId, bRed, x, y, z )
			:
			:
	SetTeleportPos( nType, x, y, z )
			:
			:
--}
--]]

--[[
-- Sample
AddDungeon( "WI_DUNGEON_FL_MAS" )
--{
	SetClass( CLASS_NORMAL, CLASS_MASTER, CLASS_HERO )
	SetLevel( 80, 120 )
	SetCoolTime( MIN(1) )
	SetTeleportPos( ID_NORMAL, 695, 90, 684 ) -- If not defined, it moves to the coordinate set in the map.
	SetTeleportPos( ID_MIDBOSS, 695, 90, 684 )
	SetTeleportPos( ID_BOSS, 695, 100, 684 )
	SetMonster( ID_NORMAL, "MI_CAITSITH04_1", false, 695, 90, 684 )
	SetMonster( ID_NORMAL, "MI_CAITSITH04_1", false, 695, 90, 684 )
	SetMonster( ID_NORMAL, "MI_CAITSITH04_1", false, 695, 90, 684 )
	SetMonster( ID_MIDBOSS, "MI_AIBATT1", false, 695, 90, 684 )
	SetMonster( ID_BOSS, "MI_AIBATT1", true, 695, 100, 684 )
--}
--]]

AddDungeon( "WI_INSTANCE_OMINOUS" )
--{
	SetClass( CLASS_NORMAL, CLASS_MASTER, CLASS_HERO, CLASS_LEGEND_HERO )
	SetLevel( 80, 300 )
	SetCoolTime( MIN(120) )
	SetMonster( ID_NORMAL, "MI_PRICKANT04", true, 1280, 101, 1640 )
	SetMonster( ID_NORMAL, "MI_MAULMOUSE04", true, 1234, 101, 1393 )
	SetMonster( ID_NORMAL, "MI_CRIPESCENTIPEDE04", true, 1089, 101, 1590 )
	SetMonster( ID_MIDBOSS, "MI_LYCANOS01", true, 1078, 101, 1359 )
	SetMonster( ID_BOSS, "MI_VEMPAIN01", true, 1079, 101, 1457 )
--}

AddDungeon( "WI_INSTANCE_OMINOUS_1" )
--{
	SetClass( CLASS_MASTER, CLASS_HERO, CLASS_LEGEND_HERO )
	SetLevel( 1, 300 )
	SetCoolTime( MIN(120) )
	SetMonster( ID_NORMAL, "MI_PRICKANT04_1", true, 1280, 101, 1640 )
	SetMonster( ID_NORMAL, "MI_MAULMOUSE04_1", true, 1234, 101, 1393 )
	SetMonster( ID_NORMAL, "MI_CRIPESCENTIPEDE04_1", true, 1089, 101, 1590 )
	SetMonster( ID_MIDBOSS, "MI_LYCANOS01_1", true, 1078, 101, 1359 )
	SetMonster( ID_BOSS, "MI_VEMPAIN01_1", true, 1079, 101, 1457 )
--}

AddDungeon( "WI_INSTANCE_DREADFULCAVE" )
--{
	SetClass( CLASS_HERO, CLASS_LEGEND_HERO )
	SetLevel( 121, 300)
	SetCoolTime( MIN(180) )
	SetMonster( ID_MIDBOSS, "MI_DREADSTONE01", false, 928, 101, 198 )
	SetMonster( ID_MIDBOSS, "MI_DREADSTONE02", false, 1504, 101, 419 )
	SetMonster( ID_MIDBOSS, "MI_DREADSTONE03", false, 1397, 101, 893 )
	SetMonster( ID_MIDBOSS, "MI_DREADSTONE04", false, 764, 101, 867 )
	SetMonster( ID_MIDBOSS, "MI_DREADSTONE05", false, 675, 101, 560 )
	SetMonster( ID_BOSS, "MI_SKELDEVIL", true, 1809, 101, 1395 )
--}

AddDungeon( "WI_INSTANCE_RUSTIA" )
--{
	SetClass( CLASS_NORMAL, CLASS_MASTER, CLASS_HERO, CLASS_LEGEND_HERO )
	SetLevel( 60, 300 )
	SetCoolTime( MIN(60) )
	SetMonster( ID_MIDBOSS, "MI_RUSTIACRASHGATE01", false, 513, 101, 953 )
	SetMonster( ID_MIDBOSS, "MI_RUSTIACRASHGATE02", false, 889, 101, 1121 )
	SetMonster( ID_MIDBOSS, "MI_RUSTIACRASHGATE03", false, 926, 101, 850 )
	SetMonster( ID_MIDBOSS, "MI_RUSTIACRASHGATE04", false, 1247, 101, 1272 )
	SetMonster( ID_BOSS, "MI_BESIBIGFOOT01", true, 1126, 103, 1505 )
--}

AddDungeon( "WI_INSTANCE_RUSTIA_1" )
--{
	SetClass( CLASS_MASTER, CLASS_HERO, CLASS_LEGEND_HERO )
	SetLevel( 60, 300 )
	SetCoolTime( MIN(60) )
	SetMonster( ID_MIDBOSS, "MI_RUSTIACRASHGATE01", false, 513, 101, 953 )
	SetMonster( ID_MIDBOSS, "MI_RUSTIACRASHGATE02", false, 889, 101, 1121 )
	SetMonster( ID_MIDBOSS, "MI_RUSTIACRASHGATE03", false, 926, 101, 850 )
	SetMonster( ID_MIDBOSS, "MI_RUSTIACRASHGATE04", false, 1247, 101, 1272 )
	SetMonster( ID_BOSS, "MI_BESIBIGFOOT02", true, 1126, 103, 1505 )
--}

AddDungeon( "WI_INSTANCE_BEHAMAH" )
--{
	SetClass( CLASS_LEGEND_HERO )
	SetLevel( 130, 300 )
	SetCoolTime( MIN(360) )
	SetMonster( ID_MIDBOSS, "MI_BEHESTATUE01", false, 697, 100, 375 )
	SetMonster( ID_MIDBOSS, "MI_BEHESTATUE01", false, 624, 100, 494 )
	SetMonster( ID_MIDBOSS, "MI_BEHESTATUE01", false, 918, 100, 643 )
	SetMonster( ID_MIDBOSS, "MI_BEHESTATUE01", false, 898, 100, 785 )
	SetMonster( ID_MIDBOSS, "MI_BEHESTATUE01", false, 580, 100, 748 )
	SetMonster( ID_BOSS, "MI_BEHEMOTH", true, 1261, 101, 1392 )
--}

AddDungeon( "WI_INSTANCE_KALGAS" )
--{
	SetClass( CLASS_LEGEND_HERO )
	SetLevel( 135, 300 )
	SetCoolTime( MIN(360) )
	SetMonster( ID_MIDBOSS, "MI_KALGASSTELE01", false, 2807, 303, 801 )
	SetMonster( ID_MIDBOSS, "MI_KALGASSTELE02", false, 1944, 303, 355 )
	SetMonster( ID_MIDBOSS, "MI_KALGASEGG01", false, 976, 100, 192 )
	SetMonster( ID_MIDBOSS, "MI_KALGASEGG01", false, 980, 100, 209 )
	SetMonster( ID_MIDBOSS, "MI_KALGASEGG01", false, 969, 100, 190 )
	SetMonster( ID_MIDBOSS, "MI_KALGASEGG01", false, 974, 100, 213 )
	SetMonster( ID_BOSS, "MI_KALGASBOSS", true, 971, 101, 202 )
--}

AddDungeon( "WI_INSTANCE_UPRESIA" )
--{
	SetClass( CLASS_NORMAL,CLASS_MASTER, CLASS_HERO, CLASS_LEGEND_HERO )
	SetLevel( 75 , 300 )
	SetCoolTime( MIN(90) )
	SetMonster( ID_BOSS, "MI_DREAMQEEN01", true, 2151, 100, 1727 )
--}

AddDungeon( "WI_INSTANCE_UPRESIA_1" )
--{
	SetClass( CLASS_MASTER, CLASS_HERO, CLASS_LEGEND_HERO)
	SetLevel( 75 , 300 )
	SetCoolTime( MIN(90) )
	SetMonster( ID_BOSS, "MI_DREAMQEEN01_1", true, 2151, 100, 1727 )	
--}

AddDungeon( "WI_INSTANCE_HERNEOS" )
--{
	SetClass( CLASS_NORMAL,CLASS_MASTER, CLASS_HERO, CLASS_LEGEND_HERO )
	SetLevel( 90 , 300 )
	SetCoolTime( MIN(90) )
	SetMonster( ID_MIDBOSS, "MI_HERNSIREN01", true, 689, 100, 508 )
	SetMonster( ID_BOSS, "MI_HERNKRAKEN01", true, 1942, 100, 1424 )	
--}

AddDungeon( "WI_INSTANCE_HERNEOS_1" )
--{
	SetClass( CLASS_MASTER, CLASS_HERO, CLASS_LEGEND_HERO )
	SetLevel( 90 , 300 )
	SetCoolTime( MIN(90) )
	SetMonster( ID_MIDBOSS, "MI_HERNSIREN01_1", true, 689, 100, 508 )
	SetMonster( ID_BOSS, "MI_HERNKRAKEN01_1", true, 1942, 100, 1424 )
--}

AddDungeon( "WI_INSTANCE_SANPRES" )
--{
	SetClass( CLASS_NORMAL, CLASS_MASTER, CLASS_HERO, CLASS_LEGEND_HERO )
	SetLevel( 105 , 300 )
	SetCoolTime( MIN(90) )
	SetMonster( ID_MIDBOSS, "MI_SHIPHIPPOGRIPH", true, 1961, 101, 253 )
	SetMonster( ID_BOSS, "MI_SHIPHARPINEES", true, 1362, 109, 1730 )
--}

AddDungeon( "WI_INSTANCE_SANPRES_1" )
--{
	SetClass( CLASS_MASTER, CLASS_HERO, CLASS_LEGEND_HERO)
	SetLevel( 105 , 300 )
	SetCoolTime( MIN(90) )
	SetMonster( ID_MIDBOSS, "MI_SHIPHIPPOGRIPH_1", true, 1961, 101, 253 )
	SetMonster( ID_BOSS, "MI_SHIPHARPINEES_1", true, 1362, 109, 1730 )
--}

AddDungeon( "WI_INSTANCE_CONTAMINTRAILS" )
--{
	SetClass( CLASS_NORMAL, CLASS_MASTER, CLASS_HERO, CLASS_LEGEND_HERO )
	SetLevel( 121, 300 )
	SetCoolTime( MIN(0) )
	SetMonster( ID_MIDBOSS, "MI_MUSHMOOT2", true, 1723, 100, 1519 )
	SetMonster( ID_MIDBOSS, "MI_KRRR2", true, 1303, 100, 1417 )
	SetMonster( ID_BOSS, "MI_DU_METEONYKER5", true, 1573, 100, 1772 )
--}