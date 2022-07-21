tCreateMonster = {}

function SEC( n )	return n * 1000		end
function MIN( n )	return n * SEC( 60 )	end

function AddItem( strItemId, dwKeepTime )
	local nSize = #tCreateMonster + 1
	
	tCreateMonster[nSize] = {}
	tCreateMonster[nSize].strItemId = strItemId
	tCreateMonster[nSize].dwKeepTime = dwKeepTime
	tCreateMonster[nSize].tMonster = {}
end

function AddMonster( strMonsterId, nProbability )
	local n = #tCreateMonster
	nSize = #tCreateMonster[n].tMonster + 1
	
	tCreateMonster[n].tMonster[nSize] = {}
	tCreateMonster[n].tMonster[nSize].strMonsterId	= strMonsterId
	tCreateMonster[n].tMonster[nSize].nProbability	= nProbability
end