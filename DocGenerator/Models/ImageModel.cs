namespace DocGenerator.Models
{
    public class ImageModel
    {
        public string CPFCNPJ { get; set; }
        public string DocumentoBase64 { get; set; }
        public int? Status { get; set; } = 1;

        public ImageModel(string cpfcnpj, string documentoBase64, int status)
        {
            CPFCNPJ = cpfcnpj;
            DocumentoBase64 = documentoBase64;
            Status = status;
        }

    }
}
