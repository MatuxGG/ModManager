function SEC( a ) return a*1000 end
function MIN( a ) return SEC(a)*60 end

MONSTER_LOW		= 1
MONSTER_HARD		= 2
MONSTER_LOW_BOSS	= 3
MONSTER_HARD_BOSS	= 4

tMonster = {}
function AddMonster( nType, strMonsterId, nTime, nStage )
	nIndex = #tMonster  + 1
	tMonster[nIndex] = {}
	tMonster[nIndex].nType = nType
	tMonster[nIndex].strMonsterId = strMonsterId
	tMonster[nIndex].nTime = nTime
	tMonster[nIndex].nStage = nStage
end