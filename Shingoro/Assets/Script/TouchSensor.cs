using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSensor : MonoBehaviour
{

	BallController[] m_player1Contorollers = new BallController[2];
	BallController[] m_player2Contorollers = new BallController[2];

	Touch[] m_p1Touch = new Touch[2];
	Touch[] m_p2Touch = new Touch[2];

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		Touch[] myTouches = Input.touches;
		int p1idx = 0; 
		int p2idx = 0;

		//タッチが無かった場合は処理しない
		if (Input.touchCount == 0) {

			break;
		}




		//Player1の入力とPlayer2の入力を分析
		//上下どちらかのエリアへの入力だった場合,2つまで記録
		for (int i = 0; i < Input.touchCount; i++) {

			Touch myTouch = Input.GetTouch (i);

			if (myTouch.position.y < Screen.height / 2) {

				if (p1idx == 2) {
					break;
				}
				m_p1Touch [p1idx++] = myTouch;

			} else {
				
				if (p2idx == 2) {
					break;
				}
				m_p2Touch [p2idx++] = myTouch;

			}
		}


		//値に応じて入れ替え

		//Player1
		//タッチ箇所が1つだった時
		if (p1idx == 1) {

			//左にあった時
			if (m_p1Touch [0].position.x < Screen.width) {
				m_player1Contorollers [0].m_nowTouch = m_p1Touch [0];
				m_player1Contorollers [1].m_nowTouch = null;

			} 
				//右にあった時
				else {
				m_player1Contorollers [0].m_nowTouch = null;
				m_player1Contorollers [1].m_nowTouch = m_p1Touch [0];

			}

		}

			//タッチ箇所が2つだった時
			else if (p1idx == 2) {

			//最初に入れた値のほうが左にあったとき
			if (m_p1Touch [0].position.x < m_p1Touch [1].position.x) {
				m_player1Contorollers [0].m_nowTouch = m_p1Touch [0];
				m_player1Contorollers [1].m_nowTouch = m_p1Touch [1];

			} 
				//最初に入れた値のほうが右にあったとき
				else {
				m_player1Contorollers [0].m_nowTouch = m_p1Touch [1];
				m_player1Contorollers [1].m_nowTouch = m_p1Touch [0];

			}

		}

		//Player2
		//タッチ箇所が1つだった時
		if (p2idx == 1) {

			//左にあった時
			if (m_p1Touch [0].position.x < Screen.width) {
				m_player2Contorollers [0].m_nowTouch = m_p2Touch [0];
				m_player2Contorollers [1].m_nowTouch = null;

			} 
				//右にあった時
				else {
				m_player2Contorollers [0].m_nowTouch = null;
				m_player2Contorollers [1].m_nowTouch = m_p2Touch [0];
			}
		}

			//タッチ箇所が2つだった時
			else if (p2idx == 2) {

			//最初に入れた値のほうが左にあったとき
			if (m_p1Touch [0].position.x < m_p1Touch [1].position.x) {
				m_player2Contorollers [0].m_nowTouch = m_p2Touch [0];
				m_player2Contorollers [1].m_nowTouch = m_p2Touch [1];

			} 
				//最初に入れた値のほうが右にあったとき
				else {
				m_player2Contorollers [0].m_nowTouch = m_p2Touch [1];
				m_player2Contorollers [1].m_nowTouch = m_p2Touch [0];

			}
		}
	}
}
