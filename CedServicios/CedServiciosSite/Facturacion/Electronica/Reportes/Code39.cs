using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace CedServicios.Site.Facturacion.Electronica.Reportes
{
    public class Code39
    {
        private const int _itemSepHeight = 3;

        SizeF _titleSize = SizeF.Empty;
        SizeF _barCodeSize = SizeF.Empty;
        SizeF _codeStringSize = SizeF.Empty;

        #region Barcode Title

        private string _titleString = null;
        private Font _titleFont = null;

        public string Title
        {
            get { return _titleString; }
            set { _titleString = value; }
        }

        public Font TitleFont
        {
            get { return _titleFont; }
            set { _titleFont = value; }
        }
        #endregion

        #region Barcode code string

        private bool _showCodeString = false;
        private Font _codeStringFont = null;

        public bool ShowCodeString
        {
            get { return _showCodeString; }
            set { _showCodeString = value; }
        }

        public Font CodeStringFont
        {
            get { return _codeStringFont; }
            set { _codeStringFont = value; }
        }
        #endregion

        #region Barcode Font

        private Font _c39Font = null;
        private float _c39FontSize = 12;
        private string _c39FontFileName = null;
        private string _c39FontFamilyName = null;

        public string FontFileName
        {
            get { return _c39FontFileName; }
            set { _c39FontFileName = value; }
        }

        public string FontFamilyName
        {
            get { return _c39FontFamilyName; }
            set { _c39FontFamilyName = value; }
        }

        public float FontSize
        {
            get { return _c39FontSize; }
            set { _c39FontSize = value; }
        }

        private Font Code39Font
        {
            get
            {
                if (_c39Font == null)
                {
                    // Load the barcode font			
                    PrivateFontCollection pfc = new PrivateFontCollection();
                    pfc.AddFontFile(_c39FontFileName);
                    FontFamily family = new FontFamily(_c39FontFamilyName, pfc);
                    _c39Font = new Font(family, _c39FontSize);
                }
                return _c39Font;
            }
        }

        #endregion

        public Code39()
        {
            _titleFont = new Font("Arial", 10);
            _codeStringFont = new Font("Arial", 10);
        }

        #region Barcode Generation

        public Bitmap GenerateBarcode(string barCode)
        {

            int bcodeWidth = 0;
            int bcodeHeight = 0;

            // Get the image container...
            Bitmap bcodeBitmap = CreateImageContainer(barCode, ref bcodeWidth, ref bcodeHeight);
            Graphics objGraphics = Graphics.FromImage(bcodeBitmap);

            // Fill the background			
            objGraphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, bcodeWidth, bcodeHeight));

            int vpos = 0;

            // Draw the title string
            if (_titleString != null)
            {
                objGraphics.DrawString(_titleString, _titleFont, new SolidBrush(Color.Black), XCentered((int)_titleSize.Width, bcodeWidth), vpos);
                vpos += (((int)_titleSize.Height) + _itemSepHeight);
            }
            // Draw the barcode
            objGraphics.DrawString(barCode, Code39Font, new SolidBrush(Color.Black), XCentered((int)_barCodeSize.Width, bcodeWidth), vpos);

            // Draw the barcode string
            if (_showCodeString)
            {
                vpos += (((int)_barCodeSize.Height));
                objGraphics.DrawString(barCode, _codeStringFont, new SolidBrush(Color.Black), XCentered((int)_codeStringSize.Width, bcodeWidth), vpos);
            }

            // return the image...									
            return bcodeBitmap;
        }

        private Bitmap CreateImageContainer(string barCode, ref int bcodeWidth, ref int bcodeHeight)
        {

            Graphics objGraphics;

            // Create a temporary bitmap...
            Bitmap tmpBitmap = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
            objGraphics = Graphics.FromImage(tmpBitmap);

            // calculate size of the barcode items...
            if (_titleString != null)
            {
                _titleSize = objGraphics.MeasureString(_titleString, _titleFont);
                bcodeWidth = (int)_titleSize.Width;
                bcodeHeight = (int)_titleSize.Height + _itemSepHeight;
            }

            _barCodeSize = objGraphics.MeasureString(barCode, Code39Font);
            bcodeWidth = Max(bcodeWidth, (int)_barCodeSize.Width);
            bcodeHeight += (int)_barCodeSize.Height;

            if (_showCodeString)
            {
                _codeStringSize = objGraphics.MeasureString(barCode, _codeStringFont);
                bcodeWidth = Max(bcodeWidth, (int)_codeStringSize.Width);
                bcodeHeight += (_itemSepHeight + (int)_codeStringSize.Height);
            }

            // dispose temporary objects...
            objGraphics.Dispose();
            tmpBitmap.Dispose();

            return (new Bitmap(bcodeWidth, bcodeHeight, PixelFormat.Format32bppArgb));
        }

        #endregion


        #region Auxiliary Methods

        private int Max(int v1, int v2)
        {
            return (v1 > v2 ? v1 : v2);
        }

        private int XCentered(int localWidth, int globalWidth)
        {
            return ((globalWidth - localWidth) / 2);
        }

        #endregion

    }

}
