nMaxInstanceDungeon = 40

tDungeon = {}
--------------------------------------------------------------------
-- 시간 설정 관련 함수 ---------------------------------------------
--------------------------------------------------------------------
function SEC( a ) return a * 1000 end
function MIN( a ) return SEC( a ) * 60 end


function AddDungeon( strWorldId )
	local nIndex = #tDungeon + 1
	
	tDungeon[nIndex] = {}
	tDungeon[nIndex].strWorldId = strWorldId
	tDungeon[nIndex].dwClass = 65535
	tDungeon[nIndex].nMinLevel = 1
	tDungeon[nIndex].nMaxLevel = 120
	tDungeon[nIndex].dwCoolTime = MIN( 30 )
	tDungeon[nIndex].tMonster = {}
	tDungeon[nIndex].tTeleport = {}
end

CLASS_NORMAL	= 1
CLASS_MASTER	= 2
CLASS_HERO	= 4
CLASS_LEGEND_HERO	= 8

function SetClass( ... )
	local nIndex = #tDungeon
	local arg = table.pack(...)
	local dwClass = 0
	if( #arg > 0 ) then
		for indx = 1, #arg do
			dwClass = dwClass + arg[indx]
		end
	end
	tDungeon[nIndex].dwClass = dwClass
end


function SetLevel( nMinLevel, nMaxLevel )
	local nIndex = #tDungeon
	tDungeon[nIndex].nMinLevel = nMinLevel
	tDungeon[nIndex].nMaxLevel = nMaxLevel
end


function SetCoolTime( dwCoolTime )
	local nIndex = #tDungeon
	tDungeon[nIndex].dwCoolTime = dwCoolTime
end


ID_NORMAL	= 0
ID_MIDBOSS 	= 1
ID_BOSS		= 2
function SetMonster( nType, strMonsterId, bRed, x, y, z )
	local nPDIndex = #tDungeon
	local nMTIndex = #tDungeon[nPDIndex].tMonster + 1
		
	tDungeon[nPDIndex].tMonster[nMTIndex] = {}
	tDungeon[nPDIndex].tMonster[nMTIndex].nType = nType
	tDungeon[nPDIndex].tMonster[nMTIndex].strMonsterId = strMonsterId
	tDungeon[nPDIndex].tMonster[nMTIndex].bRed = bRed
	tDungeon[nPDIndex].tMonster[nMTIndex].x = x
	tDungeon[nPDIndex].tMonster[nMTIndex].y = y
	tDungeon[nPDIndex].tMonster[nMTIndex].z = z
end


function SetTeleportPos( nType, x, y, z )
	local nPDIndex = #tDungeon
	local nTPIndex = #tDungeon[nPDIndex].tTeleport + 1
		
	tDungeon[nPDIndex].tTeleport[nTPIndex] = {}
	tDungeon[nPDIndex].tTeleport[nTPIndex].nType = nType
	tDungeon[nPDIndex].tTeleport[nTPIndex].x = x
	tDungeon[nPDIndex].tTeleport[nTPIndex].y = y
	tDungeon[nPDIndex].tTeleport[nTPIndex].z = z
end
