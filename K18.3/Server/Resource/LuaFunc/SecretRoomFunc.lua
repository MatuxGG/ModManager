--------------------------------------------------------------------
-- 시간 설정 관련 함수 ---------------------------------------------
--------------------------------------------------------------------
function SEC( a ) return a*1000 end
function MIN( a ) return SEC(a)*60 end
function CheckOpenTime()
	local Time = OpenTime..":00"
	if( Time == os.date("%a %H:%M:%S") ) then
		return true
	end
	return false
end

function GetNextOpenTime()
	local nNowDay = tonumber( os.date("%w") )
	local nNowHour = tonumber( os.date("%H") )
	local nNowMin = tonumber( os.date("%M") )
	local nNowSec = tonumber( os.date("%S") )
	
	local a, b, c = GetWeekDayStrToNum()
	if( a > nNowDay ) then
		return ((a-nNowDay)*24*3600)+((b-nNowHour)*3600)+((c-nNowMin)*60)-nNowSec
	elseif( (a == nNowDay) and (b > nNowHour) ) then
		return ((b-nNowHour)*3600)+((c-nNowMin)*60)-nNowSec
	elseif( (a == nNowDay) and (b == nNowHour) and (c > nNowMin) ) then 
		return ((c-nNowMin)*60)-nNowSec
	elseif( (a == nNowDay) and (b == nNowHour) and (c == nNowMin) ) then 
		return nNowSec
	else
		return ((7-nNowDay+a)*24*3600)+((b-nNowHour)*3600)+((c-nNowMin)*60)-nNowSec
	end
end

function GetWeekDayStrToNum()
	local a = 0
	local nTemp1, nTemp2 = string.find(OpenTime, "%d%d:")
	local b = tonumber( string.sub(OpenTime, nTemp1, nTemp2-1) )
	nTemp1, nTemp2 = string.find(OpenTime, ":%d%d")
	local c = tonumber( string.sub(OpenTime, nTemp1+1, nTemp2) )

	local strDay = string.sub(OpenTime, string.find(OpenTime, "%a+"))
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


--------------------------------------------------------------------
-- 몬스터 리젠 관련 함수 -------------------------------------------
--------------------------------------------------------------------
-- 함수 (수정 금지)
MONSTER_NORMAL	= 1
MONSTER_MIDBOSS = 2
MONSTER_BOSS	= 3

tMonster = {}
function AddMonster( nType, strMonsterId, nNum, bRed, x1, z1, x2, z2, y )
	nIndex = #tMonster + 1
		
	tMonster[nIndex] = {}
	tMonster[nIndex].nType = nType
	tMonster[nIndex].dwId = strMonsterId
	tMonster[nIndex].nNum = nNum
	tMonster[nIndex].bRed = bRed
	tMonster[nIndex].x1 = x1
	tMonster[nIndex].z1 = z1
	tMonster[nIndex].x2 = x2
	tMonster[nIndex].z2 = z2
	tMonster[nIndex].y = y
end
