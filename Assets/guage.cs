
namespace InGame
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class guage : MonoBehaviour
    {
        private const float MATRIX_TIME=20;
        private float _MatrixTime;
        public float _remainingMatrixGuage;
        private float _progressTime;
        public GameObject timeDisplayTextObject;
        private Text timeDisplayText;
        // Start is called before the first frame update
        void Start()
        {
            _MatrixTime = MATRIX_TIME;
            timeDisplayText = timeDisplayTextObject.GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            _progressTime += Time.deltaTime;
            timeDisplayText.text = _progressTime.ToString();

            if (Input.GetKey(KeyCode.Space))
            {
                _MatrixTime -= Time.deltaTime;
                _remainingMatrixGuage = Mathf.Lerp(0, 100, _MatrixTime / MATRIX_TIME);
                Time.timeScale = 0.1f;

            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }

}
