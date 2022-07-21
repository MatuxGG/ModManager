tEventMonster = {}

function AddMonster( strMonsterId, nLevel, nLootTime, fItemDropRange, bPet, bGiftBox )
	local nSize = #tEventMonster + 1
	
	tEventMonster[nSize] = {}
	tEventMonster[nSize].strMonsterId = strMonsterId
	tEventMonster[nSize].nLevel = nLevel
	tEventMonster[nSize].nLootTime = nLootTime
	tEventMonster[nSize].fItemDropRange = fItemDropRange
	tEventMonster[nSize].bPet = bPet
	tEventMonster[nSize].bGiftBox = bGiftBox
end
