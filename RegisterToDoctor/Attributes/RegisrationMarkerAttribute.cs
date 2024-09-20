namespace RegisterToDoctor.Attributes
{
    public class RegisrationMarkerAttribute : Attribute
    {
        public ServiceLifetime Lifetime { get; }

        public RegisrationMarkerAttribute(ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            Lifetime = lifetime;
        }
    }
}
