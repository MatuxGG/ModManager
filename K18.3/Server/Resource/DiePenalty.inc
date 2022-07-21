/*/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

유의점) 경험치 다운, HP회복수치인 % 일 경우 소수점을 표현하기 위해 곱하기 100인 값으로 적용됩니다.

REVIVAL_PENALTY		// 부활 Penalty
{
사용법)	ADDPENALTY	레벨	HP회복수치(%)
예) 	ADDPENALTY	1	8000
	ADDPENALTY	2	6000
	ADDPENALTY	5	5000
	// 0~1레벨이 부활하면 MAX HP의 80%의 HP가 회복함
	// 2~2레벨이 부활하면 MAX HP의 60%의 HP가 회복함
	// 3~5레벨이 부활하면 MAX HP의 50%의 HP가 회복함
}

DECEXP_PENALTY
{
사용법)	ADDPENALTY	레벨	경험치다운(%)
예) 	ADDPENALTY	20	0
	ADDPENALTY	29	60		
	// 0~20레벨이 죽으면 0%의 경험치가 깍임
	// 21~29레벨이 죽으면 6%의 경험치가 깍임
}

LEVEL_DOWN_PENALTY
{
사용법)	ADDPENALTY	레벨	레벨다운(유/무)
예) 	ADDPENALTY	20	0
	ADDPENALTY	200	1	
	// 0~20레벨 죽었을때 레벨다운을 할수 없음
	// 21~200레벨 죽었을때 레벨다운을 할수 있음
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/

REVIVAL_PENALTY
{
	ADDPENALTY	1	8000
	ADDPENALTY	2	6000
	ADDPENALTY	5	5000
	ADDPENALTY	10	4000
	ADDPENALTY	200	3000
}

DECEXP_PENALTY
{
	ADDPENALTY	20	0
	ADDPENALTY	29	600
	ADDPENALTY	59	500
	ADDPENALTY	89	400
	ADDPENALTY	99	300
	ADDPENALTY	109	200
	ADDPENALTY	129	150
	ADDPENALTY	200	100
}

LEVEL_DOWN_PENALTY
{
	ADDPENALTY	20	0
	ADDPENALTY	200	1
}