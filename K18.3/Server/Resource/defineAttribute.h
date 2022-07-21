#ifndef __DEFINEATTRIBUTE
#define __DEFINEATTRIBUTE

// 가상 아이템 타입 
#define VT_ITEM                      1
#define VT_SKILL                     2
/*
#define CT_START     1
#define CT_CIRCLE    2
#define CT_FINISH    3 
#define CT_COUNTER   4
#define CT_BOOSTER   5 
#define CT_FG        6
*/

//드랍률 증가 관련 스킬 2차 그룹명 정의
#define	SK2_DROPRATE_UP	1

//드랍률 증가 관련 스킬 3차 그룹명 정의
#define SK3_ITEM_ALL	1
#define	SK3_ITEM_RARE	2


#define CT_STEP      1 // 원래 CT_START
#define CT_CIRCLE    2
#define CT_FINISH    3
#define CT_GENERAL   4 // 원래 CT_FG


// ItemSex
//#define IS_MALE                      1 // 남성전용사용
//#define IS_FEMALE                    2 // 여성잔용사용

// Handed
#define HD_ONE                       1 // 한손으로
#define HD_TWO                       2 // 양손으로 
#define HD_DUAL                      3 // Two-Weapon

// AtkType
#define AT_SLASH                     1 // 베기
#define AT_BLOW                      2 // 치기
#define AT_PIERCE                    3 // 찌르기

// AtkStyle
#define AS_HORIZONTAL                0 // 수평 휘두르기
#define AS_VERTICAL                  1 // 수직 휘두르기
#define AS_DIAGONAL                  2 // 사선 휘두르기
#define AS_THRUST                    3 // 찌르기
#define AS_HEAD                      4 // 머리(통제부분)
#define AS_CHEST                     5 // 가슴(몸통)
#define AS_ARM                       6 // 팔(공격부위)
#define AS_LEG                       7 // 다리(이동부위)
#define AS_BACK                      8 // 뒤에서 공격

#define MAX_AS                       9 //

// WeaponType
#define WT_MELEE_SWD                 1 // 칼을 사용한 기본 패턴공격수식
#define WT_MELEE_AXE                 2 // 도끼을 사용한 기본 패턴공격수식
#define WT_MELEE_STICK               3 // 치어스틱을 사용한 기본 패턴공격수식
#define WT_MELEE_KNUCKLE             4 // 너클해머를 사용한 기본 패턴공격수식
#define WT_MELEE_STAFF               5 // 스태프를 사용한 기본 패턴공격수식
#define WT_MAGIC_WAND                6 // 완드를 사용한 기본 패턴공격수식

/* 20050329 가라추가 */
#define WT_MELEE_YOYO               20 // 요요를 사용한 기본 패턴공격수식
#define WT_RANGE_BOW                21 // 활를 사용한 기본 패턴공격수식

#define WT_MELEE                     7 // 기본 공격 직접공격용 수식(Str)
#define WT_RANGE                     8 // 기본 공격 장거리공격용 수식(Dex)
#define WT_MAGIC                     9 // 기본 공격 마법공격용 수식(Int)
#define WT_CHEER                    10 // 기본 공격 치어스틱 공격 수식(*Sta, Int)
#define WT_GUN                      11 // 기본 공격 총을 사용한 공격용 수식(Sta,*Dex)
#define WT_DOLL                     12 // 기본 공격 인형공격용 수식(*Sta,Dex)
#define WT_EQUIP                    13 // 장착한 장비에 의해서 기술의 수식적용(기술)
#define WT_PROPERTY                 14 // 소도구 기술 사용시 수식적용(기술, Dex)
#define WT_ACROBAT                  15 // 곡예기술 사용시 수식적용(기술, Dex)
#define WT_THROWITEM                16 // 괴력에서 아이템 던지기 기술사용시 수식적용(아이템 무게, Sta, Dex)
#define WT_THROWING                 17 // 괴력에서 나무,돌 던지기 기술사용시 수식적용(기술, Sta, Dex)
#define WT_SWING                    18 // 괴력에서 나무휘두르기 기술사용시 수식적용(기술, Sta, Dex)
#define WT_KNUCKLE                  19 // 괴력에서 나무휘두르기 기술사용시 수식적용(기술, Sta, Dex)

//속성 타입

#define _NONE			0 //무속성
#define _FIRE			1 //불속성
#define _WATER			2 //물속성
#define _ELECTRICITY	3 //전기속성
#define _WIND			4 //바람속성
#define _EARTH			5 //땅속성

// AttackRange
#define AR_SHORT                     1 // 한손용 근접전 무기
#define AR_LONG                      2 // 양손용 근전전 무기
#define AR_FAR                       3 // 채찍, 창과 같은 무기
#define AR_RANGE                     4 // 쏘는 무기
#define AR_WAND                      5 // 완드 거리
#define AR_HRANGE                    6 // 쏘는 무기
#define AR_HWAND                     7 // 긴완드 거리

// SpellAttribute
#define SA_DIRECTDMG                 1 // 직접 데미지
#define SA_OBJCHGPARAMET             2 // 대상의 파라미터 변경
#define SA_SELFCHGPARAMET            3 // 자신의 파라미터 변경
#define SA_OTHERS                    4 // 기타

//	SpellType
#define ST_MAGIC                     1 // 일반 마법
#define ST_MIND                      2 // 정신 계열
#define ST_POISON                    3 // 독 계열
#define ST_ELECTRICITY               4 // 전기 계열
#define ST_FIRE                      5 // 불 계열
#define ST_WIND                      6 // 바람 계열
#define ST_WATER                     7 // 물 계열
#define ST_EARTH                     8 // 땅 계열
#define ST_DARK                      9 // 어둠 계열
#define ST_LIGHT                    10 // 빛 계열
#define ST_FIREEARTH                11 // 불/땅 계열
#define ST_ELECWIND                 12 // 전기/바람 계열
#define ST_EARTHWIND                13 // 땅/바람 계열
#define ST_EARTHWATER               14 // 땅/물 계열

// Skill Ready 기술준비시간
#define SR_AFTER                     1 // 기술 사용후에 대기시간 발동
#define SR_BEFORE                    2 // 기술 사용전에 대기시간 발동  

//	Spell Region
#define SRO_DIRECT                   1 // 단일 대상 100%
#define SRO_REGION                   2 // 대상을 중심(대상 100%, 주위 100%)
#define SRO_EXTENT                   3 // 대상을 중심(대상 100%, 주위 최소 데미지)
#define SRO_SURROUND                 4 // 대상을 중심(대상 최소, 주위 100%)
#define SRO_DOUBLE                   5 // 100% 재판정
#define SRO_LINE                     6 // 대상과 직선 거리에 있는 적들(대상 100%, 주위 100%)
#define SRO_AROUND                   7 // 대상을 중심(대상 0%, 주위 100%)
#define SRO_TROUPE					 8 // 파티원들이 대상.

//	Skill Type
#define KT_MAGIC                     1 // 
#define KT_SKILL                     2 // 

// Buff Tick Type
#define	BT_START					1	// Buff 시작과 동시에 적용(매 틱시에도 적용)
#define	BT_TICK						2	// Buff 틱에만 적용

// CardType
#define CT_TELEPORT                  1 // 특정 지역으로 이동
#define CT_SUMMON                    2 // 특정 대상을 소환

// Race
#define RACE_HUMAN                   1 // 인간
#define RACE_ANIMAL                  2 // 동물
#define RACE_HUMANOID                3 // 인간 동류
#define RACE_MONSTER                 4 // 일반 몬스터
#define RACE_UNDEAD                  5 // 언데드
#define RACE_GHOST                   6 // 육체가 없는 유령
#define RACE_INSECT                  7 // 곤충
#define RACE_MECHANIC                8 // 기계로 작동하는 생명체
#define RACE_ELEMENTAL               9 // 원소계 생명체


// Size
#define SIZE_TINY                    1 // 
#define SIZE_SMALL                   2 // 
#define SIZE_MIDDLE                  3 // 
#define SIZE_NORMAL                  4 // 
#define SIZE_TALL                    5 // 
#define SIZE_BIG                     6 // 
#define SIZE_GAINT                   7 // 

// dwClass 
#define RANK_LOW                     1 //
#define RANK_NORMAL                  2 //
#define RANK_CAPTAIN                 3 //
#define RANK_BOSS                    4 //
#define RANK_MIDBOSS				 5 // 빅머슬,크르릉,머쉬무트 중간보스들
#define RANK_MATERIAL                6 //
#define RANK_SUPER                   7 //
#define RANK_GUARD                   8 //
#define RANK_CITIZEN                 9 //
#define RANK_MAX					 10 // 몬스터 랭크가 추가 될 경우 증가시킨다. propskill.csv 에 몬스터 적용 등급 값을 위한 파라미터

//dwAreaColor
#define AREA_NORMAL		1 // 일반 지역
#define AREA_CASH		2 // 유료 맵 지역
#define AREA_DUNGEON		3 // 일반 던전 지역
#define AREA_INSTANCE		4 // 인스턴스 던전 지역


// Character State(캐릭터 상태변경)
#define CHS_NORMAL				0			// 일반
#define CHS_GUARDARROW			0x00000001	// 화살을 막는 상태
#define CHS_GUARDBULLET			0x00000002	// 총알을 막는 상태
#define CHS_GROGGY				0x00000004	// 타격받은 상태(억!!)
#define CHS_STUN				0x00000008	// 기절한 상태 - nProbability:확률 dwSkillTime:지속시간
#define CHS_ANOMY				0x00000010	// 정신적 혼란상태(억!!)
#define CHS_STARVE				0x00000020	// 굶주린 상태
#define CHS_PLASYARM			0x00000040	// 손떨림으로 인한 공격불능상태
#define CHS_MISSING				0x00000080	// 특정한 상황에 의해 헛손질한 상태
#define CHS_DARK				0x00000100	// 명중률 저하 nProbability:확률 dwDestData2:수정될 명중치.
#define CHS_LITHOSKIN			0x00000200	// 방어하는 량을 피해 입는다. 방어구에 심각한 피해를 준다.
#define CHS_INVISIBILITY		0x00000400	// 방어하는 량을 피해 입는다. 방어구에 심각한 피해를 준다.
#define CHS_POISON				0x00000800	// 독걸린 상태. nProbability:확률(CHANCE로 사용한것이면 =를함)  dwPainTime:몇초마다?  nDestData1 : 틱당데미지: dwSkilltime:지속시간
#define CHS_SLOW				0x00001000	// 느려진 상태.
#define CHS_DMGREFLECT			0x00002000	// 데미지 반사. 리플렉히트는 이걸로 안한다. 버프형태가 아니기 때문
#define CHS_DOUBLE				0x00004000	// 2배 데미지 .
#define CHS_BLEEDING			0x00008000	// 출혈 : 사용법은 독과 같음
#define CHS_SILENT				0x00010000	// 침묵
#define CHS_DMG_COUNTERATTACK	0x00020000	// 반격 대기중 : 가격당했을때 지정된확률(destData1)로 지정된스킬(destData2)이 발동됨.
#define CHS_ATK_COUNTERATTACK	0x00040000	// 반격 대기중 : 공격당했을때 지정된확률(destData1)로 지정된스킬(destData2)이 발동됨.
#define CHS_LOOT				0x00080000	// 이동불가 상태.

#define CHS_SETSTONE			0x00100000	// 석화 상태.



#define CHS_SLEEPING			0x00200000	// 잠자는 상태.
#define CHS_DEBUFFALL			0x00600000	// 모든 상태영향 해제.

#define	CHS_ATTACKSPEED_DOWN	0x00400000	// 공격속도 감소
#define	CHS_CRITICALRATE_DOWN	0x00800000	// 치명타 확률 감소
#define	CHS_CRITICALDMG_DOWN	0x01000000	//	치명타 추가 데미지 감소



// 위에꺼 조합한 형태...
#define CHS_DARK_POISON								0x00000900	// 독과 암흑
#define CHS_DARK_POISON_STUN						0x00000908	// 독과 암흑과 스턴 
#define CHS_LOOT_SLOW								0x00081000	// 이동장애상태 총집합(룻,스네어,슬로우등)
#define	CHS_DARK_POISON_STUN_BLEEDING				0x00008908	// 독, 암흑, 스턴, 출혈
#define CHS_DARK_POISON_STUN_BLEEDING_DEBUFFALL		0x0031d908	// 모든 상태영향 해제.독, 암흑, 스턴, 출혈,CHS_SILENT,CHS_SETSTONE,CHS_DOUBLE,CHS_SLOW

// Belligerence
#define BELLI_PEACEFUL                1 // 평화 - 공격 받아도 반격 안함 
#define BELLI_CAUTIOUSATTACK          2 // 공격 받으면 반격
#define BELLI_ACTIVEATTACK            3 // 무조건 공격 
#define BELLI_ALLIANCE                4
#define BELLI_ACTIVEATTACK_MELEE2X    5 // 무조건 공격하는 직접공격만 가진 캐릭(직접만 가짐)
#define BELLI_ACTIVEATTACK_MELEE      6 // 무조건 공격하는 직접/ 장거리을 가진 캐릭(직접 중심)
#define BELLI_ACTIVEATTACK_RANGE      7 // 무조건 공격하는 장거리/ 직접을 가진 캐릭(장거리 중심)
#define BELLI_CAUTIOUSATTACK_MELEE2X  8 // 공격받으면 반격하는 직접공격만 가진 캐릭(직접만 가짐)
#define BELLI_CAUTIOUSATTACK_MELEE    9 // 공격받으면 반격하는 직접/ 장거리을 가진 캐릭(직접 중심)
#define BELLI_CAUTIOUSATTACK_RANGE   10 // 공격받으면 반격하는 장거리/ 직접을 가진 캐릭(장거리 중심)
#define BELLI_MELEE2X                11 // 무조건 공격하는 직접공격만 가진 캐릭(직접만 가짐)
#define BELLI_MELEE                  12 // 무조건 공격하는 직접/ 장거리을 가진 캐릭(직접 중심)
#define BELLI_RANGE                  13 // 무조건 공격하는 장거리/ 직접을 가진 캐릭(장거리 중심)

// BloodColor
#define BLOOD_RED                    1
#define BLOOD_GREEN                  2
#define BLOOD_BLUE                   3
#define BLOOD_WHITE                  4
#define BLOOD_BLACK                  5

// Shelter
#define SHELTER_BASICZONE            1
#define SHELTER_TESTZONE             2
#define SHELTER_GRASS                3

// dwSfxElemental
#define ELEMENTAL_FIRE               1
#define ELEMENTAL_WATER              2
#define ELEMENTAL_WIND               3
#define ELEMENTAL_EARTH              4
#define ELEMENTAL_LASER              5
#define ELEMENTAL_DARK               6
#define ELEMENTAL_ELEC               7
#define ELEMENTAL_ANGEL_BLUE         8
#define ELEMENTAL_ANGEL_RED          9
#define ELEMENTAL_ANGEL_WHITE        10
#define ELEMENTAL_ANGEL_GREEN        11

// dwReferTarget
#define RT_ATTACK                    1
#define RT_TIME                      2
#define RT_HEAL                      3

// DestParam1 추가
// 캐릭터 관련
#define DST_NONE					0
#define DST_STR                      1   // Str			<-사용중
#define DST_DEX                      2   // Dex			<-사용중
#define DST_INT                      3   // Int			<-사용중
#define DST_STA                      4   // Sta			<-사용중
#define DST_YOY_DMG		             5   // 요요 데미지
#define DST_BOW_DMG		             6   // 보우 데미지
#define DST_CHR_RANGE                7   // 공격 범위
#define DST_BLOCK_RANGE              8   // 블럭율상승(원거리공격에 대한)
#define DST_CHR_CHANCECRITICAL       9   // 
#define DST_CHR_BLEEDING            10	//
#define DST_SPEED                   11  // 		<-사용중
#define DST_ABILITY_MIN             12  // AbilityMin
#define DST_ABILITY_MAX             13  // AbilityMax
#define DST_BLOCK_MELEE             14  // 블럭율상승(근접공격에 대한)
#define DST_MASTRY_EARTH            15  // 
#define DST_STOP_MOVEMENT           16  // 대상 이동 불가(공격은 가능)
#define DST_MASTRY_FIRE             17  // 
#define DST_MASTRY_WATER            18  // 
#define DST_MASTRY_ELECTRICITY      19  // 
#define DST_MASTRY_WIND             20  //
#define DST_KNUCKLE_DMG             21  // 너클 공격력 증가
#define DST_PVP_DMG_RATE			22	// PVP시 받은 최종 데미지 감소 Rate //#define DST_ARM_RATE                22  // Diagonal Rate
//#define DST_LEG_RATE                23  // Thrust Rate
#define DST_ATTACKSPEED             24  // Attack Speed		<-사용중
#define DST_SWD_DMG                 25  // 추가 데미지			<-사용중
#define DST_ADJDEF                  26  // Adjestment Defense	<-사용중
#define DST_RESIST_MAGIC            27  // Resist Magic 마법의 전체저항수치
#define DST_RESIST_ELECTRICITY      28  // Resist Electticity
#define DST_REFLECT_DAMAGE          29  // 공격자에게 데미지 반사(%), nAdj 돌려주는 데미지의 비율(100%=100) dwDestData1 확률(=는100%)
#define DST_RESIST_FIRE             30  // Resist Fire
#define DST_RESIST_WIND             31  // Resist Wind
#define DST_RESIST_WATER            32  // Resist Water
#define DST_RESIST_EARTH            33  // Resist Earth
#define DST_AXE_DMG                 34  // 추가 데미지			<-사용중									
#define DST_HP_MAX                  35  // HP			<-사용중
#define DST_MP_MAX                  36  // MP			
#define DST_FP_MAX                  37  // FP
#define DST_HP                      38  // HP			<-사용중
#define DST_MP                      39  // MP			<-사용중
#define DST_FP                      40  // FP			<-사용중
#define DST_HP_RECOVERY             41  // HPRecovery
#define DST_MP_RECOVERY             42  // MPRecovery
#define DST_FP_RECOVERY             43  // FPRecovery
#define DST_KILL_HP					44	// 적을 죽였을시 HP 회복량
#define DST_KILL_MP					45	// 적을 죽였을시 MP 회복량
#define DST_KILL_FP					46	// 적을 죽였을시 FP 회복량
#define DST_ADJ_HITRATE             47  // AdjHitRate			<-사용중
//#define DST_ADJ_SPELLRATE           48  // AdjSpellRate
#define DST_CLEARBUFF				49  // 버프 파괴.
#define DST_CHR_STEALHP_IMM         50  // 대상으로부터 지정된 양의 hp를 흡수
#define DST_ATTACKSPEED_RATE		51	// 공격속도 증가율 //#define DST_ABRASION                51  // Abrasion
#define DST_HP_MAX_RATE				52	// DST_HP_MAX 퍼센트 버전		//#define DST_ADJROLL                 52  // AdjRoll
#define DST_MP_MAX_RATE				53	// 동일							//#define DST_AP                      53  // 최대치까지 상승하게 되면 공격이 저지된다.(연속공격이 저지되며 ReAttackDelay 적용)	<-사용중
#define DST_FP_MAX_RATE				54	// 동일							//#define DST_GROGGY                  54  // 피해동작 발생에 필요한 수치(공격이 정지되면서 피해동작을 취하게 된다. ReAttackDelay 동시 적용)
#define DST_CHR_WEAEATKCHANGE	    55	// 케릭터의 속성 공격력을 올려줌(무기에 속성 공격력이 없거나 무기를 바꿀시 해제됨)
#define DST_CHR_STEALHP				56  // 가격한 데미지의 일정비율의HP를 흡수(흡혈)
#define DST_CHR_CHANCESTUN			57  // 효과가 지속되는동안 공격시 (일정확률로Adj) 지정된 스킬(Chg) 발동.
#define DST_AUTOHP					58  // 케릭터가 일정양 이상 HP가 줄어들면 HP가 자동으로 회복됨 Adj:남은 HP의 퍼센테이지 Chg:회복 HP의 퍼센테이지
#define DST_CHR_CHANCEDARK			59  // 효과가 지속되는동안 공격시 (일정확률로Adj) 지정된 스킬(Chg) 발동.
//#define DST_CHR_CHANCESKILL	    60  // 효과가 지속되는동안 공격시 (일정확률로Adj) 지정된 스킬(Chg) 발동.
#define DST_CHR_CHANCEPOISON	    60  // 효과가 지속되는동안 공격시 (일정확률로Adj) 지정된 스킬(Chg) 발동.
#define DST_IMMUNITY	 			61  // 면역
#define DST_ADDMAGIC				62 	// 마법 추가
#define DST_CHR_DMG                 63  // 추가 데미지			<-사용중
#define DST_CHRSTATE                64  // 캐릭터의 상태를 변경		<-사용중 Adj:CHR_시리즈 Chg:사용금지.  nProbability:확률 dwSkillTime:시간.
#define DST_PARRY                   65  // 피할 확률을 추가한다.	<-사용중
#define DST_ATKPOWER_RATE			66  // 공격력(%로 사용)
#define DST_EXPERIENCE				67  // 경험치 //#define DST_REATTACKDELAY           67  // 재공격 속도를 변경
#define DST_JUMPING                 68  // 캐릭터의 점프 높이 변경
#define DST_CHR_CHANCESTEALHP		69  // 효과가 지속되는동안 공격시 (일정확률로Adj) 지정된 스킬(Chg) 발동.
#define DST_CHR_CHANCEBLEEDING      70  // 효과가 지속되는동안 공격시 (일정확률로Adj) 지정된 스킬(Chg) 발동.
#define DST_RECOVERY_EXP            71  // 캐릭터 사망시에 부활을 통해서 살아날 경우 Exp 손실 부분의 회복 퍼센트	<-사용중
#define DST_ADJDEF_RATE				72	// ADJDEF 퍼센트로 쓰는 버전.

#define	DST_MP_DEC_RATE				73	// MP 소모 감소율
#define	DST_FP_DEC_RATE				74	// FP 소모 감소율
#define	DST_SPELL_RATE				75	// 스펠 속도 증가율
#define	DST_CAST_CRITICAL_RATE		76	// 주문 극대화 확률 증가
#define	DST_CRITICAL_BONUS			77	// 치명타 적중시 추가 타격
#define	DST_SKILL_LEVEL				78	// 스킬레벨 업
#define DST_MONSTER_DMG				79	// 몬스터 사냥시 데미지 증가
#define DST_PVP_DMG					80	// PVP시 데미지 증가
#define DST_MELEE_STEALHP			81	// 평타시 흡혈
#define	DST_HEAL					82	// 자동 치유
#define DST_ATKPOWER				83	// 공격력

//	10차 전승 마스터 스킬 
#define DST_ONEHANDMASTER_DMG       85	
#define DST_TWOHANDMASTER_DMG       86
#define DST_YOYOMASTER_DMG          87
#define DST_BOWMASTER_DMG           88
#define DST_KNUCKLEMASTER_DMG       89
#define DST_HAWKEYE_RATE            90
#define DST_RESIST_MAGIC_RATE       91
#define DST_GIFTBOX					92

#define	DST_RESTPOINT_RATE			93	// 15차 휴식의 기운 증가율(%)

#define DST_IGNORE_DMG_PVP			94	// PVP 데미지 무시(절대치)


// 19차 신규옵션
#define	DST_TAKE_PVP_DMG_PHYSICAL_RATE		95		// PVP 시 받는 물리 데미지 변화 (입력값 -10 이면 10% 감소 적용)
#define	DST_TAKE_PVP_DMG_MAGIC_RATE			96		// PVP 시 받는 마법 데미지 변화 (입력값 -10 이면 10% 감소 적용)
#define	DST_TAKE_PVE_DMG_PHYSICAL_RATE		97		// PVE 시 받는 물리 데미지 변화 (입력값 -10 이면 10% 감소 적용)
#define	DST_TAKE_PVE_DMG_MAGIC_RATE			98		// PVE 시 받는 마법 데미지 변화 (입력값 -10 이면 10% 감소 적용)
#define	DST_DROP_ITEM_ALLGRADE_RATE			99		// 아이템 드롭률 변화 (입력값 -10 이면 10% 감소 적용)
#define	DST_DROP_ITEM_ONEMORE_CHANCE		100		// 드롭 판정 재검사 (입력값 10 이면 10% 확률로 한번 더 굴림)
#define	DST_GIVE_PVE_DMG_ELEMENT_FIRE_RATE		101	//	불속성 몬스터에게 추가 피해 변화(입력값 10이면 10% 증가 적용)
#define	DST_GIVE_PVE_DMG_ELEMENT_WATER_RATE		102	//	물속성 몬스터에게 추가 피해 변화(입력값 10이면 10% 증가 적용)
#define	DST_GIVE_PVE_DMG_ELEMENT_ELECT_RATE		103	//	전기속성 몬스터에게 추가 피해 변화(입력값 10이면 10% 증가 적용)
#define	DST_GIVE_PVE_DMG_ELEMENT_WIND_RATE		104	//	바람속성 몬스터에게 추가 피해 변화(입력값 10이면 10% 증가 적용)
#define	DST_GIVE_PVE_DMG_ELEMENT_EARTH_RATE		105	//	땅속성 몬스터에게 추가 피해 변화(입력값 10이면 10% 증가 적용)
#define	DST_ADJ_ITEM_EQUIP_LEVEL				106	//	아이템 착용 레벨 변화(입력값 -1이면 레벨 1 하락)
#define	DST_SKILL_LEVELUP_ALL					107	//	모든 스킬 레벨 증가
#define	DST_GIVE_DMG_RATE_ENEMY_STUN			108	//	기절한 상태의 몹에게 추가 피해 변화(입력값 10이면 10% 증가 적용)
#define	DST_GIVE_DMG_RATE_ENEMY_DARK			109	//	암흑 상태의 몹에게 추가 피해 변화(입력값 10이면 10% 증가 적용)
#define	DST_GIVE_DMG_RATE_ENEMY_POISON			110	//	독 걸린 상태의 몹에게 추가 피해 변화(입력값 10이면 10% 증가 적용)
#define	DST_GIVE_DMG_RATE_ENEMY_SLOW			111	//	느려진 상태의 몹에게 추가 피해 변화(입력값 10이면 10% 증가 적용)
#define	DST_GIVE_DMG_RATE_ENEMY_BLEEDING		112	//	출혈 상태의 몹에게 추가 피해 변화(입력값 10이면 10% 증가 적용)
#define	DST_GIVE_DMG_RATE_ENEMY_SILENT			113	//	침묵 상태의 몹에게 추가 피해 변화(입력값 10이면 10% 증가 적용)
#define	DST_GIVE_DMG_RATE_ENEMY_LOOT			114	//	이동 불가 상태의 몹에게 추가 피해 변화(입력값 10이면 10% 증가 적용)
#define	DST_GIVE_DMG_RATE_ENEMY_SETSTONE		115	//	석화 상태의 몹에게 추가 피해 변화(입력값 10이면 10% 증가 적용)
#define	DST_GIVE_DMG_RATE_ENEMY_SLEEPING		116	//	잠자는 상태의 몹에게 추가 피해 변화(입력값 10이면 10% 증가 적용)


#define MAX_ADJPARAMARY             117

// ADJPARAMARRAY에는 추가되지 않고, 현재값의 설정과 반환( GetPointParam, SetPointParam )에 사용하기 위한 식별자
#define	DST_GOLD				10000
#define	DST_PXP					10001
#define DST_RESIST_ALL			10002	// Resist ALL - (MAX_ADJPARAMARY + 3)과 같은 방식은 프로퍼티에서 인식하지 못함.
#define DST_STAT_ALLUP			10003	//모든 Status를 +1만큼 올려준다.
#define DST_HPDMG_UP			10004
#define DST_DEFHITRATE_DOWN		10005
#define DST_CURECHR				10006		// DST_CHRSTATE 상태 제거
#define DST_HP_RECOVERY_RATE	10007		// HPRecovery Rate
#define DST_MP_RECOVERY_RATE	10008		// MPRecovery Rate
#define DST_FP_RECOVERY_RATE	10009		// FPRecovery Rate
#define	DST_LOCOMOTION			10010		// JUMP & SPEED
#define	DST_MASTRY_ALL			10011
#define DST_ALL_RECOVERY		10012
#define DST_ALL_RECOVERY_RATE	10013
#define DST_KILL_ALL			10014
#define DST_KILL_HP_RATE		10015
#define DST_KILL_MP_RATE		10016
#define DST_KILL_FP_RATE		10017
#define DST_KILL_ALL_RATE		10018
#define DST_ALL_DEC_RATE		10019

#define	DST_FORCE_DAMAGE_MAX_HP_RATE		10020		// 최대 HP의 x%만큼 데미지를 입힌다. AdjParam 비율(최대10000%)
#define	DST_FORCE_DAMAGE_SAFE_HP_RATE		10021		// 최대 HP의 x%의 HP가 남게 데미지를 입힌다. AdjParam 비율(최대10000%)
#define	DST_FORCE_DAMAGE_VALUE				10022		// 절대치 데미지 주기 AdjParam(데미지)

#define DST_HEAL_HP_RATE					10030		// HP 비율 회복 AdjParam(최대 10000%)
#define DST_HEAL_MP_RATE					10031		// MP 비율 회복 AdjParam(최대 10000%)
#define DST_HEAL_FP_RATE					10032		// FP 비율 회복 AdjParam(최대 10000%)
#define DST_HEAL_HP_VALUE					10033		// HP 절대치 회복 AdjParam
#define DST_HEAL_MP_VALUE					10034		// MP 절대치 회복 AdjParam
#define DST_HEAL_FP_VALUE					10035		// FP 절대치 회복 AdjParam

#define DST_DEBUFF_ALL_CLEAR				10036

//11.10.04 사용된 버프 스킬 유지 조건 컬럼용 파라미터 추가(해당 사항 없는 스킬은 = 로 표기)
#define	KEEP_EQUIP_YOYO					1				// 착용된 요요를 착용 해제하면 풀리는 버프
#define	KEEP_EQUIP_BOW					2				// 착용된 보우를 착용 해제하면 풀리는 버프
#define	KEEP_EQUIP_SWD					3				// 착용된 검을 착용 해제하면 풀리는 버프
#define	KEEP_EQUIP_AXE					4				// 착용된 도끼를 착용 해제하면 풀리는 버프
#define	KEEP_EQUIP_KNUCKLE				5				// 착용된 너클을 착용 해제하면 풀리는 버프
#define	KEEP_EQUIP_SHILED				6				// 착용된 방패를 착용 해제하면 풀리는 버프
#define	KEEP_EQUIP_DUALWEAPON			7				// 착용된 2개의 무기 중 1개를 착용 해제하면 풀리는 버프
#define	KEEP_EQUIP_TWOHANDEDWEAPON		8				// 착용된 양손 무기를 해제하면 풀리는 버프
#define	KEEP_EQUIP_ELEMENTALWEAPON		9				// 착용된 속성 무기를 해제하면 풀리는 버프


#endif
