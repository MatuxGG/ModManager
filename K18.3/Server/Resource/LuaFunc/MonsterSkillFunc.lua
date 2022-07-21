tMonsterSkill = {}

ATK_MELEE = 1
ATK_RANGE = 2

function AddMonster( strMonsterId )
	local nSize = #tMonsterSkill + 1
	
	tMonsterSkill[nSize] = {}
	tMonsterSkill[nSize].strMonsterId = strMonsterId
	tMonsterSkill[nSize].tSkill = {}
end

function AddSkill( nAtkMethod, strSkillId, nSkillLv, nHitCount, nRange, nProb, dwSkillTime, bIgnore )
	local n = #tMonsterSkill
	nSize = #tMonsterSkill[n].tSkill + 1
	
	tMonsterSkill[n].tSkill[nSize] = {}
	tMonsterSkill[n].tSkill[nSize].nAtkMethod	= nAtkMethod
	tMonsterSkill[n].tSkill[nSize].strSkillId	= strSkillId
	tMonsterSkill[n].tSkill[nSize].dwSkillLv	= nSkillLv
	tMonsterSkill[n].tSkill[nSize].nHitCount	= nHitCount - 1
	tMonsterSkill[n].tSkill[nSize].nRange		= nRange
	tMonsterSkill[n].tSkill[nSize].nProb		= nProb
	tMonsterSkill[n].tSkill[nSize].dwSkillTime  = dwSkillTime * 1000
	tMonsterSkill[n].tSkill[nSize].bIgnore	= bIgnore
end