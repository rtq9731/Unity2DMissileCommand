using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseCharger : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> gaugeObjs;

    private void Update()
    {
        switch(MainSceneManager.Instance.cities)
        {
            default: break;
            case 0:
                {
                    gaugeObjs[0].SetActive(false);
                    gaugeObjs[1].SetActive(false);
                    gaugeObjs[2].SetActive(false);
                    gaugeObjs[3].SetActive(false);
                    gaugeObjs[4].SetActive(false);
                    gaugeObjs[5].SetActive(false);
                    Invoke("GameOver", 3f); break;
                }
            case 1:
                {
                    gaugeObjs[0].SetActive(false);
                    gaugeObjs[1].SetActive(false);
                    gaugeObjs[2].SetActive(false);
                    gaugeObjs[3].SetActive(false);
                    gaugeObjs[4].SetActive(false);
                    gaugeObjs[5].SetActive(true);
                    break;
                }
            case 2:
                {
                    gaugeObjs[0].SetActive(false);
                    gaugeObjs[1].SetActive(false);
                    gaugeObjs[2].SetActive(false);
                    gaugeObjs[3].SetActive(false);
                    gaugeObjs[4].SetActive(true);
                    gaugeObjs[5].SetActive(true);
                    break;
                }
            case 3:
                {
                    gaugeObjs[0].SetActive(false);
                    gaugeObjs[1].SetActive(false);
                    gaugeObjs[2].SetActive(false);
                    gaugeObjs[3].SetActive(true);
                    gaugeObjs[4].SetActive(true);
                    gaugeObjs[5].SetActive(true);
                    break;
                }
            case 4:
                {
                    gaugeObjs[0].SetActive(false);
                    gaugeObjs[1].SetActive(false);
                    gaugeObjs[2].SetActive(true);
                    gaugeObjs[3].SetActive(true);
                    gaugeObjs[4].SetActive(true);
                    gaugeObjs[5].SetActive(true);
                    break;
                }
            case 5:
                {
                    gaugeObjs[0].SetActive(false);
                    gaugeObjs[1].SetActive(true);
                    gaugeObjs[2].SetActive(true);
                    gaugeObjs[3].SetActive(true);
                    gaugeObjs[4].SetActive(true);
                    gaugeObjs[5].SetActive(true);
                    break;
                }
            case 6:
                {
                    gaugeObjs[0].SetActive(true);
                    gaugeObjs[1].SetActive(true);
                    gaugeObjs[2].SetActive(true);
                    gaugeObjs[3].SetActive(true);
                    gaugeObjs[4].SetActive(true);
                    gaugeObjs[5].SetActive(true);
                    break;
                }

        }
    }

    private void GameOver()
    {
        MainSceneManager.Instance.GameOver();
    }

}
