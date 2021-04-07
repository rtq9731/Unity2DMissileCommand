using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseCharger : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> gaugeObjs;

    private MissileHitScan commandHp;

    private void Start()
    {
        commandHp = this.gameObject.GetComponentInParent<MissileHitScan>();
    }

    private void Update()
    {
        switch(commandHp.hp)
        {
            case 1:
                {
                    gaugeObjs[0].SetActive(false);
                    gaugeObjs[1].SetActive(false);   
                    gaugeObjs[2].SetActive(false);
                    gaugeObjs[3].SetActive(true);
                    break;
                }
            case 2:
                {
                    gaugeObjs[0].SetActive(false);
                    gaugeObjs[1].SetActive(false);
                    gaugeObjs[2].SetActive(true);
                    gaugeObjs[3].SetActive(true);
                    break;
                }
            case 3:
                {
                    gaugeObjs[0].SetActive(false);
                    gaugeObjs[1].SetActive(true);
                    gaugeObjs[2].SetActive(true);
                    gaugeObjs[3].SetActive(true);
                    break;
                }
            case 4:
                {
                    gaugeObjs[0].SetActive(true);
                    gaugeObjs[1].SetActive(true);
                    gaugeObjs[2].SetActive(true);
                    gaugeObjs[3].SetActive(true);
                    break;
                }

        }
    }

}
