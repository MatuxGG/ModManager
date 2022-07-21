-- Init -------------------------------------
-- tEventMonster 초기화, 함수 로딩
dofile( ".\\LuaFunc\\EventMonsterFunc.lua" ) -- 수정하지 말것!!!
---------------------------------------------
-- AddMonster( "Monster_ID", nLevel, nLootTime, fItemDropRate, bPet, bGiftBox )
-- 		"Monster_ID"	-> 몬스터 ID
-- 		nLevel			-> 캐릭터레벨 - 몬스터레벨 >= nLevel 일때 공격불가
-- 		nLootTime		-> 아이템 선점 시간(sec)
--		fItemDropRate	-> 아이템 드랍 범위(소수 가능)
-- 		bPet			-> 먹펫 습득가능 여부
-- 		bGiftBox		-> 기프트 박스 가능 여부
--
-- ** 이벤트용으로 제작된 신규 몬스터만 추가할 것!!!
--------------------------------------------------

--AddMonster( "MI_AIBATT1", 15, 0, false, false )
--AddMonster( "MI_AIBATT2", 15, 0, false, false )
AddMonster( "MI_EVENT01", 20, 3, 10, false, false )
AddMonster( "MI_EVENT02", 20, 3, 10, false, false )
AddMonster( "MI_EVENT03", 20, 3, 10, false, false )
AddMonster( "MI_EVENT04", 20, 3, 10, false, false )