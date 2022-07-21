DST_STR = 1
DST_DEX = 2
DST_INT = 3
DST_STA = 4 

-- II_WEA_SWO_LONG(23¹ø) ÀåÂø ÇÔ¼ö
function F23_equip( pMover )
	Trace( "LONG ¼Òµå ÀåÂø" )
	
	SetDestParam( pMover, DST_STR, 3 );
	return 1
end

-- II_WEA_SWO_LONG(23¹ø) Å»Âø ÇÔ¼ö
function F23_unequip( pMover )
	Trace( "LONG ¼Òµå Å»Âø" )
	ResetDestParam( pMover, DST_STR, 3 );
	return 1
end

 
