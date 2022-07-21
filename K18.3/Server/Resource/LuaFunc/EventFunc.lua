tEvent = {}
tNotice = {}
bNotice = false

function SEC( n )
	return n*1000
end

function MIN( n )
	return n*SEC(60)
end

ITEM = 4
MONSTER = 5

-----------------------------------------------------------------------------------
function Notice( strTime, nInterval, nNoticeCount )
	tNotice.strTime = strTime
	tNotice.nInterval = nInterval
	tNotice.nNoticeCount = nNoticeCount
	tNotice.tMessage = {}
end

function AddMessage( strMessage )
	local nSize = #tNotice.tMessage + 1
	tNotice.tMessage[nSize] = strMessage
end

function IsNoticeTime()
	if( (bNotice == true) and (tNotice.nNoticeCount > 0) and (tNotice.strTime == os.date("%a %H:%M")) ) then
		tNotice.nNoticeCount = tNotice.nNoticeCount - 1
		SetNextNoticeTime()
		return true
	end
	
	return false
end

function SetNextNoticeTime()
	local nMin = tonumber( os.date( "%M" ) )
	local nHour = tonumber( os.date( "%H" ) )
	local strTemp;

	tNotice.strTime = os.date( "%a " )
	nMin = nMin + tNotice.nInterval;
	if( nMin > 59 ) then 
		nMin = 60 - nMin
		nHour = nHour + 1
	end
	strTemp = tostring( nHour )..":"
	if( nHour < 10 ) then strTemp = "0"..strTemp end
	tNotice.strTime = tNotice.strTime .. strTemp
	strTemp = tostring( nMin )
	if( nMin < 10 ) then strTemp = "0"..strTemp end
	tNotice.strTime = tNotice.strTime .. strTemp
end

function GetNoticeMessage()
	return tNotice.tMessage
end

function GetEventState()
	local tReturn = {}
	local nCount = 1
	for i in pairs(tEvent) do
		local OldState = tEvent[i].State
		for j in pairs(tEvent[i].Time) do
	    		if( tEvent[i].Time[j].nStart <= tonumber(os.date("%Y%m%d%H%M")) ) then
	    			if( tEvent[i].Time[j].nEnd > tonumber(os.date("%Y%m%d%H%M")) ) then	
	    				if( tEvent[i].State == 0 ) then
	    					tEvent[i].State = 1
	       				end
	    			else
	    				if( tEvent[i].State == 1 ) then
	    					tEvent[i].State = 0
	    				end
	    			end
	    		end
	    	end
    	
	    	if( OldState ~= tEvent[i].State ) then
	    		tReturn[nCount] = {}
	    		tReturn[nCount].nId = i
	    		tReturn[nCount].State = tEvent[i].State
	    		nCount = nCount + 1
	    	end
	end

	return tReturn
end

function SetState( nId, nState )
	if( tEvent[nId] == nil ) then
		TRACE( string.format( "Have Not Event - ID:%d", nId ) )
		ERROR( string.format( "Have Not Event - ID:%d", nId ) )
		return false;
	end
	tEvent[nId].State = nState
	TRACE( string.format( "Event - ID:%d,  Title:%s,  State:%d", nId, tEvent[nId].Desc, tEvent[nId].State ) )
	ERROR( string.format( "Event - ID:%d,  Title:%s,  State:%d", nId, tEvent[nId].Desc, tEvent[nId].State ) )
	return true;
end

function GetEventList()
	local tList = {}
	local nCount = 1
	for i in pairs(tEvent) do
		if( tEvent[i].State == 1 ) then
			tList[nCount] = i
			nCount = nCount + 1
		end
	end
	
	return tList
end

function GetAllEventList()
	local tAllList = {}
	local nCount = 1
	for i in pairs(tEvent) do
		tAllList[nCount] = {}
		tAllList[nCount].nId = i
		tAllList[nCount].strTitle = tEvent[i].Desc
		tAllList[nCount].nState = tEvent[i].State
		nCount = nCount + 1
	end
	
	return tAllList
end

function GetEventInfo( nId )
	local tEventInfo = {}
	if( tEvent[nId] == nil ) then
		tEventInfo[1] = "No EventInfo ID = "..nId
		return tEventInfo
	end
	
	local nCount = 3
	tEventInfo[1] = "Title = " .. tEvent[nId].Desc
	tEventInfo[2] = "State = " .. tEvent[nId].State
	for i in pairs(tEvent[nId].Time) do
		local strTime = tEvent[nId].Time[i].nStart .. ", " ..tEvent[nId].Time[i].nEnd
		tEventInfo[nCount] = "Time["..i.."] = " .. strTime
		nCount = nCount + 1
	end

	for i in pairs(tEvent[nId].Item) do
		local strItem = tEvent[nId].Item[i].ItemId ..", ".. tEvent[nId].Item[i].ItemMaxNum ..", ".. tEvent[nId].Item[i].ItemNum ..", ".. tEvent[nId].Item[i].nLevel
		tEventInfo[nCount]  = "Item["..i.."] = " .. strItem
		nCount = nCount + 1
	end
	
	if( tEvent[nId].fExpFactor ~= 1 ) then
		tEventInfo[nCount] = "ExpFactor = " .. tEvent[nId].fExpFactor
		nCount = nCount + 1
	end
	
	if( tEvent[nId].fItemDropRate ~= 1 ) then
		tEventInfo[nCount] = "ItemDropRate = " .. tEvent[nId].fItemDropRate
		nCount = nCount + 1
	end
	
	if( tEvent[nId].fPieceItemDropRate ~= 1 ) then
		tEventInfo[nCount] = "fPieceItemDropRate = " .. tEvent[nId].fPieceItemDropRate
		nCount = nCount + 1
	end
	
	if( tEvent[nId].fGoldDropFactor ~= 1 ) then
		tEventInfo[nCount] = "fGoldDropFactor = " .. tEvent[nId].fGoldDropFactor
		nCount = nCount + 1
	end
	
	if( tEvent[nId].nAttackPower ~= 0 ) then
		tEventInfo[nCount] = "nAttackPower = " .. tEvent[nId].nAttackPower
		nCount = nCount + 1
	end
	
	if( tEvent[nId].nDefensePower ~= 0 ) then
		tEventInfo[nCount] = "nDefensePower = " .. tEvent[nId].nDefensePower
		nCount = nCount + 1
	end
	
	if( tEvent[nId].nCouponEvent ~= 0 ) then
		if( tEvent[nId].nCouponEvent < MIN(1) ) then 
			tEventInfo[nCount] = "nCouponEventTime = " .. tEvent[nId].nCouponEvent / SEC(1) .. "Sec"
		else
			tEventInfo[nCount] = "nCouponEventTime = " .. tEvent[nId].nCouponEvent / MIN(1) .. "Min"
		end
		nCount = nCount + 1
	end
	
	for i in pairs(tEvent[nId].Gift) do
		local strGift = tEvent[nId].Gift[i].nLevel ..", ".. tEvent[nId].Gift[i].strAccount ..", ".. tEvent[nId].Gift[i].strItemId ..", ".. tEvent[nId].Gift[i].nItemNum
		tEventInfo[nCount]  = "Gift["..i.."] = " .. strGift
		nCount = nCount + 1
	end
	
	if( tEvent[nId].fCheerExpFactor ~= 1 ) then
		tEventInfo[nCount] = "fCheerExpFactor = " .. tEvent[nId].fCheerExpFactor
		nCount = nCount + 1
	end

	for i in pairs(tEvent[nId].tKeepConnectEvent) do
		local strTick = "tKeepConnectTime = " .. tEvent[nId].tKeepConnectEvent[i].nTime / MIN(1) .. "Min"
		tEventInfo[nCount]  = "tKeepConnectTime["..i.."] = " .. strTick
		nCount = nCount + 1
		local strItem = tEvent[nId].tKeepConnectEvent[i].strItemId ..", ".. tEvent[nId].tKeepConnectEvent[i].nItemNum
		tEventInfo[nCount]  = "tKeepConnectItem["..i.."] = " .. strItem
		nCount = nCount + 1
	end

	
	return tEventInfo
end

function GetDesc( nId )
	local strDesc = tEvent[nId].Desc
	
	return strDesc
end		

function GetTimeToNumber( strTime )
	local strTemp = ""
	local j = 0
	for i in string.gmatch( strTime, "%d+" ) do
		j = j + 1
		if( (j~=1) and (tonumber(i)<10) ) then
			i = "0"..tonumber(i)
		end
		strTemp = strTemp..i
	end
	return tonumber( strTemp )
end

function AddEvent( strDesc )
	local nEventId = #tEvent + 1
	
	tEvent[nEventId] = {}
	tEvent[nEventId].Item = {}
	tEvent[nEventId].Time = {}
	tEvent[nEventId].Desc = strDesc
	tEvent[nEventId].fExpFactor = 1
	tEvent[nEventId].fItemDropRate = 1
	tEvent[nEventId].fPieceItemDropRate = 1
	tEvent[nEventId].fGoldDropFactor = 1
	tEvent[nEventId].State = 0
	tEvent[nEventId].nAttackPower = 0
	tEvent[nEventId].nDefensePower = 0
	tEvent[nEventId].nCouponEvent = 0
	tEvent[nEventId].Gift = {}
	tEvent[nEventId].fCheerExpFactor = 1
	tEvent[nEventId].tSpawn = {}
	tEvent[nEventId].tKeepConnectEvent = {}
	tEvent[nEventId].fRainEventExpFactor = 1
	tEvent[nEventId].strRainEventTitle = ""
	tEvent[nEventId].fSnowEventExpFactor = 1
	tEvent[nEventId].strSnowEventTitle = ""
end

function SetTime( strStart, strEnd )
	local nEventId = #tEvent
	local nSize = #tEvent[nEventId].Time + 1
	
	tEvent[nEventId].Time[nSize] = {}
	tEvent[nEventId].Time[nSize].nStart = GetTimeToNumber( strStart )
	tEvent[nEventId].Time[nSize].nEnd = GetTimeToNumber( strEnd )
end

function SetItem( ItemId, nItemMaxNum, nItemNum, nLevel )
	local nEventId = #tEvent
	local nSize = #tEvent[nEventId].Item
	
	tEvent[nEventId].Item[nSize+1] = {}
	tEvent[nEventId].Item[nSize+1].ItemId = ItemId
	tEvent[nEventId].Item[nSize+1].ItemMaxNum = nItemMaxNum
	tEvent[nEventId].Item[nSize+1].ItemNum = nItemNum
	tEvent[nEventId].Item[nSize+1].nLevel = nLevel
	tEvent[nEventId].Item[nSize+1].TimeOut = 0
	tEvent[nEventId].Item[nSize+1].Skip = 0
	
	local tInterval = {}
	local nTotal = 0
	for i in pairs(tHour) do
		nTotal = nTotal + tHour[i]
	end
	for i in pairs(tHour) do
		tInterval[i] = 3600000 / ( nItemMaxNum * tHour[i] / nTotal )
		tInterval[i] = math.floor(tInterval[i])
	end
	tEvent[nEventId].Item[nSize+1].tInterval = tInterval
end

function GetItem( nTickCount, nLevel )
	local nHour = tonumber(os.date("%H")) + 1
	local tList = GetEventList()
	local tReturn = {}
	local nCount = 1
	for i in pairs(tList) do
		local tItem = tEvent[tList[i]].Item
		for j in pairs(tItem) do
			local nRandom = math.random(0, tItem[j].ItemNum)
			if( (nRandom > 0) and (nTickCount >= tItem[j].TimeOut) and (tItem[j].nLevel <= nLevel) ) then
				tItem[j].TimeOut = tItem[j].tInterval[nHour] + nTickCount
				if( tItem[j].Skip == 0 ) then
					tReturn[nCount] = {}
					tReturn[nCount].ItemId = tItem[j].ItemId
					tReturn[nCount].ItemNum = nRandom
					tItem[j].Skip = nRandom - 1
					nCount = nCount + 1
					TRACE( "Event.lua : GetItem() - Drop - "..tItem[j].ItemId..", "..nRandom.."개, Skip:"..tItem[j].Skip.." 시간대:"..(nHour-1).." ~ "..nHour )
				else
					tItem[j].Skip = tItem[j].Skip - 1
					TRACE( "Event.lua : GetItem() - Skip - "..tItem[j].ItemId..", 남은 Skip:"..tItem[j].Skip.." 시간대:"..(nHour-1).." ~ "..nHour )
				end
			end
		end
	end
	return tReturn
end
function SetExpFactor( fExpFactor )
	local nEventId = #tEvent
	tEvent[nEventId].fExpFactor = fExpFactor
end

function GetExpFactor()
	local tList = GetEventList()
	local fExpFactor = 1
	for i in pairs(tList) do
		if( tEvent[tList[i]].fExpFactor ~= nil ) then
			fExpFactor = fExpFactor * tEvent[tList[i]].fExpFactor
		end
	end
	
	return fExpFactor
end

function SetItemDropRate( fItemDropRate )
	local nEventId = #tEvent
	tEvent[nEventId].fItemDropRate = fItemDropRate
end

function GetItemDropRate()
	local tList = GetEventList()
	local fItemDropRate = 1
	for i in pairs(tList) do
		if( tEvent[tList[i]].fItemDropRate ~= nil ) then
			fItemDropRate = fItemDropRate * tEvent[tList[i]].fItemDropRate
		end
	end
	
	return fItemDropRate
end

function SetPieceItemDropRate( fPieceItemDropRate )
	local nEventId = #tEvent
	tEvent[nEventId].fPieceItemDropRate = fPieceItemDropRate
end

function GetPieceItemDropRate()
	local tList = GetEventList()
	local fPieceItemDropRate = 1
	for i in pairs(tList) do
		if( tEvent[tList[i]].fPieceItemDropRate ~= nil ) then
			fPieceItemDropRate = fPieceItemDropRate * tEvent[tList[i]].fPieceItemDropRate
		end
	end
	
	return fPieceItemDropRate
end

function SetGoldDropFactor( fGoldDropFactor )
	local nEventId = #tEvent
	tEvent[nEventId].fGoldDropFactor = fGoldDropFactor
end

function GetGoldDropFactor()
	local tList = GetEventList()
	local fGoldDropFactor = 1
	for i in pairs(tList) do
		if( tEvent[tList[i]].fGoldDropFactor ~= nil ) then
			fGoldDropFactor = fGoldDropFactor * tEvent[tList[i]].fGoldDropFactor
		end
	end
	
	return fGoldDropFactor
end


function SetAttackPower( nAttackPower )
	local nEventId = #tEvent
	tEvent[nEventId].nAttackPower = nAttackPower
end

function GetAttackPower()
	local tList = GetEventList()
	local nAttackPower = 1
	for i in pairs(tList) do
		if( tEvent[tList[i]].nAttackPower ~= nil ) then
			nAttackPower = nAttackPower + tEvent[tList[i]].nAttackPower
		end
	end
	
	return nAttackPower
end


function SetDefensePower( nDefensePower )
	local nEventId = #tEvent
	tEvent[nEventId].nDefensePower = nDefensePower
end

function GetDefensePower()
	local tList = GetEventList()
	local nDefensePower = 1
	for i in pairs(tList) do
		if( tEvent[tList[i]].nDefensePower ~= nil ) then
			nDefensePower = nDefensePower + tEvent[tList[i]].nDefensePower
		end
	end
	
	return nDefensePower
end

function SetCouponEvent( nTime )
	local nEventId = #tEvent
	tEvent[nEventId].nCouponEvent = nTime
end

function GetCouponEvent()
	local tList = GetEventList()
	for i in pairs(tList) do
		if( tEvent[tList[i]].nCouponEvent ~= 0 ) then
			return tEvent[tList[i]].nCouponEvent
		end
	end
	
	return 0
end

function SetLevelUpGift( nLevel, strAccount, strItemId, nItemNum, byFlag )
	local nEventId = #tEvent
	local nSize = #tEvent[nEventId].Gift
	
	tEvent[nEventId].Gift[nSize+1] = {}
	tEvent[nEventId].Gift[nSize+1].nLevel = nLevel
	tEvent[nEventId].Gift[nSize+1].strAccount = strAccount
	tEvent[nEventId].Gift[nSize+1].strItemId = strItemId
	tEvent[nEventId].Gift[nSize+1].nItemNum = nItemNum
	tEvent[nEventId].Gift[nSize+1].byFlag = byFlag
end

function GetLevelUpGift( nLevel, strAccount )
	local nCount = 1
	local tGiftList = {}
	local tList = GetEventList()
	for i in pairs(tList) do
		local tGift = tEvent[tList[i]].Gift
		for j in pairs(tGift) do
			local nTemp = string.find( strAccount, tGift[j].strAccount )
			if( (tGift[j].strAccount == "all") or (nTemp ~= nil) ) then 
				if( tGift[j].nLevel == nLevel ) then
					tGiftList[nCount] = {}
					tGiftList[nCount].strItemId = tGift[j].strItemId
					tGiftList[nCount].nItemNum = tGift[j].nItemNum
					tGiftList[nCount].byFlag = tGift[j].byFlag
					nCount = nCount + 1
				end
			end
		end
	end
	
	return tGiftList
end	

function SetCheerExpFactor( fCheerExpFactor )
	local nEventId = #tEvent
	tEvent[nEventId].fCheerExpFactor = fCheerExpFactor
end

function GetCheerExpFactor()
	local tList = GetEventList()
	local fCheerExpFactor = 1
	for i in pairs(tList) do
		if( tEvent[tList[i]].fCheerExpFactor ~= nil ) then
			fCheerExpFactor = fCheerExpFactor * tEvent[tList[i]].fCheerExpFactor
		end
	end
	
	return fCheerExpFactor
end

function SetSpawn( nType, strId, nDayNum )
	local nEventId = #tEvent
	local nSize = #tEvent[nEventId].tSpawn
	
	tEvent[nEventId].tSpawn[nSize+1] = {}
	tEvent[nEventId].tSpawn[nSize+1].nType = nType
	tEvent[nEventId].tSpawn[nSize+1].strId = strId
	tEvent[nEventId].tSpawn[nSize+1].nDayNum = nDayNum
end

function GetSpawn( nId )
	return tEvent[nId].tSpawn, #tEvent[nId].tSpawn
end


function SetKeepConnectEvent( nTime, strItemId, nItemNum )
	local nEventId = #tEvent
	local nSize = #tEvent[nEventId].tKeepConnectEvent
	
	tEvent[nEventId].tKeepConnectEvent[nSize+1] = {}
	tEvent[nEventId].tKeepConnectEvent[nSize+1].nTime = nTime
	tEvent[nEventId].tKeepConnectEvent[nSize+1].strItemId = strItemId
	tEvent[nEventId].tKeepConnectEvent[nSize+1].nItemNum = nItemNum
end

function GetKeepConnectTime()
	local tList = GetEventList()
	for i in pairs(tList) do
		local tTime = tEvent[tList[i]].tKeepConnectEvent
		for j in pairs(tTime) do
			if( tTime[j].nTime ~= 0 ) then
				return tTime[j].nTime
			end
		end
	end
	return 0
end

function GetKeepConnectItem()
	local tList = GetEventList()
	local tReturn = {}
	local nCount = 1
	for i in pairs(tList) do
		local tItem = tEvent[tList[i]].tKeepConnectEvent
		for j in pairs(tItem) do
			tReturn[nCount] = {}
			tReturn[nCount].strItemId = tItem[j].strItemId
			tReturn[nCount].nItemNum = tItem[j].nItemNum
			nCount = nCount + 1
		end
	end
	return tReturn
end

function SetRainEvent( fFactor, strTitle )
	local nEventId = #tEvent
	tEvent[nEventId].fRainEventExpFactor = fFactor
	tEvent[nEventId].strRainEventTitle = strTitle
end

function GetRainEventExpFactor()
	local tList = GetEventList()
	local fFactor = 1
	for i in pairs(tList) do
		if( tEvent[tList[i]].fRainEventExpFactor ~= nil ) then
			fFactor = fFactor * tEvent[tList[i]].fRainEventExpFactor
		end
	end
	
	return fFactor
end

function GetRainEventTitle()
	local tList = GetEventList()
	for i in pairs(tList) do
		if( tEvent[tList[i]].fRainEventExpFactor > 1 ) then
			return tEvent[tList[i]].strRainEventTitle
		end
	end
	
	return nil
end

function SetSnowEvent( fFactor, strTitle )
	local nEventId = #tEvent
	tEvent[nEventId].fSnowEventExpFactor = fFactor
	tEvent[nEventId].strSnowEventTitle = strTitle
end

function GetSnowEventExpFactor()
	local tList = GetEventList()
	local fFactor = 1
	for i in pairs(tList) do
		if( tEvent[tList[i]].fSnowEventExpFactor ~= nil ) then
			fFactor = fFactor * tEvent[tList[i]].fSnowEventExpFactor
		end
	end

	return fFactor
end

function GetSnowEventTitle()
	local tList = GetEventList()
	for i in pairs(tList) do
		if( tEvent[tList[i]].fSnowEventExpFactor > 1 ) then
			return tEvent[tList[i]].strSnowEventTitle
		end
	end

	return nil
end
