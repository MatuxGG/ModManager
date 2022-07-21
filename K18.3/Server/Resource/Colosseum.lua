-----------------------------------------------------
-------------------- Function -----------------------
-----------------------------------------------------
dofile( ".\\LuaFunc\\ColosseumFunc.lua" )

-----------------------------------------------------
-------------------- Settings -----------------------
-----------------------------------------------------
StartWaitTime		=	MIN(5)
WaitAfterStage		=	SEC(30)
LowStages		=	12
HardStages		=	9

-----------------------------------------------------
-------------------- Monsters -----------------------
-----------------------------------------------------
AddMonster(MONSTER_LOW, "MI_COLOBANG_1", MIN(1), 1)
AddMonster(MONSTER_LOW, "MI_COLOWAGJAK_1", MIN(1), 2)
AddMonster(MONSTER_LOW, "MI_COLOREDMANTIS_1", MIN(1), 3)
AddMonster(MONSTER_LOW, "MI_COLOJACKTHEHAMMER_1", MIN(1), 4)
AddMonster(MONSTER_LOW, "MI_COLOBERKRO_1", MIN(1), 5)
AddMonster(MONSTER_LOW, "MI_COLOHOWBOW_1", MIN(1), 6)
AddMonster(MONSTER_LOW, "MI_COLOSTIMEWORK_1", MIN(1), 7)
AddMonster(MONSTER_LOW, "MI_COLOGRIMONG_1", MIN(1), 8)
AddMonster(MONSTER_LOW, "MI_COLOGRREUNG_1", MIN(2), 9)
AddMonster(MONSTER_LOW, "MI_COLOLUIA_1", MIN(3), 10)
AddMonster(MONSTER_LOW, "MI_COLOGONGRI_1", MIN(3), 11)
AddMonster(MONSTER_LOW_BOSS, "MI_COLOKEREUN_1", MIN(10), 12)

AddMonster(MONSTER_HARD, "MI_COLOBIGFOOT_1", MIN(30), 1)
AddMonster(MONSTER_HARD, "MI_COLOLYCANOS_1", MIN(30), 2)
AddMonster(MONSTER_HARD, "MI_COLOLUCIFER_1", MIN(41), 3)
AddMonster(MONSTER_HARD, "MI_COLOSOULVAMPAIN_1", MIN(27), 4)
AddMonster(MONSTER_HARD, "MI_COLOTUTTLEKING_1", MIN(9), 5)
AddMonster(MONSTER_HARD, "MI_COLOSKELGENERAL_1", MIN(38), 6)
AddMonster(MONSTER_HARD, "MI_COLOSKELDEVIL_1", MIN(41), 7)
AddMonster(MONSTER_HARD, "MI_COLORYCANBARGA_1", MIN(120), 8)
AddMonster(MONSTER_LOW_HARD, "MI_COLOANGRYBEHEMOTH_1", MIN(120), 9)