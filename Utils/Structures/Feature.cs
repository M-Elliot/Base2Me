using System.Threading;

namespace Base2Me.Utils.Structures
{
    public abstract class Feature
    {
        private Thread FeatureThread;

        protected Feature()
        {
            FeatureThread = new Thread(new ThreadStart(Main));
            FeatureThread.Start();
        }

        public abstract void Main();
    }
}