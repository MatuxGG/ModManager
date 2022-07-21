--------------------------------------------------------------------
-- 초기화 ----------------------------------------------------------
--------------------------------------------------------------------
dofile( ".\\LuaFunc\\CampusFunc.lua" )
--------------------------------------------------------------------

RecoveryTime		=	MIN(60)		-- 사제 포인트 회복 주기
RecoveryPoint		=	1		-- 회복 포인트


-- 완료해야 할 사제 퀘스트
SetQuest( "QUEST_SCE_MDRIGALTEACHER5" )


-- 접속한 사제지간에 따른 레벨별 버프
SetBuffLevel( 1, "II_TS_BUFF_POWER_LOVE01" )
SetBuffLevel( 2, "II_TS_BUFF_POWER_LOVE02" )
SetBuffLevel( 3, "II_TS_BUFF_POWER_LOVE03" )


-- 제자의 해당 레벨업 시 지급 사제 포인트
SetCampusReward( 15, 1, 1 )
SetCampusReward( 40, 1, 2 )
SetCampusReward( 60, 1, 2 )
SetCampusReward( 75, 2, 5 ) -- 졸업


