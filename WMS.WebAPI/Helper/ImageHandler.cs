using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;

namespace WMS.WebAPI.Helper
{
    public static class ImageHandler
    {
        public static byte[] ResizeImage(byte[] imageBytes, int maxWidth, int maxHeight)
        {
            using var inputStream = new MemoryStream(imageBytes);
            using var originalImage = Image.FromStream(inputStream);

            // Tính toán tỷ lệ
            var ratioX = (double)maxWidth / originalImage.Width;
            var ratioY = (double)maxHeight / originalImage.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(originalImage.Width * ratio);
            var newHeight = (int)(originalImage.Height * ratio);

            // Tạo ảnh mới
            using var newImage = new Bitmap(newWidth, newHeight);
            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;

                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            using var outputStream = new MemoryStream();
            newImage.Save(outputStream, ImageFormat.Png);
            return outputStream.ToArray();
        }
    }
}
