using GameWorld;

namespace EventSystem
{
    public class PeaceOffer : EventCard
    {
        public War affectedWar;

        public Country sender;

        public override void Option1()
        {
            base.Option1();
        }
        public override void Option2()
        {
            affectedWar.EndWar();
        }
    }
}
