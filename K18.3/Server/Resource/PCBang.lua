--------------------------------------------------------
tExp = {}
tDropRate = {}

function AddExp( fFactor )
	local nIndex = #tExp + 1
	tExp[nIndex] = fFactor
end

function AddDropRate( fFactor )
	local nIndex = #tDropRate + 1
	tDropRate[nIndex] = fFactor
end
--------------------------------------------------------

--------------------------------------------------------
-- Begin Script ----------------------------------------
--------------------------------------------------------
AddExp( 1.5 )

AddDropRate( 1.2 )
