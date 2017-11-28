using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbol.RFID3;

namespace InvenTID
{
    public class ComboboxItem
    {
        private RFIDReader reader;

        public ComboboxItem(RFIDReader reader)
        {
            this.reader = reader;
            Text = reader.FriendlyName+" ("+ reader.ComPortNumber+")";
            Value = reader;
        }

        public string Text { get; set; }
        public object Value { get; set; }

         public string Id
        {
            get
            {
                return reader.BluetoothAddress;
            }
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
