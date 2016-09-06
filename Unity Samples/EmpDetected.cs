using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EmpDetected : MonoBehaviour
{
    public Image EmpWarning;
    public float activeTimer;
    public float activeTime;
    private GameObject m_AudioManager;


    // Use this for initialization
    void Start()
    {
        EmpWarning.color = new Color(1, 1, 1, 0);
        m_AudioManager = GameObject.Find("Audio Manager");
    }


    // Update is called once per frame
    void Update()
    {
        activeTimer -= Time.deltaTime;
        if (activeTimer <= 0)
        {
            EmpWarning.color = new Color(1, 1, 1, 0);
        }
    }


    void OnTriggerEnter(Collider _col)
    {
        if (_col.tag == "EMPCol")
        {
            EmpWarning.color = new Color(1, 1, 1, 1);
            activeTimer = activeTime;
            m_AudioManager.GetComponent<AudioManager>().PlayEmpWarning();
        }
    }

}
