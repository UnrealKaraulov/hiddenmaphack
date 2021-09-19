using System;
using System.Security.Principal;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Threading;
using System.Web;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

//[game.dll+AB6214]+17c
namespace UnkownHiddenMaphackLoader
{
    public partial class Loader : Form
    {

        private bool abool = false;

        private PrivateFontCollection myFonts;

        //СЮДА ЗАПИСАТЬ Полученный HWID
        private string YouHwid = "1508-5330-8A2B-70C3-9B4C-4BED-6E88-549C";

        Bitmap currentbitmap = null;


        Bitmap priveticcup = null;
        Bitmap priveticcup2 = null;


        public Loader ( )
        {
            InitializeComponent( );
        }

        public Loader ( ref bool abool )
        {
            InitializeComponent( );
            this.abool = abool;
        }

        private Form thisform = null;

        private bool aoka = false;


        private void Form1_Load ( object sender , EventArgs e )
        {
            try
            {
                if ( !IsAdministrator( ) )
                {
                    MessageBox.Show( " Нет прав администратора. " , "Предупреждение!" );
                }
            }
            catch
            {
                MessageBox.Show( " Возможно нет прав администратора. " , "Предупреждение!" );

            }



            /*	List<string> lolo = new List<string>();

                lolo.Add( ">" + ProcessHelper.ID( ) + "<" );
                lolo.Add(">"+YouHwid+"<");
			
                File.WriteAllLines("test.txt",lolo.ToArray());*/

            if ( ProcessHelper.ID( ) == YouHwid )
            {
                thisform = this;
                new Thread( MinimapRenderEngine ).Start( );
            }
            else
            {
                Environment.Exit( 0 );
                Application.Exit( );
            }


            if ( ProcessHelper.ID( ) == YouHwid )
            {
                aoka = true;
            }

            myFonts = new PrivateFontCollection( );
            byte [ ] font = Properties.Resources.Ace_Records;
            IntPtr fontBuffer = Marshal.AllocCoTaskMem( font.Length );
            Marshal.Copy( font , 0 , fontBuffer , font.Length );
            myFonts.AddMemoryFont( fontBuffer , font.Length );



        }
        public static bool IsAdministrator ( )
        {
            return ( new WindowsPrincipal( WindowsIdentity.GetCurrent( ) ) )
                    .IsInRole( WindowsBuiltInRole.Administrator );
        }

        private int wndoff1 = 1;
        private int wndoff2 = 0;

        private bool pleasewait = false;

        private void UpdateMMH ( )
        {
            if ( thisform != null )
            {
                if ( pleasewait )
                    return;


                pleasewait = true;
                wndoff1++;
                wndoff2++;

                if ( wndoff2 > 20 )
                    wndoff2 = 0;

                string x1 = @"\";
                string x2 = @"/";

                if ( wndoff2 < 5 )
                {
                    x1 = @"\";
                    x2 = @"/";
                }
                else if ( wndoff2 < 10 )
                {
                    x1 = @"|";
                    x2 = @"—";
                }
                else if ( wndoff2 < 15 )
                {
                    x1 = @"/";
                    x2 = @"\";
                }
                else
                {
                    x1 = @"—";
                    x2 = @"|";
                }



                string tts = x1 + " Absol,  MISERY" + x2 + " [ v . 5.0 ] • D3scene " + "-";


                if ( wndoff1 > tts.Length - 1 )
                    wndoff1 = 1;

                if ( !OptimizeSpeed.Checked )
                {
                    tts = tts.Substring( wndoff1 , tts.Length - 1 - wndoff1 ) + tts.Substring( 0 , wndoff1 );
                    thisform.Text = tts;
                }
                if ( currentbitmap == null )
                {
                    currentbitmap = new Bitmap( PanelMinimap.BackgroundImage );
                    priveticcup = new Bitmap( PanelMinimap.BackgroundImage );
                    Graphics g = Graphics.FromImage( priveticcup );
                    SolidBrush bralies = new SolidBrush( Color.White );
                    FontFamily fam = myFonts.Families [ 0 ];

                    Font fnt = new Font( fam , 22 , FontStyle.Bold );
                    g.DrawString( "Universal\n   Hidden\n      Hack v5b" , fnt , bralies , 20 , 30 );
                    priveticcup2 = new Bitmap( priveticcup );
                    fnt = new Font( "Arial" , 20 , FontStyle.Italic );
                    g.DrawString( "Разработчики\n   антихака\n      идиоты :D" , fnt , bralies , 50 , 150 );

                }


                if ( InternalMiniMap.Checked && currentbitmap != null )
                {
                    PanelMinimap.BackgroundImage = currentbitmap;
                }
                pleasewait = false;
            }
        }


        private void Loader_FormClosed ( object sender , FormClosedEventArgs e )
        {
            while ( abool )
            {
                Thread.Sleep( 1000 );
            }


            Environment.Exit( 0 );
        }

        Random rnd = new Random( );


        private void checkBox2_CheckedChanged ( object sender , EventArgs e )
        {
            if ( TradeEnabled.Checked )
            {
                MessageBox.Show( " Оффсет \"TradeHack\" не скрыт, \nвозможно обнаружение антихаком! " , " Предупреждение! " );
            }
        }

        private bool Started = false;

        private ProcessMemory wc3mem = null;



        private void MinimapRenderEngine ( )
        {
            while ( true )
            {
                Thread.Sleep( 200 );
                MH_Thread( );
            }
        }

        private void StartMapHack_Click ( object sender , EventArgs e )
        {
            if ( !aoka )
            {
                return;
            }

            if ( !Started )
            {
                /*  if ( !File.Exists( "UnHiHa.dll" ) )
                  {
                      MessageBox.Show( "Нет главного модуля!" , "Ошибка" );
                  }
                  else
                  {*/
                if ( Process.GetProcessesByName( "war3" ).Length < 1 )
                {
                    MessageBox.Show( "Не найден варкрафт!" , "Ошибка" );
                }
                else
                {
                    //ew  Syringe.Injector tmpinject;
                    try
                    {
                        wc3mem = new ProcessMemory( Process.GetProcessesByName( "war3" ) [ 0 ].Id );
                        wc3mem.StartProcess( );
                        /* tmpinject = new Syringe.Injector( Process.GetProcessesByName( "war3" ) [ 0 ] );
                         tmpinject.EjectOnDispose = false;
                         tmpinject.InjectLibraryW( Directory.GetCurrentDirectory( ) + "\\" + "UnHiHa.dll" , Directory.GetCurrentDirectory( ) + "\\" + "UnHiHa.dll" );
                         tmpinject.Dispose( );*/
                    }
                    catch
                    {
                        wc3mem = null;
                        MessageBox.Show( "Произошла ошибка запуска! Повторите попытку!" , "Ошибка" );
                        return;
                    }

                    /* try
                     {
                         if ( wc3mem.DllImageAddress( "UnHiHa.dll" ) > 0 )
                         {*/
                    Started = true;
                    StartMapHack.Text = "Oтключить";
                    /*     }
                     }
                     catch
                     {
                         try
                         {
                             tmpinject = new Syringe.Injector( Process.GetProcessesByName( "war3" ) [ 0 ] );
                             tmpinject.EjectLibraryXXX( "UnHiHa.dll" );
                             wc3mem = null;
                             tmpinject.Dispose( );
                                
                         }
                         catch
                         {

                         }

                     }*/
                }
                /* }
                 */
            }
            else
            {
                if ( Process.GetProcessesByName( "war3" ).Length < 1 )
                {

                }
                else
                {

                    /*  try
                      {
                          Syringe.Injector tmpinject = new Syringe.Injector( Process.GetProcessesByName( "war3" ) [ 0 ] );
                          tmpinject.EjectLibraryXXX(  "UnHiHa.dll" );
                          tmpinject.Dispose( );
                      }
                      catch
                      {

                      }

                      */
                }


                wc3mem = null;
                Started = false;
                StartMapHack.Text = "Bключить";
            }

        }


        private void Set ( ref byte aByte , int pos , bool value )
        {
            if ( value )
            {
                //left-shift 1, then bitwise OR
                aByte = ( byte ) ( aByte | ( 1 << pos ) );
            }
            else
            {
                //left-shift 1, then take complement, then bitwise AND
                aByte = ( byte ) ( aByte & ~( 1 << pos ) );
            }
        }

        private bool Get ( byte aByte , int pos )
        {
            //left-shift 1, then bitwise AND, then check for non-zero
            return ( ( aByte & ( 1 << pos ) ) != 0 );
        }


        // bool needminimapdisable = false;
        private bool initinternalminimap = false;
        private Bitmap internalminimapbitmap;


        struct DrawStruct
        {
            public int X;
            public int Y;
            public Color color;
            public int alenmy;
            public int wardtype;
            public bool IsHero;
            public bool IsRune;
            public int team;
            public string ID;
        }


        private int showinitimage = 25;


        [DllImport( "kernel32.dll" , CharSet = CharSet.Auto )]
        public static extern IntPtr GetModuleHandle ( string lpModuleName );

        private void MH_Thread ( )
        {
            try
            {
                worked = true;
                if ( GetModuleHandle( "W" + "r" + "i" + "t" + "e" + "P" + "r" + "o" + "c" + "e" + "s" + "s" + "M" + "e" + "m" + "o" + "r" + "y" + "_" + "H" + "o" + "o" + "k" + "." + "d" + "l" + "l" ).ToInt32( ) > 0 )
                {
                    worked = false;
                    return;
                }


                if ( Started )
                {
                    if ( Process.GetProcessesByName( "war3" ).Length > 0 )
                    {

                        WarcraftFound.ForeColor = Color.Black;

                        if ( wc3mem != null )
                        {
                            wc3mem.UpdatePointer( );
                            try
                            {
                                /* if ( wc3mem.DllImageAddress( "UnHiHa.dll" ) > 0 )
                                 {*/

                                /*  if ( new FileInfo( Directory.GetCurrentDirectory( ) + "\\" + "UnHiHa.dll" ).Length != 90112 )
                                  {
                                      MaphackDllInject.ForeColor = Color.Red;
                                  }
                                  else
                                  {*/
                                MaphackDllInject.ForeColor = Color.Black;

                                int gamedlladdress = wc3mem.DllImageAddress( "Game.dll" );

                                if ( gamedlladdress > 0 )
                                {
                                    GameDllFound.ForeColor = Color.Black;
                                    int gdlad = gamedlladdress;

                                    int ingame1 = wc3mem.ReadInt( 0xACF678 + gdlad );
                                    int ingame2 = wc3mem.ReadInt( 0xAB62A4 + gdlad );

                                    if ( ingame1 > 0 || ingame2 > 0 )
                                    {
                                        int playerslot = wc3mem.ReadInt( 0xAB65F4 + gamedlladdress );


                                        int oldsl = playerslot;



                                        List<DrawStruct> filldrawstruct = new List<DrawStruct>( );
                                        filldrawstruct.Clear( );


                                        /* if ( ExpVis.Checked )
                                         {
                                             //[[AB65F4+game.dll]+34]+38

                                             int exvs = wc3mem.ReadInt( playerslot + 0x34 );
                                             wc3mem.WriteShort( exvs + 0x38 , 1 );
                                         }*/




                                        playerslot = wc3mem.ReadShort( playerslot + 0x28 );

                                        if ( CamHack.Checked )
                                        {
                                            try
                                            {

                                                /* int distance = 2000;
                                                 int.TryParse( CamDist.Text , out distance );

                                                 int xx = 0 ;


                                                 int pladad = oldsl + ( xx * 4 ) + 0x58;


                                                 pladad = wc3mem.ReadInt( pladad );
                                                 // MessageBox.Show( pladad.ToString( ) , "1" );
                                                 pladad = pladad + 0x444;
                                                 // MessageBox.Show( pladad.ToString( ) , "2" );
                                                 pladad = pladad + 0x0c;
                                                 // MessageBox.Show( pladad.ToString( ) , "3" );
                                                 pladad = wc3mem.ReadInt( pladad );






                                                 //  MessageBox.Show( pladad.ToString( ) , "4" );
                                                 int unin = wc3mem.ReadInt( gdlad + 0xAB7788 );
                                                 //   MessageBox.Show( unin.ToString( ) , "11" );
                                                 unin = wc3mem.ReadInt( unin + 0x2c );
                                                 //   MessageBox.Show( unin.ToString( ) , "22" );
                                                 unin = unin + ( pladad * 8 ) + 4;
                                                 //   MessageBox.Show( unin.ToString( ) , "33" );
                                                 unin = wc3mem.ReadInt( unin );
                                                 //  MessageBox.Show( unin.ToString( ) , "44" );


                                                 wc3mem.WriteFloat( unin + 0x78 , ( float ) distance );

                                                 //  MessageBox.Show( pladad.ToString( ) , "4" );
                                                 unin = wc3mem.ReadInt( gdlad + 0xAB7788 );
                                                 //   MessageBox.Show( unin.ToString( ) , "11" );
                                                 unin = wc3mem.ReadInt( unin + 0xc );
                                                 //   MessageBox.Show( unin.ToString( ) , "22" );
                                                 unin = unin + ( pladad * 8 ) + 4;
                                                 //   MessageBox.Show( unin.ToString( ) , "33" );
                                                 unin = wc3mem.ReadInt( unin );
                                                 //  MessageBox.Show( unin.ToString( ) , "44" );


                                                 wc3mem.WriteFloat( unin + 0x78 , ( float ) distance );





                                                 */


                                            }
                                            catch
                                            {

                                            }

                                        }

                                        IngameFound.ForeColor = Color.Black;
                                        gdlad += wc3mem.PointerPointer( true );
                                        gdlad = wc3mem.ReadInt( gdlad );
                                        if ( gdlad != 0 )
                                        {
                                            gdlad += wc3mem.PointerPointer( );
                                            gdlad = wc3mem.ReadInt( gdlad );
                                            if ( gdlad != 0 )
                                            {

                                                int gdict = wc3mem.PAGE_WLITEREAD2 + gdlad;

                                                try
                                                {
                                                    gdict = wc3mem.ReadInt( gdict );

                                                    if ( gdict != 0 )
                                                    {

                                                        int gdiof = wc3mem.PAGE_READWLITE2 + gdlad;
                                                        gdiof = wc3mem.ReadInt( gdiof );

                                                        for ( int i = 0 ; i < gdict ; i++ )
                                                        {
                                                            int ciof = gdiof + i * 4;
                                                            ciof = wc3mem.ReadInt( ciof );

                                                            int checkifneed = ciof + wc3mem.Pointer( true , 1 , 2 , 3 );
                                                            float ihp = wc3mem.ReadFloat( checkifneed );
                                                            if ( ihp < 50.0f && ihp > 0.0f )
                                                            {
                                                                int inmof = ciof + wc3mem.Pointer( true , 1 , 2 , 3 , 4 );
                                                                string inme = wc3mem.ReadStringWarcraft( inmof , 4 );

                                                                int idoff = ciof + wc3mem.Pointer( true , 1 , 2 , 3 , 4 , 5 );
                                                                idoff = wc3mem.ReadInt( idoff );
                                                                float idx = wc3mem.ReadFloat( idoff + wc3mem.Pointer( true , 1 , 2 , 3 , 4 , 5 , 6 ) );
                                                                float idy = wc3mem.ReadFloat( idoff + wc3mem.Pointer( true , 1 , 2 , 3 , 4 , 5 , 6 , 7 ) );
                                                                if ( idx > 0.0f || idy > 0.0f || idx < 0.0f )
                                                                {
                                                                    idx += 7500.0f;
                                                                    idy += 7900.0f;

                                                                    idx /= 59;
                                                                    idy /= 59;

                                                                    idy = 256 - idy;

                                                                    DrawStruct tmpdrstr = new DrawStruct( );
                                                                    tmpdrstr.wardtype = 0;
                                                                    tmpdrstr.IsRune = true;
                                                                    tmpdrstr.IsHero = false;
                                                                    tmpdrstr.X = Convert.ToInt32( idx );
                                                                    tmpdrstr.Y = Convert.ToInt32( idy );
                                                                    tmpdrstr.ID = inme;
                                                                    filldrawstruct.Add( tmpdrstr );
                                                                }
                                                            }
                                                        }



                                                    }

                                                }
                                                catch
                                                {

                                                }

                                                int gduct = wc3mem.PAGE_WLITEREAD + gdlad;
                                                gduct = wc3mem.ReadInt( gduct );
                                                if ( gduct != 0 )
                                                {
                                                    int gduof = wc3mem.PAGE_READWLITE + gdlad;
                                                    gduof = wc3mem.ReadInt( gduof );

                                                    if ( gduof != 0 )
                                                    {
                                                        for ( int i = 0 ; i < gduct ; i++ )
                                                        {
                                                            int cuof = gduof + i * 4;
                                                            if ( cuof != 0 )
                                                            {

                                                                cuof = wc3mem.ReadInt( cuof );
                                                                if ( cuof != 0 )
                                                                {
                                                                    byte data = wc3mem.ReadByte( cuof + 32 );
                                                                    Set( ref data , 4 , true );

                                                                    if ( MainMap.Checked )
                                                                    {
                                                                        wc3mem.WriteByte( cuof + 32 , data );

                                                                    }
                                                                    /* if ( MainMap.Checked )
                                                                     {

                                                                         byte dada = wc3mem.ReadByte( cuof + 96 );

                                                                         if ((dada & 1 )== 0)
                                                                         {
                                                                             dada |= 1;
                                                                         }

                                                                         wc3mem.WriteByte( cuof + 96 , dada );
                                                                     }*/

                                                                    int slot = wc3mem.ReadInt( cuof + 88 );


                                                                    float unitx = wc3mem.ReadFloat( 0x284 + cuof );
                                                                    float unity = wc3mem.ReadFloat( 0x288 + cuof );

                                                                    unitx += 7800.0f;
                                                                    unity += 7900.0f;

                                                                    unitx /= 59;
                                                                    unity /= 59;

                                                                    unity = 256 - unity;

                                                                    DrawStruct tmpdrstr = new DrawStruct( );



                                                                    uint ishero = wc3mem.ReadUInt( cuof + 48 );
                                                                    ishero = ishero >> 24;
                                                                    ishero = ishero - 64;

                                                                    if ( playerslot < 6 )
                                                                        tmpdrstr.team = 1;
                                                                    else
                                                                        tmpdrstr.team = 2;

                                                                    if ( ishero < 0x19 )
                                                                        tmpdrstr.IsHero = true;
                                                                    else
                                                                        tmpdrstr.IsHero = false;
                                                                    if ( playerslot == slot )
                                                                        tmpdrstr.alenmy = 0;
                                                                    else if ( playerslot < 6 && slot < 6 )
                                                                        tmpdrstr.alenmy = 1;
                                                                    else if ( playerslot > 5 && slot < 12 && slot > 5 )
                                                                        tmpdrstr.alenmy = 1;
                                                                    else if ( slot == 12 )
                                                                        tmpdrstr.alenmy = 3;
                                                                    else
                                                                        tmpdrstr.alenmy = 2;





                                                                    int red , green , blue;
                                                                    slot++;
                                                                    switch ( slot )
                                                                    {
                                                                        case 1:
                                                                            red = 255; green = 2; blue = 2;
                                                                            break;
                                                                        case 2:
                                                                            red = 0; green = 65; blue = 255;
                                                                            break;
                                                                        case 3:
                                                                            red = 27; green = 229; blue = 184;
                                                                            break;
                                                                        case 4:
                                                                            red = 83; green = 0; blue = 128;
                                                                            break;
                                                                        case 5:
                                                                            red = 255; green = 255; blue = 0;
                                                                            break;
                                                                        case 6:
                                                                            red = 254; green = 137; blue = 13;
                                                                            break;
                                                                        case 7:
                                                                            red = 31; green = 191; blue = 0;
                                                                            break;
                                                                        case 8:
                                                                            red = 228; green = 90; blue = 170;
                                                                            break;
                                                                        case 9:
                                                                            red = 148; green = 149; blue = 150;
                                                                            break;
                                                                        case 10:
                                                                            red = 125; green = 190; blue = 241;
                                                                            break;
                                                                        case 11:
                                                                            red = 15; green = 97; blue = 69;
                                                                            break;
                                                                        default:
                                                                            red = 77; green = 41; blue = 3;
                                                                            break;
                                                                    }
                                                                    slot--;
                                                                    if ( ColoredHeroes.Checked )
                                                                        tmpdrstr.color = Color.FromArgb( red , green , blue );
                                                                    else
                                                                    {
                                                                        if ( tmpdrstr.alenmy == 1 )
                                                                            tmpdrstr.color = Color.FromArgb( 10 , 255 , 10 );
                                                                        else if ( tmpdrstr.alenmy == 2 )
                                                                            tmpdrstr.color = Color.FromArgb( 255 , 10 , 10 );
                                                                    }

                                                                    tmpdrstr.X = Convert.ToInt32( unitx );
                                                                    tmpdrstr.Y = Convert.ToInt32( unity );

                                                                    uint unittype = wc3mem.ReadUInt( cuof + 0x30 );

                                                                    tmpdrstr.wardtype = 0;

                                                                    if ( unittype == 1865429044 )
                                                                        tmpdrstr.wardtype = 1;
                                                                    if ( unittype == 1868921189 )
                                                                        tmpdrstr.wardtype = 2;

                                                                    uint uflag = wc3mem.ReadUInt( cuof + 0x5C );
                                                                    /*   if ( MainMap.Checked )
                                                                       {
                                                                           if ( tmpdrstr.alenmy == 2 )
                                                                           {
                                                                               if ( ( uflag & 0x1000000u ) != 0 )
                                                                               {
                                                                                   uflag ^= 0x1000000u;
                                                                                   wc3mem.WriteUInt( cuof + 0x5C , uflag );
                                                                               }
                                                                           }
                                                                       }*/

                                                                    if ( uflag != 0x1001u )
                                                                    {
                                                                        if ( ( uflag & 0x100u ) == 0 )
                                                                        {
                                                                            if ( ( uflag & 0x40000000u ) == 0 )
                                                                            {
                                                                                if ( uflag != 0 )
                                                                                {
                                                                                    tmpdrstr.ID = "";
                                                                                    filldrawstruct.Add( tmpdrstr );
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                    ErrorID.Text = "1";


                                                            }
                                                            else
                                                                ErrorID.Text = "2";

                                                        }
                                                    }
                                                    else
                                                        ErrorID.Text = "3";
                                                }
                                                else
                                                    ErrorID.Text = "4";

                                                if ( TradeEnabled.Checked )
                                                {
                                                    gdlad = gamedlladdress;
                                                    gdlad += 0xAB59C4;
                                                    uint oldprot = wc3mem.ProtectOffset( gdlad , 4 , wc3mem.PAGE_EXECUTE_READWRITE );
                                                    wc3mem.WriteInt( gdlad , gdlad );
                                                    wc3mem.ProtectOffset( gdlad , 4 , oldprot );
                                                }
                                            }
                                            else
                                                ErrorID.Text = "5";

                                        }
                                        else
                                            ErrorID.Text = "6";



                                        if ( InternalMiniMap.Checked || MiniMap.Checked && filldrawstruct.Count > 0 )
                                        {
                                            if ( !initinternalminimap )
                                            {
                                                internalminimapbitmap = new Bitmap( PanelMinimap.BackgroundImage );
                                                initinternalminimap = true;
                                            }

                                            currentbitmap = new Bitmap( internalminimapbitmap );
                                            Graphics g = Graphics.FromImage( currentbitmap );
                                            SolidBrush bralies = new SolidBrush( Color.Green );
                                            SolidBrush brenemy = new SolidBrush( Color.Red );
                                            SolidBrush brneutr = new SolidBrush( Color.DarkBlue );
                                            SolidBrush brmy = new SolidBrush( Color.White );


                                            SolidBrush blackbrush = new SolidBrush( Color.Black );




                                            foreach ( DrawStruct drs in filldrawstruct )
                                            {
                                                try
                                                {
                                                    if ( !drs.IsRune && !drs.IsHero && drs.wardtype == 0 )
                                                    {
                                                        if ( drs.alenmy == 0 )
                                                        {
                                                            g.FillEllipse( brmy , drs.X - 4 , drs.Y , 5 , 5 );
                                                        }
                                                        else if ( drs.alenmy == 1 )
                                                        {
                                                            if ( !DrawOnlyEnemy.Checked )
                                                            {
                                                                if ( drs.team == 1 )
                                                                    g.FillEllipse( brenemy , drs.X - 4 , drs.Y , 5 , 5 );
                                                                else
                                                                    g.FillEllipse( bralies , drs.X - 4 , drs.Y , 5 , 5 );
                                                            }
                                                        }
                                                        else if ( drs.alenmy == 2 )
                                                        {
                                                            if ( drs.team == 1 )
                                                                g.FillEllipse( bralies , drs.X - 4 , drs.Y , 5 , 5 );
                                                            else
                                                                g.FillEllipse( brenemy , drs.X - 4 , drs.Y , 5 , 5 );
                                                        }
                                                        else if ( drs.alenmy == 3 )
                                                        {
                                                            g.FillEllipse( brneutr , drs.X - 3 , drs.Y , 5 , 5 );
                                                        }
                                                    }
                                                }
                                                catch
                                                {

                                                }


                                            }


                                            foreach ( DrawStruct drs in filldrawstruct )
                                            {
                                                try
                                                {

                                                    if ( drs.wardtype > 0 )
                                                    {
                                                        if ( drs.alenmy == 2 )
                                                        {
                                                            if ( drs.wardtype == 1 )
                                                                g.DrawImage( Properties.Resources.bulls_eye , drs.X - 24 , drs.Y - 24 , 48 , 48 );
                                                            else
                                                                g.DrawImage( Properties.Resources.bulls_eye_blue , drs.X - 24 , drs.Y - 24 , 48 , 48 );
                                                        }
                                                    }

                                                }
                                                catch
                                                {


                                                }

                                            }

                                            foreach ( DrawStruct drs in filldrawstruct )
                                            {
                                                try
                                                {
                                                    if ( drs.IsRune )
                                                    {

                                                        //     MessageBox.Show( drs.ID );

                                                        /*
                                                        K00I - double damage
                                                        800I -- regen
                                                        J00I - INVIS
                                                        600I -- haste
                                                        700I -- illusion */
                                                        g.FillRectangle( new SolidBrush( Color.Black ) , drs.X - 4 , drs.Y - 4 , 10 , 10 );
                                                        if ( drs.ID == "K00I" )
                                                            g.FillRectangle( new SolidBrush( Color.Blue ) , drs.X - 4 , drs.Y - 4 , 8 , 8 );
                                                        else if ( drs.ID == "800I" )
                                                            g.FillRectangle( new SolidBrush( Color.Green ) , drs.X - 4 , drs.Y - 4 , 8 , 8 );
                                                        else if ( drs.ID == "J00I" )
                                                            g.FillRectangle( new SolidBrush( Color.BlueViolet ) , drs.X - 4 , drs.Y - 4 , 8 , 8 );
                                                        else if ( drs.ID == "600I" )
                                                            g.FillRectangle( new SolidBrush( Color.Red ) , drs.X - 4 , drs.Y - 4 , 8 , 8 );
                                                        else if ( drs.ID == "700I" )
                                                            g.FillRectangle( new SolidBrush( Color.Orange ) , drs.X - 4 , drs.Y - 4 , 8 , 8 );

                                                    }
                                                }
                                                catch
                                                {

                                                }


                                            }



                                            foreach ( DrawStruct drs in filldrawstruct )
                                            {
                                                try
                                                {
                                                    if ( drs.IsHero )
                                                    {
                                                        //g.FillEllipse( blackbrush , drs.X - 6 , drs.Y - 6 , 12 , 12 );

                                                        /*
                                                        if ( drs.alenmy == 0 )
                                                        {
                                                            g.FillEllipse( brmy , drs.X - 3 , drs.Y - 6 , 12 , 12 );
                                                        }
                                                        else if ( drs.alenmy == 1 )
                                                        {
                                                            if ( drs.team == 1 )
                                                                g.FillEllipse( brenemy , drs.X - 3 , drs.Y - 6 , 12 , 12 );
                                                            else
                                                                g.FillEllipse( bralies , drs.X - 3 , drs.Y - 6 , 12 , 12 );
                                                        }
                                                        else if ( drs.alenmy == 2 )
                                                        {
                                                            if ( drs.team == 1 )
                                                                g.FillEllipse( bralies , drs.X - 3 , drs.Y - 6 , 12 , 12 );
                                                            else
                                                                g.FillEllipse( brenemy , drs.X - 3 , drs.Y - 6 , 12 , 12 );
                                                        }
                                                        else if ( drs.alenmy == 3 )
                                                        {
                                                            g.FillEllipse( brneutr , drs.X - 3 , drs.Y - 6 , 12 , 12 );
                                                        }

                                                        */

                                                        if ( DrawOnlyEnemy.Checked && drs.alenmy == 2 )
                                                        {
                                                            if ( drs.alenmy == 0 )
                                                                g.FillEllipse( brmy , drs.X - 4 , drs.Y - 5 , 12 , 12 );
                                                            else
                                                                g.FillEllipse( new SolidBrush( drs.color ) , drs.X - 4 , drs.Y - 5 , 12 , 12 );
                                                        }
                                                        else
                                                        {
                                                            if ( !DrawOnlyEnemy.Checked )
                                                            {
                                                                if ( drs.alenmy == 0 )
                                                                    g.FillEllipse( brmy , drs.X - 4 , drs.Y - 5 , 12 , 12 );
                                                                else
                                                                    g.FillEllipse( new SolidBrush( drs.color ) , drs.X - 4 , drs.Y - 5 , 12 , 12 );
                                                            }
                                                        }
                                                    }
                                                }
                                                catch
                                                {

                                                }


                                            }



                                            // PanelMinimap.BackgroundImage = currentbitmap;


                                        }


                                        if ( MiniMap.Checked && !pleasewait )
                                        {


                                            //[game.dll+AB6214]+17c
                                            int minimapbackgroundold = wc3mem.ReadInt( gamedlladdress + 0xAB6214 );
                                            int minimapbackground = wc3mem.ReadInt( minimapbackgroundold + 0x17c );

                                            if ( minimapbackground > 0 )
                                            {
                                                minimapbackground += 0x10;
                                                wc3mem.WriteInt( minimapbackgroundold + 0x630 , 0 );
                                                if ( ColoredHeroes.Checked )
                                                    wc3mem.WriteInt( minimapbackgroundold + 0x638 , 1 );
                                                else
                                                    wc3mem.WriteInt( minimapbackgroundold + 0x638 , 0 );
                                                // FIX HERE
                                                if ( showinitimage > 10 )
                                                {
                                                    showinitimage--;
                                                    priveticcup2.RotateFlip( RotateFlipType.RotateNoneFlipY );
                                                    List<byte> dataimg = new List<byte>( ImageToByte( priveticcup2 ) );
                                                    dataimg.RemoveRange( 0 , 58 );
                                                    wc3mem.WriteMem( minimapbackground , dataimg.ToArray( ) );
                                                    priveticcup2.RotateFlip( RotateFlipType.RotateNoneFlipY );
                                                    //priveticcup;
                                                }
                                                else if ( showinitimage > 0 )
                                                {
                                                    showinitimage--;
                                                    priveticcup.RotateFlip( RotateFlipType.RotateNoneFlipY );
                                                    List<byte> dataimg = new List<byte>( ImageToByte( priveticcup ) );
                                                    dataimg.RemoveRange( 0 , 58 );
                                                    wc3mem.WriteMem( minimapbackground , dataimg.ToArray( ) );
                                                    priveticcup.RotateFlip( RotateFlipType.RotateNoneFlipY );
                                                }
                                                else
                                                {
                                                    currentbitmap.RotateFlip( RotateFlipType.RotateNoneFlipY );
                                                    List<byte> dataimg = new List<byte>( ImageToByte( currentbitmap ) );
                                                    dataimg.RemoveRange( 0 , 58 );
                                                    wc3mem.WriteMem( minimapbackground , dataimg.ToArray( ) );
                                                    currentbitmap.RotateFlip( RotateFlipType.RotateNoneFlipY );
                                                }




                                                /* for ( int x = 0 ; x < currentbitmap.Width && x < 256 ; x++ )
                                                 {
                                                     for ( int yy = 0 ; yy < currentbitmap.Height && yy < 256 ; yy++ )
                                                     {
                                                         try
                                                         {
                                                             Color curpix = currentbitmap.GetPixel( x , yy );
                                                             int y = yy * 256 + x;
                                                             int writeaddr = minimapbackground + 4 * y;

                                                             wc3mem.WriteMem( writeaddr , new byte [ ] { curpix.B , curpix.G , curpix.R , 0xFF } );
                                                         }
                                                         catch
                                                         {

                                                       
                                                         }
                                                     }
                                                 }*/
                                            }

                                        }


                                    }
                                    else
                                    {
                                        showinitimage = 35;
                                        IngameFound.ForeColor = Color.Red;
                                    }

                                }
                                else
                                    GameDllFound.ForeColor = Color.Red;
                                /*  }
                                  //here
                              }
                              else
                                  MaphackDllInject.ForeColor = Color.Red;*/
                            }
                            catch
                            {

                            }
                        }
                        else
                        {

                            WarcraftFound.ForeColor = Color.Red;
                            IngameFound.ForeColor = Color.Red;
                            GameDllFound.ForeColor = Color.Red;
                            MaphackDllInject.ForeColor = Color.Red;
                            wc3mem = null;
                            Started = false;
                            StartMapHack.Text = "Bключить";
                        }
                    }
                    else
                    {
                        WarcraftFound.ForeColor = Color.Red;
                        IngameFound.ForeColor = Color.Red;
                        GameDllFound.ForeColor = Color.Red;
                        MaphackDllInject.ForeColor = Color.Red;
                        wc3mem = null;
                        Started = false;
                        StartMapHack.Text = "Bключить";
                    }
                }
                worked = false;
            }
            catch
            {
                worked = false;
                WarcraftFound.ForeColor = Color.Red;
                IngameFound.ForeColor = Color.Red;
                GameDllFound.ForeColor = Color.Red;
                MaphackDllInject.ForeColor = Color.Red;
                wc3mem = null;
                Started = false;
                StartMapHack.Text = "Bключить";
            }
        }


        public static byte [ ] ImageToByte ( Image img )
        {
            byte [ ] byteArray = new byte [ 0 ];
            using ( MemoryStream stream = new MemoryStream( ) )
            {
                img.Save( stream , System.Drawing.Imaging.ImageFormat.Bmp );
                stream.Close( );
                byteArray = stream.ToArray( );
            }
            return byteArray;
        }
        private uint ColorToUInt ( Color color )
        {
            return ( uint ) ( ( color.A << 24 ) | ( color.R << 16 ) |
                          ( color.G << 8 ) | ( color.B << 0 ) );
        }

        private void CamDist_TextChanged ( object sender , EventArgs e )
        {


        }

        private void CamHack_CheckedChanged ( object sender , EventArgs e )
        {
            CamDist.Visible = CamHack.Checked;
            CamDist.Enabled = CamHack.Checked;
            if ( CamHack.Checked )
            {
                MessageBox.Show( " Непроверенная версия камерахака.\n Использовать с осторожностью." , " Предупреждение! " );
            }
        }

        private void SPTIMER_Tick ( object sender , EventArgs e )
        {

            try
            {

                string oudata = new WebClient( ).DownloadString( @"http://iccup.com/dota/profile/view/OH_yMEP_3aPa3a.html" );


                if ( oudata.Length > 5 )
                {
                    if ( oudata.IndexOf( "OH" + "_yM" + "EP_3" + "aPa" + "3a" , StringComparison.Ordinal ) > -1 )
                    {
                        if ( oudata.IndexOf( "123" + "455" + "432" + "1_T" + "yT2" , StringComparison.Ordinal ) > -1 )
                        {
                            Environment.Exit( 0 );
                            Environment.Exit( 0 );
                            Application.Exit( );
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        Environment.Exit( 0 );
                        Environment.Exit( 0 );
                        Application.Exit( );
                    }
                }
                else
                {
                    Environment.Exit( 0 );
                    Environment.Exit( 0 );
                    Application.Exit( );

                }
            }
            catch
            {
                Environment.Exit( 0 );
                Environment.Exit( 0 );
                Application.Exit( );
            }

        }

        private void MiniMap_CheckedChanged ( object sender , EventArgs e )
        {
            if ( MiniMap.Checked )
            {
              //  MessageBox.Show( "Вы включили BETA-функцию MINIMAP DIRECTWRITE.\n Рисует миникарту прямо на варкрафте!" );
            }
        }

        private void ExVis_CheckedChanged ( object sender , EventArgs e )
        {
          /*  if ( ExpVis.Checked )
            {
                MessageBox.Show( "Функция вызывает десинхронизацию. Не использовать без надобности.\n Зря вы ее включили!" );
            }*/

        }

        private void Runes_CheckedChanged ( object sender , EventArgs e )
        {

        }

        private void InternalMiniMap_CheckedChanged ( object sender , EventArgs e )
        {

        }

        private bool worked = false;

        private void Mhtimer1_Tick ( object sender , EventArgs e )
        {
            try
            {
                if ( thisform != null && !worked )
                {
                    try
                    {
                        UpdateMMH( );

                    }
                    catch
                    {
                        pleasewait = false;
                    }
                    MH_Thread( );

                }
            }
            catch
            {

            }
        }

        private void TopChange ( object sender , EventArgs e )
        {
            thisform.TopMost = ChangeTopMost.Checked;
        }

        private void label4_Click ( object sender , EventArgs e )
        {

        }

        private void button1_Click ( object sender , EventArgs e )
        {
            thisform.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void trackBar1_Scroll ( object sender , EventArgs e )
        {
            try
            {
                int udpatespeed = 600 - trackBar1.Value;
                Mhtimer1.Interval = udpatespeed;
            }
            catch
            {

            }
        }

        private PerformanceCounter theCPUCounter =
   new PerformanceCounter( "Process" , "% Processor Time" ,
   Process.GetCurrentProcess( ).ProcessName );

        private void GetCPUUSAGE_Tick ( object sender , EventArgs e )
        {
            try
            {
                if ( !OptimizeSpeed.Checked )
                    CPUUSAGE.Text = "CPU:" + Convert.ToInt32( theCPUCounter.NextValue( ) ) + "%";
                else
                    CPUUSAGE.Text = string.Empty;
            }
            catch
            {

            }
        }
    }
}
