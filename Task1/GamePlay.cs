﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class GamePlay : Form
    {

        private Form1 caller;
        private GameEngine ge;
        private int width;
        private int height;

        public GamePlay(int min_width, int max_width, int min_height, int max_height, int num_enemies)
        {
            InitializeComponent();
            ge = new GameEngine(min_width, max_width, min_height, max_height, num_enemies);
            width = ge.getWidth();
            height = ge.getHeight();
            redraw();
        }

        public void setCaller(Form1 caller)
        {
            this.caller = caller;
        }

       

        private void actionStatus(String action,Boolean success)
        {
            if (success)
            {
                redraw();
            }
            else
            {
                actionstatusLabel.Text = "You cannot " + action;
            }
        }

        private void redraw()
        {
            updateMap();
            updatePlayerStats();
            updateEnvironment();
        }

        private void updateMap()
        {
            Tile[,] view = ge.getMapView();
            string text_view = "";

            for(int i = 0; i < height; ++i)
            {
                for(int j = 0; j < width; ++j)
                {
                    text_view += this.getRepresentation(view[i, j]) + " ";
                }
                text_view += '\n';
            }

            gameviewLabel.Text = text_view;
        }

        private void updatePlayerStats()
        {

        }

        private void updateEnvironment()
        {

        }

        private char getRepresentation(Tile type)
        {
            if(type is EmptyTile)
            {
                return '.';
            }
            else if(type is Hero)
            {
                return 'H';
            }
            else if (type is Goblin)
            {
                return 'G';
            }
            else
            {
                return 'X';
            }
        }

        private void GamePlay_FormClosed(object sender, FormClosedEventArgs e)
        {
            caller.Dispose();
        }

        private void GamePlay_KeyDown(object sender, KeyEventArgs e)
        {
            actionstatusLabel.Text = "";

            if (e.KeyCode == Keys.W)
            {
                actionStatus("move up", ge.movePlayer(Character.Movement.Up));
            }
            else if (e.KeyCode == Keys.S)
            {
                actionStatus("move down", ge.movePlayer(Character.Movement.Down));
            }
            else if (e.KeyCode == Keys.A)
            {
                actionStatus("move left", ge.movePlayer(Character.Movement.Left));
            }
            else if (e.KeyCode == Keys.D)
            {
                actionStatus("move right", ge.movePlayer(Character.Movement.Right));
            }
            else if (e.KeyCode == Keys.Up)
            {
                actionStatus("attack up", ge.attackEnemy(Character.Movement.Up));
            }
            else if (e.KeyCode == Keys.Down)
            {
                actionStatus("attack down", ge.attackEnemy(Character.Movement.Down));
            }
            else if (e.KeyCode == Keys.Left)
            {
                actionStatus("attack left", ge.attackEnemy(Character.Movement.Left));
            }
            else if (e.KeyCode == Keys.Right)
            {
                actionStatus("attack right", ge.attackEnemy(Character.Movement.Right));
            }
        }
    }

    
}
