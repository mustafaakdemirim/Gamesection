using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.ADONET;
using DataAccess.Concrete.DAPPER;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Context;
using Entity.POCO;

namespace TEST
{
    class Program
    {
        

      

        static void Main(string[] args)
        {


            
            AdoGameCategory game = new AdoGameCategory();
            GameCategory category = new GameCategory() { GameID = 10, CategoryID = 1 };
            var result = game.Update(category, 1, 10);
            if (result)
            {
                Console.WriteLine("Güncellendi");

            }
            else
            {
                Console.WriteLine("Güncellenemedi");
            }

            ////byte[] salt;
            ////byte[] bytes;
            //string password = "msty2001";
            ////using (Rfc2898DeriveBytes rfc2898DeriveByte = new Rfc2898DeriveBytes(password, 16, 1000))
            ////{
            ////    salt = rfc2898DeriveByte.Salt;
            ////    bytes = rfc2898DeriveByte.GetBytes(32);
            ////}
            ////byte[] numArray = new byte[49];
            ////Buffer.BlockCopy(salt, 0, numArray, 1, 16);
            ////Buffer.BlockCopy(bytes, 0, numArray, 17, 32);
            ////Console.WriteLine(Convert.ToBase64String(numArray));
            //string hashedPassword = "AQAAAAEAACcQAAAAEKlW2MNO6sqB9BbGyWNSu7f5+reYml6ZUDUGj3L0pV/AvljvI6uSfnUljNhkCuJOQg==";
            //string newpassword = "AQAAAAEAACcQAAAAEOOXz2XwQfvBEHpsK+1tbvIX/BtfBJraIiY/rtOCnXjgm69hj0aJTLRr/aP3OYbcig==";
            //byte[] buffer4;
            //byte[] src = Convert.FromBase64String(hashedPassword);
            //byte[] dst = new byte[0x10];
            //Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            //byte[] buffer3 = new byte[0x20];
            //Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            //using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            //{
            //    buffer4 = bytes.GetBytes(0x20);
            //}
            //if(Byte.Equals(buffer3, buffer4))
            //{
            //    Console.WriteLine("Eşleşti");
            //}
            //else
            //{
            //    Console.WriteLine("Eşleşmedi");
            //}

        }
    }
}
