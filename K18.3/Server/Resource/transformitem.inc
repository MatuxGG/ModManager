/*
// nTransform	// 변환 번호	// 중복 허용 안함	// 확장을 위해 아래와 같은 형태를 가지게 되었습니다.
0
{
	// 임시
	stuff	10	
	// 변환 결과 아이템으로 크게 두 가지 타입(TI_GENERIC, TI_PET)이 있습니다. 
	// TI_GENERIC은 일반 아이템을 의미하며, 어떤 아이템 몇개를 생성한다는 뜻입니다.
	// TI_PET은 시스템 펫을 의미하며, 종류, 스탯, 생명값이 필요합니다.(에너지는 꽉 찬 상태입니다.)
		// 펫 종류로는 PK_TIGER, PK_LION, PK_RABBIT, PK_FOX, PK_DRAGON, PK_GRIFFIN, PK_UNICORN 값을 가질 수 있습니다.
		// 펫의 스탯은 13579와 같이 표시하며 이는, 스탯 1, 3, 5, 7, 9를 가지는 S급 펫을 의미합니다.
		// 만약 12라고하면 스탯 1, 2를 가지는 C급 펫이 만들어지게 됩니다.
	// 확률은 1/1000000(백만분의 1) 기준입니다.
	// 확률의 합이 백만이 되지 않을 경우엔 꽝이 나옵니다.
	item	
	{
		//확률	//타입		//발생 아이템		//개수
		250000	TI_GENERIC	II_WEA_SWO_WOODEN	1
		//확률	//타입	//펫종류	//스탯	//생명	//경험치
		250000	TI_PET	PK_LION	13579	1	0.5
	}
}
*/

0
{
	stuff	10

	item
	{
		260000	TI_GENERIC	II_SYS_SYS_FEED_01	500
		220000	TI_GENERIC	II_SYS_SYS_FEED_01	1000
		190000	TI_GENERIC	II_SYS_SYS_FEED_01	1500
		130000	TI_GENERIC	II_SYS_SYS_FEED_01	2000
		80000	TI_GENERIC	II_SYS_SYS_FEED_01	3000
		30000	TI_GENERIC	II_SYS_SYS_FEED_01	4000
		20000	TI_GENERIC	II_SYS_SYS_FEED_01	5000

		10000	TI_PET	PK_TIGER	1	0	0
		10000	TI_PET	PK_LION		1	0	0
		10000	TI_PET	PK_RABBIT	1	0	0
		10000	TI_PET	PK_FOX		1	0	0
		10000	TI_PET	PK_DRAGON	1	0	0
		10000	TI_PET	PK_GRIFFIN	1	0	0
		10000	TI_PET	PK_UNICORN	1	0	0
	}
}