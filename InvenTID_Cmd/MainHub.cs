using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvenTID.Properties;
using Microsoft.AspNet.SignalR;

namespace InvenTID
{
    public class MainHub : Hub
    {
        public string taglist;
        public void SendStatus(bool isconnected)
        {
            Clients.All.Notify("hi!");
        }

        public override Task OnConnected()
        {
            MessageBox.Show("Client connected: " + Context.ConnectionId);
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            MessageBox.Show("Client disconnected: " + Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public void ReadRFID()
        {
            FrmMain mainform = Application.OpenForms.OfType<FrmMain>().FirstOrDefault();
            if (mainform != null)
            {
                mainform.btnInventory.PerformClick();
            }
            Clients.All.readRFID(taglist);
        }
    }

}
