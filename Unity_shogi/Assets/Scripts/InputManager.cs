using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //スワイプ位置の変数
    private Vector3 GetMouseStartPos;
    private Vector3 GetMouseEndPos;

    //Ray時の位置の変数
    private Vector3 WorldStartPos;
    private Vector3 WorldEndPos;

    //KomaControllerに返す変数
    public Vector3 GetSwipeDistance;

    //カメラの定義
    private Camera mainCamera;

    //ユーザー入力の状況
    public bool CanInput = true;

    void Start()
    {
        //カメラの設定
        mainCamera = Camera.main;
    }

    void Update()
    {
        //マウスクリック時
        if (Input.GetMouseButtonDown(0))
        {
            //マウススワイプ開始時の位置の取得
            GetMouseStartPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //マウススワイプ終了時の位置の取得
            GetMouseEndPos = Input.mousePosition;
            //ユーザー入力の終了
            CanInput = false;
        }
    }

    public Vector3 SwipeMouse()
    {
        //Rayとしてスワイプ開始時、終了時の位置を変換
        Ray rayStart = mainCamera.ScreenPointToRay(GetMouseStartPos);
        Ray rayEnd = mainCamera.ScreenPointToRay(GetMouseEndPos);

        if (
            Physics.Raycast(rayStart, out RaycastHit hitStart)
            && Physics.Raycast(rayEnd, out RaycastHit hitEnd)
        )
        {
            //スワイプの開始と終了をRayとして取得
            WorldStartPos = hitStart.point;
            WorldEndPos = hitEnd.point;
        }
        //結果としてスワイプの間隔を返す
        return WorldEndPos - WorldStartPos;
    }
}
