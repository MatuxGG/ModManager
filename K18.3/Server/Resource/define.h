#ifndef __DEFINE_H_BEAST_3D
#define __DEFINE_H_BEAST_3D

#define FALSE                0 
#define TRUE                 1

// 아이템 사용 시기  (WhenUseItem)

#define WUI_NONE              0 // 
#define WUI_NOW               1 // 즉시사용 : 타겟으로 지정되어 있는 대상에게 사용한다.
#define WUI_TARGETOBJ         2 // 타겟지정 : 지정즉시 사용한다.(모션이 필요한 것은 모션 후에 사용된다.)
#define WUI_TARGETOBJ2        3 // 타겟지정 : 두개를 지정하고, 두번째 지정즉시 사용한다.(모션이 필요한 것은 모션 후에 사용된다.)
#define WUI_TARGETINGOBJ      4 // 지정된 타겟에 바로 사용한다. 타겟이 없을때 타겟 선택 아이콘으로 변경된다.(모션이 필요한 것은 모션 후에 사용된다.)
#define WUI_TARGETOBJPTZ      5 // 타겟지정 : 두개를 지정인데 첫째는 오브젝트, 둘째는 좌표다.(모션이 필요한 것은 모션 후에 사용된다.)
#define WUI_TARGETPTZ         6 // 타겟지정 : 지정즉시 사용한다.(모션이 필요한 것은 모션 후에 사용된다.)
#define WUI_TARGETMOVEOBJ     7 // 타겟지정 : 지정한 오브젝트로 이동한 뒤에 사용한다.
#define WUI_TARGETMOVEPTZ     8 // 타겟지정 : 지정한 좌표로 이동한 뒤에 사용한다.
#define WUI_MENU              9 // 지식 사용시도시 관련 메뉴가 뜨는 방식
#define	WUI_MENU_TOBJ        10 // 메뉴 부른후  타겟오브젝 사용하는 방식
#define WUI_TARGETPTZ_IB     11 // 타겟지정 : 좌표지정, Ignore Blocking
#define WUI_TARGETCURSORPTZ  12 // 타겟지정 : 사용시에 마우스 커서가 있는 곳의 좌표를 즉시 사용한다.

// 발동 시기        (WhenExcuTe)
#define WET_NONE              0 // 
#define WET_NOW               1 // 발동시기 필요없이 바로
#define WET_DEAD              2 // 죽을때
#define WET_ATK               3 // 공격을 당할 때
#define WET_ATKOTHER          4 // 선택했던 대상이 공격 당할때 
#define WET_BODYSTATE         5 // 몸이 특정한 상태일 때
#define WET_PARRY             6 // 피하기 성공 후
#define WET_ARROW             7 // 화살로 공격 당할 때
#define WET_BULLET            8 // 총알로 공격 당할 때 
#define WET_RANGE             9 // 화살과 총알 모두로 공격 당할 때
#define WET_MAGIC            10 // 직접 공격 마법으로 공격 당할 때
#define WET_HIT              11 // 대상이 공격을 할때 

// 발동 대상        (EXecuteTarget)
#define EXT_NONE             	 0 // 
#define EXT_SELFCHGPARAMET   	 1 // 자신의 파라미터를 변경
#define EXT_OBJCHGPARAMET    	 2 // 타인의 파라미터를 변경
#define	EXT_MAGICSHOT		 	 3 // 발사체가 날아간 후 발동되지만 발사체가 직접 데미지를 주진 않음.
#define EXT_MAGICATK         	 4 // 마법 직접 공격
#define EXT_AMPLIFICATION    	 5 // 마법을 증폭한다
#define EXT_ATTACKER         	 6 // 공격한 대상에게 적용
#define EXT_MAGIC            	 7 // 기타 일반 마법
#define EXT_ANOTHER          	 8 // 다른 사람에게만 적용(사용하지 않음)
#define EXT_ANOTHERWITH      	 9 // 다른 사람이나 자신에게 적용
#define EXT_SUMMON           	10 // 생명체를 소환한다.
#define EXT_AROUNDATK		 	11 // 주변의 적들을 공격한다.
#define EXT_OTHER            	12 // 기타 그외의 것들
#define EXT_TROUPE           	13 // 극단을 대상으로 함
#define EXT_MAGICATKSHOT     	14 // 마법공격계 스킬중 발사체가 있는 형태
#define EXT_MENTALATK		 	15 // 정신공격 
#define EXT_MELEEATKSHOT     	16 // 물리공격계 스킬중 발사체가 있는 형태
#define EXT_MELEEATK	     	17 // 근거리 밀리 공격
#define EXT_RANGEATK	     	18 // 원거리 비 마법 공격
#define EXT_PET					19 // 원거리 비 마법 공격
#define EXT_TROUPEWITH			20 // 극단이나 나를  대상으로 함
#define	EXT_ITEM				21 // 아이템 사용 대상이 필요하다.
#define	EXT_ITEM_ENCHANT		22 // 아이템 사용 대상이 필요하고 사용 시 인첸트 이펙트가 발생된다. 


// 스크립트를 누가 실행시켰나. (WhoExecuteScript)

#define WES_NONE             0 
#define WES_WORLD            1 // 필드가 실해이켰다.
#define WES_DEATH            2 // 죽었을 때 실행된다.
#define WES_DAMAGE           3 // 데미지를 입었을 때 실행된다.
#define WES_EXECUTE          4 // Execute프로시져 안에서 실행된다.
#define WES_DIALOG           5 // 대화 도중에 실행된다.
#define WES_EVENT            6 // 이벤트에서 실행된다.
#define WES_SCHEDULE_BEGIN   7 // 스케쥴이 작동할 때 실행된다.
#define WES_SCHEDULE_END     8 // 스케쥴이 끝나면 실행된다.

// 성별 
#define SEX_MALE             0
#define SEX_FEMALE           1
#define SEX_SEXLESS          2

// Object Type

#define OT_OBJ          0 // 배경 객체 
#define OT_ANI          1 // 애니 객체 
#define OT_CTRL         2 // 특수 배경 객체   
#define OT_SFX          3 // 특수효과 객체 
#define OT_ITEM         4 // 아이템 
#define OT_MOVER        5 // 움직이는 객체 
#define OT_REGION       6 // 리전(이벤트, 속성)
#define OT_SHIP			7 // 비공정
#define OT_PATH			8 // 비공정
#define MAX_OBJTYPE     9

// Object Filter (source)

#define OF_OBJ          0x00000001 // 배경 오브젝트 
#define OF_ANI          0x00000002 // 애니 배경 
#define OF_CTRL         0x00000004 // 특수 배경   
#define OF_SFX          0x00000008 // 특수효과 오브젝트 
#define OF_ITEM         0x00000010
#define OF_MOVER        0x00000020
#define OF_REGION       0x00000040
#define OF_SHIP			0x00000080

// Model Type

#define MODELTYPE_NONE               0
#define MODELTYPE_MESH               1
#define	MODELTYPE_ANIMATED_MESH		 2
#define MODELTYPE_BILLBOARD          3 
#define MODELTYPE_SFX                4 
#define MODELTYPE_ASE				 5		// ASE모델

// Model Distant 
#define MD_FAR  0 //- 멀리서도 보임. 집, 나무, 거대 오브젝트
#define MD_MID  1 //- 
#define MD_NEAR 2 //- 프랍 
#define MD_FIX  3 //- 고정 프랍, 무조건 보인다.

// Addition Texture
#define ATEX_NONE	0 //- 추가매핑 사용하지 않음
#define ATEX_00		0	// 텍스쳐세트 00번(디폴트)
#define ATEX_USE	1 //- 추가매핑 사용함
#define ATEX_01		1	// 텍스쳐세트 01번
#define ATEX_02		2	// 텍스쳐세트 02번
#define ATEX_03		3	// 텍스쳐세트 03번
#define ATEX_04		4	// 텍스쳐세트 04번
#define ATEX_05		5	// 텍스쳐세트 05번
#define ATEX_06		6	// 텍스쳐세트 06번
#define ATEX_07		7	// 텍스쳐세트 07번
// Item Type

#define ITYPE_ITEM      0
#define ITYPE_CARD      1
#define ITYPE_CUBE      2 
#define ITYPE_PET		3

// Region attribute
#define RA_WORLD         0x00000001
#define RA_DUNGEON       0x00000002
#define RA_NEWBIE        0x00000004
#define RA_BEGIN         0x00000008
#define RA_SAFETY        0x00000010
#define RA_SHRINE        0x00000020
#define RA_FIGHT         0x00000040
#define RA_INN           0x00000080
#define RA_SIGHT         0x00000100
#define RA_DAMAGE        0x00000200
#define RA_TOWN          0x00000400
#define RA_DAYLIGHT      0x00000800
#define RA_PK            0x00001000
#define RA_OX            0x00002000
#define RA_DANGER        0x00004000
#define RA_NO_CHAT       0x00008000
#define RA_NO_ATTACK     0x00010000
#define RA_NO_DAMAGE     0x00020000
#define RA_NO_SKILL      0x00040000
#define RA_NO_ITEM       0x00080000
#define RA_NO_TELEPORT   0x00100000
#define RA_SCHOOL        0x00200000
#define RA_PENALTY_PK    0x00400000
#define	RA_COLLECTING	0x00800000

// Guild Logo
#define CUSTOM_LOGO_MAX		27

#define GM_LOGO_CH			21
#define GM_LOGO_EU			22
#define GM_LOGO_JP			23
#define GM_LOGO_PH			24
#define GM_LOGO_TH			25
#define GM_LOGO_TW			26
#define GM_LOGO_US			27

#define CITYN_FLARIS        1
#define CITYN_SAINTMORNING  2

#define LANDN_FLARIS        1
#define LANDN_SAINTMORNING  2




// Guide define
#define GUIDE_EVENT_MOVE				0
#define GUIDE_EVENT_KEY_MOVE			1
#define GUIDE_EVENT_KEY_RUN				2
#define GUIDE_EVENT_KEY_JUMP			3
#define GUIDE_EVENT_TRACKING_MOVE		4
#define GUIDE_EVENT_KEY_ZOOM			5
#define GUIDE_EVENT_CAMERAMOVE			6
#define GUIDE_EVENT_KEY_CAMERAMOVE		7
#define GUIDE_EVENT_INTRO				8
#define GUIDE_EVENT_END                 9
#define GUIDE_EVENT_BERSERKERMODE		10
#define GUIDE_FLIGHT					11
#define GUIDE_FLIGHT_METHOD				12

#define APP_SKILL_BEFOREJOB				13
#define APP_SKILL_AFTERJOB				14
#define APP_DEATH_FIELD					15
#define GUIDE_ESSENSE					16
#define GUIDE_CHANGEJOB					17
#define GUIDE_APP_GUILD					18


#define GUIDE_EVENT_MOUSE_MOVE					19
#define GUIDE_EVENT_KEY_WALK					20
#define GUIDE_EVENT_MOUSE_CAMERAMOVE			21
#define GUIDE_EVENT_WORLD_MAP					22
#define GUIDE_EVENT_WORLD_NAVI					23
#define GUIDE_EVENT_NORMAL_CHAT					24
#define GUIDE_EVENT_SHOUT_CHAT					25
#define GUIDE_EVENT_TROUPE_CHAT					26
#define GUIDE_EVENT_WHISPER_CHAT				27
#define GUIDE_EVENT_GUILD_CHAT					28
#define GUIDE_EVENT_SYSTEM_CHAT					29
#define GUIDE_EVENT_FILTER_CHAT					30
#define GUIDE_EVENT_STATUS_WIN					31
#define GUIDE_EVENT_CHARACTER_WIN				32
#define GUIDE_EVENT_INVENTORY_WIN				33
#define GUIDE_EVENT_QUEST_WIN					34
#define GUIDE_EVENT_QUICKSLOT					35
#define GUIDE_EVENT_TROUPE						36
#define GUIDE_EVENT_TROUPE_WIN					37
#define GUIDE_EVENT_CHARACTER_MENU				38
#define GUIDE_EVENT_TRADE						39
#define GUIDE_EVENT_STORE						40
#define GUIDE_EVENT_BANK						41
#define GUIDE_EVENT_MESSENGER					42
#define GUIDE_EVENT_MOTION						43
#define GUIDE_EVENT_CHEER						44



// AI
#define		MAX_SUMMON		8		// 최대 소환할수 있는 부하 수

// Useing attribute
#define UA_ITEM          0x00000001
#define UA_LEVEL         0x00000002
#define UA_QUEST         0x00000004
#define UA_CLASS         0x00000008
#define UA_GENDER        0x00000010
#define UA_TELEPORT      0x00000020
#define UA_QUEST_END     0x00000040
#define UA_PLAYER_ID     0x00000080

//트랩 발동 타입
#define TOT_RANDOM			0    // 랜덤 발동
#define TOT_NOENDU		1    // 내구도가 0이면 발동

#define	PK_NPC		-1
#define	PK_TIGER		0
#define	PK_LION		1
#define	PK_RABBIT		2
#define	PK_FOX			3
#define	PK_DRAGON	4
#define	PK_GRIFFIN	5
#define	PK_UNICORN	6
#define	PK_MAX		7


// 알 변환 결과에 의해 생성되는 아이템의 타입
#define	TI_GENERIC	0
#define	TI_PET	1

#define	PERIN_VALUE		100000000L

// point type
#define POINTTYPE_CAMPUS	1

// weather type
#define SEASON_NONE			0
#define SEASON_SPRING		1
#define SEASON_SUMMER		2
#define SEASON_FALL			3
#define SEASON_WINTER		4
#define SEASON_MAX			5


// 스킬이 부여된 아이템 사용 시 적용 대상(Item Skill Target)
#define IST_SELF			1	// 자기 자신에게 발동
#define IST_ANOTHER			2	// 상대방에게 발동


#endif