using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpPDFLabel.Labels.A4Labels.Avery;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SharpPDFLabel.Tests
{
    [TestClass]
    public class CustomLabelCreatorTests
    {
        [TestMethod]
        public void TestCreateAPdf()
        {

            var labelDefinition = new L5162();
            var labelCreator = new CustomLabelCreator(labelDefinition) {
                IncludeLabelBorders = true
            };

            var bitmap = new Bitmap(600, 600);
            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    bitmap.SetPixel(x, y, Color.BlueViolet);
                }
            }
            byte[] result = null;
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                result = stream.ToArray();
            }

            for (var i = 1; i <= 30; i++) {
                var label = new Label(Enums.Alignment.CENTER);
                label.AddImage(result);
                label.AddText("Person Name " + i.ToString(), "Verdana", 12, embedFont: true);
                label.AddText("Person Name2 " + i.ToString(), "Verdana", 12, embedFont: true);
                labelCreator.AddLabel(label);
            }


            var pdfStream = labelCreator.CreatePDF();

            var fileStream = File.Create(@".\pdf5160.pdf");
            pdfStream.CopyTo(fileStream);
            fileStream.Close();
            pdfStream.Close();

            // yeah, lame test
            Assert.IsTrue(File.Exists(@".\pdf5160.pdf"));


            // I comment this out to look at the pdf..
            // how would you test this?
            //File.Delete(@".\pdf5160.pdf");

        }
    }
}
