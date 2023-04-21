using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public SwerveMotion swerveMotion;
    public ForwardMotion forwardMotion;

    public PlayerBaseState currentState;
    public PlayerBaseState previousState;
    public PlayerWalkState walkState=new PlayerWalkState();
    public PlayerIdleState idleState=new PlayerIdleState();

    [SerializeField] private MeshRenderer graphics;

    [HideInInspector] public Collision collision;
    [HideInInspector] public Collider other;



    /// <summary>
    /// Called By Game manager to Set Player When Scene Load
    /// </summary>
    public void SetPlayer()
    {
        
        SwitchState(idleState);
    }

    private void Update()
    {
        currentState.UpdateState();
    }
    /// <summary>
    /// Recieve Collision information from Gameobject that has Collider
    /// Pass on the collision information to current state
    /// </summary>
    /// <param name="collision"></param>
    public void CollisionEntered(Collision collision)
    {
        this.collision = collision;
        currentState.OnCollisionEnter();

        switch (collision.gameObject.tag)
        {
            case GameStrings.tag_Ending:
                GameManager.Instance.LevelConmplete();
                currentState.Exit(idleState);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// Recieve Collider information from Gameobject that has Collider
    /// Pass on the Trigger information to current state
    /// </summary>
    /// <param name="other"></param>
    public void TriggerEntered(Collider other)
    {
        this.other = other;
        currentState.OnTriggerEnter();
        switch (other.tag)
        {
            case GameStrings.tag_Eat:
                if (other.gameObject.GetComponent<MeshRenderer>().material.color==graphics.material.color)
                {
                    if (swerveMotion.gameObject.transform.localScale.x > 3f) { return; }
                    Vector3 newScaleBig = new Vector3(swerveMotion.gameObject.transform.localScale.x + 0.2f,
                        swerveMotion.gameObject.transform.localScale.y + 0.2f, swerveMotion.gameObject.transform.localScale.z + 0.2f);
                    swerveMotion.gameObject.transform.localScale = newScaleBig;
                }
                else
                {
                    if (swerveMotion.gameObject.transform.localScale.x <= 1f) { return; }
                    Vector3 newScaleSmall = new Vector3(swerveMotion.gameObject.transform.localScale.x - 0.2f,
                        swerveMotion.gameObject.transform.localScale.y - 0.2f, swerveMotion.gameObject.transform.localScale.z - 0.2f);
                    swerveMotion.gameObject.transform.localScale = newScaleSmall;
                    
                }
                Destroy(other.gameObject);
                int score= (int)(((swerveMotion.gameObject.transform.localScale.x - 1) * 10) / 2);
                GameManager.Instance.UpdateScore(score);

                if (score<=0)
                {
                    GameManager.Instance.LevelLost();
                    currentState.Exit(idleState);
                }

                break;
            
            case GameStrings.tag_Bad:
                //if (transform.localScale.x <= 1f) { return; }
                //Vector3 newScaleSmall = new Vector3(transform.localScale.x - 0.2f,
                //    transform.localScale.y - 0.2f, transform.localScale.z - 0.2f);
                //transform.localScale = newScaleSmall;
                break;
            case GameStrings.tag_ColorChange:
                graphics.material.color = other.GetComponent<MeshRenderer>().material.color;
                break;
            default:
                break;
        }

    } 
    /// <summary>
    /// States Call this to transition to other state
    /// </summary>
    /// <param name="state"></param>
    public void SwitchState(PlayerBaseState state)
    {
        currentState=state;
        currentState.Enter(this);
    }
    /// <summary>
    /// This method is called when user starts playing game
    /// </summary>
    public void GameStart()
    {
        SwitchState(walkState);
    }
}
