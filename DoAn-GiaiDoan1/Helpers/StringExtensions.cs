using System.Text;
using System.Text.RegularExpressions;

namespace QuanLyBanHang.Data
{
    public static class StringExtensions
    {
        public static string GenerateSlug(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            string slug = input.ToLowerInvariant();

            // bỏ dấu tiếng Việt
            slug = Regex.Replace(slug, @"[áàảãạăắằẳẵặâấầẩẫậ]", "a");
            slug = Regex.Replace(slug, @"[éèẻẽẹêếềểễệ]", "e");
            slug = Regex.Replace(slug, @"[íìỉĩị]", "i");
            slug = Regex.Replace(slug, @"[óòỏõọôốồổỗộơớờởỡợ]", "o");
            slug = Regex.Replace(slug, @"[úùủũụưứừửữự]", "u");
            slug = Regex.Replace(slug, @"[ýỳỷỹỵ]", "y");
            slug = Regex.Replace(slug, @"[đ]", "d");

            // bỏ ký tự đặc biệt
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");

            // thay khoảng trắng bằng -
            slug = Regex.Replace(slug, @"\s+", "-").Trim('-');

            return slug;
        }
    }
}