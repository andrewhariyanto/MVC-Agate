namespace Example.Scene.Gameplay.Message
{
    public struct UpdateBladderMessage
    {
        public float Bladder { get; private set; }
        public UpdateBladderMessage(float bladder)
        {
            Bladder = bladder;
        }
    }
}
