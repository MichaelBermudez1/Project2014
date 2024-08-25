using Domain.DTOS;

namespace Servicio_GestorDocumentario.HelperRequest
{
    public class ColaboradorConDocumentosRequest
    {
        public DTOGestorColaboradores Colaboradores { get; set; }
        public List<DTOGestorDocColaboradores> Documentos { get; set; }
    }
}
