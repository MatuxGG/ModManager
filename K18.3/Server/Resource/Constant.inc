// 1.0은 기본 값
// 2.0은 배수
// 0.5는 1/2

// itemDropRate = 1.0 // 아이템 드롭률 
// goldDropRate = 1.0 // 페냐 드롭률
// monsterExpRate = 1.0 // 몬스터 경험치률 
// monsterHitRate = 1.0 // 몬스터 히트률 (몬스터의 공격력)

// 파일의 위치 ; resource\constant.inc
// Constant.txt는 월드 서버의 스크립트이며 내용 수정한 후에 반드시 월드 서버를 리붓해야한다.

// 운영자 명령어 ; 동일 수치를 게임내에서도 실시간 수정 가능함. 비율을 입력하지 않고 그냥 엔터치면 현재 상태 출력

// 영문 명령
// ItemDropRade   [비율]
// GoldDropRade   [비율]
// MonsterExpRate [비율]
// MonsterHitRate [비율]

// 한글 명령
// 아이템드롭률   [비율]
// 골드드롭률     [비율]
// 몬스터경험치률 [비율]
// 몬스터히트률   [비율]

//----------------------------------------------------------------------------------------------------// 
lang LANG_KOR // 언어 세팅, 이하 한국 버젼에 적용
{
  formula 
  {
    itemDropRate = 1.0 
    goldDropRate = 1.0 
    monsterExpRate = 1.0 
    monsterHitRate = 1.0
    dwVagSP = 1
    dwExpertSP = 2
    dwProSP = 3
  }
}
//----------------------------------------------------------------------------------------------------// 
lang LANG_JAP // 일본 난이도 세팅.(일본 관계자들은 이부분만 고치시고, 차후 패치시 한국 버젼으로 overwrite될 수 있으므로 픽스된 수치는 한국에 통보 바람)
{
  formula 
  {
    itemDropRate = 1.0 // 아이템 드롭률 1.0이면 기본값, 2.0이면 두배, 3.0이면 세배. 이하 모두 동일 규칙. 높을 수록 드롭율 상승
    goldDropRate = 1.0 // 페냐 드롭률 ; 높을 수록 페냐 드롭률 상승
    monsterExpRate = 1.0 // 몬스터 경험치률 ; 높을 수록 몬스터가 주는 경험치 상승
    monsterHitRate = 1.0 // 몬스터 히트률 (몬스터의 공격력) 높을 수록 몬스터의 공격력이 세진다.
  }
}
//----------------------------------------------------------------------------------------------------// 
lang LANG_CHI // 언어 세팅, 이하 한국 버젼에 적용
{
  formula 
  {
    itemDropRate = 1.0 
    goldDropRate = 1.0 
    monsterExpRate = 0.9 
    monsterHitRate = 1.0
  }
  test
  {
    itemDropRate = 1.0 
    goldDropRate = 1.0 
    monsterExpRate = 0.9 
    monsterHitRate = 1.0
  }
}