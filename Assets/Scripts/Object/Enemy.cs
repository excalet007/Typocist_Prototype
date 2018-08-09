using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : WordOwner {


    Animator enemy_animator;
    SpriteRenderer enemy_SRend;
    bool is_hit;
    const float hit_duration = 0.3f;
    float hit_timer;

    protected override void Start()
    {
        base.Start();

        enemy_animator = GetComponent<Animator>();
        enemy_SRend = GetComponent<SpriteRenderer>();

        is_hit = false;
        hit_timer = 0;
    }

    protected override void Update()
    {
        base.Update();

        // hurt animation
        if(is_hit)
        {
            float temp = hit_duration - hit_timer;
            enemy_SRend.color = new Color(1, 1- (temp)/hit_duration, 1-(temp)/hit_duration , 1);

            hit_timer -= Time.deltaTime;
            if (hit_timer < 0)
            {
                is_hit = false;
                enemy_SRend.color = Color.white;
            }
        }
    }


    public override void Enter_word()
    {
        base.Enter_word();

        // hit animation
        enemy_animator.SetTrigger("trigHurt");
        is_hit = true;
        hit_timer = hit_duration;

        // camera shake
        CameraController cam = CameraController.Get_CameraController();
        cam.Shake(0.5f, 0.6f);

        // player turn
        Vector3 playerPos = InputController.Get_InputController().Player.position;
        SpriteRenderer playerSRend = InputController.Get_InputController().player_SRenderer;
        if (this.transform.position.x > playerPos.x)
            playerSRend.flipX = false;
        if (this.transform.position.x < playerPos.x)
            playerSRend.flipX = true;
        
        
    }

    

}
