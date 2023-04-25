

using System.Collections;


namespace Shop_Asp.Models
{
    public class Sizes : IEnumerable<string>
    {

        private List<string> Size;


        public Sizes()
        {
            Size = new List<string>(new string[] { "36", "37", "38", "39", "40", "41", "42", "43", "44", "45" });
        }


        public IEnumerator<string> GetEnumerator()
        {
            foreach (string val in Size)
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
