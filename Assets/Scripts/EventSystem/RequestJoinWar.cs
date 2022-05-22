namespace EventSystem
{
    public class RequestJoinWar : EventCard
    {
        public War war;
        public Side side;
        public enum Side
        {
            Attacker,
            Defender
        }
        public override void EvaluateAI()
        {
            if (side == Side.Attacker)
            {

            }
        }

        public override void Option2()
        {
            if(side == Side.Attacker)
            {
                war.attackers.Add(receiver);
                receiver.activeWars.Add(war);
            }
        }
    }
}
