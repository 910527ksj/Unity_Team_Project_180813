using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using InControl;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    static PlayerController _instance = null;
    public static PlayerController Instance()
    {
        return _instance;
    }//인스턴스화
    public enum PLAYERSTATES
    {
        IDLE02 = 0,
        RUN,
        ATTACK01,
        ATTACK02,
        ATTACK03,
        DAMAGE,
        DIE,
        STUN,
        SKILL01,
        SKILL02,
        SKILL03,
        CHEER,
        IDLE01,
        WALK,
    }//상태정의
    public PLAYERSTATES playerstate;//상태
    float exitTime = 0.5f;//에니메이션 끝나는 변수 정의
    //MyCharacterActions characterActions;
    public GameObject playerObj;//플레이어 오브젝트
    public CharacterController CharacterController;//플레이어 콘트롤
    public Animator playercharacter;//플레이어 에니메이션 콘트롤
    private Vector3 _moveVector; //플레이어 이동벡터 
    private Transform _transform;//위치값
    public int index;
    public string chr_Name_kr;
    public string chr_Name;
    public float move_Speed;//이동속도
    public float hp;//플레이어 HP
    public float mp;//플레이어 mp
    public float at;//플레이어 공격력
    public float df;//플레이어 방어력
    public float item01;//플레이어 소모 착용아이템
    public float combo;//기본공격 콤보 확인 변수
    public bool atingP;//공격중이니?
    public GameObject hitbox;//히트박스오브젝트
    public GameObject hitdtagetp;//누가대상이니?
    public float limtat;
    Rigidbody rb;
    public float monsterat;
    public float i1;//딜레이 이프값
    public float forwardForceSkill02;
    public float forwardForceSkill03;
    public float UpForceSkill03;
    public float attack_Range;

    public bool isSkill01 = false;
    public bool isSkillUse = false;
    public bool isRun;
    public bool at01;
    public bool isAttackMove = false;
    public bool isAttackMove01 = false;
    public bool isDead;

    public float h;
    public float v;
    public GameObject atObj01;
    public GameObject atObj02;
    public GameObject atObj03;
    public GameObject skill01Obj;
    public GameObject skill02Obj;
    public GameObject skill03Obj;
   
    public GameObject autotarget;
    public bool auto;
    public float MaxPlayerHP;
    public UISlider playerHPBar;
    public UILabel Playerhp;
    public GameObject gameManager;
    public GameObject textL;
    public float pExp; //현재경험치(경험치바용)
    public float pMaxExp; //최대경험치

    public AudioClip[] swSwing;
    public AudioClip[] attackVoice;
    public AudioClip[] deadVoice;
    public AudioClip[] skillVoice;
    public float playerEXP;
    public bool onetime = false;
   


     //public GameObject skill01Effect;
     //public GameObject skill02Effect;
     //public List<GameObject> mons = new List<GameObject>();
     void Start()
    {
        /////////////////////////////////캐릭터 액션/////////////////////////////////////////
        //characterActions = new MyCharacterActions();
        //characterActions.Left.AddDefaultBinding(Key.LeftArrow);
        //characterActions.Left.AddDefaultBinding(InputControlType.DPadLeft);
        //characterActions.Right.AddDefaultBinding(Key.RightArrow);
        //characterActions.Right.AddDefaultBinding(InputControlType.DPadRight);
        //characterActions.Attack.AddDefaultBinding(Key.Space);
        //characterActions.Attack.AddDefaultBinding(InputControlType.Action1);
        /////////////////////////////////캐릭터 액션/////////////////////////////////////////
        rb = GetComponent<Rigidbody>();
        playercharacter = GetComponent<Animator>();
        CharacterController = GetComponent<CharacterController>();
        //조이스틱 관련//
        _transform = transform;//Transform 캐싱 
        _moveVector = Vector3.zero;//플레이어 이동벡터 초기화 
        //조이스틱 관련//
        //Debug.Log("조이스틱 이동속도 : " + move_Speed);    

        index = GameManagerScript.Instance().index;
        chr_Name_kr = GameManagerScript.Instance().chr_Name_kr;
        chr_Name = GameManagerScript.Instance().chr_Name;
        hp = GameManagerScript.Instance().hp;
        mp = GameManagerScript.Instance().mp;
        at = GameManagerScript.Instance().atk;
        df = GameManagerScript.Instance().def;       
        move_Speed = GameManagerScript.Instance().movementSpeed;
        GameObject pAT=GameObject.Find("AtackBtn");
        pAT.GetComponent<UIButton>().onClick.Add(new EventDelegate(Atbut));        
        playerHPBar = GameObject.Find("Player_HP_Bar").GetComponent<UISlider>();
        Playerhp = GameObject.Find("PlayerHP_Txt").GetComponent<UILabel>();
        MaxPlayerHP = hp;
        gameManager = GameObject.Find("GameManager");
        

    }


    void Update()
    {
       

        if (hp <= 0)
        {
            
            playerstate = PLAYERSTATES.DIE;
                     
                                          
        }
        if (hp <= 0)
        {
            hp = 0;
        }
              
        //몬스터 hp바 코드 가져옴//
        if (MaxPlayerHP <= hp)
        {
            playerHPBar.GetComponent<UIProgressBar>().value = 1;
        }
        if (MaxPlayerHP > hp)
        {
            float _hp;
            _hp = hp / MaxPlayerHP;
            playerHPBar.GetComponent<UIProgressBar>().value = _hp;
        }

        Playerhp.text = "" + hp + "/" + MaxPlayerHP;



        //몬스터 hp바 코드 가져옴//

        HandleInput();
        //Debug.Log("H" + h);
        //Debug.Log("V" + v);                 
        //CharacterAction();  
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

        }
        //======================================= 스킬 시전 키 입력 시작============================================//
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //SkillBtn_Skill01_Smash.Instance().UseSkill01();
            //Skiil01();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //SkillBtn_Skill02_RageDash.Instance().UseSkill02();
            //Skiil02();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //SkillBtn_Skill03_GroundBang.Instance().UseSkill03();
            //Skiil03();
        }




        if (Input.GetKeyDown(KeyCode.F1))
        {
            UserHPPotion();
        }
        //if (Input.GetKeyDown(KeyCode.F2))
        //{
        //    UserMPPotion();
        //}


        //=======================================스킬 시전 키 입력 끝============================================//
        //======================================캐릭터 스테이트 시작===================================================//
        switch (playerstate)
        {
            case PLAYERSTATES.IDLE02:
                if (Input.GetKeyDown(KeyCode.Space))//공격키를 입력시
                {
                    Atbut();
                }
                AutoPlayer();
                //Debug.Log("idle상태전환");

                break;
            case PLAYERSTATES.RUN:
                transform.Translate(0, 0, move_Speed * Time.deltaTime);
                if (h == 0 && v == 0)
                {
                    playercharacter.SetBool("isRun", false);
                    playerstate = PLAYERSTATES.IDLE02;
                }
                //Debug.Log("Run상태전환");

                break;
            case PLAYERSTATES.ATTACK01:
                AutoPlayer();
                playercharacter.SetBool("isAttack01", true);
                break;
            case PLAYERSTATES.ATTACK02:
                AutoPlayer();
                playercharacter.SetBool("isAttack02", true);
                break;
            case PLAYERSTATES.ATTACK03:
                AutoPlayer();
                playercharacter.SetBool("isAttack03", true);
                break;
            case PLAYERSTATES.DAMAGE:
                playercharacter.SetBool("HITP", false);
                break;
            case PLAYERSTATES.DIE:
                playercharacter.SetBool("isDead", true);
                if (!onetime)
                {
                    StartCoroutine(PlaySfxRandomDeadVoice());
                    onetime = true;
                }
                GameOVer();
                break;
            case PLAYERSTATES.STUN:
                break;
            case PLAYERSTATES.SKILL01:
                playercharacter.SetBool("isSkill01", true);
                //Debug.Log("Skill01상태전환");
                break;
            case PLAYERSTATES.SKILL02:
                playercharacter.SetBool("isSkill02", true);
                //Debug.Log("Skill02상태전환");
               
                break;
            case PLAYERSTATES.SKILL03:
                playercharacter.SetBool("isSkill03", true);
                //Debug.Log("Skill03상태전환");
                StartCoroutine(WaitskillSecondsSkill03());
                break;
            case PLAYERSTATES.CHEER:
                break;
            case PLAYERSTATES.IDLE01:
                break;
            case PLAYERSTATES.WALK:
                break;
            default:
                break;
        }
        //======================================캐릭터 스테이트 끝===================================================//
    }
    //=============================================캐릭터 이동 관련 시작================================================//
    public void HandleInput()
    {
        _moveVector = PoolInput();
    }//조이스틱 정의
    public Vector3 PoolInput()
    {
        var InputDevice = InputManager.ActiveDevice;
        h = InputDevice.LeftStickX;
        v = InputDevice.LeftStickY;
        var input = new Vector3(InputDevice.LeftStickX, 0, InputDevice.LeftStickY);
        if (input != Vector3.zero)
        {
            transform.forward = input;
            playerstate = PLAYERSTATES.RUN;
            playercharacter.SetBool("isRun", true);
        }
        if (playercharacter.GetCurrentAnimatorStateInfo(0).IsName("ATTACK01"))
        {
            playercharacter.SetBool("isRun", false);
            playerstate = PLAYERSTATES.IDLE02;
        }
        if (playercharacter.GetCurrentAnimatorStateInfo(0).IsName("ATTACK02"))
        {
            playercharacter.SetBool("isRun", false);
            playerstate = PLAYERSTATES.IDLE02;
        }
        if (playercharacter.GetCurrentAnimatorStateInfo(0).IsName("ATTACK03"))
        {
            playercharacter.SetBool("isRun", false);
            playerstate = PLAYERSTATES.IDLE02;
        }
        if (playercharacter.GetCurrentAnimatorStateInfo(0).IsName("SKILL01"))
        {
            playercharacter.SetBool("isRun", false);
            playerstate = PLAYERSTATES.IDLE02;
        }
        if (playercharacter.GetCurrentAnimatorStateInfo(0).IsName("SKILL02"))
        {
            playercharacter.SetBool("isRun", false);
            playerstate = PLAYERSTATES.IDLE02;
        }
        if (playercharacter.GetCurrentAnimatorStateInfo(0).IsName("SKILL03"))
        {
            playercharacter.SetBool("isRun", false);
            playerstate = PLAYERSTATES.IDLE02;
        }
        if (playercharacter.GetCurrentAnimatorStateInfo(0).IsName("DIE"))
        {
            playercharacter.SetBool("isRun", false);
            playerstate = PLAYERSTATES.IDLE02;
        }

        Vector3 moveDir = new Vector3(h, 0, v).normalized;
        return moveDir;
    }
    //=============================================캐릭터 이동 관련 끝================================================//
    public void CharacterAction()
    {
        /*
         *var InputDevice = InputManager.ActiveDevice;
         * Debug.Log(InputDevice.Action1);
         * if (Input.GetKeyDown(KeyCode.Space))
         * {
         * playercharacter.SetBool("isAttack01", true);
         * }
         * else
         * {
         * playercharacter.SetBool("isAttack01", false);
         * }*/
        }//에이메이션실행 예시문
    IEnumerator CheckAnimationState01()
    {
        i1 = 2;
        while (playercharacter.GetCurrentAnimatorStateInfo(0).IsName("isAttack01"))
        {//플레이어 에니메이션이 isAttack01 아닌경우 동안 무엇을할것인가? 
            //전환 중일 때 실행되는 부분             
            yield return null;
        }
        while (playercharacter.GetCurrentAnimatorStateInfo(0).normalizedTime < exitTime)
        {//플레이어 에니메이션이 실행이 끝나는동안 
            //애니메이션 재생 중 실행되는 부분             
            yield return null;
        }
        atObj01.GetComponent<Playerhitbox>().Hitmonster();       
        Debug.Log("실행완료1 (기본공격 종료)");
        //애니메이션 완료 후 실행되는 부분 
    }//에니메이션실행중일때 예시문 
    IEnumerator CheckAnimationState02()
    {
        i1 = 3;
        while (playercharacter.GetCurrentAnimatorStateInfo(0).IsName("isAttack01"))
        {//플레이어 에니메이션이 isAttack01 아닌경우 동안 무엇을할것인가? 
            //전환 중일 때 실행되는 부분             
            yield return null;
        }
        while (playercharacter.GetCurrentAnimatorStateInfo(0).normalizedTime < exitTime)
        {//플레이어 에니메이션이 실행이 끝나는동안 
            //애니메이션 재생 중 실행되는 부분            
            yield return null;
        }        
        atObj02.GetComponent<Playerhitbox>().Hitmonster();
        Debug.Log("실행완료2 (기본공격 종료)");       
        //애니메이션 완료 후 실행되는 부분 
    }//에니메이션실행중일때 예시문 

    IEnumerator CheckAnimationState03()
    {
        i1 = 1;
        while (playercharacter.GetCurrentAnimatorStateInfo(0).IsName("isAttack01"))
        {//플레이어 에니메이션이 isAttack01 아닌경우 동안 무엇을할것인가? 
            //전환 중일 때 실행되는 부분             
            yield return null;
        }
        while (playercharacter.GetCurrentAnimatorStateInfo(0).normalizedTime < exitTime)
        {//플레이어 에니메이션이 실행이 끝나는동안 
            //애니메이션 재생 중 실행되는 부분            
            yield return null;
        }       
        atObj03.GetComponent<Playerhitbox>().Hitmonster();       
        Debug.Log("실행완료3 (기본공격 종료)");
        //애니메이션 완료 후 실행되는 부분 
    }
    //=================================================차지에니메이션 대기=====================================//    

    IEnumerator WaitAttack01()
    {
        atObj01.GetComponent<Playerhitbox>().Ef();
        int i = 0;
        while (i < 1)
        {
            SoundManager.Instance.RandomSoundEffect(swSwing);
            SoundManager.Instance.RandomSoundEffect(attackVoice);
            yield return new WaitForSeconds(0.5f);
            atObj01.SetActive(true);                                     
            yield return new WaitForSeconds(0.5f);
            playercharacter.SetBool("isAttack01", false);
            yield return new WaitForSeconds(0);
            atObj01.SetActive(false);
            i1 = 0;
            i++;            
        }
    }//콤보1코루틴  

    IEnumerator WaitAttack02()
    {
        atObj02.GetComponent<Playerhitbox>().Ef();
        int i = 0;
        while (i < 1)
        {
            SoundManager.Instance.RandomSoundEffect(swSwing);
            //SoundManager.Instance.RandomSoundEffect(attackVoice);
            yield return new WaitForSeconds(0.3f);
            atObj02.SetActive(true);                               
            yield return new WaitForSeconds(0.3f);
            playercharacter.SetBool("isAttack02", false);
            yield return new WaitForSeconds(0);
            atObj02.SetActive(false);
            i1 = 0;
            i++;            
        }
    }//콤보2코루틴  
    IEnumerator WaitAttack03()
    {
        atObj03.GetComponent<Playerhitbox>().Ef();
        int i = 0;
        while (i < 1)
        {
            SoundManager.Instance.RandomSoundEffect(swSwing);
            //SoundManager.Instance.RandomSoundEffect(attackVoice);
            yield return new WaitForSeconds(0.2f);
            atObj03.SetActive(true);           
            yield return new WaitForSeconds(0.2f);
            playercharacter.SetBool("isAttack03", false);
            yield return new WaitForSeconds(0);
            atObj03.SetActive(false);           
            i1 = 0;
            i++;
        }
    }//콤보3코루틴 

    public void Atbut()
    {
        if (i1 == 0)
        {
            if (playercharacter.GetCurrentAnimatorStateInfo(0).IsName("IDLE02"))
            {
                StartCoroutine(CheckAnimationState01());
                playerstate = PLAYERSTATES.ATTACK01;
                Debug.Log("어택01");
                StartCoroutine(WaitAttack01());//공격하는동안                                  
            }
        }
        if (i1 == 2)
        {
            if (playercharacter.GetCurrentAnimatorStateInfo(0).IsName("ATTACK01"))
            {
                StartCoroutine(CheckAnimationState02());
                playercharacter.SetBool("isAttack02", true);
                playerstate = PLAYERSTATES.ATTACK02;
                Debug.Log("어택02");
                StartCoroutine(WaitAttack02());
            }
        }
        if (i1 == 3)
        {
            if (playercharacter.GetCurrentAnimatorStateInfo(0).IsName("ATTACK02"))
            {
                StartCoroutine(CheckAnimationState03());
                playercharacter.SetBool("isAttack03", true);
                playerstate = PLAYERSTATES.ATTACK03;
                Debug.Log("어택03");
                StartCoroutine(WaitAttack03());
            }//기본공격 버튼3      
        }                                    
    }
    //=========================================================스킬 시전 시작====================================//
    public void Skiil01()
    {
        if (isSkill01 == false)
        {
           
            playerstate = PLAYERSTATES.SKILL01;
            playercharacter.SetBool("isSkill01", true);
            StartCoroutine(Waitskill01());
            Debug.Log(playerstate);
            isSkill01 = true;
            //Debug.Log("스킬01");
            Debug.Log("isSkill01 : " + isSkill01);
        }
           
    }
    public void Skiil02()
    {
        if (isSkill01 == false)
        {
           
            playerstate = PLAYERSTATES.SKILL02;
            StartCoroutine(WaitskillSecondsSkill02());
            playercharacter.SetBool("isSkill02", true);
            StartCoroutine(Waitskill02());
            isSkill01 = true;
            //Debug.Log(playerstate);
            //Debug.Log("스킬02");
            Debug.Log("isSkill01 : " + isSkill01);
        }

    }//스킬공격 버튼2
    public void Skiil03()
    {
        if (isSkill01 == false)
        {
         
            playerstate = PLAYERSTATES.SKILL03;
            StartCoroutine(WaitskillSecondsSkill03());
            playercharacter.SetBool("isSkill03", true);
            StartCoroutine(Waitskill03());
            isSkill01 = true;
            //Debug.Log(playerstate);
            //Debug.Log("스킬03");
            Debug.Log("isSkill01 : " + isSkill01);
        }

    }//스킬공격 버튼3
    IEnumerator Waitskill01()
    {
        int i = 0;
        while (i < 1)
        {
            SoundManager.Instance.RandomSoundEffect(skillVoice);
            yield return new WaitForSeconds(0.4f);
            skill01Obj.SetActive(true);
            move_Speed = 0;
            yield return new WaitForSeconds(0.2f);
            playercharacter.SetBool("isSkill01", false);
            move_Speed = 5;
            yield return new WaitForSeconds(0.0f);
            skill01Obj.SetActive(false);
            StartCoroutine(WaitIsskill());
            
            i++;
        }
    }
    IEnumerator Waitskill02()
    {
        int i = 0;
        while (i < 1)
        {
            SoundManager.Instance.RandomSoundEffect(skillVoice);
            yield return new WaitForSeconds(0.4f);
            skill02Obj.SetActive(true);
            move_Speed = 0;
            yield return new WaitForSeconds(0.4f);
            playercharacter.SetBool("isSkill02", false);
            move_Speed = 5;
            yield return new WaitForSeconds(0.0f);
            skill02Obj.SetActive(false);
            StartCoroutine(WaitIsskill());

            i++;
        }
    }
    IEnumerator Waitskill03()
    {
        int i = 0;
        while (i < 1)
        {
            move_Speed = 0;
            SoundManager.Instance.RandomSoundEffect(skillVoice);
            yield return new WaitForSeconds(0.8f);
            skill03Obj.SetActive(true);
           
            //skill03Obj.GetComponent<BoxCollider>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            playercharacter.SetBool("isSkill03", false);
            move_Speed = 5;
            yield return new WaitForSeconds(0.0f);
            skill03Obj.SetActive(false);
            StartCoroutine(WaitIsskill());

            i++;
        }
    }
    IEnumerator WaitskillSecondsSkill02()
    {
        int i = 0;
        while (i < 1)
        {
            yield return new WaitForSeconds(0.4f);
            rb.AddForce(transform.forward * forwardForceSkill02, ForceMode.Impulse);
            rb.velocity = new Vector3(0, 0, 0);
            i++;
        }
    }
    IEnumerator WaitskillSecondsSkill03()
    {
        int i = 0;
        while (i < 1)
        {
            yield return new WaitForSeconds(0.2f);
            rb.AddForce(transform.forward * forwardForceSkill03, ForceMode.Impulse);
            rb.velocity = new Vector3(0, 0, 0);
            i++;
        }
    }
    IEnumerator WaitIsskill()
    {
        int i = 0;
        while (i < 1)
        {
            yield return new WaitForSeconds(0.8f);
            isSkill01 = false;
            //Debug.Log("isSkill01 : " + isSkill01);
            i++;
        }
    }

    public void GameOVer()
    {
        isDead = gameManager.GetComponent<GameManagerScript>().isGameover = true;

        // Debug.Log("GameOver :" + isDead);
    }

    IEnumerator PlaySfxRandomAttackVoice()
    {
        yield return new WaitForSeconds(0.0f);
        SoundManager.Instance.RandomSoundEffect(attackVoice);
    }

    IEnumerator PlaySfxRandomDeadVoice()
    {
        int i = 0;
        while (i < 1)
        {
            yield return new WaitForSeconds(0.0f);
            SoundManager.Instance.RandomSoundEffect(deadVoice);
            
            i++;
           
        }

        
        
    }

    public void UserHPPotion()
    {
        if(hp < MaxPlayerHP)
        {
           
            hp += 50;
            CharacterDatamanager.Instance().SaveHpPotion();


        }
        if(hp >= MaxPlayerHP)
        {
            hp = MaxPlayerHP;
            Debug.Log("물약을 사용할 수 없습니다.");
           
        }
      
    }

    //public void UserMPPotion()
    //{
    //    if (mp < MaxPlayerMP)
    //    {
    //        mp += 50;
    //        CharacterDatamanager.Instance().SaveMpPotion();
    //    }

    //}


    //=======================================================스킬 시전 끝====================================//
    public void AutoPlayer()
    {
        if (auto == true)
        {

            if (autotarget != null)
            {
                MONSTERAI02 ack = autotarget.GetComponent<MONSTERAI02>();
                if (ack != null)
                {
                    if (ack.die == true)
                    {
                        autotarget = null;
                    }
                    if (ack.die == false)
                    {
                        Vector3 relativePos = autotarget.transform.position - transform.position;
                        // the second argument, upwards, defaults to Vector3.up
                        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                        transform.rotation = rotation;
                        /*float distabce = (autotarget.transform.position - gameObject.transform.position).magnitude;//공격거리 정규화                
                        if (distabce > attack_Range)
                        {
                            //Moveobj();//이동함수 호출               
                        }*/
                    }
                }
                if (ack == null)
                {
                    Debug.Log("찾지 못햇습니다");
                }
            }
            if (autotarget == null)
            {
                auto = false;
            }
        }
        if (autotarget == null)
        {
            auto = false;
        }

    }
    public void Hiting()
    {       
        hp -= monsterat;
        GetComponent<TEXTPLAYER>().Textadd();
        /*if (atingP != true)
         * {
         * /*playercharacter.SetBool("HITP", true);
         * /*StartCoroutine(Wait01());
         * //playerstate = PLAYERSTATES.DAMAGE;      
         * }*/
    }
    /*public void Moveobj()
    {             
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        agent.destination = autotarget.transform.position;
        agent.enabled = true;
    }*///타겟을 찾아고 타겟으로이동하라

    //public void AttackMove()
    //{
    //    playerObj.transform.Translate(Vector3.forward *1.5f* move_Speed *  Time.deltaTime);
    //}

}
