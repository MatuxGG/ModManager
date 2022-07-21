#ifndef __DEFINE_NEUZ
#define __DEFINE_NEUZ

#define AII_NONE			0
#define AII_MOVER			1
#define AII_MONSTER			2
#define AII_HUMAN			3
#define	AII_CLOCKWORKS		4
#define AII_PET				5
#define AII_BIGMUSCLE		6
#define AII_KRRR			7
#define AII_BEAR			8
#define	AII_EGG		9
#define	AII_METEONYKER	10
#define	AII_AGGRO_NORMAL	11

#define	AII_PARTY_AGGRO_LEADER	12
#define	AII_PARTY_AGGRO_SUB		13

#define AII_ARENA_REAPER	14

#define	AII_BEETLE			15

#define AII_VER2_TYPE0		100

// group 그룹 설정 
#define GRP_ALL               0
#define GRP_SOLO              1
#define GRP_PARTY             2
#define GRP_GUILD             3

//////////////////////////////////////////////////////////////////////////
#define	PARTS_HEAD				0  // 장비에서 제외 
#define	PARTS_HAIR				1  // 장비에서 제외 
#define	PARTS_UPPER_BODY		2
#define	PARTS_LOWER_BODY		3
#define	PARTS_HAND				4
#define	PARTS_FOOT				5
#define	PARTS_CAP				6
#define	PARTS_ROBE				7
#define	PARTS_CLOAK				8
#define	PARTS_LWEAPON			9 
#define	PARTS_RWEAPON			10
#define	PARTS_SHIELD  			11
#define	PARTS_MASK              12
#define	PARTS_RIDE              13 // 장비에서 제외 - 이건 16번 이후로 가야하는건데 컨버트를 해야하기땜시 이대로 해결했다.
// 여기까지 동시 출력 파츠 
// 16이상으로 수치를 늘이려면 xuzhu에게 꼭 얘기할것. 안그러면 에러남.
#define	PARTS_CAP2              14 // 장비에서 제외 
#define	PARTS_UPPER2            15 // 장비에서 제외 

// 실제 화면상에서 렌더링되지 않는 파츠는 16번 이상을 쓴다. 귀걸이,반지 같은것들.
#define	PARTS_LOWER2            16
#define	PARTS_HAND2             17
#define	PARTS_FOOT2             18
// 여기까지 장착은 하지만 이것을 장착하므로서 다른 파츠가 눈에 안보이게 한다.(익스크루시브랑은 다르다.)
#define	PARTS_NECKLACE1         19 // 목걸이
#define	PARTS_RING1             20 // 반지
#define	PARTS_RING2             21
#define	PARTS_EARRING1          22 // 귀걸이
#define	PARTS_EARRING2          23
#define	PARTS_PROPERTY          24 //목걸이, 반지, 귀걸이를 제외한 소도구들을 착용할 공간
#define	PARTS_BULLET            25 //각종총알 슬롯


#define	PARTS_HAT				26 // 패션아템 모자
#define	PARTS_CLOTH				27 // 패션 의상 
#define	PARTS_GLOVE				28 // 패션 장갑
#define	PARTS_BOOTS				29 // 패션 부츠
#define	PARTS_CLOAK2			30 // 패션 망토
// 파츠가 추가될 때 프로그램팀에 알려주세요
//////////////////////////////////////////////////////////////////////////



// Structure Type
#define SRT_NONE                 0 
#define SRT_LODESTAR             1 
#define SRT_LODELOGHT            2 
#define SRT_STATION              3
#define SRT_WEAPON               4
#define SRT_SHIELD               5
#define SRT_FOOD                 6
#define SRT_MAGIC                7
#define SRT_GENERAL              8 
#define SRT_PUBLICOFFICE         9 
#define SRT_QUESTOFFICE         10 
#define SRT_DUNGEON             11
#define SRT_BUCKLER				12
#define SRT_WARPZONE			13
#define SRT_KEY					14
#define SRT_CASH				15
#define MAX_STRUCTURE            20


// 퀘스트 스테이트
#define QS_BEGIN                0


// 주의!! 이 부분에 추가할 때는 해당 텍스트도 입력해야함.
// 텍스트는 defineText.h와 texClient.txt를 수정해야함.
// defineText.h의 순서와 MMI의 순서가 일치해야함.
#define MMI_DIALOG		0 // "대화" ),
#define MMI_QUEST		1 // 퀘스트 
#define MMI_TRADE		2 // "거래" ),
#define MMI_FIGHT		3 // "대전" ),
#define MMI_MESSAGE		4 // "메시지" ),
#define MMI_ADD_MESSENGER	5 // "메신저 추가" ),
#define MMI_INVITE_PARTY	6 // "파티 참여" )
#define MMI_INVITE_COMPANY	7 // "파티 참여" )
#define MMI_MARKING		8 // "장소 지정" )
#define MMI_BANKING		9 // "은행
#define MMI_DUEL		10 // 듀얼신청
#define MMI_DUEL_PARTY		11 // 파티 듀얼.
#define MMI_TRACE			12 // 개인거래
#define MMI_BEAUTYSHOP		13 // 뷰티샵
#define MMI_REPAIR  		14 // 수리창
#define MMI_GUILDBANKING	15 // 길드창고
#define MMI_RANK_GUILD		16 // 길드 랭킹
#define MMI_RANK_WAR		17 // 길드전승패 랭킹
#define MMI_RANK_INFO		18 // 길드기타 랭킹
#define MMI_UPGRADE			19 // 재련창
#define MMI_CHANGEELEM		20 // 속성 변경
#define MMI_INPUT_REWARD	21 // 현상금 걸기
#define MMI_SHOW_REWARD		22 // 현상금 보기
#define MMI_PIERCING		23
#define MMI_QUERYEQUIP		24
#define MMI_POST			25
#define MMI_GUILDWAR_APP		26
#define MMI_GUILDWAR_STATE		27
#define MMI_GUILDWAR_CANCEL		28
#define MMI_GUILDWAR_JOIN		29
#define MMI_GUILDCOMBAT_RANKING		30 
#define MMI_CHEER			31 
#define MMI_PIERCING_REMOVE		32
#define MMI_GUILDCOMBAT_SELECTION	33
#define MMI_GUILDCOMBAT_JACKPOT		34
#define MMI_GUILDCOMBAT_JACKPOT2	35
#define MMI_GUILDCOMBAT_BESTPLAYER	36

#define MMI_GUILDCOMBAT_INFO_BOARD1	37
#define MMI_GUILDCOMBAT_INFO_BOARD2	38
#define MMI_GUILDCOMBAT_INFO_BOARD3	39
#define MMI_GUILDCOMBAT_INFO_TEX	40
#define MMI_GUILDCOMBAT_PENYA_RETURN 	41
#define MMI_BEAUTYSHOP_SKIN		42 // 성형수술
#define MMI_SUMMON_ANGEL		43 // 엔젤소환
#define MMI_KAWIBAWIBO			44 //가위바위보 게임
#define MMI_FINDWORD			45 //단어맞추기 게임
#define MMI_FIVESYSTEM 			46 //오곱(주사위) 게임
#define MMI_REASSEMBLE 			47 //퍼즐 게임

#define	MMI_PET_FEED			48 //펫 먹이 주기
#define	MMI_PET_STATUS			49 //펫 상태
#define	MMI_PET_RELEASE			50 //펫 해제

#define MMI_SMELT_MIXJEWEL		51 //제련 : 오리칼쿰, 문스톤 합성
#define MMI_SMELT_JEWEL			52 //제련 : 얼터멋 아이템 보석 제련
#define MMI_SMELT_EXTRACTION	53 //제련 : 보석추출
#define MMI_SMELT_CHANGEGWEAPON	54 //제련 : 무기 변경 (일반 -> 유니크)
#define MMI_SMELT_CHANGEUWEAPON	55 //제련 : 무기 변경 (유니크 -> 얼터멋)

#define MMI_LEGEND_SKILLUP		56 //영웅 스킬업

#define MMI_EVENT_MAY			57 //5월 이벤트 - 행복한 가정의 달 만들기 대 작전
#define MMI_PET_FOODMILL		58
#define MMI_ATTRIBUTE			59

#define MMI_GUILDCOMBAT_1TO1_OFFER			60 // 1:1길드대전 신청하기
#define MMI_GUILDCOMBAT_1TO1_CANCEL			61 // 1:1길드대전 취소하기
#define MMI_GUILDCOMBAT_1TO1_OFFERSTATE		62 // 1:1길드대전 신청현황
#define MMI_GUILDCOMBAT_1TO1_SELECTION		63 // 1:1길드대전 참가자 구성
#define MMI_GUILDCOMBAT_1TO1_ENTRANCE		64 // 1:1길드대전 입장
#define MMI_GUILDCOMBAT_1TO1_GUIDE_TEX		65 // 1:1길드대전 수수료 안내
#define MMI_GUILDCOMBAT_1TO1_GUIDE_PRIZE	66 // 1:1길드대전 상금&상품 안내
#define MMI_GUILDCOMBAT_1TO1_GUIDE_ENTRY	67 // 1:1길드대전 참가 안내
#define MMI_GUILDCOMBAT_1TO1_GUIDE_RULE		68 // 1:1길드대전 규칙 안내
#define MMI_GUILDCOMBAT_1TO1_GUIDE_WIN		69 // 1:1길드대전 승리조건 안내
#define MMI_GUILDCOMBAT_1TO1_REPAYMENT		70 // 1:1길드대전 신청금 반환

#define MMI_LVREQDOWN_CANCEL			71 // 착용레벨 하락 해지 메뉴
#define MMI_SMELT_REMOVE_PIERCING		72 // 슈트의 피어싱 옵션 제거
#define MMI_ITEM_AWAKENING				73 // 아이템 각성 메뉴
#define MMI_NPC_BUFF					74 // NPC한테 Buff받기
#define MMI_COLLECT01                  	75 // 일반 조각 교환
#define MMI_COLLECT02                  	76 // 카드 조각 교환
#define MMI_PET_RES                   	77 // 펫을 부활의 조각으로 교환 
#define MMI_PET_RES01					78 // 부활의 조각을 두루마리로 교환

#define MMI_BLESSING_CANCEL				79 // 여신의 축복 취소

#define	MMI_ARENA_ENTER					80
#define	MMI_ARENA_EXIT					81

#define MMI_EVENT_HAPPY_TWN				82
#define MMI_EVENT_HAPPY_USA				83

#define MMI_SECRET_OFFER				84 // 비밀의 방 신청
#define MMI_SECRET_OFFERSTATE			85 // 비밀의 방 신청현황
#define MMI_SECRET_SELECTION			86 // 비밀의 방 참가자 구성
#define MMI_SECRET_ENTRANCE				87 // 비밀의 방 입장
#define MMI_SECRET_TAXRATES_CHANGE		88 // 세율 변경 창
#define MMI_SECRET_TAXRATES_CHECK		89 // 세율 확인 창
#define MMI_SECRET_BOARD				90 // 비밀의 방 안내

#define MMI_LORD_STATE					91 // 군주 후보 상태창
#define MMI_LORD_TENDER					92 // 군주 입찰 창
#define MMI_LORD_VOTE					93 // 군주 투표 창
#define MMI_LORD_EVENT					94 // 군주 이벤트 창

#define MMI_SMELT_REMOVE_JEWEL			95 // 얼터멋 웨폰 보석 제거 창
#define MMI_PET_EGG01					96 // 알 변환 창
#define MMI_HEAVEN_TOWER				97 // 심연의 탑
#define	MMI_EXCHANGE_WEAPONCARD			98 // 무기 카드 교환
#define	MMI_EXCHANGE_ARMORCARD			99 // 방어구 카드 교환


#define	MMI_SECRET_ENTRANCE_1			100 // 전용 사냥터 입장

#define	MMI_LORD_INFO					101 // 군주 정보창
#define	MMI_LORD_RPINFO					102 // 군주 반환금 정보창

#define MMI_SECRET_CANCEL				103 // 비밀의 방 취소

#define MMI_PET_AWAK_CANCEL				104 // 펫각성 취소

#define	MMI_FASHION_PHP					105 // 패션 쿠폰 이벤트

#define	MMI_EVENT_CARD_KOR				106 // 국내 카드 교환 이벤트

#define MMI_LORD_RAINBOWAPPLICATION		107 // 레인보우 레이스 참가 신청
#define MMI_LORD_RAINBOWWAIT			108 // 레인보우 레이스 란?
#define MMI_LORD_RAINBOWRULE			109 // 레인보우 레이스의 규칙
#define MMI_LORD_RAINBOWTOPTEN			110 // 레인보우 레이스 지난 순위
#define MMI_LORD_RAINBOWWIN				111	// 레인보우 레이스 상금 소개
#define MMI_LORD_RAINBOWEND				112 // 레인보우 레이스 종료 확인
#define MMI_LORD_RAINBOW_KAWIBAWIBO		113 // 레인보우 레이스 - 가위,바위,보 게임
#define MMI_LORD_RAINBOW_DICE			114 // 레인보우 레이스 - 주사위 굴려! 굴려!
#define MMI_LORD_RAINBOW_ARITHMETIC		115 // 레인보우 레이스 - 사칙연산
#define MMI_LORD_RAINBOW_STOPWATCH		116 // 레인보우 레이스 - 스톱워치 순발력 게임
#define MMI_LORD_RAINBOW_TYPING			117 // 레인보우 레이스 - 황당 타자 치기
#define MMI_LORD_RAINBOW_CARD			118 // 레인보우 레이스 - 기억해! 카드 맞추기
#define MMI_LORD_RAINBOW_LADDER			119 // 레인보우 레이스 - 알 수 없는 사다리 타기

#define	MMI_RENAME_CANCEL			120 // 펫 작명 취소

#define	MMI_EVENT_TRADE_KOR			121  //가위 바위 보 쿠폰 교환

#define	MMI_VISIT_MYROOM			122 // 마이룸 가기
#define	MMI_VISIT_FRIEND			123 // 친구방 가기
#define	MMI_RETURNTO_WORLD			124 // 마이룸에서 월드로 귀환

#define	MMI_EVENT_RESTATE01			125 // 리스테트 쿠폰 교환

#define MMI_ITEM_TRANSY				126 // 아이템 트렌지

#define MMI_EVENT_FIRSTTERM01			127 // 새학기 이벤트

#define	MMI_EVENT_ALICE01			128 // 국내 활성화 이벤트

#define	MMI_EVENT_OASIS01			129 // 달려라 운동회
#define	MMI_EVENT_FLOWER01			130 // 사랑의 카네이션

#define	MMI_EVENT_ALICE02			131 // 일본, 대만, 홍콩 봄이벤트

#define MMI_EVENT_TRADE_USA			132 // 미국 가위바위보 쿠폰 교환

#define MMI_EVENT_TRADE_ASIA			133 // 홍콩, 대만 가위바위보 쿠폰 교환

#define	MMI_SMELT_SAFETY_GENERAL		134 // 안전제련(일반)
#define	MMI_SMELT_SAFETY_ACCESSORY		135 // 안전제련(액세서리)
#define	MMI_SMELT_SAFETY_PIERCING		136 // 안전제련(피어싱)

#define	MMI_QUIZ_ENTRANCE			137 // 퀴즈이벤트 입장
#define	MMI_QUIZ_TELE_QUIZZONE		138 // 대기존에서 퀴즈존으로 이동
#define	MMI_QUIZ_EXIT				139 // 대기존에서 마을로 이동
#define MMI_CHANGTICKET01			140 // 일본 로사뽕 이벤트
#define MMI_BUFFPET_STATUS			141	// 버프펫 상태
#define MMI_BUFFPET_RELEASE			142 // 버프펫 해제 
#define MMI_GHOUSE_INFO				143	// 가구 정보 
#define MMI_GHOUSE_REINSTALL		144	// 가구 재설치 
#define MMI_GHOUSE_RECALL			145	// 가구 회수 

#define MMI_TELEPORTER				146 // 텔레포터 

#define MMI_GUILDHOUSE_SALE			147 // 길드하우스 판매 NPC
#define MMI_GUILDHOUSE_CHARGE		148 // 길드하우스 유지비
#define MMI_GUILDHOUSE_ENTER		149 // 길드하우스 입장
#define MMI_GUILDHOUSE_OUT			150 // 길드하우스 퇴장
#define MMI_INVITE_CAMPUS			151 // 사제 맺기
#define MMI_REMOVE_CAMPUS			152 // 사제 끊기

#define	MMI_CHANGE_CHRISTMAS01		153

#define	MMI_GHOUSE_BED				154
#define	MMI_GHOUSE_TABLE			155
#define	MMI_GHOUSE_SOFA				156
#define	MMI_GHOUSE_DESK				157
#define	MMI_GHOUSE_CHAIR			158
#define	MMI_GHOUSE_CASE				159
#define	MMI_GHOUSE_CLOSET			160
#define	MMI_GHOUSE_WARDROBE			161
#define	MMI_GHOUSE_BATH				162
#define	MMI_GHOUSE_DRAWER			163
#define	MMI_GHOUSE_CARPET			164
#define	MMI_GHOUSE_WALLPAPER			165

#define MMI_EVENT_FITA				166

#define	MMI_SMELT_SAFETY_ELEMENT		167 // 안전제련(속성)

#define	MMI_EVENT_LUCKYBOX			168

#define	MMI_CHANGEGG01				169

#define	MMI_EVENT_TRADE_KOR2010		170

#define	MMI_GUILDHOUSE_AUCTION01	171

#define	MMI_EVENT_HAPPY_USA2010		172

#define	MMI_EVENT_WORLDCUP10_KOR	173
#define	MMI_EVENT_WORLDCUP10_FOR	174
#define	MMI_EVENT_MATCHMAKER_FOR	175

#define	MMI_EVENT_ALICE_PHP_FOR	176

#define	MMI_EVENT_AROTTO_KOR	177 //롯토


#define MMI_SUMMON_SMELT				178
#define MMI_SUMMON_EXTRACTOPER			179
#define MMI_SUMMON_MAKEOPER				180
#define MMI_SUMMON_UPGRADECID			181
#define MMI_SUMMON_MAKECID				182
#define MMI_SUMMON_MAKEOPERCID			183

//16차 추가
#define MMI_GHOUSE_BARUNASMELPROT			184
#define MMI_GHOUSE_OPERPIECE				185
#define MMI_GHOUSE_OPERMIX					186
#define MMI_GHOUSE_OPERENCHANT				187
#define MMI_GHOUSE_UNSKILL					188
#define MMI_ERRORSENCHANT_BARUNA					189

#define MMI_EVENT_TRADE_TWN					190
//중형 길드하우스 문 매뉴
#define MMI_GUILDHOUSE_ENTER_DOOR			191
//중형 길드하우스 표지판
#define MMI_GUILDHOUSE_NOTICE			192

//교환매뉴 MMI
#define MMI_ZOMBIES_CHANGE1			193
#define MMI_ZOMBIES_CHANGE2			194
#define MMI_ZOMBIES_CHANGE3			195
#define MMI_ZOMBIES_CHANGE4			196

//교환매뉴 MMI
#define MMI_JAP_CHANGE			197

//유럽 홀덤 이벤트 교환 메뉴
#define MMI_HOLDEMEVENT01		198 // A카드 4장 교환
#define MMI_HOLDEMEVENT02		199 // K카드 4장 교환
#define MMI_HOLDEMEVENT03		200 // Q카드 4장 교환
#define MMI_HOLDEMEVENT04		201 // J카드 4장 교환
#define MMI_HOLDEMEVENT05		202 // A/K/Q/J 카드 1장씩 교환

#define MMI_SUMMON_PEARCING		203 //바루나 피어싱

#define MMI_COOPERATIVE_CONTRIBUTIONS 204 // 협동 기부

#define MMI_COLOSSEUM_COLOENTER01 205 // 협동 기부
#define MMI_COLOSSEUM_COLOENTER02 206 // 협동 기부

#define MMI_CHRISTMASFAIRY01	207 // 크리스마스 정령 토큰 교환 1개
#define MMI_CHRISTMASFAIRY02	208 // 크리스마스 정령 토큰 교환 25개
#define MMI_CHRISTMASFAIRY03	209 // 크리스마스 정령 토큰 교환 50개
#define MMI_CHRISTMASFAIRY04	210 // 크리스마스 정령 토큰 교환 75개
#define MMI_CHRISTMASFAIRY05	211 // 크리스마스 정령 토큰 교환 100개

#define MMI_COSTUMEBUY01	212 // 코스튬 재료 구입
#define MMI_COSTUMESELL01	213 // 코스튬 재료 판매
#define MMI_COSTUMEMIX01	214 // 코스튬 합성

#define MMI_DONATION		215 // 협동 기부 메뉴
#define MMI_DONATION_RANK	216 // 협동 기부 랭킹 보기

#define MMI_WHITEDAY_EXCHANGE01		217 //화이트 데이 교환
#define MMI_WHITEDAY_EXCHANGE02		218 //화이트 데이 교환
#define MMI_WHITEDAY_EXCHANGE03		219 //화이트 데이 교환
#define MMI_WHITEDAY_EXCHANGE04		220 //화이트 데이 교환

#define MMI_GHOUSE_CABINET			221// 길드 카테고리 장식장
#define MMI_GHOUSE_CRYSTAL			222// 길드 카테고리 크리스탈

#define MMI_FIRSEED2011					223//전나무 교환
#define	MMI_PEARSEED2011				224//배나무 교환
#define	MMI_PINESEED2011				225//소나무 교환
#define	MMI_PERSIMSEED2011				226//감나무 교환

#define	MMI_RIVERCARD2011				227//리버카드 교환
#define	MMI_FLAMECARD2011				228//플레임카드 교환
#define	MMI_DESERTCARD2011				229//데저트카드 교환
#define	MMI_GENERATERCARD2011			230//제너레이터카드 교환
#define	MMI_CYCLONECARD2011				231//싸이클론 카드
#define	MMI_EXCHANGEBLOSSOM				232//벚꽃씨앗-가위바위보 쿠폰 교환


#define	MMI_TELEPORTPOINTMENU01			233//삭제
#define	MMI_TELEPORTPOINTMENU02			234//전체삭제
#define	MMI_TELEPORTPOINTMENU03			235//이름변경
#define	MMI_TELEPORTPOINTMENU04			236//닫기

#define MMI_BARUNA_ELEMENT_SMELT		237//바루나속성제련
#define MMI_BARUNA_WAKEUP				238//바루나각성
#define MMI_BARUNA_WAKEUP_CANCEL		239//바루나각성취소

#define MMI_EVENTARENA_ENTER			241//전투 지역 입장

#define MMI_TWBOXTRADE01			242//깃발 교환하기

#define MMI_HANGAWI_TRADE		244//꿀송편 10개와 50,000 페냐를 가위바위보 쿠폰 1장으로 교환

#define MMI_MARKETJOIN				245//시장 입장 메뉴

#define MMI_TWBOXTRADE				246 // 5주년 기념 상자 교환

#define	MMI_BEHEMOTHSMELTEVENT_TWOSWORD			247	// 속성제련된 베히모스의 우든 투핸드 소드를 보상아이템으로 교환
#define	MMI_BEHEMOTHSMELTEVENT_TWOAXE			248	// 속성제련된 베히모스의 우든 투핸드 엑스를 보상아이템으로 교환
#define	MMI_BEHEMOTHSMELTEVENT_ONESWORD			249	// 속성제련된 베히모스의 우든소드를 보상아이템으로 교환
#define	MMI_BEHEMOTHSMELTEVENT_ONEAXE			250	// 속성제련된 베히모스의 우든 엑스를 보상아이템으로 교환
#define	MMI_BEHEMOTHSMELTEVENT_BOW				251	// 속성제련된 베히모스의 우든 보우를 보상아이템으로 교환
#define	MMI_BEHEMOTHSMELTEVENT_YOYO				252	// 속성제련된 베히모스의 우든 요요를 보상아이템으로 교환
#define	MMI_BEHEMOTHSMELTEVENT_KNUCKLE			253	// 속성제련된 베히모스의 우든 너클을 보상아이템으로 교환
#define	MMI_BEHEMOTHSMELTEVENT_STICK			254	// 속성제련된 베히모스의 우든 스틱을 보상아이템으로 교환
#define	MMI_BEHEMOTHSMELTEVENT_WAND				255	// 속성제련된 베히모스의 우든 완드를 보상아이템으로 교환
#define	MMI_BEHEMOTHSMELTEVENT_STAFF			256	// 속성제련된 베히모스의 우든 스태프를 보상아이템으로 교환

#define	MMI_MAPLE_TRADE					257	// 낙엽 교환하기
#define	MMI_MARKET_TRADE				258	// 거래 중개 메뉴

#define	MMI_USAKAWIBAWIBOCOUPON2011			259	// 호박 10개와 100,000 페냐를 가위바위보 쿠폰으로 교환

#define	MMI_TWOHANDEDWEAPONMERGE			260	// 양손 무기 합성
#define	MMI_TWOHANDEDWEAPONMERGE_CANCEL		261	// 양손 무기 합성 취소

#define	MMI_ELLDINPOTION			262	// 항아리 전용 UI


#define	MMI_COLOSSEUM_REWARD_MIX		263	//증표로 기타 보상 아이템 교환
#define	MMI_COLOSSEUM_REWARD_WEAPON_1	264	// 증표로 초급 투사의 무기 교환
#define	MMI_COLOSSEUM_REWARD_WEAPON_2	265	// 증표로 중급 투사의 무기 교환
#define	MMI_COLOSSEUM_REWARD_WEAPON_3	266	// 증표로 고급 투사의 무기 교환

#define	MMI_CRISTMASRUBETRADEMENU		267 //크리스 마스 토큰으로 아이템 교환

#define	MMI_LOOKCHANGE					268

#define	MMI_CHRISTMASENCHANTEVENTMENU		269	//크리스마스 제련 이벤트 교환 메뉴

#define	MMI_MARKETEXIT				270	//시장에서 마을로 이동 메뉴

#define	MMI_EVENT_2012HAPPYMONEYMENU		271	//2012해피머니 이벤트 메뉴

#define	MMI_POR_2012KAWIBAWIBOCUPONMENU		272	//2012가위바위보 이벤트_쿠폰 교환 메뉴

#define	MMI_SEAKINGLOOKCHANGEMENU		273	//용왕의상 성별 교환 메뉴

#define	MMI_SEAKINGMASKCHANGEMENU		274	//용왕가면(남) 옵션 교환 메뉴
#define	MMI_SEAKINGMASKCHANGEMENU_1		275	//용왕가면(여) 옵션 교환 메뉴

#define	MMI_FLYFFCOUPONSHOP			276	//프리프 쿠폰 교환 UI

#define	MMI_FLYFFPIECE_CHANGE		277

#define	MMI_MUSICFESTIVALETC		278	//뮤직페스티벌 음표
#define	MMI_MUSICFESTIVALGUITAR		279	//뮤직페스티벌 기타

//미국 길드전 이벤트(12.07.25 ~ 12.08.28)
#define MMI_ENGGUILDEVENTARMOR     280  //방어구 랜덤박스 교환
#define MMI_ENGGUILDEVENTWEA     281  //무기 랜덤박스 교환
#define MMI_ENGGUILDEVENTGCHIP     282 //기타 아이템 교환

#define MMI_SUMMERENCHANTEVENTMENU     283  //해외 제련 이벤트(12.07.31 ~ 12.09.25)

//크리스마스 곰인형
#define MMI_CHRISTMAS_BEARDOLL		284 // 크리스마스 곰인형 교환

#define MMI_CHRISTMAS_SNOW_GOLD		285 // 크리스마스 황금 눈의결정 교환

//크리스마스 제련 이벤트

#define MMI_CHRISTMASENCHANTEVENT		286 // 황금종 교환

//발렌타인 이벤트
#define MMI_VALENTAINEVENT		287 // 발렌타인 이벤트
#define MMI_VALENTAIN_QUPID		288 // 발렌타인 이벤트(변덕스러운 큐피드)

//화이트데이 남성 교환메뉴 추가
#define MMI_WHITEDAY_EXCHANGE05		289 //화이트 데이 교환
#define MMI_WHITEDAY_EXCHANGE06		290 //화이트 데이 교환
#define MMI_WHITEDAY_EXCHANGE07		291 //화이트 데이 교환
#define MMI_WHITEDAY_EXCHANGE08		292 //화이트 데이 교환

// 2014 할로윈 이벤트
#define	MMI_HALLOWEEN_EVENT_2014	293

// 2014 와인 이벤트
#define	MMI_WINE_EVENT_FLARIS_2014		294
#define	MMI_WINE_EVENT_SAINT_2014		295
#define	MMI_WINE_EVENT_DARKON_2014		296

// 2014 크리스마스 이벤트
#define	MMI_CHRISTMAS_EVENT_02_2014		297
#define	MMI_CHRISTMAS_EVENT_04_2014		298
#define	MMI_CHRISTMAS_EVENT_05_2014		299
#define	MMI_CHRISTMAS_EVENT_07_2014		300
#define	MMI_CHRISTMAS_EVENT_08_2014		301

// 2015 클로버 이벤트
#define	MMI_CLOVER_EVENT_2015			302

// 2015 웹젠.com 6주년 이벤트
#define	MMI_6TH_ANNIVERSARY_WEBZEN_WEAPON_EXCHANGE_2015			303
#define	MMI_6TH_ANNIVERSARY_WEBZEN_MALE_ARMOR_EXCHANGE_2015		304
#define	MMI_6TH_ANNIVERSARY_WEBZEN_FEMALE_ARMOR_EXCHANGE_2015	305

#define	MMI_JP_11TH_ANNIVERSARY_PIGGY_EXCHANGE_2015				306

#define 	MMI_MADRIGAL_TOUR_EXCHANGE					307

#define 	MMI_BARUNA_ULTIMATETRANS	308

#define		MMI_CARD_UPGRADE			309

#define 	MMI_COLLECT03                  	310 	// 카드 조각 교환

#define 	MMI_12TH_ANNIVERSARY_EXCHANGE01          	311
#define 	MMI_12TH_ANNIVERSARY_EXCHANGE02          	312


#define		MMI_COSTUME_EXCHANGE01		313		// 코스튬 교환
#define		MMI_COSTUME_EXCHANGE02		314
#define		MMI_COSTUME_EXCHANGE03		315
#define		MMI_COSTUME_EXCHANGE04		316
#define		MMI_COSTUME_EXCHANGE05		317
#define		MMI_COSTUME_EXCHANGE06		318
#define		MMI_COSTUME_EXCHANGE07		319

#define		MMI_WEAPONBOX_EXCHANGE01		320		// 2017 추석 아이템 교환
#define		MMI_ARMORBOX_EXCHANGE01		321		
#define		MMI_ARMORBOX_EXCHANGE02		322	

#define		MMI_SMELT_SAFETY_COSTUME	323

#define		MMI_SMELT_JEWEL_COSTUME		324 //제련 : 코스튬 아이템 보석 제련	

#define 	MMI_NPC_BUFF2					325 // 프리미엄 버프

#define		MMI_SMELT_REMOVE_JEWEL_COSTUME		326 	//제련 : 코스튬 아이템 보석 제거	

#define		MMI_SMELT_MIXCOSTUME			327 //제련 : 코스튬 합성

#define		MMI_SMELT_MIXMATERIAL			328	//제련 : 재료 합성

#define		MMI_155_LORDK_F_CHANGE		329	//여성용 로드 템플러 방어구 아이템 교환
#define		MMI_155_LORDK_M_CHANGE		330	//남성용 로드 템플러 방어구 아이템 교환
#define		MMI_155_STORMB_F_CHANGE		331	//여성용 스톰 블레이드 템플러 방어구 아이템 교환
#define		MMI_155_STORMB_M_CHANGE		332	//남성용 스톰 블레이드 템플러 방어구 아이템 교환
#define		MMI_155_CRACKS_F_CHANGE		333	//여성용 크랙슈터 방어구 아이템 교환
#define		MMI_155_CRACKS_M_CHANGE		334	//남성용 크랙슈터 방어구 아이템 교환
#define		MMI_155_WINDL_F_CHANGE		335	//여성용 윈드러커 방어구 아이템 교환
#define		MMI_155_WINDL_M_CHANGE		336	//남성용 윈드러커 방어구 아이템 교환
#define		MMI_155_FLOR_F_CHANGE		337	//여성용 플로리스트 방어구 아이템 교환
#define		MMI_155_FLOR_M_CHANGE		338	//남성용 플로리스트 방어구 아이템 교환
#define		MMI_155_FORCEM_F_CHANGE		339	//여성용 포스마스터 방어구 아이템 교환
#define		MMI_155_FORCEM_M_CHANGE		340	//남성용 포스마스터 방어구 아이템 교환
#define		MMI_155_MENT_F_CHANGE		341	//여성용 멘탈리스트 방어구 아이템 교환
#define		MMI_155_MENT_M_CHANGE		342	//남성용 멘탈리스트 방어구 아이템 교환
#define		MMI_155_ELEL_F_CHANGE		343	//여성용 엘리멘탈 로드 방어구 아이템 교환
#define		MMI_155_ELEL_M_CHANGE		344	//남성용 엘리멘탈 로드 방어구 아이템 교환
#define		MMI_155_LORDK_WEA_CHANGE	345	//로드 템플러 전용 무기 교환
#define		MMI_155_STORMB_WEA_CHANGE	346	//스톰 블레이드 전용 무기 교환
#define		MMI_155_CRACKS_WEA_CHANGE	347	//크랙슈터 전용 무기 교환
#define		MMI_155_WINDL_WEA_CHANGE	348	//윈드러커 전용 무기 교환
#define		MMI_155_FLOR_WEA_CHANGE		349	//플로리스트 전용 무기 교환
#define		MMI_155_FORCEM_WEA_CHANGE	350	//포스마스터 전용 무기 교환
#define		MMI_155_MENT_WEA_CHANGE		351	//멘탈리스트 전용 무기 교환
#define		MMI_155_ELEL_WEA_CHANGE		352	//엘리멘탈 로드 전용 무기 교환
#define		MMI_155_SHEILD_BOOK_CHANGE		353	//방패 및 책 교환
#define		MMI_GUILD_COIN		354	//길드 대전 코인

#define		MMI_SMELT_SAFETY_GENERAL_BARUNA	355
#define		MMI_SMELT_SAFETY_PIERCING_BARUNA	356
#define		MMI_SMELT_JEWEL_BARUNA				357

#define MMI_SMELT_REMOVE_PIERCING_BARUNA		358 // 슈트의 피어싱 옵션 제거

#define MMI_SMELT_REMOVE_JEWEL_BARUNA			359

#define MMI_CARD_EXCHANGE			360
#define MMI_BARUNA_CARD_EXCHANGE			361

#define	MMI_FLYCOIN_CASH_COSTUME	362
#define	MMI_FLYCOIN_CASH_PET	363
#define	MMI_FLYCOIN_CASH_CONVENIENCE	364
#define	MMI_FLYCOIN_CASH_PARTY	365
#define	MMI_FLYCOIN_CASH_BUFF	366
#define	MMI_FLYCOIN_CASH_UPGRADE	367
#define	MMI_FLYCOIN_CASH_PRIMIUM	368
#define	MMI_FLYCOIN_CASH_RIDE	369
#define	MMI_FLYCOIN_CASH_FECOSTUME	370
#define	MMI_FLYCOIN_CASH_BARUNA	371

#define	MMI_DRAGONQUEEN_M	372	// 필리핀 옥토버 페스티벌
#define	MMI_DRAGONQUEEN_F	373

#define	MMI_HALLOWEENQUEEN	374	// 2019년 할로윈 이벤트

#define	MMI_OCTORBERPH_1	375	// 필리핀 10월 출석
#define	MMI_OCTORBERPH_2	376	// 필리핀 10월 출석
#define	MMI_HALLOWEENQUEEN_PH	377	// 2019년 필리핀 할로윈 이벤트

#define	MMI_CHIRSTMASPH_1	378	// 2019 필리핀 크리스마스 교환
#define	MMI_CHIRSTMASPH_2	379	// 2019 필리핀 크리스마스 교환
#define	MMI_CHIRSTMASPH_3	380	// 2019 필리핀 크리스마스 교환

#define	MMI_NEWYEAR2020	381	// 필리핀 2020 신년 이벤트

#define	MMI_TWNEWSERVER1	382	// 대만 신규 서버 이벤트
#define	MMI_TWNEWSERVER2	383	// 대만 신규 서버 이벤트

#define	MMI_VALENTINE2020	384

#define	MMI_SAINT2020	385

#define	MMI_SUMMER2020	386	// 필리핀 2020 여름 이벤트

#define	MMI_DEVILWEAPON	387	// 데빌 웨폰 교환
#define	MMI_DEVILWEAPON_QUE	388	// 데빌 웨폰 교환(퀘재료)

#define	MMI_GROWGREEN	389	// 필리핀 식목일

#define	MMI_WEDDING	390	// 2020 웨딩 이벤트

#define	MMI_SUMMER	391	// 2020 섬머 이벤트

#define	MMI_TREASUREPH	392	// 2020 섬머 이벤트

#define	MMI_DEVILARMOR	393	// 데빌 아머 교환

#define	MMI_DRAGONWINGVIP	394	// VIP 교환 메뉴
#define	MMI_VIPHORNOR	395	
#define	MMI_VIIPSUNGLASS	396	
#define	MMI_DEVILWPTIKET	397	
#define	MMI_METEONIKERSET	398	
#define	MMI_METEONIKERCLOAK	399	
#define	MMI_METEONIKERMASK	400	
#define	MMI_RTIERBX	401	
#define	MMI_DRAGONWING	402	
#define	MMI_COSTUMEBX	403	
#define	MMI_ALTAIRBX	404	
#define	MMI_ARTIFACTBX	405	
#define	MMI_DEVILCLOAK	406	

#define	MMI_NINJAEVE	407	// 필리핀 닌자 이벤트

#define	MMI_CHRISTMAS_EVENT_2020	408	// 2020 크리스마스 제련 이벤트

#define	MMI_GUILDWIN_COIN	409	// 길드 우승
#define	MMI_GUILD_COIN_NEW		410	//길드 대전 코인 추가

#define	MMI_TEDDYBEAR		411	//크리스마스 교환
#define	MMI_CHRISTTREE		412
#define	MMI_CHRISTWORK		413
#define	MMI_GOLDAPPLE		414
#define	MMI_CHRISTFAIRY		415
#define	MMI_SANTA		416

#define	MMI_JESSICA	417
#define	MMI_NANA	418

#define	MMI_BORAEGG_EVENT	419
#define	MMI_BORARING_EVENT	420

#define	MMI_FAIRY_EVENT	421

#define	MMI_BORAJAPAN_EVENT	422

#define	MMI_BORA_ACCESSORY	423
#define	MMI_BORA_DRAGON	424

#define	MMI_TAIWANOPEN	425

#define	MMI_ELF_EVENT	426

#define	MMI_STAR_EVENT	427

#define	MMI_LITA_EVENT	428

#define	MMI_PHMERGE	429

#define	MMI_MOONCAKE_EVENT	430

#define	MMI_1STANNIVERSARY	431

#define	MMI_THANKSGIVING_CAKE	432

#define	MMI_THANKSGIVING_BALL	433

#define	MMI_HALLOWEENTW	434

#define	MMI_HALLOWEENPH	435

#define	MMI_LEAFEXCHANGETW	436

#define	MMI_DUNGEONTICKETONE	437

#define	MMI_DUNGEONTICKETTWO	438

#define	MMI_LOTTOTICKET	439

#define	MMI_FARMER	440

#define	MMI_GABITOKEN	441

#define	MMI_DEATHCLOAK	442

#define	MMI_NEWYEAR2022	443

#define	MMI_NEWYEAR2022_TW_1	444

#define	MMI_NEWYEAR2022_TW_2	445

#define	MMI_SRCARDCHANGE	446
#define	MMI_18CARDCHANGE	447
#define	MMI_STRBARUNACHANGE	448
#define	MMI_INTBARUNACHANGE	449
#define	MMI_DEXBARUNACHANGE	450
#define	MMI_STABARUNACHANGE	451
#define	MMI_SUNGLASSCHANGE	452

#define	MMI_FULLMOON	453

#define	MMI_CATEVENT	454

#define MAX_MOVER_MENU				800	// MMI를 추가시킬 일이 있다면 이 수치를 상승시켜야 한다.

/*
====================================================================================================
MMI 메뉴 종료
====================================================================================================
*/

#define MGI_APPELL_UP		0	// 호칭 업
#define MGI_APPELL_DOWN		1
#define MGI_CLASS_UP		2	// 등급 업
#define MGI_CLASS_DOWN		3
#define MGI_GUILD_LEAVE		4	// 탈퇴
#define MGI_NICKNAME		5	// 별칭 부여.
#define MGI_CHG_MASTER		6	// 길드마스터 변경

#define MGI_GUILD_MENU		7

// 모션과 액션
#define MOT_BASE_NONE            0
#define MOT_BASE_BATTLE          1
#define MOT_BASE_SIT             2
#define MOT_BASE_PICKUP          3
#define MOT_BASE_HANDSHAKE       4
#define MOT_BASE_AMBIGUOUS       5
#define MOT_BASE_YES             6
#define MOT_BASE_NO              7
#define MOT_BASE_SPRINT          8
#define MOT_BASE_PARADEREST      9
#define MOT_BASE_ATTENTION      10
#define MOT_BASE_SCISSORS       11
#define MOT_BASE_ROCK           12
#define MOT_BASE_PAPER          13
#define MOT_BASE_POINTWAYNORTH  14
#define MOT_BASE_POINTWAYSOUTH  15
#define MOT_BASE_POINTWAYEAST   16
#define MOT_BASE_POINTWAYWEST   17
#define MOT_BASE_KNEEDOWN       18
#define MOT_BASE_PUSHUP         19
#define MOT_BASE_HIPKIDDING     20
#define MOT_BASE_JAB            21
#define MOT_BASE_HEAD           22
#define MOT_BASE_RISESWORD      23
#define MOT_BASE_COLLECT        24
#define MOT_BASE_ESCAPE         25
#define MOT_BASE_CHEER          26
#define MOT_BASE_AUTOATTACK		27
#define MOT_BASE_COUPLE			28


// 일반 동작 
#define	MTI_STAND               0
#define	MTI_IDLE1               1
#define	MTI_IDLE2               2 
#define	MTI_WALK                3
#define MTI_BACK                4
#define	MTI_RUN                 5
#define	MTI_DMG1                6
#define	MTI_DMG2                7
#define	MTI_DIE1                8  
#define	MTI_DMGLIVE             9 
#define	MTI_DMGDIE              10 
#define	MTI_DMGFLY              11
#define	MTI_GROGGY              12
#define	MTI_JUMP1               13
#define	MTI_JUMP2               14
#define	MTI_JUMP3               15
#define	MTI_JUMP4               16
#define	MTI_IN				    17
#define	MTI_OUT				    18
#define	MTI_SWIM                19
#define	MTI_SIT                 20
#define	MTI_SITSTAND            21
#define	MTI_GETUP               22
#define	MTI_ATK1                23
#define	MTI_ATK2                24
#define	MTI_ATK3                25
#define	MTI_ATK4                26
#define	MTI_ATK5                27
#define	MTI_ATK6                28
#define	MTI_ATK7                29
#define	MTI_ATK8                30

#define	MTI_FSTAND1_A           31 
#define	MTI_FIDLE1_A            32 //
#define	MTI_FIDLE2_A            33 //
#define	MTI_FLTURN1_A           34
#define	MTI_FLTURN2_A           35 //
#define	MTI_FRTURN1_A           36 
#define	MTI_FRTURN2_A           37 // 
#define	MTI_FRUNNING1_A         38 //  
#define	MTI_FRUNNING2_A         39 /// 
#define MTI_FDMG1_A             40
#define MTI_FATK1_A             41
#define MTI_FATK2_A             42
#define MTI_FATK3_A             43

#define	MTI_FSTAND1_B           61 
#define	MTI_FIDLE1_B            62 //
#define	MTI_FIDLE2_B            63 //
#define	MTI_FLTURN1_B           64
#define	MTI_FLTURN2_B           65 //
#define	MTI_FRTURN1_B           66 
#define	MTI_FRTURN2_B           67 // 
#define	MTI_FRUNNING1_B         68 //  
#define	MTI_FRUNNING2_B         69 /// 
#define MTI_FDMG1_B             70
#define MTI_FATK1_B             71
#define MTI_FATK2_B             72
#define MTI_FATK3_B             73

#define	MTI_FSTAND1_C           91 
#define	MTI_FIDLE1_C            92 //
#define	MTI_FIDLE2_C            93 //
#define	MTI_FLTURN1_C           94
#define	MTI_FLTURN2_C           95 //
#define	MTI_FRTURN1_C           96 
#define	MTI_FRTURN2_C           97 // 
#define	MTI_FRUNNING1_C         98 //  
#define	MTI_FRUNNING2_C         99 /// 
#define MTI_FDMG1_C            100
#define MTI_FATK1_C            101
#define MTI_FATK2_C            102
#define MTI_FATK3_C            103

#define MTI_PICKUP             121 // 모션인덱스도 현재 저장하므로 번호를 바꿀수가 없다. 위에 끼워넣을곳도 없다. -xuzhu-
#define MTI_HANDSHAKE          122
#define MTI_AMBIGUOUS          123
#define MTI_YES                124
#define MTI_NO                 125
#define MTI_SPRINT             126
#define MTI_PARADEREST         127
#define MTI_ATTENTION          128
#define MTI_SCISSORS           129
#define MTI_ROCK               130
#define MTI_PAPER              131
#define MTI_POINTWAYNORTH      132
#define MTI_POINTWAYSOUTH      133
#define MTI_POINTWAYEAST       134
#define MTI_POINTWAYWEST       135
#define MTI_KNEEDOWN           136
#define MTI_PUSHUP             137
#define MTI_HIPKIDDING         138
#define MTI_JAB                139
#define MTI_HEAD               140
#define MTI_RISESWORD          141
#define MTI_COLLECT			   142 // 채집 모션
#define MTI_APPEAR			   143 // 등장 모션
#define MTI_APPEAR2			   144 // 등장 모션2
#define MTI_CHEERSAME		   145 //동성 응원 모션
#define MTI_CHEEROTHER		   146 //이성 응원 모션
#define MTI_FALL			   147 



#define	MTI_LOGOUT             194
#define	MTI_ACCLAIM            195
#define	MTI_CLAPDOWN           196
#define	MTI_CLAPUP             197
#define	MTI_LEVELUP            198
#define	MTI_STAND2             199 // 캐릭터 선택화면에서 포니테일을 캐릭터 뒤로 나오게 하기 위해 별도로 입력
#define MTI_FLYWALK	       231 // 사이키퍼 엘레멘터 이동
#define MTI_FLYBACK	       232 // 사이키퍼 엘레멘터 이동
#define MTI_FLYRUN	       233 // 사이키퍼 엘레멘터 이동

// Sworld 전투 모드 동작 
#define	MTI_STAND_01           200
#define	MTI_IDLE1_01           201
#define	MTI_IDLE2_01           202
#define	MTI_WALK_01            203
#define MTI_BACK_01            204
#define	MTI_RUN_01             205
#define	MTI_DMG1_01            206
#define	MTI_DMG2_01            207
#define	MTI_DIE1_01            208
#define	MTI_DMGLIVE_01         209
#define	MTI_DMGDIE_01          210 
#define	MTI_DMGFLY_01          211
#define	MTI_GROGGY_01          212
#define	MTI_JUMP1_01           213
#define	MTI_JUMP2_01           214
#define	MTI_JUMP3_01           215
#define	MTI_JUMP4_01           216
#define	MTI_IN_01              217
#define	MTI_OUT_01             218
#define	MTI_SWIM_01            219
#define	MTI_SIT_01             220
#define	MTI_SITSTAND_01        221
#define	MTI_GETUP_01           222
#define	MTI_ATK1_01            223
#define	MTI_ATK2_01            224
#define	MTI_ATK3_01            225
#define	MTI_ATK4_01            226
#define	MTI_ATK5_01            227
#define	MTI_ATK6_01            228
#define	MTI_ATK7_01            229
#define	MTI_ATK8_01            230 

// 완드 전투 모드 동작 
#define	MTI_STAND_02           300
#define	MTI_IDLE1_02           301
#define	MTI_IDLE2_02           302
#define	MTI_WALK_02            303
#define	MTI_BACK_02            304
#define	MTI_RUN_02             305
#define	MTI_DMG1_02            306
#define	MTI_DMG2_02            307
#define	MTI_DIE1_02            308
#define	MTI_DMGLIVE_02         309
#define	MTI_DMGDIE_02          310
#define	MTI_DMGFLY_02          311
#define	MTI_GROGGY_02          312
#define	MTI_JUMP1_02           313
#define	MTI_JUMP2_02           314
#define	MTI_JUMP3_02           315
#define	MTI_JUMP4_02           316
#define	MTI_IN_02              317
#define	MTI_OUT_02             318
#define	MTI_SWIM_02            319
#define	MTI_SIT_02             320
#define	MTI_SITSTAND_02        321
#define	MTI_GETUP_02           322
#define	MTI_ATK1_02            323
#define	MTI_ATK2_02            324
#define	MTI_ATK3_02            325
#define	MTI_ATK4_02            326
#define	MTI_ATK5_02            327
#define	MTI_ATK6_02            328
#define	MTI_ATK7_02            329
#define	MTI_ATK8_02            330

// 치어봉 전투 모드 동작 
#define	MTI_STAND_03           400
#define	MTI_IDLE1_03           401
#define	MTI_IDLE2_03           402
#define	MTI_WALK_03            403
#define	MTI_BACK_03            404
#define	MTI_RUN_03             405
#define	MTI_DMG1_03            406
#define	MTI_DMG2_03            407
#define	MTI_DIE1_03            408
#define	MTI_DMGLIVE_03         409
#define	MTI_DMGDIE_03          410
#define	MTI_DMGFLY_03          411
#define	MTI_GROGGY_03          412
#define	MTI_JUMP1_03           413
#define	MTI_JUMP2_03           414
#define	MTI_JUMP3_03           415
#define	MTI_JUMP4_03           416
#define	MTI_IN_03			   417
#define	MTI_OUT_03			   418
#define	MTI_SWIM_03            419
#define	MTI_SIT_03             420
#define	MTI_SITSTAND_03        421
#define	MTI_GETUP_03           422
#define	MTI_ATK1_03            423
#define	MTI_ATK2_03            424
#define	MTI_ATK3_03            425
#define	MTI_ATK4_03            426
#define	MTI_ATK5_03            427
#define	MTI_ATK6_03            428
#define	MTI_ATK7_03            429
#define	MTI_ATK8_03            430

// 엑스 전투 모드 동작 
#define	MTI_STAND_04           500
#define	MTI_IDLE1_04           501
#define	MTI_IDLE2_04           502
#define	MTI_WALK_04            503
#define	MTI_BACK_04            504
#define	MTI_RUN_04             505
#define	MTI_DMG1_04            506
#define	MTI_DMG2_04            507
#define	MTI_DIE1_04            508
#define	MTI_DMGLIVE_04         509
#define	MTI_DMGDIE_04          510
#define	MTI_DMGFLY_04          511
#define	MTI_GROGGY_04          512
#define	MTI_JUMP1_04           513
#define	MTI_JUMP2_04           514
#define	MTI_JUMP3_04           515
#define	MTI_JUMP4_04           516
#define	MTI_IN_04			   517
#define	MTI_OUT_04			   518
#define	MTI_SWIM_04            519
#define	MTI_SIT_04             520
#define	MTI_SITSTAND_04        521
#define	MTI_GETUP_04           522
#define	MTI_ATK1_04            523
#define	MTI_ATK2_04            524
#define	MTI_ATK3_04            525
#define	MTI_ATK4_04            526
#define	MTI_ATK5_04            527
#define	MTI_ATK6_04            528
#define	MTI_ATK7_04            529
#define	MTI_ATK8_04            530

// 스태프 전투 모드 동작 
#define	MTI_STAND_05           600
#define	MTI_IDLE1_05           601
#define	MTI_IDLE2_05           602
#define	MTI_WALK_05            603
#define	MTI_BACK_05            604
#define	MTI_RUN_05             605
#define	MTI_DMG1_05            606
#define	MTI_DMG2_05            607
#define	MTI_DIE1_05            608
#define	MTI_DMGLIVE_05         609
#define	MTI_DMGDIE_05          610
#define	MTI_DMGFLY_05          611
#define	MTI_GROGGY_05          612
#define	MTI_JUMP1_05           613
#define	MTI_JUMP2_05           614
#define	MTI_JUMP3_05           615
#define	MTI_JUMP4_05           616
#define	MTI_IN_05			   617
#define	MTI_OUT_05			   618
#define	MTI_SWIM_05            619
#define	MTI_SIT_05             620
#define	MTI_SITSTAND_05        621
#define	MTI_GETUP_05           622
#define	MTI_ATK1_05            623
#define	MTI_ATK2_05            624
#define	MTI_ATK3_05            625
#define	MTI_ATK4_05            626
#define	MTI_ATK5_05            627
#define	MTI_ATK6_05            628
#define	MTI_ATK7_05            629
#define	MTI_ATK8_05            630

// 너클해머 전투 모드 동작 
#define	MTI_STAND_06           700
#define	MTI_IDLE1_06           701
#define	MTI_IDLE2_06           702
#define	MTI_WALK_06            703
#define	MTI_BACK_06            704
#define	MTI_RUN_06             705
#define	MTI_DMG1_06            706
#define	MTI_DMG2_06            707
#define	MTI_DIE1_06            708
#define	MTI_DMGLIVE_06         709
#define	MTI_DMGDIE_06          710
#define	MTI_DMGFLY_06          711
#define	MTI_GROGGY_06          712
#define	MTI_JUMP1_06           713
#define	MTI_JUMP2_06           714
#define	MTI_JUMP3_06           715
#define	MTI_JUMP4_06           716
#define	MTI_IN_06			   717
#define	MTI_OUT_06			   718
#define	MTI_SWIM_06            719
#define	MTI_SIT_06             720
#define	MTI_SITSTAND_06        721
#define	MTI_GETUP_06           722
#define	MTI_ATK1_06            723
#define	MTI_ATK2_06            724
#define	MTI_ATK3_06            725
#define	MTI_ATK4_06            726
#define	MTI_ATK5_06            727
#define	MTI_ATK6_06            728
#define	MTI_ATK7_06            729
#define	MTI_ATK8_06            730

// 양손  양손도끼 전투 동작
#define	MTI_STAND_07           800
#define	MTI_IDLE1_07           801
#define	MTI_IDLE2_07           802
#define	MTI_WALK_07            803
#define	MTI_BACK_07            804
#define	MTI_RUN_07             805
#define	MTI_DMG1_07            806
#define	MTI_DMG2_07            807
#define	MTI_DIE1_07            808
#define	MTI_DMGLIVE_07         809
#define	MTI_DMGDIE_07          810
#define	MTI_DMGFLY_07          811
#define	MTI_GROGGY_07          812
#define	MTI_JUMP1_07           813
#define	MTI_JUMP2_07           814
#define	MTI_JUMP3_07           815
#define	MTI_JUMP4_07           816
#define	MTI_IN_07			   817
#define	MTI_OUT_07			   818
#define	MTI_SWIM_07            819
#define	MTI_SIT_07             820
#define	MTI_SITSTAND_07        821
#define	MTI_GETUP_07           822
#define	MTI_ATK1_07            823
#define	MTI_ATK2_07            824
#define	MTI_ATK3_07            825
#define	MTI_ATK4_07            826
#define	MTI_ATK5_07            827
#define	MTI_ATK6_07            828
#define	MTI_ATK7_07            829
#define	MTI_ATK8_07            830

// 이도류 전투동작
#define	MTI_STAND_08           900
#define	MTI_IDLE1_08           901
#define	MTI_IDLE2_08           902
#define	MTI_WALK_08            903
#define	MTI_BACK_08            904
#define	MTI_RUN_08             905
#define	MTI_DMG1_08            906
#define	MTI_DMG2_08            907
#define	MTI_DIE1_08            908
#define	MTI_DMGLIVE_08         909
#define	MTI_DMGDIE_08          910
#define	MTI_DMGFLY_08          911
#define	MTI_GROGGY_08          912
#define	MTI_JUMP1_08           913
#define	MTI_JUMP2_08           914
#define	MTI_JUMP3_08           915
#define	MTI_JUMP4_08           916
#define	MTI_IN_08			   917
#define	MTI_OUT_08			   918
#define	MTI_SWIM_08            919
#define	MTI_SIT_08             920
#define	MTI_SITSTAND_08        921
#define	MTI_GETUP_08           922
#define	MTI_ATK1_08            923
#define	MTI_ATK2_08            924
#define	MTI_ATK3_08            925
#define	MTI_ATK4_08            926
#define	MTI_ATK5_08            927
#define	MTI_ATK6_08            928
#define	MTI_ATK7_08            929
#define	MTI_ATK8_08            930

// 링마스터 스틱 전투동작
#define	MTI_STAND_09           2000
#define	MTI_IDLE1_09           2001
#define	MTI_IDLE2_09           2002
#define	MTI_WALK_09            2003
#define	MTI_BACK_09            2004
#define	MTI_RUN_09             2005
#define	MTI_DMG1_09            2006
#define	MTI_DMG2_09            2007
#define	MTI_DIE1_09            2008
#define	MTI_DMGLIVE_09         2009
#define	MTI_DMGDIE_09          2010
#define	MTI_DMGFLY_09          2011
#define	MTI_GROGGY_09          2012
#define	MTI_JUMP1_09           2013
#define	MTI_JUMP2_09           2014
#define	MTI_JUMP3_09           2015
#define	MTI_JUMP4_09           2016
#define	MTI_IN_09	       2017
#define	MTI_OUT_09	       2018
#define	MTI_SWIM_09            2019
#define	MTI_SIT_09             2020
#define	MTI_SITSTAND_09        2021
#define	MTI_GETUP_09           2022
#define	MTI_ATK1_09            2023
#define	MTI_ATK2_09            2024
#define	MTI_ATK3_09            2025
#define	MTI_ATK5_09            2026
#define	MTI_ATK6_09            2027
#define	MTI_ATK7_09            2028
#define	MTI_ATK8_09            2029

// 빌 포스터 너클 전투동작
#define	MTI_STAND_10           2100
#define	MTI_IDLE1_10           2101
#define	MTI_IDLE2_10           2102
#define	MTI_WALK_10            2103
#define	MTI_BACK_10            2104
#define	MTI_RUN_10             2105
#define	MTI_DMG1_10            2106
#define	MTI_DMG2_10            2107
#define	MTI_DIE1_10            2108
#define	MTI_DMGLIVE_10         2109
#define	MTI_DMGDIE_10          2110
#define	MTI_DMGFLY_10          2111
#define	MTI_GROGGY_10          2112
#define	MTI_JUMP1_10           2113
#define	MTI_JUMP2_10           2114
#define	MTI_JUMP3_10           2115
#define	MTI_JUMP4_10           2116
#define	MTI_IN_10	       2117
#define	MTI_OUT_10	       2118
#define	MTI_SWIM_10            2119
#define	MTI_SIT_10             2120
#define	MTI_SITSTAND_10        2121
#define	MTI_GETUP_10           2122
#define	MTI_ATK1_10            2123
#define	MTI_ATK2_10            2124
#define	MTI_ATK3_10            2125
#define	MTI_ATK4_10            2126
#define	MTI_ATK5_10            2127
#define	MTI_ATK6_10            2128
#define	MTI_ATK7_10            2129
#define	MTI_ATK8_10            2130

// 사이키퍼 완드 전투동작
#define	MTI_STAND_11           2200
#define	MTI_IDLE1_11           2201
#define	MTI_IDLE2_11           2202
#define	MTI_WALK_11            2203
#define	MTI_BACK_11            2204
#define	MTI_RUN_11             2205
#define	MTI_DMG1_11            2206
#define	MTI_DMG2_11            2207
#define	MTI_DIE1_11            2208
#define	MTI_DMGLIVE_11         2209
#define	MTI_DMGDIE_11          2210
#define	MTI_DMGFLY_11          2211
#define	MTI_GROGGY_11          2212
#define	MTI_JUMP1_11           2213
#define	MTI_JUMP2_11           2214
#define	MTI_JUMP3_11           2215
#define	MTI_JUMP4_11           2216
#define	MTI_IN_11	       2217
#define	MTI_OUT_11	       2218
#define	MTI_SWIM_11            2219
#define	MTI_SIT_11             2220
#define	MTI_SITSTAND_11        2221
#define	MTI_GETUP_11           2222
#define	MTI_ATK_11             2223
#define	MTI_ATK5_11            2224
#define	MTI_ATK6_11            2225
#define	MTI_ATK7_11            2226
#define	MTI_ATK8_11            2227

// 엘레멘터 스태프 전투동작
#define	MTI_STAND_12           2300
#define	MTI_IDLE1_12           2301
#define	MTI_IDLE2_12           2302
#define	MTI_WALK_12            2303
#define	MTI_BACK_12            2304
#define	MTI_RUN_12             2305
#define	MTI_DMG1_12            2306
#define	MTI_DMG2_12            2307
#define	MTI_DIE1_12            2308
#define	MTI_DMGLIVE_12         2309
#define	MTI_DMGDIE_12          2310
#define	MTI_DMGFLY_12          2311
#define	MTI_GROGGY_12          2312
#define	MTI_JUMP1_12           2313
#define	MTI_JUMP2_12           2314
#define	MTI_JUMP3_12           2315
#define	MTI_JUMP4_12           2316
#define	MTI_IN_12	       2317
#define	MTI_OUT_12	       2318
#define	MTI_SWIM_12            2319
#define	MTI_SIT_12             2320
#define	MTI_SITSTAND_12        2321
#define	MTI_GETUP_12           2322
#define	MTI_ATK_12             2323
#define	MTI_ATK5_12            2324
#define	MTI_ATK6_12            2325
#define	MTI_ATK7_12            2326
#define	MTI_ATK8_12            2327

// 아크로뱃 활 전투동작
#define	MTI_STAND_13	       2328
#define	MTI_IDLE1_13	       2329
#define	MTI_IDLE2_13	       2330
#define	MTI_WALK_13	       2331
#define	MTI_BACK_13	       2332
#define	MTI_RUN_13	       2333
#define	MTI_DMG1_13	       2334
#define	MTI_DMG2_13	       2335
#define	MTI_DIE1_13	       2336
#define	MTI_DMGLIVE_13	       2337
#define	MTI_DMGDIE_13	       2338
#define	MTI_DMGFLY_13	       2339
#define	MTI_GROGGY_13	       2340
#define	MTI_JUMP1_13	       2341
#define	MTI_JUMP2_13	       2342
#define	MTI_JUMP3_13	       2343
#define	MTI_JUMP4_13	       2344
#define	MTI_IN_13	       2345
#define	MTI_OUT_13	       2346
#define	MTI_SWIM_13 	       2347
#define	MTI_SIT_13	       2348
#define	MTI_SITSTAND_13	       2349
#define	MTI_GETUP_13	       2350
#define	MTI_ATK_13	       2351
#define	MTI_ATK5_13	       2352
#define	MTI_ATK6_13	       2353
#define	MTI_ATK7_13	       2354
#define	MTI_ATK8_13	       2355

//아크로뱃 요요 전투동작
#define	MTI_STAND_14	       2356
#define	MTI_IDLE1_14	       2357
#define	MTI_IDLE2_14	       2358
#define	MTI_WALK_14	       2359
#define	MTI_BACK_14	       2360
#define	MTI_RUN_14	       2361
#define	MTI_DMG1_14	       2362
#define	MTI_DMG2_14	       2363
#define	MTI_DIE1_14	       2364
#define	MTI_DMGLIVE_14	       2365
#define	MTI_DMGDIE_14	       2366
#define	MTI_DMGFLY_14	       2367
#define	MTI_GROGGY_14	       2368
#define	MTI_JUMP1_14	       2369
#define	MTI_JUMP2_14	       2370
#define	MTI_JUMP3_14	       2371
#define	MTI_JUMP4_14	       2372
#define	MTI_IN_14	       2373
#define	MTI_OUT_14	       2374
#define	MTI_SWIM_14 	       2375
#define	MTI_SIT_14	       2376
#define	MTI_SITSTAND_14	       2377
#define	MTI_GETUP_14	       2378
#define	MTI_ATK1_14	       2379
#define	MTI_ATK2_14	       2380
#define	MTI_ATK5_14	       2381
#define	MTI_ATK6_14	       2382
#define	MTI_ATK7_14	       2383
#define	MTI_ATK8_14	       2384

//크랙슈터 석궁 전투동작
#define	MTI_STAND_15	2385
#define	MTI_IDLE1_15	2386
#define	MTI_IDLE2_15	2387
#define	MTI_WALK_15		2388
#define	MTI_BACK_15		2389
#define	MTI_RUN_15		2390
#define	MTI_DMG1_15		2391
#define	MTI_DMG2_15		2392
#define	MTI_DIE1_15		2393
#define	MTI_DMGLIVE_15	2394
#define	MTI_DMGDIE_15	2395
#define	MTI_DMGFLY_15	2396
#define	MTI_GROGGY_15	2397
#define	MTI_JUMP1_15	2398
#define	MTI_JUMP2_15	2399
#define	MTI_JUMP3_15	2400
#define	MTI_JUMP4_15	2401
#define	MTI_IN_15		2402
#define	MTI_OUT_15		2403
#define	MTI_SWIM_15 	2404
#define	MTI_SIT_15		2405
#define	MTI_SITSTAND_15	2406
#define	MTI_GETUP_15	2407
#define	MTI_ATK1_15		2408
#define	MTI_ATK2_15		2409
#define	MTI_ATK5_15		2410
#define	MTI_ATK6_15		2411
#define	MTI_ATK7_15		2412
#define	MTI_ATK8_15		2413


// 특정 동작에 추가적으로 더해져서 완성된 모션 인덱스를 만든다.
// MTI_FDOWN1 = MTI_FSTAND1 + MTA_FDOWN
#define	MTA_FSTAND1         0 
#define	MTA_FIDLE1          1
#define	MTA_FIDLE2          2
#define	MTA_FLTURN1         3
#define	MTA_FLTURN2         4
#define	MTA_FRTURN1         5
#define	MTA_FRTURN2         6 
#define	MTA_FRUNNING1       7  
#define	MTA_FRUNNING2       8 
#define MTA_FDMG1			9
#define MTA_FATK1			10
#define MTA_FATK2			11
#define MTA_FATK3			12

// 여기부터 스킬 동작 추가
// 방랑자 계열 
#define MTI_VAG_ONE_CLEANHIT                1000
#define MTI_VAG_ONE_BRANDISH                1001
#define MTI_VAG_ONE_OVERCUTTER              1002

// 머서너리 계열 
#define MTI_MER_ONE_SPLMASH                 1003
#define MTI_MER_ONE_KEENWHEEL               1004
#define MTI_MER_ONE_BLINDSIDE               1005
#define MTI_MER_ONE_SPECIAL     	1006
#define MTI_MER_ONE_SNAKE	        1007
#define MTI_MER_SHIELD_PROTECTION           1008
#define MTI_MER_SHIELD_PANBARRIER           1009
#define MTI_MER_ONE_BLOODYSTRIKE            1010 


// 어시스트 계열 
#define MTI_ASS_HEAL_CASTING01              1043
#define MTI_ASS_HEAL_CASTING02              1044
#define MTI_ASS_HEAL_CASTING03              1045
#define MTI_ASS_CHEER_CASTING01             1046
#define MTI_ASS_CHEER_CASTING02             1047
#define MTI_ASS_CHEER_CASTING03             1048
#define MTI_ASS_RESURRECTION		    1049
#define MTI_ASS_RES_CASTING01		    1050
#define MTI_ASS_RES_CASTING02		    1051
#define MTI_ASS_RES_CASTING03		    1052
#define MTI_ASS_KNU_POWERFIST		    1053

//  매지션 계열 
#define MTI_MAG_FIRE_CASTING01		1063
#define MTI_MAG_FIRE_CASTING02		1064
#define MTI_MAG_FIRE_CASTING03		1065
#define MTI_MAG_WIND_CASTING01		1066
#define MTI_MAG_WIND_CASTING02		1067
#define MTI_MAG_WIND_CASTING03		1068




#define MTI_ASS_KNU_BURSTCRACK              1103 // 추가 어시스트 너클스킬
#define MTI_ASS_KNU_TAMPINGHOLE             1104 // 추가 어시스트 너클스킬


//나이트
#define	MTI_KNT_SUP_CASTING01			1105
#define	MTI_KNT_TWO_POWERSWING01		1106
#define	MTI_KNT_TWOSW_EARTHDIVIDER01	1107
#define	MTI_KNT_TWOSW_CHARGE01			1108
#define	MTI_KNT_TWOAX_PAINDEALER01		1109
#define	MTI_KNT_TWOAX_POWERSTUMP01		1110

//블레이드
#define	MTI_BLD_DOUBLE_CROSSSTRIKE01		1111
#define	MTI_BLD_DOUBLE_ARMORPENETRATE01		1112
#define	MTI_BLD_DOUBLESW_SILENTSTRIKE01		1113
#define	MTI_BLD_DOUBLESW_BLADEDANCE01		1114
#define	MTI_BLD_DOUBLEAX_SPRINGATTAKE01		1115
#define	MTI_BLD_DOUBLEAX_HAWKATTAKE01		1116
#define	MTI_BLD_DOUBLE_SONICBLADE01		1117
#define	MTI_BLD_SUP_CASTING01			1118

//링마스터
#define	MTI_RIN_HEAL_CASTING01			1119
#define	MTI_RIN_HEAL_CASTING02			1120
#define	MTI_RIN_HEAL_CASTING03			1121
#define	MTI_RIN_SUP_CASTING01			1122
#define	MTI_RIN_SUP_CASTING02			1123
#define	MTI_RIN_SUP_CASTING03			1124
#define	MTI_RIN_HEAL_CURE01			1125
#define	MTI_RIN_HEAL_CURE02			1126
#define	MTI_RIN_HEAL_CURE03			1127
#define	MTI_RIN_SQU_CASTING01			1128
#define	MTI_RIN_SQU_CASTING02			1129
#define	MTI_RIN_SQU_CASTING03			1130
				
//빌포스터				
#define	MTI_BIL_KNU_BELIALSMESHING01			1131
#define	MTI_BIL_KNU_PIERCINGSERPENT01			1132
#define	MTI_BIL_KNU_BLOODFIST01			1133
#define	MTI_BIL_KNU_SONICHAND01			1134
#define	MTI_BIL_PST_CASTING01			1135
#define	MTI_BIL_PST_CASTING02			1136
#define	MTI_BIL_PST_CASTING03			1137
#define	MTI_BIL_PST_SQUARE01			1138
#define	MTI_BIL_PST_SQUARE02			1139
#define	MTI_BIL_PST_SQUARE03			1140

//사이키퍼				
#define	MTI_PSY_NLG_CASTING01			1145
#define	MTI_PSY_NLG_CASTING02			1146
#define	MTI_PSY_NLG_CASTING03			1147
#define	MTI_PSY_PSY_PSYCHI01			1148
#define	MTI_PSY_PSY_PSYCHI02			1149
#define	MTI_PSY_PSY_PSYCHI03			1150
#define	MTI_PSY_PSY_SQUARE01			1151
#define	MTI_PSY_PSY_SQUARE02			1152
#define	MTI_PSY_PSY_SQUARE03			1153
				
//엘리멘터				
#define	MTI_ELE_FIRE_CASTING01			1160
#define	MTI_ELE_FIRE_CASTING02			1161
#define	MTI_ELE_FIRE_CASTING03			1162
#define	MTI_ELE_ELECTRICITY_CASTING01			1163
#define	MTI_ELE_ELECTRICITY_CASTING02			1164
#define	MTI_ELE_ELECTRICITY_CASTING03			1165
#define	MTI_ELE_EARTH_CASTING01			1166
#define	MTI_ELE_EARTH_CASTING02			1167
#define	MTI_ELE_EARTH_CASTING03			1168
#define	MTI_ELE_WATER_CASTING01			1169
#define	MTI_ELE_WATER_CASTING02			1170
#define	MTI_ELE_WATER_CASTING03			1171
#define	MTI_ELE_WIND_CASTING01			1172
#define	MTI_ELE_WIND_CASTING02			1173
#define	MTI_ELE_WIND_CASTING03			1174
#define	MTI_ELE_MULTI_CASTING01			1175
#define	MTI_ELE_MULTI_CASTING02			1176
#define	MTI_ELE_MULTI_CASTING03			1177

//아크로뱃
#define	MTI_ACR_SUP_CASTING01			1178
#define	MTI_ACR_BOW_JUNKBOW01			1179
#define	MTI_ACR_BOW_AIMEDSHOT01			1180
#define	MTI_ACR_YOYO_SLOWSTEP01			1181
#define	MTI_ACR_BOW_SILENTSHOT01		1182
#define	MTI_ACR_DEF_SUPPORT01			1183
#define	MTI_ACR_BOW_ARROWRAIN01			1184
#define	MTI_ACR_YOYO_CROSSLINE01		1185
#define	MTI_ACR_BOW_AUTOSHOT01			1186
#define	MTI_ACR_YOYO_SNITCH01			1187
#define	MTI_ACR_YOYO_COUNTER01			1188
#define	MTI_ACR_YOYO_DEADLYSWING01		1189
#define	MTI_ACR_YOYO_PULLING01			1190
#define MTI_ACR_YOYO_COUNTER02			1205

//제스터
#define	MTI_JST_SUP_CRITICALSWING01		1191
#define	MTI_JST_SUP_ENCHANT				1192
#define	MTI_JST_YOYO_BACKSTAB01			1193
#define	MTI_JST_YOYO_HITOFPENYA01		1194
#define	MTI_JST_YOYO_ESCAPE01			1195
#define	MTI_JST_YOYO_VATALSTAB01		1196

//레인저
#define	MTI_RAG_SUP_FASTATTACK01		1197
#define	MTI_RAG_BOW_ICEARROW01			1198
#define	MTI_RAG_BOW_FLAMEARROW01		1199
#define	MTI_RAG_BOW_PIRCINGARROW01		1200
#define	MTI_RAG_BOW_POISONARROW01		1201
#define	MTI_RAG_BOW_SILENTARROW01		1202
#define	MTI_RAG_SUP_NATURE01			1203
#define	MTI_RAG_BOW_TRIPLESHOT01		1204

//3차 전직 클래스 스킬

//로드템플러
#define	MTI_LORDK_SUP_TEMPLARPULLING01	1235
#define	MTI_LORDK_ONE_GRANDRAGE01		1236
#define	MTI_LORDK_ONE_SHILDSTRIKE01		1237
#define	MTI_LORDK_SUP_ANGRYINCREASE01	1238
#define	MTI_LORDK_SUP_HOLYARMOR01		1239
#define	MTI_LORDK_TWO_SCOPESTRIKE01		1240

//스톰블레이드
#define	MTI_STORMB_DOUBLE_CROSSOFBLOOD01	1241
#define	MTI_STORMB_DOUBLE_CROSSOFBLOOD02	1242
#define	MTI_STORMB_DOUBLE_STORMBLASTE01		1243
#define	MTI_STORMB_DOUBLE_HOLDINGSTORM01	1244
#define	MTI_STORMB_DOUBLE_POWERINCREASE01	1245

//크랙슈터
#define	MTI_CRA_BOW_RANGESTRIKE01			1246
#define	MTI_CRA_SUP_POWERINCREASE01			1247
#define	MTI_CRA_SUP_CONTROLINCREASE01		1248
#define	MTI_CRA_SUP_HAWKEYE01				1249

//윈드러커
#define	MTI_WINDL_YOYO_MADHURRICANE01		1250
#define	MTI_WINDL_YOYO_EVASIONINCREASE01	1251
#define	MTI_WINDL_YOYO_CONTROLINCREASE01	1252
#define	MTI_WINDL_YOYO_BACKSTEP01			1253

//플로리스트
#define	MTI_FLO_HEAL_PLAYEROFTHEREVIVAL01		1254
#define	MTI_FLO_HEAL_PLAYEROFTHEREVIVAL02		1255
#define	MTI_FLO_HEAL_PLAYEROFTHEREVIVAL03		1256
#define	MTI_FLO_SUP_BLESSEDSTEP01				1257
#define	MTI_FLO_SUP_BLESSEDSTEP02				1258
#define	MTI_FLO_SUP_BLESSEDSTEP03				1259
#define	MTI_FLO_SUP_BLESSEDBODY01				1260
#define	MTI_FLO_SUP_BLESSEDBODY02				1261
#define	MTI_FLO_SUP_BLESSEDBODY03				1262
#define	MTI_FLO_SUP_BLESSEDARMOR01				1263
#define	MTI_FLO_SUP_BLESSEDARMOR02				1264
#define	MTI_FLO_SUP_BLESSEDARMOR03				1265
#define	MTI_FLO_SUP_ABSOLUTEBARRIER01			1266
#define	MTI_FLO_SUP_ABSOLUTEBARRIER02			1267
#define	MTI_FLO_SUP_ABSOLUTEBARRIER03			1268
#define	MTI_FLO_SUP_FETTERS01					1269
#define	MTI_FLO_SUP_FETTERS02					1270
#define	MTI_FLO_SUP_FETTERS03					1271

//포스마스터
#define	MTI_FORCEM_SUP_AURORAOFTHERAGE01		1272
#define	MTI_FORCEM_SUP_AURORAOFTHERAGE02		1273
#define	MTI_FORCEM_SUP_AURORAOFTHERAGE03		1274
#define	MTI_FORCEM_SUP_AURORAOFTHETENACITY01	1275
#define	MTI_FORCEM_SUP_AURORAOFTHETENACITY02	1276
#define	MTI_FORCEM_SUP_AURORAOFTHETENACITY03	1277
#define	MTI_FORCEM_SUP_AURORAOFTHESPEED01		1278
#define	MTI_FORCEM_SUP_AURORAOFTHESPEED02		1279
#define	MTI_FORCEM_SUP_AURORAOFTHESPEED03		1280
#define	MTI_FORCEM_SUP_AURORAOFTHEMAD01			1281
#define	MTI_FORCEM_SUP_AURORAOFTHEMAD02			1282
#define	MTI_FORCEM_SUP_AURORAOFTHEMAD03			1283

//멘탈리스트
#define	MTI_MENT_PSY_DARKNESSSCREAM01		1284
#define	MTI_MENT_PSY_DARKNESSSCREAM02		1285
#define	MTI_MENT_PSY_DARKNESSSCREAM03		1286
#define	MTI_MENT_PSY_DARKNESSRAKE01			1287
#define	MTI_MENT_PSY_DARKNESSRAKE02			1288
#define	MTI_MENT_PSY_DARKNESSRAKE03			1289
#define	MTI_MENT_PSY_ATTACKDECREASE01		1290
#define	MTI_MENT_PSY_ATTACKDECREASE02		1291
#define	MTI_MENT_PSY_ATTACKDECREASE03		1292
#define	MTI_MENT_PSY_DEFENDERDECREASE01		1293
#define	MTI_MENT_PSY_DEFENDERDECREASE02		1294
#define	MTI_MENT_PSY_DEFENDERDECREASE03		1295
#define	MTI_MENT_PSY_SPEEDDECREASE01		1296
#define	MTI_MENT_PSY_SPEEDDECREASE02		1297
#define	MTI_MENT_PSY_SPEEDDECREASE03		1298

//엘리멘탈로드
#define	MTI_ELE_MULTI_THUNDERBOLTS01		1299
#define	MTI_ELE_MULTI_THUNDERBOLTS02		1300
#define	MTI_ELE_MULTI_THUNDERBOLTS03		1301
#define	MTI_ELE_MULTI_FINALSPEAR01			1302
#define	MTI_ELE_MULTI_FINALSPEAR02			1303
#define	MTI_ELE_MULTI_FINALSPEAR03			1304
#define	MTI_ELE_MULTI_COSMICELEMENT01		1305
#define	MTI_ELE_MULTI_COSMICELEMENT02		1306
#define	MTI_ELE_MULTI_COSMICELEMENT03		1307
#define	MTI_ELE_MULTI_SLEEPING01			1308
#define	MTI_ELE_MULTI_SLEEPING02			1309
#define	MTI_ELE_MULTI_SLEEPING03			1310


//크랙슈터 크로스보우 

#define	MTI_ACR_SUP_BOWMASTER_CRA			1378
#define	MTI_ACR_BOW_JUNKBOW01_CRA			1379
#define	MTI_ACR_BOW_AIMEDSHOT01_CRA			1380
#define	MTI_ACR_BOW_SILENTSHOT01_CRA		1382
#define	MTI_ACR_DEF_SUPPORT01_CRA			1383
#define	MTI_ACR_BOW_ARROWRAIN01_CRA			1384
#define	MTI_ACR_BOW_AUTOSHOT01_CRA			1386

#define	MTI_RAG_SUP_FASTATTACK01_CRA		1397
#define	MTI_RAG_BOW_ICEARROW01_CRA			1398
#define	MTI_RAG_BOW_FLAMEARROW01_CRA		1399
#define	MTI_RAG_BOW_PIRCINGARROW01_CRA		1400
#define	MTI_RAG_BOW_POISONARROW01_CRA		1401
#define	MTI_RAG_BOW_SILENTARROW01_CRA		1402
#define	MTI_RAG_SUP_NATURE01_CRA			1403
#define	MTI_RAG_BOW_TRIPLESHOT01_CRA		1404

#define	MTI_CRA_BOW_RANGESTRIKE01_CRA			1446
#define	MTI_CRA_SUP_POWERINCREASE01_CRA			1447
#define	MTI_CRA_SUP_CONTROLINCREASE01_CRA		1448
#define	MTI_CRA_SUP_HAWKEYE01_CRA				1449



//날개모션
#define	MTI_FSTAND1_D				1206
#define	MTI_FIDLE1_D				1207
#define	MTI_FIDLE2_D				1208
#define	MTI_FLTURN1_D				1209
#define	MTI_FLTURN2_D				1210
#define	MTI_FRTURN1_D				1211
#define	MTI_FRTURN2_D				1212
#define	MTI_FRUNNING1_D				1213
#define	MTI_FRUNNING2_D				1214
#define MTI_FDMG1_D				1215
#define MTI_FATK1_D				1216
#define MTI_FATK2_D				1217
#define MTI_FATK3_D				1218

//유럽 신규 자동차 

#define	MTI_GENFSTAND1_D				1223
#define	MTI_GENFLTURN1_D				1226
#define	MTI_GENFRTURN1_D				1228
#define	MTI_GENFRUNNING1_D				1230
#define	MTI_GENFDMG1_D					1232
#define	MTI_GENFATK1_D					1233
#define	MTI_GENFATK2_D					1234

//동물 탈 것
#define	MTI_FSTAND1_F						1457
#define	MTI_GENFLTURN1_F					1460
#define	MTI_GENFRTURN1_F					1462
#define	MTI_GENFRUNNING1_F					1464
#define	MTI_GENFDMG1_F						1466
#define	MTI_GENFATK1_F						1467
#define	MTI_GENFATK2_F						1468

// parts
#define HAIRMESH_01                            0
#define HAIRMESH_02                            1
#define HAIRMESH_03                            2
#define HAIRMESH_04                            3
#define HAIRMESH_05                            4
#define HAIRMESH_06                            5
#define HAIRMESH_07                            6
#define HAIRMESH_08                            7
#define HAIRMESH_09                            8
#define HAIRMESH_10                            9

#define SKINSET_01                             0
#define SKINSET_02                             1
#define SKINSET_03                             2
#define SKINSET_04                             3
#define SKINSET_05                             4

#define HEADTEXTURE_NORMAL                     0
#define HEADTEXTURE_SMILE                      1
#define HEADTEXTURE_RAGE                       2

#define MAX_DEFAULT_HEAD						5
#define MAX_HEAD                               11
#define MAX_HAIR                               10
#define MAX_BASE_HAIR                          5
#define MAX_SKIN                               2

#define HAIR_COST		2000000
#define HAIRCOLOR_COST		4000000
#define CHANGE_FACE_COST	1000000
#endif  
  

