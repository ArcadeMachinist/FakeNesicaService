using System;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading;
using System.Threading.Tasks;

namespace FakeNesicaService
{


    public class PipeServer
    {
        private static int numThreads = 4;
        public CancellationTokenSource cts;

        public struct serverParams
        {
            public string s_gameid;
            public string s_tenpoid;
            public string s_tenponame;
            public string s_address;
            public string s_prefecture;
            public string s_img;
            public string s_version;
            public string s_host;
            public string s_ticket;

        }


        public serverParams e_sp;

        private struct tStarter
        {
            public IProgress<string> p;
            public serverParams sp;
        }

        public Task<string> RunPipe(IProgress<string> myProgress)
        {



            return Task.Run(() =>
            {
                //here you will sen out to your UI thread whatever text you want.
                //typically used for progress bar.
                myProgress.Report("Starting Pipe Server..");
                //your tasks return
                int i;
                Thread[] servers = new Thread[numThreads];
                //Form1.Invoke(new Action(() => Form1.button1.Text = "new text"));

                for (i = 0; i < numThreads; i++)
                {
                    tStarter ts = new tStarter();
                    ts.p = myProgress;
                    ts.sp = e_sp;
                    servers[i] = new Thread(ServerThread);

                    servers[i].Start(ts);
                }
                Thread.Sleep(250);
                while (i > 0)
                {
                    for (int j = 0; j < numThreads; j++)
                    {
                        if (servers[j] != null)
                        {
                            if (servers[j].Join(250))
                            {
                                Console.WriteLine("Server thread[{0}] finished.", servers[j].ManagedThreadId);
                                servers[j] = null;
                                i--;    // decrement the thread watch count
                            }
                        }
                    }
                }
                Console.WriteLine("\nServer threads exhausted, exiting.");
                return "";
            }, cts.Token);
           

        }


        private static void ServerThread(object data)
        {
            tStarter ts = (tStarter)data;
            IProgress<string> myProgress = (IProgress<string>)ts.p;
            Console.WriteLine(ts.sp.s_host);


            // we don't care about length here, we would copy only required number of bytes later
            Byte[] s_gameid = BitConverter.GetBytes((UInt32)uint.Parse(ts.sp.s_gameid));
            Byte[] s_tenpoid = BitConverter.GetBytes((UInt32)uint.Parse(ts.sp.s_tenpoid));
            Byte[] s_tenponame = System.Text.Encoding.UTF8.GetBytes(ts.sp.s_tenponame);
            Byte[] s_address = System.Text.Encoding.UTF8.GetBytes(ts.sp.s_address);
            Byte[] s_prefecture = System.Text.Encoding.UTF8.GetBytes(ts.sp.s_prefecture);
            Byte[] s_img = System.Text.Encoding.UTF8.GetBytes(ts.sp.s_img);
            Byte[] s_version = System.Text.Encoding.UTF8.GetBytes(ts.sp.s_version);
            Byte[] s_host = System.Text.Encoding.UTF8.GetBytes(ts.sp.s_host);
            Byte[] s_ticket = System.Text.Encoding.UTF8.GetBytes(ts.sp.s_ticket);

            Byte[] s_globaladdr = System.Text.Encoding.UTF8.GetBytes("10.79.0.41");
            Byte[] s_ip_gate = System.Text.Encoding.UTF8.GetBytes("192.168.8.1");
            Byte[] s_ip_addr = System.Text.Encoding.UTF8.GetBytes("192.168.8.117");
            Byte[] s_ip_mask = System.Text.Encoding.UTF8.GetBytes("255.255.255.0");
            Byte[] s_ip_dns1 = System.Text.Encoding.UTF8.GetBytes("192.168.8.1");
            Byte[] s_ip_dns2 = System.Text.Encoding.UTF8.GetBytes("192.168.8.1");
            Byte[] s_ip_mac  = System.Text.Encoding.UTF8.GetBytes("001C42888475");


            if (!System.OperatingSystem.IsWindows())
                throw new PlatformNotSupportedException("Windows only");

            SecurityIdentifier securityIdentifier = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);
            PipeSecurity pipeSecurity = new PipeSecurity();

            // Allow Everyone read and write access to the pipe. 
            pipeSecurity.AddAccessRule(new PipeAccessRule(securityIdentifier, PipeAccessRights.ReadWrite | PipeAccessRights.CreateNewInstance, System.Security.AccessControl.AccessControlType.Allow));

            NamedPipeServerStream pipeServer = NamedPipeServerStreamAcl.Create("nesys_games", PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 0, 0, pipeSecurity);


            int threadId = Thread.CurrentThread.ManagedThreadId;
            myProgress.Report("Waiting for clients thread "+ threadId);
            // Wait for a client to connect
            pipeServer.WaitForConnection();

            myProgress.Report("Client connected on thread " + threadId);
            try
            {


                //StreamString ss = new StreamString(pipeServer);


                var srvBuff = new byte[2048];
                var srvL = 0;
                var retBuff = new byte[3192];

                Byte[] netMAC = new byte[] { 0x30, 0x30, 0x31, 0x43, 0x34, 0x32, 0x38, 0x38, 0x38, 0x34, 0x37, 0x35, 0x00, 0x00, 0x00, 0x00 };
                Byte[] ipAddr = new byte[] { 0x31, 0x30, 0x2e, 0x32, 0x31, 0x31, 0x2e, 0x35, 0x35, 0x2e, 0x33, 0x00, 0x00, 0x00, 0x00, 0x00 };
                Byte[] ipGate = new byte[] { 0x31, 0x30, 0x2e, 0x32, 0x31, 0x31, 0x2e, 0x35, 0x35, 0x2e, 0x31, 0x00, 0x00, 0x00, 0x00, 0x00 };
                Byte[] ipDNS  = new byte[] { 0x31, 0x30, 0x2e, 0x32, 0x31, 0x31, 0x2e, 0x35, 0x35, 0x2e, 0x31, 0x00, 0x00, 0x00, 0x00, 0x00 };
                Byte[] ipUnkn = new byte[] { 0x7c, 0x15, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                uint apos = 0;

                Byte[] sVersion = new byte[] { 0x32, 0x2E, 0x38, 0x35, 0x28, 0x78, 0x36, 0x34, 0x29, 0x20, 0x32, 0x30, 0x31, 0x34, 0x2F, 0x30, 0x37, 0x2F, 0x30, 0x38, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

                
                while (true)
                {
                    srvL = pipeServer.Read(srvBuff, 0, srvBuff.Length);

                    if (srvL > 0 )
                    {
                        srvL = 0;
                        //myProgress.Report("[" + threadId + "] " + BitConverter.ToString(srvBuff));

                        Console.WriteLine("FROM NESYS: {0:X}", BitConverter.ToString(srvBuff));

                        var segment = new ArraySegment<byte>(srvBuff, 2, 3);
                        var bb = segmentGetBytes(new ArraySegment<byte>(srvBuff, 0, 4));


                        UInt32 commandID = BitConverter.ToUInt32(bb, 0);


                        //myProgress.Report("[" + threadId + "] COMMAND " + commandID);
                        Array.Clear(retBuff, 0, retBuff.Length);

                        switch (commandID)
                        {
                            case (int)NESYS.NesysClientCommand.LCOMMAND_CLIENT_START:
                                myProgress.Report("[" + threadId + "] LCOMMAND_CLIENT_START");
                                
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_CLIENT_START_REPLY + 0x100), 0, retBuff, 0, 4);
                                pipeServer.Write(srvBuff, 0, srvL);
                                pipeServer.Write(retBuff, 0, 8);
                                break;
                            case (int)NESYS.NesysClientCommand.LCOMMAND_CONNECT_REQUEST:
                                myProgress.Report("[" + threadId + "] LCOMMAND_CONNECT_REQUEST");
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_CONNECT_REPLY + 0x100), 0, retBuff, 0, 4);
                                pipeServer.Write(srvBuff, 0, srvL);
                                pipeServer.Write(retBuff, 0, 8);
                                Thread.Sleep(30);
                                
                                // pretend network ok - send SCOMMAND_NWRECOVER_NOTICE
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_NWRECOVER_NOTICE + 0x100), 0, retBuff, 0, 4);
                                pipeServer.Write(retBuff, 0, 8);
                                Thread.Sleep(30);
                                
                                // send SCOMMAND_CERT_INIT_NOTICE
                                Array.Clear(retBuff, 0, retBuff.Length);
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_CERT_INIT_NOTICE + 0x100), 0, retBuff, 0, 4);
                                apos = 4;
                                Array.Copy(BitConverter.GetBytes((UInt32)(s_host.Length + 1156)), 0, retBuff, apos, 4); apos += 4;
                                Array.Copy(BitConverter.GetBytes((UInt32)uint.Parse(ts.sp.s_tenpoid)), 0, retBuff, apos, 4); apos += 4;
                                Array.Copy(s_tenponame, 0, retBuff, apos, s_tenponame.Length < 32 ? s_tenponame.Length : 31); apos += 31;
                                Array.Copy(s_address, 0, retBuff, apos, s_address.Length < 34 ? s_address.Length : 33); apos += 33;
                                Array.Copy(s_ticket, 0, retBuff, apos, s_ticket.Length < 34 ? s_ticket.Length : 33); apos += 33;
                                Array.Copy(s_prefecture, 0, retBuff, apos, s_prefecture.Length < 24 ? s_prefecture.Length : 23); apos += 23;
                                Array.Copy(BitConverter.GetBytes((UInt32)uint.Parse(ts.sp.s_tenpoid)), 0, retBuff, apos, 4); apos += 4;
                                Array.Copy(s_img, 0, retBuff, apos, s_img.Length < 1025 ? s_img.Length : 1024); apos += 1024;
                                Array.Copy(BitConverter.GetBytes((UInt32)(s_host.Length)), 0, retBuff, apos,4); apos += 4;
                                Array.Copy(s_host, 0, retBuff, apos, s_host.Length); apos += 1024;
                                pipeServer.Write(retBuff, 0, s_host.Length + 1156 + 8);
                                
                                break;
                            case (int)NESYS.NesysClientCommand.LCOMMAND_DISCONNECT_REQUEST:
                                myProgress.Report("[" + threadId + "] LCOMMAND_DISCONNECT_REQUEST");
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_DISCONNECT_REPLY + 0x100), 0, retBuff, 0, 4);
                                pipeServer.Write(srvBuff, 0, srvL);
                                pipeServer.Write(retBuff, 0, 8);
                                break;
                            case (int)NESYS.NesysClientCommand.LCOMMAND_LOCALNW_INFO_REQUEST:
                                myProgress.Report("[" + threadId + "] LCOMMAND_LOCALNW_INFO_REQUEST");
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_LOCALNW_INFO_REPLY + 0x100), 0, retBuff, 0, 4);
                                pipeServer.Write(srvBuff, 0, srvL);
                                pipeServer.Write(retBuff, 0, 8);
                                //
                                // Also should immediatly send COMMAND_LOCALNW_INFO_NOTICE
                                apos = 0;
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_LOCALNW_INFO_NOTICE + 0x100), 0, retBuff, apos, apos+4); apos += 4;
                                Array.Copy(BitConverter.GetBytes((UInt32)80), 0, retBuff, apos, 4); apos += 4;   // length = 96
                                Array.Copy(BitConverter.GetBytes((UInt32)1), 0, retBuff, apos,  4); apos += 4; // ResultOK = 1
                                Array.Copy(BitConverter.GetBytes((UInt32)72), 0, retBuff, apos, 4); apos += 4;   // length = 88
                                Array.Copy(netMAC, 0, retBuff, apos, 16); apos += 16;
                                Array.Copy(ipAddr, 0, retBuff, apos, 16); apos += 16;
                                Array.Copy(ipGate, 0, retBuff, apos, 16); apos += 16;
                                Array.Copy(ipDNS, 0, retBuff, apos, 16); apos += 16;
                                Array.Copy(ipUnkn, 0, retBuff, apos, 8); apos += 8;
                                pipeServer.Write(retBuff, 0, (int)apos);

                                break;
                            case (int)NESYS.NesysClientCommand.LCOMMAND_GAMESTATUS_RESET_REQUEST:
                                myProgress.Report("[" + threadId + "] LCOMMAND_GAMESTATUS_RESET_REQUEST");
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_GAMESTATUS_RESET_REPLY + 0x100), 0, retBuff, 0, 4);
                                pipeServer.Write(srvBuff, 0, srvL);
                                pipeServer.Write(retBuff, 0, 8);
                                break;

                            case (int)NESYS.NesysClientCommand.LCOMMAND_SERVICE_VERSION_REQUEST:
                                myProgress.Report("[" + threadId + "] LCOMMAND_SERVICE_VERSION_REQUEST");
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_SERVICE_VERSION_REPLY + 0x100), 0, retBuff, 0, 4);
                                Array.Copy(BitConverter.GetBytes((UInt32)sVersion.Length), 0, retBuff, 4, 4); apos = 8;
                                Array.Copy(s_version, 0, retBuff, 8, s_version.Length);
                                Array.Copy(s_version, 0, retBuff, apos, s_version.Length < 33 ? s_version.Length : 32); apos += 32;
                                pipeServer.Write(srvBuff, 0, srvL);
                                pipeServer.Write(retBuff, 0, (int)apos);
                                break;
                            case (int)NESYS.NesysClientCommand.LCOMMAND_GAME_FREE_END_REQUEST:
                                myProgress.Report("[" + threadId + "] LCOMMAND_GAME_FREE_END_REQUEST");
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_FREE_TICKET_REPLY + 0x100), 0, retBuff, 0, 4);
                                Array.Copy(BitConverter.GetBytes((UInt32)8), 0, retBuff, 4, 4);
                                pipeServer.Write(srvBuff, 0, srvL);
                                pipeServer.Write(retBuff, 0, 8 + 8);

                                break;

                            case (int)NESYS.NesysClientCommand.LCOMMAND_GLOBALADDR_REQUEST:
                                myProgress.Report("[" + threadId + "] LCOMMAND_GLOBALADDR_REQUEST");
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_GLOBALADDR_REPLY + 0x100), 0, retBuff, 0, 4); apos = 4;
                                Array.Copy(BitConverter.GetBytes((UInt32)0x0018), 0, retBuff, apos, 4); apos += 4; // length
                                Array.Copy(BitConverter.GetBytes((UInt32)0x0001), 0, retBuff, apos, 4); apos += 4; // unknown
                                Array.Copy(BitConverter.GetBytes((UInt32)0x01a6), 0, retBuff, apos, 4); apos += 4; // unknown
                                Array.Copy(s_globaladdr, 0, retBuff, apos, s_globaladdr.Length < 17 ? s_globaladdr.Length : 16); apos += 16;
                                pipeServer.Write(srvBuff, 0, srvL);
                                pipeServer.Write(retBuff, 0, (int)apos);
                                break;
                            case (int)NESYS.NesysClientCommand.LCOMMAND_SET_INCOME_MODE_REQUEST:
                                myProgress.Report("[" + threadId + "] LCOMMAND_SET_INCOME_MODE_REQUEST");
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_SET_INCOME_MODE_REPLY + 0x100), 0, retBuff, 0, 4);
                                pipeServer.Write(srvBuff, 0, srvL);
                                pipeServer.Write(retBuff, 0, 8);
                                break;
                            case (int)NESYS.NesysClientCommand.LCOMMAND_ADAPTER_INFO_REQUEST:
                                myProgress.Report("[" + threadId + "] LCOMMAND_ADAPTER_INFO_REQUEST");
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_ADAPTER_INFO_REPLY + 0x100), 0, retBuff, 0, 4); apos = 4;
                                Array.Copy(BitConverter.GetBytes((UInt32)0x00e8), 0, retBuff, apos, 4); apos += 4; // length
                                Array.Copy(BitConverter.GetBytes((UInt32)0x0001), 0, retBuff, apos, 4); apos += 4; // unknown
                                Array.Copy(BitConverter.GetBytes((UInt32)0x0001), 0, retBuff, apos, 4); apos += 4; // unknown
                                Array.Copy(s_ip_gate, 0, retBuff, apos, s_ip_gate.Length < 17 ? s_ip_gate.Length : 16); apos += 16;
                                Array.Copy(new Byte[16], 0, retBuff, apos, 16); apos += 16;
                                Array.Copy(s_ip_addr, 0, retBuff, apos, s_ip_addr.Length < 17 ? s_ip_addr.Length : 16); apos += 16;
                                Array.Copy(new Byte[16], 0, retBuff, apos, 16); apos += 16;
                                Array.Copy(s_ip_mask, 0, retBuff, apos, s_ip_mask.Length < 17 ? s_ip_mask.Length : 16); apos += 16;
                                Array.Copy(new Byte[16], 0, retBuff, apos, 16); apos += 16;
                                Array.Copy(s_ip_dns1, 0, retBuff, apos, s_ip_dns1.Length < 17 ? s_ip_dns1.Length : 16); apos += 16;
                                Array.Copy(new Byte[16], 0, retBuff, apos, 16); apos += 16;
                                Array.Copy(s_ip_dns2, 0, retBuff, apos, s_ip_dns2.Length < 17 ? s_ip_dns2.Length : 16); apos += 16;
                                Array.Copy(new Byte[16], 0, retBuff, apos, 16); apos += 16;
                                Array.Copy(s_ip_mac, 0, retBuff, apos, s_ip_mac.Length < 17 ? s_ip_mac.Length : 16); apos += 16;
                                Array.Copy(new Byte[16], 0, retBuff, apos, 16); apos += 16;
                                Array.Copy(new Byte[16], 0, retBuff, apos, 16); apos += 16;
                                Array.Copy(new Byte[16], 0, retBuff, apos, 16); apos += 16;
                                pipeServer.Write(srvBuff, 0, srvL);
                                pipeServer.Write(retBuff, 0, (int)apos);

                                break;
                            case (int)NESYS.NesysClientCommand.LCOMMAND_ROW_EVENTDATA_LIST_REQUEST:
                                myProgress.Report("[" + threadId + "] LCOMMAND_ROW_EVENTDATA_LIST_REQUEST");
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_ROW_EVENTDATA_LIST_REPLY + 0x100), 0, retBuff, 0, 4); apos = 4;
                                Array.Copy(BitConverter.GetBytes((UInt32)0x0844), 0, retBuff, apos, 4); apos += 4; // length1
                                Array.Copy(BitConverter.GetBytes((UInt32)0x0840), 0, retBuff, apos, 4); apos += 4; // length2
                                Array.Copy(new Byte[2112], 0, retBuff, apos, 2112); apos += 2112;
                                pipeServer.Write(srvBuff, 0, srvL);
                                pipeServer.Write(retBuff, 0, (int)apos);
                                break;
                            case (int)NESYS.NesysClientCommand.LCOMMAND_GAME_START_REQUEST:
                            case (int)NESYS.NesysClientCommand.LCOMMAND_GAME_END_REQUEST:
                            case (int)NESYS.NesysClientCommand.LCOMMAND_GAME_CONTINUE_REQUEST:
                                myProgress.Report("[" + threadId + "] LCOMMAND_GAME_START/CONTINUE/END [" + commandID + "]");
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_GAME_STATUS_REPLY + 0x100), 0, retBuff, 0, 4);
                                pipeServer.Write(srvBuff, 0, srvL);
                                pipeServer.Write(retBuff, 0, 8);
                                break;
                            case (int)NESYS.NesysClientCommand.LCOMMAND_INCOME_START_REQUEST:
                            case (int)NESYS.NesysClientCommand.LCOMMAND_INCOME_END_REQUEST:
                            case (int)NESYS.NesysClientCommand.LCOMMAND_INCOME_CONTINUE_REQUEST:
                                myProgress.Report("[" + threadId + "] LCOMMAND_INCOME_START/CONTINUE/END [" + commandID + "]");
                                Array.Copy(BitConverter.GetBytes((UInt32)NESYS.NesysServerCommand.SCOMMAND_INCOME_STATUS_REPLY + 0x100), 0, retBuff, 0, 4);
                                pipeServer.Write(srvBuff, 0, srvL);
                                pipeServer.Write(retBuff, 0, 8);
                                break;
                            default:
                                myProgress.Report("[" + threadId + "] Unhandled command id: "+ commandID);
                                pipeServer.Write(srvBuff, 0, srvL);
                                break;
                        }
                    }
                    Array.Clear(srvBuff, 0, srvBuff.Length);
                    Thread.Sleep(5);

                }


                // Read in the contents of the file while impersonating the client.
                //ReadFileToStream fileReader = new ReadFileToStream(ss, filename);

                // Display the name of the user we are impersonating.
                //Console.WriteLine("Reading file: {0} on thread[{1}] as user: {2}.",
                //    filename, threadId, pipeServer.GetImpersonationUserName());
                //pipeServer.RunAsClient(fileReader.Start);
            }
            // Catch the IOException that is raised if the pipe is broken
            // or disconnected.
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0:X}", e.Message);
            }
            //pipeServer.Close();
        }

        public static byte[] segmentGetBytes(ArraySegment<byte> arraySegment)
        {
            var retBuff = new byte[arraySegment.Count];
            Array.Copy(arraySegment.Array, arraySegment.Offset, retBuff, 0, arraySegment.Count);
            return retBuff;
        }
    }




    // Defines the data protocol for reading and writing strings on our stream
    public class StreamString
    {
        private Stream ioStream;
        private UnicodeEncoding streamEncoding;

        public StreamString(Stream ioStream)
        {
            this.ioStream = ioStream;
            streamEncoding = new UnicodeEncoding();
        }

        public string ReadString()
        {
            int len = 0;

            len = ioStream.ReadByte() * 256;
            len += ioStream.ReadByte();
            byte[] inBuffer = new byte[len];
            ioStream.Read(inBuffer, 0, len);

            return streamEncoding.GetString(inBuffer);
        }

        public int WriteString(string outString)
        {
            byte[] outBuffer = streamEncoding.GetBytes(outString);
            int len = outBuffer.Length;
            if (len > UInt16.MaxValue)
            {
                len = (int)UInt16.MaxValue;
            }
            ioStream.WriteByte((byte)(len / 256));
            ioStream.WriteByte((byte)(len & 255));
            ioStream.Write(outBuffer, 0, len);
            ioStream.Flush();

            return outBuffer.Length + 2;
        }
    }

    // Contains the method executed in the context of the impersonated user
    public class ReadFileToStream
    {
        private string fn;
        private StreamString ss;

        public ReadFileToStream(StreamString str, string filename)
        {
            fn = filename;
            ss = str;
        }

        public void Start()
        {
            string contents = File.ReadAllText(fn);
            ss.WriteString(contents);
        }
    }
}