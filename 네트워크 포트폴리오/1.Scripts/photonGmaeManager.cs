using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class photonGmaeManager : MonoBehaviourPunCallbacks
{
    [Header("적 태그")]
    public string anemyTag;
    public bool isSubuerver = true;
    [Header("게임 정보")]
    public int nMyActorNumber;
    public int nMychampionNumber;
    //public GameObject objGameUserData;
    public GameObject OBJchampion;

    private static photonGmaeManager instance = null;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static photonGmaeManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }

    }

    [Header("챔피언 스폰 위치")]
    public Transform Tchampion;
    public Transform Bchampion;
    // Start is called before the first frame update
    void Start()
    {
        nMychampionNumber = PlayerPrefs.GetInt("CHAMPION_NUM");
        PhotonNetwork.IsMessageQueueRunning = true;
        //objGameUserData = GameObject.Find("UserData");
        //nMychampionNumber = objGameUserData.GetComponent<GameRoomManager>().nChampionnum[i];
        nMyActorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        if (!isSubuerver)
        {
            for (int i = 0; i < 10; i++)
            {
                //나의 정보를 찾음
                //if (objGameUserData.GetComponent<GameRoomManager>().nActorNumBer[i] == nMyActorNumber)
                //{

                //    //윗 마을 케릭터인 경우
                //    if (i < 5) //슬롯번호 체크
                //    {
                //        if (photonView.IsMine)
                //        {
                //            Debug.Log("nMyActorNumber[i] top" + objGameUserData.GetComponent<GameRoomManager>().nActorNumBer[i]);
                //            switch (objGameUserData.GetComponent<GameRoomManager>().nChampionnum)
                //            {
                //                case 0:
                //                    OBJchampion = PhotonNetwork.Instantiate("xbot", Bchampion.position, Quaternion.identity);
                //                    break;
                //                case 1:
                //                    OBJchampion = PhotonNetwork.Instantiate("ybot", Bchampion.position, Quaternion.identity);
                //                    break;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        if (photonView.IsMine)
                //        {
                //            Debug.Log("nMyActorNumber[i] bottam" + objGameUserData.GetComponent<GameRoomManager>().nActorNumBer[i]);
                //            switch (objGameUserData.GetComponent<GameRoomManager>().nChampionnum)
                //            {
                //                case 0:
                //                    OBJchampion = PhotonNetwork.Instantiate("xbot", Bchampion.position, Quaternion.identity);
                //                    break;
                //                case 1:
                //                    OBJchampion = PhotonNetwork.Instantiate("ybot", Bchampion.position, Quaternion.identity);
                //                    break;
                //            }
                //        }
                //    }
                //    //메인카메라에 대상 게임 오브젝트를 지정
                //    //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Cameramove_CHOGUNHEE>().obj[0] = OBJchampion;
                //    break;
                //}
            }
        }
        else
        {
            switch (nMychampionNumber)
            {
                case 0:
                    OBJchampion = PhotonNetwork.Instantiate("ybot", Bchampion.position, Quaternion.identity);
                    break;
                case 1:
                    OBJchampion = PhotonNetwork.Instantiate("xbot", Bchampion.position, Quaternion.identity);
                    break;
            }

        }
    }

    
    // Update is called once per frame
    void Update()
    {

    }
}
