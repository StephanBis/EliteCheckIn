using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Oppassen! Dit zal alle records updaten!" + Environment.NewLine + "Weet u het zeker?", "Oppassen!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;

                int index = 0;

                var json = new WebClient().DownloadString("http://eddb.io/archive/v3/systems.json");
                List<SystemsJson> systems = JsonConvert.DeserializeObject<List<SystemsJson>>(json);

                foreach (SystemsJson system in systems)
                {
                    Systems newSystem = new Systems();
                    newSystem.Name = system.name;

                    if (system.faction == null || system.faction == "")
                    {
                        newSystem.Faction = "Unknown";
                    }
                    else
                    {
                        newSystem.Faction = system.faction;
                    }

                    HttpResponseMessage response = await Database.SaveSystem(newSystem);

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error");
                        break;
                    }
                    else
                    {
                        index++;

                        statusLabel.Text = newSystem.SystemId + " | " + newSystem.Name + " | " + newSystem.Faction + " | " + index;
                    }
                }

                this.Cursor = Cursors.Default;
            }
        }

        private async void insertButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Oppassen! Dit voegt alles opnieuw toe! Alleen doen als table leeg is!" + Environment.NewLine + "Weet u het zeker?", "Oppassen!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;

                int index = 0;

                var json = new WebClient().DownloadString("http://eddb.io/archive/v3/systems.json");
                List<SystemsJson> systems = JsonConvert.DeserializeObject<List<SystemsJson>>(json);

                foreach (SystemsJson system in systems)
                {
                    Systems newSystem = new Systems();
                    newSystem.Id = system.id;
                    newSystem.Name = system.name;

                    if (system.faction == null || system.faction == "")
                    {
                        newSystem.Faction = "Unknown";
                    }
                    else
                    {
                        newSystem.Faction = system.faction;
                    }

                    HttpResponseMessage response = await Database.AddSystem(newSystem);

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error");
                        break;
                    }
                    else
                    {
                        index++;

                        statusLabel.Text = newSystem.SystemId + " | " + newSystem.Name + " | " + newSystem.Faction + " | " + index; 
                    }
                }

                this.Cursor = Cursors.Default;
            }
        }
    }
}
