using GameWorld.Governments;

namespace GameWorld
{
    public class KaiserStadt : Province
    {
        public override void ChangeOwner(Country newOwner)
        {
            if(newOwner.government is GovernmentMonarchy)
            {
                GameManager.instance.grandEmpire.emperor = newOwner;
            }
            base.ChangeOwner(newOwner);
        }
    }
}
