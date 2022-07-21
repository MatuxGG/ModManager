----------------------------------------------------------------------
---- 이벤트 관련 루아 함수 로딩 --------------------------------------
----------------------------------------------------------------------
dofile(".\\LuaFunc\\EventFunc.lua")

----------------------------------------------------------------------
-- 자동 공지 (각 서버군 TRANS Server 만 수정하면 돼요 ^^) ------------
----------------------------------------------------------------------
bNotice = false		-- 자동 공지 실행 여부(true or false)
Notice( "Tue 08:44", 5, 10 )	-- 자동공지시간, 공지간격(MIN), 공지 횟수
--{
	AddMessage( "안녕하세요. Flyff 입니다." )
	AddMessage( "오전 9시부터 원활한 서비스를 위한" )
	AddMessage( "정기 점검이 진행 될 예정 입니다." )
	AddMessage( "안전한 장소에서 접속 종료를 해 주시기 바랍니다." )	
--}

----------------------------------------------------------------------
---- 초기화 ----------------------------------------------------------
----------------------------------------------------------------------

-- 시간대별 아이템 드롭 가중치
tHour = { 505, 409, 324, 280, 220, 203, 202, 212,
	  227, 261, 302, 349, 571, 701, 764, 803,
	  790, 789, 754, 849, 936, 940, 919, 720 }
----------------------------------------------------------------------


----------------------------------------------------------------------------------------------------------------
----  1. AddEvent( strDesc )					-- 이벤트 추가 및 설명 등록
----  2. SetTime( strStartTime, strEndTime )	-- 해당 이벤트의 시작 시간, 종료 시간 등록(여러개 설정 가능)
----											   ( 시간 형식 -- "2007-05-03 17:53" )
----  3. SetItem( ItemId, nMax, nNum, nLevel )	-- 이벤트용 드롭 아이템, 일일 최대량, 드롭 갯수(랜덤),
----   										 	   아이템을 드롭할 몬스터의 최소 레벨 - 여러개 가능
----  4. SetExpFactor( fFactor )				-- 경험지 증가 배수
----  5. SetItemDropRate( fFactor )				-- 아이템 드롭률 증가 배수
----  6. SetPieceItemDropRate( fFactor )		-- 몬스터가 가지고 있는 낱개 아이템의 드랍률 증가 배수
----  7. SetGoldDropFactor( fFactor )			-- 페냐 드롭 배수
----  8. SetAttackPower( nAttackPower )			-- 공격력 증가
----  9. SetDefensePower( nDefensePower )		-- 방어력 증가
---- 10. SetCouponEvent( SEC(n) )				-- 쿠폰 이벤트( 접속시간 - SEC(n) 또는 MIN(n) )
---- 11. SetLevelUpGift( nLevel, "all", ItemId, nNum, byFlag ) -- 레벨업 선물( nLevel달성시 아이템 지급, "all" 부분에 특정 계정 지정 가능(예. "__bu" - 버디, "__an" - 엔젤 )
---- 12. SetCheerExpFactor( fFactor )			-- 응원 경험치 설정
---- 13. SetSpawn( TYPE, strId, nNum )			-- 스폰이벤트 : Type - ITEM 또는 MONSTER, ID, 1일 스폰량 
---- 14. SetKeepConnectEvent( nTime, strItemId, nItemNum )	-- 누적 접속 아이템 지급 이벤트( 접속시간, 아이템 ID, 아이템 개수 )
---- 15. SetRainEvent( fExpFactor, strTitle )			-- 장마이벤트(경험치 증가 배수, 비올때 추력 제목) : 15차에 추가됨
---- 16. SetSnowEvent( fExpFactor, strTitle )			-- 강설이벤트(경험치 증가 배수, 눈올때 추력 제목)
---- *** 이벤트 추가 등록시 1번부터 반복하고 3~16번은 필요에 따라 생략가능하다.
----------------------------------------------------------------------------------------------------------------
--[[ SAMPLE
AddEvent( "EVENT TEST 01" )
--{
	SetTime( "2007-06-08 14:23", "2007-06-08 16:11" )
	SetTime( "2007-06-09 14:23", "2007-06-10 00:00" )
	
	SetItem( "II_SYS_SYS_EVE_HAPPYMONEY01", 30000, 5, 15 )
	SetItem( "II_SYS_SYS_EVE_PUMPKIN01", 2000, 3, 15 )
	SetExpFactor( 2 )
	SetItemDropRate( 2 )
	SetPieceItemDropRate( 2 )
	SetGoldDropFactor( 2 )
	SetAttackPower( 150 )
	SetDefensePower( 100 )
	SetCouponEvent( MIN(120) )
	SetLevelUpGift( 15, "__bu", "II_SYS_SYS_SCR_BX_PET_LAWOLF7", 1, 2 )
	SetCheerExpFactor( 1.3 )
	SetSpawn( ITEM, "II_SYS_SYS_EVE_HAPPYMONEY01", 10000 )
	SetSpawn( MONSTER, "MI_AIBATT1", 2000 )
	SetSpawn( MONSTER, "MI_AIBATT4", 2000 )
	SetKeepConnectEvent( MIN(60), "II_SYS_SYS_SCR_BXTREASURE01", 1 )
	SetRainEvent( 2, "비가오면 경험치가 2배~!" )
	SetSnowEvent( 2, "눈이오면 경험치가 2배~!" )
--}
--]]

-------------------------------------------------------------------------
---- Begin Script -------------------------------------------------------
-------------------------------------------------------------------------
