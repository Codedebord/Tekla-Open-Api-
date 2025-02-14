using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tekla.Structures.Model;
using T3d = Tekla.Structures.Geometry3d;

namespace BeamV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Model myModel = new Model();
            if (myModel.GetConnectionStatus())
            {
                Tekla.Structures.Model.UI.Picker _picker = new Tekla.Structures.Model.UI.Picker();
                T3d.Point startPoint = _picker.PickPoint("PicK The start Point");
                T3d.Point endPoint = _picker.PickPoint("PicK The end Point");

                Beam myBeam = new Beam(startPoint, endPoint);
                myBeam.Profile.ProfileString = "HEB200";
                myBeam.Material.MaterialString = "S235";
                myBeam.Class = "3";
                myBeam.Position.Depth = Position.DepthEnum.BEHIND;
                myBeam.Position.Rotation = Position.RotationEnum.TOP;

                myBeam.Insert();
                myModel.CommitChanges();
            }
    }
}
}
