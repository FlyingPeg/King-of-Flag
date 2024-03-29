﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Chess
{
    public partial class MainForm : Form, UIBoard
    {      
        bool m_aigame = false;
        bool m_checkmate = false;
        bool m_manualBoard = false; // Don't init board on new game
        bool m_finalizedBoard = false;

        Chess chess;
                
        private void Stop()
        {
            ChessBoard s = new ChessBoard(); 
            SetStatus("Choose PVP Game to start.");

            // stop the ai and reset chess
            chess = null;

            // reset turn indicator
            SetTurn(Player.WHITE);

            // clear the board ui and log
            SetBoard(new ChessBoard());

            // reset board status vars
            m_checkmate = false;
            m_aigame = false;
            m_finalizedBoard = false;

            // reset the menu
            endCurrentGameToolStripMenuItem.Enabled = false;
        }

        private void NewGame(int nPlayers)
        {
            
            // clean up all of the things first
            if (!m_manualBoard) Stop();

            // create new game for number of players
            m_aigame = (nPlayers == 0);
            chess = new Chess(this, nPlayers, !m_manualBoard);

            // show turn status
            SetTurn(Player.WHITE);
            SetStatus("White's turn.");
            SetStatus("White's Turn.");
            
            // allow stopping the game
            endCurrentGameToolStripMenuItem.Enabled = true;
        }

        public void SetTurn(Player p)
        {
            // if a thread called this, invoke recursion
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetTurn(p)));
                return;
            }
        }
        public void SetBoard(ChessBoard board)
        {
            // if a thread called this, invoke recursion
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetBoard(board)));
                return;
            }

            // update all tiles on board
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    SetPiece(board.Grid[i][j].piece, board.Grid[i][j].player, j, i);
        }

        public void LogMove(string move)
        {
            // if a thread called this, invoke recursion
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => LogMove(move)));
                return;
            }

            // reset check indicators
            lblWhiteCheck.Visible = false;
            lblBlackCheck.Visible = false;

            // show check indicator
            if (move.Contains("+"))
            {
                lblWhiteCheck.Visible = chess.Turn == Player.BLACK;
                lblBlackCheck.Visible = chess.Turn == Player.WHITE;
            }
            LV_LogMove.Items.Add(move);

        }

        public void SetStatus(string message)
        {
            // update status text and progress bar
            if(message == "Black's Turn.") lbl_Turn.Text = message;
            else 
            if (message == "White's Turn.") lbl_Turn.Text = message;
        }

        private void endCurrentGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
            this.Close();
        }
        private byte[] PToByteArray(position_t obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        private position_t ByteArrayToP(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            position_t obj = (position_t)binForm.Deserialize(memStream);
            return obj;
        }
        public Socket socket;
        public position_t str;
        public void Receive()
        {
            byte[] data = new byte[1000];

            socket.Receive(data);

            str = ByteArrayToP(data);
        }

        public void Send()
        {
            socket.Send(PToByteArray(str));
        }
    }
}
