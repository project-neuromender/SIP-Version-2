﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private RoomListing _roomListing;

    public SteamVR_LaserPointer laserPointer;


    private List<RoomListing> _listing = new List<RoomListing>();
    private RoomCanvases _roomCanvases;

    public bool RoomTest = false;

    private string roomname;

    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomCanvases = canvases;
    }

    void Awake()
    {
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "RoomListing(Clone)")
        {
            Debug.Log("Room Listing was clicked");
            //place that need to insert on join room 
            //xtahu keluar ape
            //PhotonNetwork.JoinRoom(_roomListing.RoomInfo.Name);
            //PhotonNetwork.JoinRoom();
            //GameObject.Find("RoomListing(Clone)").GetComponentInChildren<Text>().text = PhotonNetwork.NickName;
            roomname = GameObject.Find("RoomListing(Clone)").GetComponentInChildren<Text>().text;
            Debug.Log("Room : " + roomname);
            PhotonNetwork.JoinRoom(roomname);


        }
    }

   
    public override void OnJoinedRoom()
    {
        _roomCanvases.CurrentRoomCanvas.Show();
         _content.DestroyChildren();
         _listing.Clear();

        Debug.Log("Room Listing Menu : Override Joined Room ");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        int i = 0;

        foreach (RoomInfo info  in roomList)
        {
            //remove from room list.
            if (info.RemovedFromList)
            {
                int index = _listing.FindIndex(x => x.RoomInfo.Name == info.Name);
                
                if(index != -1)
                {
                    Destroy(_listing[index].gameObject);
                    _listing.RemoveAt(index);
                }
            }
            //added rooms to list.
            else
            {
                int index = _listing.FindIndex(x => x.RoomInfo.Name == info.Name);
                
                if (index == -1)
                {
                    RoomListing listing = Instantiate(_roomListing, _content);
                    
                    
                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        _listing.Add(listing);
                        
                    }
                   
                }
                else
                {
                    //modify listing here
                    //_listing[index].dowhatever.

                }
            }
        }
    }
}
