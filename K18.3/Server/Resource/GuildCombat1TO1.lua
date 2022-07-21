-----------------------------------------------------------------------------------------
-- Begin Script -------------------------------------------------------------------------
-----------------------------------------------------------------------------------------
-- 루아 스크립트는 "//" 대신 "--"를 사용하여 주석처리 한다.
-- 블럭 주석은 "/*, */"대신 "--[[, --]]"를 사용한다.
-----------------------------------------------------------------------------------------

-- 최소 참가 PENYA 설정
MinJoinPenya = 			110000000

-- 최소 참가 길드 레벨 설정
MinGuildLevel =			20

-- 최소 참여 길드 개수
MinJoinGuild =			2

-- 최대 전쟁을 할수 있는 길드 개수
MaxJoinGuild =			8

-- 최소 참가 인원
MinJoinPlayer = 		6

-- 최대 참가 인원
MaxJoinPlayer =			11

-- 최소 참가 레벨
MinJoinPlayerLevel =	30

-- 대전한 참가자들의 최대 생명수
PlayerLife =			1

-- 참가 취소 시 돌려주는 페냐 %
CancelReturnRate =		80

-- 입찰 실패 시 돌려주는 페냐 %
FailReturnRate =		98

-- 참가자 작성 시간(msec)
MemberLineUpTime =		3600000

-- 입장대기시간 (msec)
EntranceWaitTime = 		600000

-- 대전 시작전 대기시간(msec)
WarWaitTime = 			60000

-- 대전 시간(msec)
WarTime =			600000

-- 대전 종료 후 대기 시간(msec)
WarCloseWaitTime = 	30000

-- 대전 승리시 얻는 칩 갯수 공식
WinChipNum = MinJoinPenya * 0.9 * 0.00001 / MaxJoinPlayer

OPENTIME = {} -- 초기화(수정 금지)
-- 자동 오픈 시간 설정( 요일 순서로, index는 1부터 시작, 시간은 2자리로[예 - 07:08] )
-- 요일 순서 - Sun, Mon, Tue, Wed, Thu, Fri, Sat : 대소문자 구분함, 가장 빠른 요일이 index 1에 배정.
OPENTIME[1] = "Sat 17:00"





------------------------------------------------------------------------------
-- Function ------------------------------------------------------------------
------------------------------------------------------------------------------

-- __DBSERVER
function CheckOpenTime()
	local strNowTime = os.date("%a %H:%M")
	
	for i in pairs(OPENTIME) do
		if( OPENTIME[i] == strNowTime ) then
			return 1
		end
	end
	return 0
end

-- 남은 시간 __WORLDSERVER
function GetRemainNextTime()
	if( #OPENTIME == 0 ) then 
		return 0
	end
	
	local nNowDay = tonumber( os.date("%w") )
	local nNowHour = tonumber( os.date("%H") )
	local nNowMin = tonumber( os.date("%M") )
	local nNowSec = tonumber( os.date("%S") )
			
	for i in pairs(OPENTIME) do
		local a, b, c = GetWeekDayStrToNum( OPENTIME[i] )
		if( a > nNowDay ) then
			return ((a-nNowDay)*24*3600)+((b-nNowHour)*3600)+((c-nNowMin)*60)-nNowSec
		elseif( (a == nNowDay) and (b > nNowHour) ) then
			return ((b-nNowHour)*3600)+((c-nNowMin)*60)-nNowSec
		elseif( (a == nNowDay) and (b == nNowHour) and (c > nNowMin) ) then 
			return ((c-nNowMin)*60)-nNowSec
		elseif( (a == nNowDay) and (b == nNowHour) and (c == nNowMin) ) then 
			return nNowSec
		end
	end
	
	-- 다음이 없으면...
	local a, b, c = GetWeekDayStrToNum( OPENTIME[1] )
	
	return ((7-nNowDay+a)*24*3600)+((b-nNowHour)*3600)+((c-nNowMin)*60)-nNowSec
end

-- 요일을 수치화
function GetWeekDayStrToNum( strTime )
	local a = 0
	local nTemp1, nTemp2 = string.find(strTime, "%d%d:")
	local b = tonumber( string.sub(strTime, nTemp1, nTemp2-1) )
	nTemp1, nTemp2 = string.find(strTime, ":%d%d")
	local c = tonumber( string.sub(strTime, nTemp1+1, nTemp2) )

	local strDay = string.sub(strTime, string.find(strTime, "%a+"))
	if( strDay == "Sun" ) then a=0
	elseif( strDay == "Mon" ) then a=1
	elseif( strDay == "Tue" ) then a=2
	elseif( strDay == "Wed" ) then a=3
	elseif( strDay == "Thu" ) then a=4
	elseif( strDay == "Fri" ) then a=5
	elseif( strDay == "Sat" ) then a=6
	end
	
	return a, b, c
end
