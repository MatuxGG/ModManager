property
{
	// 1 = Sunday, 2 = Monday, ..., 7 = Saturday
	nDayOfWeek	6	// 입후보 시작 요일 = 금요일
	nHour		0	// 입후보 시작 시간 = 0시
	tCandidacy	86400	// 입후보 기간 = 24시간
	tVote		172800	// 투표 기간 = 48시간
	nDays		14	// 군주 선거 간격 = 14일
}

rate
{
	1.0	// 득표 순위에 따른 반환율	// 1
	1.0	// 2
	0.8	// 3
	0.6	// 4
	0.4	// 5
	0.2	// 6
	0.0	// 7
	0.0
	0.0
	0.0
	0.98	// 후보 탈락 반환율
}

fRequirementFactor		20.0	// 최소 군주 득표 비율

item	0	// 군주 아이템 지급		// 남
{
II_ARM_M_CHR_MAJESTY01HAT
II_ARM_M_CHR_MAJESTY01SUIT
II_ARM_M_CHR_MAJESTY01GLOVES
II_ARM_M_CHR_MAJESTY01SHOES
II_PET_YETI
II_ARM_S_CLO_CLO_MAJESTY
II_RID_RID_STI_MAJESTYBIKE
}

item	1	// 군주 아이템 지급		// 여
{
II_ARM_F_CHR_MAJESTY01HAT
II_ARM_F_CHR_MAJESTY01SUIT
II_ARM_F_CHR_MAJESTY01GLOVES
II_ARM_F_CHR_MAJESTY01SHOES
II_PET_YETI
II_ARM_S_CLO_CLO_MAJESTY
II_RID_RID_STI_MAJESTYBIKE
}