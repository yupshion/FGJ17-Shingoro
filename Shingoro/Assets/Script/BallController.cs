using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public Vector3 targetPos;       //目標とする位置
    Vector3 acc, vel, pos;

    GameObject Glove1, Glove2, Glove3, Glove4;

    void Start()
    {
        pos = targetPos;    //初期値はターゲットと同じで
        acc = vel = Vector3.zero;
        //targetPos = pos = new Vector3(0, 0, 0);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(this.pos, this.targetPos);
    }

    void Update()
    {

        /*
        if (Input.GetMouseButton(0))
        {
            this.pos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            this.pos.z = 0;
        }
        else
        {
            Vector3 diff = this.targetPos - this.pos;
            this.acc = diff * 0.1f;
            this.vel += this.acc;
            this.vel *= 0.9f;
            this.pos += this.vel;
        }
        */

        /*
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            Vector3 vec = touch.position;

            this.pos = Camera.main.ScreenToWorldPoint(vec);

        }
        */


        if (OnTouchDown())
        {
           
            this.pos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            this.pos.z = 0;
        }
        else
        {
            Vector3 diff = this.targetPos - this.pos;
            this.acc = diff * 0.1f;
            this.vel += this.acc;
            this.vel *= 0.9f;
            this.pos += this.vel;
        }
        transform.position = this.pos;
    }

    //スマホ向け そのオブジェクトがタッチされていたらtrue（マルチタップ対応）
    bool OnTouchDown()
    {
        // タッチされているとき
        if (0 < Input.touchCount || Input.GetMouseButton(0))
        {
            // タッチされている指の数だけ処理
            for (int i = 0; i < Input.touchCount && i < 4; i++)
            {
                // タッチ情報をコピー
                Touch t = Input.GetTouch(i);
                // タッチしているかどうか
                if (t.phase != TouchPhase.Ended)
                {
                    
                    //タッチしている場所が上下判定する
                    if(t.position.y < Screen.height / 2)
                    {
                        //1P側

                        if (t.position.x < Screen.width / 2)
                        {
                            //左

                        }
                        else
                        {
                            //右

                        }

                    }
                    else
                    {
                        //2P側
                        if (t.position.x < Screen.width / 2)
                        {
                            //左

                        }
                        else
                        {
                            //右

                        }

                    }
                    /*
                    //タッチした位置からRayを飛ばす
                    Ray ray = Camera.main.ScreenPointToRay(t.position);
                    RaycastHit hit = new RaycastHit();
                    if (Physics.Raycast(ray, out hit))
                    {
                        //Rayを飛ばしてあたったオブジェクトが自分自身だったら
                        if (hit.collider.gameObject == this.gameObject)
                        {
                            //ゲームオブジェクトの名前表示
                            Debug.Log("タップされました");
                            Debug.Log(hit.collider.gameObject.name);
                            return true;
                        }
                    }
                    */
                }
            }
        }
        return false; //タッチされてなかったらfalse
    }

}