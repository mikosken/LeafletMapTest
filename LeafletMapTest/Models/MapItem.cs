using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace LeafletMapTest.Models
{
    public class MapItem
    {
        public int Id { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Name { get; set; }
        public string? StreetName { get; set; }
        public string? StreetNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        [NotMapped]
        public string FullAddress { 
            get {
                string fa = $"{StreetName} {StreetNumber}, {PostalCode} {City}, {Country}";
                // Remove whitespaces immediately before ','.
                fa = Regex.Replace(fa, @"\s+,+", ",");
                // Remove multiple consecutive ','.
                fa = Regex.Replace(fa, @",+", ",");
                // In case some values were null, remove excess whitespaces.
                fa = Regex.Replace(fa, @"(\s)\s+", "$1");
                // Trim whitespaces and ','.
                fa = Regex.Replace(fa, @"^[\s,]+|[\s,]+$", "");
                return fa;
            }
        }
    }
}
