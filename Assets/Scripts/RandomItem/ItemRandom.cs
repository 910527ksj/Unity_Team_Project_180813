using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
//백슬기
public class ItemRandom : MonoBehaviour
{
    static ItemRandom _instance = null;
    public static ItemRandom Instance()
    {
        return _instance;
    }

    public bool RandomStart; //최적화를 위한 랜덤 중복 방지
    public int playerLV; //플레이어 레벨

    //**
    public List<TextAsset> ItemTable; //무기, 방어구 같은 대분류 테이블 파일 리스트
    public TextAsset OptionTable; //옵션 테이블 파일
    //**

    public int SelectTableNum; //랜덤으로 선택된 대분류 테이블 번호
    public int ItemLevelRange = 5; //랜덤으로 등장할 아이템 레벨의 범위
    public int ItemDataKey;

    //**
    public bool InvenMargin; //인벤토리에 여유공간이 있으면 true, 없으면 false
    public string ItemName; //아이템 이름
    public string GradeName; //아이템 등급명
    public int ItemRequestLevel; //아이템 착용 요구레벨
    public int ItemBuffCreateMin; //아이템의 최소공격력(방어구일 경우엔 이게 방어력)
    public int ItemBuffCreateMax; //아이템의 최대공격력
    public string ItemPre; //아이템의 접두사
    public string ItemSuf; //아이템의 접미사
    public List<string> OptionName; //옵션 이름
    public List<int> OptionBuffMin; //옵션의 최소수치
    public List<int> OptionBuffMax; //옵션의 최대수치
    //**

    public int OptionCount; //아이템에 붙일 옵션의 갯수
    public string ItemCategory; //아이템 카테고리명
    public int ItemLevel; //아이템 레벨
    public List<int> RandomItemNum; //1차 조건에 부합하는 아이템 목록
    public List<int> OptionNum; //1차 조건에 부합하는 옵션 번호
    public List<int> FinalOpt; //최종 출력될 옵션 번호
    public List<int> FinalOptGroup; //최종 출력될 옵션 번호의 그룹 번호
    public List<int> PreFinalOpt; //최종 옵션의 접두사들
    public List<int> SufFinalOpt; //최종 옵션의 접미사들
    public int FinalGroupCountUp = 0; //옵션 그룹 중복 방지용 세부 조건 변수

    void Start()
    {
        if (_instance == null)
            _instance = this;

        playerLV = PlayerPrefs.GetInt("playerLV", 1); //가져올 플레이어 레벨이 없으면 기본값은 1
        RandomStart = true; //상자 사용하기 버튼을 눌렀음  
        IventoryMargin();
    }

    void IventoryMargin() //인벤토리에 여유 공간이 있는지 체크
    {
        if (InvenMargin == true)
        {
            ItemGrade(); // 아이템의 등급과 붙일 옵션 갯수 결정하기
            LoadItemTable(); // 아이템 대분류 테이블 랜덤으로 가져오기
        }
        else
        {
            //인벤토리에 여유공간이 없습니다. 인벤토리를 비워주세요. 라는 메시지창 출력
        }
    }

    public void ItemGrade() //아이템의 등급과 붙일 옵션 갯수 결정
    {
        int GradeProba = Random.Range(0, 1000);

        if (0 <= GradeProba && GradeProba < 800)
        {
            GradeName = "Normal";
            OptionCount = 1;
        }
        if (800 <= GradeProba && GradeProba < 950)
        {
            GradeName = "Magic";
            OptionCount = Random.Range(2, 5);
        }
        if (950 <= GradeProba && GradeProba < 999)
        {
            GradeName = "Rare";
            OptionCount = Random.Range(5, 8);
        }
        if (999 <= GradeProba && GradeProba < 1000)
        {
            GradeName = "Legendary";
            OptionCount = 8;
        }
    }

    public void LoadItemTable() //아이템 대분류 테이블 가져오기
    {
        int ItemTableMax = ItemTable.Count;
        SelectTableNum = Random.Range(0, ItemTableMax);

        HighLVItemSearch();
    }

    void HighLVItemSearch() //테이블 안에서 플레이어 레벨과 동일한 레벨의 아이템 검색하고 없으면 위에 있는 아이템 검색
    {
        var ItemData = JSON.Parse(ItemTable[SelectTableNum].text);

        for (int j = 0; j < playerLV + ItemLevelRange; j++)
        {
            for (int i = 0; i < ItemData.Count; i++)
            {
                if (ItemData[i]["ItemLevel"] == playerLV + j)
                {
                    RandomItemNum.Add(ItemData[i]["ItemDataKey"]);
                }
            }
            if (RandomItemNum.Count != 0)
                break;
        }

        if (RandomItemNum.Count == 0)
            LowLVItemSearch();

        if (RandomItemNum.Count > 0)
            SelectItem();
    }

    void LowLVItemSearch() //플레이어 레벨과 같거나 높은 아이템이 테이블에 없다면 낮은거 전부 검색
    {
        var ItemData = JSON.Parse(ItemTable[SelectTableNum].text);

        for (int j = -1; j < playerLV - ItemLevelRange; j--)
        {
            for (int i = 0; i < ItemData.Count; i++)
            {
                if (ItemData[i]["ItemLevel"] == playerLV + j)
                {
                    RandomItemNum.Add(ItemData[i]["ItemDataKey"]);
                }
            }
            if (RandomItemNum.Count != 0)
                break;
        }

        if (RandomItemNum.Count > 0)
            SelectItem();
    }

    void SelectItem() //아이템 1개 골라내서 요구레벨, 최소공격력, 최대공격력 랜덤 돌리기
    {
        //위에서 검색한 아이템들 랜덤 돌려서 1개만 골라내기
        int RandomNum = Random.Range(0, RandomItemNum.Count);
        ItemDataKey = RandomItemNum[RandomNum];
        RandomItemNum.Clear();

        //골라낸 아이템에 수치들 랜덤 돌려서 붙이기
        var ItemData = JSON.Parse(ItemTable[SelectTableNum].text);
        for (int i = 0; i < ItemData.Count; i++)
        {
            if (ItemData[i]["ItemDataKey"] == ItemDataKey)
            {
                ItemName = ItemData[i]["ItemName"];
                ItemLevel = ItemData[i]["ItemLevel"];
                ItemCategory = ItemData[i]["ItemCategory"]; // 카테고리명을 기준으로 옵션 돌릴 것
                ItemRequestLevel = Random.Range(ItemData[i]["ItemRequestLevelMin"], ItemData[i]["ItemRequestLevelMax"] + 1);
                ItemBuffCreateMin = Random.Range(ItemData[i]["ItemBuffCreateMinMin[0]"], ItemData[i]["ItemBuffCreateMinMax[0]"] + 1);
                ItemBuffCreateMax = Random.Range(ItemData[i]["ItemBuffCreateMaxMin[0]"], ItemData[i]["ItemBuffCreateMaxMax[0]"] + 1);
            }
        }

        OptionSearch();
    }

    void OptionSearch() //아이템 카테고리와 착용레벨 기준으로 옵션 검색
    {
        var OptionData = JSON.Parse(OptionTable.text);

        for (int i = 0; i < OptionData.Count; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                string ItemCategoryStr = "ItemCategoryDatas[" + j + "]";

                if (ItemCategory == OptionData[i][ItemCategoryStr])
                {
                    if (OptionData[i]["ItemLevelRestrictSt"] <= ItemLevel && ItemLevel <= OptionData[i]["ItemLevelRestrictEd"])
                    {
                        OptionNum.Add(OptionData[i]["ItemAffixeDataKey"]);
                    }
                }
            }
        }

        OptionSelect();
    }

    void OptionSelect() //등급마다 정해진 수 만큼 옵션 랜덤 돌려서 최종 옵션 뽑아내기
    {
        var OptionData = JSON.Parse(OptionTable.text);

        if (OptionNum.Count >= OptionCount)
        {
            for (int j = 0; j < OptionNum.Count; j++)
            {
                for (int i = 0; i < OptionData.Count; i++)
                {
                    if (OptionData[i]["ItemAffixeDataKey"] == OptionNum[j])
                    {
                        int optGroupNum = OptionData[i]["ItemAffixGroup"];
                        bool optGroup = FinalOptGroup.Contains(optGroupNum);
                        if (optGroup == false)
                        {
                            FinalOptGroup.Add(optGroupNum);

                            if (FinalOptGroup.Count >= OptionCount)
                                FinalGroupCountUp = 1;

                            if (FinalOptGroup.Count < OptionCount)
                                FinalGroupCountUp = 2;
                        }
                    }
                }
            }
            FinalOptGroup.Clear();

            if (FinalGroupCountUp == 1)
            {
                while (true)
                {
                    int FinalOption = Random.Range(0, OptionNum.Count);

                    for (int i = 0; i < OptionData.Count; i++)
                    {
                        if (OptionData[i]["ItemAffixeDataKey"] == OptionNum[FinalOption])
                        {
                            int optGroupNum = OptionData[i]["ItemAffixGroup"];
                            bool optGroup = FinalOptGroup.Contains(optGroupNum);
                            if (optGroup == false)
                            {
                                FinalOpt.Add(OptionNum[FinalOption]);
                                FinalOptGroup.Add(optGroupNum);
                            }
                        }
                    }

                    if (FinalOpt.Count == OptionCount)
                    {
                        break;
                    }
                }
            }

            if (FinalGroupCountUp == 2)
            {
                while (true)
                {
                    int FinalOption = Random.Range(0, OptionNum.Count);

                    for (int i = 0; i < OptionData.Count; i++)
                    {
                        if (OptionData[i]["ItemAffixeDataKey"] == OptionNum[FinalOption])
                        {
                            int optGroupNum = OptionData[i]["ItemAffixGroup"];
                            bool optGroup = FinalOptGroup.Contains(optGroupNum);
                            if (optGroup == false)
                            {
                                FinalOpt.Add(OptionNum[FinalOption]);
                                FinalOptGroup.Add(optGroupNum);
                            }
                        }
                    }

                    if (FinalOpt.Count == FinalOptGroup.Count)
                    {
                        break;
                    }
                }
            }
        }

        if (OptionNum.Count < OptionCount)
        {
            while (true)
            {
                int FinalOption = Random.Range(0, OptionNum.Count);

                for (int i = 0; i < OptionData.Count; i++)
                {
                    if (OptionData[i]["ItemAffixeDataKey"] == OptionNum[FinalOption])
                    {
                        int optGroupNum = OptionData[i]["ItemAffixGroup"];
                        bool optGroup = FinalOptGroup.Contains(optGroupNum);
                        if (optGroup == false)
                        {
                            FinalOpt.Add(OptionNum[FinalOption]);
                            FinalOptGroup.Add(optGroupNum);
                        }
                    }
                }

                if (FinalOpt.Count == FinalOptGroup.Count)
                {
                    break;
                }
            }
        }

        OptionNum.Clear();

        FinalOption();
        PreOrSuf();

        FinalOpt.Clear();
        FinalOptGroup.Clear();

        RandomStart = false;
    }

    void FinalOption() //최종 옵션에서 능력치 뽑아오기
    {
        var OptionData = JSON.Parse(OptionTable.text);

        for (int i = 0; i < OptionData.Count; i++)
        {
            for (int j = 0; j < FinalOpt.Count; j++)
            {
                if (OptionData[i]["ItemAffixeDataKey"] == FinalOpt[j])
                {
                    OptionName.Add(OptionData[i]["BuffData[0]"]);

                    int BuffMin = Random.Range(OptionData[i]["BuffCreateMinMin[0]"], OptionData[i]["BuffCreateMinMax[0]"]);
                    int BuffMax = Random.Range(OptionData[i]["BuffCreateMaxMin[0]"], OptionData[i]["BuffCreateMaxMax[0]"]);

                    OptionBuffMin.Add(BuffMin);
                    OptionBuffMax.Add(BuffMax);
                }
            }
        }
    }

    void PreOrSuf() //최종 옵션에서 접두사와 접미사로 각각 분류
    {
        var OptionData = JSON.Parse(OptionTable.text);

        for (int i = 0; i < OptionData.Count; i++)
        {
            for (int j = 0; j < FinalOpt.Count; j++)
            {
                if (OptionData[i]["ItemAffixeDataKey"] == FinalOpt[j])
                {
                    string Pref = "ITEM_AFFIX_PREFIX";
                    string Suff = "ITEM_AFFIX_SUFFIX";
                    if (OptionData[i]["AffixType"] == Pref)
                    {
                        PreFinalOpt.Add(FinalOpt[j]);
                    }
                    if (OptionData[i]["AffixType"] == Suff)
                    {
                        SufFinalOpt.Add(FinalOpt[j]);
                    }
                }
            }
        }

        if (PreFinalOpt.Count > 0)
        {
            PreSelect();
            PreFinalOpt.Clear();
        }

        if (SufFinalOpt.Count > 0)
        {
            SufSelect();
            SufFinalOpt.Clear();
        }
    }

    void PreSelect() //옵션 최대레벨이 가장 높은 접두사를 가져오기
    {
        var OptionData = JSON.Parse(OptionTable.text);

        for (int i = 0; i < OptionData.Count; i++)
        {
            for (int j = 0; j < PreFinalOpt.Count; j++)
            {
                if (OptionData[i]["ItemAffixeDataKey"] == PreFinalOpt[j])
                {
                    int optionLevel = OptionData[i]["ItemLevelRestrictEd"];
                    int optionLevelMax = 0;

                    if (optionLevel > optionLevelMax)
                    {
                        optionLevelMax = optionLevel;
                        ItemPre = OptionData[i]["ItemAffixeName"];
                    }
                }
            }
        }
    }
    void SufSelect() //옵션 최대레벨이 가장 높은 접미사를 가져오기
    {
        var OptionData = JSON.Parse(OptionTable.text);

        for (int i = 0; i < OptionData.Count; i++)
        {
            for (int j = 0; j < SufFinalOpt.Count; j++)
            {
                if (OptionData[i]["ItemAffixeDataKey"] == SufFinalOpt[j])
                {
                    int optionLevel = OptionData[i]["ItemLevelRestrictEd"];
                    int optionLevelMax = 0;

                    if (optionLevel > optionLevelMax)
                    {
                        optionLevelMax = optionLevel;
                        ItemSuf = OptionData[i]["ItemAffixeName"];
                    }
                }
            }
        }
    }

    public void OutputClear()
    {
        OptionName.Clear();
        OptionBuffMin.Clear();
        OptionBuffMax.Clear();
    }
}