//--------------------------- 아이템 타입1--------------------------------//

#define	TYPE1_NONE				0

#define	TYPE1_WEAPON				1
#define	TYPE1_ARMOR				2
#define	TYPE1_ACCESSORY			3
#define	TYPE1_MATERIAL			4
#define	TYPE1_CONSUME			5
#define	TYPE1_ALLEXCEPTION		6
#define	TYPE1_COSTUME			7
#define	TYPE1_POTION			8
#define	TYPE1_TWOWEAPONMERGE	9		//양손 무기 합성 캐시 아이템(장비보호)

//19차 전에 분류 작업 추가로 할 것들
#define	TYPE1_PET				10		//펫 종류

#define	TYPE1_SMELT				11		//일반 제련
#define	TYPE1_SMELT_ACCESSORY	12		//악세서리 제련
#define	TYPE1_SMELT_ELEMENT		13		//속성 제련
#define	TYPE1_BARUNASMELT		14		//바루나 제련
#define	TYPE1_ULTIMATE			15		//얼터멋 변환
#define	TYPE1_BARUNAELE			16		//바루나 속성제련
#define	TYPE1_AWAKE				17		//아이템 각성
#define	TYPE1_PIERCING			18		//피어싱(카드)
#define	TYPE1_PIERCING_BARUNA	19		//피어싱(바루나)
#define	TYPE1_USABLE			20		//사용가능 아이템
#define	TYPE1_RIDE				21		//비행체
#define	TYPE1_BOX				22		//박스류
#define	TYPE1_FURNITURE			23		//가구 종류
#define	TYPE1_SCROLL			24		//스크롤
#define	TYPE1_ETC				25		//기타잡다한 종류
#define	TYPE1_TELEPORTSCROLL	26		//텔레포트 스크롤
#define	TYPE1_LEVELDOWNSCROLL	27		//레벨다운 스크롤











//--------------------------- 아이템 타입2--------------------------------//
//------------------------------------------------------------------------//





#define TYPE2_NONE				0

#define	TYPE2_WEAPON_ONESWORD			1
#define	TYPE2_WEAPON_TWOSWORD			2
#define	TYPE2_WEAPON_ONEAXE			3
#define	TYPE2_WEAPON_TWOAXE			4
#define	TYPE2_WEAPON_KNUCKLE			5
#define	TYPE2_WEAPON_STICK			6
#define	TYPE2_WEAPON_BOW			7
#define	TYPE2_WEAPON_STAFF			8
#define	TYPE2_WEAPON_YOYO			9
#define	TYPE2_WEAPON_WAND			10

#define	TYPE2_WEAPON_ALLEXCEPTION		13

#define	TYPE2_ARMOR_FORCEZEM			11
#define	TYPE2_ARMOR_MAGICBOOK			12
#define	TYPE2_ARMOR_HELMET			14
#define	TYPE2_ARMOR_SUIT			15
#define	TYPE2_ARMOR_GUNTLET			16
#define	TYPE2_ARMOR_BOOTS			17
#define	TYPE2_ARMOR_SHIELD			18

#define	TYPE2_ACCESSORY_RING			19
#define	TYPE2_ACCESSORY_EARRING			20
#define	TYPE2_ACCESSORY_NECKLACE		21

#define	TYPE2_MATERIAL_EXCEPTION		22

#define	TYPE2_CONSUME_POTION			23
#define	TYPE2_CONSUME_SCROLL			24
#define	TYPE2_CONSUME_POSTER			25
#define	TYPE2_CONSUME_EXCEPTION			26


#define TYPE2_ALLEXCEPTION_ALLEXCEPTION		27

#define	TYPE2_COSTUME_MASK			28
#define	TYPE2_COSTUME_CLOAK			29
#define	TYPE2_COSTUME_HAT			30
#define	TYPE2_COSTUME_CLOTH			31
#define	TYPE2_COSTUME_GLOVE			32
#define	TYPE2_COSTUME_SHOES			33
#define	TYPE2_POTION_SAVE			34
#define	TYPE2_MATERIAL_ELLDIN			35
#define	TYPE2_CONSUME_ELLDIN			36
#define	TYPE2_TWOWEAPONMERGE_PROPTECTION	37		//양손 무기 합성 캐시 아이템(장비보호)

//19차 전에 분류 작업 추가로 할 것들

#define	TYPE2_PET_EGG				38		//알
#define	TYPE2_PET_REAR				39		//리어펫(먹펫)
#define	TYPE2_PET_PICKUP			40		//픽업펫
#define	TYPE2_PET_BUFF				41		//버프펫
#define	TYPE2_PET_SMELTSPRIT		42		//제련정령


#define	TYPE2_SMELT_MATERIAL								43		//	재료
#define	TYPE2_SMELT_CASH_PROTECTION							44		//	캐시(보호)
#define	TYPE2_SMELT_CASH_INCREASEPROP						45		//	캐시(확률증가)
#define	TYPE2_SMELT_ACCESSORY_MATERIAL						46		//	재료
#define	TYPE2_SMELT_ACCESSORY_CASH_PROPTECTION				47		//	캐시(보호)
#define	TYPE2_SMELT_ELEMENT_CARD							48		//	재료
#define	TYPE2_SMELT_ELEMENT_CASH_PROPTECTION				49		//	캐시(보호)

#define	TYPE2_BARUNASMELT_CID								50		//	재료
#define	TYPE2_BARUNASMELT_CIDCRYSTAL						51		//	재료
#define	TYPE2_BARUNASMELT_CIDMIX							52		//	재료
#define	TYPE2_BARUNASMELT_OPER								53		//	재료
#define	TYPE2_BARUNASMELT_OPERMIX							54		//	재료
#define	TYPE2_BARUNASMELT_OPERCID							55		//	재료
#define	TYPE2_BARUNASMELT_OPERCRYSTAL						56		//	재료
#define	TYPE2_BARUNASMELT_CASH_PROTECTION					57		//	캐시(보호)
#define	TYPE2_BARUNASMELT_CASH_INCREASEPROP					58		//	캐시(확률증가)

#define	TYPE2_ULTIMATE_MATERIAL								59		//	재료
#define	TYPE2_ULTIMATE_CASH									60		//	캐시(보호)
#define	TYPE2_ULTIMATE_CASH_INCREASEPROP					61		//	캐시(확률증가)

#define	TYPE2_BARUNAELE_ORB									62		//	재료
#define	TYPE2_BARUNAELE_CASH_PROPTECTION					63		//	캐시(보호)

#define	TYPE2_BARUNA_CASH_INCREASEPROP						64		//	캐시(확률증가)
#define	TYPE2_AWAKE_SCROLL									65		//	각성의 두루마리
#define	TYPE2_AWAKE_CANCEL									66		//	캐시(취소)
#define	TYPE2_AWAKE_PROTECTION								67		//	캐시(보호)
#define	TYPE2_AWAKE_BARUNA_CANCEL							68		//	캐시(취소)
#define	TYPE2_AWAKE_PET_REAR								69		// 리어 펫 각성 두루마리
#define	TYPE2_AWAKE_PET_PICKUP								70		// 픽업 펫 각성 두루마리
#define	TYPE2_AWAKE_COSTUME									71		//	코스튬 각성(여신의 축복)

#define	TYPE2_PIERCING_SOCKETCARD							72		//	재료
#define	TYPE2_PIERCING_BARUNA_RUNE_WEAPON					73		//	재료
#define	TYPE2_PIERCING_BARUNA_RUNE_ARMOR					74		//	바루나 룬(아머)
#define	TYPE2_PIERCING_BARUNA_PROPTECTION					75		//	캐시(보호)

#define	TYPE2_USABLE_INSTANTPOTION							76		//	일회용포션
#define	TYPE2_USABLE_INSTANTFOOD							77		//	일회용음식
#define	TYPE2_USABLE_BUFFPOTION								78		//	버프포션
#define	TYPE2_USABLE_BUFFFOOD								79		//	버프음식

#define	TYPE2_RIDE_BROOM									80		//	빗자루
#define	TYPE2_RIDE_BOARD									81		//	보드
#define	TYPE2_RIDE_CAR										82		//	차
#define	TYPE2_RIDE_WING										83		//	날개

#define	TYPE2_BOX_RANDOM									84		//	랜덤박스
#define	TYPE2_BOX_PACKAGE									85		//	패키지박스
#define	TYPE2_BOX_TREASURE									86		//	보물상자
#define	TYPE2_BOX_TREASURE_KEY								87		//	보물상자열쇠

#define	TYPE2_FURNITURE_BED									88		//	침대
#define	TYPE2_FURNITURE_SOFA								89		//	소파
#define	TYPE2_FURNITURE_WARDROBE							90		//	옷장
#define	TYPE2_FURNITURE_CLOSET								91		//	화장대
#define	TYPE2_FURNITURE_TABLE								92		//	탁자
#define	TYPE2_FURNITURE_CABINET								93		//	장식장
#define	TYPE2_FURNITURE_PROPS								94		//	소품
#define	TYPE2_FURNITURE_WALLPAPER							95		//	벽지
#define	TYPE2_FURNITURE_CARPET								96		//	장판
#define	TYPE2_FURNITURE_DESK								97		//	책상
#define	TYPE2_FURNITURE_BATH								98		//	욕조
#define	TYPE2_FURNITURE_DRAWER								99		//	협탁
#define	TYPE2_FURNITURE_CHAIR								100		//	의자
#define	TYPE2_FURNITURE_GUILD_BED							101		//	길드 침대
#define	TYPE2_FURNITURE_GUILD_SOFA							102		//	길드 소파
#define	TYPE2_FURNITURE_GUILD_WARDROBE						103		//	길드 옷장
#define	TYPE2_FURNITURE_GUILD_CLOSET						104		//	길드 화장대
#define	TYPE2_FURNITURE_GUILD_TABLE							105		//	길드 탁자
#define	TYPE2_FURNITURE_GUILD_CABINET						106		//	길드 장식장
#define	TYPE2_FURNITURE_GUILD_PROPS							107		//	길드 소품
#define	TYPE2_FURNITURE_GUILD_WALLPAPER						108		//	길드 벽지
#define	TYPE2_FURNITURE_GUILD_CARPET						109		//	길드 장판
#define	TYPE2_FURNITURE_GUILD_DESK							110		//	길드 책상
#define	TYPE2_FURNITURE_GUILD_BATH							111		//	길드 욕조
#define	TYPE2_FURNITURE_GUILD_DRAWER						112		//	길드 협탁
#define	TYPE2_FURNITURE_GUILD_TELEPORTER					113		//	길드 텔레포트
#define	TYPE2_FURNITURE_GUILD_CHAIR							114		//	길드 의자
#define	TYPE2_FURNITURE_GUILD_CASE							115		//	길드 책장

#define	TYPE2_SCROLL_EXPRATE								116		//	경험치 스크롤
#define	TYPE2_SCROLL_COLOSSEUMBOSSRATE						117		//	보스확률증가
#define	TYPE2_SCROLL_COLOSSEUMRETRY							118		//	재도전

#define	TYPE2_ETC_BALLOON									119		//	풍선
#define	TYPE2_ETC_ARROW										120		//	화살
#define	TYPE2_ETC_BOLT										121		//	볼트
#define	TYPE2_ETC_MAGICTRICK								122		//	장난감
#define	TYPE2_ETC_VIS										123		//	비스
#define	TYPE2_ETC_TROPHY									124		//	전리품
#define	TYPE2_ETC_COLLECTER									125		//	채집 관련
#define	TYPE2_ETC_ACCEL										126		//	엑셀러퓰
#define	TYPE2_ETC_BLINKWING									127		//	블링크윙
#define	TYPE2_ETC_ANGEL										128		//	엔젤
#define	TYPE2_ETC_QUEST										129		//	퀘스트
#define	TYPE2_ETC_MIX										130		//	재료
#define	TYPE2_ETC_PETFOOD									131		//	리어펫먹이
#define	TYPE2_ETC_PENYA										132		//	페냐
#define	TYPE2_TELEPORTSCROLL_NORMAL							133		//	일반텔레포트
#define	TYPE2_TELEPORTSCROLL_PREMIUM						134		//	고급텔레포트

#define	TYPE2_LEVELDOWNSCROLL_NORMAL		135		//레벨다운 스크롤 노말
#define	TYPE2_LEVELDOWNSCROLL_MASTER	136		//레벨다운 스크롤 마스터
#define	TYPE2_LEVELDOWNSCROLL_HERO		137		//레벨다운 스크롤 히어로