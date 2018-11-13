using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emotex
{
    public static class Helpers
    {
        public class DataGridViewPallete
        {
            public Font Font { get; set; }
            public int HeaderHeight { get; set; }
            public int RowHeight { get; set; }

            // color pallete
            public Color ForeColor { get; set; }
            public Color BackColor { get; set; }

            // alternate color
            public DataGridViewCellStyle HeaderStyle { get; set; }
            public DataGridViewCellStyle CellStyle { get; set; }
            public DataGridViewCellStyle AlternatingRowCellStyle { get; set; }

            public DataGridViewPallete()
            {
                var font = new Font("Segoe UI", 9.87F, FontStyle.Regular, GraphicsUnit.Point, 0);

                // global style
                Font = font;
                BackColor = Color.Black;
                ForeColor = Color.White;
                RowHeight = 25;
                HeaderHeight = 30;

                // column header
                HeaderStyle = new DataGridViewCellStyle
                {
                    Font = font,
                    ForeColor = Color.White,
                    BackColor = Color.Black,
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                };

                // cell style
                CellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.Gray,
                    SelectionBackColor = Color.FromArgb(35, 168, 109),
                    SelectionForeColor = Color.White
                };

                // alternating cell style
                AlternatingRowCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.SlateGray
                };
            }
        }

        public static void ApplyStyle(ref DataGridView control)
        {
            var pallete = new DataGridViewPallete();
         
            // globals
            control.Font = pallete.Font;
            control.BackColor = pallete.BackColor;
            control.ForeColor = pallete.ForeColor;
            control.BorderStyle = BorderStyle.None;
            control.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // column header
            control.EnableHeadersVisualStyles = false;
            control.ColumnHeadersHeight = pallete.HeaderHeight;
            control.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            control.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // rows
            control.RowHeadersVisible = false;
            control.RowTemplate.Height = pallete.RowHeight;
            control.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            control.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            control.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // cell style
            control.ColumnHeadersDefaultCellStyle = pallete.HeaderStyle;
            control.DefaultCellStyle = pallete.CellStyle;
            control.AlternatingRowsDefaultCellStyle = pallete.AlternatingRowCellStyle;

            // enable double buffer
            var type = typeof(Control);
            var prop = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            Debug.Assert(prop != null, "prop != null");
            prop.SetValue(control, true, null);
        }
    }
}
