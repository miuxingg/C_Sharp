using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainActivity.Database
{
    class Insert_Accessories
    {
       
            public void Insert_Computer(string id, string name, string room, string harddrive, string capacity, string chip, string ram, string speed, string screen, string sizescreen, string mouse, string keybroad, string rom, string speaker, int tinhtrang, string ghichu)
            {
                try
                {
                    DataProcess.Instance.Querry("exec insert_Computer @id , @name , @idroom , @idharddrive , @idcapacity , @idchip , @idram , @idspeed , @idscreen , @idsizescreen , @idmouse , @idkeybroad , @idrom , @idspeak , @tinhtrang , @ghichu  ",
                        new object[] { id, name, room, harddrive, capacity, chip, ram, speed, screen, sizescreen, mouse, keybroad, rom, speaker, tinhtrang, ghichu });
                }
                catch(Exception e)
                {
                
                }
            }

    }
}
