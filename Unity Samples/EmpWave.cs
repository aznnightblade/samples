using UnityEngine;
using System.Collections;

public class EmpWave : MonoBehaviour
{
    public float m_Scaler;                  //How fast it grows over time.
    public float m_maxCooldownTime;         //Maximum Time between EMP waves.
    public float m_minCooldownTime;         //Minimum Time between EMP waves.
    public float m_CurrCooldownTimer;       //Current Time between EMP waves.
    public float m_CurrEmpActiveTimer;      //How long the EMP has been active.
    public float m_MaxEmpActiveTimer;       //How long the EMP can be Active.

    public float m_MaxScale;                //How Large the EMP can grow.
    public float m_ForwardSpeed;            //How fast the EMP moves Foward, Can be negative.

    public Vector3 m_OriginalScale;         //Original Size before been Active.
    public Vector3 m_OriginalLocation;      //Original Location before been Active.

    public GameObject[] m_towers;


    // Use this for initialization
    void Start()
    {
        m_CurrCooldownTimer = Random.Range(m_minCooldownTime, m_maxCooldownTime);
        m_CurrEmpActiveTimer = 0.0f;
        m_OriginalLocation = gameObject.transform.position;
        m_OriginalScale = gameObject.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {

        if (m_CurrCooldownTimer <= 0.0f)
        {
            //Always Rotate it looks cool
            gameObject.transform.Rotate(Vector3.up * (Time.deltaTime * 10));
            //Grow untill it reaches x sizes
            if (m_MaxScale >= gameObject.transform.localScale.x)
                gameObject.transform.localScale += new Vector3(m_Scaler, m_Scaler, m_Scaler) * Time.deltaTime;
            else //Move towards Player once max size is reach
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + (Time.deltaTime * m_ForwardSpeed));
            //Decrement Life while active
            m_CurrEmpActiveTimer -= Time.deltaTime;
            if (m_CurrEmpActiveTimer <= 0)
                Reset();
        }
        else {  //If not Active decrement cooldown
            m_CurrCooldownTimer -= Time.deltaTime;
            if (m_CurrCooldownTimer <= 0.0f)
                m_CurrEmpActiveTimer = m_MaxEmpActiveTimer;
        }





        //if (EMPTicker < maxEMPTime)
        //{
        //    gameObject.transform.Rotate(Vector3.up * (Time.deltaTime * 10));
        //    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - (Time.deltaTime * 2));
        //    gameObject.transform.localScale += new Vector3(m_Scaler, m_Scaler, m_Scaler) * Time.deltaTime;
        //    EMPTicker += Time.deltaTime;
        //}

        //if (EMPTicker > maxEMPTime && m_CurrCooldownTimer > 0.0f)
        //{
        //    m_CurrCooldownTimer -= Time.deltaTime;
        //}
        //else if (m_CurrCooldownTimer <= 0)
        //{
        //    Reset();
        //}
    }

    void OnTriggerEnter(Collider _col)
    {
        if (_col.tag == "Player")
        {
            _col.gameObject.BroadcastMessage("EMPHit");
        }
    }

    public void Reset()
    {
        m_CurrCooldownTimer = Random.Range(m_minCooldownTime, m_maxCooldownTime);
        gameObject.transform.localScale = m_OriginalScale;
        gameObject.transform.position = m_OriginalLocation;
    }

}
