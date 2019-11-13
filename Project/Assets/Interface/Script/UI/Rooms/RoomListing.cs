using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;
using Photon.Pun;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    public SteamVR_LaserPointer laserPointer;

    private string roomname;

    public int[] number;

    public RoomInfo RoomInfo { get; private set; }
    
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        _text.text = roomInfo.Name;

        roomname = roomInfo.Name;
        Debug.Log("Room Listing: " + roomname);

        /*for (int i = 1; i >= 100; i++)
        {
            roomname[i] = roomInfo.Name;
            Debug.Log("1: " + roomname[i]);
        }*/

        //Debug.Log("Room Name : " + roomname);

    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "RoomListing(Clone)")
        {
            Debug.Log("Room Listing was clicked");

            /*roomname = GameObject.Find("RoomListing(Clone)").GetComponentInChildren<Text>().text;
            Debug.Log("Room : " + roomname);
            PhotonNetwork.JoinRoom(roomname);*/

            OnClick_Button();


        }

    }

    public void OnClick_Button()
    {
        roomname = GameObject.Find("RoomListing(Clone)").GetComponentInChildren<Text>().text;
        Debug.Log("Room : " + roomname);
        //PhotonNetwork.JoinRoom(roomname); 
    }
}
