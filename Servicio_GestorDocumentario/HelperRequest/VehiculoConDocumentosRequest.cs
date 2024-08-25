using Domain.DTOS;

namespace Servicio_GestorDocumentario.HelperRequest
{
    public class VehiculoConDocumentosRequest
    {
        public DTOVehiculos Vehiculo { get; set; }
        public List<DTODocVehiculos> Documentos { get; set; }
    }
}
