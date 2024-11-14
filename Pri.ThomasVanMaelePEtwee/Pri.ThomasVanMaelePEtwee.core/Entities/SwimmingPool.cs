namespace Pri.ThomasVanMaelePEtwee.core.Entities
{
    public class SwimmingPool
    {
        public int Id { get; set; }  
        public string Name { get; set; }
        public float Length { get; set; }  
        public float Width { get; set; }   
        public float Depth { get; set; }   
        public bool HasHeating { get; set; }
        public int QuotationId { get; set; }
        public Quotation Quotation { get; set; }
    }
}
