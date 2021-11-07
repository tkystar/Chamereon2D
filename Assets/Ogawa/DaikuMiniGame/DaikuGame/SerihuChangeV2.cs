using UnityEngine;
using TMPro;

public class SerihuChangeV2 : MonoBehaviour
{
    public GameObject PinP;
    public GameObject PinR;
    public GameObject PinG;
    public GameObject PinY;
    public GameObject PinB;
    public GameObject PinS;

    public GameObject Say;
    public GameObject serihu;
    TextMeshPro SayText;

    PinR2 Pin1;
    PinR2 Pin2;
    PinR2 Pin3;
    PinR2 Pin4;
    PinR2 Pin5;
    PinR2 Pin6;

    public bool Yotu = false;
    public bool Katakori = false;
    public bool Hiesyou = false;
    public bool Warai = false;

    int PinCount = 0;
    bool Check = true;

    public GameObject Clear;
    bool ClearCheck = false;

    //public GameObject HanteiXY;
    //public GameObject HanteiX2;
    //public GameObject HanteiX3;
    //public GameObject HanteiX4;
    //public GameObject HanteiY2;
    //public GameObject HanteiY3;
    //public GameObject HanteiY4;

    // Start is called before the first frame update
    void Start()
    {
        Clear.SetActive(false);
        Pin1 = PinR.GetComponent<PinR2>();
        Pin2 = PinP.GetComponent<PinR2>();
        Pin3 = PinG.GetComponent<PinR2>();
        Pin4 = PinY.GetComponent<PinR2>();
        Pin5 = PinB.GetComponent<PinR2>();
        Pin6 = PinS.GetComponent<PinR2>();
        SayText = serihu.GetComponent<TextMeshPro>();
        SayText.text = "コシのいたみとカタこりのツボをついてくれ";
        Invoke("Activateoff", 3);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PinCount);
        if (!ClearCheck)
        {
            if (Check)
            {
                if (PinCount == 6)
                {
                    PinCheck();
                }
            }
            if (Yotu && Katakori && Warai && Hiesyou)
            {
                Invoke("DaikuClear", 3.5f);
                ClearCheck = true;
            }
        }

    }

    void PinCheck()
    {
        Say.SetActive(true);
        if (
            //ようつう
            PinR.transform.position.x > -16.5f && PinR.transform.position.x < -12.5f &&
            PinR.transform.position.y > 2 / 3f && PinR.transform.position.y < 4f &&

            PinP.transform.position.x > -8.5f && PinP.transform.position.x < -4.5f &&
            PinP.transform.position.y > -8 / 3f && PinP.transform.position.y < 2 / 3f &&

            PinG.transform.position.x > -8.5f && PinG.transform.position.x < -4.5f &&
            PinG.transform.position.y > 2 / 3f && PinG.transform.position.y < 4f &&

            PinY.transform.position.x > -16.5f && PinY.transform.position.x < -12.5f &&
            PinY.transform.position.y > -8 / 3f && PinY.transform.position.y < 2 / 3f &&

            PinB.transform.position.x > -12.5f && PinB.transform.position.x < -8.5f &&
            PinB.transform.position.y > -6f && PinB.transform.position.y < -8 / 3f &&

            PinS.transform.position.x > -12.5f && PinS.transform.position.x < -8.5f &&
            PinS.transform.position.y > -6f && PinS.transform.position.y < -8 / 3f
            )
        {
            if (!Yotu)
            {
                SayText.text = "ようつうがよくなったきがするぞ";
            }
            if (Yotu)
            {
                SayText.text = "ようつうはもうダイジョウブじゃ";
            }
            Yotu = true;
        }
        else if (
            //かたこり
            PinR.transform.position.x > -16.5f && PinR.transform.position.x < -12.5f &&
            PinR.transform.position.y > 2 / 3f && PinR.transform.position.y < 4f &&

            PinP.transform.position.x > -16.5f && PinP.transform.position.x < -12.5f &&
            PinP.transform.position.y > -6f && PinP.transform.position.y < -8 / 3f &&

            PinG.transform.position.x > -12.5f && PinG.transform.position.x < -8.5f &&
            PinG.transform.position.y > -6f && PinG.transform.position.y < -8 / 3f &&

            PinY.transform.position.x > -12.5f && PinY.transform.position.x < -8.5f &&
            PinY.transform.position.y > -6f && PinY.transform.position.y < -8 / 3f &&

            PinB.transform.position.x > -8.5f && PinB.transform.position.x < -4.5f &&
            PinB.transform.position.y > 2 / 3f && PinB.transform.position.y < 4f &&

            PinS.transform.position.x > -8.5f && PinS.transform.position.x < -4.5f &&
            PinS.transform.position.y > -6f && PinS.transform.position.y < -8 / 3f
            )
        {
            if (!Katakori)
            {
                SayText.text = "なんとなくカタがかるいわい";
            }
            if (Katakori)
            {
                SayText.text = "かたこりはもうダイジョウブじゃ";
            }
            Katakori = true;
        }
        else if (
            //かたこり
            PinR.transform.position.x > -16.5f && PinR.transform.position.x < -12.5f &&
            PinR.transform.position.y > 2 / 3f && PinR.transform.position.y < 4f &&

            PinP.transform.position.x > -16.5f && PinP.transform.position.x < -12.5f &&
            PinP.transform.position.y > -6f && PinP.transform.position.y < -8 / 3f &&

            PinG.transform.position.x > -12.5f && PinG.transform.position.x < -8.5f &&
            PinG.transform.position.y > -6f && PinG.transform.position.y < -8 / 3f &&

            PinY.transform.position.x > -12.5f && PinY.transform.position.x < -8.5f &&
            PinY.transform.position.y > -6f && PinY.transform.position.y < -8 / 3f &&

            PinB.transform.position.x > -8.5f && PinB.transform.position.x < -4.5f &&
            PinB.transform.position.y > 2 / 3f && PinB.transform.position.y < 4f &&

            PinS.transform.position.x > -8.5f && PinS.transform.position.x < -4.5f &&
            PinS.transform.position.y > -6f && PinS.transform.position.y < -8 / 3f
            )
        {
            if (!Hiesyou)
            {
                SayText.text = "からだがほてってきたのぅ";
            }
            if (Hiesyou)
            {
                SayText.text = "からだがもえてしまいそうじゃ";
            }
            Hiesyou = true;
        }
        else if (
            //わらい
            PinR.transform.position.x > -12.5f && PinR.transform.position.x < -8.5f &&
            PinR.transform.position.y > -6f && PinR.transform.position.y < -8 / 3f &&

            PinP.transform.position.x > -12.5f && PinP.transform.position.x < -8.5f &&
            PinP.transform.position.y > -6f && PinP.transform.position.y < -8 / 3f &&

            PinG.transform.position.x > -8.5f && PinG.transform.position.x < -4.5f &&
            PinG.transform.position.y > -8 / 3f && PinG.transform.position.y < 2 / 3f &&

            PinY.transform.position.x > -16.5f && PinY.transform.position.x < -12.5f &&
            PinY.transform.position.y > -8 / 3f && PinY.transform.position.y < 2 / 3f &&

            PinB.transform.position.x > -16.5f && PinB.transform.position.x < -12.5f &&
            PinB.transform.position.y > -8 / 3f && PinB.transform.position.y < 2 / 3f &&

            PinS.transform.position.x > -8.5f && PinS.transform.position.x < -4.5f &&
            PinS.transform.position.y > -8 / 3f && PinS.transform.position.y < 2 / 3f
            )
        {
            SayText.text = "うひゃひゃひゃひゃひゃ\nへんなとこささんでくれ,,,\nうひゃひゃ";
            Warai = true;
        }
        else
        {
            SayText.text = "いまいちじゃのぅ… \n いいところにさしてくれぇ";
        }

        Invoke("PinR2Reset", 0.5f);
        Check = false;
        Invoke("Activateoff", 3.5f);
    }
    void Activateoff()
    {
        Say.SetActive(false);
    }
    void DaikuClear()
    {
        Clear.SetActive(true);
    }

    void PinR2Reset()
    {
        Pin1.ResetPin();
        Pin2.ResetPin();
        Pin3.ResetPin();
        Pin4.ResetPin();
        Pin5.ResetPin();
        Pin6.ResetPin();
    }

    public void CountDown()
    {
        PinCount--;
    }

    public void CountUp()
    {
        Check = true;
        PinCount++;
    }

}
