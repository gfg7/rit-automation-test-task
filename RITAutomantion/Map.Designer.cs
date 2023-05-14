namespace RITAutomantion
{
    partial class Map
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MapControl = new GMap.NET.WindowsForms.GMapControl();
            this.LoadMarkersWorker = new System.ComponentModel.BackgroundWorker();
            this.LoadingBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // MapControl
            // 
            this.MapControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MapControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MapControl.Bearing = 0F;
            this.MapControl.CanDragMap = true;
            this.MapControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.MapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapControl.EmptyTileColor = System.Drawing.Color.Transparent;
            this.MapControl.GrayScaleMode = false;
            this.MapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MapControl.LevelsKeepInMemmory = 5;
            this.MapControl.Location = new System.Drawing.Point(0, 0);
            this.MapControl.MarkersEnabled = true;
            this.MapControl.MaxZoom = 100;
            this.MapControl.MinZoom = 2;
            this.MapControl.MouseWheelZoomEnabled = true;
            this.MapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MapControl.Name = "MapControl";
            this.MapControl.NegativeMode = false;
            this.MapControl.PolygonsEnabled = true;
            this.MapControl.RetryLoadTile = 0;
            this.MapControl.RoutesEnabled = false;
            this.MapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MapControl.ShowTileGridLines = false;
            this.MapControl.Size = new System.Drawing.Size(929, 530);
            this.MapControl.TabIndex = 0;
            this.MapControl.Zoom = 2D;
            this.MapControl.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.MapControl_OnMarkerEnter);
            this.MapControl.OnMarkerLeave += new GMap.NET.WindowsForms.MarkerLeave(this.MapControl_OnMarkerLeave);
            this.MapControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseDown);
            this.MapControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseMove);
            this.MapControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseUp);
            // 
            // LoadMarkersWorker
            // 
            this.LoadMarkersWorker.WorkerReportsProgress = true;
            this.LoadMarkersWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadMarkersWorker_DoWork);
            this.LoadMarkersWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadMarkersWorker_RunWorkerCompleted);
            // 
            // LoadingBar
            // 
            this.LoadingBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LoadingBar.Location = new System.Drawing.Point(0, 507);
            this.LoadingBar.Name = "LoadingBar";
            this.LoadingBar.Size = new System.Drawing.Size(929, 23);
            this.LoadingBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.LoadingBar.TabIndex = 1;
            this.LoadingBar.Visible = false;
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 530);
            this.Controls.Add(this.LoadingBar);
            this.Controls.Add(this.MapControl);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Map";
            this.Text = "RIT Automation - Task 1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Map_FormClosing);
            this.Load += new System.EventHandler(this.Map_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl MapControl;
        private System.ComponentModel.BackgroundWorker LoadMarkersWorker;
        private System.Windows.Forms.ProgressBar LoadingBar;
    }
}

