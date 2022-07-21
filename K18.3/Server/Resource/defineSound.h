#ifndef __SOUND_H
#define __SOUND_H

#define SND_NONE                   0 //""가상 아이디"""

#define SND_INF_CLICK              1 //""InfClick.wav"""
#define SND_INF_OPEN               2 //""InfOpen.wav"""
#define SND_INF_CLOSE              3 //""InfClose.wav"""
#define SND_INF_TRADE              4 //""InfTrade.wav"""
#define SND_INF_INVENTORYDROP      5 //""InfInventoryDrop.wav"""
#define SND_INF_GROUNDDROP         6 //""InfGroundDrop.wav"""
#define SND_INF_GROUNDPICKUP       7 //""InfGroundPickup.wav"""
#define SND_INF_EQUIPWEAPON        8 //""InfEqujpWeapon.wav"""
#define SND_INF_EQUIPARMOR         9 //""InfEquipArmor.wav"""
#define SND_INF_EQUIPCLOTH        10 //""InfEquipCloth.wav"""
#define SND_INF_EQUIPACCESSORY    11 //""InfEquipAccessory.wav"""
#define SND_INF_MESSENGERRING     12 //""InfEquipAccessory.wav"""		
#define SND_INF_UPGRADEFAIL       13 //""InfUpgradeFail.wav"""		
#define SND_INF_UPGRADESUCCESS    14 //""InfUpgradeSuccess.wav"""		

// 30 ~ 99 아이템 및 각종 배경 효과음		
#define SND_ITEM_GNEATFOOD        30		
#define SND_ITEM_GNPURFUME        31		
#define SND_ITEM_ANIMAL           32		
#define SND_ITEM_PLANT            33		
#define SND_ITEM_TREE             34		
#define SND_ITEM_MOLLUSCAN        35		
#define SND_ITEM_HAPPYNEWYEARBOMB 36		
#define SND_ITEM_FIRESHOWER       37		
#define SND_ITEM_DROPDING	38	
#define	SND_ITEM_DROPDING1	39


#define SND_GEN_LEVELUP           70
#define SND_GEN_WATER             71
#define SND_GEN_QUAKE             72

// 100 ~ 199 캐릭터 효과음
#define SND_PC_MALEATK1           100
#define SND_PC_MALEATK2           101
#define SND_PC_MALEDMG1           102
#define SND_PC_MALEDIE            103
#define SND_PC_MALEGROOGY         104
#define SND_PC_FEMATK1            105
#define SND_PC_FEMATK2            106
#define SND_PC_FEMDMG1            107
#define SND_PC_FEMDIE             108
#define SND_PC_FEMGROOGY          109
#define SND_PC_FEMJUMP            110
#define SND_PC_MALEJUMP           111
#define SND_PC_MALEDMG2           112
#define SND_PC_FEMDMG2            113
#define SND_PC_MALEFLYATK1        190 
#define SND_PC_MALEFLYATK2        191
#define SND_PC_MALEFLYATK3        192
#define SND_PC_MALEFLYDMG1        193
#define SND_PC_FEMFLYATK1         194
#define SND_PC_FEMFLYATK2         195
#define SND_PC_FEMFLYATK3         196
#define SND_PC_FEMFLYDMG1         197

#define SND_PC_DMGSWD             115// 칼 저급 직접피해          
#define SND_PC_DMGSWDB            116// 칼 초급 직접피해          
#define SND_PC_DMGSWDM            117// 칼 중급 직접피해          
#define SND_PC_DMGSWDH            118// 칼 고급 직접피해          
#define SND_PC_DMGSWDC            119// 칼 크리티컬 피해          
#define SND_PC_DMGCHEB            120// 치어스틱 초급 직접피해    
#define SND_PC_DMGCHEM            121// 치어스틱 중급 직접피해    
#define SND_PC_DMGCHEH            122// 치어스틱 고급 직접피해    
#define SND_PC_DMGCHEC            123// 치어스틱 크리티컬 직접피해
#define SND_PC_DMGWANB            124// 완드 초급 피해            
#define SND_PC_DMGWANM            125// 완드 중급 피해            
#define SND_PC_DMGWANH            126// 완드 고급 피해            
#define SND_PC_DMGWANC            127// 완드 크리티컬 피해        
#define SND_PC_DMGDARB            180// 암기 초급 직접피해    
#define SND_PC_DMGDARM            181// 암기 중급 직접피해    
#define SND_PC_DMGDARH            182// 암기 고급 직접피해    
#define SND_PC_DMGDARC            183// 암기 크리티컬 직접피해
#define SND_PC_DMGMARB            184// 마리오넷 초급 직접피해    
#define SND_PC_DMGMARM            185// 마리오넷 중급 직접피해    
#define SND_PC_DMGMARH            186// 마리오넷 고급 직접피해    
#define SND_PC_DMGMARC            187// 마리오넷 크리티컬 직접피해
#define SND_PC_DMGYOYB            188// 요요 초급 직접피해    
#define SND_PC_DMGYOYM            189// 요요 중급 직접피해    
#define SND_PC_DMGYOYH            99// 요요 고급 직접피해    
#define SND_PC_DMGYOYC            98// 요요 크리티컬 직접피해
#define SND_PC_DMGBOWB            97// 활 초급 직접피해    
#define SND_PC_DMGBOWM            96// 활 중급 직접피해    
#define SND_PC_DMGBOWH            95// 활 고급 직접피해    
#define SND_PC_DMGBOWC            94// 활 크리티컬 직접피해
#define SND_PC_DMGSWDTWOB         93// 양손무기 도끼 초급 직접피해    
#define SND_PC_DMGSWDTWOC         92// 양손무기 도끼 초급 직접피해    
#define SND_PC_DMGAXETWOB         91// 양손무기 칼 초급 직접피해    
#define SND_PC_DMGAXETWOC         90// 양손무기 칼 초급 직접피해    


#define SND_PC_SKILLCASTWPN       130
#define SND_PC_SKILLCASTLIGHT     131 
#define SND_PC_SKILLFIREMAGIC1    132 // 파이어계열마법 시전음
#define SND_PC_SKILLWINDMAGIC     133
#define SND_PC_SKILLCASTWATER     134
#define SND_PC_SKILLCASTEARTH     135
#define SND_PC_MAGICCASTING       136
#define SND_PC_SKILLFIREMAGIC2    137 

#define SND_ITEM_WPNSWD1          140 // 저급 칼 공격음(휘두르는 소리)         
#define SND_ITEM_WPNSWD2          141 // 초급 칼 공격음(휘두르는 소리)         
#define SND_ITEM_WPNSWD3          142 // 중급 칼 공격음(휘두르는 소리)         
#define SND_ITEM_WPNSWD4          143 // 고급 칼 공격음(휘두르는 소리)         
#define SND_ITEM_WPNCHE1          144 // 초급 치어스틱 공격음(휘두르는 소리)   
#define SND_ITEM_WPNCHE2          145 // 중급 치어스틱 공격음(휘두르는 소리)   
#define SND_ITEM_WPNCHE3          146 // 고급 치어스틱 공격음(휘두르는 소리)   
#define SND_ITEM_WPNCHE4          147 // 고급 치어스틱 공격음(휘두르는 소리)   
#define SND_ITEM_WPNDAR1          148 // 암기 초급
#define SND_ITEM_WPNDAR2          149 // 암기 중급
#define SND_ITEM_WPNDAR3          150 // 암기 초급
#define SND_ITEM_WPNDAR4          151 // 암기 중급
#define SND_ITEM_WPNMAR1          152 // 암기 고급
#define SND_ITEM_WPNMAR2          153 // 암기 고급
#define SND_ITEM_WPNMAR3          154 // 마리오넷 초급
#define SND_ITEM_WPNMAR4          155 // 마리오넷 중급
#define SND_ITEM_WPNWANB1         156 // 초급 완드 공격음(발사체 발사소리) 일반
#define SND_ITEM_WPNWANB2         157 // 초급 완드 공격음(발사체 발사소리) 충전
#define SND_ITEM_WPNWANM1         158 // 중급 완드 공격음(발사체 발사소리) 일반
#define SND_ITEM_WPNWANM2         159 // 중급 완드 공격음(발사체 발사소리) 충전
#define SND_ITEM_WPNWANH1         160 // 고급 완드 공격음(발사체 발사소리) 일반
#define SND_ITEM_WPNWANH2         161 // 고급 완드 공격음(발사체 발사소리) 충전
#define SND_ITEM_WPNWANAMPLIFY    162 // 완드 충전 소리                        
#define SND_ITEM_WPNAXE1          163
#define SND_ITEM_WPNAXE2          164
#define SND_ITEM_WPNAXE3          165
#define SND_ITEM_WPNAXE4          166
#define SND_ITEM_WPNKNU1          167
#define SND_ITEM_WPNKNU2          168
#define SND_ITEM_WPNKNU3          169
#define SND_ITEM_WPNKNU4          170
#define SND_ITEM_GNCOLLECTOR      171
#define SND_ITEM_WPNYOY1          172 // 요요 휘두르기1
#define SND_ITEM_WPNYOY2          173 // 요요 휘두르기2
#define SND_ITEM_WPNBOW1          174 // 활 쏘기
#define SND_ITEM_WPNCASE1         175 // 양수 무기 휘두르기1
#define SND_ITEM_WPNCASE2         176 // 양수 무기 휘두르기2
#define SND_ITEM_WPNCASE3         177 // 양수 무기 휘두르기3
#define SND_ITEM_WPNCASE4         178 // 양수 무기 휘두르기4
#define SND_ITEM_WPNTWO1          179 // 양손 무기 휘두르기1
#define SND_ITEM_WPNTWO2          89  // 양손 무기 휘두르기2
#define SND_ITEM_WPNTWO3          88  // 양손 무기 휘두르기3
#define SND_ITEM_WPNTWO4          87  // 양손 무기 휘두르기4


// 200 ~ 999 마술, 스킬 효과음"
#define SND_PC_SKILLM_FIREBOOMERANG1  200
#define SND_PC_SKILLM_FIREBOOMERANG2  201
#define SND_PC_SKILLM_HOTAIR1         202
#define SND_PC_SKILLM_HOTAIR2         203
#define SND_PC_SKILLM_FIREBOMBER1     204
#define SND_PC_SKILLM_FIREBOMBER2     205
#define SND_PC_SKILLM_FIREBOMBER3     206
#define SND_PC_SKILLM_SWORDWIND1      207
#define SND_PC_SKILLM_SWORDWIND2      208
#define SND_PC_SKILLM_STRONGWIND1     209
#define SND_PC_SKILLM_STRONGWIND2     210
#define SND_PC_SKILLD_CLEANHIT        211
#define SND_PC_SKILLD_BRANDISH        212
#define SND_PC_SKILLD_OVERCUTTER      213
#define SND_PC_SKILLD_SPLMASH         214
#define SND_PC_SKILLD_KEENWHEEL       215
#define SND_PC_SKILLD_BLINDSIDE       216
#define SND_PC_SKILLD_PROTECTION      217
#define SND_PC_SKILLD_PANBARRIER_A    218
#define SND_PC_SKILLD_BURSTCRACK      219
#define SND_PC_SKILLD_TAMPINGHOLE     220
#define SND_PC_SKILLM_BLAZINGSW       221
#define SND_PC_SKILLM_SMITEAXE        222
#define SND_PC_SKILLM_FURY            223
#define SND_PC_SKILLM_IMPOWER         224 
#define SND_PC_SKILLD_BLOODYSK1       225
#define SND_PC_SKILLD_BLOODYSK2       226
#define SND_PC_SKILLM_STONEHAND       227
#define SND_PC_SKILLM_QUICKSTEP       228
#define SND_PC_SKILLM_CATSREFLEX      229
#define SND_PC_SKILLM_ACCURACE        230
#define SND_PC_SKILLD_POWERFIST       231
#define SND_PC_SKILLM_MENTALSIGN      232
#define SND_PC_SKILLM_BEEFUP          233
#define SND_PC_SKILLM_PREVENTION      234
#define SND_PC_SKILLM_WATERMAGIC      235
#define SND_PC_SKILLM_ICEMISSILE1     236
#define SND_PC_SKILLM_ELECTMAGIC      237
#define SND_PC_SKILLM_LGTBALL1        238
#define SND_PC_SKILLM_EARTHMAGIC      239
#define SND_PC_SKILLM_SPIKESTONE1     240
#define SND_PC_SKILLM_NOMALMAGIC      241
#define SND_PC_SKILLM_MENTALSTK       242		
#define SND_PC_SKILLM_ELECURSE        243		
#define SND_PC_SKILLM_LGTREFLECT      244		
#define SND_PC_SKILLM_MEDITATION      245		

#define SND_PC_SKILLM_WEAMASTERY	246	
#define SND_PC_SKILLD_GUILLOTINE	247	
#define SND_PC_SKILLM_SNEAKER		248
#define SND_PC_SKILLM_REFHIT		249
#define SND_PC_SKILLM_GUARD		250
#define SND_PC_SKILLM_RAGE		252
#define SND_PC_SKILLD_POWERSWING	253	
#define SND_PC_SKILLD_EARTHDIV		254
#define SND_PC_SKILLD_CHARGE		255
#define SND_PC_SKILLD_PAINDEALER	256	
#define SND_PC_SKILLD_POWERSTUMP	257	
#define SND_PC_SKILLD_CROSSSTK		258
#define SND_PC_SKILLD_ARMORPEN		259
#define SND_PC_SKILLD_SILENTSTK		260
#define SND_PC_SKILLD_BLADEDANCE	261	
#define SND_PC_SKILLD_SPRINGATK		262
#define SND_PC_SKILLD_HAWKATK		263
#define SND_PC_SKILLD_SONICBLADE	264	
#define SND_PC_SKILLM_BERZERKE		265
#define SND_PC_SKILLM_HAST		266
#define SND_PC_SKILLM_HEALRAIN		267
#define SND_PC_SKILLM_HOLYCROSS		268
#define SND_PC_SKILLM_PROTECTION	269	
#define SND_PC_SKILLM_HOLYGUARD		270
#define SND_PC_SKILLM_SPRITEFOT		271
#define SND_PC_SKILLM_GVURTIALLA	272	
#define SND_PC_SKILLM_GEBURAH		273
#define SND_PC_SKILLM_ANZELRUSHA	274	
#define SND_PC_SKILLD_BELIALSMA		275
#define SND_PC_SKILLD_PIERCINGSER	276	
#define SND_PC_SKILLD_BLOODFIST		277
#define SND_PC_SKILLD_SONICHAND		278
#define SND_PC_SKILLD_ASMODEUS		279
#define SND_PC_SKILLD_BARAQIJAL		280
#define SND_PC_SKILLD_GVURTIAL		281
#define SND_PC_SKILLD_ASALRAALA		282
#define SND_PC_SKILLM_FIRESTK		283
#define SND_PC_SKILLM_WINDCUTTER	284	
#define SND_PC_SKILLM_WATERBALL		285
#define SND_PC_SKILLM_SPRINGWAT		286
#define SND_PC_SKILLM_LGTPALM		287
#define SND_PC_SKILLM_LGTSHOCK		288
#define SND_PC_SKILLM_ROCKCRASH		289
#define SND_PC_SKILLM_LOOTING		290
#define SND_PC_SKILLM_DEMONOLGY		291
#define SND_PC_SKILLM_SATANOLGY		292
#define SND_PC_SKILLM_PSYBOMB		293
#define SND_PC_SKILLM_PSYWALL1		294
#define SND_PC_SKILLM_PSYWALL2		295
#define SND_PC_SKILLM_SPRITBOMB		296
#define SND_PC_SKILLM_CRUCIOSP		297
#define SND_PC_SKILLM_MAXCRISIS		298
#define SND_PC_SKILLM_PSYSQUARE		299
#define SND_PC_SKILLM_FIRECASTING	300	
#define SND_PC_SKILLM_FIREBIRD		301
#define SND_PC_SKILLM_FIREMASTER	302	
#define SND_PC_SKILLM_BURINGFLD1	303	
#define SND_PC_SKILLM_BURINGFLD2	304	
#define SND_PC_SKILLM_ELECASTING	305	
#define SND_PC_SKILLM_THUNDERSTK	306	
#define SND_PC_SKILLM_ELEMASTER		307
#define SND_PC_SKILLM_ELESHOCK		308
#define SND_PC_SKILLM_EARTHCASTING	309	
#define SND_PC_SKILLM_STONESPR		310
#define SND_PC_SKILLM_EARTHMASTER	311	
#define SND_PC_SKILLM_EARTHQUAKE	312	
#define SND_PC_SKILLM_WATERCASTING	313	
#define SND_PC_SKILLM_ICESHARK		314
#define SND_PC_SKILLM_WATMASTER		315
#define SND_PC_SKILLM_POISONFLD1	316	
#define SND_PC_SKILLM_POISONFLD2	317	
#define SND_PC_SKILLM_WINDCASTING	318	
#define SND_PC_SKILLM_VOID		319
#define SND_PC_SKILLM_WINDMASTER	320	
#define SND_PC_SKILLM_WINDFLD1		321
#define SND_PC_SKILLM_WINDFLD2		322
#define SND_PC_SKILLM_MULTICASTING	323	
#define SND_PC_SKILLM_METEO		324
#define SND_PC_SKILLM_LGTSTORM		325
#define SND_PC_SKILLM_SANDSTORM		326
#define SND_PC_SKILLM_AVALANCH		327
#define SND_PC_SKILLM_BOWSHOT		328
#define SND_PC_SKILLD_HITOFPENYA    	329		
#define SND_PC_BOSS_CRASH		330
#define SND_PC_BOSS_SUMMONS		331
#define SND_PC_BOSS_STUN		332

#define SND_PC_ACTIONOULINE01		333
#define SND_PC_ACTIONOULINE02		334
#define SND_PC_ACTIONREGISTER		335
#define SND_PC_ACTIONREMOVE		336
#define SND_PC_ACTIONSLOTMOVE01		337
#define SND_PC_ACTIONSLOTMOVE02		338
#define SND_PC_ACTIONSTART		339
#define SND_PC_SLOTADD			340
#define SND_PC_SLOTCHANGE		341
#define SND_PC_SLOTDRAGEADD		342
#define SND_PC_SLOTREMOVE		343


// 900 배경 효과음		
#define SND_BGAB_WATERFALL            900		
#define SND_BGAB_WINDMILL             901		
#define SND_BGAB_FOUNTAIN             902
#define SND_BGAB_INSECT               903
#define SND_BGAB_OWL                  904
#define SND_BGAB_WOLF                 905
#define SND_BGAB_WIND                 906
#define SND_BGAB_RAINDROP             907
#define SND_BGAB_RAINSHOWER           908
#define SND_BGAB_CRANE                909
#define SND_BGAB_DRILL                910
#define SND_BGAB_BIGFANSLOW           911
#define SND_BGAB_EXCAV                912
#define SND_BGAB_ERTANK               913
#define SND_BGAB_PIPE                 914
#define SND_BGAB_SPTLIGHT             915
#define SND_BGAB_BIGFANFAST           916
#define SND_BGAB_EXCAV2               917

#define SND_BGAB_FLARISALARMCLOCK     918
#define SND_BGAB_FLARISBIRD	      919


// 950 NPC 효과음 [75%]
#define SND_NPCAB_BOBOKU              950
#define SND_NPCAB_DWARPET             951

// 1000 ~ 1099 공통사운드
#define SND_NPC_COMSLUMP1        1000 // 작은크기
#define SND_NPC_COMSLUMP2        1001 // 중간크기
#define SND_NPC_COMSLUMP3        1002 // 큰 크기
#define SND_NPC_COMSLUMP4        1003
#define SND_NPC_COMSLUMP5        1004
#define SND_NPC_COMWHISTLE       1006 // 작은넘 휘슬
#define SND_NPC_COMWHISTLE2      1007 // 중간넘 휘슬
#define SND_NPC_COMWHISTLE3      1008 // 큰넘 휘슬
#define SND_NPC_COMWHISTLE4      1009 // 졸라 큰넘 날아가지 않고 밀리기

#define SND_NPC_COMBLUNTSWING    1010
#define SND_NPC_COMSWING01       1011
#define SND_NPC_COMSWING02       1012
#define SND_NPC_COMSWING03       1013
#define SND_NPC_COMSWING04       1014
#define SND_NPC_COMSWING05       1015
#define SND_NPC_COMSWING06       1016
#define SND_NPC_COMSWING07       1017
#define SND_NPC_COMSWING08       1018
#define SND_NPC_COMSWING09       1019
#define SND_NPC_COMHIT01         1026 // 공격에 의해서 피해받을때 나는 소리
#define SND_NPC_COMHIT02         1027
#define SND_NPC_COMHIT03         1028
#define SND_NPC_COMHIT04         1029
#define SND_NPC_COMHIT05         1030
#define SND_NPC_COMHIT06         1031
#define SND_NPC_COMHIT07         1032
#define SND_NPC_COMHIT08         1033
#define SND_NPC_COMHIT09         1034
#define SND_NPC_COMHIT10         1035


#define SND_JUMP_LANDING         1201
#define SND_WALK_LANDSOFT        1202
#define SND_WALK_HARD            1203
#define SND_WALK_GRASSSOFT       1204
#define SND_WALK_GRASSHARD       1205
#define SND_WALK_SIDESOFT        1206
#define SND_WALK_SIDEHARD        1207
#define SND_WALK_SWARM           1208
#define SND_WALK_WATER           1209
#define SND_WALK_SAND            1210
#define SND_WALK_SNOW            1211
#define SND_WALK_ASH             1212
#define SND_WALK_SWIM            1213

//CTROLER SOUND
#define SND_CTRL_ITEMBOXOPEN1    1250
#define SND_CTRL_ITEMBOXOPEN2    1251


// 100 부터 몬스터 관련 효과음
#define SND_NPC_BUFFATK1           1300
#define SND_NPC_BUFFATK2           1301
#define SND_NPC_BUFFDIE1           1302
#define SND_NPC_BUFFDIE2           1303 //쿵소리와 함께
#define SND_NPC_BUFFIDLE1          1304 //몹의 고유소리 있으면 넣고 없으면 무시
#define SND_NPC_BUFFIDLE2          1305
#define SND_NPC_BUFFDMG1           1306 //몹의 고유소리 있으면 넣고 없으면 무시
#define SND_NPC_BUFFDMG2           1307
#define SND_NPC_AIBATTATK1         1308
#define SND_NPC_AIBATTATK2         1309
#define SND_NPC_AIBATTDIE1         1310
#define SND_NPC_AIBATTDIE2         1311
#define SND_NPC_AIBATTFLYDIE1      1312
#define SND_NPC_AIBATTIDLE1        1313
#define SND_NPC_AIBATTIDLE2        1314
#define SND_NPC_AIBATTDMG1         1315
#define SND_NPC_AIBATTDMG2         1316
#define SND_NPC_BURUDENGATK1       1317
#define SND_NPC_BURUDENGATK2       1318
#define SND_NPC_BURUDENGDIE1       1319
#define SND_NPC_BURUDENGDIE2       1320
#define SND_NPC_BURUDENGFLYDIE1    1321
#define SND_NPC_BURUDENGIDLE1      1322
#define SND_NPC_BURUDENGIDLE2      1323
#define SND_NPC_BURUDENGDMG1       1324
#define SND_NPC_BURUDENGDMG2       1325
#define SND_NPC_PUKEPUKEATK1       1326
#define SND_NPC_PUKEPUKEATK2       1327
#define SND_NPC_PUKEPUKEDIE1       1328
#define SND_NPC_PUKEPUKEDIE2       1329
#define SND_NPC_PUKEPUKEFLYDIE1    1330
#define SND_NPC_PUKEPUKEIDLE1      1331
#define SND_NPC_PUKEPUKEIDLE2      1332
#define SND_NPC_PUKEPUKEDMG1       1333
#define SND_NPC_PUKEPUKEDMG2       1334
#define SND_NPC_DORIDOMAATK1       1335
#define SND_NPC_DORIDOMAATK2       1336
#define SND_NPC_DORIDOMADIE1       1337
#define SND_NPC_DORIDOMADIE2       1338
#define SND_NPC_DORIDOMAFLYDIE1    1339
#define SND_NPC_DORIDOMAIDLE1      1340
#define SND_NPC_DORIDOMAIDLE2      1341
#define SND_NPC_DORIDOMADMG1       1342
#define SND_NPC_DORIDOMADMG2       1343
#define SND_NPC_LAWOLFATK1         1344
#define SND_NPC_LAWOLFATK2         1345
#define SND_NPC_LAWOLFDIE1         1346
#define SND_NPC_LAWOLFDIE2         1347
#define SND_NPC_LAWOLFFLYDIE1      1348
#define SND_NPC_LAWOLFIDLE1        1349
#define SND_NPC_LAWOLFIDLE2        1350
#define SND_NPC_LAWOLFDMG1         1351
#define SND_NPC_LAWOLFDMG2         1352
#define SND_NPC_NYANGNYANGATK1     1353
#define SND_NPC_NYANGNYANGATK2     1354
#define SND_NPC_NYANGNYANGDIE1     1355
#define SND_NPC_NYANGNYANGDIE2     1356
#define SND_NPC_NYANGNYANGFLYDIE1  1357
#define SND_NPC_NYANGNYANGIDLE1    1358
#define SND_NPC_NYANGNYANGIDLE2    1359
#define SND_NPC_NYANGNYANGDMG1     1360
#define SND_NPC_NYANGNYANGDMG2     1361
#define SND_NPC_BANGATK1           1362
#define SND_NPC_BANGATK2           1363
#define SND_NPC_BANGDIE1           1364
#define SND_NPC_BANGDIE2           1365
#define SND_NPC_BANGFLYDIE1        1366
#define SND_NPC_BANGIDLE1          1367
#define SND_NPC_BANGIDLE2          1368
#define SND_NPC_BANGDMG1           1369
#define SND_NPC_BANGDMG2           1370
#define SND_NPC_WAGSAACATK1        1371
#define SND_NPC_WAGSAACATK2        1372
#define SND_NPC_WAGSAACDIE1        1373
#define SND_NPC_WAGSAACDIE2        1374
#define SND_NPC_WAGSAACFLYDIE1     1375
#define SND_NPC_WAGSAACDMG1        1376
#define SND_NPC_WAGSAACDMG2        1377
#define SND_NPC_WAGSAACIDLE1       1378
#define SND_NPC_WAGSAACIDLE2       1379
#define SND_NPC_WHEELEMATK1        1380
#define SND_NPC_WHEELEMATK2        1381
#define SND_NPC_WHEELEMDIE1        1382
#define SND_NPC_WHEELEMDIE2        1383
#define SND_NPC_WHEELEMFLYDIE1     1384
#define SND_NPC_WHEELEMDMG1        1385
#define SND_NPC_WHEELEMDMG2        1386
#define SND_NPC_WHEELEMIDLE1       1387
#define SND_NPC_WHEELEMIDLE2       1388
#define SND_NPC_TOTEMIAATK1        1389
#define SND_NPC_TOTEMIAATK2        1390
#define SND_NPC_TOTEMIADIE1        1391
#define SND_NPC_TOTEMIADIE2        1392
#define SND_NPC_TOTEMIAFLYDIE1     1393
#define SND_NPC_TOTEMIADMG1        1394
#define SND_NPC_TOTEMIADMG2        1395
#define SND_NPC_TOTEMIAIDLE1       1396
#define SND_NPC_TOTEMIAIDLE2       1397
#define SND_NPC_BASQUEATK1         1398
#define SND_NPC_BASQUEATK2         1399
#define SND_NPC_BASQUEDIE1         1400
#define SND_NPC_BASQUEDIE2         1401
#define SND_NPC_BASQUEFLYDIE1      1402
#define SND_NPC_BASQUEDMG1         1403
#define SND_NPC_BASQUEDMG2         1404
#define SND_NPC_BASQUEIDLE1        1405
#define SND_NPC_BASQUEIDLE2        1406
#define SND_NPC_FEFERNATK1         1407
#define SND_NPC_FEFERNATK2         1408
#define SND_NPC_FEFERNDIE1         1409
#define SND_NPC_FEFERNDIE2         1410
#define SND_NPC_FEFERNFLYDIE1      1411
#define SND_NPC_FEFERNDMG1         1412
#define SND_NPC_FEFERNDMG2         1413
#define SND_NPC_FEFERNIDLE1        1414
#define SND_NPC_FEFERNIDLE2        1415
#define SND_NPC_MRPUMPKINATK1      1416
#define SND_NPC_MRPUMPKINATK2      1417
#define SND_NPC_MRPUMPKINDIE1      1418
#define SND_NPC_MRPUMPKINDIE2      1419
#define SND_NPC_MRPUMPKINFLYDIE1   1420
#define SND_NPC_MRPUMPKINDMG1      1421
#define SND_NPC_MRPUMPKINDMG2      1422
#define SND_NPC_MRPUMPKINIDLE1     1423
#define SND_NPC_MRPUMPKINIDLE2     1424
#define SND_NPC_REDMANTISATK1      1425
#define SND_NPC_REDMANTISATK2      1426
#define SND_NPC_REDMANTISDIE1      1427
#define SND_NPC_REDMANTISDIE2      1428
#define SND_NPC_REDMANTISFLYDIE1   1429
#define SND_NPC_REDMANTISDMG1      1430
#define SND_NPC_REDMANTISDMG2      1431
#define SND_NPC_REDMANTISIDLE1     1432
#define SND_NPC_REDMANTISIDLE2     1433
#define SND_NPC_PRANKSTERATK1      1434
#define SND_NPC_PRANKSTERATK2      1435
#define SND_NPC_PRANKSTERDIE1      1436
#define SND_NPC_PRANKSTERDIE2      1437
#define SND_NPC_PRANKSTERFLYDIE1   1438
#define SND_NPC_PRANKSTERDMG1      1439
#define SND_NPC_PRANKSTERDMG2      1440
#define SND_NPC_PRANKSTERIDLE1     1441
#define SND_NPC_PRANKSTERIDLE2     1442
#define SND_NPC_CARDPUPPETATK1     1443
#define SND_NPC_CARDPUPPETATK2     1444
#define SND_NPC_CARDPUPPETDIE1     1445
#define SND_NPC_CARDPUPPETDIE2     1446
#define SND_NPC_CARDPUPPETFLYDIE1  1447
#define SND_NPC_CARDPUPPETDMG1     1448
#define SND_NPC_CARDPUPPETDMG2     1449
#define SND_NPC_CARDPUPPETIDLE1    1450
#define SND_NPC_CARDPUPPETIDLE2    1451
#define SND_NPC_DEMIANATK1         1452 // 데미안 
#define SND_NPC_DEMIANATK2         1453
#define SND_NPC_DEMIANDIE1         1454
#define SND_NPC_DEMIANDIE2         1455
#define SND_NPC_DEMIANFLYDIE1      1456
#define SND_NPC_DEMIANDMG1         1457
#define SND_NPC_DEMIANDMG2         1458
#define SND_NPC_DEMIANIDLE1        1459
#define SND_NPC_DEMIANIDLE2        1460
#define SND_NPC_MUSHPANGATK1       1461 // 머슈팡
#define SND_NPC_MUSHPANGATK2       1462
#define SND_NPC_MUSHPANGDIE1       1463
#define SND_NPC_MUSHPANGDIE2       1464
#define SND_NPC_MUSHPANGFLYDIE1    1465
#define SND_NPC_MUSHPANGDMG1       1466
#define SND_NPC_MUSHPANGDMG2       1467
#define SND_NPC_MUSHPANGIDLE1      1468
#define SND_NPC_MUSHPANGIDLE2      1469
#define SND_NPC_ROCKMUSCLEATK1     1470 // 락머슬
#define SND_NPC_ROCKMUSCLEATK2     1471
#define SND_NPC_ROCKMUSCLEDIE1     1472    
#define SND_NPC_ROCKMUSCLEDIE2     1473
#define SND_NPC_ROCKMUSCLEFLYDIE1  1474
#define SND_NPC_ROCKMUSCLEDMG1     1475
#define SND_NPC_ROCKMUSCLEDMG2     1476
#define SND_NPC_ROCKMUSCLEIDLE1    1477
#define SND_NPC_ROCKMUSCLEIDLE2    1478
#define SND_NPC_TOMBSTONEBEARERATK1     1479   // 툼스톤베어러
#define SND_NPC_TOMBSTONEBEARERATK2     1480
#define SND_NPC_TOMBSTONEBEARERDIE1     1481    
#define SND_NPC_TOMBSTONEBEARERDIE2     1482
#define SND_NPC_TOMBSTONEBEARERFLYDIE1  1483
#define SND_NPC_TOMBSTONEBEARERDMG1     1484
#define SND_NPC_TOMBSTONEBEARERDMG2     1485
#define SND_NPC_TOMBSTONEBEARERIDLE1    1486
#define SND_NPC_TOMBSTONEBEARERIDLE2    1487
#define SND_NPC_STEAMWALKERATK1         1488 // 스팀워커
#define SND_NPC_STEAMWALKERATK2         1489
#define SND_NPC_STEAMWALKERDIE1         1490
#define SND_NPC_STEAMWALKERDIE2         1491
#define SND_NPC_STEAMWALKERFLYDIE1      1492
#define SND_NPC_STEAMWALKERDMG1         1493
#define SND_NPC_STEAMWALKERDMG2         1494
#define SND_NPC_STEAMWALKERIDLE1        1495
#define SND_NPC_STEAMWALKERIDLE2        1496

#define SND_NPC_VOLTATK1                   1497
#define SND_NPC_VOLTATK2                   1498
#define SND_NPC_VOLTDIE1                   1499
#define SND_NPC_VOLTDMG1                   1500
#define SND_NPC_VOLTDMG2                   1501
#define SND_NPC_VOLTDMGDIE1                1502
#define SND_NPC_VOLTDMGFLY1                1503
#define SND_NPC_VOLTDMGLIVE1               1504
#define SND_NPC_VOLTGROOGY1                1505
#define SND_NPC_VOLTIDLE1                  1506
#define SND_NPC_CIRCUSBEARATK1             1507
#define SND_NPC_CIRCUSBEARATK2             1508
#define SND_NPC_CIRCUSBEARDIE1             1509
#define SND_NPC_CIRCUSBEARDMG1             1510
#define SND_NPC_CIRCUSBEARDMG2             1511
#define SND_NPC_CIRCUSBEARDMGDIE1          1512
#define SND_NPC_CIRCUSBEARDMGFLY1          1513
#define SND_NPC_CIRCUSBEARDMGLIVE1         1514
#define SND_NPC_CIRCUSBEARGROOGY1          1515
#define SND_NPC_CIRCUSBEARIDLE1            1516
#define SND_NPC_MIAATK1                    1517
#define SND_NPC_MIAATK2                    1518
#define SND_NPC_MIADIE1                    1519
#define SND_NPC_MIADMG1                    1520
#define SND_NPC_MIADMG2                    1521
#define SND_NPC_MIADMGDIE1                 1522
#define SND_NPC_MIADMGFLY1                 1523
#define SND_NPC_MIADMGLIVE1                1524
#define SND_NPC_MIAGROOGY1                 1525
#define SND_NPC_MIAIDLE1                   1526
#define SND_NPC_PIREATK1                   1527
#define SND_NPC_PIREATK2                   1528
#define SND_NPC_PIREDIE1                   1529
#define SND_NPC_PIREDMG1                   1530
#define SND_NPC_PIREDMG2                   1531
#define SND_NPC_PIREDMGDIE1                1532
#define SND_NPC_PIREDMGFLY1                1533
#define SND_NPC_PIREDMGLIVE1               1534
#define SND_NPC_PIREGROOGY1                1535
#define SND_NPC_PIREIDLE1                  1536
#define SND_NPC_FROZIESTATK1               1537
#define SND_NPC_FROZIESTATK2               1538
#define SND_NPC_FROZIESTDIE1               1539
#define SND_NPC_FROZIESTDMG1               1540
#define SND_NPC_FROZIESTDMG2               1541
#define SND_NPC_FROZIESTDMGDIE1            1542
#define SND_NPC_FROZIESTDMGFLY1            1543
#define SND_NPC_FROZIESTDMGLIVE1           1544
#define SND_NPC_FROZIESTGROOGY1            1545
#define SND_NPC_FROZIESTIDLE1              1546
#define SND_NPC_ERONSCATCHERATK1           1547
#define SND_NPC_ERONSCATCHERATK2           1548
#define SND_NPC_ERONSCATCHERDIE1           1549
#define SND_NPC_ERONSCATCHERDMG1           1550
#define SND_NPC_ERONSCATCHERDMG2           1551
#define SND_NPC_ERONSCATCHERDMGDIE1        1552
#define SND_NPC_ERONSCATCHERDMGFLY1        1553
#define SND_NPC_ERONSCATCHERDMGLIVE1       1554
#define SND_NPC_ERONSCATCHERGROOGY1        1555
#define SND_NPC_ERONSCATCHERIDLE1          1556
#define SND_NPC_MINECATCHERATK1            1557
#define SND_NPC_MINECATCHERATK2            1558
#define SND_NPC_MINECATCHERDIE1            1559
#define SND_NPC_MINECATCHERDMG1            1560
#define SND_NPC_MINECATCHERDMG2            1561
#define SND_NPC_MINECATCHERDMGDIE1         1562
#define SND_NPC_MINECATCHERDMGFLY1         1563
#define SND_NPC_MINECATCHERDMGLIVE1        1564
#define SND_NPC_MINECATCHERGROOGY1         1565
#define SND_NPC_MINECATCHERIDLE1           1566
#define SND_NPC_BURNBIRDATK1               1567
#define SND_NPC_BURNBIRDATK2               1568
#define SND_NPC_BURNBIRDDIE1               1569
#define SND_NPC_BURNBIRDDMG1               1570
#define SND_NPC_BURNBIRDDMG2               1571
#define SND_NPC_BURNBIRDDMGDIE1            1572
#define SND_NPC_BURNBIRDDMGFLY1            1573
#define SND_NPC_BURNBIRDDMGLIVE1           1574
#define SND_NPC_BURNBIRDGROOGY1            1575
#define SND_NPC_BURNBIRDIDLE1              1576
#define SND_NPC_CLOCKWORKSATK1             1577
#define SND_NPC_CLOCKWORKSATK2             1578
#define SND_NPC_CLOCKWORKSATK3             1579
#define SND_NPC_CLOCKWORKSATK4             1580
#define SND_NPC_CLOCKWORKSDIE1             1581
#define SND_NPC_CLOCKWORKSENTRY1           1582
#define SND_NPC_CLOCKWORKSENTRY2           1583
#define SND_NPC_CLOCKWORKSWALK1            1584


#define SND_NPC_BUKETFOOTATK1              1587
#define SND_NPC_BUKETFOOTATK2              1588
#define SND_NPC_BUKETFOOTDIE1              1589
#define SND_NPC_BUKETFOOTDMG1              1590
#define SND_NPC_BUKETFOOTDMG2              1591
#define SND_NPC_BUKETFOOTDMGDIE1           1592
#define SND_NPC_BUKETFOOTDMGFLY1           1593
#define SND_NPC_BUKETFOOTDMGLIVE1          1594
#define SND_NPC_BUKETFOOTGROOGY1           1595
#define SND_NPC_BUKETFOOTIDLE1             1596
#define SND_NPC_FLBYRIGENATK1              1597
#define SND_NPC_FLBYRIGENATK2              1598
#define SND_NPC_FLBYRIGENDIE1              1599
#define SND_NPC_FLBYRIGENDMG1              1600
#define SND_NPC_FLBYRIGENDMG2              1601
#define SND_NPC_FLBYRIGENDMGDIE1           1602
#define SND_NPC_FLBYRIGENDMGFLY1           1603
#define SND_NPC_FLBYRIGENDMGLIVE1          1604
#define SND_NPC_FLBYRIGENGROOGY1           1605
#define SND_NPC_FLBYRIGENIDLE1             1606
#define SND_NPC_MOTHBEEATK1                1607
#define SND_NPC_MOTHBEEATK2                1608
#define SND_NPC_MOTHBEEDIE1                1609
#define SND_NPC_MOTHBEEDMG1                1610
#define SND_NPC_MOTHBEEDMG2                1611
#define SND_NPC_MOTHBEEDMGDIE1             1612
#define SND_NPC_MOTHBEEDMGFLY1             1613
#define SND_NPC_MOTHBEEDMGLIVE1            1614
#define SND_NPC_MOTHBEEGROOGY1             1615
#define SND_NPC_MOTHBEEIDLE1               1616
#define SND_NPC_ROCKEPELLERATK1            1617
#define SND_NPC_ROCKEPELLERATK2            1618
#define SND_NPC_ROCKEPELLERDIE1            1619
#define SND_NPC_ROCKEPELLERDMG1            1620
#define SND_NPC_ROCKEPELLERDMG2            1621
#define SND_NPC_ROCKEPELLERDMGDIE1         1622
#define SND_NPC_ROCKEPELLERDMGFLY1         1623
#define SND_NPC_ROCKEPELLERDMGLIVE1        1624
#define SND_NPC_ROCKEPELLERGROOGY1         1625
#define SND_NPC_ROCKEPELLERIDLE1           1626
#define SND_NPC_GIGGLEBOXATK1              1627
#define SND_NPC_GIGGLEBOXATK2              1628
#define SND_NPC_GIGGLEBOXDIE1              1629
#define SND_NPC_GIGGLEBOXDMG1              1630
#define SND_NPC_GIGGLEBOXDMG2              1631
#define SND_NPC_GIGGLEBOXDMGDIE1           1632
#define SND_NPC_GIGGLEBOXDMGFLY1           1633
#define SND_NPC_GIGGLEBOXDMGLIVE1          1634
#define SND_NPC_GIGGLEBOXGROOGY1           1635
#define SND_NPC_GIGGLEBOXIDLE1             1636
#define SND_NPC_GARBAGEPIDERATK1           1637
#define SND_NPC_GARBAGEPIDERATK2           1638
#define SND_NPC_GARBAGEPIDERDIE1           1639
#define SND_NPC_GARBAGEPIDERDMG1           1640
#define SND_NPC_GARBAGEPIDERDMG2           1641
#define SND_NPC_GARBAGEPIDERDMGDIE1        1642
#define SND_NPC_GARBAGEPIDERDMGFLY1        1643
#define SND_NPC_GARBAGEPIDERDMGLIVE1       1644
#define SND_NPC_GARBAGEPIDERGROOGY1        1645
#define SND_NPC_GARBAGEPIDERIDLE1          1646
#define SND_NPC_RAMPAGEBUTCHERATK1         1647
#define SND_NPC_RAMPAGEBUTCHERATK2         1648
#define SND_NPC_RAMPAGEBUTCHERDIE1         1649
#define SND_NPC_RAMPAGEBUTCHERDMG1         1650
#define SND_NPC_RAMPAGEBUTCHERDMG2         1651
#define SND_NPC_RAMPAGEBUTCHERDMGDIE1      1652
#define SND_NPC_RAMPAGEBUTCHERDMGFLY1      1653
#define SND_NPC_RAMPAGEBUTCHERDMGLIVE1     1654
#define SND_NPC_RAMPAGEBUTCHERGROOGY1      1655
#define SND_NPC_RAMPAGEBUTCHERIDLE1        1656
#define SND_NPC_GREEMONGATK1               1657
#define SND_NPC_GREEMONGATK2               1658
#define SND_NPC_GREEMONGDIE1               1659
#define SND_NPC_GREEMONGDMG1               1660
#define SND_NPC_GREEMONGDMG2               1661
#define SND_NPC_GREEMONGDMGDIE1            1662
#define SND_NPC_GREEMONGDMGFLY1            1663
#define SND_NPC_GREEMONGDMGLIVE1           1664
#define SND_NPC_GREEMONGGROOGY1            1665
#define SND_NPC_GREEMONGIDLE1              1666
#define SND_NPC_DRILLERATK1                1667
#define SND_NPC_DRILLERATK2                1668
#define SND_NPC_DRILLERDIE1                1669
#define SND_NPC_DRILLERDMG1                1670
#define SND_NPC_DRILLERDMG2                1671
#define SND_NPC_DRILLERDMGDIE1             1672
#define SND_NPC_DRILLERDMGFLY1             1673
#define SND_NPC_DRILLERDMGLIVE1            1674
#define SND_NPC_DRILLERGROOGY1             1675
#define SND_NPC_DRILLERIDLE1               1676
#define SND_NPC_STEELKNIGHTATK1            1677
#define SND_NPC_STEELKNIGHTATK2            1678
#define SND_NPC_STEELKNIGHTDIE1            1679
#define SND_NPC_STEELKNIGHTDMG1            1680
#define SND_NPC_STEELKNIGHTDMG2            1681
#define SND_NPC_STEELKNIGHTDMGDIE1         1682
#define SND_NPC_STEELKNIGHTDMGFLY1         1683
#define SND_NPC_STEELKNIGHTDMGLIVE1        1684
#define SND_NPC_STEELKNIGHTGROOGY1         1685
#define SND_NPC_STEELKNIGHTIDLE1           1686
#define SND_NPC_ELDERGUARDATK1             1687
#define SND_NPC_ELDERGUARDATK2             1688
#define SND_NPC_ELDERGUARDDIE1             1689
#define SND_NPC_ELDERGUARDDMG1             1690
#define SND_NPC_ELDERGUARDDMG2             1691
#define SND_NPC_ELDERGUARDDMGDIE1          1692
#define SND_NPC_ELDERGUARDDMGFLY1          1693
#define SND_NPC_ELDERGUARDDMGLIVE1         1694
#define SND_NPC_ELDERGUARDGROOGY1          1695
#define SND_NPC_ELDERGUARDIDLE1            1696
#define SND_NPC_CRANEMACHINERYATK1         1697
#define SND_NPC_CRANEMACHINERYATK2         1698
#define SND_NPC_CRANEMACHINERYDIE1         1699
#define SND_NPC_CRANEMACHINERYDMG1         1700
#define SND_NPC_CRANEMACHINERYDMG2         1701
#define SND_NPC_CRANEMACHINERYDMGDIE1      1702
#define SND_NPC_CRANEMACHINERYDMGFLY1      1703
#define SND_NPC_CRANEMACHINERYDMGLIVE1     1704
#define SND_NPC_CRANEMACHINERYGROOGY1      1705
#define SND_NPC_CRANEMACHINERYIDLE1        1706
#define SND_NPC_POPCRANKATK1               1707
#define SND_NPC_POPCRANKATK2               1708
#define SND_NPC_POPCRANKDIE1               1709
#define SND_NPC_POPCRANKDMG1               1710
#define SND_NPC_POPCRANKDMG2               1711
#define SND_NPC_POPCRANKDMGDIE1            1712
#define SND_NPC_POPCRANKDMGFLY1            1713
#define SND_NPC_POPCRANKDMGLIVE1           1714
#define SND_NPC_POPCRANKGROOGY1            1715
#define SND_NPC_POPCRANKIDLE1              1716
#define SND_NPC_PEAKYTURTLEATK1            1717
#define SND_NPC_PEAKYTURTLEATK2            1718
#define SND_NPC_PEAKYTURTLEDIE1            1719
#define SND_NPC_PEAKYTURTLEDMG1            1720
#define SND_NPC_PEAKYTURTLEDMG2            1721
#define SND_NPC_PEAKYTURTLEDMGDIE1         1722
#define SND_NPC_PEAKYTURTLEDMGFLY1         1723
#define SND_NPC_PEAKYTURTLEDMGLIVE1        1724
#define SND_NPC_PEAKYTURTLEGROOGY1         1725
#define SND_NPC_PEAKYTURTLEIDLE1           1726
#define SND_NPC_HOBOATK1                   1727
#define SND_NPC_HOBOATK2                   1728
#define SND_NPC_HOBODIE1                   1729
#define SND_NPC_HOBODMG1                   1730
#define SND_NPC_HOBODMG2                   1731
#define SND_NPC_HOBODMGDIE1                1732
#define SND_NPC_HOBODMGFLY1                1733
#define SND_NPC_HOBODMGLIVE1               1734
#define SND_NPC_HOBOGROOGY1                1735
#define SND_NPC_HOBOIDLE1                  1736
#define SND_NPC_CLAWDOLLATK1               1737
#define SND_NPC_CLAWDOLLATK2               1738
#define SND_NPC_CLAWDOLLDIE1               1739
#define SND_NPC_CLAWDOLLDMG1               1740
#define SND_NPC_CLAWDOLLDMG2               1741
#define SND_NPC_CLAWDOLLDMGDIE1            1742
#define SND_NPC_CLAWDOLLDMGFLY1            1743
#define SND_NPC_CLAWDOLLDMGLIVE1           1744
#define SND_NPC_CLAWDOLLGROOGY1            1745
#define SND_NPC_CLAWDOLLIDLE1              1746
#define SND_NPC_CARRIERBOMBATK1            1747
#define SND_NPC_CARRIERBOMBATK2            1748
#define SND_NPC_CARRIERBOMBDIE1            1749
#define SND_NPC_CARRIERBOMBDMG1            1750
#define SND_NPC_CARRIERBOMBDMG2            1751
#define SND_NPC_CARRIERBOMBDMGDIE1         1752
#define SND_NPC_CARRIERBOMBDMGFLY1         1753
#define SND_NPC_CARRIERBOMBDMGLIVE1        1754
#define SND_NPC_CARRIERBOMBGROOGY1         1755
#define SND_NPC_CARRIERBOMBIDLE1           1756
#define SND_NPC_LEYENAATK1                 1757
#define SND_NPC_LEYENAATK2                 1758
#define SND_NPC_LEYENADIE1                 1759
#define SND_NPC_LEYENADMG1                 1760
#define SND_NPC_LEYENADMG2                 1761
#define SND_NPC_LEYENADMGDIE1              1762
#define SND_NPC_LEYENADMGFLY1              1763
#define SND_NPC_LEYENADMGLIVE1             1764
#define SND_NPC_LEYENAGROOGY1              1765
#define SND_NPC_LEYENAIDLE1                1766
#define SND_NPC_DUMBBULLATK1               1767
#define SND_NPC_DUMBBULLATK2               1768
#define SND_NPC_DUMBBULLDIE1               1769
#define SND_NPC_DUMBBULLDMG1               1770
#define SND_NPC_DUMBBULLDMG2               1771
#define SND_NPC_DUMBBULLDMGDIE1            1772
#define SND_NPC_DUMBBULLDMGFLY1            1773
#define SND_NPC_DUMBBULLDMGLIVE1           1774
#define SND_NPC_DUMBBULLGROOGY1            1775
#define SND_NPC_DUMBBULLIDLE1              1776
#define SND_NPC_NUTTYWHEELATK1             1777
#define SND_NPC_NUTTYWHEELATK2             1778
#define SND_NPC_NUTTYWHEELDIE1             1779
#define SND_NPC_NUTTYWHEELDMG1             1780
#define SND_NPC_NUTTYWHEELDMG2             1781
#define SND_NPC_NUTTYWHEELDMGDIE1          1782
#define SND_NPC_NUTTYWHEELDMGFLY1          1783
#define SND_NPC_NUTTYWHEELDMGLIVE1         1784
#define SND_NPC_NUTTYWHEELGROOGY1          1785
#define SND_NPC_NUTTYWHEELIDLE1            1786
#define SND_NPC_JACKTHEHAMMERATK1          1787
#define SND_NPC_JACKTHEHAMMERATK2          1788
#define SND_NPC_JACKTHEHAMMERDIE1          1789
#define SND_NPC_JACKTHEHAMMERDMG1          1790
#define SND_NPC_JACKTHEHAMMERDMG2          1791
#define SND_NPC_JACKTHEHAMMERDMGDIE1       1792
#define SND_NPC_JACKTHEHAMMERDMGFLY1       1793
#define SND_NPC_JACKTHEHAMMERDMGLIVE1      1794
#define SND_NPC_JACKTHEHAMMERGROOGY1       1795
#define SND_NPC_JACKTHEHAMMERIDLE1         1796
#define SND_NPC_MINECATCHER_DIE1           1797
#define SND_NPC_MINECATCHER_DMG1           1798
#define SND_NPC_MINECATCHER_DMG2           1799
#define SND_NPC_MINECATCHER_IDLE1          1800
#define SND_NPC_ERONSCATCHER_DIE1          1801
#define SND_NPC_ERONSCATCHER_DMG1          1802
#define SND_NPC_ERONSCATCHER_DMG2          1803
#define SND_NPC_ERONSCATCHER_IDLE1         1804
#define SND_NPC_GURUCATCHER_DIE1           1805
#define SND_NPC_GURUCATCHER_DMG1           1806
#define SND_NPC_GURUCATCHER_DMG2           1807
#define SND_NPC_GURUCATCHER_IDLE1          1808
#define SND_NPC_KRASECCATCHER_DIE1         1809
#define SND_NPC_KRASECCATCHER_DMG1         1810
#define SND_NPC_KRASECCATCHER_DMG2         1811
#define SND_NPC_KRASECCATCHER_IDLE1        1812

#define SND_NPC_NUCTUVEHICLEATK1             1813
#define SND_NPC_NUCTUVEHICLEATK2             1814
#define SND_NPC_NUCTUVEHICLEDIE1             1815	
#define SND_NPC_NUCTUVEHICLEDMG1             1816	
#define SND_NPC_NUCTUVEHICLEDMG2             1817	
#define SND_NPC_NUCTUVEHICLEDMGDIE1          1818	
#define SND_NPC_NUCTUVEHICLEDMGFLY1          1819	
#define SND_NPC_NUCTUVEHICLEDMGLIVE1         1820	
#define SND_NPC_NUCTUVEHICLEGROOGY1          1821	
#define SND_NPC_NUCTUVEHICLEIDLE1            1822	

#define SND_NPC_RISEMATK1       	1823
#define SND_NPC_RISEMATK2          	1824
#define SND_NPC_RISEMDIE1         	1825
#define SND_NPC_RISEMDMG1         	1826
#define SND_NPC_RISEMDMG2         	1827
#define SND_NPC_RISEMDMGDIE1     	1828
#define SND_NPC_RISEMDMGFLY1        	1829
#define SND_NPC_RISEMDMGLIVE1        	1830
#define SND_NPC_RISEMGROOGY1       	1831
#define SND_NPC_RISEMIDLE1        	1832

#define SND_NPC_SYLIACAATK1       	1833
#define SND_NPC_SYLIACAATK2          	1834
#define SND_NPC_SYLIACADIE1         	1835
#define SND_NPC_SYLIACADMG1         	1836
#define SND_NPC_SYLIACADMG2         	1837
#define SND_NPC_SYLIACADMGDIE1     	1838
#define SND_NPC_SYLIACADMGFLY1        	1839
#define SND_NPC_SYLIACADMGLIVE1        	1840
#define SND_NPC_SYLIACAGROOGY1       	1841
#define SND_NPC_SYLIACAIDLE1        	1842

#define SND_NPC_ZOMBIGERATK1       	1843
#define SND_NPC_ZOMBIGERATK2          	1844
#define SND_NPC_ZOMBIGERDIE1         	1845
#define SND_NPC_ZOMBIGERDMG1         	1846
#define SND_NPC_ZOMBIGERDMG2         	1847
#define SND_NPC_ZOMBIGERDMGDIE1     	1848
#define SND_NPC_ZOMBIGERDMGFLY1        	1849
#define SND_NPC_ZOMBIGERDMGLIVE1       	1850
#define SND_NPC_ZOMBIGERGROOGY1       	1851
#define SND_NPC_ZOMBIGERIDLE1        	1852


#define SND_NPC_FLYBATATK1       	1853
#define SND_NPC_FLYBATATK2          	1854
#define SND_NPC_FLYBATDIE1         	1855
#define SND_NPC_FLYBATDMG1         	1856
#define SND_NPC_FLYBATDMG2         	1857
#define SND_NPC_FLYBATDMGDIE1     	1858
#define SND_NPC_FLYBATDMGFLY1        	1859
#define SND_NPC_FLYBATDMGLIVE1       	1860
#define SND_NPC_FLYBATGROOGY1       	1861
#define SND_NPC_FLYBATIDLE1        	1862

#define SND_NPC_BUCROWATK1       	1863
#define SND_NPC_BUCROWATK2          	1864
#define SND_NPC_BUCROWDIE1         	1865
#define SND_NPC_BUCROWDMG1         	1866
#define SND_NPC_BUCROWDMG2         	1867
#define SND_NPC_BUCROWDMGDIE1     	1868
#define SND_NPC_BUCROWDMGFLY1        	1869
#define SND_NPC_BUCROWDMGLIVE1       	1870
#define SND_NPC_BUCROWGROOGY1       	1871
#define SND_NPC_BUCROWIDLE1        	1872

#define SND_NPC_SCOPICONATK1       	1873
#define SND_NPC_SCOPICONATK2          	1874
#define SND_NPC_SCOPICONDIE1         	1875
#define SND_NPC_SCOPICONDMG1         	1876
#define SND_NPC_SCOPICONDMG2         	1877
#define SND_NPC_SCOPICONDMGDIE1     	1878
#define SND_NPC_SCOPICONDMGFLY1        	1879
#define SND_NPC_SCOPICONDMGLIVE1       	1880
#define SND_NPC_SCOPICONGROOGY1       	1881
#define SND_NPC_SCOPICONIDLE1        	1882

#define SND_NPC_TRANGFOMAATK1       	1883
#define SND_NPC_TRANGFOMAATK2          	1884
#define SND_NPC_TRANGFOMADIE1         	1885
#define SND_NPC_TRANGFOMADMG1         	1886
#define SND_NPC_TRANGFOMADMG2         	1887
#define SND_NPC_TRANGFOMADMGDIE1     	1888
#define SND_NPC_TRANGFOMADMGFLY1           1889	
#define SND_NPC_TRANGFOMADMGLIVE1      	1890
#define SND_NPC_TRANGFOMAGROOGY1       	1891
#define SND_NPC_TRANGFOMAIDLE1        	1892

#define SND_NPC_WATANGKAATK1             1893	
#define SND_NPC_WATANGKAATK2             1894	
#define SND_NPC_WATANGKADIE1             1895	
#define SND_NPC_WATANGKADMG1             1896	
#define SND_NPC_WATANGKADMG2             1897	
#define SND_NPC_WATANGKADMGDIE1          1898	
#define SND_NPC_WATANGKADMGFLY1          1899	
#define SND_NPC_WATANGKADMGLIVE1         1900	
#define SND_NPC_WATANGKAGROOGY1          1901	
#define SND_NPC_WATANGKAIDLE1            1902
#define SND_NPC_IRENATK1                 1903
#define SND_NPC_IRENATK2                 1904
#define SND_NPC_IRENDIE1                 1905
#define SND_NPC_IRENDMG1                 1906
#define SND_NPC_IRENDMG2                 1907
#define SND_NPC_IRENDMGDIE1              1908
#define SND_NPC_IRENDMGFLY1              1909
#define SND_NPC_IRENDMGLIVE1             1910
#define SND_NPC_IRENGROOGY1              1911
#define SND_NPC_IRENIDLE1                1912
#define SND_NPC_BOOATK1                  1913
#define SND_NPC_BOOATK2                  1914
#define SND_NPC_BOODIE1                  1915
#define SND_NPC_BOODMG1                  1916
#define SND_NPC_BOODMG2                  1917
#define SND_NPC_BOODMGDIE1               1918
#define SND_NPC_BOODMGFLY1               1919
#define SND_NPC_BOODMGLIVE1              1920
#define SND_NPC_BOOGROOGY1               1921
#define SND_NPC_BOOIDLE1                 1922
#define SND_NPC_LUIAATK1                 1923
#define SND_NPC_LUIAATK2                 1924
#define SND_NPC_LUIADIE1                 1925
#define SND_NPC_LUIADMG1                 1926
#define SND_NPC_LUIADMG2                 1927
#define SND_NPC_LUIADMGDIE1              1928
#define SND_NPC_LUIADMGFLY1              1929
#define SND_NPC_LUIADMGLIVE1             1930
#define SND_NPC_LUIAGROOGY1              1931
#define SND_NPC_LUIAIDLE1                1932
#define SND_NPC_GLAPHANATK1              1933
#define SND_NPC_GLAPHANATK2              1934
#define SND_NPC_GLAPHANDIE1              1935
#define SND_NPC_GLAPHANDMG1              1936
#define SND_NPC_GLAPHANDMG2              1937
#define SND_NPC_GLAPHANDMGDIE1           1938
#define SND_NPC_GLAPHANDMGFLY1           1939
#define SND_NPC_GLAPHANDMGLIVE1          1940
#define SND_NPC_GLAPHANGROOGY1           1941
#define SND_NPC_GLAPHANIDLE1             1942
#define SND_NPC_SHUHAMMAATK1             1943
#define SND_NPC_SHUHAMMAATK2             1944
#define SND_NPC_SHUHAMMADIE1             1945
#define SND_NPC_SHUHAMMADMG1             1946
#define SND_NPC_SHUHAMMADMG2             1947
#define SND_NPC_SHUHAMMADMGDIE1          1948
#define SND_NPC_SHUHAMMADMGFLY1          1949
#define SND_NPC_SHUHAMMADMGLIVE1         1950
#define SND_NPC_SHUHAMMAGROOGY1          1951
#define SND_NPC_SHUHAMMAIDLE1            1952
#define SND_NPC_NAUTREPYATK1             1953
#define SND_NPC_NAUTREPYATK2             1954
#define SND_NPC_NAUTREPYDIE1             1955
#define SND_NPC_NAUTREPYDMG1             1956
#define SND_NPC_NAUTREPYDMG2             1957
#define SND_NPC_NAUTREPYDMGDIE1          1958
#define SND_NPC_NAUTREPYDMGFLY1          1959
#define SND_NPC_NAUTREPYDMGLIVE1         1960
#define SND_NPC_NAUTREPYGROOGY1          1961
#define SND_NPC_NAUTREPYIDLE1            1962
#define SND_NPC_GRRRATK1                 1963
#define SND_NPC_GRRRATK2                 1964
#define SND_NPC_GRRRDIE1                 1965
#define SND_NPC_GRRRDMG1                 1966
#define SND_NPC_GRRRDMG2                 1967
#define SND_NPC_GRRRDMGDIE1              1968
#define SND_NPC_GRRRDMGFLY1              1969
#define SND_NPC_GRRRDMGLIVE1             1970
#define SND_NPC_GRRRGROOGY1              1971
#define SND_NPC_GRRRIDLE1                1972
#define SND_NPC_ANTIQUERYATK1            1973
#define SND_NPC_ANTIQUERYATK2            1974
#define SND_NPC_ANTIQUERYDIE1            1975
#define SND_NPC_ANTIQUERYDMG1            1976
#define SND_NPC_ANTIQUERYDMG2            1977
#define SND_NPC_ANTIQUERYDMGDIE1         1978
#define SND_NPC_ANTIQUERYDMGFLY1         1979
#define SND_NPC_ANTIQUERYDMGLIVE1        1980
#define SND_NPC_ANTIQUERYGROOGY1         1981
#define SND_NPC_ANTIQUERYIDLE1           1982
#define SND_NPC_MUSHPOIEATK1             1983
#define SND_NPC_MUSHPOIEATK2             1984
#define SND_NPC_MUSHPOIEDIE1             1985
#define SND_NPC_MUSHPOIEDMG1             1986
#define SND_NPC_MUSHPOIEDMG2             1987
#define SND_NPC_MUSHPOIEDMGDIE1          1988
#define SND_NPC_MUSHPOIEDMGFLY1          1989
#define SND_NPC_MUSHPOIEDMGLIVE1         1990
#define SND_NPC_MUSHPOIEGROOGY1          1991
#define SND_NPC_MUSHPOIEIDLE1            1992
#define SND_NPC_MUFFRINATK1              1993
#define SND_NPC_MUFFRINATK2              1994
#define SND_NPC_MUFFRINDIE1              1995
#define SND_NPC_MUFFRINDMG1              1996
#define SND_NPC_MUFFRINDMG2              1997
#define SND_NPC_MUFFRINDMGDIE1           1998
#define SND_NPC_MUFFRINDMGFLY1           1999
#define SND_NPC_MUFFRINDMGLIVE1          2000
#define SND_NPC_MUFFRINGROOGY1           2001
#define SND_NPC_MUFFRINIDLE1             2002
#define SND_NPC_HOPPREATK1               2003
#define SND_NPC_HOPPREATK2               2004
#define SND_NPC_HOPPREDIE1               2005
#define SND_NPC_HOPPREDMG1               2006
#define SND_NPC_HOPPREDMG2               2007
#define SND_NPC_HOPPREDMGDIE1            2008
#define SND_NPC_HOPPREDMGFLY1            2009
#define SND_NPC_HOPPREDMGLIVE1           2010
#define SND_NPC_HOPPREGROOGY1            2011
#define SND_NPC_HOPPREIDLE1              2012
#define SND_NPC_GONGURYATK1              2013
#define SND_NPC_GONGURYATK2              2014
#define SND_NPC_GONGURYDIE1              2015
#define SND_NPC_GONGURYDMG1              2016
#define SND_NPC_GONGURYDMG2              2017
#define SND_NPC_GONGURYDMGDIE1           2018
#define SND_NPC_GONGURYDMGFLY1           2019
#define SND_NPC_GONGURYDMGLIVE1          2020
#define SND_NPC_GONGURYGROOGY1           2021
#define SND_NPC_GONGURYIDLE1             2022
#define SND_NPC_DUMPATK1                 2023
#define SND_NPC_DUMPATK2                 2024
#define SND_NPC_DUMPDIE1                 2025
#define SND_NPC_DUMPDMG1                 2026
#define SND_NPC_DUMPDMG2                 2027
#define SND_NPC_DUMPDMGDIE1              2028
#define SND_NPC_DUMPDMGFLY1              2029
#define SND_NPC_DUMPDMGLIVE1             2030
#define SND_NPC_DUMPGROOGY1              2031
#define SND_NPC_DUMPIDLE1                2032
#define SND_NPC_KERNATK1                 2033
#define SND_NPC_KERNATK2                 2034
#define SND_NPC_KERNDIE1                 2035
#define SND_NPC_KERNDMG1                 2036
#define SND_NPC_KERNDMG2                 2037
#define SND_NPC_KERNDMGDIE1              2038
#define SND_NPC_KERNDMGFLY1              2039
#define SND_NPC_KERNDMGLIVE1             2040
#define SND_NPC_KERNGROOGY1              2041
#define SND_NPC_KERNIDLE1                2042
#define SND_NPC_WORMVEDUQUEATK1          2042
#define SND_NPC_WORMVEDUQUEATK2          2043
#define SND_NPC_WORMVEDUQUEDIE1          2044
#define SND_NPC_WORMVEDUQUEDMG1          2045				
#define SND_NPC_WORMVEDUQUEDMG2          2046				
#define SND_NPC_WORMVEDUQUEDMGDIE1       2047				
#define SND_NPC_WORMVEDUQUEDMGFLY1       2048				
#define SND_NPC_WORMVEDUQUEDMGLIVE1      2049				
#define SND_NPC_WORMVEDUQUEGROOGY1       2050				
#define SND_NPC_WORMVEDUQUEIDLE1         2051				
#define SND_NPC_ROACHFLATK1				2052
#define SND_NPC_ROACHFLATK2				2053
#define SND_NPC_ROACHFLDIE1				2054
#define SND_NPC_ROACHFLDMG1				2055
#define SND_NPC_ROACHFLDMG2				2056
#define SND_NPC_ROACHFLDMGDIE1			2057	
#define SND_NPC_ROACHFLDMGFLY1			2058	
#define SND_NPC_ROACHFLDMGLIVE1			2059	
#define SND_NPC_ROACHFLGROOGY1			2060	
#define SND_NPC_ROACHFLIDLE1			2061
#define SND_NPC_METEONYKERATK1			2062
#define SND_NPC_METEONYKERATK2           2063			
#define SND_NPC_METEONYKERDIE1           2064			
#define SND_NPC_METEONYKERDMG1           2065			
#define SND_NPC_METEONYKERDMG2           2066			
#define SND_NPC_METEONYKERDMGDIE1        2067			
#define SND_NPC_METEONYKERDMGFLY1        2068			
#define SND_NPC_METEONYKERDMGLIVE1       2069			
#define SND_NPC_METEONYKERGROOGY1        2070			
#define SND_NPC_METEONYKERIDLE1          2071			
#define SND_NPC_AXKEAKOONATK1            2072			
#define SND_NPC_AXKEAKOONATK2            2073			
#define SND_NPC_AXKEAKOONDIE1            2074			
#define SND_NPC_AXKEAKOONDMG1            2075			
#define SND_NPC_AXKEAKOONDMG2            2076			
#define SND_NPC_AXKEAKOONDMGDIE1         2077
#define SND_NPC_AXKEAKOONDMGFLY1         2078
#define SND_NPC_AXKEAKOONDMGLIVE1        2079
#define SND_NPC_AXKEAKOONGROOGY1         2080
#define SND_NPC_AXKEAKOONIDLE1           2081
#define SND_NPC_SWKEAKOONATK1            2082
#define SND_NPC_SWKEAKOONATK2            2083
#define SND_NPC_SWKEAKOONDIE1            2084
#define SND_NPC_SWKEAKOONDMG1            2085
#define SND_NPC_SWKEAKOONDMG2            2086
#define SND_NPC_SWKEAKOONDMGDIE1         2087
#define SND_NPC_SWKEAKOONDMGFLY1         2088
#define SND_NPC_SWKEAKOONDMGLIVE1        2089
#define SND_NPC_SWKEAKOONGROOGY1         2090
#define SND_NPC_SWKEAKOONIDLE1           2091
#define SND_NPC_TRILLIPYATK1             2092
#define SND_NPC_TRILLIPYATK2			2093
#define SND_NPC_TRILLIPYDIE1			2094
#define SND_NPC_TRILLIPYDMG1			2095
#define SND_NPC_TRILLIPYDMG2			2096
#define SND_NPC_TRILLIPYDMGDIE1			2097
#define SND_NPC_TRILLIPYDMGFLY1			2098
#define SND_NPC_TRILLIPYDMGLIVE1		2099	
#define SND_NPC_TRILLIPYGROOGY1			2100
#define SND_NPC_TRILLIPYIDLE1			2101
#define SND_NPC_KIMERADONATK1			2102
#define SND_NPC_KIMERADONATK2			2103
#define SND_NPC_KIMERADONDIE1			2104
#define SND_NPC_KIMERADONDMG1			2105
#define SND_NPC_KIMERADONDMG2			2106
#define SND_NPC_KIMERADONDMGDIE1		2107	
#define SND_NPC_KIMERADONDMGFLY1		2108	
#define SND_NPC_KIMERADONDMGLIVE1		2109	
#define SND_NPC_KIMERADONGROOGY1		2110	
#define SND_NPC_KIMERADONIDLE1			2111
// 12차 추가 효과음			
#define SND_NPC_ABRAXASATK1		2112	
#define SND_NPC_ABRAXASATK2		2113	
#define SND_NPC_ABRAXASDIE1		2114	
#define SND_NPC_ABRAXASDMG1		2115	
#define SND_NPC_ABRAXASDMG2		2116	
#define SND_NPC_ABRAXASDMGFLY1		2117	
#define SND_NPC_ABRAXASIDLE1		2118	

#define SND_NPC_CYCLOPSXATK1		2119	
#define SND_NPC_CYCLOPSXATK2		2120	
#define SND_NPC_CYCLOPSXDIE1		2121	
#define SND_NPC_CYCLOPSXFLYDIE1		2122	
#define SND_NPC_CYCLOPSXIDLE1		2123
#define SND_NPC_CYCLOPSXDMG1		2124
#define SND_NPC_CYCLOPSXDMG2		2125

#define SND_NPC_CAITSITHATK1             2126		
#define SND_NPC_CAITSITHATK2		2127
#define SND_NPC_CAITSITHDIE1		2128
#define SND_NPC_CAITSITHFLYDIE1		2129
#define SND_NPC_CAITSITHIDLE1		2130
#define SND_NPC_CAITSITHDMG1		2131
#define SND_NPC_CAITSITHDMG2		2132

#define SND_NPC_HARPYATK1	  	2133
#define SND_NPC_HARPYATK2		2134
#define SND_NPC_HARPYDIE1		2135
#define SND_NPC_HARPYFLYDIE1		2136
#define SND_NPC_HARPYIDLE1		2137	
#define SND_NPC_HARPYDMG1		2138	
#define SND_NPC_HARPYDMG2		2139	

#define SND_NPC_POLEVIKATK1		2140	
#define SND_NPC_POLEVIKATK2		2141	
#define SND_NPC_POLEVIKDIE1		2142	
#define SND_NPC_POLEVIKFLYDIE1		2143	
#define SND_NPC_POLEVIKIDLE1		2144	
#define SND_NPC_POLEVIKDMG1		2145	
#define SND_NPC_POLEVIKDMG2		2146	

#define SND_NPC_HAGATK1			2147
#define SND_NPC_HAGATK2			2148
#define SND_NPC_HAGDIE1			2149
#define SND_NPC_HAGFLYDIE1		2150	
#define SND_NPC_HAGDLE1			2151
#define SND_NPC_HAGDMG1			2152
#define SND_NPC_HAGDMG2			2153

#define SND_NPC_THOTHATK1		2154	
#define SND_NPC_THOTHATK2		2155	
#define SND_NPC_THOTHDIE1		2156	
#define SND_NPC_THOTHFLYDIE1		2157	
#define SND_NPC_THOTHDLE1		2158	
#define SND_NPC_THOTHDMG1		2159	
#define SND_NPC_THOTHDMG2		2160	

#define SND_NPC_KHNEMUATK1		2161	
#define SND_NPC_KHNEMUATK2		2162	
#define SND_NPC_KHNEMUDIE1		2163	
#define SND_NPC_KHNEMUFLYDIE1		2164	
#define SND_NPC_KHNEMUDLE1		2165
#define SND_NPC_KHNEMUDMG1		2166
#define SND_NPC_KHNEMUDMG2		2167

#define SND_NPC_DANTALIANATK1		2168
#define SND_NPC_DANTALIANATK2		2169
#define SND_NPC_DANTALIANDIE1		2170
#define SND_NPC_DANTALIANFLYDIE1	2171	
#define SND_NPC_DANTALIANDLE1		2172
#define SND_NPC_DANTALIANDMG1		2173
#define SND_NPC_DANTALIANDMG2		2174

#define SND_NPC_GANESAATK1		2175
#define SND_NPC_GANESAATK2		2176
#define SND_NPC_GANESADIE1		2177
#define SND_NPC_GANESAFLYDIE1		2178
#define SND_NPC_GANESADLE1		2179
#define SND_NPC_GANESADMG1		2180
#define SND_NPC_GANESADMG2		2181

#define SND_NPC_ASURAATK1		2182
#define SND_NPC_ASURAATK2		2183
#define SND_NPC_ASURADIE1		2184
#define SND_NPC_ASURAFLYDIE1		2185
#define SND_NPC_ASURADLE1		2186
#define SND_NPC_ASURADMG1		2187
#define SND_NPC_ASURADMG2		2188

#define SND_NPC_YETIATK1		2189
#define SND_NPC_YETIATK2		2190
#define SND_NPC_YETIDIE1		2191
#define SND_NPC_YETIFLYDIE1		2192
#define SND_NPC_YETIDLE1		2193
#define SND_NPC_YETIDMG1		2194
#define SND_NPC_YETIDMG2		2195

#define SND_NPC_SADKINGATK1		2196
#define SND_NPC_SADKINGATK2		2197
#define SND_NPC_SADKINGDIE1		2198
#define SND_NPC_SADKINGFLYDIE1		2199
#define SND_NPC_SADKINGDLE1		2200
#define SND_NPC_SADKINGDMG1		2201
#define SND_NPC_SADKINGDMG2		2202

#define SND_NPC_AUGOOATK1		2203
#define SND_NPC_AUGOOATK2		2204
#define SND_NPC_AUGOODIE1		2205
#define SND_NPC_AUGOOFLYDIE1		2206
#define SND_NPC_AUGOODLE1		2207
#define SND_NPC_AUGOODMG1		2208
#define SND_NPC_AUGOODMG2		2209

#define SND_NPC_MAMMOTHATK1		2210
#define SND_NPC_MAMMOTHATK2	  	2211
#define SND_NPC_MAMMOTHDIE1		2212
#define SND_NPC_MAMMOTHFLYDIE1		2213
#define SND_NPC_MAMMOTHDLE1		2214
#define SND_NPC_MAMMOTHDMG1		2215
#define SND_NPC_MAMMOTHDMG2		2216

#define SND_NPC_LUCIFERATK1		2217
#define SND_NPC_LUCIFERATK2		2218
#define SND_NPC_LUCIFERDIE1		2219
#define SND_NPC_LUCIFERFLYDIE1		2220
#define SND_NPC_LUCIFERDLE1		2221	
#define SND_NPC_LUCIFERDMG1		2222	
#define SND_NPC_LUCIFERDMG2		2223	

#define SND_NPC_IMPATK1			2224
#define SND_NPC_IMPATK2			2225
#define SND_NPC_IMPDIE1			2226
#define SND_NPC_IMPFLYDIE1		2227	
#define SND_NPC_IMPIDLE1		2228	
#define SND_NPC_IMPDMG1			2229
#define SND_NPC_IMPDMG2			2230

#define SND_NPC_RANGDAATK1   		2231	
#define SND_NPC_RANGDAATK2               2232			
#define SND_NPC_RANGDADIE1		2233	
#define SND_NPC_RANGDAFLYDIE1		2234	
#define SND_NPC_RANGDAIDLE1		2235	
#define SND_NPC_RANGDADMG1		2236	
#define SND_NPC_RANGDADMG2		2237	

#define	SND_NPC_KINGSTERATK1		2238
#define	SND_NPC_KINGSTERATK2		2239
#define	SND_NPC_KINGSTERDIE1		2240
#define	SND_NPC_KINGSTERFLYDIE1		2241
#define	SND_NPC_KINGSTERIDLE1		2242
#define	SND_NPC_KINGSTERDMG1		2243
#define	SND_NPC_KINGSTERDMG2		2244

#define	SND_NPC_KRAKENATK1		2245
#define	SND_NPC_KRAKENATK2		2246
#define	SND_NPC_KRAKENDIE1		2247
#define	SND_NPC_KRAKENFLYDIE1		2248
#define	SND_NPC_KRAKENIDLE1		2249
#define	SND_NPC_KRAKENDMG1		2250
#define	SND_NPC_KRAKENDMG2		2251

#define	SND_NPC_CREPERATK1		2252
#define	SND_NPC_CREPERATK2		2253
#define	SND_NPC_CREPERDIE1		2254
#define	SND_NPC_CREPERFLYDIE1		2255
#define	SND_NPC_CREPERIDLE1		2256
#define	SND_NPC_CREPERDMG1		2257
#define	SND_NPC_CREPERDMG2		2258

#define	SND_NPC_NAGAATK1		2259
#define	SND_NPC_NAGAATK2		2260
#define	SND_NPC_NAGADIE1		2261
#define	SND_NPC_NAGAFLYDIE1		2262
#define	SND_NPC_NAGAIDLE1		2263
#define	SND_NPC_NAGADMG1		2264
#define	SND_NPC_NAGADMG2		2265

#define	SND_NPC_ATROXATK1		2266
#define	SND_NPC_ATROXATK2		2267
#define	SND_NPC_ATROXDIE1		2268
#define	SND_NPC_ATROXFLYDIE1		2269
#define	SND_NPC_ATROXIDLE1		2270
#define	SND_NPC_ATROXDMG1		2271
#define	SND_NPC_ATROXDMG2		2272

#define	SND_NPC_OKEANATK1		2273
#define	SND_NPC_OKEANATK2		2274
#define	SND_NPC_OKEANDIE1		2275
#define	SND_NPC_OKEANFLYDIE1		2276
#define	SND_NPC_OKEANIDLE1		2277
#define	SND_NPC_OKEANDMG1		2278
#define	SND_NPC_OKEANDMG2		2279

#define	SND_NPC_TAIGAATK1		2280
#define	SND_NPC_TAIGAATK2		2281
#define	SND_NPC_TAIGADIE1		2282
#define	SND_NPC_TAIGAFLYDIE1		2283
#define	SND_NPC_TAIGAIDLE1		2284
#define	SND_NPC_TAIGADMG1		2285
#define	SND_NPC_TAIGADMG2		2286

#define	SND_NPC_DORIANATK1		2287
#define	SND_NPC_DORIANATK2		2288
#define	SND_NPC_DORIANDIE1		2289
#define	SND_NPC_DORIANFLYDIE1		2290
#define	SND_NPC_DORIANIDLE1		2291
#define	SND_NPC_DORIANDMG1		2292
#define	SND_NPC_DORIANDMG2		2293

#define	SND_NPC_MERELATK1		2294
#define	SND_NPC_MERELATK2		2295
#define	SND_NPC_MERELDIE1		2296
#define	SND_NPC_MERELFLYDIE1		2297
#define	SND_NPC_MERELIDLE1		2298
#define	SND_NPC_MERELDMG1		2299
#define	SND_NPC_MERELDMG2		2300

#define	SND_NPC_TOADIRNATK1		2301
#define	SND_NPC_TOADIRNATK2		2302
#define	SND_NPC_TOADIRNDIE1		2303
#define	SND_NPC_TOADIRNFLYDIE1		2304
#define	SND_NPC_TOADIRNIDLE1		2305
#define	SND_NPC_TOADIRNDMG1		2306
#define	SND_NPC_TOADIRNDMG2		2307

#define	SND_NPC_BERKENATK1		2308
#define	SND_NPC_BERKENATK2		2309
#define	SND_NPC_BERKENDIE1		2310
#define	SND_NPC_BERKENFLYDIE1		2311
#define	SND_NPC_BERKENIDLE1		2312
#define	SND_NPC_BERKENDMG1		2313
#define	SND_NPC_BERKENDMG2		2314

#define	SND_NPC_HATSALRAATK1		2315
#define	SND_NPC_HATSALRAATK2		2316
#define	SND_NPC_HATSALRADIE1		2317
#define	SND_NPC_HATSALRAFLYDIE1		2318
#define	SND_NPC_HATSALRAIDLE1		2319
#define	SND_NPC_HATSALRADMG1		2320
#define	SND_NPC_HATSALRADMG2		2321

#define	SND_NPC_FRINKERATK1		2322
#define	SND_NPC_FRINKERATK2		2323
#define	SND_NPC_FRINKERDIE1		2324
#define	SND_NPC_FRINKERFLYDIE1		2325
#define	SND_NPC_FRINKERIDLE1		2326
#define	SND_NPC_FRINKERDMG1		2327
#define	SND_NPC_FRINKERDMG2		2328

#define	SND_NPC_CROHELLATK1		2329
#define	SND_NPC_CROHELLATK2		2330
#define	SND_NPC_CROHELLDIE1		2331
#define	SND_NPC_CROHELLFLYDIE1		2332
#define	SND_NPC_CROHELLIDLE1		2333
#define	SND_NPC_CROHELLDMG1		2334
#define	SND_NPC_CROHELLDMG2		2335

#define	SND_NPC_PRICKANTATK1		2336
#define	SND_NPC_PRICKANTATK2		2337
#define	SND_NPC_PRICKANTDIE1		2338
#define	SND_NPC_PRICKANTFLYDIE1		2339
#define	SND_NPC_PRICKANTIDLE1		2340
#define	SND_NPC_PRICKANTDMG1		2341
#define	SND_NPC_PRICKANTDMG2		2342

#define	SND_NPC_CRIPESCENTIPEDEATK1	2343	
#define	SND_NPC_CRIPESCENTIPEDEATK2	2344	
#define	SND_NPC_CRIPESCENTIPEDEDIE1	2345	
#define	SND_NPC_CRIPESCENTIPEDEFLYDIE1	2346	
#define	SND_NPC_CRIPESCENTIPEDEIDLE1	2347	
#define	SND_NPC_CRIPESCENTIPEDEDMG1	2348	
#define	SND_NPC_CRIPESCENTIPEDEDMG2	2349	

#define	SND_NPC_MAULMOUSEATK1		2350
#define	SND_NPC_MAULMOUSEATK2		2351
#define	SND_NPC_MAULMOUSEDIE1		2352
#define	SND_NPC_MAULMOUSEFLYDIE1	2353	
#define	SND_NPC_MAULMOUSEIDLE1		2354
#define	SND_NPC_MAULMOUSEDMG1		2355
#define	SND_NPC_MAULMOUSEDMG2		2356

#define	SND_NPC_LYCANOSATK1		2357
#define	SND_NPC_LYCANOSATK2		2358
#define	SND_NPC_LYCANOSDIE1		2359
#define	SND_NPC_LYCANOSFLYDIE1		2360
#define	SND_NPC_LYCANOSIDLE1		2361
#define	SND_NPC_LYCANOSDMG1		2362
#define	SND_NPC_LYCANOSDMG2		2363

#define	SND_NPC_VEMPAINATK1		2364
#define	SND_NPC_VEMPAINATK2		2365
#define	SND_NPC_VEMPAINATK3		2366
#define	SND_NPC_VEMPAINDIE1		2367
#define	SND_NPC_VEMPAINFLYDIE1		2368
#define	SND_NPC_VEMPAINIDLE1		2369
#define	SND_NPC_VEMPAINDMG1		2370
#define	SND_NPC_VEMPAINDMG2		2371

#define	SND_NPC_SKELWOLFATK1		2372
#define	SND_NPC_SKELWOLFATK2		2373
#define	SND_NPC_SKELWOLFDIE1		2374
#define	SND_NPC_SKELWOLFFLYDIE1		2375
#define	SND_NPC_SKELWOLFIDLE1		2376
#define	SND_NPC_SKELWOLFDMG1		2377
#define	SND_NPC_SKELWOLFDMG2		2378

#define	SND_NPC_SKELSWORDATK1		2379
#define	SND_NPC_SKELSWORDATK2		2380
#define	SND_NPC_SKELSWORDDIE1		2381
#define	SND_NPC_SKELSWORDFLYDIE1	2382	
#define	SND_NPC_SKELSWORDIDLE1		2383
#define	SND_NPC_SKELSWORDDMG1		2384
#define	SND_NPC_SKELSWORDDMG2		2385

#define	SND_NPC_SKELSPEARATK1		2386
#define	SND_NPC_SKELSPEARATK2		2387
#define	SND_NPC_SKELSPEARDIE1		2388
#define	SND_NPC_SKELSPEARFLYDIE1	2389	
#define	SND_NPC_SKELSPEARIDLE1		2390
#define	SND_NPC_SKELSPEARDMG1		2391
#define	SND_NPC_SKELSPEARDMG2		2392

#define	SND_NPC_SKELMAGEATK1		2393
#define	SND_NPC_SKELMAGEATK2		2394
#define	SND_NPC_SKELMAGEDIE1		2395
#define	SND_NPC_SKELMAGEFLYDIE1		2396
#define	SND_NPC_SKELMAGEIDLE1		2397
#define	SND_NPC_SKELMAGEDMG1		2398
#define	SND_NPC_SKELMAGEDMG2		2399

#define	SND_NPC_SKELASSASSINATK1	2400	
#define	SND_NPC_SKELASSASSINATK2	2401	
#define	SND_NPC_SKELASSASSINDIE1	2402	
#define	SND_NPC_SKELASSASSINFLYDIE1	2403	
#define	SND_NPC_SKELASSASSINIDLE1	2404	
#define	SND_NPC_SKELASSASSINDMG1	2405	
#define	SND_NPC_SKELASSASSINDMG2	2406	

#define	SND_NPC_SKELFIGHTERATK1		2407
#define	SND_NPC_SKELFIGHTERATK2		2408
#define	SND_NPC_SKELFIGHTERDIE1		2409
#define	SND_NPC_SKELFIGHTERFLYDIE1	2410	
#define	SND_NPC_SKELFIGHTERIDLE1	2411	
#define	SND_NPC_SKELFIGHTERDMG1		2412
#define	SND_NPC_SKELFIGHTERDMG2		2413

#define	SND_NPC_SKELGENERALATK1		2414
#define	SND_NPC_SKELGENERALATK2		2415
#define	SND_NPC_SKELGENERALATK3		2416
#define	SND_NPC_SKELGENERALDIE1		2417
#define	SND_NPC_SKELGENERALFLYDIE1	2418	
#define	SND_NPC_SKELGENERALIDLE1	2419	
#define	SND_NPC_SKELGENERALDMG1		2420
#define	SND_NPC_SKELGENERALDMG2		2421

#define	SND_NPC_SKELGRIFFINATK1		2422
#define	SND_NPC_SKELGRIFFINATK2		2423
#define	SND_NPC_SKELGRIFFINDIE1		2424
#define	SND_NPC_SKELGRIFFINFLYDIE1	2425	
#define	SND_NPC_SKELGRIFFINIDLE1	2426	
#define	SND_NPC_SKELGRIFFINDMG1		2427
#define	SND_NPC_SKELGRIFFINDMG2		2428

#define	SND_NPC_SKELLEADERATK1		2429
#define	SND_NPC_SKELLEADERATK2		2430
#define	SND_NPC_SKELLEADERDIE1		2431
#define	SND_NPC_SKELLEADERFLYDIE1	2432	
#define	SND_NPC_SKELLEADERIDLE1		2433
#define	SND_NPC_SKELLEADERDMG1		2434
#define	SND_NPC_SKELLEADERDMG2		2435

#define	SND_NPC_SKELSPAINATK1		2436
#define	SND_NPC_SKELSPAINATK2		2437
#define	SND_NPC_SKELSPAINDIE1		2438
#define	SND_NPC_SKELSPAINFLYDIE1	2439	
#define	SND_NPC_SKELSPAINIDLE1		2440
#define	SND_NPC_SKELSPAINDMG1		2441
#define	SND_NPC_SKELSPAINDMG2		2442

#define	SND_NPC_SKELSHAMENATK1		2443
#define	SND_NPC_SKELSHAMENATK2		2444
#define	SND_NPC_SKELSHAMENDIE1		2445
#define	SND_NPC_SKELSHAMENFLYDIE1	2446	
#define	SND_NPC_SKELSHAMENIDLE1		2447
#define	SND_NPC_SKELSHAMENDMG1		2448
#define	SND_NPC_SKELSHAMENDMG2		2449

#define	SND_NPC_SKELRIDERATK1		2450
#define	SND_NPC_SKELRIDERATK2		2451
#define	SND_NPC_SKELRIDERDIE1		2452
#define	SND_NPC_SKELRIDERFLYDIE1	2453	
#define	SND_NPC_SKELRIDERIDLE1		2454
#define	SND_NPC_SKELRIDERDMG1		2455
#define	SND_NPC_SKELRIDERDMG2		2456

#define	SND_NPC_SKELDEVILATK1		2457
#define	SND_NPC_SKELDEVILATK2		2458
#define	SND_NPC_SKELDEVILATK3		2459
#define	SND_NPC_SKELDEVILDIE1		2460
#define	SND_NPC_SKELDEVILFLYDIE1	2461	
#define	SND_NPC_SKELDEVILIDLE1		2462
#define	SND_NPC_SKELDEVILDMG1		2463
#define	SND_NPC_SKELDEVILDMG2		2464

#define	SND_NPC_BIGCOBRAATK1		2465
#define	SND_NPC_BIGCOBRAATK2		2466
#define	SND_NPC_BIGCOBRADIE1		2467
#define	SND_NPC_BIGCOBRAFLYDIE1		2468
#define	SND_NPC_BIGCOBRAIDLE1		2469
#define	SND_NPC_BIGCOBRADMG1		2470
#define	SND_NPC_BIGCOBRADMG2		2471

#define	SND_NPC_BIGVARIETYCOBRAATK1	2472	
#define	SND_NPC_BIGVARIETYCOBRAATK2	2473	
#define	SND_NPC_BIGVARIETYCOBRADIE1	2474	
#define	SND_NPC_BIGVARIETYCOBRAFLYDIE1	2475	
#define	SND_NPC_BIGVARIETYCOBRAIDLE1	2476	
#define	SND_NPC_BIGVARIETYCOBRADMG1	2477	
#define	SND_NPC_BIGVARIETYCOBRADMG2	2478	

#define	SND_NPC_BIGRACCONATK1		2479
#define	SND_NPC_BIGRACCONATK2		2480
#define	SND_NPC_BIGRACCONDIE1		2481
#define	SND_NPC_BIGRACCONFLYDIE1	2482	
#define	SND_NPC_BIGRACCONIDLE1		2483
#define	SND_NPC_BIGRACCONDMG1		2484
#define	SND_NPC_BIGRACCONDMG2		2485

#define	SND_NPC_BIGSOLDIERRACCONATK1	2486	
#define	SND_NPC_BIGSOLDIERRACCONATK2	2487
#define	SND_NPC_BIGSOLDIERRACCONDIE1	2488
#define	SND_NPC_BIGSOLDIERRACCONFLYDIE1	2489
#define	SND_NPC_BIGSOLDIERRACCONIDLE1	2490
#define	SND_NPC_BIGSOLDIERRACCONDMG1	2491
#define	SND_NPC_BIGSOLDIERRACCONDMG2	2492

#define	SND_NPC_SOLDIERTANGZATK1	2493
#define	SND_NPC_SOLDIERTANGZATK2	2494
#define	SND_NPC_SOLDIERTANGZDIE1	2495
#define	SND_NPC_SOLDIERTANGZFLYDIE1	2496
#define	SND_NPC_SOLDIERTANGZIDLE1	2497
#define	SND_NPC_SOLDIERTANGZDMG1	2498
#define	SND_NPC_SOLDIERTANGZDMG2	2499

#define	SND_NPC_SHAMANWUTANGKAATK1	2500
#define	SND_NPC_SHAMANWUTANGKAATK2	2501	
#define	SND_NPC_SHAMANWUTANGKADIE1	2502	
#define	SND_NPC_SHAMANWUTANGKAFLYDIE1	2503	
#define	SND_NPC_SHAMANWUTANGKAIDLE1	2504	
#define	SND_NPC_SHAMANWUTANGKADMG1	2505	
#define	SND_NPC_SHAMANWUTANGKADMG2	2506	

#define	SND_NPC_BESIBIGGOOTATK1		2507
#define	SND_NPC_BESIBIGGOOTATK2		2508
#define	SND_NPC_BESIBIGGOOTATK3		2509
#define	SND_NPC_BESIBIGGOOTDIE1		2510
#define	SND_NPC_BESIBIGGOOTFLYDIE1	2511	
#define	SND_NPC_BESIBIGGOOTIDLE1	2512	
#define	SND_NPC_BESIBIGGOOTDMG1		2513
#define	SND_NPC_BESIBIGGOOTDMG2		2514

#define	SND_NPC_MOKOMOCIATK1		2515
#define	SND_NPC_MOKOMOCIDIE1		2516
#define	SND_NPC_MOKOMOCIFLYDIE1		2517
#define	SND_NPC_MOKOMOCIIDLE1		2518
#define	SND_NPC_MOKOMOCIDMG1		2519

#define	SND_NPC_RABBITGUARDERATK1		2520
#define	SND_NPC_RABBITGUARDERATK2		2521
#define	SND_NPC_RABBITGUARDERDIE1		2522
#define	SND_NPC_RABBITGUARDERFLYDIE1	2523	
#define	SND_NPC_RABBITGUARDERIDLE1		2524
#define	SND_NPC_RABBITGUARDERDMG1		2525
#define	SND_NPC_RABBITGUARDERDMG2		2526
#define	SND_NPC_TUTTLEFIGHTERATK1		2527
#define	SND_NPC_TUTTLEFIGHTERATK2		2528
#define	SND_NPC_TUTTLEFIGHTERDIE1		2529
#define	SND_NPC_TUTTLEFIGHTERFLYDIE1	2530	
#define	SND_NPC_TUTTLEFIGHTERIDLE1		2531
#define	SND_NPC_TUTTLEFIGHTERDMG1		2532
#define	SND_NPC_TUTTLEFIGHTERDMG2		2533
#define	SND_NPC_TUTTLESWORDERATK1		2534
#define	SND_NPC_TUTTLESWORDERATK2		2535
#define	SND_NPC_TUTTLESWORDERDIE1		2536
#define	SND_NPC_TUTTLESWORDERFLYDIE1	2537	
#define	SND_NPC_TUTTLESWORDERIDLE1		2538
#define	SND_NPC_TUTTLESWORDERDMG1		2539
#define	SND_NPC_TUTTLESWORDERDMG2		2540
#define	SND_NPC_TUTTLEASSASSINATK1		2541
#define	SND_NPC_TUTTLEASSASSINATK2		2542
#define	SND_NPC_TUTTLEASSASSINDIE1		2543
#define	SND_NPC_TUTTLEASSASSINFLYDIE1	2544	
#define	SND_NPC_TUTTLEASSASSINIDLE1		2545
#define	SND_NPC_TUTTLEASSASSINDMG1		2546	
#define	SND_NPC_TUTTLEASSASSINDMG2		2547	
#define	SND_NPC_TUTTLEAXEATK1			2548
#define	SND_NPC_TUTTLEAXEATK2			2549
#define	SND_NPC_TUTTLEAXEDIE1			2550
#define	SND_NPC_TUTTLEAXEFLYDIE1		2551	
#define	SND_NPC_TUTTLEAXEDLE1			2552
#define	SND_NPC_TUTTLEAXEDMG1			2553
#define	SND_NPC_TUTTLEAXEDMG2			2554
#define	SND_NPC_TUTTLESPEARATK1			2555
#define	SND_NPC_TUTTLESPEARATK2			2556
#define	SND_NPC_TUTTLESPEARDIE1			2557
#define	SND_NPC_TUTTLESPEARFLYDIE1		2558	
#define	SND_NPC_TUTTLESPEARIDLE1		2559	
#define	SND_NPC_TUTTLESPEARDMG1			2560
#define	SND_NPC_TUTTLESPEARDMG2			2561
#define	SND_NPC_TUTTLEKINGATK1			2562
#define	SND_NPC_TUTTLEKINGATK2			2563
#define	SND_NPC_TUTTLEKINGATK3			2564
#define	SND_NPC_TUTTLEKINGDIE1			2565
#define	SND_NPC_TUTTLEKINGFLYDIE1		2566	
#define	SND_NPC_TUTTLEKINGIDLE1			2567
#define	SND_NPC_TUTTLEKINGDMG1			2568
#define	SND_NPC_TUTTLEKINGDMG2			2569




//16차 카일룬 초원 몬스터				

// 퍼펫 울프				
#define	SND_NPC_PUPPETWOLFATK1			2570
#define	SND_NPC_PUPPETWOLFATK2			2571
#define	SND_NPC_PUPPETWOLFDIE1			2572
#define	SND_NPC_PUPPETWOLFDMG1			2573
#define	SND_NPC_PUPPETWOLFDMG2			2574
#define	SND_NPC_PUPPETWOLFFLYDIE1		2575	
#define	SND_NPC_PUPPETWOLFIDLE1			2576

// 라이칸 보초병				
#define	SND_NPC_RYSENTRYATK1			2577
#define	SND_NPC_RYSENTRYATK2			2578
#define	SND_NPC_RYSENTRYDIE1			2579
#define	SND_NPC_RYSENTRYDMG1			2580
#define	SND_NPC_RYSENTRYDMG2			2581
#define	SND_NPC_RYSENTRYFLYDIE1			2582
#define	SND_NPC_RYSENTRYIDLE1			2583

// 라이칸 경계병					
#define	SND_NPC_RYGUARDATK1				2584
#define	SND_NPC_RYGUARDATK2				2585
#define	SND_NPC_RYGUARDDIE1				2586
#define	SND_NPC_RYGUARDDMG1				2587
#define	SND_NPC_RYGUARDDMG2				2588
#define	SND_NPC_RYGUARDFLYDIE1			2589	
#define	SND_NPC_RYGUARDIDLE1			2590	

// 라이칸 궁사					
#define	SND_NPC_RYARCHERATK1			2591	
#define	SND_NPC_RYARCHERATK2			2592	
#define	SND_NPC_RYARCHERDIE1			2593	
#define	SND_NPC_RYARCHERDMG1			2594	
#define	SND_NPC_RYARCHERDMG2			2595	
#define	SND_NPC_RYARCHERFLYDIE1			2596	
#define	SND_NPC_RYARCHERIDLE1			2597	

// 라이칸 주술사					
#define	SND_NPC_RYMAGIATK1				2598
#define	SND_NPC_RYMAGIATK2				2599
#define	SND_NPC_RYMAGIDIE1				2600
#define	SND_NPC_RYMAGIDMG1				2601
#define	SND_NPC_RYMAGIDMG2				2602
#define	SND_NPC_RYMAGIFLYDIE1			2603	
#define	SND_NPC_RYMAGIIDLE1				2604

// 라이칸 전투병					
#define	SND_NPC_RYWARRIORATK1			2605	
#define	SND_NPC_RYWARRIORATK2			2606	
#define	SND_NPC_RYWARRIORDIE1			2607	
#define	SND_NPC_RYWARRIORDMG1			2608	
#define	SND_NPC_RYWARRIORDMG2			2609
#define	SND_NPC_RYWARRIORFLYDIE1		2610	
#define	SND_NPC_RYWARRIORIDLE1			2611


// 라이칸 바르가
#define	SND_NPC_RYBARGAATK1			2612
#define	SND_NPC_RYBARGAATK2			2613
#define	SND_NPC_RYBARGAATK3			2614
#define	SND_NPC_RYBARGADIE1			2615
#define	SND_NPC_RYBARGADMG1			2616
#define	SND_NPC_RYBARGADMG2			2617
#define	SND_NPC_RYBARGAFLYDIE1		2618
#define	SND_NPC_RYBARGAIDLE1			2619



//16차 베히모스 몬스터				

// 저주받은 석상				
#define	SND_NPC_STATUEATK1				2620
#define	SND_NPC_STATUEATK2				2621
#define	SND_NPC_STATUEDIE1				2622
#define	SND_NPC_STATUEDMG1				2623
#define	SND_NPC_STATUEDMG2				2624
#define	SND_NPC_STATUEFLYDIE1			2625	
#define	SND_NPC_STATUEIDLE1				2626

// 죽음의 정령 툴라				
#define	SND_NPC_SPIRITTULAATK1			2627 //프레임 수정
#define	SND_NPC_SPIRITTULAATK2			2628 //프레임 수정
#define	SND_NPC_SPIRITTULADIE1			2629
#define	SND_NPC_SPIRITTULADMG1			2630
#define	SND_NPC_SPIRITTULADMG2			2631
#define	SND_NPC_SPIRITTULAFLYDIE1		2632 //프레임 수정
#define	SND_NPC_SPIRITTULAIDLE1			2633

// 죽음의 정령 움툴라	
#define	SND_NPC_SPIRITUMTULAATK1			2634
#define	SND_NPC_SPIRITUMTULAATK2			2635
#define	SND_NPC_SPIRITUMTULADIE1			2636
#define	SND_NPC_SPIRITUMTULADMG1			2637
#define	SND_NPC_SPIRITUMTULADMG2			2638
#define	SND_NPC_SPIRITUMTULAFLYDIE1			2639
#define	SND_NPC_SPIRITUMTULAIDLE1			2640


// 죽음의 정령 바그니스				
#define	SND_NPC_SPIRITBAGNISATK1		2641
#define	SND_NPC_SPIRITBAGNISATK2		2642
#define	SND_NPC_SPIRITBAGNISDIE1		2643
#define	SND_NPC_SPIRITBAGNISDMG1		2644
#define	SND_NPC_SPIRITBAGNISDMG2		2645
#define	SND_NPC_SPIRITBAGNISFLYDIE1		2646	
#define	SND_NPC_SPIRITBAGNISIDLE1		2647

// 죽음의 정령 옵니스 ( 몬스터 목소리 고음으로 수정요청)			
#define	SND_NPC_SPIRITOBNISATK1			2648
#define	SND_NPC_SPIRITOBNISATK2			2649
#define	SND_NPC_SPIRITOBNISDIE1			2650
#define	SND_NPC_SPIRITOBNISDMG1			2651
#define	SND_NPC_SPIRITOBNISDMG2			2652
#define	SND_NPC_SPIRITOBNISFLYDIE1		2653	
#define	SND_NPC_SPIRITOBNISIDLE1		2654

// 베히모스 수호자				
#define	SND_NPC_BEGUARDIANATK1			2655
#define	SND_NPC_BEGUARDIANATK2			2656
#define	SND_NPC_BEGUARDIANDIE1			2657
#define	SND_NPC_BEGUARDIANDMG1			2658
#define	SND_NPC_BEGUARDIANDMG2			2659
#define	SND_NPC_BEGUARDIANFLYDIE1		2660	
#define	SND_NPC_BEGUARDIANIDLE1			2661

// 베히모스				

#define	SND_NPC_BEHEMOTHATK1			2662
#define	SND_NPC_BEHEMOTHATK2			2663
#define	SND_NPC_BEHEMOTHATK3			2664
#define	SND_NPC_BEHEMOTHDIE1			2665
#define	SND_NPC_BEHEMOTHDMG1			2666
#define	SND_NPC_BEHEMOTHDMG2			2667
#define	SND_NPC_BEHEMOTHFLYDIE1			2668
#define	SND_NPC_BEHEMOTHIDLE1			2669


//17차 바하라 사막 몬스터

// 모래 바람의 루갈루
#define	SND_NPC_BAHARARUGALWINDATK1			2670
#define	SND_NPC_BAHARARUGALWINDATK2			2671
#define	SND_NPC_BAHARARUGALWINDDIE1			2672
#define	SND_NPC_BAHARARUGALWINDDMG1			2673
#define	SND_NPC_BAHARARUGALWINDDMG2			2674
#define	SND_NPC_BAHARARUGALWINDFLYDIE1		2675	
#define	SND_NPC_BAHARARUGALWINDIDLE1		2676

// 폭염의 루갈루				
#define	SND_NPC_BAHARARUGALHEATATK1			2677
#define	SND_NPC_BAHARARUGALHEATATK2			2678
#define	SND_NPC_BAHARARUGALHEATDIE1			2679
#define	SND_NPC_BAHARARUGALHEATDMG1			2680
#define	SND_NPC_BAHARARUGALHEATDMG2			2681
#define	SND_NPC_BAHARARUGALHEATFLYDIE1		2682	
#define	SND_NPC_BAHARARUGALHEATIDLE1		2683

// 사막의 정령 쿰			
#define	SND_NPC_RUGALKUMAATK1			2684
#define	SND_NPC_RUGALKUMAATK2			2685
#define	SND_NPC_RUGALKUMADIE1			2686
#define	SND_NPC_RUGALKUMADMG1			2687
#define	SND_NPC_RUGALKUMADMG2			2688
#define	SND_NPC_RUGALKUMAFLYDIE1		2689	
#define	SND_NPC_RUGALKUMAIDLE1			2690

// 사막의 정령 림			
#define	SND_NPC_RUGALRIMAATK1			2691
#define	SND_NPC_RUGALRIMAATK2			2692
#define	SND_NPC_RUGALRIMADIE1			2693
#define	SND_NPC_RUGALRIMADMG1			2694
#define	SND_NPC_RUGALRIMADMG2			2695
#define	SND_NPC_RUGALRIMAFLYDIE1		2696	
#define	SND_NPC_RUGALRIMAIDLE1			2697

// 길들여진 모래 바람의 루갈루			
#define	SND_NPC_RUGALWIND01ATK1			2698
#define	SND_NPC_RUGALWIND01ATK2			2699
#define	SND_NPC_RUGALWIND01DIE1			2700
#define	SND_NPC_RUGALWIND01DMG1			2701
#define	SND_NPC_RUGALWIND01DMG2			2702
#define	SND_NPC_RUGALWIND01FLYDIE1		2703	
#define	SND_NPC_RUGALWIND01IDLE1		2704

// 길들여진 폭염의 루갈루			
#define	SND_NPC_RUGALHEAT01ATK1			2705
#define	SND_NPC_RUGALHEAT01ATK2			2706
#define	SND_NPC_RUGALHEAT01DIE1			2707
#define	SND_NPC_RUGALHEAT01DMG1			2708
#define	SND_NPC_RUGALHEAT01DMG2			2709
#define	SND_NPC_RUGALHEAT01FLYDIE1		2710	
#define	SND_NPC_RUGALHEAT01IDLE1		2711

// 루갈루 마스터 쿠마				
#define	SND_NPC_RUGALKUMA01ATK1			2712
#define	SND_NPC_RUGALKUMA01ATK2			2713
#define	SND_NPC_RUGALKUMA01DIE1			2714
#define	SND_NPC_RUGALKUMA01DMG1			2715
#define	SND_NPC_RUGALKUMA01DMG2			2716
#define	SND_NPC_RUGALKUMA01FLYDIE1		2717	
#define	SND_NPC_RUGALKUMA01IDLE1		2718

// 루갈루 마스터 리마				
#define	SND_NPC_RUGALRIMA01ATK1			2719
#define	SND_NPC_RUGALRIMA01ATK2			2720
#define	SND_NPC_RUGALRIMA01DIE1			2721
#define	SND_NPC_RUGALRIMA01DMG1			2722
#define	SND_NPC_RUGALRIMA01DMG2			2723
#define	SND_NPC_RUGALRIMA01FLYDIE1		2724	
#define	SND_NPC_RUGALRIMA01IDLE1		2725

// 바실리스크				
#define	SND_NPC_BASILISKATK1			2726
#define	SND_NPC_BASILISKATK2			2727
#define	SND_NPC_BASILISKATK3			2789
#define	SND_NPC_BASILISKDIE1			2728
#define	SND_NPC_BASILISKDMG1			2729
#define	SND_NPC_BASILISKDMG2			2730
#define	SND_NPC_BASILISKFLYDIE1			2731	
#define	SND_NPC_BASILISKIDLE1			2732

//17차 칼가스 동굴 몬스터

// 지하의 망령 쿠마
#define	SND_NPC_KALGASKUMAATK1			2733
#define	SND_NPC_KALGASKUMAATK2			2734
#define	SND_NPC_KALGASKUMADIE1			2735
#define	SND_NPC_KALGASKUMADMG1			2736
#define	SND_NPC_KALGASKUMADMG2			2737
#define	SND_NPC_KALGASKUMAFLYDIE1		2738	
#define	SND_NPC_KALGASKUMAIDLE1			2739

// 지하의 망령 리마				
#define	SND_NPC_KALGASRUMAATK1			2740
#define	SND_NPC_KALGASRUMAATK2			2741
#define	SND_NPC_KALGASRUMADIE1			2742
#define	SND_NPC_KALGASRUMADMG1			2743
#define	SND_NPC_KALGASRUMADMG2			2744
#define	SND_NPC_KALGASRUMAFLYDIE1		2745	
#define	SND_NPC_KALGASRUMAIDLE1			2746

// 베히비 카르고			
#define	SND_NPC_KALGASBABYATK1			2747
#define	SND_NPC_KALGASBABYATK2			2748
#define	SND_NPC_KALGASBABYDIE1			2749
#define	SND_NPC_KALGASBABYDMG1			2750
#define	SND_NPC_KALGASBABYDMG2			2751
#define	SND_NPC_KALGASBABYFLYDIE1		2752	
#define	SND_NPC_KALGASBABYIDLE1			2753

// 플라이 카르고			
#define	SND_NPC_KALGASFLYATK1			2754
#define	SND_NPC_KALGASFLYATK2			2755
#define	SND_NPC_KALGASFLYDIE1			2756
#define	SND_NPC_KALGASFLYDMG1			2757
#define	SND_NPC_KALGASFLYDMG2			2758
#define	SND_NPC_KALGASFLYFLYDIE1		2759	
#define	SND_NPC_KALGASFLYIDLE1			2760

// 레서 칼가스			
#define	SND_NPC_LESSERATK1				2761
#define	SND_NPC_LESSERATK2				2762
#define	SND_NPC_LESSERDIE1				2763
#define	SND_NPC_LESSERDMG1				2764
#define	SND_NPC_LESSERDMG2				2765
#define	SND_NPC_LESSERFLYDIE1			2766	
#define	SND_NPC_LESSERIDLE1				2767

// 결계의 수호자 에킨			
#define	SND_NPC_KALGASAKINATK1			2768
#define	SND_NPC_KALGASAKINATK2			2769
#define	SND_NPC_KALGASAKINDIE1			2770
#define	SND_NPC_KALGASAKINDMG1			2771
#define	SND_NPC_KALGASAKINDMG2			2772
#define	SND_NPC_KALGASAKINFLYDIE1		2773	
#define	SND_NPC_KALGASAKINIDLE1			2774

// 결계의 수호자 발트				
#define	SND_NPC_KALGASBALTATK1			2775
#define	SND_NPC_KALGASBALTATK2			2776
#define	SND_NPC_KALGASBALTDIE1			2777
#define	SND_NPC_KALGASBALTDMG1			2778
#define	SND_NPC_KALGASBALTDMG2			2779
#define	SND_NPC_KALGASBALTFLYDIE1		2780	
#define	SND_NPC_KALGASBALTIDLE1			2781

// 날카로운 송곳니의 칼가스				
#define	SND_NPC_KALGASTOOTHATK1			2782
#define	SND_NPC_KALGASTOOTHATK2			2783
#define	SND_NPC_KALGASTOOTHATK3			2790
#define	SND_NPC_KALGASTOOTHDIE1			2784
#define	SND_NPC_KALGASTOOTHDMG1			2785
#define	SND_NPC_KALGASTOOTHDMG2			2786
#define	SND_NPC_KALGASTOOTHFLYDIE1		2787	
#define	SND_NPC_KALGASTOOTHIDLE1		2788


// 다음 사운드 추가는 2791번부터 하시면됩니다.

//이벤트 감자보스
#define	SND_NPC_COLOBOSS01ATK1			2791
#define	SND_NPC_COLOBOSS01ATK2			2792
#define	SND_NPC_COLOBOSS01ATK3			2793
#define	SND_NPC_COLOBOSS01DIE1			2794
#define	SND_NPC_COLOBOSS01DMG1			2795
#define	SND_NPC_COLOBOSS01DMG2			2796
#define	SND_NPC_COLOBOSS01FLYDIE1		2797	
#define	SND_NPC_COLOBOSS01IDLE1			2798

//17차 에킨 발트 석상 사운드
#define	SND_NPC_KALGASSTELE01DIE1		2799
#define	SND_NPC_KALGASSTELE02DIE1		2800
#define SND_NPC_KALGASEGG01DIE1			2801


//18차 유프레시아 몬스터 사운드

#define	SND_NPC_DREAMRAPRAATK1			2802
#define	SND_NPC_DREAMRAPRAATK2			2803
#define	SND_NPC_DREAMRAPRAIDLE1			2804
#define	SND_NPC_DREAMRAPRADIE1			2805
#define	SND_NPC_DREAMRAPRADMG1			2806
#define	SND_NPC_DREAMRAPRADMG2			2807
#define	SND_NPC_DREAMRAPRAFLYDIE1		2808	

#define	SND_NPC_DREAMFLAMEATK1			2809
#define	SND_NPC_DREAMFLAMEATK2			2810
#define	SND_NPC_DREAMFLAMEIDLE1			2811
#define	SND_NPC_DREAMFLAMEDIE1			2812
#define	SND_NPC_DREAMFLAMEDMG1			2813
#define	SND_NPC_DREAMFLAMEDMG2			2814
#define	SND_NPC_DREAMFLAMEFLYDIE1		2815

#define	SND_NPC_DREAMOLDRUTATK1			2816
#define	SND_NPC_DREAMOLDRUTATK2			2817
#define	SND_NPC_DREAMOLDRUTIDLE1		2818
#define	SND_NPC_DREAMOLDRUTDIE1			2819
#define	SND_NPC_DREAMOLDRUTDMG1			2820
#define	SND_NPC_DREAMOLDRUTDMG2			2821
#define	SND_NPC_DREAMOLDRUTFLYDIE1		2822

#define	SND_NPC_DREAMMINIMUSHUATK1		2823
#define	SND_NPC_DREAMMINIMUSHUATK2		2824
#define	SND_NPC_DREAMMINIMUSHUIDLE1		2825
#define	SND_NPC_DREAMMINIMUSHUDIE1		2826
#define	SND_NPC_DREAMMINIMUSHUDMG1		2827
#define	SND_NPC_DREAMMINIMUSHUDMG2		2828
#define	SND_NPC_DREAMMINIMUSHUFLYDIE1		2829

#define	SND_NPC_DREAMLADYBLUMATK1		2830
#define	SND_NPC_DREAMLADYBLUMATK2		2831
#define	SND_NPC_DREAMLADYBLUMIDLE1		2832
#define	SND_NPC_DREAMLADYBLUMDIE1		2833
#define	SND_NPC_DREAMLADYBLUMDMG1		2834
#define	SND_NPC_DREAMLADYBLUMDMG2		2835
#define	SND_NPC_DREAMLADYBLUMFLYDIE1		2836

#define	SND_NPC_DREAMNIGHTMISTATK1		2837
#define	SND_NPC_DREAMNIGHTMISTATK2		2838
#define	SND_NPC_DREAMNIGHTMISTIDLE1		2839
#define	SND_NPC_DREAMNIGHTMISTDIE1		2840
#define	SND_NPC_DREAMNIGHTMISTDMG1		2841
#define	SND_NPC_DREAMNIGHTMISTDMG2		2842
#define	SND_NPC_DREAMNIGHTMISTFLYDIE1		2843

#define	SND_NPC_DREAMQEENATK1			2844
#define	SND_NPC_DREAMQEENATK2			2845
#define	SND_NPC_DREAMQEENATK3			2846
#define	SND_NPC_DREAMQEENIDLE1		2847
#define	SND_NPC_DREAMQEENDIE1			2848
#define	SND_NPC_DREAMQEENDMG1			2849
#define	SND_NPC_DREAMQEENDMG2			2850
#define	SND_NPC_DREAMQEENFLYDIE1		2851


//18차 헤르네오스 몬스터 사운드

#define	SND_NPC_DREAMHERNSHARKATK1		2852
#define	SND_NPC_DREAMHERNSHARKATK2		2853
#define	SND_NPC_DREAMHERNSHARKIDLE1		2854
#define	SND_NPC_DREAMHERNSHARKDIE1		2855
#define	SND_NPC_DREAMHERNSHARKDMG1		2856
#define	SND_NPC_DREAMHERNSHARKDMG2		2857
#define	SND_NPC_DREAMHERNSHARKFLYDIE1		2858

#define	SND_NPC_DREAMHERNMERMANATK1		2853
#define	SND_NPC_DREAMHERNMERMANATK2		2854
#define	SND_NPC_DREAMHERNMERMANIDLE1		2855
#define	SND_NPC_DREAMHERNMERMANDIE1		2856
#define	SND_NPC_DREAMHERNMERMANDMG1		2857
#define	SND_NPC_DREAMHERNMERMANDMG2		2858
#define	SND_NPC_DREAMHERNMERMANFLYDIE1		2859

#define	SND_NPC_DREAMHERNTURTLEATK1		2860
#define	SND_NPC_DREAMHERNTURTLEATK2		2861
#define	SND_NPC_DREAMHERNTURTLEIDLE1		2862
#define	SND_NPC_DREAMHERNTURTLEDIE1		2863
#define	SND_NPC_DREAMHERNTURTLEDMG1		2864
#define	SND_NPC_DREAMHERNTURTLEDMG2		2865
#define	SND_NPC_DREAMHERNTURTLEFLYDIE1		2866

#define	SND_NPC_DREAMHERNMERMAIDATK1		2867
#define	SND_NPC_DREAMHERNMERMAIDATK2		2868
#define	SND_NPC_DREAMHERNMERMAIDIDLE1		2869
#define	SND_NPC_DREAMHERNMERMAIDDIE1		2870
#define	SND_NPC_DREAMHERNMERMAIDDMG1		2871
#define	SND_NPC_DREAMHERNMERMAIDDMG2		2872
#define	SND_NPC_DREAMHERNMERMAIDFLYDIE1		2873

#define	SND_NPC_DREAMHERNSIRENATK1		2874
#define	SND_NPC_DREAMHERNSIRENATK2		2875
#define	SND_NPC_DREAMHERNSIRENIDLE1		2876
#define	SND_NPC_DREAMHERNSIRENDIE1		2877
#define	SND_NPC_DREAMHERNSIRENDMG1		2878
#define	SND_NPC_DREAMHERNSIRENDMG2		2879
#define	SND_NPC_DREAMHERNSIRENFLYDIE1		2880

#define	SND_NPC_DREAMHERNKRAKENATK1		2881
#define	SND_NPC_DREAMHERNKRAKENATK2		2882
#define	SND_NPC_DREAMHERNKRAKENATK3		2883
#define	SND_NPC_DREAMHERNKRAKENIDLE1		2884
#define	SND_NPC_DREAMHERNKRAKENDIE1		2885
#define	SND_NPC_DREAMHERNKRAKENDMG1		2886
#define	SND_NPC_DREAMHERNKRAKENDMG2		2887
#define	SND_NPC_DREAMHERNKRAKENFLYDIE1		2888

//18차 산프레스호 몬스터 사운드

#define	SND_NPC_DREAMSHIPMAUGUSATK1		2889
#define	SND_NPC_DREAMSHIPMAUGUSATK2		2890
#define	SND_NPC_DREAMSHIPMAUGUSIDLE1		2891
#define	SND_NPC_DREAMSHIPMAUGUSDIE1		2892
#define	SND_NPC_DREAMSHIPMAUGUSDMG1		2893
#define	SND_NPC_DREAMSHIPMAUGUSDMGDIE1		2894
#define	SND_NPC_DREAMSHIPMAUGUSFLYDIE1		2895

#define	SND_NPC_DREAMSHIPWINGMAUGUSATK1		2896
#define	SND_NPC_DREAMSHIPWINGMAUGUSATK2		2897
#define	SND_NPC_DREAMSHIPWINGMAUGUSIDLE1	2898
#define	SND_NPC_DREAMSHIPWINGMAUGUSDIE1		2899
#define	SND_NPC_DREAMSHIPWINGMAUGUSDMG1		2900
#define	SND_NPC_DREAMSHIPWINGMAUGUSDMGDIE1		2901
#define	SND_NPC_DREAMSHIPWINGMAUGUSFLYDIE1	2902

#define	SND_NPC_DREAMSHIPMESPIATK1		2945
#define	SND_NPC_DREAMSHIPMESPIATK2		2903
#define	SND_NPC_DREAMSHIPMESPIIDLE1		2904
#define	SND_NPC_DREAMSHIPMESPIDIE1		2905
#define	SND_NPC_DREAMSHIPMESPIDMG1		2906
#define	SND_NPC_DREAMSHIPMESPIDMGDIE1		2907
#define	SND_NPC_DREAMSHIPMESPIFLYDIE1		2908

#define	SND_NPC_DREAMSHIPWINDMESPIATK1		2909
#define	SND_NPC_DREAMSHIPWINDMESPIATK2		2910
#define	SND_NPC_DREAMSHIPWINDMESPIIDLE1		2911
#define	SND_NPC_DREAMSHIPWINDMESPIDIE1		2912
#define	SND_NPC_DREAMSHIPWINDMESPIDMG1		2913
#define	SND_NPC_DREAMSHIPWINDMESPIDMGDIE1		2914
#define	SND_NPC_DREAMSHIPWINDMESPIFLYDIE1	2915

#define	SND_NPC_DREAMSHIPREDHARPYATK1		2916
#define	SND_NPC_DREAMSHIPREDHARPYATK2		2917
#define	SND_NPC_DREAMSHIPREDHARPYIDLE1		2918
#define	SND_NPC_DREAMSHIPREDHARPYDIE1		2919
#define	SND_NPC_DREAMSHIPREDHARPYDMG1		2920
#define	SND_NPC_DREAMSHIPREDHARPYDMGDIE1		2921
#define	SND_NPC_DREAMSHIPREDHARPYFLYDIE1	2922

#define	SND_NPC_DREAMSHIPHIPPOGRIPHATK1		2923
#define	SND_NPC_DREAMSHIPHIPPOGRIPHATK2		2924
#define	SND_NPC_DREAMSHIPHIPPOGRIPHATK3		2925
#define	SND_NPC_DREAMSHIPHIPPOGRIPHDIE1		2926
#define	SND_NPC_DREAMSHIPHIPPOGRIPHDMG1		2927
#define	SND_NPC_DREAMSHIPHIPPOGRIPHDMG2		2928
#define	SND_NPC_DREAMSHIPHIPPOGRIPHFLYDIE1	2929

#define	SND_NPC_DREAMSHIPHARPINEESATK1		2930
#define	SND_NPC_DREAMSHIPHARPINEESATK2		2931
#define	SND_NPC_DREAMSHIPHARPINEESATK3		2932
#define	SND_NPC_DREAMSHIPHARPINEESIDLE1		2933
#define	SND_NPC_DREAMSHIPHARPINEESDIE1		2934
#define	SND_NPC_DREAMSHIPHARPINEESDMG1		2935
#define	SND_NPC_DREAMSHIPHARPINEESDMG2		2936
#define	SND_NPC_DREAMSHIPHARPINEESDMGDIE	2937

#define	SND_NPC_DREAMSHIPBLUEHARPYATK1		2938
#define	SND_NPC_DREAMSHIPBLUEHARPYATK2		2939
#define	SND_NPC_DREAMSHIPBLUEHARPYIDLE1		2940
#define	SND_NPC_DREAMSHIPBLUEHARPYDIE1		2941
#define	SND_NPC_DREAMSHIPBLUEHARPYDMG1		2942
#define	SND_NPC_DREAMSHIPBLUEHARPYDMGDIE		2943
#define	SND_NPC_DREAMSHIPBLUEHARPYFLYDIE1	2944


//헤르네오스 추가분
#define	SND_NPC_DREAMHERNMERMAN02ATK1		2946
#define	SND_NPC_DREAMHERNMERMAN02ATK2		2947
#define	SND_NPC_DREAMHERNMERMAN02IDLE1		2948
#define	SND_NPC_DREAMHERNMERMAN02DIE1		2949
#define	SND_NPC_DREAMHERNMERMAN02DMG1		2950
#define	SND_NPC_DREAMHERNMERMAN02DMG2		2951
#define	SND_NPC_DREAMHERNMERMAN02FLYDIE1	2952

#define	SND_NPC_DREAMHERNMERMAID02ATK1		2953
#define	SND_NPC_DREAMHERNMERMAID02ATK2		2954
#define	SND_NPC_DREAMHERNMERMAID02IDLE1		2955
#define	SND_NPC_DREAMHERNMERMAID02DIE1		2956
#define	SND_NPC_DREAMHERNMERMAID02DMG1		2957
#define	SND_NPC_DREAMHERNMERMAID02DMG2		2958
#define	SND_NPC_DREAMHERNMERMAID02FLYDIE1	2959
#define	SND_NPC_DREAMHERNSIRENATK3		2960



// 일본 음성 남성 3001, 여성=남성+500"
#define VOC_M_ONE_CLEANHIT                3001
#define VOC_M_ONE_BRANDISH                3002
#define VOC_M_ONE_OVERCUTTER              3003
#define VOC_M_ONE_SPLMASH                 3004
#define VOC_M_ONE_KEENWHEEL               3005
#define VOC_M_ONE_BLINDSIDE               3006
#define VOC_M_ONE_SKILL4                  3007
#define VOC_M_ONE_SKILL5                  3008
#define VOC_M_SHIELD_PROTECTION           3009
#define VOC_M_SHIELD_PANBARRIER           3010
#define VOC_M_SHIELD_RESONACE             3011
#define VOC_M_SHIELD_DOUBLESHIELD         3012
#define VOC_M_SHIELD_NUMBNESS             3013
#define VOC_M_DOUBLE_SKILL1               3014
#define VOC_M_DOUBLE_SKILL2               3015
#define VOC_M_DOUBLE_SKILL3               3016
#define VOC_M_DOUBLE_SKILL4               3017
#define VOC_M_DOUBLE_SKILL5               3018
#define VOC_M_CASE_SKILL1                 3019
#define VOC_M_CASE_SKILL2                 3020
#define VOC_M_CASE_SKILL3                 3021
#define VOC_M_CASE_SKILL4                 3022
#define VOC_M_CASE_SKILL5                 3023
#define VOC_M_JUGGLING_SKILL1             3024
#define VOC_M_JUGGLING_SKILL2             3025
#define VOC_M_JUGGLING_SKILL3             3026
#define VOC_M_JUGGLING_SKILL4             3027
#define VOC_M_JUGGLING_SKILL5             3028
#define VOC_M_ACROBATIC_FEATHERBODY       3029
#define VOC_M_ACROBATIC_ANVILBLASTER      3030
#define VOC_M_ACROBATIC_AIRJUMP           3031
#define VOC_M_ACROBATIC_ELUSION           3032
#define VOC_M_ACROBATIC_DOWNCAST          3033
#define VOC_M_YOYO_SKILL1                 3034
#define VOC_M_YOYO_SKILL2                 3035
#define VOC_M_YOYO_SKILL3                 3036
#define VOC_M_YOYO_SKILL4                 3037
#define VOC_M_YOYO_SKILL5                 3038
#define VOC_M_DANCE_SIDESTEP              3039
#define VOC_M_DANCE_QUICKPASS             3040
#define VOC_M_DANCE_COUNTER               3041
#define VOC_M_DANCE_MISSING               3042
#define VOC_M_DANCE_REFEATION             3043
#define VOC_M_HEAL_HEALING                3044
#define VOC_M_HEAL_RESURRECTION           3045
#define VOC_M_HEAL_PATIENCE               3046
#define VOC_M_HEAL_REGENERATION           3047
#define VOC_M_HEAL_PREVENTION             3048
#define VOC_M_CHEER_HEAPUP                3049
#define VOC_M_CHEER_CANNONBALL            3050
#define VOC_M_CHEER_CIRCLEHEALING         3051
#define VOC_M_CHEER_MENTALSIGN            3052
#define VOC_M_CHEER_BEEFUP                3053
#define VOC_M_ACTING_MORALE               3054
#define VOC_M_ACTING_BETATRON             3055
#define VOC_M_ACTING_BULLSEYE             3056
#define VOC_M_ACTING_MEMORIALDAY          3057
#define VOC_M_ACTING_REV                  3058
#define VOC_M_POSTER_FURIL                3059
#define VOC_M_POSTER_KEROS                3060
#define VOC_M_POSTER_LITT                 3061
#define VOC_M_POSTER_LEHMANN              3062
#define VOC_M_POSTER_DASS                 3063
#define VOC_M_FIRE_BOOMERANG              3064
#define VOC_M_FIRE_HOTAIR                 3065
#define VOC_M_FIRE_BOMB                   3066
#define VOC_M_FIRE_FURNACE                3067
#define VOC_M_FIRE_BLOWUP                 3068
#define VOC_M_WIND_SWORDWIND              3069
#define VOC_M_WIND_STRONGWIND             3070
#define VOC_M_WIND_AFTERSTORM             3071
#define VOC_M_WIND_MICROBURST             3072
#define VOC_M_WIND_VACUUMSTORM            3073
#define VOC_M_WATER_ICECONE               3074
#define VOC_M_WATER_WATERSPOUT            3075
#define VOC_M_WATER_GEYSER                3076
#define VOC_M_WATER_HAILSTORM             3077
#define VOC_M_WATER_DEEPFREEZE            3078
#define VOC_M_EARTH_TURPLEROOT            3079
#define VOC_M_EARTH_SANDHAMMER            3080
#define VOC_M_EARTH_STONEWHEEL            3081
#define VOC_M_EARTH_TENDRIL               3082
#define VOC_M_EARTH_EARTHQUAKE            3083
#define VOC_M_MARIONETTE_SKILL1           3084
#define VOC_M_MARIONETTE_SKILL2           3085
#define VOC_M_MARIONETTE_SKILL3           3086
#define VOC_M_MARIONETTE_SKILL4           3087
#define VOC_M_MARIONETTE_SKILL5           3088
#define VOC_M_STRING_STING                3089
#define VOC_M_STRING_RAINBOWSTRING        3090
#define VOC_M_STRING_SILKSWORD            3091
#define VOC_M_STRING_VIBRATION            3092
#define VOC_M_STRING_COCOON               3093
#define VOC_M_RIFLE_SKILL1                3094
#define VOC_M_RIFLE_SKILL2                3095
#define VOC_M_RIFLE_SKILL3                3096
#define VOC_M_RIFLE_SKILL4                3097
#define VOC_M_RIFLE_SKILL5                3098
#define VOC_M_GIGAPUPPET_SPINHEAD         3099
#define VOC_M_GIGAPUPPET_PUPPETFRIEND     3100
#define VOC_M_GIGAPUPPET_HINGEHAND        3101
#define VOC_M_GIGAPUPPET_TAPDANCE         3102
#define VOC_M_GIGAPUPPET_JUNKRAIN         3103
#define VOC_M_KNU_TAMPINGHOLE             3104
#define VOC_M_KNU_BURSTCRACK              3105
#define VOC_M_PITFALL                     3106
#define VOC_M_BLINKPOOL                   3107

#define VOC_F_ONE_CLEANHIT                3501
#define VOC_F_ONE_BRANDISH                3502
#define VOC_F_ONE_OVERCUTTER              3503
#define VOC_F_ONE_SPLMASH                 3504
#define VOC_F_ONE_KEENWHEEL               3505
#define VOC_F_ONE_BLINDSIDE               3506
#define VOC_F_ONE_SKILL4                  3507
#define VOC_F_ONE_SKILL5                  3508
#define VOC_F_SHIELD_PROTECTION           3509
#define VOC_F_SHIELD_PANBARRIER           3510
#define VOC_F_SHIELD_RESONACE             3511
#define VOC_F_SHIELD_DOUBLESHIELD         3512
#define VOC_F_SHIELD_NUMBNESS             3513
#define VOC_F_DOUBLE_SKILL1               3514
#define VOC_F_DOUBLE_SKILL2               3515
#define VOC_F_DOUBLE_SKILL3               3516
#define VOC_F_DOUBLE_SKILL4               3517
#define VOC_F_DOUBLE_SKILL5               3518
#define VOC_F_CASE_SKILL1                 3519
#define VOC_F_CASE_SKILL2                 3520
#define VOC_F_CASE_SKILL3                 3521
#define VOC_F_CASE_SKILL4                 3522
#define VOC_F_CASE_SKILL5                 3523
#define VOC_F_JUGGLING_SKILL1             3524
#define VOC_F_JUGGLING_SKILL2             3525
#define VOC_F_JUGGLING_SKILL3             3526
#define VOC_F_JUGGLING_SKILL4             3527
#define VOC_F_JUGGLING_SKILL5             3528
#define VOC_F_ACROBATIC_FEATHERBODY       3529
#define VOC_F_ACROBATIC_ANVILBLASTER      3530
#define VOC_F_ACROBATIC_AIRJUMP           3531
#define VOC_F_ACROBATIC_ELUSION           3532
#define VOC_F_ACROBATIC_DOWNCAST          3533
#define VOC_F_YOYO_SKILL1                 3534
#define VOC_F_YOYO_SKILL2                 3535
#define VOC_F_YOYO_SKILL3                 3536
#define VOC_F_YOYO_SKILL4                 3537
#define VOC_F_YOYO_SKILL5                 3538
#define VOC_F_DANCE_SIDESTEP              3539
#define VOC_F_DANCE_QUICKPASS             3540
#define VOC_F_DANCE_COUNTER               3541
#define VOC_F_DANCE_MISSING               3542
#define VOC_F_DANCE_REFEATION             3543
#define VOC_F_HEAL_HEALING                3544
#define VOC_F_HEAL_RESURRECTION           3545
#define VOC_F_HEAL_PATIENCE               3546
#define VOC_F_HEAL_REGENERATION           3547
#define VOC_F_HEAL_PREVENTION             3548
#define VOC_F_CHEER_HEAPUP                3549
#define VOC_F_CHEER_CANNONBALL            3550
#define VOC_F_CHEER_CIRCLEHEALING         3551
#define VOC_F_CHEER_MENTALSIGN            3552
#define VOC_F_CHEER_BEEFUP                3553
#define VOC_F_ACTING_MORALE               3554
#define VOC_F_ACTING_BETATRON             3555
#define VOC_F_ACTING_BULLSEYE             3556
#define VOC_F_ACTING_MEMORIALDAY          3557
#define VOC_F_ACTING_REV                  3558
#define VOC_F_POSTER_FURIL                3559
#define VOC_F_POSTER_KEROS                3560
#define VOC_F_POSTER_LITT                 3561
#define VOC_F_POSTER_LEHMANN              3562
#define VOC_F_POSTER_DASS                 3563
#define VOC_F_FIRE_BOOMERANG              3564
#define VOC_F_FIRE_HOTAIR                 3565
#define VOC_F_FIRE_BOMB                   3566
#define VOC_F_FIRE_FURNACE                3567
#define VOC_F_FIRE_BLOWUP                 3568
#define VOC_F_WIND_SWORDWIND              3569
#define VOC_F_WIND_STRONGWIND             3570
#define VOC_F_WIND_AFTERSTORM             3571
#define VOC_F_WIND_MICROBURST             3572
#define VOC_F_WIND_VACUUMSTORM            3573
#define VOC_F_WATER_ICECONE               3574
#define VOC_F_WATER_WATERSPOUT            3575
#define VOC_F_WATER_GEYSER                3576
#define VOC_F_WATER_HAILSTORM             3577
#define VOC_F_WATER_DEEPFREEZE            3578
#define VOC_F_EARTH_TURPLEROOT            3579
#define VOC_F_EARTH_SANDHAMMER            3580
#define VOC_F_EARTH_STONEWHEEL            3581
#define VOC_F_EARTH_TENDRIL               3582
#define VOC_F_EARTH_EARTHQUAKE            3583
#define VOC_F_MARIONETTE_SKILL1           3584
#define VOC_F_MARIONETTE_SKILL2           3585
#define VOC_F_MARIONETTE_SKILL3           3586
#define VOC_F_MARIONETTE_SKILL4           3587
#define VOC_F_MARIONETTE_SKILL5           3588
#define VOC_F_STRING_STING                3589
#define VOC_F_STRING_RAINBOWSTRING        3590
#define VOC_F_STRING_SILKSWORD            3591
#define VOC_F_STRING_VIBRATION            3592
#define VOC_F_STRING_COCOON               3593
#define VOC_F_RIFLE_SKILL1                3594
#define VOC_F_RIFLE_SKILL2                3595
#define VOC_F_RIFLE_SKILL3                3596
#define VOC_F_RIFLE_SKILL4                3597
#define VOC_F_RIFLE_SKILL5                3598
#define VOC_F_GIGAPUPPET_SPINHEAD         3599
#define VOC_F_GIGAPUPPET_PUPPETFRIEND     3600
#define VOC_F_GIGAPUPPET_HINGEHAND        3601
#define VOC_F_GIGAPUPPET_TAPDANCE         3602
#define VOC_F_GIGAPUPPET_JUNKRAIN         3603
#define VOC_F_KNU_TAMPINGHOLE             3604
#define VOC_F_KNU_BURSTCRACK              3605
#define VOC_F_PITFALL                     3606
#define VOC_F_BLINKPOOL                   3607
#define SND_PC_CHAOS                      3608


// 16 스킬 사운드
//로드 템플러 스 킬
#define SND_PC_SKILLM_PULLING1_01          3609
#define SND_PC_SKILLM_PULLING1_02          3610
#define SND_PC_SKILLM_PULLING1_03          3611
#define SND_PC_SKILLM_PULLING1_04          3612
#define SND_PC_SKILLM_GRANDRAGE_01         3613
#define SND_PC_SKILLM_GRANDRAGE_02         3614
#define SND_PC_SKILLM_SHILDSTRIKE_01       3615
#define SND_PC_SKILLM_SHILDSTRIKE_02       3616
#define SND_PC_SKILLM_ANGER_01             3617	
#define SND_PC_SKILLM_ANGER_02             3618	
#define SND_PC_SKILLM_HOLYARMOR_01         3619		
#define SND_PC_SKILLM_HOLYARMOR_02         3620	
#define SND_PC_SKILLM_SCOPESTRIKE_01       3621	
#define SND_PC_SKILLM_SCOPESTRIKE_02       3622		
//스톰블레이드
#define SND_PC_SKILLM_CROSSBLOOD_01        3623	
#define SND_PC_SKILLM_CROSSBLOOD_02        3624		
#define SND_PC_SKILLM_STORMBLAST_01        3625	
#define SND_PC_SKILLM_STORMBLAST_02        3626	
#define SND_PC_SKILLM_STORMBLAST_03        3627	
#define SND_PC_SKILLM_STORMBLAST_04        3628		
#define SND_PC_SKILLM_POWERINCREASE1_01    3629	
#define SND_PC_SKILLM_POWERINCREASE1_02    3630	
#define SND_PC_SKILLM_HOLDINGSTORM_01      3631	
#define SND_PC_SKILLM_HOLDINGSTORM_02      3632	
#define SND_PC_SKILLM_HOLDINGSTORM_03      3633	
#define SND_PC_SKILLM_HOLDINGSTORM_04      3634	
#define SND_PC_SKILLM_HOLDINGSTORM_05      3635	
//윈드러커
#define SND_PC_SKILLM_MADHURRICANE_01      3636	
#define SND_PC_SKILLM_EVASIONINCREASE_01   3637
#define SND_PC_SKILLM_CONTROLINCREASE1_01  3638	
#define SND_PC_SKILLM_BACKSTEP_01          3639	
#define SND_PC_SKILLM_BACKSTEP_02          3640	
//크랙슈터
#define SND_PC_SKILLM_RANGESTRIKE_01       3641	
#define SND_PC_SKILLM_RANGESTRIKE_02       3642	
#define SND_PC_SKILLM_RANGESTRIKE_03       3643	
#define SND_PC_SKILLM_RANGESTRIKE_04       3644	
#define SND_PC_SKILLM_POWERINCREASE2_01    3645	
#define SND_PC_SKILLM_CONTROLINCREASE2_01  3646
#define SND_PC_SKILLM_HAWKEYE_01           3647	
#define SND_PC_SKILLM_HAWKEYE_02           3648	
//플로리스트
#define SND_PC_SKILLM_DOT_01               3649	
#define SND_PC_SKILLM_DOT_02               3650	
#define SND_PC_SKILLM_BLESSSTEP_01         3651	
#define SND_PC_SKILLM_BLESSSTEP_02         3652	
#define SND_PC_SKILLM_BLESSBODY_01         3653	
#define SND_PC_SKILLM_BLESSBODY_02         3654	
#define SND_PC_SKILLM_BLESSARMOR_01        3655	
#define SND_PC_SKILLM_BLESSARMOR_02        3656	
#define SND_PC_SKILLM_ABSOLUTE_01          3657
#define SND_PC_SKILLM_ABSOLUTE_02          3658
#define SND_PC_SKILLM_PATTERS_01           3659
#define SND_PC_SKILLM_PATTERS_02           3660
//포스마스터
#define SND_PC_SKILLM_FORCETENACITY_01     3661
#define SND_PC_SKILLM_FORCETENACITY_02     3662
#define SND_PC_SKILLM_FORCEANGER_01        3663	
#define SND_PC_SKILLM_FORCEANGER_02        3664	
#define SND_PC_SKILLM_FORCESPEED_01        3665	
#define SND_PC_SKILLM_FORCESPEED_02        3666	
#define SND_PC_SKILLM_FORCEMAD_01          3667	
#define SND_PC_SKILLM_FORCEMAD_02          3668	
//멘탈리스트
#define SND_PC_SKILLM_FEARSCREAM_01        3669	
#define SND_PC_SKILLM_FEARSCREAM_02        3670	
#define SND_PC_SKILLM_FEARSCREAM_03        3671	
#define SND_PC_SKILLM_DARKNESSLAKE_01      3672
#define SND_PC_SKILLM_DARKNESSLAKE_02      3673
#define SND_PC_SKILLM_ATKDECREASE_01       3674
#define SND_PC_SKILLM_DEFDECREASE_01       3675	
#define SND_PC_SKILLM_SPEDECREASE_01       3676
//엘리멘탈로드
#define SND_PC_SKILLM_THUNDERBOLT_01       3677
#define SND_PC_SKILLM_FINALSPEAR_01        3678
#define SND_PC_SKILLM_FINALSPEAR_02        3679
#define SND_PC_SKILLM_FINALSPEAR_03        3680
#define SND_PC_SKILLM_COSMICELEMENT_01     3681	
#define SND_PC_SKILLM_COSMICELEMENT_02     3682
#define SND_PC_SKILLM_COSMICELEMENT_03     3683
#define SND_PC_SKILLM_SLIPPING_01          3684
#define SND_PC_SKILLM_SLIPPING_02          3685


//콜로세움 효과음
#define SND_COLO_ALLSTAGECLEAR		   3691
#define SND_COLO_BOSSAPPEAR		   3692
#define SND_COLO_EVENTBOSSAPPEAR	   3693
#define SND_COLO_COUNT			   3694
#define SND_COLO_STAGECLEAR		   3695
#define SND_COLO_TAKEPRESENT		   3696
#define SND_COLO_TIMEOVER		   3697
#define SND_COLO_PEOPLECHEER		   3698

//아레나 효과음
#define SND_EVENTARENA_WINNER		   3699




/*
"#define BGM_TITLE               ""01_Title_Music.mp3"""
"#define BGM_TOWN1               ""09_Festive_Arabic_BG.mp3"""
"#define BGM_TOWN2               ""06_Magic_City_BG.MP3"""
"#define BGM_TOWN3               ""03_Dark_City_Revised.MP3"""
"#define BGM_DUNGEON1            ""16_Dungeon_Background.MP3"""
"#define BGM_DUNGEON2            ""17_Dungeon_BG.MP3"""
"#define BGM_DUNGEON3            ""18_Dungeon_BG.MP3"""

"#define BGM_THEME1              """""
"#define BGM_THEME2              """""
"#define BGM_THEME3              """""
"#define BGM_THEME4              """""
"#define BGM_THEME5              """""
"#define BGM_THEME6              """""
"#define BGM_THEME7              """""

"#define BGM_BATTLE1             ""23_Combat_BG1.mp3"""
"#define BGM_BATTLE2             ""25_Combat_3.MP3"""
*/
///////////////////////////////////////

#define BGM_NONE             		0
#define BGM_TITLE            		1

//#ifdef __V041122_MUSIC

#define BGM_TO_FLARIS        		2
#define BGM_TO_SAINTMORNING  		3
#define BGM_TO_DARKON        		4

#define BGM_DU_MYSTERY       		5
#define BGM_DU_CREEP         		6
#define BGM_DU_TERROR        		7

#define BGM_TH_GENERAL       		8
#define BGM_TH_LACHRYMOSE    		9
#define BGM_TH_RETURN        		10
#define BGM_TH_TEMPLE        		11
#define BGM_TH_PLAYGROUND    		12
#define BGM_TH_FLYING        		13
#define BGM_TH_MASKBALL      		14

#define BGM_BA_FLARIS        		15
#define BGM_BA_CRISIS        		16

#define BGM_EV_LIGHTWING     		17
#define BGM_EV_HEAVYWING     		18
#define BGM_EV_START         		19
#define BGM_EV_END           		20

#define BGM_IN_BOSS          		21
#define BGM_IN_DEATH         		22
#define BGM_IN_LEVELUP       		23
#define BGM_IN_LEVEL         		24
#define BGM_IN_FITUP         		25
#define BGM_IN_COMPANY      		26
//신규 BGM(16차)
#define BGM_IN_BEHEMOS       		27
#define BGM_IN_RARTESIA      		28
#define BGM_IN_ENRIUN        		29
#define BGM_IN_KAILUN        		30

// 추가 전투 음악
#define BGM_BA_SAINTMORNING  		50
#define BGM_BA_DARKON        		51

// 추가 던젼 음악 
#define BGM_DU_INVISIBLE     		70

// 추가 필드 뮤직 
#define BGM_FI_FLARIS        		120
#define BGM_FI_SAINTMORNING  		121
#define BGM_FI_DARKON1       		122
#define BGM_FI_DARKON2       		123
#define BGM_FI_DARKON3       		124

// 추가 NPC 음악 
#define BGM_NPC_HORROR       		200
#define BGM_NPC_HORROR2      		201
#define BGM_NPC_MILD         		202
#define BGM_NPC_SAD          		203
#define BGM_NPC_SECRET       		204
#define BGM_NPC_SOLEMN       		205
#define BGM_NPC_SOLEMN2      		206
#define BGM_NPC_ACCOMPLISH  		207

#define BGM_DU_BEHEMOTH01	   	3686
#define BGM_TOWN_ELIUN01	   	3687
#define BGM_DU_RARTESIA01      		3688
#define BGM_FIELD_KAILUN01    		3689

//콜로세움 
#define BGM_DU_COLOSSEOUM     		3690

//17차 BGM
#define BGM_DU_KALGAS	     		3691
#define BGM_FLELD_BAHARA	 	3692

//이벤트 아레나 BGM
#define BGM_BA_FWC			3693
//산프레스 저렙 고렙
#define BGM_DU_SANPRES			3700
//유프레시아 저렙 고렙
#define BGM_DU_UPRESIA			3701
//헤르네오스 저렙 고렙
#define BGM_DU_HERNEOS			3702

//신규 플라리스 BGM
#define BGM_TOWN_NEWFLARIS		3703

#define BGM_DU_CONTAMINATEDTRAILS	3704

/*
#else // #ifdef __V041122_MUSIC ///////////////////////////////

#define BGM_TOWN01      2
#define BGM_TOWN02      3
#define BGM_TOWN03      4
#define BGM_DUNGEON01   5
#define BGM_DUNGEON02   6
#define BGM_DUNGEON03   7

#define BGM_THEME01     8
#define BGM_THEME02     9
#define BGM_THEME03    10
#define BGM_THEME04    11
#define BGM_THEME05    12
#define BGM_THEME06    13
#define BGM_THEME07    14

#define BGM_BATTLE01   15
#define BGM_BATTLE02   16

#define BGM_EVENT01    17
#define BGM_EVENT02    18
#define BGM_EVENT03    19
#define BGM_EVENT04    20

#define BGM_INSTANT01  21
#define BGM_INSTANT02  22
#define BGM_INSTANT03  23
#define BGM_INSTANT04  24
#define BGM_INSTANT05  25
#define BGM_INSTANT06  26
#endif
*/

#endif
