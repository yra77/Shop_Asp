

using System.Collections;


namespace Shop_Asp.Models
{
    public class Colors : IEnumerable<string>
    {

        private List<string> Color;


        public Colors()
        {
            Color = new List<string>(new string[] { "White", "Black", "Red", "Blue", "Gray", "Green", "Yellow", "Pink" });
        }


        public IEnumerator<string> GetEnumerator()
        {
            foreach (string val in Color)
            {
                yield return val;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
