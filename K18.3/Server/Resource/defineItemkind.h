#ifndef __DEFINE_ITEMKIND
#define __DEFINE_ITEMKIND

// IK_2는 탭의 의미적인 구분, IK_3은 아이템 생성에 사용

////////////////////////////////////////////////////////////////////////////
// 1차 구분 
//////////////////////////////////////////////////////////////////////////
#define IK1_NONE					0	// 널값
#define IK1_WEAPON					1	// 아이템<-
#define IK1_ARMOR					2	// 아이템<-
#define IK1_GENERAL					3	// 아이템<-
#define IK1_RIDE					4	// 아이템<-
#define IK1_SYSTEM					5	// <-
#define IK1_CHARGED					6	// 상용화 아이템 여부 판단.
#define IK1_HOUSING					7	// 하우징

#define IK1_EFFECT					8	// 버프 생성 후 효과 발동

#define IK1_ACTIVE					9	// 버프 생성 없이 효과 발동
#define IK1_PASSIVE					10	// 직접 사용 불가, UI 슬롯에 넣어야 발동
#define IK1_ACTIVEUI				11	// 아이템 사용 시 UI 창 호출됨

#define IK1_GOLD					12	// 돈<-

////////////////////////////////////////////////////////////////////////////
// 2차 구분 
//////////////////////////////////////////////////////////////////////////
#define IK2_NONE                   0 // 널값
#define IK2_WEAPON_HAND            1 // 단거리<-
#define IK2_WEAPON_DIRECT          2 // 단거리<-
#define IK2_WEAPON_MAGIC           3 // 마법<-
#define IK2_ARMOR                  7 // 방어구(갑옷, 방패)<-
#define IK2_ARMORETC               8 // 주변 방어구(건틀렛 등등)<-
#define IK2_CLOTH                  9 // 의상(일반 의상들)<-
#define IK2_CLOTHETC              10 // 주변 의상(건틀렛 등등)<-
#define IK2_REFRESHER             11 // 향수 형태<-
#define IK2_POTION                12 // 물병 형태<-
#define IK2_JEWELRY               13 // 장신구<-
#define IK2_FOOD                  14 // 음식<-
#define IK2_MAGIC                 15 // 마법물품<-
#define IK2_GEM                   16 // 보석<-
#define IK2_MATERIAL              17 // 재조 재료<-
#define IK2_TOOLS                 18 // 도구<-
#define IK2_SYSTEM                19 // 시스템에 사용<-
#define IK2_RIDING                20 // 소형 비행체<-
#define IK2_MOB                   21 // <-몬스터에게 사용되는 아이템
#define IK2_BLINKWING             22 //<-
#define IK2_AIRFUEL               23 // 비행체 연료들<-
#define IK2_CHARM                 24 // 포스터
#define IK2_BULLET                25 // 발사체
#define IK2_TEXT                  26 // 문서
#define IK2_GMTEXT				  27 // GM명령
#define IK2_GENERAL				  28 // 장군아이템...이 아니고 걍 구분할거 없을때 이거 씀 -_-;;;;
#define	IK2_BUFF					29	// 버프 아이템
#define	IK2_WARP				30
#define IK2_SKILL				31
#define IK2_CLOTHWIG			32	// 머리의상(가발)
#define	IK2_BUFF2		33	// 버프 아이템 - 만료 시간
#define IK2_FURNITURE		34	// 하우징 - 가구
#define IK2_PAPERING		35	// 하우징 - 도배
#define	IK2_TOCASH		36	// 퍼니 코인
#define	IK2_BUFF_TOGIFT		37	// 버프 완료 후 아이템 지급
#define	IK2_GUILDHOUSE_FURNITURE		38 //길드하우스 가구
#define	IK2_GUILDHOUSE_NPC		39 //길드하우스 NPC
#define IK2_GUILDHOUSE_PAPERING 40 //길드하우스 도배
#define	IK2_GUILDHOUES_COMEBACK	41 //길드하우스 귀환 주문서

#define IK2_KEEP					42	// IK1_EFFECT - 시간 만료 시 버프 제거
#define IK2_ONCE					43	// IK1_EFFECT - 사용 시 버프 제거

#define	IK2_TELEPORTMAP				44	// 텔레포트지도 아이템
#define	IK2_BARUNA					45	// 바루나 관련 아이템

#define	IK2_DECREASE				46	// 능력(옵션) 감소 아이템
#define	IK2_RANDOMOPTION			47	// 능력치(옵션) 랜덤 부여 아이템
#define	IK2_RESET					48	// 능력치(옵션) 초기화 아이템
#define	IK2_COLOSSEUM				49	// 콜로세움 아이템

#define	IK2_ENCHANT					50	// 제련 관련 아이템
#define	IK2_INCREASE				51	// 능력(옵션) 증가 아이템
#define	IK2_UPGRADE					52	// 아이템 업그레이드 기능
#define	IK2_MAPOPEN					53	// 지도 오픈 아이템
#define	IK2_COSTUMESYSTEM			54	// 코스튬 시스템 아이템

#define	IK2_TREASURE				55	// 보물상자 시스템 아이템
#define	IK2_TWOWEAPONMERGE			56	//양손무기 합성 아이템
#define	IK2_LEVELDOWNSCROLL			57	//레벨다운스크롤
#define	IK2_ELLDINPOTION			58	//엘딘항아리 관련 아이템

#define IK2_GOLD					59 // 돈<-

#define IK2_COUNT					60 //면죄의 두루마리 버프 카운트

////////////////////////////////////////////////////////////////////////////
// 3차 구분 
//////////////////////////////////////////////////////////////////////////
#define IK3_NONE                   0 //<- 널값
// 무기에 관련된 것 (IK_WEAPON 소속)
#define IK3_HAND                   1 //<-
#define IK3_SWD                    2 //<-
#define IK3_AXE                    3 //<-
#define IK3_CHEERSTICK             4 // <-
#define IK3_KNUCKLEHAMMER          5 //<-
#define IK3_WAND                   6 //<-
#define IK3_STAFF                  7 //<-
#define IK3_THSWD                  8 // 양손 소드
#define IK3_THAXE                  9 // 양손 엑스
#define IK3_VIRTUAL               10 //<-몬스터가 사용하는 가상 아이템
#define IK3_YOYO                  11 //요요
#define IK3_BOW                   12 //활
#define IK3_YOBO				  13 //요요와 활을 동시에 사용
#define IK3_CROSSBOW              14 //크로스보우

// 방어구에 관련된 것 (IK_ARMOR 소속)
#define IK3_SHIELD                16 // 방패<-
#define IK3_HELMET                17 // 머리 보호 방어구<-
#define IK3_SUIT                  18 // 상체(통짜) 보호 방어구<-
#define IK3_GAUNTLET              19 // 손 보호 방어구<-
#define IK3_BOOTS                 20 // 발 보호 방어구<-

// 의상에 관련된 것 (IK2_CLOTH 소속)
#define IK3_HAT                   21 // 모자 의상<-
#define IK3_MASK                  22 // 신발 의상<-
#define IK3_SHOES                 23 // 신발 의상<-
#define IK3_CLOAK                 24 // 망토 의상<-
#define IK3_CLOTH                 57 // 옷
#define IK3_GLOVE                 58 // 장갑

// 일반 아이템들
#define IK3_REFRESHER             25 // 정신력 치료<-
#define IK3_POTION                26 // 각종 물병<-
#define IK3_EARRING               27 // 귀걸이<-
#define IK3_NECKLACE              28 // 목걸이<-
#define IK3_RING                  29 // 반지<-
#define IK3_INSTANT               30 // 즉석으로 먹을수 있게 만들어진 음식<-
#define IK3_COOKING               31 // 요리된 음식(음식)<-
#define IK3_ICECEARM              32 // 만들어진 아이스크림2<-
#define IK3_PILL                  59 // 영양 보조 알약
#define IK3_MAGICTRICK            33 // 각종 마법용품<-
#define IK3_GEM                   34 // 그냥 보석<-
#define IK3_DRINK                 35 // 활력제<-
#define IK3_COLLECTER		      36 // 콜렉터<-
#define IK3_ELECARD		          37 // 속성 카드<-
#define IK3_DICE		          38 // 파워 주사위<-
#define IK3_SUPSTONE		      39 // 보조석<-
 
// 탈것
#define IK3_BOARD                 40 // 보드 형태의 탈 것(손사용가능)<-
#define IK3_STICK                 41 // 올라 타는 것(손사용불능)<-
#define IK3_EVENTMAIN             42 // <-이벤트용 아이템  지급자동, 판매, 트레이드, 타임줍기 불가
#define IK3_QUEST                 43 // 퀘스트용 아이템<-
#define IK3_MAP                   44 // 퀘스트용 아이템<-
#define IK3_BLINKWING             45 // 퀘스트용 아이템<-
#define IK3_EVENTSUB              46 // <-이벤트용 아이템  지급자동, 일반아이템과 동일
#define IK3_TOWNBLINKWING         47 // <-마을로만 돌아가게 되는 블링크윙

//유럽 신규 자동차
#define IK3_CAR					86		// 자동차


//비행체 아이템2
#define IK3_ACCEL		         48 // 가속 연료 아이템<-
#define IK3_DELETE		         49 // <-dwItemkind3가 이것으로 설정되면 캐릭터가 로딩될 때 자동으로 지운다.

//상용화 아이템
#define IK3_SCROLL		        50 //<-
#define IK3_ENCHANTWEAPON		51
#define IK3_CFLIGHT		        52
#define IK3_BFLIGHT		        53
#define IK3_MAGICBOTH			54
#define IK3_BCHARM		        55
#define IK3_RCHARM		        56 
#define IK3_ARROW		        60


//소켓 카드 와 피어싱 주사위
#define IK3_PIERDICE			61
#define IK3_SOCKETCARD			62
#define IK3_SOCKETCARD2			63

//문서 구분
#define IK3_TEXT_BOOK          	70 // 문서
#define IK3_TEXT_SCROLL	       	71 // 문서
#define IK3_TEXT_LETTER        	72 // 문서

//운영자 명령 아이템화
#define	IK3_TEXT_UNDYING		80
#define	IK3_TEXT_DISGUISE		81
#define IK3_TEXT_INVISIBLE		82
#define IK3_TEXT_GM				83

// BINDS
#define	IK3_BINDS				84

// 몬스터 소환
#define IK3_CREATE_MONSTER		85



#define IK3_POTION_BUFF_STR		90		// 버프 물약
#define IK3_POTION_BUFF_DEX		91		// 버프 물약
#define IK3_POTION_BUFF_INT		92		// 버프 물약
#define IK3_POTION_BUFF_STA		93		// 버프 물약
#define IK3_POTION_BUFF_DEFENSE	94		// 버프 물약

#define IK3_ANGEL_BUFF					95		// 엔젤 버프

// PET
#define IK3_PET							100		// 펫소환 아이템
#define IK3_RANDOM_SCROLL		101		// 랜덤 스클롤

#define IK3_ULTIMATE			102		// 얼터멋 웨폰 보석

#define	IK3_LINK				104
// General
#define IK3_GENERAL			118		// 아무 구분이 없는 일반.

#define IK3_ENCHANT			119

#define IK3_EGG					120		// 성장 펫
#define	IK3_FEED				121

#define	IK3_TICKET					122		// 입장권
#define	IK3_POCKET					123		// 주머니

#define IK3_BED							124		// 하우징 - 가구 - 침대
#define IK3_SOFA							125		// 하우징 - 가구 - 소파
#define IK3_WARDROBE				126		// 하우징 - 가구 - 옷장
#define IK3_CLOSET						127		// 하우징 - 가구 - 화장대
#define IK3_TABLE						128		// 하우징 - 가구 - 탁자
#define IK3_CABINET					129		// 하우징 - 가구 - 장식장
#define IK3_PROPS						130		// 하우징 - 가구 - 소품
#define IK3_WALLPAPER				131		// 하우징 - 도배 - 벽지
#define IK3_CARPET						132		// 하우징 - 도배 - 장판
#define	IK3_COUPLE_BUFF			133		// 커플 효과
#define	IK3_FUNNYCOIN				134		// 퍼니 코인
#define	IK3_FLOWER					135		// 겹침 방지를 위한 아이템. 같은 종류 사용 안됨
#define IK3_BALLOON					136		// 풍선
#define IK3_WING							137		// 날개

#define IK3_VIS							138		// 비스
#define	IK3_TS_BUFF					139

#define IK3_TELEPORTER				140 //길드하우스 텔레포터
#define IK3_REST							141	//휴식의 기운
#define	IK3_DESK						142	// 하우징 - 가구 - 책상
#define	IK3_CHAIR						143	// 하우징 - 가구 - 의자
#define	IK3_CASE						144	// 하우징 - 가구 - 책장
#define	IK3_BATH						145	// 하우징 - 가구 - 욕조
#define	IK3_DRAWER					146	// 하우징 - 가구 - 협탁

#define	IK3_CRYSTAL					147
#define IK3_KEY							148
#define IK3_CROSSARROW 			149

#define IK3_MAGICBARUNA 			150
#define IK3_ZEMBARUNA 				151
#define IK3_SHILDBARUNA 			152

//#define IK3_ENCHANTPET		153				//
#define IK3_SUMMON_NPC							153			//NPC 소환 아이템

//3차 바루나 제련 관련 아이템
#define IK3_OPERCID					154 // 오퍼시드
#define IK3_OPER							155 // 오퍼
#define IK3_CID							156 // 시드
#define IK3_OPERCRYSTAL			157 // 오퍼 결정체
#define IK3_CIDCRYSTAL				158 // 시드 결정체
#define IK3_OPERMIX					159 // 오퍼 융합제
#define IK3_CIDMIX						160 // 시드 융합제
#define IK3_MEAL							161 // 바륨의 가루
#define IK3_EXTRACT					162 // 추출 도구
//상용화 분류
#define IK3_BARUNA		        163 //바루나 8월 19일 추가 유 치훈


#define IK3_EXP_RATE						164	// 획득 경험치 증가
#define IK3_GENERAL_ENCHANT_RATE			165 // 일반 제련 확률 증가
#define IK3_GEN_ATT_ENCHANT_RATE			166 // 일반 & 속성 제련 확률 증가
#define IK3_GENERAL_WEAPON_ENCHANT_RATE		167 // 일반 무기 제련 확률 증가
#define IK3_ULTIMATE_UPGRADE_RATE			168 // 얼터멋 무기 업글 확률 증가
#define IK3_RESET_BIND						169 // 귀속 속성 해제
#define IK3_BARUNA_PROTECTION				170 // 바루나의 제련 시 바루나 아이템 보호
#define IK3_BARUNA_PROTECTION_KEEP			171 // 바루나의 제련 시 바루나 아이템 보호 및 제련수치 하락 방지


#define IK3_BARUNAWEA_PIERCE_RUNE				172 // 바루나의 피어싱 시 필요한 고대 문자석
#define IK3_BARUNAAMO_PIERCE_RUNE				173 // 바루나의 피어싱 시 필요한 고대 문자석
#define IK3_BARUNA_PROTECTION_RUNE			174 // 바루나의 피어싱 시 고대 문자석 파괴 방지
#define IK3_BARUNA_PIERCE_RATE				175 // 바루나의 피어싱 시 확률 증가

#define IK3_COLOSSEUM_BOSS_RATE				176 // 콜로세움 진보스 출현 확률 증가
#define IK3_COLOSSEUM_RETRY					177 // 콜로세움 재시도 가능

//코스튬 합성 파괴 방지 아이템
#define IK3_COSTUME_DEFENDER					178 // 콜로세움 재시도 가능

//유료 지도 시스템 관련 횃불 2종 (지역/던전)
#define IK3_MAPOPEN_AREA					179 // 콜로세움 재시도 가능
#define IK3_MAPOPEN_DUNGEON					180 // 콜로세움 재시도 가능


#define	IK3_TELEPORTMAP_BASIC				181	// 텔레포트지도 일반형
#define	IK3_TELEPORTMAP_USER				182	// 텔레포트지도 유저 등록형

#define IK3_GENERAL_RANDOMOPTION_GEN		183	// 일반 각성의 두루마리
#define IK3_GENERAL_RANDOMOPTION_INIT		184	// 일반 각성 취소의 두루마리
#define IK3_GENERAL_RANDOMOPTION_SAFE		185	// 일반 각성 보호의 두루마리

#define IK3_SYSTEMPET_RANDOMOPTION_GEN		186	// 리어펫 각성의 두루마리
#define IK3_SYSTEMPET_RANDOMOPTION_INIT		187	// 리어펫 각성 취소의 두루마리

#define IK3_COSTUME_RANDOMOPTION_GEN		188	// 여신의 축복

#define IK3_EATPET_RANDOMOPTION_GEN			189	// 픽업펫 각성의 두루마리

#define IK3_DECREASE_EQUIP_LEVEL			190	// 아이템 착용 레벨 하락

#define IK3_BARUNA_RANDOMOPTION_INIT		191	// 바루나 각성 취소의 두루마리

#define IK3_BARUNA_ELE_PROPTECTION			192 // 바루나의 은총
#define IK3_BARUNA_ELE_PROPTECTION_KEEP		193	// 축복받은 바루나의 은총
#define IK3_BARUNA_ELE_PROP_INCREASE		194	// 원소 활력제
#define IK3_ELEORB							195	// 속성오브

#define IK3_EQUIP_LEVEL							196	// 장비 레벨
#define IK3_GENERAL_GEN							197	// 일반 각성의 두루마리
#define IK3_GENERAL_INIT						198	// 일반 각성 취소
#define IK3_COSTUME_GEN							199	// 여신의 축복
#define IK3_EATPET_GEN							200	// 픽업펫 각성 각성 두루마리
#define IK3_SYSTEMPET_GEN						201	// 리어펫 각성 두루마리
#define IK3_SYSTEMPET_INIT						202	// 리어펫 각성 취소
#define IK3_SMELT_PROTECTION					203	// 제련 보호
#define IK3_SMELT_PROTECTION_KEEP				204	// 아이템 보호 및 제련수치 하락 방지
#define IK3_WEA_PIERCE_RUNE						205	// 무기 전용 피어싱 문자석
#define IK3_AMO_PIERCE_RUNE						206	// 방어구 전용 피어싱 문자석
#define IK3_PIERCE_PROTECTION					207	// 피어싱 보호 아이템
#define IK3_PIERCE_RATE							208	// 피어싱 확률 아이템
#define IK3_BOSS_RATE							209	// 보스 확률 증가
#define IK3_RETRY								210	// 재도전
#define IK3_DUNGEON								211	// 유료지도 (던전용)

#define IK3_BOX								212	// 보물상자 시스템 상자
#define IK3_BOXOPEN							213	// 보물상자 시스템 열쇠

#define IK3_SERVERMOVE							214	// 캐릭터 서버 이동

#define IK3_TRADEREGISTERITEM							215	// 장인의 계약서// 거래 중개용 캐시 아이템

#define IK3_SAVEPOTION							216	// 체력 회복 항아리 아이템
#define IK3_ELLDINKEY							217	// 체력 회복 항아리 포장 해제 아이템
#define IK3_FOODELLDIN							218	// 체력 회복 항아리 전용 물약

#define IK3_LOOKRESTOREITEM							219	// 아이템 외형 복구 주문서

#define IK3_NOMALLEVELDOWN							220	// 일반 등급 레벨 다운 주문서
#define IK3_MASTERLEVELDOWN							221	// 마스터 등급 레벨 다운 주문서
#define IK3_HEROLEVELDOWN							222	// 히어로 등급 레벨 다운 주문서

#define	IK3_TWOWEAPONMERGE_PROTECTION				223	// 양손무기합성 캐시아이템 (보호)

#define	IK3_SMELT_ULTIMATE_MATERIAL				224 // 얼터멋 강화 재료(빛나는 오리칼쿰)
#define	IK3_SMELT_GENERAL_MATERIAL				225	// 일반 강화 재료(오리칼쿰)
#define	IK3_SMELT_ACCESSORY_MATERIAL			226 // 악세서리 강화 재료(문스톤)


#define IK3_GOLD                   227 //<- 돈
#define	IK3_USESKILL			228//스킬발동아이템(spec_item.txt 의 마법 설정컬럼EF~EO 참조)
#define IK3_MOREGETITEMSCROLL		229	//획득의 두루마리

#define IK3_DUNCOOLRESET		230	//쉐이드의 모래시계

#define	IK3_MADRIGALBLESS		231	//마드리갈의 축복
#define	IK3_RANDOMOPTION_RETRY	232	//각성 재굴림의 두루마리

#define	IK3_PARTYSPEEDLEVELUP	233	//극단 성장의 두루마리
#define	IK3_PARTYPOINTFREE	234	//극단 포인트 무제한의 두루마리

#define	IK3_PKPENALTYSCROLL_A	235	//면죄의 두루마리
#define	IK3_PKPENALTYSCROLL_B	236	//속죄의 두루마리
#define	IK3_PKPENALTYSCROLL_C	237	//면책의 두루마리

#define	IK3_ARMOREFFECTCHANGE	238	//방어구 이펙트 변경 아이템

#define	IK3_BUBBLEPOINT			239	//버블포인트 버프 표시용 아이템

#define IK3_STAT_DICE			240	// 스탯 다이스

#define IK3_PATLOOT_OPTION		241

#ifdef DAILY_QUEST
#define IK3_DAILY_QUEST			242
#endif // DAILY_QUEST

#define	IK3_SMELT_COSTUME_MATERIAL			243 // 코스튬 강화 재료(번개석)
#define IK3_LIGHTNINGSTONE_MATERIAL			244	// 번개석 재료
#define IK3_COSTUME_GEN_MAT_CANCEL				245	// 코스튬 보석 취소 두루마리
#define IK3_COSTUME_GEN_MAT					246	// 코스튬 보석

#define IK3_BARUNA_ENCHANT_RATE			247 // 바루나 제련 확률 증가

#define	IK3_SOCKETCARD3					248	// 바루나 슈트 피어싱 카드

#define IK3_BARUNA_GEN_PIC_MAT_CANCEL				249	// 코스튬 보석 취소 두루마리
#define IK3_BARUNA_GEN_PIC_MAT_CANCEL2				250	// 바루나 무기 피어싱 스크롤

#define IK3_REGION_BUFF					251		// 던전 버프
#define IK3_REGION_DEBUFF					252		// 던전 디버프

#define MAX_ITEM_KIND3			253		// ItemKind3 총 개수


#define MAX_UNIQUE_SIZE				400

// 컨트롤 오브젝트 Kind
#define CK1_CHEST				0    // <-보물상자
#define CK1_DOOR				1    // <-문
#define CK1_TRIGGER				2    // 동작 오브젝트
#define CK1_HOUSING				3    // 하우징 가구 컨트롤
#define	CK1_GUILD_HOUSE				4    // 길드 가구 컨트롤

#define CK2_FADE				1    // 사라지는 컨트롤
#define CK2_KEEP				2    // 없어지지 않는 컨트롤

#define CK3_FULL				1    // 풀에니메이션
#define CK3_HALF				2    // 1/2 에니메이션


//--------------------------- 등급 start----------------------------------//
#define PET_VIS					1	// VisPet\

#define WEAPON_GENERAL			0	// 일반 무기
#define WEAPON_UNIQUE			1	// 유니크 무기
#define WEAPON_ULTIMATE			2	// 얼터멋 무기

#define ARMOR_SET				3	// 세트 방어구

#define BARUNA_D			4	// 바루나 무기 D등급
#define BARUNA_C			5	// 바루나 무기 C등급
#define BARUNA_B			6	// 바루나 무기 B등급
#define BARUNA_A			7	// 바루나 무기 A등급
#define BARUNA_S			8	// 바루나 무기 S등급

#define BARUNA_ULTIMATE		9	// 바루나 얼터멋 무기

//--------------------------- 등급 end----------------------------------//




#endif