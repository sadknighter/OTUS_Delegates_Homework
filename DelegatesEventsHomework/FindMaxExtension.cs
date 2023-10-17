namespace DelegatesEventsHomework
{
    public static class FindMaxExtension 
    {
        public static T GetMax<T>(this IEnumerable<T> e, Func<T, float> getParameter) where T : class
        {
            var floats = new List<float>();
            
            foreach (var item in e)
            {
                floats.Add( getParameter(item) );
            }

            var maxValue = floats.Max();

            return e.First( x => getParameter(x) == maxValue);
        }
    }
}
