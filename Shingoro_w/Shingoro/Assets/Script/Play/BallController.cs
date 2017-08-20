using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public Vector3 targetPos;       //目標とする位置
    public Vector3 targetPos1, targetPos2, targetPos3, targetPos4;       //目標とする位置

    //バネ計算
    Vector3 acc1, acc2, acc3, acc4;
    Vector3 vel1, vel2, vel3, vel4;
    Vector3 pos1, pos2, pos3, pos4;

    Vector3 acc;
    Vector3 vel;
    Vector3 pos;

    public GameObject Glove1, Glove2, Glove3, Glove4;      //1P左、右、2P左、右

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

            // タッチしている場所を特定する
            Vector3 vec = Camera.main.ScreenPointToRay(Input.mousePosition).origin; ;

            //タッチしている場所が上下判定する
            //TODO：Z軸がカメラの位置になってしまう為、無理やり0に…。
            if (Camera.main.ScreenPointToRay(Input.mousePosition).origin.y < Screen.height / 2)
            {
                //1P側

                if (Camera.main.ScreenPointToRay(Input.mousePosition).origin.x < Screen.width / 2)
                {
                    //左
                    Glove1.transform.position = Camera.main.ScreenToWorldPoint(vec);
                    Glove1.transform.position = new Vector3(Glove1.transform.position.x, Glove1.transform.position.y, 0);
                }
                else
                {
                    //右
                    Glove2.transform.position = Camera.main.ScreenToWorldPoint(vec);
                    Glove2.transform.position = new Vector3(Glove2.transform.position.x, Glove2.transform.position.y, 0);
                }

            }
            else
            {
                //2P側
                if (Camera.main.ScreenPointToRay(Input.mousePosition).origin.x < Screen.width / 2)
                {
                    //左
                    Glove3.transform.position = Camera.main.ScreenToWorldPoint(vec);
                    Glove3.transform.position = new Vector3(Glove3.transform.position.x, Glove3.transform.position.y, 0);
                }
                else
                {
                    //右
                    Glove4.transform.position = Camera.main.ScreenToWorldPoint(vec);
                    Glove4.transform.position = new Vector3(Glove4.transform.position.x, Glove4.transform.position.y, 0);

                }
            }
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

        //押しているか判定を取る
        OnTouchDown();


        if (OnTouchDown())
        {
           
            //this.pos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            //this.pos.z = 0;
        }
        else
        {
            //   Glove1;
            //   Glove2;
            //   Glove3;
            //   Glove4;
            //Vector3 diff = this.targetPos - this.pos;   //差を計算する
            //this.acc = diff * 0.1f; //加速度を計算
            //this.vel += this.acc;
            //this.vel *= 0.9f;
            //this.pos += this.vel;

            Vector3 diff1 = this.targetPos1 - Glove1.transform.position;   //差を計算する
            this.acc1 = diff1 * 0.1f; //加速度を計算
            this.vel1 += this.acc1;
            this.vel1 *= 0.9f;
            Glove1.transform.position += this.vel1;

            Vector3 diff2 = this.targetPos2 - Glove2.transform.position;   //差を計算する
            this.acc2 = diff2 * 0.1f; //加速度を計算
            this.vel2 += this.acc2;
            this.vel2 *= 0.9f;
            Glove2.transform.position += this.vel2;

            Vector3 diff3 = this.targetPos3 - Glove3.transform.position;   //差を計算する
            this.acc3 = diff3 * 0.1f; //加速度を計算
            this.vel3 += this.acc3;
            this.vel3 *= 0.9f;
            Glove3.transform.position += this.vel3;

            Vector3 diff4 = this.targetPos4 - Glove4.transform.position;   //差を計算する
            this.acc4 = diff4 * 0.1f; //加速度を計算
            this.vel4 += this.acc4;
            this.vel4 *= 0.9f;
            Glove4.transform.position += this.vel4;

            //各べこの角度を計算する
            //べこ左(p1L)
          //  Glove1.transform.rotation = new Quaternion(0, 0, 0, 0);
          //  Glove2.transform.rotation = new Quaternion(0, 0, 0, 0);
          //  Glove3.transform.rotation = new Quaternion(0, 0, 0, 0);
          //  Glove4.transform.rotation = new Quaternion(0, 0, 0, 0);
            //Glove1.transform.rotation = new Quaternion(0, 0, GetAim(Glove1.transform.position, this.targetPos1 + new Vector3(0, -1, 0)), 1);

            //Glove2.transform.rotation = new Quaternion(0, 0, GetAim(Glove2.transform.position, this.targetPos2 + new Vector3(0, -1, 0)), 1);

        }

        //transform.position = this.pos;
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
                    //タッチしている場所を特定する
                    Vector3 vec = t.position;

                    //タッチしている場所が上下判定する
                    //TODO：Z軸がカメラの位置になってしまう為、無理やり0に…。
                    if (t.position.y < Screen.height / 2)
                    {
                        //1P側

                        if (t.position.x < Screen.width / 2)
                        {
                            //左
                            Glove1.transform.position = Camera.main.ScreenToWorldPoint(vec);
                            Glove1.transform.position = new Vector3(Glove1.transform.position.x, Glove1.transform.position.y,0);

                            //角度の計算を行う
                            var diff = (this.targetPos1 - Glove1.transform.position).normalized;
                            Glove1.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);

                        }
                        else
                        {
                            //右
                            Glove2.transform.position = Camera.main.ScreenToWorldPoint(vec);
                            Glove2.transform.position = new Vector3(Glove2.transform.position.x, Glove2.transform.position.y, 0);

                            //角度の計算を行う
                            var diff = (this.targetPos2 - Glove2.transform.position).normalized;
                            Glove2.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
                        }

                    }
                    else
                    {
                        //2P側
                        if (t.position.x < Screen.width / 2)
                        {
                            //左
                            Glove3.transform.position = Camera.main.ScreenToWorldPoint(vec);
                            Glove3.transform.position = new Vector3(Glove3.transform.position.x, Glove3.transform.position.y, 0);
                            //角度の計算を行う
                            var diff = (this.targetPos3 - Glove3.transform.position).normalized;
                            Glove3.transform.rotation = Quaternion.FromToRotation(Vector3.up,diff);
                        }
                        else
                        {
                            //右
                            Glove4.transform.position = Camera.main.ScreenToWorldPoint(vec);
                            Glove4.transform.position = new Vector3(Glove4.transform.position.x, Glove4.transform.position.y, 0);
                            //角度の計算を行う
                            var diff = (this.targetPos4 - Glove4.transform.position).normalized;
                            Glove4.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);

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

    // p2からp1への角度を求める
    // @param p1 自分の座標
    // @param p2 相手の座標
    // @return 2点の角度(Degree)
    public float GetAim(Vector2 p1, Vector2 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }

}