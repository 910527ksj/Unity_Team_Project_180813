using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBtn_Skill01_Smash : MonoBehaviour
{

    static SkillBtn_Skill01_Smash _instance = null;
    public static SkillBtn_Skill01_Smash Instance()
    {
        return _instance;
    }//인스턴스화

    public UIProgressBar bar;
    public UILabel coolTimeCounter; //남은 쿨타임을 표시할 텍스트


    public float coolTime;

    private float currentCoolTime; //남은 쿨타임을 추적 할 변수

    private bool canUseSkill = true; //스킬을 사용할 수 있는지 확인하는 변수

    public AudioClip[] skill01;

   

    private void Awake()
    {

        coolTimeCounter.enabled = false;

    }


    void Start()
    {


        //coolTime = GameObject.Find("Skill_Bomb").GetComponent<Skill_Bomb>().coolDown;

       SkillDataManager.Instance().LoadSkillData00(0);

        coolTime = SkillDataManager.Instance().coolDown;


        Debug.Log("스매쉬 쿨다운타임 : " + coolTime);


        bar.value = 1;



    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //SkillBtn_Skill01_Smash.Instance().UseSkill01();
            //Skiil01();
            UseSkill01();
        }
    }


    public void UseSkill01()
    {
        if (canUseSkill && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isSkill01 ==false)
        {
            coolTimeCounter.enabled = true;


            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Skiil01();
            //PlayerController.Instance().Skiil01();           
            //사운드출력//
            StartCoroutine(PlaySfxRandom());
            //Debug.Log("Use Skill");
            bar.value = 0; //스킬 버튼을 가림
            StartCoroutine("Cooltime");

            currentCoolTime = coolTime;
            coolTimeCounter.text = "" + currentCoolTime;

            StartCoroutine("CoolTimeCounter");

            canUseSkill = false; //스킬을 사용하면 사용할 수 없는 상태로 바꿈
        }
        else
        {
            Debug.Log("아직 스킬을 사용할 수 없습니다.");
        }
    }

    IEnumerator Cooltime()
    {
        while (bar.value < 1)
        {
            // bar.value -= 1 * Time.smoothDeltaTime / coolTime;
            bar.value += 1 * Time.deltaTime / coolTime;

            yield return null;
        }

        canUseSkill = true; //스킬 쿨타임이 끝나면 스킬을 사용할 수 있는 상태로 바꿈
        coolTimeCounter.enabled = false;
        yield break;
    }

    //남은 쿨타임을 계산할 코르틴을 만듬.
    IEnumerator CoolTimeCounter()
    {
        while (currentCoolTime > 0)
        {
            yield return new WaitForSeconds(1.0f);

            currentCoolTime -= 1.0f;
            coolTimeCounter.text = "" + currentCoolTime;
        }

        yield break;
    }




    IEnumerator PlaySfxRandom()
    {


        yield return new WaitForSeconds(0.3f);

        SoundManager.Instance.RandomSoundEffect(skill01);



    }
}