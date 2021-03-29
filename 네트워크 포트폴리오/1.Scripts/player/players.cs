using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;

public class players : MonoBehaviourPunCallbacks
{
    photonGmaeManager photonGM;
    public GameObject thisplayer;
    public CameraFlow cameraFlow;
    public NavMeshAgent agent;
    [Header("위치 값")]
    public Transform resphonspos;
    public GameObject tuchinstance;
    public GameObject hitPOS;
    Transform tuchpos;

    [Header("거리값")]
    public float dist;
    public float minimumdist;
    public float fSearchDist;
    public float attackDist;
    public bool bAttack;
    [Header("플레이어 정보")]
    public Text playerName;
    public Animator animator;

    public bool bDead;
    //public string SubuerverTag;


    [Header("게임 종류")]
    //public GameObject[] isSubuerverGameObj;

    [Header("추적부분")]
    public bool bColl;
    bool bAI;
    GameObject ObjTarget; //목표 오브젝트
    public Transform tsTarget;

    public enum playerKinds
    {
        move,
        stop,
        attack
    }
    public playerKinds PlayerKinds;
    public enum minState { idle, trace, attack };
    public minState currState = minState.trace;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        photonGM = GameObject.Find("PhotonGM").GetComponent<photonGmaeManager>();
        playerName.text = photonView.Owner.NickName;
        if (photonView.IsMine) {
            
            cameraFlow = GameObject.Find("Main Camera").GetComponent<CameraFlow>();
            cameraFlow.target = gameObject;
            if (photonGM.isSubuerver)
            {
                thisplayer.tag = "Subuerver";
            }
            else
            {
                if (photonGM.anemyTag == "A") { thisplayer.tag = "A"; }
                if (photonGM.anemyTag == "B") { thisplayer.tag = "B"; }
            }
        }
        agent = this.GetComponent<NavMeshAgent>();
        PlayerKinds = playerKinds.stop;
        StartCoroutine(this.State());
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) { return; }
        else
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        Vector3 pos = Input.GetTouch(0).position;

                        Ray ray = Camera.main.ScreenPointToRay(pos);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit))
                        {
                            //animator.SetBool("run", true
                            ani(aniState.run);
                            agent.SetDestination(hit.point);
                            //hitPOS = Instantiate(tuchinstance, hit.transform);

                            agent.isStopped = false;
                        }
                    }
                    if (agent.remainingDistance <= 0.2f && agent.velocity.magnitude >= 0.2f)
                    {
                        Debug.Log("idle");
                        //ani(aniState.run);
                        agent.isStopped = true;

                    }
                }
            }
            if (Input.GetMouseButton(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log("클릭");
                    PlayerKinds = playerKinds.move;
                    bAttack = true;
                    bAI = true;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 100))
                    {
                        ani(aniState.run);
                        agent.SetDestination(hit.point);
                        
                       
                        agent.isStopped = false;

                    }
                }
            }
            if (agent.remainingDistance <= 0.2f && agent.velocity.magnitude >= 0.2f)
            {
                animator.SetBool("run", false);
                ani(aniState.idle);
                bAttack = true;
                bAI = true;
                agent.isStopped = true;
            }
        }
    }
    void Delethit() 
    {
        if (hitPOS != null) 
        {
                Destroy(hitPOS);
                return;
            
        }
    }
    public void NearEnemyAttack(Vector3 pos, float rafius)
    {

        Collider[] colls = Physics.OverlapSphere(pos, rafius);
        minimumdist = rafius;
        bColl = false;
        ObjTarget = null;

        for (int i = 0; i < colls.Length; i++)
        {
            //서바이벌 게임
            if (photonGM.isSubuerver)
            {
                if (colls[i].tag == "Subuerver" && colls[i].GetComponent<DadeState>().bDead == false)
                {
                    curAni = aniState.attack;
                    Vector3 objectPos = colls[i].transform.position;
                    dist = Vector3.Distance(objectPos, transform.position);
                    
                    if (minimumdist > dist)
                    {
                        curAni = aniState.attack;
                        ObjTarget = colls[i].gameObject;
                        minimumdist = dist;
                        bColl = true;
                        

                    }

                }

            }
            else
            {
                if (photonGM.anemyTag == "A")
                {
                    if (colls[i].tag == "B" && colls[i].GetComponent<DadeState>().bDead == false)
                    {
                        Vector3 objectPos = colls[i].transform.position;
                        dist = Vector3.Distance(objectPos, transform.position);

                        if (minimumdist > dist)
                        {
                            ObjTarget = colls[i].gameObject;
                            minimumdist = dist;
                            bColl = true;

                        }

                    }
                }
                if (photonGM.anemyTag == "B")
                {
                    if (colls[i].tag == "A" && colls[i].GetComponent<DadeState>().bDead == false)
                    {
                        Vector3 objectPos = colls[i].transform.position;
                        dist = Vector3.Distance(objectPos, transform.position);

                        if (minimumdist > dist)
                        {
                            ObjTarget = colls[i].gameObject;
                            minimumdist = dist;
                            bColl = true;

                        }

                    }
                }

            }
        }
        if (bColl)
        {
            tsTarget = ObjTarget.transform;
            bAI = true;
        }
        else
        {
            bAI = false;
        }

    }

    IEnumerator State()
    {
        if (bDead)
        {
            yield return new WaitForSeconds(0.1f);
            NearEnemyAttack(transform.position, fSearchDist);
            if (bAI && bAttack)
            {
                float dist = Vector3.Distance(tsTarget.position, transform.position);

                if (tsTarget.tag == "Subuerver" && dist < attackDist)
                {
                    currState = minState.attack;
                    ani(aniState.attack);
                    
                    
                   
                    //tsTarget.SendMessage("Damage", fAttackDamage);
                    Debug.Log("근거리 공격");
                }
                else
                {
                    currState = minState.trace;
                    ani(aniState.run);
                }
                switch (PlayerKinds)
                {
                    case playerKinds.stop:
                        agent.isStopped = true;
                        break;
                    case playerKinds.move:
                        agent.isStopped = false;
                        break;
                    case playerKinds.attack:
                        agent.isStopped = false;
                        break;
                }
            }
        }
    }
    public enum aniState { idle, attack, run};
    public aniState curAni = aniState.idle;
    void ani(aniState _curAni) //애니이션 상태 함수
    {
        animator.SetBool("idle", false);
        animator.SetBool("attack", false);
        animator.SetBool("run", false);
        //animator.SetBool("death", false);
    

        curAni = _curAni; //확인용

        switch (_curAni)
        {
            case aniState.idle:
                animator.SetBool("idle", true); 
                break;
            case aniState.attack:
                animator.SetBool("attack", true);
                break;
            case aniState.run:
                animator.SetBool("run", true);
                break;
           
           
        }
    }


}
