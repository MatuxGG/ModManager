tOccupationShopItem = {}
-------------------------------------------------------------
--- 세율 변경 시간 체크 함수 --------------------------------
-------------------------------------------------------------
function CheckChangeTime( strDate )	-- strDate 는 가장 최근에 세율이 적용된 시간
	local strNowDate = os.date("%a %H:%M")
	local nNowDate = tonumber( GetNowDate() )	-- 현재 날짜 및 시간 
	local nNextDate = tonumber( GetNextDate( strDate ) ) -- 다음 적용될 날짜 및 시간 
			
	if( ChangeTaxTime == strNowDate ) then	-- ChangeTaxTime에 설정한 시간이면 변경
		return true, tostring( nNowDate )
	elseif( nNowDate >= nNextDate  ) then	-- 다음 적용할 시간이 지났으면 변경
		return true, tostring( nNowDate )	-- (ChangeTaxTime에 군주가 아직 설정되지 않은 경우)
	end
	
	return false, tostring( nNowDate )
end

function CheckPayTime()	-- 세금 지급시간
	if( PayTime == os.date("%H:%M") ) then
		return true
	end
	return false
end

function GetNowDate()
	return os.date("%Y%m%d%H%M")
end

----------------------------------------------------------------
-- 여기부터는 lua에서만 사용하는 함수 ------------------
----------------------------------------------------------------
function GetNextDate( strDate )
	local nYear = tonumber( string.sub( strDate, 1, 4 ) )
	local nMonth = tonumber( string.sub( strDate, 5, 6 ) )
	local nDay = tonumber( string.sub( strDate, 7, 8 ) )
	
	local nWDay, nHour, nMin = GetCheckTime()
	
	-- 다음 적용될 날짜를 구한다.(strDate로 부터 다음 설정 시간)
	local temp = os.date( "*t", os.time{year=nYear, month=nMonth, day=nDay, hour=nHour, min=nMin} )
	if( temp.wday >= nWDay ) then
		temp.day = temp.day + ( 7 - ( temp.wday - nWDay ) )
	elseif( temp.wday < nWDay ) then
		temp.day = temp.day + ( nWDay - temp.wday )
	end	

	return os.date( "%Y%m%d%H%M", os.time(temp) )
end

function GetCheckTime()
	local strWDay = string.sub( ChangeTaxTime, 1, 3 )
	local nHour = string.sub( ChangeTaxTime, 5, 6 )
	local nMin = string.sub( ChangeTaxTime, 8, 9 )
	local nWDay = 2
	
	if( strWDay == "Sun" ) then nWDay = 1
	elseif( strWDay == "Mon" ) then nWDay = 2
	elseif( strWDay == "Tue" ) then nWDay = 3
	elseif( strWDay == "Wed" ) then nWDay = 4
	elseif( strWDay == "Thu" ) then nWDay = 5
	elseif( strWDay == "Fri" ) then nWDay = 6
	elseif( strWDay == "Sat" ) then nWDay = 7
	end
	
	return nWDay, nHour, nMin
end


function AddOccupationShopItem( strItemId )
	local nIndex = #tOccupationShopItem + 1
	
	tOccupationShopItem[nIndex] = strItemId
end
