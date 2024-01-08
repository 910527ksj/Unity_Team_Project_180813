using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//백슬기
namespace Assets.SimpleAndroidNotifications
{
    public class KeyPlusManager : MonoBehaviour
    {
        static KeyPlusManager _instance = null;
        public static KeyPlusManager Instance()
        {
            return _instance;
        }

        public int KeyPlusCool = 1; //열쇠 회복 쿨타임(Minute단위)
        public string KeyplusTimeEnd; //열쇠 회복 종료시간
        public int FillKey; //회복해야 할 열쇠 갯수

        void Start()
        {
            if (_instance == null)
                _instance = this;

            GameRestartKeyPlusTimer();
        }

        void Update()
        {
            FillKey = PlayerPrefs.GetInt("FillKey");

            if (FillKey == 0)
                NotificationManager.CancelAll();
            if (FillKey > 0)
                KeyPlusTimer();
        }

        public void KeyPlusTimeStart() //열쇠 사용해서, 보유한 열쇠가 30개 이하가 된 그 순간에 타이머 시작
        {
            FillKey = 30 - CharacterDatamanager.Instance().Key;
            PlayerPrefs.SetInt("FillKey", FillKey);

            DateTime StartTime = DateTime.Now;
            DateTime EndTime = StartTime.AddMinutes(FillKey * KeyPlusCool);
            KeyplusTimeEnd = EndTime.ToString("MM/dd/yyyy hh:mm:ss tt");
            PlayerPrefs.SetString("KeyplusTimeEnd", KeyplusTimeEnd);

            NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(FillKey * (KeyPlusCool * 60)), "열쇠 회복 완료!", "새로운 지역을 열 수 있는 열쇠가 모두 회복됐어요! 이제 정복하러 가볼까요?", new Color(1, 0.96f, 0.4f), NotificationIcon.Star);
        }
        void KeyPlusTimer() //열쇠 회복 타이머
        {
            KeyplusTimeEnd = PlayerPrefs.GetString("KeyplusTimeEnd");

            DateTime keyPlusTime = DateTime.Parse(KeyplusTimeEnd, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat, System.Globalization.DateTimeStyles.None);
            DateTime nowTime = DateTime.Now;
            TimeSpan timeCal = keyPlusTime - nowTime;

            int timeCalMinute = timeCal.Minutes;
            int timeCalSec = timeCal.Seconds;

            if (timeCalSec == 0)
            {
                CharacterDatamanager.Instance().Key += 1;
                PlayerPrefs.SetInt("Key", CharacterDatamanager.Instance().Key);
                FillKey -= 1;
                PlayerPrefs.SetInt("FillKey", FillKey);
            }

            if (timeCalMinute <= 0 && timeCalSec <= 0)
            {
                timeCalMinute = 0;
                timeCalSec = 0;
                FillKey = 0;
                PlayerPrefs.SetInt("FillKey", FillKey);
            }
        }
        void GameRestartKeyPlusTimer() //열쇠 회복 타이머(게임 종료 후 다시 실행했을 때만)
        {
            KeyplusTimeEnd = PlayerPrefs.GetString("KeyplusTimeEnd");
            FillKey = PlayerPrefs.GetInt("FillKey");

            DateTime keyPlusTime = DateTime.Parse(KeyplusTimeEnd, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat, System.Globalization.DateTimeStyles.None);
            DateTime nowTime = DateTime.Now;
            TimeSpan timeCal = keyPlusTime - nowTime;

            int timeCalMinute = timeCal.Minutes;
            int timeCalSec = timeCal.Seconds;

            if (timeCalMinute <= 0 && timeCalSec <= 0)
            {
                timeCalMinute = 0;
                timeCalSec = 0;
            }

            if (timeCalSec == 0)
            {
                int NowFillKey = FillKey - timeCalMinute;
                CharacterDatamanager.Instance().Key += NowFillKey;
                PlayerPrefs.SetInt("Key", CharacterDatamanager.Instance().Key);
                FillKey -= NowFillKey;
                PlayerPrefs.SetInt("FillKey", FillKey);
            }
            else
            {
                int NowFillKey = (FillKey - timeCalMinute) - 1;
                CharacterDatamanager.Instance().Key += NowFillKey;
                PlayerPrefs.SetInt("Key", CharacterDatamanager.Instance().Key);
                FillKey -= NowFillKey;
                PlayerPrefs.SetInt("FillKey", FillKey);
            }
        }
    }
}
