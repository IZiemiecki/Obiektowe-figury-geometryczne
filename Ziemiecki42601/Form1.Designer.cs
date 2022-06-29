namespace Ziemiecki42601
{
    partial class Ziemiecki42601
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.iz_label1 = new System.Windows.Forms.Label();
            this.iz_btnStart = new System.Windows.Forms.Button();
            this.iz_btnMoveAll = new System.Windows.Forms.Button();
            this.iz_btnMoveAndChangeAll = new System.Windows.Forms.Button();
            this.iz_btnChangeAll = new System.Windows.Forms.Button();
            this.iz_btnAdd = new System.Windows.Forms.Button();
            this.iz_btnClear = new System.Windows.Forms.Button();
            this.iz_pbBoard = new System.Windows.Forms.PictureBox();
            this.iz_lblWzierniki = new System.Windows.Forms.Label();
            this.iz_lblKolor = new System.Windows.Forms.Label();
            this.iz_lblGrubosc = new System.Windows.Forms.Label();
            this.iz_lblRodzaj = new System.Windows.Forms.Label();
            this.iz_lblPedzel = new System.Windows.Forms.Label();
            this.iz_ColorDialog = new System.Windows.Forms.ColorDialog();
            this.iz_numThickness = new System.Windows.Forms.NumericUpDown();
            this.iz_dType = new System.Windows.Forms.DomainUpDown();
            this.iz_nNumber = new System.Windows.Forms.NumericUpDown();
            this.iz_lblCheck = new System.Windows.Forms.Label();
            this.iz_chList = new System.Windows.Forms.CheckedListBox();
            this.iz_lblColor = new System.Windows.Forms.Label();
            this.iz_lblBrush = new System.Windows.Forms.Label();
            this.iz_btnCyfry = new System.Windows.Forms.Button();
            this.iz_btnDelete = new System.Windows.Forms.Button();
            this.iz_numDelete = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.iz_pbBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_numThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_nNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_numDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // iz_label1
            // 
            this.iz_label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.iz_label1.Location = new System.Drawing.Point(23, 8);
            this.iz_label1.Name = "iz_label1";
            this.iz_label1.Size = new System.Drawing.Size(143, 35);
            this.iz_label1.TabIndex = 0;
            this.iz_label1.Text = "Podaj liczbę figur geomatrycznych";
            this.iz_label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iz_btnStart
            // 
            this.iz_btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.iz_btnStart.Location = new System.Drawing.Point(12, 72);
            this.iz_btnStart.Name = "iz_btnStart";
            this.iz_btnStart.Size = new System.Drawing.Size(164, 44);
            this.iz_btnStart.TabIndex = 2;
            this.iz_btnStart.Text = "Rysowanie losowe w oparciu o listę";
            this.iz_btnStart.UseVisualStyleBackColor = true;
            this.iz_btnStart.Click += new System.EventHandler(this.iz_btnStart_Click);
            // 
            // iz_btnMoveAll
            // 
            this.iz_btnMoveAll.Location = new System.Drawing.Point(12, 122);
            this.iz_btnMoveAll.Name = "iz_btnMoveAll";
            this.iz_btnMoveAll.Size = new System.Drawing.Size(164, 35);
            this.iz_btnMoveAll.TabIndex = 3;
            this.iz_btnMoveAll.Text = "Przesunięcie do nowego miejsca";
            this.iz_btnMoveAll.UseVisualStyleBackColor = true;
            this.iz_btnMoveAll.Click += new System.EventHandler(this.iz_btnMoveAll_Click);
            // 
            // iz_btnMoveAndChangeAll
            // 
            this.iz_btnMoveAndChangeAll.Location = new System.Drawing.Point(12, 181);
            this.iz_btnMoveAndChangeAll.Name = "iz_btnMoveAndChangeAll";
            this.iz_btnMoveAndChangeAll.Size = new System.Drawing.Size(164, 37);
            this.iz_btnMoveAndChangeAll.TabIndex = 4;
            this.iz_btnMoveAndChangeAll.Text = "Wylosuj nowe położenie oraz atrybuty figur geometrycznych";
            this.iz_btnMoveAndChangeAll.UseVisualStyleBackColor = true;
            this.iz_btnMoveAndChangeAll.Click += new System.EventHandler(this.iz_btnMoveAndChangeAll_Click);
            // 
            // iz_btnChangeAll
            // 
            this.iz_btnChangeAll.Location = new System.Drawing.Point(12, 224);
            this.iz_btnChangeAll.Name = "iz_btnChangeAll";
            this.iz_btnChangeAll.Size = new System.Drawing.Size(164, 37);
            this.iz_btnChangeAll.TabIndex = 5;
            this.iz_btnChangeAll.Text = "Wylosuj nowe atrybuty dla figur geometrycznych";
            this.iz_btnChangeAll.UseVisualStyleBackColor = true;
            this.iz_btnChangeAll.Click += new System.EventHandler(this.iz_btnChangeAll_Click);
            // 
            // iz_btnAdd
            // 
            this.iz_btnAdd.Location = new System.Drawing.Point(12, 385);
            this.iz_btnAdd.Name = "iz_btnAdd";
            this.iz_btnAdd.Size = new System.Drawing.Size(164, 37);
            this.iz_btnAdd.TabIndex = 6;
            this.iz_btnAdd.Text = "Dodaj nową (nowe) figurę z listy";
            this.iz_btnAdd.UseVisualStyleBackColor = true;
            this.iz_btnAdd.Click += new System.EventHandler(this.iz_btnAdd_Click);
            // 
            // iz_btnClear
            // 
            this.iz_btnClear.Location = new System.Drawing.Point(12, 428);
            this.iz_btnClear.Name = "iz_btnClear";
            this.iz_btnClear.Size = new System.Drawing.Size(164, 25);
            this.iz_btnClear.TabIndex = 7;
            this.iz_btnClear.Text = "Czyść";
            this.iz_btnClear.UseVisualStyleBackColor = true;
            this.iz_btnClear.Click += new System.EventHandler(this.iz_btnClear_Click);
            // 
            // iz_pbBoard
            // 
            this.iz_pbBoard.BackColor = System.Drawing.Color.White;
            this.iz_pbBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iz_pbBoard.Location = new System.Drawing.Point(185, 12);
            this.iz_pbBoard.Name = "iz_pbBoard";
            this.iz_pbBoard.Size = new System.Drawing.Size(567, 432);
            this.iz_pbBoard.TabIndex = 8;
            this.iz_pbBoard.TabStop = false;
            // 
            // iz_lblWzierniki
            // 
            this.iz_lblWzierniki.AutoSize = true;
            this.iz_lblWzierniki.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.iz_lblWzierniki.Location = new System.Drawing.Point(182, 447);
            this.iz_lblWzierniki.Name = "iz_lblWzierniki";
            this.iz_lblWzierniki.Size = new System.Drawing.Size(203, 17);
            this.iz_lblWzierniki.TabIndex = 9;
            this.iz_lblWzierniki.Text = "Wzierniki narzędzi graficznych:";
            // 
            // iz_lblKolor
            // 
            this.iz_lblKolor.AutoSize = true;
            this.iz_lblKolor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.iz_lblKolor.Location = new System.Drawing.Point(182, 468);
            this.iz_lblKolor.Name = "iz_lblKolor";
            this.iz_lblKolor.Size = new System.Drawing.Size(45, 17);
            this.iz_lblKolor.TabIndex = 10;
            this.iz_lblKolor.Text = "Kolor:";
            // 
            // iz_lblGrubosc
            // 
            this.iz_lblGrubosc.AutoSize = true;
            this.iz_lblGrubosc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.iz_lblGrubosc.Location = new System.Drawing.Point(295, 468);
            this.iz_lblGrubosc.Name = "iz_lblGrubosc";
            this.iz_lblGrubosc.Size = new System.Drawing.Size(90, 17);
            this.iz_lblGrubosc.TabIndex = 11;
            this.iz_lblGrubosc.Text = "Grubość linii:";
            // 
            // iz_lblRodzaj
            // 
            this.iz_lblRodzaj.AutoSize = true;
            this.iz_lblRodzaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.iz_lblRodzaj.Location = new System.Drawing.Point(431, 468);
            this.iz_lblRodzaj.Name = "iz_lblRodzaj";
            this.iz_lblRodzaj.Size = new System.Drawing.Size(80, 17);
            this.iz_lblRodzaj.TabIndex = 12;
            this.iz_lblRodzaj.Text = "Rodzaj linii:";
            // 
            // iz_lblPedzel
            // 
            this.iz_lblPedzel.AutoSize = true;
            this.iz_lblPedzel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.iz_lblPedzel.Location = new System.Drawing.Point(624, 468);
            this.iz_lblPedzel.Name = "iz_lblPedzel";
            this.iz_lblPedzel.Size = new System.Drawing.Size(55, 17);
            this.iz_lblPedzel.TabIndex = 13;
            this.iz_lblPedzel.Text = "Pędzel:";
            // 
            // iz_numThickness
            // 
            this.iz_numThickness.Location = new System.Drawing.Point(387, 468);
            this.iz_numThickness.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.iz_numThickness.Name = "iz_numThickness";
            this.iz_numThickness.ReadOnly = true;
            this.iz_numThickness.Size = new System.Drawing.Size(38, 20);
            this.iz_numThickness.TabIndex = 16;
            this.iz_numThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // iz_dType
            // 
            this.iz_dType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.iz_dType.Items.Add("_________");
            this.iz_dType.Items.Add("- - - - - -");
            this.iz_dType.Items.Add("- • - • - •");
            this.iz_dType.Items.Add("- • • - • •");
            this.iz_dType.Items.Add("• • • • • •");
            this.iz_dType.Location = new System.Drawing.Point(517, 468);
            this.iz_dType.Name = "iz_dType";
            this.iz_dType.ReadOnly = true;
            this.iz_dType.Size = new System.Drawing.Size(101, 26);
            this.iz_dType.TabIndex = 17;
            this.iz_dType.Text = "_________";
            this.iz_dType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // iz_nNumber
            // 
            this.iz_nNumber.Location = new System.Drawing.Point(42, 46);
            this.iz_nNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.iz_nNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iz_nNumber.Name = "iz_nNumber";
            this.iz_nNumber.Size = new System.Drawing.Size(113, 20);
            this.iz_nNumber.TabIndex = 19;
            this.iz_nNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.iz_nNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // iz_lblCheck
            // 
            this.iz_lblCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.iz_lblCheck.Location = new System.Drawing.Point(758, 29);
            this.iz_lblCheck.Name = "iz_lblCheck";
            this.iz_lblCheck.Size = new System.Drawing.Size(182, 52);
            this.iz_lblCheck.TabIndex = 20;
            this.iz_lblCheck.Text = "Zacznacz które figury mają być losowane i wyświetlane na planszy graficznej";
            // 
            // iz_chList
            // 
            this.iz_chList.CheckOnClick = true;
            this.iz_chList.FormattingEnabled = true;
            this.iz_chList.Items.AddRange(new object[] {
            "Punkt",
            "Okrąg",
            "Koło jednobarwne",
            "Koło ze wzorem",
            "Elipsa",
            "Elipsa jednobarwna",
            "Elipsa ze wzorem",
            "Kwadrat",
            "Kwadrat jednobarwny",
            "Kwadrat ze wzorem",
            "Prostokąt",
            "Prostokąt jednobarwny",
            "Prostojąt ze wzorem"});
            this.iz_chList.Location = new System.Drawing.Point(758, 84);
            this.iz_chList.Name = "iz_chList";
            this.iz_chList.Size = new System.Drawing.Size(182, 199);
            this.iz_chList.TabIndex = 21;
            // 
            // iz_lblColor
            // 
            this.iz_lblColor.BackColor = System.Drawing.Color.Black;
            this.iz_lblColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.iz_lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.iz_lblColor.Location = new System.Drawing.Point(233, 468);
            this.iz_lblColor.Name = "iz_lblColor";
            this.iz_lblColor.Size = new System.Drawing.Size(56, 17);
            this.iz_lblColor.TabIndex = 22;
            this.iz_lblColor.Click += new System.EventHandler(this.iz_lblColor_Click);
            // 
            // iz_lblBrush
            // 
            this.iz_lblBrush.BackColor = System.Drawing.Color.Black;
            this.iz_lblBrush.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.iz_lblBrush.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.iz_lblBrush.Location = new System.Drawing.Point(685, 468);
            this.iz_lblBrush.Name = "iz_lblBrush";
            this.iz_lblBrush.Size = new System.Drawing.Size(56, 17);
            this.iz_lblBrush.TabIndex = 23;
            this.iz_lblBrush.Click += new System.EventHandler(this.iz_lblBrush_Click);
            // 
            // iz_btnCyfry
            // 
            this.iz_btnCyfry.Location = new System.Drawing.Point(12, 267);
            this.iz_btnCyfry.Name = "iz_btnCyfry";
            this.iz_btnCyfry.Size = new System.Drawing.Size(164, 25);
            this.iz_btnCyfry.TabIndex = 24;
            this.iz_btnCyfry.Text = "Pokaż numery obiektów";
            this.iz_btnCyfry.UseVisualStyleBackColor = true;
            this.iz_btnCyfry.Click += new System.EventHandler(this.iz_btnCyfry_Click);
            // 
            // iz_btnDelete
            // 
            this.iz_btnDelete.Location = new System.Drawing.Point(12, 298);
            this.iz_btnDelete.Name = "iz_btnDelete";
            this.iz_btnDelete.Size = new System.Drawing.Size(164, 39);
            this.iz_btnDelete.TabIndex = 25;
            this.iz_btnDelete.Text = "Usuń figurę o podanym numerze:";
            this.iz_btnDelete.UseVisualStyleBackColor = true;
            this.iz_btnDelete.Click += new System.EventHandler(this.iz_btnDelete_Click);
            // 
            // iz_numDelete
            // 
            this.iz_numDelete.Location = new System.Drawing.Point(42, 343);
            this.iz_numDelete.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.iz_numDelete.Name = "iz_numDelete";
            this.iz_numDelete.Size = new System.Drawing.Size(113, 20);
            this.iz_numDelete.TabIndex = 26;
            this.iz_numDelete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Ziemiecki42601
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(952, 504);
            this.Controls.Add(this.iz_numDelete);
            this.Controls.Add(this.iz_btnDelete);
            this.Controls.Add(this.iz_btnCyfry);
            this.Controls.Add(this.iz_lblBrush);
            this.Controls.Add(this.iz_lblColor);
            this.Controls.Add(this.iz_chList);
            this.Controls.Add(this.iz_lblCheck);
            this.Controls.Add(this.iz_nNumber);
            this.Controls.Add(this.iz_dType);
            this.Controls.Add(this.iz_numThickness);
            this.Controls.Add(this.iz_lblPedzel);
            this.Controls.Add(this.iz_lblRodzaj);
            this.Controls.Add(this.iz_lblGrubosc);
            this.Controls.Add(this.iz_lblKolor);
            this.Controls.Add(this.iz_lblWzierniki);
            this.Controls.Add(this.iz_pbBoard);
            this.Controls.Add(this.iz_btnClear);
            this.Controls.Add(this.iz_btnAdd);
            this.Controls.Add(this.iz_btnChangeAll);
            this.Controls.Add(this.iz_btnMoveAndChangeAll);
            this.Controls.Add(this.iz_btnMoveAll);
            this.Controls.Add(this.iz_btnStart);
            this.Controls.Add(this.iz_label1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Ziemiecki42601";
            this.ShowIcon = false;
            this.Text = "Ziemiecki42601";
            ((System.ComponentModel.ISupportInitialize)(this.iz_pbBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_numThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_nNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_numDelete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label iz_label1;
        private System.Windows.Forms.Button iz_btnStart;
        private System.Windows.Forms.Button iz_btnMoveAll;
        private System.Windows.Forms.Button iz_btnMoveAndChangeAll;
        private System.Windows.Forms.Button iz_btnChangeAll;
        private System.Windows.Forms.Button iz_btnAdd;
        private System.Windows.Forms.Button iz_btnClear;
        private System.Windows.Forms.PictureBox iz_pbBoard;
        private System.Windows.Forms.Label iz_lblWzierniki;
        private System.Windows.Forms.Label iz_lblKolor;
        private System.Windows.Forms.Label iz_lblGrubosc;
        private System.Windows.Forms.Label iz_lblRodzaj;
        private System.Windows.Forms.Label iz_lblPedzel;
        private System.Windows.Forms.ColorDialog iz_ColorDialog;
        private System.Windows.Forms.NumericUpDown iz_numThickness;
        private System.Windows.Forms.DomainUpDown iz_dType;
        private System.Windows.Forms.NumericUpDown iz_nNumber;
        private System.Windows.Forms.CheckedListBox iz_chList;
        private System.Windows.Forms.Label iz_lblCheck;
        private System.Windows.Forms.Label iz_lblBrush;
        private System.Windows.Forms.Label iz_lblColor;
        private System.Windows.Forms.Button iz_btnCyfry;
        private System.Windows.Forms.Button iz_btnDelete;
        private System.Windows.Forms.NumericUpDown iz_numDelete;
    }
}

