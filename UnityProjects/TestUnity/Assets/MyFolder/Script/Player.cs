using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    // 移動スピードの設定
    public float speed;
    Rigidbody r;                // リジッドボディ
    Vector3 player_pos;         // 座標
    float radian = 0.0f;        // プレイヤーの向き
    
    public Vector3 jump_force;  // ジャンプ力
    public float move_force;
    bool jump_flag = false;     // ジャンプ中かどうか
    bool move_flag = false;     // 移動してるかどうか
    bool trigger_flag = false;  // ブーストのトリガーフラグ
    float hp = 100.0f;          // HP
    float energy = 100.0f;      // エネルギー
    float energy_cd = 0;

    //bool up_flag = false;
    //bool down_flag = false;
    //bool left_flag = false;
    //bool right_flag = false;

	// Use this for initialization
	void Start () {
        r = GameObject.Find("Player").GetComponent<Rigidbody>();
        jump_flag = false;
        player_pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        GetRadian(GameObject.Find("Cube1").transform.position.x, GameObject.Find("Cube1").transform.position.z, transform.position.x, transform.position.z);
        float angle = radian * 180.0f / Mathf.PI + 90.0f;

        if (move_flag == false)
        {
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        BoostCounter.Count = energy;

        // ブースト処理
        if (Input.GetKey("left shift") && energy >= 25.0f && !trigger_flag)
        {
            if (Input.GetKey("up"))
            {
                Vector3 num = new Vector3(move_force * Mathf.Cos(-radian), 0, move_force * Mathf.Sin(-radian));
                r.AddForce(num, ForceMode.Impulse);
            }
            else if (Input.GetKey("down"))
            {
                Vector3 num = new Vector3(-move_force * Mathf.Cos(-radian), 0, -move_force * Mathf.Sin(-radian));
                r.AddForce(num, ForceMode.Impulse);
            }
            else if (Input.GetKey("left"))
            {
                Vector3 num = new Vector3(move_force * Mathf.Cos(radian - 90.0f * 3.14f / 180.0f), 0, -move_force * Mathf.Sin(radian - 90.0f * 3.14f / 180.0f));
                r.AddForce(num, ForceMode.Impulse);
            }
            else if (Input.GetKey("right"))
            {
                Vector3 num = new Vector3(move_force * Mathf.Cos(radian + 90.0f * 3.14f / 180.0f), 0, -move_force * Mathf.Sin(radian + 90.0f * 3.14f / 180.0f));
                r.AddForce(num, ForceMode.Impulse);
            }
            else 
            {
                Vector3 num = new Vector3(move_force * Mathf.Cos(-radian), 0, move_force * Mathf.Sin(-radian));
                r.AddForce(num, ForceMode.Impulse);
            }
            energy -= 25.0f;
            energy_cd = 10.0f;
            trigger_flag = true;
        }
        // キー入力による移動
        else if (Input.GetKey("up"))
        {
            transform.Translate(0, 0, speed);
            move_flag = true;
        }
        else if (Input.GetKey("down"))
        {
            transform.Translate(0, 0, -speed);
            move_flag = true;
        }
        else if (Input.GetKey("left"))
        {
            transform.Translate(-speed, 0, 0);
            move_flag = true;
        }
        else if (Input.GetKey("right"))
        {
            transform.Translate(speed, 0, 0);
            move_flag = true;
        }
        else
        {
            move_flag = false;
        }

        // エネルギー回復処理------
        if (!Input.GetKey("left shift"))
        {
            trigger_flag = false;
        }
        if (energy_cd <= 0.0f && energy < 100.0f)
        {
            energy++;
        }
        else 
        {
            energy_cd -= 1.0f;
        }
        // ------


        // ジャンプ処理
        if (Input.GetKey("space"))
        {
            if (jump_flag == false)
            {
                r.AddForce(jump_force, ForceMode.Impulse);
                jump_flag = true;
            }
        }

        // 弾発射
        if (Input.GetKey("z"))
        {
        }

        // 左クリック
        if (Input.GetMouseButton(0))
        {
            // マウスの座標を取得
            //mouse_pos = Input.mousePosition;
        }
	}

    // 衝突判定
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Cube")
        {
            jump_flag = false;
        }
    }

    // 二点から角度を求める
    float GetRadian(float x_1, float z_1, float x_2, float z_2)
    {
        radian = Mathf.Atan2(z_2 - z_1, x_1 - x_2);
        return radian;
    }
}
