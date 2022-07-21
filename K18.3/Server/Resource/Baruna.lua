----------------------------------------------------------
--Baruna System-------------------------------------------
----------------------------------------------------------

tBarunaUpgrade 		= { 10000, 8000, 6300, 4500, 3300, 2600, 2100, 1700, 1400, 1100, 900, 750, 600, 400, 290, 200, 120, 60, 26, 10};
tBarunaDowngrade 	= { 0, 4000, 3150, 2250, 1650, 1300, 1050, 850, 700, 550, 450, 375, 300, 200, 145, 100, 60, 30, 13, 5};
tBarunaPetMultiplicator = { 0, 20, 50, 100, 200};
tBarunaNeedFailForPetUp = { 8, 25, 80, 200, 500}; 

tBarunaChaosGem = {}
function ChaosGemTable( nLevelMin, nChaosGemAmount, nChaosGemChance, nChaosPieceAmount, nChaosPieceChance )
	tBarunaChaosGem[nLevelMin] = {}
	tBarunaChaosGem[nLevelMin].nChaosGemAmount = nChaosGemAmount
	tBarunaChaosGem[nLevelMin].nChaosGemChance = nChaosGemChance
	tBarunaChaosGem[nLevelMin].nChaosPieceAmount = nChaosPieceAmount
	tBarunaChaosGem[nLevelMin].nChaosPieceChance = nChaosPieceChance
end

ChaosGemTable( 1, 0, 0, 1, 100 ) -- 1%
ChaosGemTable( 20, 0, 0, 1, 200 ) -- 2%
ChaosGemTable( 40, 0, 0, 1, 500 ) -- 5%
ChaosGemTable( 60, 0, 0, 2, 800 ) -- 8%
ChaosGemTable( 80, 1, 200, 3, 1000 ) -- 2%/ 10%
ChaosGemTable( 95, 1, 1000, 3, 2000 ) -- 10% / 20%
ChaosGemTable( 110, 1, 2500, 4, 4000 ) -- 25% / 40%
ChaosGemTable( 115, 1, 3500, 4, 8000 ) -- 35% / 80%
ChaosGemTable( 120, 1, 5000, 5, 10000 ) -- 50% / 100%
ChaosGemTable( 130, 1, 8000, 5, 10000 ) -- 80% / 100%

tBarunaPiercing		= { 10000 }; -- 100%