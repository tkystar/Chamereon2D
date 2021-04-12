namespace Western {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class SceneFin : MonoBehaviour
    {
        [SerializeField] public static int Score;
        public Button ScoreBtn;
        public Button BackBtn;
        public GameObject ScoretexObj;
        private Text Scoretex;
        Scene WesternScene;
        //public int[] scorekouho;
        // Start is called before the first frame update
        void Start()
        {
            ScoreBtn.onClick.AddListener(RandomScore);
            BackBtn.onClick.AddListener(SceneBack);
            Scoretex = ScoretexObj.GetComponent<Text>();
        }

        // Update is called once per frame
        void RandomScore()
        {
            Score = Random.Range(0, 100);
            Scoretex.text = "Score is " + Score;
        }
        void SceneBack()
        {
            //SceneManager.LoadScene("WesternScene");
            SceneManager.UnloadScene("BugCatchGame");
            //SceneManager.SetActiveScene().WesternScene;
        }
    }

}

