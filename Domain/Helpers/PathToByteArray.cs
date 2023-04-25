

using Shop_Asp.Domain.Entities;


namespace Shop_Asp.Domain.Helpers
{
    public class PathToByteArray
    {
        private static int countId = 1;
        //public static List<Photo> GetListByteArray(string str, int id)
        //{

        //    List<Photo> aa = new List<Photo>();

        //    string[] filePath = str.Split(' ');

        //    for (int i = 0; i < filePath.Length; i++)
        //    {
        //        aa.Add(new Photo() { Id = countId, ProductId = id, Image = System.IO.File.ReadAllBytes(filePath[i]) });
        //        countId++;
        //    }
        //    return aa;
        //}

        public static List<Photo> GetList(string str, int id)
        {

            List<Photo> aa = new List<Photo>();

            string[] filePath = str.Split(' ');

            for (int i = 0; i < filePath.Length; i++)
            {
                aa.Add(new Photo() { Id = countId, ProductId = id, Image = filePath[i] });
                countId++;
            }
            return aa;
        }

        public static byte[] GetByteArray(string path)
        {
            return System.IO.File.ReadAllBytes(path);
        }
    }
}
