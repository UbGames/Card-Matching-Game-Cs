using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;

namespace ShuffleNDealP1
{
	public partial class BasicCardForm : System.Windows.Forms.Form
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicCardForm));
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HowToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.PlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OnShowCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OffShowCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OnSoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OffSoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowSidePanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OnSidePanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OffSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.HowToPlayToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PicPlayerCard0 = new System.Windows.Forms.PictureBox();
            this.PicBoxDealerCard1 = new System.Windows.Forms.PictureBox();
            this.DealerCardPB = new System.Windows.Forms.PictureBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.lblShowTime = new System.Windows.Forms.Label();
            this.PanelCardsSelected = new System.Windows.Forms.Panel();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.TextBox7 = new System.Windows.Forms.TextBox();
            this.TextBox8 = new System.Windows.Forms.TextBox();
            this.PanelCardsFound = new System.Windows.Forms.Panel();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PanelButtons = new System.Windows.Forms.Panel();
            this.Label17 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.TextBox6 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBox5 = new System.Windows.Forms.TextBox();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.MenuStrip1.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlayerCard0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxDealerCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerCardPB)).BeginInit();
            this.Panel2.SuspendLayout();
            this.PanelCardsSelected.SuspendLayout();
            this.PanelCardsFound.SuspendLayout();
            this.PanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HowToPlayToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(65, 32);
            this.HelpToolStripMenuItem.Text = "Help";
            // 
            // HowToPlayToolStripMenuItem
            // 
            this.HowToPlayToolStripMenuItem.Name = "HowToPlayToolStripMenuItem";
            this.HowToPlayToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.HowToPlayToolStripMenuItem.Text = "How to play...";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.MenuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayToolStripMenuItem,
            this.DeckToolStripMenuItem,
            this.ExitToolStripMenuItem,
            this.HelpToolStripMenuItem1});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuStrip1.Size = new System.Drawing.Size(909, 43);
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // PlayToolStripMenuItem
            // 
            this.PlayToolStripMenuItem.Image = global::ShuffleNDealP1.Properties.Resources.play;
            this.PlayToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PlayToolStripMenuItem.Name = "PlayToolStripMenuItem";
            this.PlayToolStripMenuItem.Size = new System.Drawing.Size(90, 39);
            this.PlayToolStripMenuItem.Text = "Play";
            this.PlayToolStripMenuItem.Click += new System.EventHandler(this.PlayToolStripMenuItem_Click);
            // 
            // DeckToolStripMenuItem
            // 
            this.DeckToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.ClearCardsToolStripMenuItem,
            this.ShowCardsToolStripMenuItem,
            this.toolStripSeparator2,
            this.SoundToolStripMenuItem,
            this.ShowSidePanelToolStripMenuItem});
            this.DeckToolStripMenuItem.Name = "DeckToolStripMenuItem";
            this.DeckToolStripMenuItem.Size = new System.Drawing.Size(82, 39);
            this.DeckToolStripMenuItem.Text = "&Options";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // ClearCardsToolStripMenuItem
            // 
            this.ClearCardsToolStripMenuItem.Name = "ClearCardsToolStripMenuItem";
            this.ClearCardsToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.ClearCardsToolStripMenuItem.Text = "Clear Table";
            this.ClearCardsToolStripMenuItem.Click += new System.EventHandler(this.ClearCardsToolStripMenuItem_Click);
            // 
            // ShowCardsToolStripMenuItem
            // 
            this.ShowCardsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OnShowCardsToolStripMenuItem,
            this.OffShowCardsToolStripMenuItem});
            this.ShowCardsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowCardsToolStripMenuItem.Name = "ShowCardsToolStripMenuItem";
            this.ShowCardsToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.ShowCardsToolStripMenuItem.Text = "Show Cards";
            // 
            // OnShowCardsToolStripMenuItem
            // 
            this.OnShowCardsToolStripMenuItem.Name = "OnShowCardsToolStripMenuItem";
            this.OnShowCardsToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.OnShowCardsToolStripMenuItem.Text = "Show";
            this.OnShowCardsToolStripMenuItem.Click += new System.EventHandler(this.OnShowCardsToolStripMenuItem_Click);
            // 
            // OffShowCardsToolStripMenuItem
            // 
            this.OffShowCardsToolStripMenuItem.Checked = true;
            this.OffShowCardsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OffShowCardsToolStripMenuItem.Name = "OffShowCardsToolStripMenuItem";
            this.OffShowCardsToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.OffShowCardsToolStripMenuItem.Text = "Hide";
            this.OffShowCardsToolStripMenuItem.Click += new System.EventHandler(this.OffShowCardsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // SoundToolStripMenuItem
            // 
            this.SoundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OnSoundToolStripMenuItem,
            this.OffSoundToolStripMenuItem});
            this.SoundToolStripMenuItem.Name = "SoundToolStripMenuItem";
            this.SoundToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.SoundToolStripMenuItem.Text = "Sound";
            // 
            // OnSoundToolStripMenuItem
            // 
            this.OnSoundToolStripMenuItem.Checked = true;
            this.OnSoundToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OnSoundToolStripMenuItem.Name = "OnSoundToolStripMenuItem";
            this.OnSoundToolStripMenuItem.Size = new System.Drawing.Size(104, 26);
            this.OnSoundToolStripMenuItem.Text = "On";
            this.OnSoundToolStripMenuItem.Click += new System.EventHandler(this.OnSoundToolStripMenuItem_Click);
            // 
            // OffSoundToolStripMenuItem
            // 
            this.OffSoundToolStripMenuItem.Name = "OffSoundToolStripMenuItem";
            this.OffSoundToolStripMenuItem.Size = new System.Drawing.Size(104, 26);
            this.OffSoundToolStripMenuItem.Text = "Off";
            this.OffSoundToolStripMenuItem.Click += new System.EventHandler(this.OffSoundToolStripMenuItem_Click);
            // 
            // ShowSidePanelToolStripMenuItem
            // 
            this.ShowSidePanelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OnSidePanelToolStripMenuItem,
            this.OffSideToolStripMenuItem});
            this.ShowSidePanelToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowSidePanelToolStripMenuItem.Name = "ShowSidePanelToolStripMenuItem";
            this.ShowSidePanelToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.ShowSidePanelToolStripMenuItem.Text = "Side Panel";
            // 
            // OnSidePanelToolStripMenuItem
            // 
            this.OnSidePanelToolStripMenuItem.Name = "OnSidePanelToolStripMenuItem";
            this.OnSidePanelToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.OnSidePanelToolStripMenuItem.Text = "Show";
            this.OnSidePanelToolStripMenuItem.Click += new System.EventHandler(this.OnSidePanelToolStripMenuItem_Click);
            // 
            // OffSideToolStripMenuItem
            // 
            this.OffSideToolStripMenuItem.Checked = true;
            this.OffSideToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OffSideToolStripMenuItem.Name = "OffSideToolStripMenuItem";
            this.OffSideToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.OffSideToolStripMenuItem.Text = "Hide";
            this.OffSideToolStripMenuItem.Click += new System.EventHandler(this.OffSidePanelToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ExitToolStripMenuItem.Image = global::ShuffleNDealP1.Properties.Resources.exit1;
            this.ExitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(86, 39);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem1
            // 
            this.HelpToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.HelpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HowToPlayToolStripMenuItem1,
            this.AboutToolStripMenuItem1});
            this.HelpToolStripMenuItem1.Image = global::ShuffleNDealP1.Properties.Resources.help;
            this.HelpToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1";
            this.HelpToolStripMenuItem1.Size = new System.Drawing.Size(90, 39);
            this.HelpToolStripMenuItem1.Text = "Help";
            // 
            // HowToPlayToolStripMenuItem1
            // 
            this.HowToPlayToolStripMenuItem1.Name = "HowToPlayToolStripMenuItem1";
            this.HowToPlayToolStripMenuItem1.Size = new System.Drawing.Size(172, 26);
            this.HowToPlayToolStripMenuItem1.Text = "How to play";
            this.HowToPlayToolStripMenuItem1.Click += new System.EventHandler(this.HowToPlayToolStripMenuItem1_Click);
            // 
            // AboutToolStripMenuItem1
            // 
            this.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1";
            this.AboutToolStripMenuItem1.Size = new System.Drawing.Size(172, 26);
            this.AboutToolStripMenuItem1.Text = "About";
            this.AboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItem1_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Panel1.Controls.Add(this.PicPlayerCard0);
            this.Panel1.Controls.Add(this.PicBoxDealerCard1);
            this.Panel1.Controls.Add(this.DealerCardPB);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 43);
            this.Panel1.Margin = new System.Windows.Forms.Padding(2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(909, 518);
            this.Panel1.TabIndex = 1;
            // 
            // PicPlayerCard0
            // 
            this.PicPlayerCard0.BackColor = System.Drawing.Color.SteelBlue;
            this.PicPlayerCard0.Location = new System.Drawing.Point(416, 417);
            this.PicPlayerCard0.Name = "PicPlayerCard0";
            this.PicPlayerCard0.Size = new System.Drawing.Size(100, 50);
            this.PicPlayerCard0.TabIndex = 4;
            this.PicPlayerCard0.TabStop = false;
            this.PicPlayerCard0.Visible = false;
            // 
            // PicBoxDealerCard1
            // 
            this.PicBoxDealerCard1.BackColor = System.Drawing.Color.SteelBlue;
            this.PicBoxDealerCard1.Location = new System.Drawing.Point(363, 415);
            this.PicBoxDealerCard1.Name = "PicBoxDealerCard1";
            this.PicBoxDealerCard1.Size = new System.Drawing.Size(100, 50);
            this.PicBoxDealerCard1.TabIndex = 3;
            this.PicBoxDealerCard1.TabStop = false;
            // 
            // DealerCardPB
            // 
            this.DealerCardPB.BackColor = System.Drawing.Color.SteelBlue;
            this.DealerCardPB.Location = new System.Drawing.Point(310, 415);
            this.DealerCardPB.Name = "DealerCardPB";
            this.DealerCardPB.Size = new System.Drawing.Size(100, 50);
            this.DealerCardPB.TabIndex = 2;
            this.DealerCardPB.TabStop = false;
            // 
            // Panel2
            // 
            this.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel2.BackColor = System.Drawing.Color.Gold;
            this.Panel2.Controls.Add(this.lblShowTime);
            this.Panel2.Controls.Add(this.PanelCardsSelected);
            this.Panel2.Controls.Add(this.PanelCardsFound);
            this.Panel2.Controls.Add(this.PanelButtons);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel2.Location = new System.Drawing.Point(794, 43);
            this.Panel2.Margin = new System.Windows.Forms.Padding(2);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(115, 518);
            this.Panel2.TabIndex = 3;
            // 
            // lblShowTime
            // 
            this.lblShowTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(255)))), ((int)(((byte)(201)))));
            this.lblShowTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblShowTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblShowTime.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowTime.ForeColor = System.Drawing.Color.Black;
            this.lblShowTime.Location = new System.Drawing.Point(7, 16);
            this.lblShowTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShowTime.Name = "lblShowTime";
            this.lblShowTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblShowTime.Size = new System.Drawing.Size(100, 18);
            this.lblShowTime.TabIndex = 98;
            this.lblShowTime.Text = "00:00:00";
            this.lblShowTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PanelCardsSelected
            // 
            this.PanelCardsSelected.Controls.Add(this.Label10);
            this.PanelCardsSelected.Controls.Add(this.Label4);
            this.PanelCardsSelected.Controls.Add(this.Label3);
            this.PanelCardsSelected.Controls.Add(this.TextBox7);
            this.PanelCardsSelected.Controls.Add(this.TextBox8);
            this.PanelCardsSelected.Location = new System.Drawing.Point(2, 175);
            this.PanelCardsSelected.Margin = new System.Windows.Forms.Padding(2);
            this.PanelCardsSelected.Name = "PanelCardsSelected";
            this.PanelCardsSelected.Size = new System.Drawing.Size(110, 101);
            this.PanelCardsSelected.TabIndex = 97;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(7, 6);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(97, 13);
            this.Label10.TabIndex = 31;
            this.Label10.Text = "Cards Selected:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(7, 58);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(50, 13);
            this.Label4.TabIndex = 30;
            this.Label4.Text = "2nd Card";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(7, 21);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(46, 13);
            this.Label3.TabIndex = 29;
            this.Label3.Text = "1st Card";
            // 
            // TextBox7
            // 
            this.TextBox7.BackColor = System.Drawing.SystemColors.Window;
            this.TextBox7.Enabled = false;
            this.TextBox7.Location = new System.Drawing.Point(7, 36);
            this.TextBox7.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.Size = new System.Drawing.Size(100, 20);
            this.TextBox7.TabIndex = 28;
            this.TextBox7.Text = "TextBox7";
            // 
            // TextBox8
            // 
            this.TextBox8.BackColor = System.Drawing.SystemColors.Window;
            this.TextBox8.Enabled = false;
            this.TextBox8.Location = new System.Drawing.Point(7, 73);
            this.TextBox8.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Size = new System.Drawing.Size(100, 20);
            this.TextBox8.TabIndex = 27;
            this.TextBox8.Text = "TextBox8";
            // 
            // PanelCardsFound
            // 
            this.PanelCardsFound.Controls.Add(this.Label8);
            this.PanelCardsFound.Controls.Add(this.Label7);
            this.PanelCardsFound.Controls.Add(this.textBox4);
            this.PanelCardsFound.Controls.Add(this.textBox3);
            this.PanelCardsFound.Controls.Add(this.Label9);
            this.PanelCardsFound.Controls.Add(this.Label6);
            this.PanelCardsFound.Controls.Add(this.Label5);
            this.PanelCardsFound.Controls.Add(this.textBox2);
            this.PanelCardsFound.Controls.Add(this.textBox1);
            this.PanelCardsFound.Location = new System.Drawing.Point(2, 282);
            this.PanelCardsFound.Margin = new System.Windows.Forms.Padding(2);
            this.PanelCardsFound.Name = "PanelCardsFound";
            this.PanelCardsFound.Size = new System.Drawing.Size(112, 176);
            this.PanelCardsFound.TabIndex = 96;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(5, 135);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(31, 13);
            this.Label8.TabIndex = 34;
            this.Label8.Text = "Suite";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(5, 99);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(77, 13);
            this.Label7.TabIndex = 33;
            this.Label7.Text = "Ranks (Match)";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Window;
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(5, 150);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 32;
            this.textBox4.Text = "TextBox4";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Window;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(5, 114);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 31;
            this.textBox3.Text = "TextBox3";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(6, 8);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(82, 13);
            this.Label9.TabIndex = 30;
            this.Label9.Text = "Cards Found:";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(6, 62);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(62, 13);
            this.Label6.TabIndex = 29;
            this.Label6.Text = "Rank/Suite";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(6, 26);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(49, 13);
            this.Label5.TabIndex = 28;
            this.Label5.Text = "Positions";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(6, 78);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 27;
            this.textBox2.Text = "TextBox2";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(6, 41);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 26;
            this.textBox1.Text = "TextBox1";
            // 
            // PanelButtons
            // 
            this.PanelButtons.BackColor = System.Drawing.Color.Transparent;
            this.PanelButtons.Controls.Add(this.Label17);
            this.PanelButtons.Controls.Add(this.Label2);
            this.PanelButtons.Controls.Add(this.TextBox6);
            this.PanelButtons.Controls.Add(this.Label1);
            this.PanelButtons.Controls.Add(this.TextBox5);
            this.PanelButtons.Location = new System.Drawing.Point(0, 55);
            this.PanelButtons.Margin = new System.Windows.Forms.Padding(2);
            this.PanelButtons.Name = "PanelButtons";
            this.PanelButtons.Size = new System.Drawing.Size(115, 80);
            this.PanelButtons.TabIndex = 95;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.Location = new System.Drawing.Point(7, 10);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(100, 15);
            this.Label17.TabIndex = 102;
            this.Label17.Text = "Number of Cards";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(9, 50);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(60, 13);
            this.Label2.TabIndex = 101;
            this.Label2.Text = "Remaining:";
            // 
            // TextBox6
            // 
            this.TextBox6.BackColor = System.Drawing.Color.Gold;
            this.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox6.Enabled = false;
            this.TextBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox6.Location = new System.Drawing.Point(73, 50);
            this.TextBox6.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.Size = new System.Drawing.Size(25, 13);
            this.TextBox6.TabIndex = 98;
            this.TextBox6.Text = "TextBox6";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(9, 30);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(52, 13);
            this.Label1.TabIndex = 100;
            this.Label1.Text = "Matched:";
            // 
            // TextBox5
            // 
            this.TextBox5.BackColor = System.Drawing.Color.Gold;
            this.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox5.Enabled = false;
            this.TextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox5.Location = new System.Drawing.Point(73, 30);
            this.TextBox5.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Size = new System.Drawing.Size(25, 13);
            this.TextBox5.TabIndex = 99;
            this.TextBox5.Text = "TextBox5";
            // 
            // Timer1
            // 
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Interval = 50;
            // 
            // BasicCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(909, 561);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.MenuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BasicCardForm";
            this.Text = "ShuffleNDealP1";
            this.Load += new System.EventHandler(this.BasicCardForm_Load);
            this.SizeChanged += new System.EventHandler(this.BasicCardForm_SizeChanged);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicPlayerCard0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxDealerCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerCardPB)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.PanelCardsSelected.ResumeLayout(false);
            this.PanelCardsSelected.PerformLayout();
            this.PanelCardsFound.ResumeLayout(false);
            this.PanelCardsFound.PerformLayout();
            this.PanelButtons.ResumeLayout(false);
            this.PanelButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

	}
		internal System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem HowToPlayToolStripMenuItem;
		internal System.Windows.Forms.MenuStrip MenuStrip1;
		internal System.Windows.Forms.ToolStripMenuItem PlayToolStripMenuItem;
		internal System.Windows.Forms.Panel Panel1;
		internal System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem1;
		internal System.Windows.Forms.ToolStripMenuItem HowToPlayToolStripMenuItem1;
		internal System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem1;


        private static BasicCardForm _DefaultInstance;
        internal Panel Panel2;
        internal Timer Timer1;
        internal Panel PanelButtons;
        internal Timer AnimationTimer;
        private PictureBox PicBoxDealerCard1;
        private PictureBox DealerCardPB;
        internal ToolStripMenuItem DeckToolStripMenuItem;
        internal ToolStripSeparator toolStripSeparator1;
        internal ToolStripMenuItem ShowSidePanelToolStripMenuItem;
        internal ToolStripMenuItem OnSidePanelToolStripMenuItem;
        internal ToolStripMenuItem OffSideToolStripMenuItem;
        internal ToolStripMenuItem SoundToolStripMenuItem;
        internal ToolStripMenuItem OnSoundToolStripMenuItem;
        internal ToolStripMenuItem OffSoundToolStripMenuItem;
        internal ToolStripMenuItem ShowCardsToolStripMenuItem;
        internal ToolStripMenuItem OnShowCardsToolStripMenuItem;
        internal ToolStripMenuItem OffShowCardsToolStripMenuItem;
        private ToolStripMenuItem ClearCardsToolStripMenuItem;
        internal ToolStripSeparator toolStripSeparator2;
        internal Label Label17;
        internal Label Label2;
        internal Label Label1;
        private TextBox TextBox5;
        private TextBox TextBox6;
        internal Panel PanelCardsSelected;
        internal Label Label10;
        internal Label Label4;
        internal Label Label3;
        private TextBox TextBox7;
        private TextBox TextBox8;
        internal Panel PanelCardsFound;
        internal Label Label8;
        internal Label Label7;
        private TextBox textBox4;
        private TextBox textBox3;
        internal Label Label9;
        internal Label Label6;
        internal Label Label5;
        private TextBox textBox2;
        private TextBox textBox1;
        private ToolStripMenuItem ExitToolStripMenuItem;
        public Label lblShowTime;
        private PictureBox PicPlayerCard0;

        public static BasicCardForm DefaultInstance
		{
			get
			{
				if (_DefaultInstance == null)
					_DefaultInstance = new BasicCardForm();

				return _DefaultInstance;
			}
		}
	}

}