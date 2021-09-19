// Type: ProcessMemory
// Assembly: SharpMagic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E23B772C-417F-419D-85FF-9CD44497601D
// Assembly location: D:\projects\ReadWriteMemoryLibrary\SharpMagic.dll

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;



public class ProcessMemory
{
    private const uint PAGE_EXECUTE = 16U;
    private const uint PAGE_EXECUTE_READ = 32U;
    public uint PAGE_EXECUTE_READWRITE = 64U;
    private const uint PAGE_EXECUTE_WRITECOPY = 128U;
    private const uint PAGE_GUARD = 256U;
    private const uint PAGE_NOACCESS = 1U;
    private const uint PAGE_NOCACHE = 512U;
    public int PAGE_READWLITE = 0x512;
    public int PAGE_WLITEREAD = 0x128;
    public int PAGE_READWLITE2 = 0x512;
    public int PAGE_WLITEREAD2 = 0x128;
    private const uint PAGE_READONLY = 2U;
    private const uint PAGE_READWRITE = 4U;
    private const uint PAGE_WRITECOPY = 8U;
    private const uint PROCESS_ALL_ACCESS = 2035711U;
    protected int BaseAddress;
    protected Process MyProcess;
    protected ProcessModule myProcessModule;
    protected int processHandle;
    protected string ProcessName;
    protected int processID;

    public ProcessMemory ( int processID )
    {
        this.processID = processID;
        PAGE_READWLITE = 0x608;
        PAGE_WLITEREAD = 0x604;
        PAGE_READWLITE2 = 0x608+0x10;
        PAGE_WLITEREAD2 = 0x604 + 0x10;
    }

    public void UpdatePointer( )
    {
        PAGE_READWLITE = 0x608;
        PAGE_WLITEREAD = 0x604;
        PAGE_READWLITE2 = 0x608 + 0x10;
        PAGE_WLITEREAD2 = 0x604 + 0x10;
    }

    public ProcessMemory ( string processname )
    {
        ProcessName = processname;
        this.processID = Process.GetProcessesByName( ProcessName ) [ 0 ].Id;
    }

    /// <summary>
    /// Проверить процесс на доступ.
    /// </summary>
    /// <returns> True если процесс доступен </returns>
    public bool CheckProcess ( )
    {
        return Process.GetProcessesByName( ProcessName ).Length > 0;
    }

    [DllImport( "kernel32.dll" )]
    public static extern bool CloseHandle ( int hObject );
    /// <summary>
    /// Что-то делает со строкой.
    /// </summary>
    /// <param name="mystring">Ваша строка</param>
    /// <returns>Возвращает строку</returns>
    public string CutString ( string mystring )
    {

        char [ ] chArray = mystring.ToCharArray( );
        string str = "";
        for ( int index = 0 ; index < mystring.Length ; ++index )
        {
            if ( ( int ) chArray [ index ] == 32 && ( int ) chArray [ index + 1 ] == 32 || ( int ) chArray [ index ] == 0 )
                return str;
            str = str + chArray [ index ].ToString( );
        }
        return mystring.TrimEnd( new char [ 1 ]
    {
      '0'
    } );
    }
    /// <summary>
    /// Возвращает адрес DLL
    /// </summary>
    /// <param name="dllname">имя dll файла</param>
    /// <returns>Возвращает INT - адрес dll </returns>
    public int DllImageAddress ( string dllname )
    {
        foreach ( ProcessModule processModule in MyProcess.Modules )
        {
            if ( dllname.ToLower( ) == processModule.ModuleName.ToLower( ) )
                return ( int ) processModule.BaseAddress;
        }
        return -1;
    }

    [DllImport( "user32.dll" , EntryPoint = "FindWindow" , SetLastError = true )]
    public static extern int FindWindowByCaption ( int ZeroOnly , string lpWindowName );
    /// <summary>
    /// Получить адрес exe модуля
    /// </summary>
    /// <returns>Возвращает INT - адрес process.exe </returns>
    public int ImageAddress ( )
    {
        BaseAddress = 0;
        myProcessModule = MyProcess.MainModule;
        BaseAddress = ( int ) myProcessModule.BaseAddress;
        return BaseAddress;
    }
    /// <summary>
    /// Получить адрес exe + offset
    /// </summary>
    /// <param name="pOffset">Смещение</param>
    /// <returns>Адрес exe + offset</returns>
    public int ImageAddress ( int pOffset )
    {
        BaseAddress = 0;
        myProcessModule = MyProcess.MainModule;
        BaseAddress = ( int ) myProcessModule.BaseAddress;
        return pOffset + BaseAddress;
    }
    /// <summary>
    /// Получить имя выбранного процесса
    /// </summary>
    /// <returns> Возвращает имя процесса </returns>
    public string MyProcessName ( )
    {
        return ProcessName;
    }

    [DllImport( "kernel32.dll" )]
    public static extern int OpenProcess ( uint dwDesiredAccess , bool bInheritHandle , int dwProcessId );
    /// <summary>
    /// Читает память и возвращает указатель.
    /// </summary>
    /// <param name="AddToImageAddress">Если TRUE то читает exe + offset</param>
    /// <param name="pOffset">Смещение</param>
    /// <returns>Считанный указатель</returns>
    public int Pointer ( bool AddToImageAddress , int pOffset )
    {
        if ( AddToImageAddress )
            return ReadInt( ImageAddress( pOffset ) );
        else return ReadInt( pOffset );
    }

    public int PointerPointer ( )
    {
        return 0x3bc;
    }

    public int Pointer (bool x, int a , int b , int c )
    {
        return 0x58;
    }

    public int Pointer ( bool x , int a , int b , int c , int d )
    {
        return 0x30;
    }


    public int Pointer ( bool x , int a , int b , int c , int d, int e )
    {
        return 0x28;
    }
    public int Pointer ( bool x , int a , int b , int c , int d , int e , int f )
    {
        return 0x88;
    }
    public int Pointer ( bool x , int a , int b , int c , int d , int e , int f, int h)
    {
        return 0x8c;
    }





    //[0C461104+28]+88 - X
    //[0C461104+28]+8C - Y

    public int PointerPointer ( bool needpointer )
    {
        return 0xAB4F80;
    }
    /// <summary>
    /// Получение указателя из списка смещений
    /// </summary>
    /// <param name="Module">Имя модуля</param>
    /// <param name="Offsets">Массив смещений</param>
    /// <returns>Указатель</returns>
    public int Pointer ( string Module , params int [ ] Offsets )
    {
        int num1 = DllImageAddress( Module );
        foreach ( int num2 in Offsets )
            num1 = ReadInt( num1 + num2 );
        return num1;
    }
    /// <summary>
    /// Читает указатель
    /// </summary>
    /// <param name="Module">Имя модуля</param>
    /// <param name="pOffset">Смещение</param>
    /// <returns>Адрес указателя</returns>
    public int Pointer ( string Module , int pOffset )
    {
        return ReadInt( DllImageAddress( Module ) + pOffset );
    }
    /// <summary>
    /// Читает указатель
    /// </summary>
    /// <param name="Module">Имя модуля</param>
    /// <param name="pOffset">Смещение</param>
    /// <param name="pOffset2">Смещение 2</param>
    /// <returns>Адрес указателя</returns>
    public int Pointer ( bool AddToImageAddress , int pOffset , int pOffset2 )
    {
        if ( AddToImageAddress )
            return ReadInt( ImageAddress( ) + pOffset ) + pOffset2;
        else
            return ReadInt( pOffset ) + pOffset2;
    }
    /// <summary>
    /// Прочитать байт
    /// </summary>
    /// <param name="pOffset">Смещение</param>
    /// <returns>вернет Байт</returns>
    public byte ReadByte ( int pOffset )
    {
        byte [ ] buffer = new byte [ 1 ];
        ProcessMemory.ReadProcessMemory( processHandle , pOffset , buffer , 1 , 0 );
        return buffer [ 0 ];
    }

    public byte ReadByte ( bool AddToImageAddress , int pOffset )
    {
        byte [ ] buffer = new byte [ 1 ];
        ProcessMemory.ReadProcessMemory( processHandle , AddToImageAddress ? ImageAddress( pOffset ) : pOffset , buffer , 1 , 0 );
        return buffer [ 0 ];
    }

    public byte ReadByte ( string Module , int pOffset )
    {
        byte [ ] buffer = new byte [ 1 ];
        ProcessMemory.ReadProcessMemory( processHandle , DllImageAddress( Module ) + pOffset , buffer , 1 , 0 );
        return buffer [ 0 ];
    }

    public float ReadFloat ( int pOffset )
    {
        return BitConverter.ToSingle( ReadMem( pOffset , 4 ) , 0 );
    }

    public float ReadFloat ( bool AddToImageAddress , int pOffset )
    {
        return BitConverter.ToSingle( ReadMem( pOffset , 4 , AddToImageAddress ) , 0 );
    }

    public float ReadFloat ( string Module , int pOffset )
    {
        return BitConverter.ToSingle( ReadMem( DllImageAddress( Module ) + pOffset , 4 ) , 0 );
    }

    public int ReadInt ( int pOffset )
    {
        return BitConverter.ToInt32( ReadMem( pOffset , 4 ) , 0 );
    }

    public int ReadInt ( bool AddToImageAddress , int pOffset )
    {
        return BitConverter.ToInt32( ReadMem( pOffset , 4 , AddToImageAddress ) , 0 );
    }

    public int ReadInt ( string Module , int pOffset )
    {
        return BitConverter.ToInt32( ReadMem( DllImageAddress( Module ) + pOffset , 4 ) , 0 );
    }

    public byte [ ] ReadMem ( int pOffset , int pSize )
    {
        byte [ ] buffer = new byte [ pSize ];
        ProcessMemory.ReadProcessMemory( processHandle , pOffset , buffer , pSize , 0 );
        return buffer;
    }

    public byte [ ] ReadMem ( int pOffset , int pSize , bool AddToImageAddress )
    {
        byte [ ] buffer = new byte [ pSize ];
        ProcessMemory.ReadProcessMemory( processHandle , AddToImageAddress ? ImageAddress( pOffset ) : pOffset , buffer , pSize , 0 );
        return buffer;
    }

    [DllImport( "kernel32.dll" )]
    public static extern bool ReadProcessMemory ( int hProcess , int BaseAddress , byte [ ] buffer , int size , int NumberOfBytesRead );

    public short ReadShort ( int pOffset )
    {
        return BitConverter.ToInt16( ReadMem( pOffset , 2 ) , 0 );
    }

    public short ReadShort ( bool AddToImageAddress , int pOffset )
    {
        return BitConverter.ToInt16( ReadMem( pOffset , 2 , AddToImageAddress ) , 0 );
    }

    public short ReadShort ( string Module , int pOffset )
    {
        return BitConverter.ToInt16( ReadMem( DllImageAddress( Module ) + pOffset , 2 ) , 0 );
    }

    public string ReadStringAscii ( int pOffset , int pSize )
    {
        return CutString( Encoding.ASCII.GetString( ReadMem( pOffset , pSize ) ) );
    }

    public string ReadStringAscii ( bool AddToImageAddress , int pOffset , int pSize )
    {
        return CutString( Encoding.ASCII.GetString( ReadMem( pOffset , pSize , AddToImageAddress ) ) );
    }

    public string ReadStringAscii ( string Module , int pOffset , int pSize )
    {
        return CutString( Encoding.ASCII.GetString( ReadMem( DllImageAddress( Module ) + pOffset , pSize ) ) );
    }

    public string ReadStringWarcraft ( int pOffset , int pSize )
    {
        return CutString( Encoding.Default.GetString( ReadMem( pOffset , pSize ) ) );
    }

    public string ReadStringWarcraft ( bool AddToImageAddress , int pOffset , int pSize )
    {
        return CutString( Encoding.Default.GetString( ReadMem( pOffset , pSize , AddToImageAddress ) ) );
    }

    public string ReadStringWarcraft ( string Module , int pOffset , int pSize )
    {
        return CutString( Encoding.Default.GetString( ReadMem( DllImageAddress( Module ) + pOffset , pSize ) ) );
    }

    public string ReadStringUnicode ( int pOffset , int pSize )
    {
        return CutString( Encoding.Unicode.GetString( ReadMem( pOffset , pSize ) ) );
    }

    public string ReadStringUnicode ( bool AddToImageAddress , int pOffset , int pSize )
    {
        return CutString( Encoding.Unicode.GetString( ReadMem( pOffset , pSize , AddToImageAddress ) ) );
    }

    public string ReadStringUnicode ( string Module , int pOffset , int pSize )
    {
        return CutString( Encoding.Unicode.GetString( ReadMem( DllImageAddress( Module ) + pOffset , pSize ) ) );
    }

    public uint ReadUInt ( int pOffset )
    {
        return BitConverter.ToUInt32( ReadMem( pOffset , 4 ) , 0 );
    }

    public uint ReadUInt ( bool AddToImageAddress , int pOffset )
    {
        return BitConverter.ToUInt32( ReadMem( pOffset , 4 , AddToImageAddress ) , 0 );
    }

    public uint ReadUInt ( string Module , int pOffset )
    {
        return BitConverter.ToUInt32( ReadMem( DllImageAddress( Module ) + pOffset , 4 ) , 0 );
    }

    public bool StartProcess ( )
    {
        if ( ProcessName != "" )
        {
            MyProcess = Process.GetProcessById( processID );
            if ( MyProcess.Id == 0 )
            {
                int num = ( int ) MessageBox.Show( ProcessName + " is not running or has not been found. Please check and try again" , "Process Not Found" , MessageBoxButtons.OK , MessageBoxIcon.Hand );
                return false;
            }
            else
            {
                processHandle = ProcessMemory.OpenProcess( 2035711U , false , MyProcess.Id );
                if ( processHandle != 0 )
                    return true;
                int num = ( int ) MessageBox.Show( ProcessName + " is not running or has not been found. Please check and try again" , "Process Not Found" , MessageBoxButtons.OK , MessageBoxIcon.Hand );
                return false;
            }
        }
        else
        {
            int num = ( int ) MessageBox.Show( "Define process name first!" );
            return false;
        }
    }

    [DllImport( "kernel32.dll" )]
    public static extern bool VirtualProtectEx ( int hProcess , int lpAddress , int dwSize , uint flNewProtect , out uint lpflOldProtect );

    public uint ProtectOffset ( int pOffset , int size , uint flNewProtect )
    {
        uint oldprot = 0;
        VirtualProtectEx( processHandle , pOffset , size , flNewProtect , out oldprot );
        return oldprot;
    }


    public void WriteByte ( int pOffset , byte pBytes )
    {
        WriteMem( pOffset , new byte [ 1 ] { pBytes } );
    }

    public void WriteByte ( bool AddToImageAddress , int pOffset , byte pBytes )
    {
        WriteMem( pOffset , new byte [ 1 ] { pBytes } , AddToImageAddress );
    }

    public void WriteByte ( string Module , int pOffset , byte pBytes )
    {
        WriteMem( DllImageAddress( Module ) + pOffset , new byte [ 1 ] { pBytes } );
    }

    public void WriteDouble ( int pOffset , double pBytes )
    {
        WriteMem( pOffset , BitConverter.GetBytes( pBytes ) );
    }

    public void WriteDouble ( bool AddToImageAddress , int pOffset , double pBytes )
    {
        WriteMem( pOffset , BitConverter.GetBytes( pBytes ) , AddToImageAddress );
    }

    public void WriteDouble ( string Module , int pOffset , double pBytes )
    {
        WriteMem( DllImageAddress( Module ) + pOffset , BitConverter.GetBytes( pBytes ) );
    }

    public void WriteFloat ( int pOffset , float pBytes )
    {
        WriteMem( pOffset , BitConverter.GetBytes( pBytes ) );
    }

    public void WriteFloat ( bool AddToImageAddress , int pOffset , float pBytes )
    {
        WriteMem( pOffset , BitConverter.GetBytes( pBytes ) , AddToImageAddress );
    }

    public void WriteFloat ( string Module , int pOffset , float pBytes )
    {
        WriteMem( DllImageAddress( Module ) + pOffset , BitConverter.GetBytes( pBytes ) );
    }

    public void WriteInt ( int pOffset , int pBytes )
    {
        WriteMem( pOffset , BitConverter.GetBytes( pBytes ) );
    }

    public void WriteInt ( bool AddToImageAddress , int pOffset , int pBytes )
    {
        WriteMem( pOffset , BitConverter.GetBytes( pBytes ) , AddToImageAddress );
    }

    public void WriteInt ( string Module , int pOffset , int pBytes )
    {
        WriteMem( DllImageAddress( Module ) + pOffset , BitConverter.GetBytes( pBytes ) );
    }

    public void WriteMem ( int pOffset , byte [ ] pBytes )
    {
        ProcessMemory.WriteProcessMemory( processHandle , pOffset , pBytes , pBytes.Length , 0 );
    }

    public void WriteMem ( int pOffset , byte [ ] pBytes , bool AddToImageAddress )
    {
        ProcessMemory.WriteProcessMemory( processHandle , AddToImageAddress ? ImageAddress( pOffset ) : pOffset , pBytes , pBytes.Length , 0 );
    }

    [DllImport( "kernel32.dll" )]
    public static extern bool WriteProcessMemory ( int hProcess , int lpBaseAddress , byte [ ] buffer , int size , int lpNumberOfBytesWritten );

    public void WriteShort ( int pOffset , short pBytes )
    {
        WriteMem( pOffset , BitConverter.GetBytes( pBytes ) );
    }

    public void WriteShort ( bool AddToImageAddress , int pOffset , short pBytes )
    {
        WriteMem( pOffset , BitConverter.GetBytes( pBytes ) , AddToImageAddress );
    }

    public void WriteShort ( string Module , int pOffset , short pBytes )
    {
        WriteMem( DllImageAddress( Module ) + pOffset , BitConverter.GetBytes( pBytes ) );
    }

    public void WriteStringAscii ( int pOffset , string pBytes )
    {
        WriteMem( pOffset , Encoding.ASCII.GetBytes( pBytes + "\0" ) );
    }

    public void WriteStringAscii ( bool AddToImageAddress , int pOffset , string pBytes )
    {
        WriteMem( pOffset , Encoding.ASCII.GetBytes( pBytes + "\0" ) , AddToImageAddress );
    }

    public void WriteStringAscii ( string Module , int pOffset , string pBytes )
    {
        WriteMem( DllImageAddress( Module ) + pOffset , Encoding.ASCII.GetBytes( pBytes + "\0" ) );
    }
    public void WriteStringWarcraft ( int pOffset , string pBytes )
    {
        WriteMem( pOffset , Encoding.Default.GetBytes( pBytes + "\0" ) );
    }

    public void WriteStringWarcraft ( bool AddToImageAddress , int pOffset , string pBytes )
    {
        WriteMem( pOffset , Encoding.Default.GetBytes( pBytes + "\0" ) , AddToImageAddress );
    }

    public void WriteStringWarcraft ( string Module , int pOffset , string pBytes )
    {
        WriteMem( DllImageAddress( Module ) + pOffset , Encoding.Default.GetBytes( pBytes + "\0" ) );
    }

    public void WriteStringUnicode ( int pOffset , string pBytes )
    {
        WriteMem( pOffset , Encoding.Unicode.GetBytes( pBytes + "\0" ) );
    }

    public void WriteStringUnicode ( bool AddToImageAddress , int pOffset , string pBytes )
    {
        WriteMem( pOffset , Encoding.Unicode.GetBytes( pBytes + "\0" ) , AddToImageAddress );
    }

    public void WriteStringUnicode ( string Module , int pOffset , string pBytes )
    {
        WriteMem( DllImageAddress( Module ) + pOffset , Encoding.Unicode.GetBytes( pBytes + "\0" ) );
    }

    public void WriteUInt ( int pOffset , uint pBytes )
    {
        WriteMem( pOffset , BitConverter.GetBytes( pBytes ) );
    }

    public void WriteUInt ( bool AddToImageAddress , int pOffset , uint pBytes )
    {
        WriteMem( pOffset , BitConverter.GetBytes( pBytes ) , AddToImageAddress );
    }

    public void WriteUInt ( string Module , int pOffset , uint pBytes )
    {
        WriteMem( DllImageAddress( Module ) + pOffset , BitConverter.GetBytes( pBytes ) );
    }

    [Flags]
    public enum ProcessAccessFlags : uint
    {
        All = 2035711U ,
        CreateThread = 2U ,
        DupHandle = 64U ,
        QueryInformation = 1024U ,
        SetInformation = 512U ,
        Synchronize = 1048576U ,
        Terminate = 1U ,
        VMOperation = 8U ,
        VMRead = 16U ,
        VMWrite = 32U ,
    }
}
