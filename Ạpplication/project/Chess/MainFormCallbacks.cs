using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;

namespace Chess
{
    public partial class MainForm : Form, UIBoard
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateBoard();

            SetStatus("Choose PVP Game to start.");

            // setup menu
            endCurrentGameToolStripMenuItem.Enabled = false;
        }

        private void windowClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }

        private void Shutdown(object sender, EventArgs e)
        {
            Stop();
            this.Close();
        }

        private void endGame(object sender, EventArgs e)
        {
            Stop();
        }

        private void NewGame(object sender, EventArgs e)
        {
            ToolStripMenuItem button = (ToolStripMenuItem)sender;
            NewGame(2);
        }
        private void doneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // no longer building board
            m_manualBoard = false;
            m_finalizedBoard = true;
            // start the manual game
            SetStatus("White's Turn");
            m_checkmate = chess.detectCheckmate();
        }
    }
}