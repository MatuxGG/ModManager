--------------------------------------------------------------------------------
dofile( ".\\LuaFunc\\RainbowRaceFunc.lua" ) -- 건들지 말아요 ^^;
--------------------------------------------------------------------------------

SetTime( "Thu", "17:40", "17:45", "17:50", 1000000 )	-- 요일, 신청시작 시간, 신청종료 시간, 오픈 시간, 신청 페냐
Wait_Time	= MIN(20)			-- 준비까지 대기시간
Ready_Time	= MIN(10)			-- 준비 시간
Progress_Time	= MIN(120)			-- 진행 시간

--------------------------------------------------------------------------------
-- 진행 NPC설정
-- SetNPC( "strNPCId", "strCharKey", x, y, z ) -- strNPCId는 중복되면 안됨
-- SetNPC( "MI_NPC_SNOWGIRL", "MaFl_FlaMayor", 6963, 105, 3232 )
SetNPC( "MI_NPC_RAINBOWNPC01" ,  "MaFl_RainbowRed"    , 9460, 150, 4540 )
SetNPC( "MI_NPC_RAINBOWNPC02" ,  "MaFl_RainbowOrange" , 8314, 190, 1888 )
SetNPC( "MI_NPC_RAINBOWNPC03" ,  "MaFl_RainbowYellow" , 7197, 182, 4046 )
SetNPC( "MI_NPC_RAINBOWNPC04" ,  "MaFl_RainbowGreen"  , 6164, 152, 3787 )
SetNPC( "MI_NPC_RAINBOWNPC05" ,  "MaFl_RainbowBlue"   , 5610, 152, 3695 )
SetNPC( "MI_NPC_RAINBOWNPC06" ,  "MaFl_RainbowIndogo" , 2922, 152, 4708 )
SetNPC( "MI_NPC_RAINBOWNPC07" ,  "MaFl_RainbowViolet" , 3102, 183, 2787 )
SetNPC( "MI_MAFL_ETE", "MaFl_Ete" , 6963, 100, 3214 )
--------------------------------------------------------------------------------

-- 레인보우 레이스 요일별 순위에 따른 상품 및 상금
-- SetPrize( "요일", "ItemId", nItemNum, byFlag, nPenyaRate ) 
-- SetPrize( "Sat", "NoItem", 0, 0,      50 );
SetPrize( "Thu", "NoItem", 0, 0,      50 );
SetPrize( "Thu", "NoItem", 0, 0,      24 );
SetPrize( "Thu", "NoItem", 0, 0,      12 );
SetPrize( "Thu", "NoItem", 0, 0,       6 );
SetPrize( "Thu", "NoItem", 0, 0,       3 );
SetPrize( "Thu", "NoItem", 0, 0,     1.5 );
SetPrize( "Thu", "NoItem", 0, 0,    0.75 );
SetPrize( "Thu", "NoItem", 0, 0,   0.375 );
SetPrize( "Thu", "NoItem", 0, 0,  0.1875 );
SetPrize( "Thu", "NoItem", 0, 0, 0.09375 );

--------------------------------------------------------------------------------

-- 요일별 미니게임 완료 횟수에 따른 상품 지급
--              요일, 완료 횟수, 지급 아이템, 개수, 귀속상태 설정
-- SetMiniGamePrize( "Sat", 1, "  ", 1, 2 );
-- SetMiniGamePrize( "Sat", 2, "  ", 1, 2 );
SetMiniGamePrize( "Thu", 4, "II_GEN_MAG_TRI_FIRESHOWER"  , 1, 2 );
SetMiniGamePrize( "Thu", 5, "II_SYS_SYS_SCR_BXRAINBOW01" , 1, 2 );
SetMiniGamePrize( "Thu", 6, "II_SYS_SYS_SCR_BXRAINBOW01" , 2, 2 );
SetMiniGamePrize( "Thu", 7, "II_SYS_SYS_SCR_BXRAINBOW01" , 4, 2 );

--------------------------------------------------------------------------------