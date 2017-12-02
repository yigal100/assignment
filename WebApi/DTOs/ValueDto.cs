using WebApi.Model;

namespace WebApi.DTOs
{
    public class ValueDto
    {
        public int Value { get; set; }
        public PowerCode Magnitude { get; set; }
        public Unit Unit { get; set; }
    }
}
