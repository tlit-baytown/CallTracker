using System.ComponentModel;

namespace CallTracker_Lib.extensions
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Invoke the specified action on the specified control if required.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="action"></param>
        public static void InvokeIfRequired<T>(this T control, Action<T> action) where T : ISynchronizeInvoke
        {
            if (control.InvokeRequired)
                control.Invoke(new Action(() => action(control)), null);
            else
                action(control);
        }
    }
}
