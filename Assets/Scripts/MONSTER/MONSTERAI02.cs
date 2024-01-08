using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.AI;

public class MONSTERAI02 : MonoBehaviour
{
    public int monsterno;
    public float monster_Index;
    public string monster_Name;
    public float monsterLV;
    public float mobExp;//몬스터 경험치
    public float attack_Range;//몬스터 공격전급 범위
    public float rotation_Speed;//플레이어에게 회전값
    public float skill01_Damage;//몬스터 공격력1
    public float skill02_Damage;//몬스터 공격력2
    public float skill03_Damage;//몬스터 공격력3
    public float monster_HP;//몬스터 HP
    public float monster_MoveSpeed;//몬스터 움직이는 SPEEED;
    public float monsterSkill;//몬스터가 사용한 스킬
    public float monster_Type;//몬스터 종류구분
    public float limtP;//몬스터 체력따른변화
    public float monsterp01;
    public bool playerck;//플레이어 확인상태
    public bool monsterATing;//몬스터 공격상태
    public bool monsterRow;//원거리 몬스터공격
    public bool playerRun;//플레이어 도망감
    public GameObject playertaget;//플레이어 오브젝트 확인    
    public float pHP;//플레이어 HP 상태 확인
    public float pR;//플레이어 위치
    public CharacterController monstercon;//정규화를 윈한 컨트롤 정의
    public GameObject arow;//생성되는 투사체      
    public Rigidbody rb;//몬스터 물리력
    public float hitpow;//너백거리//변수모음
    public float i1;//limt 변수    
    public float i2;
    public float patk;
    public GameObject my;
    public float attack_Speed;//공격모션 딜레이          
    public GameObject hitboxObj;//데미지 줄수있는 범위 박스      
    public GameObject skill01IP;
    public GameObject hitEP;
    public GameObject gameManager;//게임매니저의 보스클리어 bool값 바꾸는데필요
    public bool bossClear;//보스클리어시켜라!!
    public GameObject deadEffect;
    public int StageNo;
    public GameObject gamedata;
    public float nowDamge;
    public float l1;
    public bool damgefin;
    public bool die;
    public AudioClip[] mobAttack;


    public enum ENEMYSTATE
    {
        IDLE = 0,
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD,
        boss
    }
    public ENEMYSTATE ememyState = ENEMYSTATE.IDLE;//상태 정의    

    private void Start()
    {
        StageNo = GameManagerScript.Instance()._stageValue;

        MonsterEX.Instance().LoadMonsData00(monsterno);
        MonsterEX.Instance().LoadMonsEXPData00(StageNo);

        monster_Index = MonsterEX.Instance().monster_Index;
        monster_Name = MonsterEX.Instance().monster_Name;
        monster_Type = MonsterEX.Instance().monster_Type;
        attack_Range = MonsterEX.Instance().attack_Range;
        skill01_Damage = MonsterEX.Instance().skill01_Damage;
        skill02_Damage = MonsterEX.Instance().skill02_Damage;
        skill03_Damage = MonsterEX.Instance().skill03_Damage;
        monster_MoveSpeed = MonsterEX.Instance().monster_MoveSpeed;
        rotation_Speed = MonsterEX.Instance().rotation_Speed;
        attack_Speed = MonsterEX.Instance().attack_Speed;
        monsterLV = MonsterEX.Instance().mob_LV;
        monster_HP = MonsterEX.Instance().monster_HP;
        mobExp = MonsterEX.Instance().mob_EXP;
        limtP = 50;
        playertaget = GameObject.FindGameObjectWithTag("Player");//플레이어 오브젝트 정의
        rb = GetComponent<Rigidbody>();//리지드바디 정의
        my = gameObject;
        gamedata = GameObject.Find("CharacterDatamanager");
        gameManager = GameObject.Find("GameManager");        

    }//겜 시작후 먼해야야하는것

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            BossClear();
        }
        if (die == false)
        {
            Vector3 relativePos = playertaget.transform.position - transform.position;
            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;
        }
        if (die == true)
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = gameObject.transform.position;            
        }
        switch (ememyState)
        {
            case ENEMYSTATE.IDLE://대기상태
                if (die == true)
                {
                    ememyState = ENEMYSTATE.DEAD;
                }
                GetComponent<Animator>().SetTrigger("STAE");
                GetComponent<Animator>().ResetTrigger("AT01");
                GetComponent<Animator>().ResetTrigger("HIT");
                GetComponent<Animator>().ResetTrigger("MOVE");//에니메이션 SET              
                if (playerRun == true)
                {
                    ememyState = ENEMYSTATE.IDLE;
                }
                if (playerck == true)//플레이어 발견하면 이동상태로
                {
                    ememyState = ENEMYSTATE.MOVE;
                }
                break;
            case ENEMYSTATE.MOVE://이동 상태     
                if (die == true)
                {
                    ememyState = ENEMYSTATE.DEAD;
                }
                if (i1 == 0&&die==false)
                {
                    GetComponent<Animator>().ResetTrigger("STAE");
                    GetComponent<Animator>().ResetTrigger("AT01");
                    GetComponent<Animator>().ResetTrigger("HIT");
                    GetComponent<Animator>().SetTrigger("MOVE");    //에니메이션 SET      
                    float distabce = (playertaget.transform.position - gameObject.transform.position).magnitude;//공격거리 정규화
                    if (distabce < attack_Range)//공격거리 도달시
                    {
                        ememyState = ENEMYSTATE.ATTACK;
                    }
                    if (distabce > attack_Range)
                    {
                        Moveobj();//이동함수 호출               
                    }
                    /*if (playerRun == true)//플레이어가 도망가면 조건넣자 추가상의기능구현
                         * {
                         * ememyState = ENEMYSTATE.IDLE;
                         * }*/                    
                }
                break;
            case ENEMYSTATE.ATTACK://공격하는 상태                    
                if (die == true)
                {
                    ememyState = ENEMYSTATE.DEAD;
                }
                if (playertaget.GetComponent<PlayerController>().hp > 0)
                {
                    if (monsterp01 == 0)
                    {
                        if (i1 == 0)
                        {
                            StartCoroutine(Wait02());
                            if (monster_Type == 1 || monster_Type == 3)
                            {
                                StartCoroutine(CheckAnimationState01());
                                GetComponent<Animator>().ResetTrigger("STAE");
                                GetComponent<Animator>().ResetTrigger("HIT");
                                GetComponent<Animator>().ResetTrigger("MOVE");
                                GetComponent<Animator>().SetTrigger("AT01"); //에니메이션 Set                                                                                     

                            }
                            if (monster_Type == 2)
                            {
                                StartCoroutine(CheckAnimationState04());
                                GetComponent<Animator>().SetTrigger("AT01");
                                Instantiate(arow, transform);
                                GetComponent<Animator>().ResetTrigger("STAE");
                                GetComponent<Animator>().ResetTrigger("HIT");
                                GetComponent<Animator>().ResetTrigger("MOVE");
                                //에니메이션 SET                                             
                            }
                            i1 = 1;
                        }
                        if (i1 == 1 && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
                        {
                            ememyState = ENEMYSTATE.IDLE;
                            GetComponent<Animator>().ResetTrigger("HIT");
                        }
                    }
                    if (monsterp01 == 1)
                    {
                        ememyState = ENEMYSTATE.boss;
                    }
                }
                if (playertaget.GetComponent<PlayerController>().hp <= 0)
                {
                    ememyState = ENEMYSTATE.IDLE;
                }
                    /*if (playerRun == true)//플레이어가 도망가면 조건넣자 추가상의기능구현
                  {
                      ememyState = ENEMYSTATE.IDLE;
                  }*/

                    break;
            case ENEMYSTATE.DAMAGE://데미지받은 상태                     
                if (die == true)
                {
                    ememyState = ENEMYSTATE.DEAD;
                }
                if (damgefin == true)
                {
                    ememyState = ENEMYSTATE.IDLE;
                    damgefin = false;
                }
                GetComponent<Animator>().ResetTrigger("STAE");
                GetComponent<Animator>().ResetTrigger("AT01");
                GetComponent<Animator>().ResetTrigger("MOVE");//에니메이션 SET                  
                StartCoroutine(CheckAnimationState02());
                if (monster_HP <= limtP && monster_Type == 3)
                {
                    monsterp01 = 1;
                    ememyState = ENEMYSTATE.boss;
                }              
                if (monster_HP <= 0)//몬스터 hp0 이면
                {
                    ememyState = ENEMYSTATE.DEAD;
                }
                /*if (playerRun == true)//플레이 도망확인
                {
                    ememyState = ENEMYSTATE.IDLE;
                } */
                break;
            case ENEMYSTATE.DEAD://죽은상태
                if (die == false)
                {

                    GetComponent<Animator>().ResetTrigger("STAE");
                    GetComponent<Animator>().ResetTrigger("AT01");
                    GetComponent<Animator>().ResetTrigger("HIT");
                    GetComponent<Animator>().ResetTrigger("MOVE");
                    GetComponent<Animator>().SetTrigger("DED");//에니메이션 SET
                    StartCoroutine(DeadEffectWait());
                    Destroy(gameObject, 2f);//오브젝트 사라짐
                    if (monster_Type == 1)
                    {
                        if (l1 == 0)
                        {
                            gamedata.GetComponent<CharacterDatamanager>().Exp += (mobExp * 2);
                            gamedata.GetComponent<CharacterDatamanager>().SaveEXP();
                            gameManager.GetComponent<GameManagerScript>().MobKillCnt();
                            gameManager.GetComponent<GameManagerScript>().AddGold();
                            Debug.Log("경험치 및 골드 킬카운트 실행");
                            l1 = 1;
                        }
                    }
                    if (monster_Type == 2)
                    {
                        if (l1 == 0)
                        {
                            gamedata.GetComponent<CharacterDatamanager>().Exp += (mobExp * 2);
                            gamedata.GetComponent<CharacterDatamanager>().SaveEXP();
                            gameManager.GetComponent<GameManagerScript>().MobKillCnt();
                            gameManager.GetComponent<GameManagerScript>().AddGold();
                            l1 = 1;
                        }
                        Debug.Log("경험치 및 골드 킬카운트 실행");
                    }
                    if (monster_Type == 3)
                    {
                        if (l1 == 0)
                        {
                            gamedata.GetComponent<CharacterDatamanager>().Exp += (mobExp * 2);
                            gamedata.GetComponent<CharacterDatamanager>().SaveEXP();
                            gameManager.GetComponent<GameManagerScript>().MobKillCnt();
                            gameManager.GetComponent<GameManagerScript>().AddGold();
                            Debug.Log("경험치 및 골드 킬카운트 실행");
                            BossClear();
                            l1 = 1;
                        }
                    }
                    die = true;
                }
                    break;
            case ENEMYSTATE.boss://보스 패턴 돌입                                
                if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Skill01"))
                {
                    GetComponent<Animator>().ResetTrigger("SKILL01");
                    ememyState = ENEMYSTATE.IDLE;
                }
                if (monster_HP <= 0)
                {
                  ememyState = ENEMYSTATE.DEAD;

                }
                if (i1 == 0)
                {
                    GetComponent<Animator>().SetTrigger("SKILL01");
                    GetComponent<Animator>().ResetTrigger("STAE");
                    GetComponent<Animator>().ResetTrigger("AT01");
                    GetComponent<Animator>().ResetTrigger("HIT");
                    GetComponent<Animator>().ResetTrigger("MOVE");
                    StartCoroutine(CheckAnimationState03());
                    i1 = 1;
                    StartCoroutine(Wait02());
                    playertaget.GetComponent<PlayerController>().monsterat = skill02_Damage;
                    playertaget.GetComponent<PlayerController>().Hiting();
                }
                break;
            default:
                break;
        }
    }//매프레임마다 작동 

    public void Hit()
    {
        if (die == false)
        {
            Ef1();
            GetComponent<TEXTEX>().atS = nowDamge.ToString("N0");
            GetComponent<TEXTEX>().Textadd();
            monster_HP -= nowDamge;
            ememyState = ENEMYSTATE.DAMAGE;
            HITPOW();
            GetComponent<Animator>().SetTrigger("HIT");
            StartCoroutine(Wait01());
            Debug.Log("hit적용중");
        }
    }//데미지를 받을때

    public void HITPOW()
    {
        if (hitpow == 0)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (hitpow != 0)
        {
            Vector3 a = transform.forward * -hitpow;//뒤에숫자는 플레이어 한테 받게끔
            rb.velocity = a;
            StartCoroutine(Wait01());            
        }

    }

    public void Moveobj()
    {
        if (die == false)
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = playertaget.transform.position;
        }
    }//타겟을 찾아고 타겟으로이동하라

    IEnumerator Wait01()
    {
        int i = 0;
        while (i < 1)
        {            
            yield return new WaitForSeconds(0.1f);
            rb.velocity = new Vector3(0, 0, 0);
            hitpow = 0;
            i++;
        }
    }//쿨타임

    IEnumerator Wait02()
    {
        int i = 0;
        while (i < 1)
        {
            yield return new WaitForSeconds(attack_Speed);
            i1 = 0;                       
            i++;
        }      

    }//쿨타임2

    IEnumerator DeadEffectWait()
    {
        int i = 0;
        while (i < 1)
        {
            yield return new WaitForSeconds(1.9f);

            Instantiate(deadEffect, transform.position + new Vector3(0,1f,0), transform.rotation);
            i++;
        }

    }//쿨타임2    

    IEnumerator CheckAnimationState01()
    {        
        while (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
        {//플레이어 에니메이션이 isAttack01 아닌경우 동안 무엇을할것인가?
         //전환 중일 때 실행되는 부분            
            yield return null;
        }
        while (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {//플레이어 에니메이션이 실행이 끝나는동안
         //애니메이션 재생 중 실행되는 부분            
            yield return null;
        }
        playertaget.GetComponent<PlayerController>().monsterat = skill01_Damage;
        playertaget.GetComponent<PlayerController>().Hiting();
        GetComponentInChildren<Hitbox>().Ef();
        SoundManager.Instance.RandomSoundEffect(mobAttack);
        Debug.Log("실행완료1 (기본공격 종료)");
        //애니메이션 완료 후 실행되는 부분
    }

    IEnumerator CheckAnimationState02()
    {       
        while (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Damage"))
        {//플레이어 에니메이션이 isAttack01 아닌경우 동안 무엇을할것인가?
         //전환 중일 때 실행되는 부분            
            yield return null;
        }
        while (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {//플레이어 에니메이션이 실행이 끝나는동안
         //애니메이션 재생 중 실행되는 부분            
            yield return null;
        }
        damgefin = true;
        ememyState = ENEMYSTATE.IDLE;        
        //애니메이션 완료 후 실행되는 부분
    }
    IEnumerator CheckAnimationState03()
    {
        while (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Skill01"))
        {//플레이어 에니메이션이 isAttack01 아닌경우 동안 무엇을할것인가?
         //전환 중일 때 실행되는 부분            
            yield return null;
        }
        while (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {//플레이어 에니메이션이 실행이 끝나는동안
         //애니메이션 재생 중 실행되는 부분            
            yield return null;
        }        
        GetComponentInChildren<Hitbox>().Ef();
        Instantiate(skill01IP, transform);
        SoundManager.Instance.RandomSoundEffect(mobAttack);
        ememyState = ENEMYSTATE.IDLE;
        //애니메이션 완료 후 실행되는 부분
    }
    IEnumerator CheckAnimationState04()
    {
        while (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
        {//플레이어 에니메이션이 isAttack01 아닌경우 동안 무엇을할것인가?
         //전환 중일 때 실행되는 부분            
            yield return null;
        }
        while (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {//플레이어 에니메이션이 실행이 끝나는동안
         //애니메이션 재생 중 실행되는 부분            
            yield return null;
        }      
        Debug.Log("실행완료1 (기본공격 종료)");
        //애니메이션 완료 후 실행되는 부분
    }

    public void Ef1()
    {
        Instantiate(hitEP,transform);
    }    


   public void BossClear()
   {
        bossClear = gameManager.GetComponent<GameManagerScript>().bossClear = true;
        Debug.Log("bossClear :" + bossClear);
   }
}
