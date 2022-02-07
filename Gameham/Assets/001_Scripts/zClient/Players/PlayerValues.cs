namespace Player
{
    public class PlayerValues : Singleton<PlayerValues>, ISingletonObject
    {
        public const float WalkingSpeed = 2.0f;

        public float speed = WalkingSpeed;
    }
}