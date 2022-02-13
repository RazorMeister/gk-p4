
namespace gk_p4.Animations
{
    internal interface IAnimation
    {
        public bool IsOn { get; set; }

        public void Tick(Scene.Scene scene);

        public void Reset(Scene.Scene scene);
    }
}
