using UnityEngine;

public class EnemyHostileState : EnemyState
{
    #region Private Fields
    private const int MAX_RETRY_COUNT = 3;
    private float _destinationUpdateTimer = 0;
    private float _destinationUpdateDelay = 0.5f;
    private int _retryCount = 0;
    #endregion

    #region Public Methods
    public override void Enter(Enemy owner)
    {
        base.Enter(owner);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        _destinationUpdateTimer += Time.deltaTime;
        if (_destinationUpdateTimer >= _destinationUpdateDelay)
        {
            bool success = Owner.CheckTargetPathValididty();
            if (!success)
            {
                _retryCount++;
                if (_retryCount >= MAX_RETRY_COUNT)
                {
                    Owner.SetIdle();
                }
            }
            else
            {
                _retryCount = 0;
                Owner.UpdateDestination();
            }

            _destinationUpdateTimer = 0;
        }
    }
    #endregion
}
