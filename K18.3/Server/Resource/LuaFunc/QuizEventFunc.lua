function SEC( a ) return a * 1000 end
function MIN( a ) return SEC( a ) * 60 end

--------------------------------------------------------------------------

TYPE_OX		= 1
TYPE_4C		= 2

tNPC = {}

function SetNPC( strNPCId, strCharKey, xPos, yPos, zPos )
	local nIndex = #tNPC + 1
	
	tNPC[nIndex] = {}
	tNPC[nIndex].strNPCId = strNPCId
	tNPC[nIndex].strCharKey = strCharKey
	tNPC[nIndex].xPos = xPos
	tNPC[nIndex].yPos = yPos
	tNPC[nIndex].zPos = zPos
end