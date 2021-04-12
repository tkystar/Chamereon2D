
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Western
{

   
        public class MainScene : MonoBehaviour
        {

            public GameObject[] GameObjectsTohidden;
            public GameObject maincamera;
            public Scene scene;
            public Fungus.Flowchart flowchart;
            SceneFin scenefin;
            // Use this for initialization
            void Start()
            {
                //シーンが破棄されたときに呼び出されるようにする
                SceneManager.sceneUnloaded += OnSceneUnloaded;

                scene = SceneManager.GetSceneByName("BugCatchGame");
            }

            //サブボタンが押された
            public void SubButton()
            {

                //サブシーンを呼び出しているときに非表示にするゲームオブジェクト
                foreach (GameObject obj in GameObjectsTohidden)
                {
                    obj.SetActive(false);
                }
                //メインシーンにサブシーンを追加表示する
                Application.LoadLevelAdditive("BugCatchGame");
                //SceneManager.LoadScene("BugCatchGame", LoadSceneMode.Additive);
                //SceneManager.SetActiveScene(scene);
                //Application.LoadLevelAdditive("BugCatchGame");

            }

            private void OnSceneUnloaded(Scene current)
            {
                //シーンが破棄されたときに呼び出される
                //今回の例では、サブシーンが破棄されたら呼び出されるようになっています
                Debug.Log("OnSceneUnloaded: " + current.name);

                //本当は、どのシーンが破棄されたのか確認してから処理した方が良いかもしれない

                //ゲームオブジェクトを表示する
                foreach (GameObject obj in GameObjectsTohidden)
                {
                    obj.SetActive(true);
                }

                flowchart.ExecuteBlock("BackScene");

                if (SceneFin.Score > 60)
                {
                    Debug.Log(SceneFin.Score);
                    flowchart.SetBooleanVariable("Score", true);
                }
                else if (SceneFin.Score < 60 && SceneFin.Score > 0)
                {
                    flowchart.SetBooleanVariable("Score", false);
                    Debug.Log(SceneFin.Score);
                }
            }

            

        }
    }
    
