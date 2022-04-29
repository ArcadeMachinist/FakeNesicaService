using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeNesicaService
{
    public static class NESYS
    {
        public enum NesysClientCommand {
            CCOMMAND_ERROR,
            LCOMMAND_CLIENT_START,
            LCOMMAND_CONNECT_REQUEST,
            LCOMMAND_DISCONNECT_REQUEST,
            LCOMMAND_GAME_START_REQUEST,        // 0x04
            LCOMMAND_GAME_END_REQUEST,          // 0x05
            LCOMMAND_GAME_CONTINUE_REQUEST,     // 0x06
            LCOMMAND_EVENT_DOWNLOAD_REQUEST,
            LCOMMAND_EVENT_REQUEST_REQUEST,
            LCOMMAND_CARD_SELECT_REQUEST,
            LCOMMAND_CARD_INSERT_REQUEST,        // 0x0A  10
            LCOMMAND_CARD_UPDATE_REQUEST,
            LCOMMAND_CARD_BUYS_ITEM_REQUEST,
            LCOMMAND_CARD_TAKEOVER_REQUEST,
            LCOMMAND_CARD_FORCE_TAKEOVER_REQ,
            LCOMMAND_CARD_DECREASE_REQUEST,      // 0x0F   15
            LCOMMAND_CARD_REISSUE_TEST_REQUE,    // 0x10   16
            LCOMMAND_CARD_REISSUE_REQUEST,       
            LCOMMAND_CARD_PLAYED_LIST_REQUES,
            LCOMMAND_RANKING_DATA_REQUEST,
            LCOMMAND_LOCALNW_INFO_REQUEST,      // 0x14
            LCOMMAND_GLOBALADDR_REQUEST,        // 0x15 
            LCOMMAND_ECHO_REQUEST,              
            LCOMMAND_ADAPTER_INFO_REQUEST,      // 0x17
            LCOMMAND_SERVICE_VERSION_REQUEST,   // 0x18
            LCOMMAND_DHCP_RENEW_REQUEST,        // 0x19
            LCOMMAND_HTTPACCESS_GET_REQUEST,    // 0x1A
            LCOMMAND_HTTPACCESS_POST_REQUEST,   // 0x1B
            LCOMMAND_UPLOAD_CONFIG_REQUEST,     // 0x1C
            LCOMMAND_INCOME_START_REQUEST,      // 0x1D    29
            LCOMMAND_INCOME_END_REQUEST,
            LCOMMAND_INCOME_CONTINUE_REQUEST,
            LCOMMAND_SET_INCOME_MODE_REQUEST,   // 0x20
            LCOMMAND_DESTROY_MY_SERVICE,
            LCOMMAND_INCOME_POINT_REQUEST,
            LCOMMAND_GAMESTATUS_RESET_REQUEST,
            LCOMMAND_ROW_EVENTDATA_LIST_REQUEST, // 0x24
            LCOMMAND_SHOPPING_REQUEST,
            LCOMMAND_FREE_TICKET_REQUEST,
            LCOMMAND_GAME_FREE_START_REQUEST,
            LCOMMAND_GAME_FREE_END_REQUEST,     // 0x28
            LCOMMAND_INCOME_FREE_START_REQUEST,
            LCOMMAND_INCOME_FREE_END_REQUEST,
            LCOMMAND_CLIENT_END
        }
        public enum NesysServerCommand
        {
            CCOMMAND_ERROR,
            SCOMMAND_NW_ERROR,
            SCOMMAND_CERT_ERROR,
            SCOMMAND_NWRECOVER_NOTICE, // 0x103
            SCOMMAND_SOON_MAINTENANCE_NOTICE, // 0x104
            SCOMMAND_LINKUP_NOTICE, // 0x105
            SCOMMAND_LINKLOCAL_MODE_NOTICE,
            SCOMMAND_CERT_INIT_NOTICE,        // 0x107
            SCOMMAND_CERT_REGULAR_NOTICE,
            SCOMMAND_EFFECTIVE_EVENT_NOTICE,
            SCOMMAND_INEFFECTIVE_EVENT_NOTICE, //0x10A
            SCOMMAND_DHCP_RENEW_START,        
            SCOMMAND_DHCP_COMPLETE_NOTICE,
            SCOMMAND_CLIENT_START_REPLY,      // 0x10D
            SCOMMAND_CONNECT_REPLY,           // 0x10E
            SCOMMAND_DISCONNECT_REPLY,        // 0x10F
            SCOMMAND_GAME_STATUS_REPLY,       // 0x110
            SCOMMAND_CARD_SELECT_REPLY,       // 0x111
            SCOMMAND_CARD_INSERT_REPLY,       // 0x112
            SCOMMAND_CARD_UPDATE_REPLY,       // 0x113
            SCOMMAND_CARD_BUYS_ITEM_REPLY,
            SCOMMAND_CARD_TAKEOVER_REPLY,
            SCOMMAND_CARD_DECREASE_REPLY,
            SCOMMAND_CARD_REISSUE_TEST_REPLY,
            SCOMMAND_CARD_REISSUE_REPLY,
            SCOMMAND_CARD_PLAYED_LIST_REPLY,
            SCOMMAND_RANKING_DATA_REPLY,       // 0x11A
            SCOMMAND_LOCALNW_INFO_REPLY,       // 0x11B
            SCOMMAND_LOCALNW_INFO_NOTICE,      // 0x11C
            SCOMMAND_GLOBALADDR_REPLY,
            SCOMMAND_ECHO_REPLY,
            SCOMMAND_ADAPTER_INFO_REPLY,       // 0x11F
            SCOMMAND_SERVICE_VERSION_REPLY,
            SCOMMAND_HTTPACCESS_START,
            SCOMMAND_HTTPACCESS_REPLY,
            SCOMMAND_UPLOAD_CONFIG_REPLY,
            SCOMMAND_INCOME_STATUS_REPLY,
            SCOMMAND_SET_INCOME_MODE_REPLY,
            SCOMMAND_DESTROY_MY_SERVICE,
            SCOMMAND_GAMESTATUS_RESET_REPLY,
            SCOMMAND_ROW_EVENTDATA_LIST_REPLY,  // 0x128
            SCOMMAND_SHOPPING_REPLY,
            SCOMMAND_FREE_TICKET_REPLY,      // 0x12A
            SCOMMAND_CLIENT_END
        }


        // COMMAND_CLIENT_START = 0x00000001;
        // Client command
        // 0x133 bytes
        // 0x01 0x00 0x00 0x00 LE representation of command ID
        // client string ID crap here


        //   UInt64 COMMAND_CLIENT_START_REPLY = 0x0000010D;
        // Server command
        // 0x08 bytes
        // 0x0D 0x01 0x00 0x00 0x00 0x00 0x00 0x00 
        // LE representation of command ID + 4 null bytes

        //   UInt64 COMMAND_CONNECT_REQUEST = 0x00000002;
        // Client command
        // 0x08 bytes
        // 0x02 0x00 0x00 0x00 0x00 0x00 0x00 0x00 
        // LE representation of command ID + 4 null bytes

        //   UInt64 COMMAND_CONNECT_REPLY = 0x0000010E;
        // Server command
        // 0x08 bytes
        // 0x0E 0x01 0x00 0x00 0x00 0x00 0x00 0x00 
        // LE representation of command ID + 4 null bytes

        //    UInt64 COMMAND_NW_ERROR = 0x00000101;
        // Server command
        // 01 01 00 00 04 00 00 00 11 00 00 20
        // LE representation of command ID + ...?

        //    UInt64 COMMAND_LOCALNW_INFO_REQUEST = 0x00000014;
        // Client command
        // 0x08 bytes
        // 0x14 0x00 0x00 0x00 0x00 0x00 0x00 0x00 

        //   UInt64 COMMAND_LOCALNW_INFO_REPLY = 0x0000011B;
        // Server command
        // 0x08 bytes
        // 0x1B 0x01 0x00 0x00 0x00 0x00 0x00 0x00 
        // Real data sent async in COMMAND_LOCALNW_INFO_NOTICE

        //  UInt64 COMMAND_LOCALNW_INFO_NOTICE = 0x0000011C;
        // Server command
        // 1c 01 00 00 28 01 00 00 01 00 00 00 20 01 00 00       28010000 = 0x128 = 296 bytes from 01000000 to EOF
        //                                                       01000000 = RESULT_OK
        //                                                       20010000 = 0x120 = 288 bytes from MAC1 to EOF
        //                                                       Followed by 72byte interface blocks for each IF
        // 30 30 31 43 34 32 38 38 38 34 37 35 00 00 00 00       12 ASCII bytes - MAC address + 00 00 00 00
        // 31 30 2e 32 31 31 2e 35 35 2e 33 00 00 00 00 00       IP ASCII + padding
        // 31 30 2e 32 31 31 2e 35 35 2e 31 00 00 00 00 00       GW ASCII + padding
        // 31 30 2e 32 31 31 2e 35 35 2e 31 00 00 00 00 00       DNS ASCII + padding
        // 7c 15 00 00 00 00 00 00 30 30 31 43 34 32 30 30       7c15 -?   + padding      30 30 31.... 2nd IF block start
        // 30 30 31 38 00 00 00 00 31 30 2e 32 31 31 2e 35
        // 35 2e 31 00 00 00 00 00 00 00 00 00 00 00 00 00       72 = 88
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 30 31 30 30 35 45 34 30 39 38 38 46 00 00 00 00
        // 32 33 39 2e 31 39 32 2e 31 35 32 2e 31 34 33 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 30 31 30 30 35 45 37 46
        // 46 46 46 41 00 00 00 00 32 33 39 2e 32 35 35 2e
        // 32 35 35 2e 32 35 30 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00

        // SCOMMAND_CERT_INIT_NOTICE
        //
        // 07 01 00 00 be 04 00 00 77 00 00 00 41 72 63 61     // 0x107      BE 04 00 00= 0x4be = 1214 bytes to follow
        //                                                                   77 00 00 00 TenpoID 119
        // 64 65 4d 61 63 68 69 6e 69 73 74 27 73 20 68 61                   41 72 ..... Fixed 31 bytes Tenpo name
        // 63 6b 69 6e 67 20 63 61 76 65 00 41 4d 27 73 20                   41 4D ..... Fixed 33 bytes Location Address
        // 68 6f 6d 65 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 6e 6f 6e 65                   6E 6F ....   Fixed 33 bytes "ticket" field from CERT
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 55 53 00                   55 53 ....   Fixed 23 bytes Prefecture
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 08 00 00 00 77 00 00 00 44 3a 5c 73 79 73 74 65                   77 TenpoID   44.... 1024 byte path to News PNG file
        // 6d 5c 44 55 41 5c 6e 65 77 73 5c 31 34 35 30 31
        // 35 32 38 38 37 2e 70 6e 67 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
        // 00 00 00 00 00 00 00 00 3a 00 00 00 63 61 72 64         3A 00 00 00 = 0x3a = 58 size of following host= structure
        // 5f 69 64 3d 46 41 44 45 42 41 42 45 44 45 41 44
        // 42 45 45 46 2c 72 65 6c 61 79 5f 61 64 64 72 3d
        // 31 30 2e 30 2e 32 2e 32 2c 72 65 6c 61 79 5f 70
        // 6f 72 74 3d 38 30

        // 

        //  UInt64 COMMAND_GAMESTATUS_RESET_REQUEST = 0x00000014;
        // Client command
        // 0x08 bytes
        // 0x14 0x00 0x00 0x00 0x00 0x00 0x00 0x00 

        //   UInt64 COMMAND_GAMESTATUS_RESET_REPLY = 0x0000011B;
        // Server command
        // 0x08 bytes
        // 0x1B 0x01 0x00 0x00 0x00 0x00 0x00 0x00 

        // SCOMMAND_ROW_EVENTDATA_LIST_REPLY
        //
        // 28 01 00 00 44 08 00 00 40 08 00 00            command ID, length1, length2
        // then 00 bytes of length 2 size, 2112 it test case
    }
}
