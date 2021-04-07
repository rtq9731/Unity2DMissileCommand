using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseCharger : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> gaugeObjs;

    private void Update()
    {
        gaugeObjs[1].SetActive(true);
    }

}
