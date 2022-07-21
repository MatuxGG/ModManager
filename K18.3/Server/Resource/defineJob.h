#ifndef __DEFINE_JOB
#define __DEFINE_JOB

#define JTYPE_BASE   0
#define JTYPE_EXPERT 1
#define JTYPE_PRO    2
#define JTYPE_TROUPE 3
#define JTYPE_COMMON 4
#define JTYPE_MASTER	 5
#define JTYPE_HERO	 6
#define JTYPE_LEGEND_HERO	 7

#define MAX_JOB_SKILL			3
#define MAX_EXPERT_SKILL		20
#define MAX_PRO_SKILL			20
#define MAX_TROUPE_SKILL		9
#define MAX_MASTER_SKILL		1
#define MAX_HERO_SKILL			1
#define MAX_LEGEND_HERO_SKILL			6

#define MAX_JOB_LEVEL			15
#define MAX_EXP_LEVEL			45
#define MAX_PRO_LEVEL			30
#define MAX_TROUPE_LEVEL		1



#define MAX_MONSTER_LEVEL			200	
#define MAX_GENERAL_LEVEL			120			// 일반, 마스터 캐릭 최고 레벨
#define MAX_LEGEND_LEVEL			130			// 히어로 캐릭 최고 레벨
#define MAX_3RD_LEGEND_LEVEL		170			// 3차 전직 캐릭 최고 레벨 ( 139 -> 150 확장 )
#define MAX_CHARACTER_LEVEL			170			// 기존 MAX_LEVEL 을 대체..캐릭터가 가질 수 있는 최고 레벨.. ( 139 -> 150 확장 )



//-------------------------------------------------------
// 직업 번호를 마음대로 바꾸면 안됩니다.
// 바꾸고 싶으시면 seghope 상담을.. ㅋㅋ
//-------------------------------------------------------
// Job
#define JOB_VAGRANT                 0 
#define MAX_JOBBASE                 1
  
// Expert
#define JOB_MERCENARY               1 // 기본 직업들
#define JOB_ACROBAT                 2
#define JOB_ASSIST                  3
#define JOB_MAGICIAN                4
#define JOB_PUPPETEER               5
#define MAX_EXPERT                  6

// Professional
#define JOB_KNIGHT      		6
#define JOB_BLADE			7
#define JOB_JESTER		        8
#define JOB_RANGER                   9
#define JOB_RINGMASTER               10
#define JOB_BILLPOSTER               11
#define JOB_PSYCHIKEEPER		12
#define JOB_ELEMENTOR			13
#define JOB_GATEKEEPER               14
#define JOB_DOPPLER                  15
#define MAX_PROFESSIONAL             16

// Master
#define JOB_KNIGHT_MASTER      		16
#define JOB_BLADE_MASTER			17
#define JOB_JESTER_MASTER		        18
#define JOB_RANGER_MASTER                   19
#define JOB_RINGMASTER_MASTER               20
#define JOB_BILLPOSTER_MASTER               21
#define JOB_PSYCHIKEEPER_MASTER		22
#define JOB_ELEMENTOR_MASTER		23
#define MAX_MASTER	             24

// Hero
#define JOB_KNIGHT_HERO      		24
#define JOB_BLADE_HERO			25
#define JOB_JESTER_HERO		        26
#define JOB_RANGER_HERO                   27
#define JOB_RINGMASTER_HERO               28
#define JOB_BILLPOSTER_HERO               29
#define JOB_PSYCHIKEEPER_HERO		30
#define JOB_ELEMENTOR_HERO		31
#define MAX_HERO	             32

// 3차 직업
#define	JOB_LORDTEMPLER_HERO	32
#define JOB_STORMBLADE_HERO		33
#define JOB_WINDLURKER_HERO		34
#define JOB_CRACKSHOOTER_HERO	35
#define JOB_FLORIST_HERO		36
#define JOB_FORCEMASTER_HERO	37
#define JOB_MENTALIST_HERO		38
#define JOB_ELEMENTORLORD_HERO	39

#define MAX_LEGEND_HERO	             40

#define MAX_JOB                      40

#define JOB_ALL					MAX_JOB
//-------------------------------------------------------

// SkillGroup    (Disciple)
#define DIS_VAGRANT                 0 //
#define DIS_SWORD                   1 //
#define DIS_DOUBLE                  2 //
#define DIS_CASE                    3 //
#define DIS_JUGGLING                4 //
#define DIS_YOYO                    5 //
#define DIS_RIFLE                   6 //
#define DIS_MARIONETTE              7 //
#define DIS_BOW			    32 // 새로 추가된 것
#define DIS_CROSSBOW		33 // 크로스보우 3차직업

#define DIS_MAGICBARUNA 		34 //3차 전직 새로운 보조 무기
#define DIS_ZEMBARUNA 			35 //3차 전직 새로운 보조 무기
#define DIS_SHILDBARUNA 		36 //3차 전직 새로운 보조 무기


// 방어기술군
#define DIS_SHIELD                  8 //
#define DIS_DANCE                   9 //
#define DIS_ACROBATIC              10 //
#define DIS_SUPPORT                23 //머서너리용 보조스킬
// 마법연계 기술군   
#define DIS_HEAL                   11 //
#define DIS_CHEER                  12 //
#define DIS_ACTING                 13 //
#define DIS_POSTER                 14 //
#define DIS_FIRE                   15 //
#define DIS_WIND                   16 //
#define DIS_WATER                  17 //
#define DIS_EARTH                  18 //
#define DIS_ELECTRICITY            24 //
// 특수 기술    
#define DIS_STRINGDANCE            19 //
#define DIS_GIGAPUPPET             20 //
#define DIS_KNUCKLE                21 //
#define DIS_MAGIC                  22 //

#define DIS_MULTY		23
#define DIS_PSYCHIC		24
#define DIS_CURSE		25
#define DIS_HOLY		26
#define DIS_TWOHANDWEAPON	27
#define DIS_TWOHANDSWORD	28
#define DIS_TWOHANDAXE		29
#define DIS_DOUBLESWORD		30
#define DIS_DOUBLEAXE		31



// 극단 소속
#define TRO_MASTER                  0 // 단장
#define TRO_MEMBERE                 1 // 멤버

// 길드소속
#define GUD_MASTER                  0 // 마스터
#define GUD_KINGPIN                 1 // 킹핀
#define GUD_CAPTAIN                 2 // 캡틴
#define GUD_SUPPORTER               3 // 서포터
#define GUD_ROOKIE                  4 // 루키

// 일반 기술 종류.... 캐릭터 내부에 저장되지 않음
#endif
/*
#ifndef __DEFINE_JOB
#define __DEFINE_JOB

#define JTYPE_BASE   0
#define JTYPE_EXPERT 1
#define JTYPE_PRO    2

#define MAX_JOB_SKILL    3
#define MAX_EXPERT_SKILL 14

#define MAX_JOB_LEVEL               10
#define MAX_EXP_LEVEL               40
#define MAX_PRO_LEVEL               30

// Job
#define JOB_MERCENARY               0 // 기본 직업들
#define JOB_ACROBAT                 1
#define JOB_ASSIST                  2
#define JOB_MAGICIAN                3
#define JOB_ENGINEER                4
#define JOB_VAGRANT                 5 // 더미 직업
#define MAX_JOBBASE                 5
  
// Expert
#define JOB_GUARD                   5
#define JOB_STRONGMAN               6
#define JOB_MARKMAN                 7
#define JOB_PIERROT                 8
#define JOB_HEALER                  9
#define JOB_BILLPOSTER              10
#define JOB_PYRON                   11
#define JOB_RAINMAKER               12
#define JOB_PUPPETEER               13
#define JOB_GATEKEEPER              14
#define MAX_EXPERT                  15

// Professional
#define JOB_KNIGHT                  16 // 무예가 전문직
#define JOB_BABARIAN                17
#define JOB_DANCER                  18
#define JOB_JESTER                  19 // 퍼포머 전문직
#define JOB_STARGAZER               20
#define JOB_ACCOUNTER               21
#define JOB_RAIDEN                  22 // 인터세서 전문직
#define JOB_OVERCASTER              23
#define JOB_DOPPLER                 24
#define JOB_STRINGMASTER            25 // 잭박스 전문직
#define MAX_PROFESSIONAL            26 
#define MAX_JOB                     26 


// SkillGroup
#define DIS_SWORD                   0 //
#define DIS_AXE                     1 //
#define DIS_MACE                    2 //
#define DIS_TOOL                    3 //
#define DIS_CASE                    4 //
#define DIS_SPEAR                   5 //
#define DIS_WHIP                    6 //
#define DIS_BOW                     7 //
#define DIS_THROWING                8 //
#define DIS_PISTOL                  9 //
#define DIS_RIFLE                  10 //
// 방어기술군
#define DIS_SHIELD                 11 //
#define DIS_PARRY                  12 //
#define DIS_ACROBAT                13 //

// 마법연계 기술군   
#define DIS_DIVINEPOWER            14 //
#define DIS_HEAL                   15 //
#define DIS_ASTROLOGY              16 //
#define DIS_FIRE                   17 //
#define DIS_WIND                   18 //
#define DIS_ELECTRICITY            19 //
#define DIS_DARK                   20 //
#define DIS_WATER                  21 //
#define DIS_EARTH                  22 //
// 특수 기술    
#define DIS_CHEER                  23 //
#define DIS_PROPERTIES             24 //
#define DIS_TAMING                 25 //
#define DIS_TALISMANS              26 //
#define DIS_HERCULEAN              27 //
#define DIS_PUPPET                 28 //
#define DIS_MARIONETTE             29 //
#define DIS_STRINGDANCE            30 //

// 일반 기술 종류.... 캐릭터 내부에 저장되지 않음
#endif
*/
