﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using KingOfPirates.Missioni;
using System.Windows.Forms;
using KingOfPirates.Missioni.Roba;

namespace KingOfPirates.GUI.MenuMissioni
{
    partial class FormMissione
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Inizializzatore componenti grafici.
        /// </summary>
        private void InitializeComponent(int picBoxXSize, int picBoxYSize)
        {
            this.components = new System.ComponentModel.Container();
            this.cartinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Sopra_button = new System.Windows.Forms.Button();
            this.Sinistra_button = new System.Windows.Forms.Button();
            this.Sotto_button = new System.Windows.Forms.Button();
            this.Destra_button = new System.Windows.Forms.Button();
            this.Azione_button = new System.Windows.Forms.Button();
            this.Griglia_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Rum_button = new Button();
            this.Rum_label = new Label();
            this.AssLeg_button = new Button();
            this.AssLeg_label = new Label();
            this.BevandaDet_button = new Button();
            this.BevandaDet_label = new Label();
            this.AntiUbriachezza_button = new Button();
            this.AntiUbriachezza_label = new Label();
            this.EnergiaNave_label = new Label();
            this.Ubriachezza_label = new Label();
            this.Determinazione_label = new Label();
            this.VitaNave_label = new Label();
            this.Dobloni_label = new Label();
            this.Rubini_label = new Label();
            this.Scavo_button = new Button();
            this.Attacca_button = new Button();
            this.Griglia_pictureBox = new System.Windows.Forms.PictureBox[picBoxXSize, picBoxYSize];
            ((System.ComponentModel.ISupportInitialize)(this.cartinaBindingSource)).BeginInit();
            this.Griglia_tableLayoutPanel.SuspendLayout();
            for (int i = 0; i < picBoxXSize; i++)
            {
                for (int j = 0; j < picBoxYSize; j++)
                {
                    this.Griglia_pictureBox[i, j] = new System.Windows.Forms.PictureBox();
                    ((System.ComponentModel.ISupportInitialize)(this.Griglia_pictureBox[i, j])).BeginInit();
                }
            }
            this.SuspendLayout();

            #region StatusNaveGiocatore

            int StatusStartPointX = 1090;
            int StatusStartPointY = 255;

            // 
            // Energia Nave
            // 
            this.EnergiaNave_label.Location = new System.Drawing.Point(StatusStartPointX, StatusStartPointY);
            this.EnergiaNave_label.Name = "EnergiaNave_label";
            this.EnergiaNave_label.Size = new System.Drawing.Size(156, 15);
            this.EnergiaNave_label.TabIndex = 1;
            this.EnergiaNave_label.Text = "Punti azione: " + Gioco.Giocatore.Stats.Pa + "/" + Gioco.Giocatore.Stats.PaMax;
            this.EnergiaNave_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EnergiaNave_label.AutoSize = false;
            // 
            // Ubriachezza
            // 

            StatusStartPointY += 18;

            this.Ubriachezza_label.Location = new System.Drawing.Point(StatusStartPointX, StatusStartPointY);
            this.Ubriachezza_label.Name = "Ubriacchezza_label";
            this.Ubriachezza_label.Size = new System.Drawing.Size(156, 15);
            this.Ubriachezza_label.TabIndex = 1;
            this.Ubriachezza_label.Text = "Ubriachezza: " + Gioco.Giocatore.Ubriachezza + "/" + Gioco.Giocatore.UbriachezzaMax;
            this.Ubriachezza_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Ubriachezza_label.AutoSize = false;
            // 
            // Determinazione
            // 

            StatusStartPointY += 18;

            this.Determinazione_label.Location = new System.Drawing.Point(StatusStartPointX, StatusStartPointY);
            this.Determinazione_label.Name = "Determinazione_label";
            this.Determinazione_label.Size = new System.Drawing.Size(156, 15);
            this.Determinazione_label.TabIndex = 1;
            this.Determinazione_label.Text = "Determinazione: " + Gioco.Giocatore.Determinazione + "/" + Gioco.Giocatore.DeterminazioneMax;
            this.Determinazione_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Determinazione_label.AutoSize = false;
            // 
            // VitaNave
            // 

            StatusStartPointY += 18;

            this.VitaNave_label.Location = new System.Drawing.Point(StatusStartPointX, StatusStartPointY);
            this.VitaNave_label.Name = "VitaNave_label";
            this.VitaNave_label.Size = new System.Drawing.Size(156, 15);
            this.VitaNave_label.TabIndex = 1;
            this.VitaNave_label.Text = "Punti Vita: " + Gioco.Giocatore.Stats.Hp + "/" + Gioco.Giocatore.Stats.HpMax;
            this.VitaNave_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VitaNave_label.AutoSize = false;


            // 
            // Dobloni
            // 

            StatusStartPointY += 36;

            this.Dobloni_label.Location = new System.Drawing.Point(StatusStartPointX, StatusStartPointY);
            this.Dobloni_label.Name = "Dobloni_label";
            this.Dobloni_label.Size = new System.Drawing.Size(156, 15);
            this.Dobloni_label.TabIndex = 1;
            this.Dobloni_label.Text = "Dobloni: " + Gioco.Dominio.CassaDobloni + "$";
            this.Dobloni_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Dobloni_label.AutoSize = false;
            // 
            // Rubini
            // 

            StatusStartPointY += 18;

            this.Rubini_label.Location = new System.Drawing.Point(StatusStartPointX, StatusStartPointY);
            this.Rubini_label.Name = "Rubini_label";
            this.Rubini_label.Size = new System.Drawing.Size(156, 15);
            this.Rubini_label.TabIndex = 1;
            this.Rubini_label.Text = "Rubini: " + Gioco.Dominio.CassaRubini;
            this.Rubini_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Rubini_label.AutoSize = false;
            #endregion

            #region Joystick

            int JoystickStartPointX = 1090;
            int JoystickStartPointY = 500;
            // 
            // Sopra_button
            // 
            this.Sopra_button.Location = new System.Drawing.Point(JoystickStartPointX + 53, JoystickStartPointY);
            this.Sopra_button.Name = "Sopra_button";
            this.Sopra_button.Size = new System.Drawing.Size(50, 50);
            this.Sopra_button.TabIndex = 1;
            this.Sopra_button.Text = "Sopra";
            this.Sopra_button.UseVisualStyleBackColor = true;
            this.Sopra_button.Click += new System.EventHandler(this.Sopra_button_Click);
            // 
            // Sinistra_button
            // FormMissione
            // 
            this.Sinistra_button.Location = new System.Drawing.Point(JoystickStartPointX, JoystickStartPointY + 53);
            this.Sinistra_button.Name = "Sinistra_button";
            this.Sinistra_button.Size = new System.Drawing.Size(50, 50);
            this.Sinistra_button.TabIndex = 2;
            this.Sinistra_button.Text = "Sinistra";
            this.Sinistra_button.UseVisualStyleBackColor = true;
            this.Sinistra_button.Click += new System.EventHandler(this.Sinistra_button_Click);
            // 
            // Sotto_button
            // 
            this.Sotto_button.Location = new System.Drawing.Point(JoystickStartPointX + 53, JoystickStartPointY + 106);
            this.Sotto_button.Name = "Sotto_button";
            this.Sotto_button.Size = new System.Drawing.Size(50, 50);
            this.Sotto_button.TabIndex = 3;
            this.Sotto_button.Text = "Sotto";
            this.Sotto_button.UseVisualStyleBackColor = true;
            this.Sotto_button.Click += new System.EventHandler(this.Sotto_button_Click);
            // 
            // Destra_button
            // 
            this.Destra_button.Location = new System.Drawing.Point(JoystickStartPointX + 106, JoystickStartPointY + 53);
            this.Destra_button.Name = "Destra_button";
            this.Destra_button.Size = new System.Drawing.Size(50, 50);
            this.Destra_button.TabIndex = 4;
            this.Destra_button.Text = "Destra";
            this.Destra_button.UseVisualStyleBackColor = true;
            this.Destra_button.Click += new System.EventHandler(this.Destra_button_Click);
            // 
            // Azione_button
            // 
            this.Azione_button.Location = new System.Drawing.Point(JoystickStartPointX + 53, JoystickStartPointY + 53);
            this.Azione_button.Name = "Azione_button";
            this.Azione_button.Size = new System.Drawing.Size(50, 50);
            this.Azione_button.TabIndex = 4;
            this.Azione_button.Text = "Passa";
            this.Azione_button.Click += new System.EventHandler(this.Azione_button_Click);

            #endregion

            #region Bottoni Consumabili

            Loc2D consumabiliStartPoint = new Loc2D(1090, 9);
            //
            // Rum_button
            //
            this.Rum_button.Location = new System.Drawing.Point(consumabiliStartPoint.X, consumabiliStartPoint.Y);
            this.Rum_button.Name = "Rum_button";
            this.Rum_button.Size = new System.Drawing.Size(156, 35);
            this.Rum_button.TabIndex = 1;
            this.Rum_button.Text = "Usa Rum";
            this.Rum_button.UseVisualStyleBackColor = true;
            this.Rum_button.Click += new System.EventHandler(this.Rum_button_Click);
            //
            // Rum_label
            //
            consumabiliStartPoint.Y += 38;
            this.Rum_label.Location = new System.Drawing.Point(consumabiliStartPoint.X, consumabiliStartPoint.Y);
            this.Rum_label.Name = "Rum_label";
            this.Rum_label.Size = new System.Drawing.Size(156, 15);
            this.Rum_label.TabIndex = 1;
            this.Rum_label.Text = "Rum rimasto: " + Gioco.Giocatore.Inventario.Rum;
            this.Rum_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Rum_label.AutoSize = false;
            //
            // AssLeg_button
            //
            consumabiliStartPoint.Y += 18;
            this.AssLeg_button.Location = new System.Drawing.Point(consumabiliStartPoint.X, consumabiliStartPoint.Y);
            this.AssLeg_button.Name = "AssLeg_button";
            this.AssLeg_button.Size = new System.Drawing.Size(156, 35);
            this.AssLeg_button.TabIndex = 1;
            this.AssLeg_button.Text = "Usa Assi";
            this.AssLeg_button.UseVisualStyleBackColor = true;
            this.AssLeg_button.Click += new System.EventHandler(this.AssLeg_button_Click);
            //
            // AssLeg_label
            //
            consumabiliStartPoint.Y += 38;
            this.AssLeg_label.Location = new System.Drawing.Point(consumabiliStartPoint.X, consumabiliStartPoint.Y);
            this.AssLeg_label.Name = "AssLeg_label";
            this.AssLeg_label.Size = new System.Drawing.Size(156, 15);
            this.AssLeg_label.TabIndex = 1;
            this.AssLeg_label.Text = "Assi rimaste: " + Gioco.Giocatore.Inventario.AssiLegno;
            this.AssLeg_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AssLeg_label.AutoSize = false;
            //
            // BevandaDet_button
            //
            consumabiliStartPoint.Y += 18;
            this.BevandaDet_button.Location = new System.Drawing.Point(consumabiliStartPoint.X, consumabiliStartPoint.Y);
            this.BevandaDet_button.Name = "BevandaDet_button";
            this.BevandaDet_button.Size = new System.Drawing.Size(156, 35);
            this.BevandaDet_button.TabIndex = 1;
            this.BevandaDet_button.Text = "Usa Bevanda Determinazione";
            this.BevandaDet_button.UseVisualStyleBackColor = true;
            this.BevandaDet_button.Click += new System.EventHandler(this.BevandaDet_button_Click);
            //
            // BevandaDet_label
            //
            consumabiliStartPoint.Y += 38;
            this.BevandaDet_label.Location = new System.Drawing.Point(consumabiliStartPoint.X, consumabiliStartPoint.Y);
            this.BevandaDet_label.Name = "BevandaDet_label";
            this.BevandaDet_label.Size = new System.Drawing.Size(156, 15);
            this.BevandaDet_label.TabIndex = 1;
            this.BevandaDet_label.Text = "Bevande Det Rimaste: " + Gioco.Giocatore.Inventario.BevandaDeterminazione;
            this.BevandaDet_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BevandaDet_label.AutoSize = false;
            //
            // AntiUbriachezza_button
            //
            consumabiliStartPoint.Y += 18;
            this.AntiUbriachezza_button.Location = new System.Drawing.Point(consumabiliStartPoint.X, consumabiliStartPoint.Y);
            this.AntiUbriachezza_button.Name = "AntiUbriachezza_button";
            this.AntiUbriachezza_button.Size = new System.Drawing.Size(156, 35);
            this.AntiUbriachezza_button.TabIndex = 1;
            this.AntiUbriachezza_button.Text = "Usa AntiUbriachezza";
            this.AntiUbriachezza_button.UseVisualStyleBackColor = true;
            this.AntiUbriachezza_button.Click += new System.EventHandler(this.AntiUbriachezza_button_Click);
            //
            // AntiUbriachezza_label
            //
            consumabiliStartPoint.Y += 38;
            this.AntiUbriachezza_label.Location = new System.Drawing.Point(consumabiliStartPoint.X, consumabiliStartPoint.Y);
            this.AntiUbriachezza_label.Name = "AntiUbriachezza_label";
            this.AntiUbriachezza_label.Size = new System.Drawing.Size(156, 15);
            this.AntiUbriachezza_label.TabIndex = 1;
            this.AntiUbriachezza_label.Text = "AntiUbriachezza rimasti: " + Gioco.Giocatore.Inventario.AntiUbriachezza;
            this.AntiUbriachezza_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AntiUbriachezza_label.AutoSize = false;

            #endregion

            #region Bottoni azioni

            int ActionButtonStartPointX = 1090;
            int ActionButtonStartPointY = 400;

            //
            // Scavo_button
            //
            this.Scavo_button.Location = new System.Drawing.Point(ActionButtonStartPointX, ActionButtonStartPointY);
            this.Scavo_button.Name = "Scavo_button";
            this.Scavo_button.Size = new System.Drawing.Size(150, 40);
            this.Scavo_button.TabIndex = 1;
            this.Scavo_button.Text = "Scava!";
            this.Scavo_button.UseVisualStyleBackColor = true;
            this.Scavo_button.Click += new System.EventHandler(this.Scavo_button_Click);
            //
            // Attacca_button
            //
            ActionButtonStartPointY += 43;
            this.Attacca_button.Location = new System.Drawing.Point(ActionButtonStartPointX, ActionButtonStartPointY);
            this.Attacca_button.Name = "Attacca_button";
            this.Attacca_button.Size = new System.Drawing.Size(150, 40);
            this.Attacca_button.TabIndex = 1;
            this.Attacca_button.Text = "Attacca: ";
            this.Attacca_button.UseVisualStyleBackColor = true;
            this.Attacca_button.Click += new System.EventHandler(this.Attacca_button_Click);
            ActionButtonStartPointY += 43;

            #endregion

            #region Matrice pictureBox

            //
            // Griglia_tableLayoutPanel
            // Inserisce nella tabella la matrice di pictureBox

            this.Griglia_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.Griglia_tableLayoutPanel.Size = new System.Drawing.Size(1090, 680);
            this.Griglia_tableLayoutPanel.Name = "Griglia_tableLayoutPanel";
            this.Griglia_tableLayoutPanel.TabIndex = 4;
            this.Griglia_tableLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Griglia_tableLayoutPanel.BackgroundImage = Properties.Resources.mare;
            this.Griglia_tableLayoutPanel.ColumnCount = picBoxXSize;
            this.Griglia_tableLayoutPanel.RowCount = picBoxYSize;

            for (int i = 0; i < picBoxXSize; i++)
            {
                for (int j = 0; j < picBoxYSize; j++)
                {
                    this.Griglia_tableLayoutPanel.Controls.Add(this.Griglia_pictureBox[i, j], i, j);
                }
            }

            // 50 + 3 pixel
            // Griglia_pictureBox[,]
            // Inizializza la matrice di pictureBox

            for (int i = 0; i < picBoxXSize; i++)
            {
                for (int j = 0; j < picBoxYSize; j++)
                {
                    this.Griglia_pictureBox[i, j].Name = "Griglia_pictureBox" + i + j;
                    this.Griglia_pictureBox[i, j].Size = new System.Drawing.Size(50, 50);
                    this.Griglia_pictureBox[i, j].TabIndex = 0;
                    this.Griglia_pictureBox[i, j].TabStop = false;
                    this.Griglia_pictureBox[i, j].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

                    switch (missione.Griglia_numerica.Mat[i, j])
                    {
                        default:
                        case 0: //mare
                            this.Griglia_pictureBox[i, j].BackgroundImage = Properties.Resources.mare;
                            break;
                        case 1: //isola
                            this.Griglia_pictureBox[i, j].BackgroundImage = Properties.Resources.isola1;
                            break;
                        case 2: //montagna
                            this.Griglia_pictureBox[i, j].BackgroundImage = Properties.Resources.montagna;
                            break;
                        case 3: //bandiera
                            this.Griglia_pictureBox[i, j].BackgroundImage = Properties.Resources.bandiera;
                            break;
                    }
                }
            }

            #endregion

            // 
            // MenuMissioni
            // 16 pixel tolti dalla cornice, 39 pixel tolti dalla barra del titolo

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.Griglia_tableLayoutPanel);
            this.Controls.Add(this.Azione_button);
            this.Controls.Add(this.Destra_button);
            this.Controls.Add(this.Sotto_button);
            this.Controls.Add(this.Sinistra_button);
            this.Controls.Add(this.Sopra_button);
            this.Controls.Add(this.Rum_button);
            this.Controls.Add(this.Rum_label);
            this.Controls.Add(this.AssLeg_button);
            this.Controls.Add(this.AssLeg_label);
            this.Controls.Add(this.BevandaDet_button);
            this.Controls.Add(this.BevandaDet_label);
            this.Controls.Add(this.AntiUbriachezza_button);
            this.Controls.Add(this.AntiUbriachezza_label);
            this.Controls.Add(this.EnergiaNave_label);
            this.Controls.Add(this.Ubriachezza_label);
            this.Controls.Add(this.Determinazione_label);
            this.Controls.Add(this.VitaNave_label);
            this.Controls.Add(this.Dobloni_label);
            this.Controls.Add(this.Rubini_label);
            this.Controls.Add(this.Scavo_button);
            this.Controls.Add(this.Attacca_button);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuMissioni_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.OnVisibleChanged);
            this.Name = "MenuMissioni";
            this.Text = "MenuMissioni";
            ((System.ComponentModel.ISupportInitialize)(this.cartinaBindingSource)).EndInit();
            this.Griglia_tableLayoutPanel.ResumeLayout(false);
            for (int i = 0; i < picBoxXSize; i++)
            {
                for (int j = 0; j < picBoxYSize; j++)
                {
                    ((System.ComponentModel.ISupportInitialize)(this.Griglia_pictureBox[i, j])).EndInit();
                }
            }
            this.ResumeLayout(false);
        }

        // Variabili
        internal System.Windows.Forms.PictureBox[,] Griglia_pictureBox { get; set; }
        private System.Windows.Forms.BindingSource cartinaBindingSource;
        private System.Windows.Forms.Button Sopra_button;
        private System.Windows.Forms.Button Sinistra_button;
        private System.Windows.Forms.Button Sotto_button;
        private System.Windows.Forms.Button Destra_button;
        private System.Windows.Forms.Button Azione_button;
        private System.Windows.Forms.TableLayoutPanel Griglia_tableLayoutPanel;
        private Button Rum_button;
        private Label Rum_label;
        private Button AssLeg_button;
        private Label AssLeg_label;
        private Button BevandaDet_button;
        private Label BevandaDet_label;
        private Button AntiUbriachezza_button;
        private Label AntiUbriachezza_label;

        internal Label EnergiaNave_label;
        private Label Ubriachezza_label;
        private Label Determinazione_label;
        private Label VitaNave_label;

        private Label Dobloni_label;
        private Label Rubini_label;

        private Button Scavo_button;
        private Button Attacca_button;
    }
}